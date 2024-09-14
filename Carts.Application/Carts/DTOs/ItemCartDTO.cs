namespace Carts.Application.Carts.DTOs
{
    public class ItemCartDTO
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Manufacture { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Generation { get; set; }
        public string ImgPath { get; set; }
    }
}
