using E_Commerce.Data.interfaces;
using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data.Repositories
{
    public class BuyListRepository : IBuyListReository
    {

        private readonly AppDbContext _AppDbcontext;
        public BuyListRepository(AppDbContext appDbContext)
        {
            _AppDbcontext = appDbContext;
        }

        public IEnumerable<BuyList> buyLists { get => _AppDbcontext.BuyListItems; set => throw new NotImplementedException(); }

        public BuyList GetBuyList(int UserId)
        {
          return  _AppDbcontext.BuyListItems.FirstOrDefault(x=> x.UserId == UserId);
        }
        public bool HasList(int UserId, int ItemId)
        {

            List<LikedList> us = _AppDbcontext.LikedItems.Where(x => x.UserId == UserId && x.ItemId == ItemId).ToList();

            if (us.Any())
            {
                return true;
            }

            return false;

        }

    }
}
