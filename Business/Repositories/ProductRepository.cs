using Data.Context;
using Infra;
using Infra.Entities.Products;
using Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
 
        public ProductRepository(ApplicationDbContext context):base(context)
        {
        }

         
    }
}
