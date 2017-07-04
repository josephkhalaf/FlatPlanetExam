using System.Linq;

namespace Project.Data
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IQueryable<T> GetAll();
        void Insert(T domainModel);
        void Update(T domainModel);
    }
}
