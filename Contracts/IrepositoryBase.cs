using System;
using System.Collections.Generic;

namespace Leave_Management.Contracts
{
    public interface IrepositoryBase<T> where T:class
    {
        //here we perform the CRUD operation
        ICollection<T> FindAll();

        T FindById(int id);

        bool Create(T entity);

        bool Update(T entity);

        bool Delete(T entity);

        bool save();


    }
}
