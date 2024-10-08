using Backend.DTO;
using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        IUnidadDeTrabajo Unidad;

        public CategoryService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.Unidad = unidadDeTrabajo;
        }

        #region Convertir
        Category Convertir(CategoryDTO category)
        {
            return new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        CategoryDTO Convertir(Category category)
        {
            return new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }
        #endregion

        #region CRUD
        public bool Agregar(CategoryDTO category)
        {
            try
            {
                Category entity = Convertir(category);
                Unidad.CategoryDAL.Add(entity);
                return Unidad.Complete();

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(CategoryDTO category)
        {
            try
            {
                Category entity = Convertir(category);
                Unidad.CategoryDAL.Update(entity);
                return Unidad.Complete();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(CategoryDTO category)
        {
            try
            {
                Category entity = Convertir(category);
                Unidad.CategoryDAL.Remove(entity);
                return Unidad.Complete();
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region MetodosObtener
        public CategoryDTO Obtener(int id)
        {
            try
            {
                return Convertir(Unidad.CategoryDAL.Get(id));

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CategoryDTO> Obtener()
        {
            try
            {
                List<CategoryDTO> list = new List<CategoryDTO>();
                var categories = Unidad.CategoryDAL.GetAll().ToList();

                foreach (var item in categories)
                {
                    list.Add(Convertir(item));  
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
