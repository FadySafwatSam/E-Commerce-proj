using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data.interfaces
{
    public interface IItemRepository
    {
           IEnumerable<Item> Items { get; set; }

           IEnumerable<Item>  pereferedItems { get; set; }
          Item GetItemById(int Id);


    }
}
