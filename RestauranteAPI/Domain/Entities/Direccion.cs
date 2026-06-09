namespace RestauranteAPI.Domain.Entities;

public class Direccion
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public string Calle { get; set; } = null!;
    public string Numero { get; set; } = null!;
    public string Apartamento { get; set; } = null!;
    public string Ciudad { get; set; } = null!;
    public string Departamento { get; set; } = null!;
    public string CodigoPostal { get; set; } = null!;
    public string? Referencia { get; set; }
    public bool EsPrincipal { get; set; } = false;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
