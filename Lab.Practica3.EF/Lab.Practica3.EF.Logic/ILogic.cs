using Lab.Practica6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
