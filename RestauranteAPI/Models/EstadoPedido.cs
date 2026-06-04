namespace RestauranteAPI.Models;

public class EstadoPedido
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public int Orden { get; set; }
}
