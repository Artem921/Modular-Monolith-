using Newtonsoft.Json;

namespace Carts.Domain.Entities
{
    internal class Cart
    {
        [JsonProperty]
        public string Id { get; private set; }

        [JsonProperty]
        public ICollection<ItemCart> Items { get; set; }

        public Cart(string id)
        {
            Id = id;
            Items = new List<ItemCart>();
        }

        public void AddItemToCart(ItemCart itemCart)
        {
            Items.Add(itemCart);
        }

        public int RemovingItemFromCart(Guid id)
        {
            var item = Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                throw new NullReferenceException($"Такого предмета нет в корзине,{nameof(Cart)}");
            }

            if (item != null)
            {
                Items.Remove(item);
            }

            return Items.Count;
        }
    }
}
