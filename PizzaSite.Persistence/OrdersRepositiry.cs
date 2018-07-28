using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSite.DTO;

namespace PizzaSite.Persistence
{
    public class OrdersRepository
    { 

        public static ICollection<OrderDTO> GetOrders()
        {
            PizzaSiteDBEntities db = new PizzaSiteDBEntities();

            var dbOrders = db.Orders;
            List<OrderDTO> dtoOrders = new List<OrderDTO>();

            foreach (var dbOrder in dbOrders)
            {
                var dbCustomer = db.Customers.Single((c) => c.ID == dbOrder.CustomerID);

                CustomerDTO dtoCustomer =
                    new CustomerDTO
                    {
                        ID = dbCustomer.ID,
                        Name = dbCustomer.Name,
                        Address = dbCustomer.Address,
                        ZipCode = dbCustomer.ZipCode,
                        Phone = dbCustomer.Phone
                    };

                var dbItems =
                    from item in db.Items
                    join order_item in db.Order_Items on item.ID equals order_item.ItemID
                    where order_item.OrderID == dbOrder.ID
                    select new Order_Items { Item = item, Price = order_item.Price, Quantity = order_item.Quantity };

                List<OrderItemDTO> dtoOrderItems = new List<OrderItemDTO>();

                foreach(var item in dbItems)
                {
                    dtoOrderItems.Add(
                        new OrderItemDTO
                        {
                            ID = item.ID,
                            Name = item.Item.Name,
                            Category = item.Item.Category,
                            Price = item.Price,
                            Quantity = item.Quantity
                        });
                }

                dtoOrders.Add(
                    new OrderDTO
                    {
                        ID = dbOrder.ID,
                        Customer = dtoCustomer,
                        Items = dtoOrderItems,
                        Total = dbOrder.Total,
                        Status = dbOrder.Status
                    });
   
            }

            return dtoOrders;
        }

        public static bool AddOrder(OrderDTO dtoOrder)
        {
            bool success = true;

            try
            {
                Customer newCustomer = new Customer
                {
                    Name = dtoOrder.Customer.Name,
                    Address = dtoOrder.Customer.Address,
                    ZipCode = dtoOrder.Customer.ZipCode,
                    Phone = dtoOrder.Customer.Phone
                };


            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                success = false;
            }

            return success;
        }
    }
}
