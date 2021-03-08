using E_Commerce.Data;
using E_Commerce.Data.interfaces;
using E_Commerce.Data.Models;
using E_Commerce.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {

        private AppDbContext _context;
        ILikedListRepository _iLikedListRepository;
        IBuyListReository _iBuyListReository;

        public HomeController(AppDbContext context , ILikedListRepository iLikedListRepository , IBuyListReository iBuyListReository)
        {
            _context = context;
            _iLikedListRepository = iLikedListRepository;
            _iBuyListReository = iBuyListReository;
        }

        public IActionResult list(int? CategoryId)
        {
            UserItems uI = new UserItems();

            if (CategoryId != null) {

                uI.MyItems = _context.Items.OrderBy(x => x.ItemId).Where(x => x.CategoryId == CategoryId).ToList();
            }
            else {
                uI.MyItems = _context.Items.OrderBy(x => x.ItemId).ToList();
            }

          

           

            uI.TheName = HttpContext.Session.GetString("UserName");
            uI.TheRole = HttpContext.Session.GetString("UserRole");


            return View(uI);
        }

    

        [HttpPost]
        public IActionResult List(String Act , int ItemId , int CategoryId)
        {

            UserItems uI = new UserItems();

            uI.MyItems = _context.Items.OrderBy(x => x.ItemId).ToList();

            uI.TheName = HttpContext.Session.GetString("UserName");
            uI.TheRole = HttpContext.Session.GetString("UserRole");


            if (uI.TheName != null)
            {


                Item item = _context.Items.FirstOrDefault(x => x.ItemId == ItemId);

                int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));

                bool has = _iLikedListRepository.HasList(userId, ItemId);

                if (Act == "Like")
                {

                    LikedList likedList = new LikedList
                    {

                        CategoryId = CategoryId,
                        ItemId = ItemId,
                        likedItems = new List<Item> { item },
                        UserId = userId




                    };

                    _context.LikedItems.Add(likedList);
                    _context.SaveChanges();

                }

                if (Act == "Buy")
                {

                    BuyList BuyList = new BuyList
                    {

                        CategoryId = CategoryId,
                        ItemId = ItemId,
                        BuyItemLists = new List<Item> { item },
                        UserId = userId




                    };

                    _context.BuyListItems.Add(BuyList);
                    _context.SaveChanges();

                }



            }
            else {

                return RedirectToAction("Login", "Main");
            }

       

            return View(uI);
        }

        [HttpGet]
        public IActionResult LikedList()
        {
            LikedItemsModel likedItemsModel = new LikedItemsModel();

            String UserName =  HttpContext.Session.GetString("UserName");

        int UserId    = Convert.ToInt32(HttpContext.Session.GetString("UserId"));

            if (UserName != null) {






          
                var Things = from a in _context.LikedItems
                             where a.UserId == UserId
                             join b in _context.Items on a.ItemId equals b.ItemId
                             select new LikedItemsModel { ItemId = b.ItemId 
                             
                               ,CategoryId = b.CategoryId 
                               ,Description = b.Description
                               ,ItemName = b.ItemName
                               ,price = b.price 
                               ,UrlImg = b.UrlImg
                               ,likedList = a.LikedListId
                             };


                return View(Things);

            }

            return View();

        }


        [HttpPost]
        public IActionResult LikedList(String Act, int ItemId, int CategoryId)
        {

            UserItems uI = new UserItems();

            uI.MyItems = _context.Items.OrderBy(x => x.ItemId).ToList();

            uI.TheName = HttpContext.Session.GetString("UserName");
            uI.TheRole = HttpContext.Session.GetString("UserRole");


            if (uI.TheName != null)
            {


                Item item = _context.Items.FirstOrDefault(x => x.ItemId == ItemId);

                int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));

                bool has = _iLikedListRepository.HasList(userId, ItemId);

           

                if (Act == "Buy"&& !has)
                {

                    BuyList BuyList = new BuyList
                    {

                        CategoryId = CategoryId,
                        ItemId = ItemId,
                        BuyItemLists = new List<Item> { item },
                        UserId = userId




                    };

                    _context.BuyListItems.Add(BuyList);
                    _context.SaveChanges();

                }

                if (Act == "Delete" )
                {


                    LikedList itemss = _context.LikedItems.FirstOrDefault(x => x.UserId == userId && x.ItemId == ItemId);



                    _context.LikedItems.Remove(itemss);

                    _context.SaveChanges();

                }



            }



            return RedirectToAction("LikedList");


        }

        [HttpPost]
        public IActionResult BuyList(String Act, int ItemId, int CategoryId)
        {

            UserItems uI = new UserItems();

            uI.MyItems = _context.Items.OrderBy(x => x.ItemId).ToList();

            uI.TheName = HttpContext.Session.GetString("UserName");
            uI.TheRole = HttpContext.Session.GetString("UserRole");


            if (uI.TheName != null)
            {


                Item item = _context.Items.FirstOrDefault(x => x.ItemId == ItemId);

                int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));

                bool has = _iBuyListReository.HasList(userId, ItemId);



                if (Act == "Like" && !has)
                {

                    LikedList LikedList = new LikedList
                    {

                        CategoryId = CategoryId,
                        ItemId = ItemId,
                        likedItems = new List<Item> { item },
                        UserId = userId




                    };

                    _context.LikedItems.Add(LikedList);
                    _context.SaveChanges();

                }

                if (Act == "Delete" )
                {


                    BuyList items = _context.BuyListItems.Where(x=> x.UserId == userId && x.ItemId == ItemId).FirstOrDefault();


                    _context.BuyListItems.Remove(items);
                    _context.SaveChanges();

                }



            }



            return RedirectToAction("BuyList");


        }

        public IActionResult BuyList()
        {
           

            String UserName = HttpContext.Session.GetString("UserName");

            int UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));

            if (UserName != null)
            {







                var Things = from a in _context.BuyListItems
                             where a.UserId == UserId
                             join b in _context.Items on a.ItemId equals b.ItemId
                             select new LikedItemsModel
                             {
                                 ItemId = b.ItemId

                               ,
                                 CategoryId = b.CategoryId
                               ,
                                 Description = b.Description
                               ,
                                 ItemName = b.ItemName
                               ,
                                 price = b.price
                               ,
                                 UrlImg = b.UrlImg
                               
                                
                             };


                return View(Things);

            }

            return View();

        }

        public IActionResult Index()
        {

        

            return View();
        }
    }
}
