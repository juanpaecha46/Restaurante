namespace RestauranteAPI.Domain.Entities;

public class Adicion
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public decimal Precio { get; set; }
    public bool Activo { get; set; } = true;
}
