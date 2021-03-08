using E_Commerce.Data.interfaces;
using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data.Repositories
{
    public class LikedListRepository : ILikedListRepository
    {

        private readonly AppDbContext _AppDbcontext;
        public LikedListRepository(AppDbContext appDbContext)
        {
            _AppDbcontext = appDbContext;
        }

        public IEnumerable<LikedList> LikedLists { get => _AppDbcontext.LikedItems; set => throw new NotImplementedException(); }

        public LikedList GetLikedList(int UserId)
        {
            return _AppDbcontext.LikedItems.FirstOrDefault(x => x.UserId == UserId);
        }

 

        public bool HasList(int UserId , int ItemId)
        {

             List<BuyList> us = _AppDbcontext.BuyListItems.Where(x => x.UserId == UserId && x.ItemId == ItemId).ToList();

            if (us.Any())
            {
                return true;
            }

            return false;

        }
    }
}
