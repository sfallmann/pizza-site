using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PizzaSite.DTO;
using PizzaSite.Persistence;

namespace PizzaSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings["PizzaSiteDBEntities"];

            Label1.Text = settings.ConnectionString;
            Console.WriteLine(settings);

            CustomerDTO customer = CustomersRepository.AddCustomer(new CustomerDTO
            {
                Name = "Sean Fallmann",
                Address = "1400 Margate Lane",
                ZipCode = "27284",
                Phone = "336-339-9082"
            });

            Label1.Text = String.Format("{0} {1} {2}", customer.ID, customer.Name, customer.Address);
        }
    }
}