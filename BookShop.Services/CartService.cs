using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BookShop.Services.EntityModels;

namespace BookShop.Services
{
   public class CartService
    {

       public IRepository<Cart> cartRepository { get; set; }

       public CartService(IRepository<Cart> CartRepository)
       {
           this.cartRepository = CartRepository;
       }

       /// <summary>
       /// 添加到购物车
       /// </summary>
       /// <param name="bookid"></param>
       public bool AddtoCart(Books book,Users user)
       {
           bool  b = false;
           try
           {
               Cart cart = new Cart();
               cart.bookid = book.id;
               cart.count = 1;
               cart.userid = Convert.ToInt32(user.loginid);
               cart.Users = user;
               cart.Books = book;
               cartRepository.Add(cart);
               cartRepository.Save();
               b = true;
           }
           catch (Exception ex)
           {
               
               throw new Exception( ex.Message);
           }
           return b;
          
       }
    }
}
