using Newtonsoft.Json;

namespace Carts.Domain.Entities
{
    internal class ItemCart
    {

        [JsonProperty]
        public Guid Id { get; private set; }
        [JsonProperty]
        public string Category { get; private set; } = string.Empty;
        [JsonProperty]
        public string Description { get; private set; } = string.Empty;
        [JsonProperty]
        public string Manufacture { get; private set; } = string.Empty;
        [JsonProperty]
        public string Name { get; private set; } = string.Empty;
        [JsonProperty]
        public decimal Price { get; private set; } = decimal.Zero;
        [JsonProperty]
        public int Generation { get; private set; }
        public string ImgPath { get; private set; } = string.Empty;


        public ItemCart() { }
        private ItemCart(Guid id,
                         string categoy,
                         string description,
                         string manufacture,
                         string name,
                         decimal price,
                         int genertion,
                         string imgPath)
        {
            Id = id;
            Category = categoy;
            Generation = genertion;
            Description = description;
            Manufacture = manufacture;
            Name = name;
            Price = price;
            ImgPath = imgPath;
        }




        public static ItemCart Create(Guid id,
                                      string categoy,
                                      string description,
                                      string manufacture,
                                      string name,
                                      decimal price,
                                      int generation,
                                      string imgPath)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException($"{nameof(name)} не может быть пустым");

            }

            if (string.IsNullOrEmpty(categoy))
            {
                throw new NullReferenceException($"{nameof(categoy)} не может быть пустым");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new NullReferenceException($"{nameof(description)} не может быть пустым");
            }

            if (string.IsNullOrEmpty(manufacture))
            {
                throw new NullReferenceException($"{nameof(manufacture)} не может быть пустым");
            }

            var product = new ItemCart(id, categoy, description, manufacture, name, price, generation, imgPath);

            return product;
        }
    }
}
