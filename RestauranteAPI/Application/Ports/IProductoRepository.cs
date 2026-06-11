using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Domain.Ports;

public interface IProductoRepository
{
    Task<Producto?> ObtenerPorIdAsync(Guid id);

    Task<IEnumerable<Producto>> ObtenerTodosAsync();

    Task GuardarAsync(Producto producto);

    Task EliminarAsync(Guid id);
}