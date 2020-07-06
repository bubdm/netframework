using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.EF;
using AutoLotDAL.Models.Base;

namespace AutoLotDAL.Repos
{
    /// <summary> Базовый класс хранилища </summary>
    public class BaseRepo<T> : IDisposable, IRepo<T> where T:EntityBase, new()
    {
        private readonly AutoLotEntities _entities;
        private readonly DbSet<T> _table;
        public BaseRepo()
        {
            _entities = new AutoLotEntities();
            _table = _entities.Set<T>();
        }
        protected AutoLotEntities Context => _entities;
        public void Dispose() => _entities?.Dispose();
        internal int SaveChanges()
        {
            try
            {
                return _entities.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            { //ошибка параллелизма
                throw;
            }
            catch (DbUpdateException ex)
            { //обновление терпит неудачу
                throw;
            }
            catch (CommitFailedException ex)
            { //отказы транзакции
                throw;
            }
            catch (Exception ex)
            { //другое исключение
                throw;
            }
        }
        /// <summary> Извлечение одной записи </summary>
        public T GetOne(int? id) => _table.Find(id);
        /// <summary> Извлечение всех записей </summary>
        public List<T> GetAll() => _table.ToList();
        /// <summary> Извлечение с помощью кода SQL ОПАСНО! </summary>
        public List<T> ExecuteQuery(string sql) => _table.SqlQuery(sql).ToList();

        /// <summary> Извлечение с помощью кода SQL ОПАСНО! </summary>
        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects) 
            => _table.SqlQuery(sql, sqlParametersObjects).ToList();
        /// <summary> Добавление одной записи </summary>
        public int Add(T entity)
        {
            _table.Add(entity);
            return SaveChanges();
        }
        /// <summary> Добавление кипы записей </summary>
        public int AddRange(IList<T> entities)
        {
            _table.AddRange(entities);
            return SaveChanges();
        }
        /// <summary> Обновление записей </summary>
        public int Save(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        /// <summary> Удаление записей </summary>
        public int Delete(int id, byte[] timeStamp)
        {
            _entities.Entry(new T() {Id = id, Timestamp = timeStamp}).State = EntityState.Deleted;
            return SaveChanges();
        }
        /// <summary> Удаление записей </summary>
        public int Delete(T entity)
        {
            _entities.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }
    }
}
