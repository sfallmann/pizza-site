using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSite.DTO
{

    public class OrderDTO
    {
        public int ID { get; set; }
        public List<OrderItemDTO> Items { get; set; }
        public CustomerDTO Customer { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
    }
}
