using E_Commerce.Data.interfaces;
using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly AppDbContext _AppDbcontext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _AppDbcontext = appDbContext;
        }

        public IEnumerable<Category> Categories { get => _AppDbcontext.Categories; set => throw new NotImplementedException(); }
    }
}
