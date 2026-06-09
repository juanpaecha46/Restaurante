using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Inventario> Inventarios { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Adicion> Adiciones { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<MedioPago> MediosPago { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<EstadoPedido> EstadosPedido { get; set; }
    public DbSet<Orden> Ordenes { get; set; }
    public DbSet<OrdenDetalle> OrdenDetalles { get; set; }
    public DbSet<OrdenDetalleAdicion> OrdenDetalleAdiciones { get; set; }
    public DbSet<Direccion> Direcciones { get; set; }
    public DbSet<Domicilio> Domicilios { get; set; }
    public DbSet<Recomendacion> Recomendaciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar relaciones
        modelBuilder.Entity<Usuario>()
            .HasMany<Reserva>()
            .WithOne(r => r.Usuario)
            .HasForeignKey(r => r.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Usuario>()
            .HasMany<Direccion>()
            .WithOne(d => d.Usuario)
            .HasForeignKey(d => d.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Orden>()
            .HasMany(o => o.Detalles)
            .WithOne(od => od.Orden)
            .HasForeignKey(od => od.OrdenId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrdenDetalle>()
            .HasMany(od => od.Adiciones)
            .WithOne(oda => oda.OrdenDetalle)
            .HasForeignKey(oda => oda.OrdenDetalleId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Producto>()
            .HasMany(p => p.Adiciones)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
