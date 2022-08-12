using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        DbSet<T> GetAll();
        T Get(int id);
        void Add(T row);
        void Edit(T row);
        void Delete(int id);
    }
}
