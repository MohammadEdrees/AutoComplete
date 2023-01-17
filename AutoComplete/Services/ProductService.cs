using AutoMapper;
using Business.DTO;
using Infra.Entities.Products;
using Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace AutoComplete.Services
{
    public class ProductService : IProduct
    {
        public IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> SearchProducts(string text, int pNum = 0)
        {
            IQueryable<Infra.Entities.Products.Product> products = _unitOfWork.ProductRepository.SearchAsync(a => a.Description.Contains(text) || a.SKU.Contains(text), pNum);
            List<Product> ListProducts = await products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(ListProducts);
            
            //return await products.Select(s => new ProductDto
            //{
            //    Description= s.Description,
            //    Price= s.Price,
            //    SKU = s.SKU

            //}).ToListAsync();

        }
    }
}
