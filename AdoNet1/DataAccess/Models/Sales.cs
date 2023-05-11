using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public int BuyersId { get; set; }
        public int SellersId { get; set; }
        public double SalesAmount { get; set; }
        public DateTime SalesDate { get; set; }
    }
}