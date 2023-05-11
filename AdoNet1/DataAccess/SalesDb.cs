using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SalesDb
    {
        private SqlConnection connection;

        public SalesDb(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        ~SalesDb()
        {
            connection.Close();
        }

        public void AllSellers()
        {
            string cmdText = @"SELECT * FROM Sellers";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < sqlDataReader.FieldCount; i++)
            {
                Console.Write(sqlDataReader.GetName(i) + "\t");
            }
            Console.WriteLine("\n----------------------------------------");
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    Console.Write(sqlDataReader[i] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n#####################################################################");
            sqlDataReader.Close();
        }

        public void AllBuyers()
        {
            string cmdText = @"SELECT * FROM Buyers";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < sqlDataReader.FieldCount; i++)
            {
                Console.Write(sqlDataReader.GetName(i) + "\t");
            }
            Console.WriteLine("\n----------------------------------------");
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    Console.Write(sqlDataReader[i] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n#####################################################################");
            sqlDataReader.Close();
        }

        public void SalesBuyers()
        {
            string cmdText = @"SELECT S.Id, S.SellersId, S.BuyersID, S.SalesAmount, S.SalesDate
                        FROM Sales AS S JOIN Buyers AS B
                        ON B.Name = 'Julius' AND B.Surname = 'Hobbs' AND S.BuyersId = 6";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < sqlDataReader.FieldCount; i++)
            {
                Console.Write(sqlDataReader.GetName(i) + "\t");
            }
            Console.WriteLine("\n----------------------------------------");
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    Console.Write(sqlDataReader[i] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n#####################################################################");
            sqlDataReader.Close();
        }

        public void SalesSum()
        {
            string cmdText = @"SELECT * FROM Sales WHERE SalesAmount > 400";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < sqlDataReader.FieldCount; i++)
            {
                Console.Write(sqlDataReader.GetName(i) + "\t");
            }
            Console.WriteLine("\n----------------------------------------");
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    Console.Write(sqlDataReader[i] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n#####################################################################");
            sqlDataReader.Close();
        }

        public void SalesAMount()
        {
            string cmdText = @"SELECT * FROM Sales WHERE SalesAmount > 400";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < sqlDataReader.FieldCount; i++)
            {
                Console.Write(sqlDataReader.GetName(i) + "\t");
            }
            Console.WriteLine("\n----------------------------------------");
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    Console.Write(sqlDataReader[i] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n#####################################################################");
            sqlDataReader.Close();
        }

        public void RichExpensiveSale()
        {
            string cmdText = @"SELECT S.Id, S.BuyersId, S.SellersId, S.SalesAmount, S.SalesDate, B.Name + ' ' + B.Surname AS Fullname
                       FROM Sales AS S JOIN Buyers AS B ON S.BuyersId = 4 AND B.ID = S.BuyersID";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < sqlDataReader.FieldCount; i++)
            {
                Console.Write(sqlDataReader.GetName(i) + "\t");
            }
            Console.WriteLine("\n----------------------------------------");
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    Console.Write(sqlDataReader[i] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n#####################################################################");
            sqlDataReader.Close();
        }

        public void FirstSale()
        {
            string cmdText = @"SELECT S.Id, S.BuyersId, S.SellersId, S.SalesAmount, S.SalesDate, SE.Name + ' ' + SE.Surname AS Fullname
                       FROM Sales AS S JOIN Sellers AS SE ON S.Id = SE.Id AND S.SellersID = SE.Id";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < sqlDataReader.FieldCount; i++)
            {
                Console.Write(sqlDataReader.GetName(i) + "\t");
            }
            Console.WriteLine("\n----------------------------------------");
            while (sqlDataReader.Read())
            {
                for (int i = 0; i < sqlDataReader.FieldCount; i++)
                {
                    Console.Write(sqlDataReader[i] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n#####################################################################");
            sqlDataReader.Close();
        }

        public void Create(Sales sales)
        {
            string cmdText = $@"INSERT INTO Sales
                                VALUES (@Id, 
                                        @BuyersId,
                                        @SellersId,
                                        @SalesAmount,
                                        @SalesDate)";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.AddWithValue("Id", sales.Id);
            command.Parameters.AddWithValue("BuyersId", sales.BuyersId);
            command.Parameters.AddWithValue("SellersId", sales.SellersId);
            command.Parameters.AddWithValue("SalesAmount", sales.SalesAmount);
            command.Parameters.AddWithValue("SalesDate", sales.SalesDate);
            command.ExecuteNonQuery();
        }

        public List<Sales> GetAll()
        {
            string cmdText = @"SELECT * FROM Sales";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Sales> sales = new List<Sales>();
            while (reader.Read())
            {
                sales.Add(new Sales()
                {
                    Id = (int)reader[0],
                    BuyersId = (int)reader[1],
                    SellersId = (int)reader[2],
                    SalesAmount = (double)(decimal)reader[3],
                    SalesDate = (DateTime)reader[4]

                });
            }
            reader.Close();
            return sales;
        }

        public Sales LastSaleOfBuyer(string name, string surname)
        {
            string cmdText = $@"SELECT B.Id, B.Name + ' ' + B.Surname AS 'Full name', S.SalesAmount, S.SalesAmount
                                FROM Buyers AS B JOIN Sales AS S ON B.Id = S.BuyersID AND B.Name = @name AND B.Surname = @surname";
            SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
            sqlCommand.Parameters.Add("name", System.Data.SqlDbType.NVarChar).Value = name;
            sqlCommand.Parameters.Add("surname", System.Data.SqlDbType.NVarChar).Value = surname;

            SqlDataReader reader = sqlCommand.ExecuteReader();
            Sales sales = new Sales();
            while (reader.Read())
            {
                sales.Id = (int)reader[0];
                sales.BuyersId = (int)reader[1];
                sales.SellersId = (int)reader[2];
                sales.SalesAmount = (double)reader[3];
                sales.SalesDate = (DateTime)reader[4];
            }
            reader.Close();
            return sales;
        }

        public void Delete(int id)
        {
            string cmdText = $@"DELETE Buyers WHERE Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }

        public void BigSale()
        {
            string cmdText = @"SELECT B.Id, B.Name + ' ' + B.Surname AS 'Full name', SUM(S.SalesAmount)
                              FROM Buyers AS B JOIN Sales AS S ON B.Id = S.BuyersId AND S.SalesAmount > 50000
                              GROUP BY B.Id, B.Name, B.Surname";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            Sales sales = new Sales();
            while (reader.Read())
            {
                sales.Id = (int)reader[0];
                sales.BuyersId = (int)reader[1];
                sales.SellersId = (int)reader[2];
                sales.SalesAmount = (double)reader[3];
                sales.SalesDate = (DateTime)reader[4];
            }
            reader.Close();
        }
    }
}
