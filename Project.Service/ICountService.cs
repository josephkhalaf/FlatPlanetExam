using System.Linq;
using Project.BusinessObject;

namespace Project.Service
{
    public interface ICountService
    {
        Count GetById(int id);
        IQueryable<Count> GetAll();
        void Insert(Count count);
        void Update(Count count);
    }
}
