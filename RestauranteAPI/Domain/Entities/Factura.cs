
using RestauranteAPI.Domain.Exceptions;
namespace RestauranteAPI.Domain.Entities;

public class Factura
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public int OrdenId { get; set; }
    public Orden? Orden { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal SubTotal { get; set; }
    public decimal Impuesto { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; } = "Pendiente"; // Pendiente, Pagada, Cancelada
    public string? Observaciones { get; set; }

    public static Factura Crear(int usuarioId, int ordenId, decimal subTotal, decimal impuesto)
    {
        if (usuarioId <= 0)
            throw new FacturaSinUsuarioException();

        if (ordenId <= 0)
            throw new FacturaSinPedidoException();

        if (subTotal < 0 || impuesto < 0)
            throw new DomainException("El subtotal e impuesto no pueden ser negativos.");

        var total = subTotal + impuesto;
        
        return new Factura
        {
            UsuarioId = usuarioId,
            OrdenId = ordenId,
            SubTotal = subTotal,
            Impuesto = impuesto,
            Total = total
        };
    }

    public void Validar()
    {
        var totalCalculado = SubTotal + Impuesto;
        if (Math.Abs(Total - totalCalculado) > 0.01m) // Permitir pequeños errores de redondeo
            throw new TotalFacturaInvalidoException();

        if (OrdenId <= 0)
            throw new FacturaSinPedidoException();

        if (UsuarioId <= 0)
            throw new FacturaSinUsuarioException();
    }

    public void Pagar()
    {
        Validar();
        
        if (Estado == "Cancelada")
            throw new DomainException("No se puede pagar una factura cancelada.");

        Estado = "Pagada";
    }


    public void Cancelar()
    {
        if (Estado == "Pagada")
            throw new DomainException("No se puede cancelar una factura ya pagada.");

        Estado = "Cancelada";
    }
}
