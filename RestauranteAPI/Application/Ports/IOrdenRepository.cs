using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Domain.Ports;

public interface IOrdenRepository
{
    Task<Orden?> ObtenerPorIdAsync(Guid id);

    Task GuardarAsync(Orden orden);

    Task<IEnumerable<Orden>> ObtenerActivasAsync();
}