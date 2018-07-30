using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSite.DTO;

namespace PizzaSite.Persistence
{
    public class ItemsRepository : Repository
    {
        public static ICollection<ItemDTO> GetItems()
        {
            List<ItemDTO> items = new List<ItemDTO>();

            foreach(var dbItem in db.Items)
            {
                items.Add(new ItemDTO
                {
                    ID = dbItem.ID,
                    Name = dbItem.Name,
                    Category = dbItem.Category,
                    Price = dbItem.Price
                });
            }

            return items;
        }
    }
}
