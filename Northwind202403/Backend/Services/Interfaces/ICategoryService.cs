using Backend.DTO;

namespace Backend.Services.Interfaces
{
    public interface ICategoryService
    {
        bool Agregar(CategoryDTO category);
        bool Editar (CategoryDTO category);
        bool Eliminar (CategoryDTO category);

        /// <summary>
        /// Obtiene Category por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CategoryDTO Obtener(int id);

        /// <summary>
        /// Obtiene todas las categories
        /// </summary>
        /// <returns></returns>
        List<CategoryDTO> Obtener();
    }
}
