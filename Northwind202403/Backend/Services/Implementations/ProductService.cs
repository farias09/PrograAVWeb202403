using Backend.DTO;
using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class ProductService : IProductService
    {
        IUnidadDeTrabajo _Unidad;

        public ProductService(IUnidadDeTrabajo unidad)
        {
            this._Unidad = unidad;
        }

        Product Convertir(ProductDTO product)
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

        ProductDTO Convertir(Product product)
        {
            return new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                Discontinued = product.Discontinued,
            };
        }

        public ProductDTO Add(ProductDTO product)
        {
            try
            {
                _Unidad.ProductDAL.Add(Convertir(product));
                return product;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            Product product = new Product {ProductId= id};
            _Unidad.ProductDAL.Remove(product);
            _Unidad.Complete();
        }

        public ProductDTO GetById(int id)
        {
            var product = _Unidad.ProductDAL.Get(id);
            return Convertir(product);
        }

        public List<ProductDTO> GetProducts()
        {
            var products = _Unidad.ProductDAL.GetAll();
            List<ProductDTO> productsList = new List<ProductDTO>();

            foreach (var product in products)
            {
                productsList.Add(Convertir(product));
            }
            return productsList;
        }

        public ProductDTO Update(ProductDTO product)
        {
            try
            {
                _Unidad.ProductDAL.Update(Convertir(product));
                return product;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
