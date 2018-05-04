using EfficiencyMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EfficiencyMVC.Repositories
{
    public abstract class AbstractRepository<T> where T : class
    {

        //Create
        public virtual void Create(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        //Update

        public virtual void Update(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        //Delete
        public virtual void Delete(T entity)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        //Find itp. Lambda w argumencie. Może dzięki znaleźć cokolwiek dzieki expression jakie mu podamy
        public virtual List<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Set<T>().Where(expression);
                return query.ToList();
            }
        }
    }
}