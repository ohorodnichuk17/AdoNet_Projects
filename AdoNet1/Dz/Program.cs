using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Text;
using System.Xml;

namespace Dz
{


    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=JULIAOHORODNICH\SQLEXPRESS;Initial Catalog=Sales;Integrated Security=True;Connect Timeout=2;";
            SalesDb db = new SalesDb(connectionString);

            Sales sales = new Sales()
            {
                Id = 14,
                BuyersId = 8,
                SellersId = 4,
                SalesAmount = 928,
                SalesDate = new DateTime(2023, 02, 10)
            };

            int num = 0;
            do
            {
                Console.WriteLine("[1] - Display information about all buyers");
                Console.WriteLine("[2] - Display information about all sellers");
                Console.WriteLine("[3] - Display information about sales made by a certain seller by name and surname");
                Console.WriteLine("[4] - Display information about sales for an amount greater than the specified amount");
                Console.WriteLine("[5] - Display the most expensive and cheapest purchase of a certain buyer by name and surname");
                Console.WriteLine("[6] - Show the first sale of a certain seller by name and surname");
                Console.WriteLine("[7] - Add new sale");
                Console.WriteLine("[8] - Display information about all sales");
                Console.WriteLine("[9] - Show the last purchase of a specific customer by first and last name");
                Console.WriteLine("[10] - Delete buyer by id");
                Console.WriteLine("[11] - Show the seller whose total sale is the largest");
                Console.WriteLine("[0] - Exit");
                num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1: db.AllSellers(); break;
                    case 2: db.AllBuyers(); break;
                    case 3: db.SalesBuyers(); break;
                    case 4: db.SalesSum(); break;
                    case 5: db.SalesAMount(); break;
                    case 6: db.FirstSale(); break;
                    case 7: db.Create(sales); break;
                    case 8:
                        {
                            var sale = db.GetAll();
                            foreach (var item in sale)
                            {
                                Console.WriteLine(item.Id);
                                Console.WriteLine(item.BuyersId);
                                Console.WriteLine(item.SellersId);
                                Console.WriteLine(item.SalesAmount);
                                Console.WriteLine(item.SalesDate);
                            }
                            break;
                        }
                    case 9: Sales s = db.LastSaleOfBuyer("TIffany", "White"); break;
                    case 10: db.Delete(3); break;
                    case 11: db.BigSale(); break;
                    case 0: Environment.Exit(0); break;
                    default:
                        Console.WriteLine("Error!!!");
                        break;
                }



            } while (num != 0);
        }
    }
}