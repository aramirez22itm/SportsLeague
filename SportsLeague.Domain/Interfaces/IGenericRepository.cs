using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsLeague.Domain.Interfaces;
public interface IGenericRepository<T> where T : class
{
    // Obtener todos los registros (ej: todos los equipos)
   
    Task<IEnumerable<T>> GetAllAsync();
   
    // Obtener uno solo por su ID
    Task<T?> GetByIdAsync(int id);
   
    // Preparar un nuevo registro para guardar
    // Task AddAsync(T entity);
    Task<bool> CreateAsync(T entity);

    // Marcar un registro para actualizar
    Task<bool> UpdateAsync(T entity);

    // Marcar un registro para eliminar
    Task<bool> DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
    // Guardar los cambios físicamente en la base de datos
    //Task<bool> SaveAsync();
}