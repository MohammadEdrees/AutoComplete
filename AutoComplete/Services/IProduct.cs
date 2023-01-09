using Business.DTO;

namespace AutoComplete.Services
{
    public interface IProduct
    {
        public Task<IEnumerable<ProductDto>> SearchProducts(string text, int pNum);
    }
}
