namespace SportsLeague.Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    // Obtener todos los registros (ej: todos los equipos)
    Task<IEnumerable<T>> GetAllAsync();

    // Obtener uno solo por su ID
    Task<T?> GetByIdAsync(int id);

    // Preparar un nuevo registro para guardar
    Task AddAsync(T entity);

    // Marcar un registro para actualizar
    void Update(T entity);

    // Marcar un registro para eliminar
    void Delete(T entity);

    // Guardar los cambios físicamente en la base de datos
    Task<bool> SaveAsync();
}