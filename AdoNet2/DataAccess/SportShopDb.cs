using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SportShopDb
    {
        // CRUD
        // [C]reate
        // [R]ead
        // [U]pdate
        // [D]elete

        private SqlConnection connection;

        public SportShopDb(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        ~SportShopDb()
        {
            connection.Close();
        }

        public void Create(Product product)
        {
            string cmdText = $@"INSERT INTO Products
                              VALUES (@Name, 
                                      @Type, 
                                      @Quantity, 
                                      @CostPrice, 
                                      @Producer,
                                      @Price)";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("Name", product.Name);
            command.Parameters.AddWithValue("Type", product.Type);
            command.Parameters.AddWithValue("Quantity", product.Quantity);
            command.Parameters.AddWithValue("Producer", product.Producer);
            command.Parameters.AddWithValue("Price", product.Price);
            command.ExecuteNonQuery();
        }

        public List<Product> GetAll()
        {
            string cmdText = @"select * from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = (int)reader[4],
                    Producer = (string)reader[5],
                    Price = (int)reader[6]
                });
            }
            reader.Close();
            return products;
        }

        public void Update(Product product)
        {
            string cmdText = $@"UPDATE Products
                              SET Name = @Name, 
                                  TypeProduct = @Type, 
                                  Quantity = @Quantity, 
                                  CostPrice = @CostPrice, 
                                  Producer = @Producer,
                                  Price =  @Price
                                    WHERE Id = {product.Id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("Name", product.Name);
            command.Parameters.AddWithValue("Type", product.Type);
            command.Parameters.AddWithValue("Quantity", product.Quantity);
            command.Parameters.AddWithValue("Producer", product.Producer);
            command.Parameters.AddWithValue("Price", product.Price);
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            string cmdText = $@"delete  Products WHERE Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }

        public Product GetOneById(int id)
        {
            string cmdText = $@"select * from Products where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            Product product = new Product();
            while (reader.Read())
            {

                product.Id = (int)reader[0];
                product.Name = (string)reader[1];
                product.Type = (string)reader[2];
                product.Quantity = (int)reader[3];
                product.CostPrice = (int)reader[4];
                product.Producer = (string)reader[5];+

                product.Price = (int)reader[6];

            }
            reader.Close();
            return product;
        }

        public List<Product> GetByName(string name)
        {
            string cmdText = $@"select * from Products where Name = @name";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = name;

            //SqlParameter param1 = new SqlParameter()
            //{
            //    ParameterName = "name",
            //    SqlDbType = System.Data.SqlDbType.NVarChar,
            //    Value = name
            //};
            //command.Parameters.Add(param1);

            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = (int)reader[4],
                    Producer = (string)reader[5],
                    Price = (int)reader[6]
                });
            }
            reader.Close();
            return products;
        }
    }
}