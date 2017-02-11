using Restapp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Restapp.Repositories
{
    public class BaseRepository<T> where T: class
    {
        protected DbSet<T> _table;

        protected RestappDB _db = new RestappDB();

        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public T Get(int id)
        {
            return _table.Find(id);
        }

        public void Delete(int id)
        {
            _table.Remove(Get(id));
            _db.SaveChanges();
        }

        public void Save(T entity)
        {
            _table.Add(entity);
            _db.SaveChanges();
        }

        public DbSet<T> GetTable()
        {
            return _table;
        }
    }
}