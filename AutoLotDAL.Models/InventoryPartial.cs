namespace AutoLotDAL.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Inventory
    {
        public override string ToString()
        {
            return $"{Name ?? "<без имени>"} цвета {Color} марки {Make} c Id {Id}";
        }
        [NotMapped]
        public string MakeColor => $"{Make} + {Color}";
    }
}
