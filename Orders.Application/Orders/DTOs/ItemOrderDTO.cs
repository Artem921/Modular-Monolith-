namespace Orders.Application.Orders.DTOs
{
    internal class ItemOrderDTO
    {
        public Guid Id { get;  set; }
        public string Category { get;  set; } 
        public string Description { get;  set; } 
        public string Name { get;  set; } 
        public decimal Price { get;  set; }
		public int Generation { get;  set; }
		public int OrderId { get;  set; }
    }
}
