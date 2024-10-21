using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class SupplierHelper : ISupplierHelper
    {
        IServiceRepository _ServiceRepository { get; set; }

        #region Constructor
        public SupplierHelper(IServiceRepository serviceRepository)
        {
            this._ServiceRepository = serviceRepository;
        }

        #endregion

        #region MetodoConvertir
        Supplier Convertir(SupplierViewModel supplier)
        {
            return new Supplier
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName
            };
        }
        #endregion

        #region CRUD

        public SupplierViewModel Add(SupplierViewModel supplier)
        {
            HttpResponseMessage response = _ServiceRepository.PostResponse("api/Supplier", Convertir(supplier));
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                throw new Exception("Error al crear el proveedor: " + response.ReasonPhrase);
            }
            return supplier;
        }

        public SupplierViewModel Update(SupplierViewModel supplier)
        {
            HttpResponseMessage response = _ServiceRepository.PutResponse("api/Supplier", Convertir(supplier));
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return supplier;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Supplier/" + id.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content;
            }
        }
        #endregion

        #region MetodosObtener

        public SupplierViewModel GetSupplier(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Supplier/" + id.ToString());
            Supplier supplier = new Supplier();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

                supplier = JsonConvert.DeserializeObject<Supplier>(content);
            }
            SupplierViewModel resultado = new SupplierViewModel
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName,
            };
            return resultado;
        }

        public List<SupplierViewModel> GetSuppliers()
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Supplier");
            List<Supplier> suppliers = new List<Supplier>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

                suppliers = JsonConvert.DeserializeObject<List<Supplier>>(content);
            }
            List<SupplierViewModel> resultado = new List<SupplierViewModel>();
            foreach (var item in suppliers)
            {
                resultado.Add
                    (
                    new SupplierViewModel
                    {
                        SupplierId = item.SupplierId,
                        CompanyName = item.CompanyName,
                    }
                    );
            }
            return resultado;
        }
        #endregion
    }
}
