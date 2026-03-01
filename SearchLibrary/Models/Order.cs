using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLibrary.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = "";
        public decimal TotalAmount { get; set; }
    }
}
