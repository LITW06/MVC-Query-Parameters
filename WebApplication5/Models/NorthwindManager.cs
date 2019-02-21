using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebApplication5.Models
{
    public class NorthwindManager
    {
        private string _connectionString;

        public NorthwindManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Order> GetOrders()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Orders";
            connection.Open();
            List<Order> orders = new List<Order>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Order order = new Order
                {
                    Id = (int)reader["OrderId"],
                    Date = (DateTime)reader["OrderDate"],
                    ShipAddress = (string)reader["ShipAddress"],
                    ShipName = (string)reader["ShipName"]
                };

                orders.Add(order);
            }

            connection.Close();
            connection.Dispose();
            return orders;
        }


        public IEnumerable<Order> GetOrdersForEmployee(int employeeId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Orders WHERE EmployeeId = @id";
            cmd.Parameters.AddWithValue("@id", employeeId);
            connection.Open();
            List<Order> orders = new List<Order>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Order order = new Order
                {
                    Id = (int)reader["OrderId"],
                    Date = (DateTime)reader["OrderDate"],
                    ShipAddress = (string)reader["ShipAddress"],
                    ShipName = (string)reader["ShipName"]
                };

                orders.Add(order);
            }

            connection.Close();
            connection.Dispose();
            return orders;
        }

        public IEnumerable<OrderDetail> GetOrderDetailsFor1997()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select od.* from [Order Details] od
JOIN Orders o 
ON o.OrderID = od.OrderID
WHERE o.OrderDate BETWEEN '01/01/1997' AND '12/31/1997'";
            connection.Open();
            List<OrderDetail> orders = new List<OrderDetail>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                OrderDetail detail = new OrderDetail
                {
                    OrderId = (int)reader["OrderId"],
                    Quantity = (short)reader["Quantity"],
                    UnitPrice = (decimal)reader["UnitPrice"]
                };
                orders.Add(detail);
            }

            connection.Close();
            connection.Dispose();
            return orders;
        }

        public IEnumerable<Category> GetCategories()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Categories";
            connection.Open();
            List<Category> categories = new List<Category>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                categories.Add(new Category
                {
                    Id = (int)reader["CategoryId"],
                    Description = (string)reader["Description"],
                    Title = (string)reader["CategoryName"]
                });
            }

            connection.Close();
            connection.Dispose();
            return categories;
        }

        public IEnumerable<Product> GetProducts(int categoryId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM Products WHERE 
                                CategoryId = @categoryId";
            cmd.Parameters.AddWithValue("@categoryId", categoryId);
            connection.Open();
            List<Product> products = new List<Product>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = (int)reader["ProductId"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    Name = (string)reader["ProductName"],
                    QuantityPerUnit = (string)reader["QuantityPerUnit"]
                });
            }

            connection.Close();
            connection.Dispose();
            return products;
        }

        public string GetCategoryName(int categoryId)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT CategoryName FROM Categories WHERE " +
                              "CategoryId = @catId";
            cmd.Parameters.AddWithValue("@catId", categoryId);
            connection.Open();
            return (string) cmd.ExecuteScalar();
        }

        public IEnumerable<Product> SearchProducts(string searchText, int minPrice)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM Products WHERE 
                                ProductName LIKE @searchText AND UnitPrice >= @minprice";
            cmd.Parameters.AddWithValue("@searchText", $"%{searchText}%");
            cmd.Parameters.AddWithValue("@minprice", minPrice);
            connection.Open();
            List<Product> products = new List<Product>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = (int)reader["ProductId"],
                    UnitPrice = (decimal)reader["UnitPrice"],
                    Name = (string)reader["ProductName"],
                    QuantityPerUnit = (string)reader["QuantityPerUnit"]
                });
            }

            return products;
        }

    }
}