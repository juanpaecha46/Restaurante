namespace RestauranteAPI.Models;

public class Recomendacion
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public int ProductoId { get; set; }
    public Producto? Producto { get; set; }
    public decimal Puntuacion { get; set; }
    public string Razon { get; set; } = null!;
    public DateTime FechaGeneracion { get; set; } = DateTime.UtcNow;
    public bool Visto { get; set; } = false;
}
