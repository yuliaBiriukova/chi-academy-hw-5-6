using HW_5.Models;
using Microsoft.Data.SqlClient;
using System.Data;


namespace HW_5.Database
{
    internal class DbHandler : IDbHandler
    {
        private string connectionString = DbConnection.ConnectionString;

        public DbHandler() { }

        public async Task<List<Order>> GetOrdersWithReaderAsync()
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            string selectAllQuery = "SELECT ord_id, ord_datetime, an_id, an_name, an_cost, an_price, gr_id, gr_name, gr_temp " +
                "FROM Orders " +
                "JOIN Analysis ON ord_an = an_id " +
                "JOIN Groups ON an_group = gr_id";

            await connection.OpenAsync();

            using SqlCommand command = new SqlCommand(selectAllQuery, connection);

            SqlDataReader reader = await command.ExecuteReaderAsync();

            List<Order> orders = new List<Order>();

            while (await reader.ReadAsync())
            {
                Order order = new Order()
                {
                    ord_id = reader.GetInt32(0),
                    ord_datetime = reader.GetDateTime(1),
                    ord_an = new Analysis()
                    {
                        an_id = reader.GetInt32(2),
                        an_name = reader.GetString(3),
                        an_cost = reader.GetInt32(4),
                        an_price = reader.GetInt32(5),
                        an_group = new Group()
                        {
                            gr_id = reader.GetInt32(6),
                            gr_name = reader.GetString(7),
                            gr_temp = reader.GetInt32(8)
                        }
                    }
                };
                orders.Add(order);
            }

            return orders;
        }

        public async Task<List<Order>> GetOrdersWithDataSetAsync()
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            string selectAllQuery = "SELECT ord_id, ord_datetime, an_id, an_name, an_cost, an_price, gr_id, gr_name, gr_temp " +
                "FROM Orders " +
                "JOIN Analysis ON ord_an = an_id " +
                "JOIN Groups ON an_group = gr_id";

            await connection.OpenAsync();

            SqlDataAdapter adapter = new SqlDataAdapter(selectAllQuery, connection);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            List<Order> orders = new List<Order>();

            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Order order = new Order()
                    {
                        ord_id = (int)row[0],
                        ord_datetime = (DateTime)row[1],
                        ord_an = new Analysis()
                        {
                            an_id = (int)row[2],
                            an_name = (string)row[3],
                            an_cost = (int)row[4],
                            an_price = (int)row[5],
                            an_group = new Group()
                            {
                                gr_id = (int)row[6],
                                gr_name = (string)row[7],
                                gr_temp = (int)row[8]
                            }
                        }
                    };
                    orders.Add(order);
                }
            }
            return orders;
        }

        // get all orders for the last year
        // use SqlCommand and SqlDataReader
        public async Task<List<Order>> GetOrdersByYearWithReaderAsync()
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            string selectByLastYearQuery = "SELECT ord_id, ord_datetime, an_id, an_name, an_cost, an_price, gr_id, gr_name, gr_temp " +
                "FROM Orders " +
                "JOIN Analysis ON ord_an = an_id " +
                "JOIN Groups ON an_group = gr_id " +
                "WHERE ord_datetime >= DATEADD(YEAR, -1, GETDATE())";

            await connection.OpenAsync();

            using SqlCommand command = new SqlCommand(selectByLastYearQuery, connection);

            SqlDataReader reader = await command.ExecuteReaderAsync();

            List<Order> orders = new List<Order>();

            while (await reader.ReadAsync())
            {
                Order order = new Order()
                {
                    ord_id = reader.GetInt32(0),
                    ord_datetime = reader.GetDateTime(1),
                    ord_an = new Analysis()
                    {
                        an_id = reader.GetInt32(2),
                        an_name = reader.GetString(3),
                        an_cost = reader.GetInt32(4),
                        an_price = reader.GetInt32(5),
                        an_group = new Group()
                        {
                            gr_id = reader.GetInt32(6),
                            gr_name = reader.GetString(7),
                            gr_temp = reader.GetInt32(8)
                        }
                    }
                };
                orders.Add(order);
            }
            return orders;
        }


        // get all orders for the last year
        // use SqlDataAdapter and DataSet
        public async Task<List<Order>> GetOrdersByYearWithDataSetAsync()
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            string selectByLastYearQuery = "SELECT ord_id, ord_datetime, an_id, an_name, an_cost, an_price, gr_id, gr_name, gr_temp " +
                "FROM Orders " +
                "JOIN Analysis ON ord_an = an_id " +
                "JOIN Groups ON an_group = gr_id " +
                "WHERE ord_datetime >= DATEADD(YEAR, -1, GETDATE())";

            await connection.OpenAsync();

            SqlDataAdapter adapter = new SqlDataAdapter(selectByLastYearQuery, connection);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            List<Order> orders = new List<Order>();

            foreach (DataTable dt in ds.Tables)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Order order = new Order()
                    {
                        ord_id = (int)row[0],
                        ord_datetime = (DateTime)row[1],
                        ord_an = new Analysis()
                        {
                            an_id = (int)row[2],
                            an_name = (string)row[3],
                            an_cost = (int)row[4],
                            an_price = (int)row[5],
                            an_group = new Group()
                            {
                                gr_id = (int)row[6],
                                gr_name = (string)row[7],
                                gr_temp = (int)row[8]
                            }
                        }
                    };
                    orders.Add(order);
                }
            }
            return orders;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            string selectByIdQuery = "SELECT ord_id, ord_datetime, an_id, an_name, an_cost, an_price, gr_id, gr_name, gr_temp " +
                "FROM Orders " +
                "JOIN Analysis ON ord_an = an_id " +
                "JOIN Groups ON an_group = gr_id " +
                "WHERE ord_id = @id";

            await connection.OpenAsync();

            using SqlCommand command = new SqlCommand(selectByIdQuery, connection);
            command.Parameters.Add(new SqlParameter("@id", id));

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (!await reader.ReadAsync()) return null;

            Order order = new Order()
            {
                ord_id = reader.GetInt32(0),
                ord_datetime = reader.GetDateTime(1),
                ord_an = new Analysis()
                {
                    an_id = reader.GetInt32(2),
                    an_name = reader.GetString(3),
                    an_cost = reader.GetInt32(4),
                    an_price = reader.GetInt32(5),
                    an_group = new Group()
                    {
                        gr_id = reader.GetInt32(6),
                        gr_name = reader.GetString(7),
                        gr_temp = reader.GetInt32(8)
                    }
                }
            };
            return order;
        }

        // add new record to Orders
        public async Task<int> AddOrderAsync(Order newOrder)
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            string insertQuery = "INSERT INTO dbo.Orders (ord_datetime, ord_an) VALUES (@new_datetime, @new_ord_an); " +
                "SELECT SCOPE_IDENTITY();";

            using SqlCommand command = new SqlCommand(insertQuery, connection);
            command.Parameters.Add(new SqlParameter("@new_datetime", newOrder.ord_datetime));
            command.Parameters.Add(new SqlParameter("@new_ord_an", newOrder.ord_an.an_id));

            await connection.OpenAsync();

            var result = await command.ExecuteScalarAsync();
            return (int)(decimal)result;
        }

        // update record in Orders
        public async Task<int> UpdateOrderAsync(Order newOrder)
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            string updateQuery = "UPDATE dbo.Orders SET ord_datetime = @new_datetime, ord_an = @new_ord_an WHERE ord_id = @id";

            using SqlCommand command = new SqlCommand(updateQuery, connection);
            command.Parameters.Add(new SqlParameter("@new_datetime", newOrder.ord_datetime));
            command.Parameters.Add(new SqlParameter("@new_ord_an", newOrder.ord_an.an_id));
            command.Parameters.Add(new SqlParameter("@id", newOrder.ord_id));

            await connection.OpenAsync();

            var count = await command.ExecuteNonQueryAsync();
            return count;
        }

        // delete record from Orders
        public async Task<int> DeleteOrderAsync(int orderId)
        {
            using SqlConnection connection = new SqlConnection(connectionString);

            string deleteQuery = "DELETE FROM dbo.Orders WHERE ord_id = @id";

            using SqlCommand command = new SqlCommand(deleteQuery, connection);
            command.Parameters.Add(new SqlParameter("@id", orderId));

            await connection.OpenAsync();

            var count = await command.ExecuteNonQueryAsync();
            return count;
        }
    }
}
