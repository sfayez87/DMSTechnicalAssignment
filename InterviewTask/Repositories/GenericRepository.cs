using InterviewTask.Models;
using InterviewTask.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InterviewTask.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        private readonly ApplicationDbContext context;
        public GenericRepository()
        {
            context = new ApplicationDbContext();
        }
        public void Add(T row)
        {
            context.Entry<T>(row).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var row= context.Set<T>().Find(id);
            context.Entry<T>(row).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Edit(T row)
        {
            context.Entry<T>(row).State = EntityState.Modified;
            context.SaveChanges();
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public DbSet<T> GetAll()
        {
            return context.Set<T>();
        }



        //DbSet IGenericRepository<T>.GetAll()
        //{
        //    return context.Set<T>();
        //}
    }
}