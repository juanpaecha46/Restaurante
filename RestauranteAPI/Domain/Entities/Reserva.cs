namespace RestauranteAPI.Domain.Entities;

public class Reserva
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public int Mesa { get; set; }
    public int NumeroPersonas { get; set; }
    public DateTime FechaReserva { get; set; }
    public DateTime HoraReserva { get; set; }
    public string Estado { get; set; } = "Confirmada"; // Confirmada, Cancelada, Completada
    public string? Observaciones { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
