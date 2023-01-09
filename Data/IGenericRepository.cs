using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public interface IGenericRepository<T>where T : class
    {
        IQueryable<T> SearchAsync(Expression<Func<T, bool>> expression, int num);

    }
}
