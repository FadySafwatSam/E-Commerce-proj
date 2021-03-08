using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data.Models
{
    public class LikedList
    {
        public int LikedListId { get; set; }
        public int ItemId { get; set; }

        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public List<Item> likedItems { get; set; }


    }
}
