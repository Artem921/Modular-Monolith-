using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Orders.Infrastructure
{
    internal class DapperContext 
    {
        private readonly string connectionString;

        public DapperContext(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BodyCarBd");
            CreateTable();
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(connectionString);

        public  void CreateTable()
        {
            var createOrders = "CREATE TABLE IF NOT EXISTS Orders(Id integer NOT NULL," +
               "  Name character varying(255) NOT NULL," +
               "Email character varying(255) NOT NULL," +
               "Phone character varying(50)  NOT NULL," +
               "Totalprice numeric NOT NULL," +
               "Totalamount integer NOT NULL," +
               "Orderdate timestamp without time zone NOT NULL," +
               "CONSTRAINT orders_pkey PRIMARY KEY (Id))";

            var createItemsOrder = "CREATE TABLE IF NOT EXISTS ItemsOrder(Id uuid NOT NULL," +
                "Category character varying(255) NOT NULL," +
                "Description character varying(255) NOT NULL," +
                "Name character varying(255)  NOT NULL," +
                "Price numeric NOT NULL," +
                "Generation integer NOT NULL," +
                "Orderid integer NOT NULL," +
                "CONSTRAINT itemsorder_orderid_fkey FOREIGN KEY (Orderid)" +
                "REFERENCES Orders (Id) ON DELETE CASCADE)";


            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    connection.Execute(createOrders);
                    connection.Execute(createItemsOrder);
                    transaction.Commit();
                }
            }
        }

    }
}
