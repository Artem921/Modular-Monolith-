namespace Orders.Application.Orders.DTOs
{
    internal class OrderDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }
        public ICollection<ItemOrderDTO> ItemsOrder { get;  set; }
        public decimal TotalPrice { get;  set; }
        public int TotalAmount { get;  set; }
        public DateTime OrderDate { get;  set; }
    }
}
