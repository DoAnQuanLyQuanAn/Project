using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IRepository<T>  where T : class
    {
        void Create(T obj);
        int Delete(T obj);
        int Update(T obj);
        T Select();
    }
}
