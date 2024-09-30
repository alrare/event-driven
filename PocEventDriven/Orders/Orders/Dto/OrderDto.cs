namespace Orders.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
    }
}
