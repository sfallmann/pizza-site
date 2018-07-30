using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaSite.DTO;
using PizzaSite.Persistence;

namespace PizzaSite.Domain
{
    public class Item
    {
        public static ICollection<ItemDTO> GetItems()
        {
            return ItemsRepository.GetItems();
        }

    }
}
