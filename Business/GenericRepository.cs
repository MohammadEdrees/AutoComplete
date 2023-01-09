using Data.Context;
using Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }


        public IQueryable<T> SearchAsync(Expression<Func<T, bool>> expression,int num=0)
        {
            int max = 10;
            return  _entity.Where(expression).Skip(max * num).Take(max);
        }
    }
}
