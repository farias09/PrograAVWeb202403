﻿using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using FrontEnd.ApiModels;
using System.ComponentModel;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CategoryHelper : ICategoryHelper
    {

        IServiceRepository _ServiceRepository { get; set; }

        Category Convertir(CategoryViewModel category)
        {
            return new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
            };
        }

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

        public CategoryViewModel GetCategory(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Category/" + id.ToString());
            Category category = new Category();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;


                category = JsonConvert.DeserializeObject<Category>(content);
            }

            CategoryViewModel resultado = new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
            return resultado;
        }

        public CategoryViewModel Add(CategoryViewModel category)
        {
            HttpResponseMessage response = _ServiceRepository.PostResponse("api/Category", Convertir(category));
            if (response.IsSuccessStatusCode) {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return category;
        }

        public CategoryViewModel Update(CategoryViewModel category)
        {
            HttpResponseMessage response = _ServiceRepository.PutResponse("api/Category", Convertir(category));
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return category;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Category/" + id.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = responseMessage.Content;
            }
        }
    }
}
