using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaSite.DTO;
using PizzaSite.Domain;


namespace PizzaSite
{
    
    public partial class Default : System.Web.UI.Page
    {
        
        private class ListItem
        {
            public int ID { get; set; }
            public string DisplayField { get; set; }

        }

        private IEnumerable<ListItem> ConfigureItemsDataSource(string category)
        {
            return from i in OrdersService.GetItems()
                             where i.Category == category
                             select new ListItem
                             {
                                 ID = i.ID,
                                 DisplayField = String.Format("{0} (+{1:C})", i.Name, i.Price)
                             };
        }

        private void BindItemsToControl(string category, ListControl control, bool setSelected=false)
        {
            var datasource = ConfigureItemsDataSource(category);

            control.DataSource = datasource;
            control.DataValueField = "ID";
            control.DataTextField = "DisplayField";

            if (setSelected)
                control.SelectedValue = datasource.OrderBy((i) => i.ID).First().ID.ToString();

            control.DataBind();

        }

        private CustomerDTO MapInputToCustomer()
        {
            return new CustomerDTO
            {
                Name = nameTextBox.Text.Trim(' '),
                Address = addressTextBox.Text.Trim(' '),
                Phone = phoneTextBox.Text.Trim(' '),
                ZipCode = zipCodeTextBox.Text.Trim(' ')
            };
        }

        private ItemDTO GetItemById(int id)
        {
            return OrdersService.GetItems().Single((i) => i.ID == id);
        }

        private List<OrderItemDTO> MapSelectionsToOrderItemDTO(ListControl control)
        {
            List<OrderItemDTO> selectedItems = new List<OrderItemDTO>();

            foreach(System.Web.UI.WebControls.ListItem item in control.Items)
            {
   
                int value = Convert.ToInt32(item.Value);
                ItemDTO dtoItem = GetItemById(Convert.ToInt32(value));

                if (item.Selected)
                {
                    selectedItems.Add(
                        new OrderItemDTO
                        {
                            Name = dtoItem.Name,
                            Price = dtoItem.Price,
                            Category = dtoItem.Category,
                            Quantity = 1,
                            ItemID = value
                        });
                }

            }
            return selectedItems;
        }

        private OrderDTO MapOrderToSelections()
        {
            CustomerDTO customer = MapInputToCustomer();
            List<OrderItemDTO> toppings = MapSelectionsToOrderItemDTO(toppingsCheckBoxList);
            List<OrderItemDTO> crust = MapSelectionsToOrderItemDTO(crustDropDownList);
            List<OrderItemDTO> size = MapSelectionsToOrderItemDTO(sizeDropDownList);
            var items = new List<OrderItemDTO>().Concat(toppings).Concat(crust).Concat(size);

            OrderDTO order = new OrderDTO
            {
                Customer = customer,
                Items = new List<OrderItemDTO>()
            };

            foreach (var item in items)
            {
                order.Items.Add(item);
            }

            return order;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindItemsToControl("Toppings", toppingsCheckBoxList);
                BindItemsToControl("Size", sizeDropDownList, true);
                BindItemsToControl("Crust", crustDropDownList, true);
            }

            UpdateTotal();
        }

        protected void UpdateTotal()
        {
            decimal total = OrdersService.CalculateTotal(MapOrderToSelections());
            totalLabel.Text = String.Format("{0:C}", total);
        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {
            OrdersService.ProcessOrder(MapOrderToSelections());
            Server.Transfer("Success.aspx", true);
        }
    }
}