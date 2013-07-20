using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BookShop.Services;
using BookShop.Services.EntityModels;
using BookShop.Web.Infrastructures;
using BookShop.Web.Models;
using Ninject;

namespace BookShop.WebApp.Controllers
{
    public class HomeController : Controller
    {

        [Inject]
        public BookService bookService { get; set; }

        [Inject]
        public CartService cartService { get; set; }

        [Inject]
        public UserManager userManager { get; set; }

        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用 ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult List()
        {          
            return View();
        }

        public ActionResult Details(int id)
        {
            var result = bookService.GetBookById(id);
            BooksView viewModel = Mapper.Map<Books, BooksView>(result);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult GetBooks(int? pageIndex = 1)
        {

            PagerInfo pager = new PagerInfo();
            pager.RecordCount = bookService.GetAllBooks().Count();
            pager.PageSize = 2;
            pager.CurrentPageIndex = (int)pageIndex;
            //List<NewsInfo> list = new List<NewsInfo>();
            //for (int i = 0; i < pager.RecordCount; i++)
            //{
            //    NewsInfo info = new NewsInfo() { ID = i + 1, Title = "", AddTime = DateTime.Now, UserName = "admin" };
            //     list.Add(info);
            //}
            var books = bookService.GetAllBooks();
            List<BooksView> viewModel = Mapper.Map<List<Books>, List<BooksView>>(books);


            IEnumerable<BooksView> info2 = viewModel.Where(id => id.id > (pager.CurrentPageIndex - 1) * pager.PageSize && id.id <= pager.CurrentPageIndex * pager.PageSize);
            PagerQuery<PagerInfo, IEnumerable<BooksView>> query = new PagerQuery<PagerInfo, IEnumerable<BooksView>>(pager, info2);
            return View(query);
          

            //var reslut = bookService.GetPagedBooks(Convert.ToInt32(pageSize), Convert.ToInt32(pageIndex));

            //List<BooksView> viewModel = Mapper.Map<List<Books>, List<BooksView>>(reslut);
            //return PartialView(viewModel); 
        }


        public ActionResult Cart(int bookid,IIdentity identity)
        {
            Users user = userManager.GetUserById(identity.Name);
            Books book = bookService.GetBookById(bookid);

           bool b =  cartService.AddtoCart(book, user);

           return Json(b,JsonRequestBehavior.AllowGet);
        }



    }
}
