namespace Carts.Application.Carts.DTOs
{
    public class CartDTO
    {
        public string Id { get; set; }

        public List<ItemCartDTO>? Items { get; set; }

    }
}
