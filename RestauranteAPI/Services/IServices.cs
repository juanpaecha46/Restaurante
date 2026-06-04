using RestauranteAPI.Models;

namespace RestauranteAPI.Services;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario?> GetByIdAsync(int id);
    Task<Usuario> CreateAsync(Usuario usuario);
    Task<Usuario> UpdateAsync(Usuario usuario);
    Task<bool> DeleteAsync(int id);
}

public interface IInventarioService
{
    Task<IEnumerable<Inventario>> GetAllAsync();
    Task<Inventario?> GetByIdAsync(int id);
    Task<Inventario> CreateAsync(Inventario inventario);
    Task<Inventario> UpdateAsync(Inventario inventario);
    Task<bool> DeleteAsync(int id);
}

public interface IProductoService
{
    Task<IEnumerable<Producto>> GetAllAsync();
    Task<Producto?> GetByIdAsync(int id);
    Task<Producto> CreateAsync(Producto producto);
    Task<Producto> UpdateAsync(Producto producto);
    Task<bool> DeleteAsync(int id);
}

public interface IAdicionService
{
    Task<IEnumerable<Adicion>> GetAllAsync();
    Task<Adicion?> GetByIdAsync(int id);
    Task<Adicion> CreateAsync(Adicion adicion);
    Task<Adicion> UpdateAsync(Adicion adicion);
    Task<bool> DeleteAsync(int id);
}

public interface IFacturaService
{
    Task<IEnumerable<Factura>> GetAllAsync();
    Task<Factura?> GetByIdAsync(int id);
    Task<Factura> CreateAsync(Factura factura);
    Task<Factura> UpdateAsync(Factura factura);
    Task<bool> DeleteAsync(int id);
}

public interface IMedioPagoService
{
    Task<IEnumerable<MedioPago>> GetAllAsync();
    Task<MedioPago?> GetByIdAsync(int id);
    Task<MedioPago> CreateAsync(MedioPago medioPago);
    Task<MedioPago> UpdateAsync(MedioPago medioPago);
    Task<bool> DeleteAsync(int id);
}

public interface IReservaService
{
    Task<IEnumerable<Reserva>> GetAllAsync();
    Task<Reserva?> GetByIdAsync(int id);
    Task<Reserva> CreateAsync(Reserva reserva);
    Task<Reserva> UpdateAsync(Reserva reserva);
    Task<bool> DeleteAsync(int id);
}

public interface IOrdenService
{
    Task<IEnumerable<Orden>> GetAllAsync();
    Task<Orden?> GetByIdAsync(int id);
    Task<Orden> CreateAsync(Orden orden);
    Task<Orden> UpdateAsync(Orden orden);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateEstadoAsync(int id, string estado);
}

public interface IDireccionService
{
    Task<IEnumerable<Direccion>> GetAllAsync();
    Task<Direccion?> GetByIdAsync(int id);
    Task<Direccion> CreateAsync(Direccion direccion);
    Task<Direccion> UpdateAsync(Direccion direccion);
    Task<bool> DeleteAsync(int id);
}

public interface IDomicilioService
{
    Task<IEnumerable<Domicilio>> GetAllAsync();
    Task<Domicilio?> GetByIdAsync(int id);
    Task<Domicilio> CreateAsync(Domicilio domicilio);
    Task<Domicilio> UpdateAsync(Domicilio domicilio);
    Task<bool> DeleteAsync(int id);
}

public interface IRecomendacionService
{
    Task<IEnumerable<Recomendacion>> GetByClienteIdAsync(int clienteId);
    Task<IEnumerable<Recomendacion>> GenerarRecomendacionesAsync();
}

public interface IAuthService
{
    Task<(bool success, string token)> LoginAsync(string email, string password);
    Task<bool> LogoutAsync(int usuarioId);
    Task<bool> RecuperarPasswordAsync(string email);
    Task<bool> CambiarPasswordAsync(int usuarioId, string passwordActual, string nuevaPassword);
    Task<Usuario?> GetPerfilAsync(int usuarioId);
}
