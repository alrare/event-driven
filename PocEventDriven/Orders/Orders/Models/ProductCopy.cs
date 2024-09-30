namespace Orders.Models;

/// <summary>
/// Model Order
/// </summary>
public class ProductCopy
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Relación uno a muchos
    public ICollection<Order> Orders { get; set; }
}