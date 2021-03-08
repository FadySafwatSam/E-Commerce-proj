using E_Commerce.Data.interfaces;
using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data.Repositories
{
    public class ItemRepository : IItemRepository

     
    {


        private readonly AppDbContext _AppDbcontext;
        public ItemRepository(AppDbContext appDbContext)
        {
            _AppDbcontext = appDbContext;
        }
        public IEnumerable<Item> Items { get => _AppDbcontext.Items; set => throw new NotImplementedException(); }
        public IEnumerable<Item> pereferedItems { get => _AppDbcontext.LikedItems.SelectMany(x=> x.likedItems); set => throw new NotImplementedException(); }

        public Item GetItemById(int Id)
        {
         
           return _AppDbcontext.Items.FirstOrDefault(x=> x.ItemId == Id);


        }
    }
}
