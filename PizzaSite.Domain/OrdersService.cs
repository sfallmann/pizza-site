using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSite.DTO;
using PizzaSite.Persistence;

namespace PizzaSite.Domain
{
    public static class OrdersService
    {
        public static decimal CalculateTotal(OrderDTO newOrder)
        {
            decimal total = 0;

            foreach (var item in newOrder.Items)
            {
                total += item.Price * item.Quantity;
            }

            return total;
        }

        public static ICollection<ItemDTO> GetItems()
        {
            return ItemsRepository.GetItems();
        }
    }
}
