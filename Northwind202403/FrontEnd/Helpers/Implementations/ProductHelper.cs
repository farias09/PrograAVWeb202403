using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ProductHelper : IProductHelper
    {
        IServiceRepository _ServiceRepository { get; set; }

        public ProductHelper(IServiceRepository serviceRepository)
        {
            this._ServiceRepository = serviceRepository;
        }

        #region MetodoConvertir
        Product Convertir(ProductViewModel product)
        {
            return new Product
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued,
            };
        }

        ProductViewModel Convertir(Product product)
        {
            return new ProductViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued,
            };
        }
        #endregion

        public ProductViewModel AddProduct(ProductViewModel product)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.PostResponse("api/Product", Convertir(product));
            if (responseMessage != null) 
            { 
                var content = responseMessage.Content;
            }

            return product;
        }

        public void DeleteProduct(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Product/" + id.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content;
            }
        }

        public ProductViewModel EditProduct(ProductViewModel product)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.PutResponse("api/Product", Convertir(product));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }

            return product;
        }

        public List<ProductViewModel> GetAll()
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Product");
            List<Product> products = new List<Product>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

                products = JsonConvert.DeserializeObject<List<Product>>(content);
            }
            List<ProductViewModel> resultado = new List<ProductViewModel>();
            foreach (var item in products)
            {
                resultado.Add(Convertir(item));
            }
            return resultado;
        }

        public ProductViewModel GetById(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Product");
            Product product = new Product();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

                product = JsonConvert.DeserializeObject<Product>(content);
            }
            return Convertir(product);
        }
    }
}
