using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data.interfaces
{
   public interface IUserRepository
    {
        IEnumerable<User> Users { get; set; }
        User GetUserById(int User);
        void SetUser(User U);

    }
}
