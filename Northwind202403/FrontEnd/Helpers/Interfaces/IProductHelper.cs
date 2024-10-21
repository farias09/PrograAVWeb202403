using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IProductHelper
    {
        List<ProductViewModel> GetAll();
        ProductViewModel GetById(int id);
        ProductViewModel AddProduct(ProductViewModel product);
        ProductViewModel EditProduct(ProductViewModel product);
        void DeleteProduct(int id);
    }
}
