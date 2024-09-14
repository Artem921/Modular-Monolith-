namespace Orders.Domain.Entities
{
    internal class Order
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public List<ItemOrder> ItemsOrder { get; private set; } = new List<ItemOrder>();
        public decimal TotalPrice { get; private set; }
        public int TotalAmount { get; private set; }
        public DateTime OrderDate { get; private set; }
        public Order(int id, string name, string email,string phone,DateTime orderDate)
        { 
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            OrderDate = orderDate;
        }

        public Order() { }

        public void AddItems(ItemOrder item)
        {
            ItemsOrder.Add(item);
        }
        public void Price()
        {
            TotalPrice = ItemsOrder.Select(p => p.Price).Sum();
        }

        public void AmountItems()
        {
            TotalAmount = ItemsOrder.Count();
        }
 

        public static Order Create(int id, string name, string email, string phone, DateTime orderDate)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException($"{nameof(name)} не может быть пустым");
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new NullReferenceException($"{nameof(email)} не может быть пустым");
            }

            if (string.IsNullOrEmpty(phone))
            {
                throw new NullReferenceException($"{nameof(phone)} не может быть пустым");
            }

            var order = new Order(id,name,email,phone,orderDate);

            return order;
        }

    }
}
