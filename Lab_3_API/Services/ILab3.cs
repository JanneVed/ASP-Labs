using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_3_API.Services
{
    public interface ILab3<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetSingle(int id);

        IEnumerable<T> Search(string name);

        Task<T> Add(T newEntity);

        Task<T> Update(T Entity);

        Task<T> Delete(int id);
    }
}
