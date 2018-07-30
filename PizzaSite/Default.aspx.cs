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

        private IEnumerable<ListItem> configureItemsDataSource(string category)
        {
            return from i in Item.GetItems()
                             where i.Category == category
                             select new ListItem
                             {
                                 ID = i.ID,
                                 DisplayField = String.Format("{0} (+{1:C})", i.Name, i.Price)
                             };
        }

        private void bindItemsToControl(string category, ListControl control, bool setSelected=false)
        {
            var datasource = configureItemsDataSource(category);
            control.DataSource = datasource;
            control.DataValueField = "ID";
            control.DataTextField = "DisplayField";
            if (setSelected)
                control.SelectedValue = datasource.OrderBy((i) => i.ID).First().ID.ToString();
            control.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            bindItemsToControl("Toppings", toppingsCheckBoxList, true);
            bindItemsToControl("Size", sizeDropDownList, true);
            bindItemsToControl("Crust", crustDropDownList);
        }

        protected void toppingsCheckBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}