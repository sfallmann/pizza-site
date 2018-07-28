using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSite.DTO;


namespace PizzaSite.Persistence
{
    public class CustomersRepository
    {
        public static CustomerDTO AddCustomer(CustomerDTO dtoCustomer)
        {
            PizzaSiteDBEntities db = new PizzaSiteDBEntities();

            CustomerDTO customer = CustomersRepository.GetCustomerByName(dtoCustomer.Name);

            if (customer == null)
            {
                Customer newCustomer = new Customer
                {
                    Name = dtoCustomer.Name.ToUpper(),
                    Address = dtoCustomer.Address.ToUpper(),
                    ZipCode = dtoCustomer.ZipCode.ToUpper(),
                    Phone = dtoCustomer.Phone.ToUpper()
                };

                db.Customers.Add(newCustomer);
                db.SaveChanges();
                customer = CustomersRepository.GetCustomerByName(newCustomer.Name);
            }

            return customer;
            
        }

        public static CustomerDTO GetCustomerByName(string name)
        {
            PizzaSiteDBEntities db = new PizzaSiteDBEntities();
            Customer dbCustomer = db.Customers.FirstOrDefault((c) => name.ToUpper() == c.Name);

            return dbCustomer == null ? null :
                new CustomerDTO
                {
                    ID = dbCustomer.ID,
                    Name = dbCustomer.Name,
                    Address = dbCustomer.Address,
                    ZipCode = dbCustomer.ZipCode,
                    Phone = dbCustomer.Phone
                };
        }
    }




}
