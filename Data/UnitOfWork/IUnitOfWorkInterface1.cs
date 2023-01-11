using Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository ProductRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
     
    }
}
