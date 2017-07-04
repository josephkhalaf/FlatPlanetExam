using System.Linq;
using Project.BusinessObject;
using Project.Data;

namespace Project.Service
{
    public class CountService : ICountService
    {
        private readonly IRepository<Count> Repository;

        public CountService()
        {
            Repository = new Repository<Count>();
        }

        public Count GetById(int id)
        {
            return Repository.Get(id);
        }

        public IQueryable<Count> GetAll()
        {
            return Repository.GetAll();
        }

        public void Insert(Count count)
        {
            Repository.Insert(count);
        }

        public void Update(Count count)
        {
            Repository.Update(count);
        }
    }
}
