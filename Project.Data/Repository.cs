using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Project.BusinessObject;

namespace Project.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : AbstractEntity
    {
        protected readonly DbContext Context;
        public Repository()
        {
            Context = new FlatPlanetDbEntities();
        }
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public void Insert(TEntity domainModel)
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));

            Context.Set<TEntity>().Add(domainModel);
            Save();
        }

        public void Update(TEntity domainModel)
        {
            if (domainModel == null) throw new ArgumentNullException(nameof(domainModel));

            var entity = Get(domainModel.Id);
            if (entity != null)
            {
                Context.Set<TEntity>().AddOrUpdate(domainModel);
                Save();
            }
        }

        private void Save()
        {
            Context.SaveChanges();
        }
    }
}
