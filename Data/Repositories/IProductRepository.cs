﻿using Infra.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public interface IProductRepository:IGenericRepository<Product>
    {
    }
}
