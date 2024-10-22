using Backend.DTO;

namespace Backend.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductDTO> GetProducts();
        ProductDTO Add(ProductDTO product);
        ProductDTO Update(ProductDTO product);
        void Delete(int id);
        ProductDTO GetById(int id);
    }
}
