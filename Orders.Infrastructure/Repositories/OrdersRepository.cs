using Dapper;
using Orders.Domain.Abstraction;
using Orders.Domain.Entities;
using System.Data;
namespace Orders.Infrastructure.Repositories
{
    internal class OrdersRepository : IOrdersRepository
    {
        private readonly DapperContext dapperContext;

        public OrdersRepository(DapperContext dapperContext)
        {
            this.dapperContext = dapperContext;
        }

        public async Task AddAsync(Order order,ICollection<ItemOrder> items)
        {
            var insertOrder = "INSERT INTO Orders (Id,Name,Email,Phone,TotalAmount,TotalPrice,OrderDate)" +
                "VALUES(@Id,@Name,@Email,@Phone,@TotalAmount,@TotalPrice,@OrderDate)";

            var insertItemOrder = "INSERT INTO ItemsOrder (Id,Category,Description,Name,Price,Generation,OrderId)" +
				"VALUES(@Id,@Category,@Description,@Name,@Price,@Generation,@OrderId)";


            var parametersOrder = new DynamicParameters();
            parametersOrder.Add("Id", order.Id, DbType.Int32);
            parametersOrder.Add("Name",order.Name,DbType.String);
            parametersOrder.Add("Email", order.Email, DbType.String);
            parametersOrder.Add("Phone", order.Phone, DbType.String);
            parametersOrder.Add("TotalAmount", order.TotalAmount, DbType.Int32);
            parametersOrder.Add("TotalPrice", order.TotalPrice, DbType.Decimal);
            parametersOrder.Add("OrderDate", order.OrderDate, DbType.DateTime);

            var parametersItemOrder = new DynamicParameters();
            foreach(var item in items)
            {
                parametersItemOrder.Add("Id", item.Id, DbType.Guid);
                parametersItemOrder.Add("Category", item.Category, DbType.String);
                parametersItemOrder.Add("Description", item.Description, DbType.String);
                parametersItemOrder.Add("Name", item.Name, DbType.String);
                parametersItemOrder.Add("Price", item.Price, DbType.Decimal);
                parametersItemOrder.Add("Generation", item .Generation, DbType.Int32);
                parametersItemOrder.Add("OrderId", item.OrderId, DbType.Int32);

            }      
            using (var connection = dapperContext.CreateConnection())
            {
                connection.Open();
                using(var transaction = connection.BeginTransaction())
                { 
                    await connection.ExecuteAsync(insertOrder, parametersOrder);
                    foreach (var item in items)
                    {
                        parametersItemOrder.Add("Id", item.Id, DbType.Guid);
                        parametersItemOrder.Add("Category", item.Category, DbType.String);
                        parametersItemOrder.Add("Description", item.Description, DbType.String);
                        parametersItemOrder.Add("Name", item.Name, DbType.String);
                        parametersItemOrder.Add("Price", item.Price, DbType.Decimal);
                        parametersItemOrder.Add("Generation", item.Generation, DbType.Int32);
                        parametersItemOrder.Add("OrderId", item.OrderId, DbType.Int32);
                        await connection.ExecuteAsync(insertItemOrder, parametersItemOrder);
                    }
             

                    transaction.Commit();
                }             
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM Orders WHERE Id = @Id";
            using (var connection = dapperContext.CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var result = await connection.ExecuteAsync(query, new { id });

                    transaction.Commit();

                    return result;
                }
     
            }
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var query = "SELECT * FROM Orders"
                +" INNER JOIN ItemsOrder ON Orders.Id = ItemsOrder.OrderId";

            using(var connection = dapperContext.CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var orders = await connection.QueryAsync<Order,ItemOrder,Order>(query,
                    (order, item) =>
                    {
                        order.AddItems(item);
                        return order;
                    });

                    transaction.Commit();
                    return orders.ToList();

                }     
            }
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Orders" 
                 +" INNER JOIN ItemsOrder ON Orders.Id = ItemsOrder.OrderId"
                 + " WHERE Orders.Id = @Id";

            using (var connection = dapperContext.CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                { 
                    var orders = await connection.QueryAsync<Order, ItemOrder, Order>(query, 
                    (order, item) =>
                    {
                        order.AddItems(item);
                        return order;
                    }, new { id });

                    transaction.Commit();
                    return  orders.FirstOrDefault(ord => ord.Id == id);

                }
               
            }
        }
    }
}
