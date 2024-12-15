using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D8M7Q2_SportEvents.Data
{
    public class Repository<T> where T : class
    {
        SportEventContext ctx;

        public Repository(SportEventContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public T FindById(string id)
        {
            return null;
            //return ctx.Set<T>().First(t => t. == id);
        }
    }
}
