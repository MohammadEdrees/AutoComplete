using Data.Context;
using Domain.Repositories;
using Infra.Repositories;
using Infra.UnitOfWork;

namespace Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IProductRepository _product;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IProductRepository ProductRepository => _product = _product ?? new ProductRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
           Dispose();
        }

      
    }
}
