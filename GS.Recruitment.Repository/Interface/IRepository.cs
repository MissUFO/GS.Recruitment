using System;
using System.Collections.Generic;

namespace GS.Recruitment.Repository.Interface
{
    public interface IRepository<T>
    {
        string ConnectionString { get; set; }

        T Get(Guid id);
        bool AddEdit(T entity);
        List<T> List();
        bool Delete(Guid id);
    }
}
