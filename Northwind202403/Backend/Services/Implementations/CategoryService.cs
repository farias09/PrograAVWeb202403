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
        public bool Agregar(Category category)
        {
            try
            {
                Unidad.CategoryDAL.Add(category);
                return Unidad.Complete();

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(Category category)
        {
            try
            {
                Unidad.CategoryDAL.Update(category);
                return Unidad.Complete();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(Category category)
        {
            try
            {
                Unidad.CategoryDAL.Remove(category);
                return Unidad.Complete();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Category Obtener(int id)
        {
            try
            {
                return Unidad.CategoryDAL.Get(id);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Category> Obtener()
        {
            try
            {
                return Unidad.CategoryDAL.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
