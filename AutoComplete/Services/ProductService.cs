using Business.DTO;
using Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace AutoComplete.Services
{
    public class ProductService : IProduct
    {
        public IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDto>> SearchProducts(string text, int pNum = 0)
        {
            IQueryable<Infra.Entities.Products.Product> products = _unitOfWork.ProductRepository.SearchAsync(a => a.Description.Contains(text) || a.SKU.Contains(text), pNum);
            return await products.Select(s => new ProductDto
            {
                Description= s.Description,
                Price= s.Price,
                Quantity= s.Quantity,
                SKU = s.SKU

            }).ToListAsync();

        }
    }
}
