using Products.Models;

namespace Orders.Models;

/// <summary>
/// Model Order
/// </summary>
public class Order
{
    public int Id { get; set; }
    public int IdProduct { get; set; }
    public int Quantity { get; set; }

    // Navegación hacia Producto
    public ProductCopy ProductCopy { get; set; }
}