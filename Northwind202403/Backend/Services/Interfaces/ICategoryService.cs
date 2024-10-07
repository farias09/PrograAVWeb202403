using Entities.Entities;

namespace Backend.Services.Interfaces
{
    public interface ICategoryService
    {
        bool Agregar(Category category);
        bool Editar (Category category);
        bool Eliminar (Category category);

        /// <summary>
        /// Obtiene Category por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Category Obtener(int id);

        /// <summary>
        /// Obtiene todas las categories
        /// </summary>
        /// <returns></returns>
        List<Category> Obtener();
    }
}
