using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PizzaSite.DTO;

namespace PizzaSite.Persistence
{
    public class OrdersRepository : Repository
    {

        public static IEnumerable<OrderDTO> GetOrders()
        {

            var dbOrders = db.Orders.Include("Order_Items");
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

                


                List<OrderItemDTO> dtoOrderItems = new List<OrderItemDTO>();

                foreach(var order_item in dbOrder.Order_Items)
                {
                    dtoOrderItems.Add(new OrderItemDTO
                    {
                        ID = order_item.ID,
                        Name = order_item.Item.Name,
                        Category = order_item.Item.Category,
                        Price = order_item.Price,
                        Quantity = order_item.Quantity
                    });
                }

                dtoOrders.Add(new OrderDTO
                {
                    ID = dbOrder.ID,
                    Customer = dtoCustomer,
                    Items = dtoOrderItems,
                    Status = dbOrder.Status
                });
   
            }

            return dtoOrders;
        }

        public static void AddOrder(OrderDTO dtoOrder)
        {

            CustomerDTO dtoCustomer = CustomersRepository.AddCustomer(dtoOrder.Customer);

            Order newOrder = new Order
            {
                Status = "InProgress",
                CustomerID = dtoCustomer.ID
            };

            
            foreach (var dtoItem in dtoOrder.Items)
            {
                Item item = new Item
                {
                    ID = dtoItem.ID
                };

                Order_Items orderItem = new Order_Items
                {
                    Order = newOrder,
                    ItemID = item.ID
                };

                db.Order_Items.Add(orderItem);
            }

            db.SaveChanges();
           
        }

        public static void UpdateOrder(OrderDTO updatedOrder)
        {
            Order order = db.Orders.Single((o) => o.ID == updatedOrder.ID);
            order.Status = updatedOrder.Status;
            db.SaveChanges();
        }
    }
}
