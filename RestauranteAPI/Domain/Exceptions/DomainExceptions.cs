namespace RestauranteAPI.Domain.Exceptions;

/// <summary>
/// Excepción base para errores de lógica de dominio
/// </summary>
public class DomainException : Exception
{
    public DomainException(string message) : base(message) { }
}

/// <summary>
/// Excepción cuando se intenta reservar una fecha pasada
/// </summary>
public class ReservaFechaPasadaException : DomainException
{
    public ReservaFechaPasadaException() 
        : base("No se puede realizar una reserva para una fecha pasada.") { }
}

/// <summary>
/// Excepción cuando se intenta ocupar una mesa que ya está ocupada
/// </summary>
public class MesaOcupadaException : DomainException
{
    public MesaOcupadaException(int numeroMesa) 
        : base($"La mesa {numeroMesa} ya está ocupada.") { }
}

/// <summary>
/// Excepción cuando se intenta liberar una mesa que ya está libre
/// </summary>
public class MesaYaLibreException : DomainException
{
    public MesaYaLibreException(int numeroMesa) 
        : base($"La mesa {numeroMesa} ya está libre.") { }
}


public class PrecioInvalidoException : DomainException
{
    public PrecioInvalidoException() 
        : base("El precio del producto debe ser mayor a 0.") { }
}

public class StockNegativoException : DomainException
{
    public StockNegativoException() 
        : base("El stock no puede ser negativo.") { }
}

public class FacturaSinPedidoException : DomainException
{
    public FacturaSinPedidoException() 
        : base("No se puede emitir una factura sin un pedido asociado.") { }
}

public class FacturaSinUsuarioException : DomainException
{
    public FacturaSinUsuarioException() 
        : base("No se puede emitir una factura sin un usuario.") { }
}

public class TotalFacturaInvalidoException : DomainException
{
    public TotalFacturaInvalidoException() 
        : base("El total de la factura debe ser igual a subtotal + impuesto.") { }
}
