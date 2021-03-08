using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ViewModels
{
    public class UserItems
    {
        public String  TheName { get; set; }
        public String TheRole { get; set; }
        public List<Item> MyItems { get; set; }

       

    }
}
