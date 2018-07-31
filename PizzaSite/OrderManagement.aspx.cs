using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaSite.Domain;
using PizzaSite.DTO;

namespace PizzaSite
{
    public partial class OrderManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OrdersGridView_OnRowCommand(object sender,
          GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CompleteOrder")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = OrdersGridView.Rows[index];

                int ID = Convert.ToInt32(row.Cells[0].Text);
                OrderDTO order = OrdersService.GetOrders().Single((o) => ID == o.ID);
                order.Status = "Complete";
                OrdersService.UpdateOrder(order);
                OrdersGridView.DataSource = null;
                OrdersGridView.DataBind();
            }

        }
    }
}