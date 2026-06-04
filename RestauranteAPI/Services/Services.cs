using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Data;
using RestauranteAPI.Models;

namespace RestauranteAPI.Services;

public class UsuarioService : IUsuarioService
{
    private readonly ApplicationDbContext _context;

    public UsuarioService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios.Where(u => u.Activo).ToListAsync();
    }

    public async Task<Usuario?> GetByIdAsync(int id)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id && u.Activo);
    }

    public async Task<Usuario> CreateAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> UpdateAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null) return false;

        usuario.Activo = false;
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class InventarioService : IInventarioService
{
    private readonly ApplicationDbContext _context;

    public InventarioService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Inventario>> GetAllAsync()
    {
        return await _context.Inventarios.Where(i => i.Activo).ToListAsync();
    }

    public async Task<Inventario?> GetByIdAsync(int id)
    {
        return await _context.Inventarios.FirstOrDefaultAsync(i => i.Id == id && i.Activo);
    }

    public async Task<Inventario> CreateAsync(Inventario inventario)
    {
        _context.Inventarios.Add(inventario);
        await _context.SaveChangesAsync();
        return inventario;
    }

    public async Task<Inventario> UpdateAsync(Inventario inventario)
    {
        inventario.FechaActualizacion = DateTime.UtcNow;
        _context.Inventarios.Update(inventario);
        await _context.SaveChangesAsync();
        return inventario;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var inventario = await _context.Inventarios.FindAsync(id);
        if (inventario == null) return false;

        inventario.Activo = false;
        _context.Inventarios.Update(inventario);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class ProductoService : IProductoService
{
    private readonly ApplicationDbContext _context;

    public ProductoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos.Include(p => p.Adiciones).ToListAsync();
    }

    public async Task<Producto?> GetByIdAsync(int id)
    {
        return await _context.Productos.Include(p => p.Adiciones).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Producto> CreateAsync(Producto producto)
    {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task<Producto> UpdateAsync(Producto producto)
    {
        _context.Productos.Update(producto);
        await _context.SaveChangesAsync();
        return producto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return false;

        producto.Disponible = false;
        _context.Productos.Update(producto);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class AdicionService : IAdicionService
{
    private readonly ApplicationDbContext _context;

    public AdicionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Adicion>> GetAllAsync()
    {
        return await _context.Adiciones.Where(a => a.Activo).ToListAsync();
    }

    public async Task<Adicion?> GetByIdAsync(int id)
    {
        return await _context.Adiciones.FirstOrDefaultAsync(a => a.Id == id && a.Activo);
    }

    public async Task<Adicion> CreateAsync(Adicion adicion)
    {
        _context.Adiciones.Add(adicion);
        await _context.SaveChangesAsync();
        return adicion;
    }

    public async Task<Adicion> UpdateAsync(Adicion adicion)
    {
        _context.Adiciones.Update(adicion);
        await _context.SaveChangesAsync();
        return adicion;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var adicion = await _context.Adiciones.FindAsync(id);
        if (adicion == null) return false;

        adicion.Activo = false;
        _context.Adiciones.Update(adicion);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class FacturaService : IFacturaService
{
    private readonly ApplicationDbContext _context;

    public FacturaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Factura>> GetAllAsync()
    {
        return await _context.Facturas.Include(f => f.Usuario).Include(f => f.Orden).ToListAsync();
    }

    public async Task<Factura?> GetByIdAsync(int id)
    {
        return await _context.Facturas.Include(f => f.Usuario).Include(f => f.Orden).FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Factura> CreateAsync(Factura factura)
    {
        _context.Facturas.Add(factura);
        await _context.SaveChangesAsync();
        return factura;
    }

    public async Task<Factura> UpdateAsync(Factura factura)
    {
        _context.Facturas.Update(factura);
        await _context.SaveChangesAsync();
        return factura;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var factura = await _context.Facturas.FindAsync(id);
        if (factura == null) return false;

        _context.Facturas.Remove(factura);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class MedioPagoService : IMedioPagoService
{
    private readonly ApplicationDbContext _context;

    public MedioPagoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MedioPago>> GetAllAsync()
    {
        return await _context.MediosPago.Where(m => m.Activo).ToListAsync();
    }

    public async Task<MedioPago?> GetByIdAsync(int id)
    {
        return await _context.MediosPago.FirstOrDefaultAsync(m => m.Id == id && m.Activo);
    }

    public async Task<MedioPago> CreateAsync(MedioPago medioPago)
    {
        _context.MediosPago.Add(medioPago);
        await _context.SaveChangesAsync();
        return medioPago;
    }

    public async Task<MedioPago> UpdateAsync(MedioPago medioPago)
    {
        _context.MediosPago.Update(medioPago);
        await _context.SaveChangesAsync();
        return medioPago;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var medioPago = await _context.MediosPago.FindAsync(id);
        if (medioPago == null) return false;

        medioPago.Activo = false;
        _context.MediosPago.Update(medioPago);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class ReservaService : IReservaService
{
    private readonly ApplicationDbContext _context;

    public ReservaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reserva>> GetAllAsync()
    {
        return await _context.Reservas.Include(r => r.Usuario).ToListAsync();
    }

    public async Task<Reserva?> GetByIdAsync(int id)
    {
        return await _context.Reservas.Include(r => r.Usuario).FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Reserva> CreateAsync(Reserva reserva)
    {
        _context.Reservas.Add(reserva);
        await _context.SaveChangesAsync();
        return reserva;
    }

    public async Task<Reserva> UpdateAsync(Reserva reserva)
    {
        _context.Reservas.Update(reserva);
        await _context.SaveChangesAsync();
        return reserva;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var reserva = await _context.Reservas.FindAsync(id);
        if (reserva == null) return false;

        _context.Reservas.Remove(reserva);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class OrdenService : IOrdenService
{
    private readonly ApplicationDbContext _context;

    public OrdenService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Orden>> GetAllAsync()
    {
        return await _context.Ordenes
            .Include(o => o.Usuario)
            .Include(o => o.MedioPago)
            .Include(o => o.Detalles)
            .ThenInclude(od => od.Adiciones)
            .ToListAsync();
    }

    public async Task<Orden?> GetByIdAsync(int id)
    {
        return await _context.Ordenes
            .Include(o => o.Usuario)
            .Include(o => o.MedioPago)
            .Include(o => o.Detalles)
            .ThenInclude(od => od.Adiciones)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Orden> CreateAsync(Orden orden)
    {
        _context.Ordenes.Add(orden);
        await _context.SaveChangesAsync();
        return orden;
    }

    public async Task<Orden> UpdateAsync(Orden orden)
    {
        _context.Ordenes.Update(orden);
        await _context.SaveChangesAsync();
        return orden;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var orden = await _context.Ordenes.FindAsync(id);
        if (orden == null) return false;

        _context.Ordenes.Remove(orden);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateEstadoAsync(int id, string estado)
    {
        var orden = await _context.Ordenes.FindAsync(id);
        if (orden == null) return false;

        orden.Estado = estado;
        _context.Ordenes.Update(orden);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class DireccionService : IDireccionService
{
    private readonly ApplicationDbContext _context;

    public DireccionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Direccion>> GetAllAsync()
    {
        return await _context.Direcciones.Include(d => d.Usuario).ToListAsync();
    }

    public async Task<Direccion?> GetByIdAsync(int id)
    {
        return await _context.Direcciones.Include(d => d.Usuario).FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Direccion> CreateAsync(Direccion direccion)
    {
        _context.Direcciones.Add(direccion);
        await _context.SaveChangesAsync();
        return direccion;
    }

    public async Task<Direccion> UpdateAsync(Direccion direccion)
    {
        _context.Direcciones.Update(direccion);
        await _context.SaveChangesAsync();
        return direccion;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var direccion = await _context.Direcciones.FindAsync(id);
        if (direccion == null) return false;

        _context.Direcciones.Remove(direccion);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class DomicilioService : IDomicilioService
{
    private readonly ApplicationDbContext _context;

    public DomicilioService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Domicilio>> GetAllAsync()
    {
        return await _context.Domicilios
            .Include(d => d.Orden)
            .Include(d => d.Direccion)
            .Include(d => d.Repartidor)
            .ToListAsync();
    }

    public async Task<Domicilio?> GetByIdAsync(int id)
    {
        return await _context.Domicilios
            .Include(d => d.Orden)
            .Include(d => d.Direccion)
            .Include(d => d.Repartidor)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Domicilio> CreateAsync(Domicilio domicilio)
    {
        _context.Domicilios.Add(domicilio);
        await _context.SaveChangesAsync();
        return domicilio;
    }

    public async Task<Domicilio> UpdateAsync(Domicilio domicilio)
    {
        _context.Domicilios.Update(domicilio);
        await _context.SaveChangesAsync();
        return domicilio;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var domicilio = await _context.Domicilios.FindAsync(id);
        if (domicilio == null) return false;

        _context.Domicilios.Remove(domicilio);
        await _context.SaveChangesAsync();
        return true;
    }
}

public class RecomendacionService : IRecomendacionService
{
    private readonly ApplicationDbContext _context;

    public RecomendacionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Recomendacion>> GetByClienteIdAsync(int clienteId)
    {
        return await _context.Recomendaciones
            .Where(r => r.UsuarioId == clienteId && !r.Visto)
            .Include(r => r.Producto)
            .ToListAsync();
    }

    public async Task<IEnumerable<Recomendacion>> GenerarRecomendacionesAsync()
    {
        var recomendaciones = new List<Recomendacion>();
        
        // Lógica para generar recomendaciones basadas en compras anteriores
        var usuarios = await _context.Usuarios.ToListAsync();
        
        foreach (var usuario in usuarios)
        {
            var comprasUsuario = await _context.Ordenes
                .Where(o => o.UsuarioId == usuario.Id)
                .Include(o => o.Detalles)
                .ToListAsync();

            if (comprasUsuario.Count > 0)
            {
                var productosComprados = comprasUsuario
                    .SelectMany(o => o.Detalles)
                    .Select(od => od.ProductoId)
                    .Distinct()
                    .ToList();

                var productosRecomendados = await _context.Productos
                    .Where(p => !productosComprados.Contains(p.Id) && p.Disponible)
                    .Take(3)
                    .ToListAsync();

                foreach (var producto in productosRecomendados)
                {
                    recomendaciones.Add(new Recomendacion
                    {
                        UsuarioId = usuario.Id,
                        ProductoId = producto.Id,
                        Puntuacion = 0.85m,
                        Razon = "Basado en tus compras anteriores",
                        FechaGeneracion = DateTime.UtcNow
                    });
                }
            }
        }

        if (recomendaciones.Any())
        {
            await _context.Recomendaciones.AddRangeAsync(recomendaciones);
            await _context.SaveChangesAsync();
        }

        return recomendaciones;
    }
}

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;

    public AuthService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(bool success, string token)> LoginAsync(string email, string password)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Activo);
        
        if (usuario == null || !VerificarPassword(password, usuario.PasswordHash))
        {
            return (false, string.Empty);
        }

        var token = GenerarToken(usuario);
        return (true, token);
    }

    public async Task<bool> LogoutAsync(int usuarioId)
    {
        // Implementar lógica de logout si es necesario
        return await Task.FromResult(true);
    }

    public async Task<bool> RecuperarPasswordAsync(string email)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        
        if (usuario == null)
        {
            return false;
        }

        // Implementar envío de email de recuperación
        return true;
    }

    public async Task<bool> CambiarPasswordAsync(int usuarioId, string passwordActual, string nuevaPassword)
    {
        var usuario = await _context.Usuarios.FindAsync(usuarioId);
        
        if (usuario == null || !VerificarPassword(passwordActual, usuario.PasswordHash))
        {
            return false;
        }

        usuario.PasswordHash = HashPassword(nuevaPassword);
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<Usuario?> GetPerfilAsync(int usuarioId)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarioId && u.Activo);
    }

    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    private bool VerificarPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }

    private string GenerarToken(Usuario usuario)
    {
        // Implementar generación de JWT token
        return $"token_{usuario.Id}_{DateTime.UtcNow.Ticks}";
    }
}
