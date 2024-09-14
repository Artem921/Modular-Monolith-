namespace Orders.Domain.Entities
{
    internal class ItemOrder
    {
        public Guid Id { get; private set; }
        public string Category { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; } = decimal.Zero;
		public int Generation { get; private set; }
		public int OrderId { get; private set; }


        public ItemOrder(Guid id,
                         string category,
                         string description,
                         string name,
                         decimal price, 
                         int generation,
                         int orderId)
        {
            Id = id;
            Category = category;
            Description = description;
            Name = name;
            Price = price;
            Generation = generation;
            OrderId = orderId;
        }

        public static ItemOrder Create(Guid id,
                                       string category,
                                       string description,
                                       string name,
                                       decimal price, 
                                       int generation,
                                       int orderId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException($"{nameof(name)} не может быть пустым");
            }

            if (string.IsNullOrEmpty(category))
            {
                throw new NullReferenceException($"{nameof(category)} не может быть пустым");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new NullReferenceException($"{nameof(description)} не может быть пустым");
            }

            if ( orderId == 0)
            {
                throw new NullReferenceException($"{nameof(orderId)} не может быть пустым");
            }

            var itemOrder = new ItemOrder(id,category, description,name, price, generation, orderId);

            return itemOrder;
        }
    }
}
