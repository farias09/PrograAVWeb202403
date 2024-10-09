﻿using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ICategoryHelper
    {
        List<CategoryViewModel> GetCategories();
        CategoryViewModel GetCategory(int id);
    }
}
