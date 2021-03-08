using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data.interfaces
{
  public  interface IBuyListReository
    {
        IEnumerable<BuyList> buyLists { get; set; }
        BuyList GetBuyList(int UserId);
        bool HasList(int UserId, int ItemId);

    }
}
