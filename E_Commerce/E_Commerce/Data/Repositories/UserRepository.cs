using E_Commerce.Data.interfaces;
using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data.Repositories
{
    public class UserRepository : IUserRepository
    {


        private  AppDbContext _AppDbcontext;
        public UserRepository(AppDbContext appDbContext)
        {
            _AppDbcontext = appDbContext;
        }
        public IEnumerable<User> Users { get => _AppDbcontext.Users; set => throw new NotImplementedException(); }

        public User GetUserById(int User)
        {
          return _AppDbcontext.Users.FirstOrDefault(x=> x.UserId == User);
        }

        public void SetUser(User U)
        {
           
            _AppDbcontext.Users.Add(U);
            _AppDbcontext.SaveChanges();

        }
    }
}
