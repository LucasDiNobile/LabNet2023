using System.Collections.Generic;

namespace Lab.Practica6.Logic
{
    public interface ILogic<T>
    {
        List<T> GetAll();

        void Delete(T entity);

        void Update(T entity);

        void Insert(T entity);
    }
}
