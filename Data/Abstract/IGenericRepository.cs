using System.Collections.Generic;

namespace Data.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        bool Insert(T model);

        bool Delete(int id);

        T Get(int id);

        List<T> GetAll();
    }
}
