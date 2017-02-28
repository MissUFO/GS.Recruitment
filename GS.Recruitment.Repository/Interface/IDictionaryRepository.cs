using System;
using System.Collections.Generic;

namespace GS.Recruitment.Repository.Interface
{
    public interface IDictionaryRepository<T>
    {
        string ConnectionString { get; set; }

        T Get(string name, Guid id);
        bool AddEdit(string name, T entity);
        List<T> List(string name);
        List<T> List(string name, Guid parentId);
        bool Delete(string name, T entity);
    }
}
