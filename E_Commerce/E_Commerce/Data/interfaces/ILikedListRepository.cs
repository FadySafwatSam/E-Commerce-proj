using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data.interfaces
{
    public interface ILikedListRepository
    {
        IEnumerable<LikedList> LikedLists { get; set; }
        LikedList GetLikedList(int UserId);
        bool HasList(int UserId,int ItemId);
    }
}
