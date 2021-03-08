using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.ViewModels
{
    public class LikedItemsModel
    {

        public int ItemId { get; set; }
        public String ItemName { get; set; }
        public int CategoryId { get; set; }
        public String Description { get; set; }
        public String UrlImg { get; set; }
        public decimal price { get; set; }
        public int likedList { get; set; }
       


    }
}
