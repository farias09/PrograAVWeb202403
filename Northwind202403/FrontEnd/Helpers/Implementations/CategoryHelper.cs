using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using FrontEnd.ApiModels;
using System.ComponentModel;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CategoryHelper : ICategoryHelper
    {

        IServiceRepository _ServiceRepository { get; set; }

        public CategoryHelper(IServiceRepository serviceRepository)
        {
            this._ServiceRepository = serviceRepository;
        }
        public List<CategoryViewModel> GetCategories()
        {
           HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Category");
            List<Category> categories = new List<Category>();
            if (responseMessage != null) 
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;


                categories = JsonConvert.DeserializeObject<List<Category>>(content);
            }

            List<CategoryViewModel> resultado = new List<CategoryViewModel>();
            foreach (var item in categories)
            {
                resultado.Add
                    (
                    new CategoryViewModel 
                    { CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName
                    }
                    );
            }
            return resultado;
        }
    }
}
