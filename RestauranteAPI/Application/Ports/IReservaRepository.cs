using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Domain.Ports;

public interface IReservaRepository
{
    Task<Reserva?> ObtenerPorIdAsync(Guid id);

    Task GuardarAsync(Reserva reserva);

    Task<IEnumerable<Reserva>> ObtenerTodasAsync();
}