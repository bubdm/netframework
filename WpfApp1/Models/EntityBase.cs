using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WpfApp1.Models
{
    public class EntityBase : INotifyDataErrorInfo
    {
        protected string[] GetErrorsFromAnnotations<T>(string propertyName, T value)
        {
            var results = new List<ValidationResult>();
            var vc = new ValidationContext(this, null, null) {MemberName = propertyName};
            var isValid = Validator.TryValidateProperty(value, vc, results);
            return (isValid) ? null : Array.ConvertAll(results.ToArray(), o => o.ErrorMessage);
        }

        
        //хранение всех сведений о ошибках, сгруппированные по именам свойств
        protected readonly Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        //возвращает любые ошибки в словаре, когда в параметре пустая сторока или null, если имя свойства - то ошибки этого свойства
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return errors.Values;
            }
            return errors.ContainsKey(propertyName) ? errors[propertyName] : null;
        }
        //истина если в словаре присуствуют любые ошибки
        public bool HasErrors => errors.Count != 0;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        //вспомогательный метод инициирования события ErrorChanged
        protected void OnErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        //добавление ошибок
        protected void AddError(string propertyName, string error)
        {
            AddErrors(propertyName, new List<string>{error});
        }
        protected void AddErrors(string propertyName, IList<string> errors)
        {
            if (errors == null || errors?.Count == 0) 
                return;
            var changed = false;
            if (!this.errors.ContainsKey(propertyName))
            {
                this.errors.Add(propertyName, new List<string>());
                changed = true;
            }
            foreach (var err in errors)
            {
                if (this.errors[propertyName].Contains(err)) continue;
                this.errors[propertyName].Add(err);
                changed = true;
            }
            if (changed)
                OnErrorChanged(propertyName);
        }
        //удаление ошибок
        protected void ClearErrors(string propertyName = "")
        {
            if (string.IsNullOrEmpty(propertyName))
                errors.Clear();
            else
                errors.Remove(propertyName);
            OnErrorChanged(propertyName);
        }

    }
}
