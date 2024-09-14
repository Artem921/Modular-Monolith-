namespace Product.Domain.Entities
{
    internal class ProductEntity
    {
        public Guid Id { get; private set; }
        public string Category { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Manufacture { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public int Generation {  get; private set; }
        public decimal Price { get; private set; } = decimal.Zero;
        public List<string>? ImgPath { get; set; } = new List<string>();

        private ProductEntity(Guid id, 
                             string categoy, 
                             string description, 
                             string manufacture, 
                             string name, 
                             decimal price, 
                             int generation,
                             List<string>? imgPath)
        {
            Id = id;
            Category = categoy;
            Description = description;
            Manufacture = manufacture;
            Name = name;
            Price = price;
            ImgPath = imgPath;
            Generation = generation;
        }

        public static ProductEntity Create(Guid id,
                                           string categoy, 
                                           string description,
                                           string manufacture, 
                                           string name,
                                           decimal price,
                                           int generation,
                                           List<string>? imgPath)
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


            var product = new ProductEntity(id,categoy, description, manufacture, name, price,generation, imgPath);

            return product;
        }
    }
}
