using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Services.EntityModels;

namespace BookShop.Services
{
    public interface IBookService
    {
        List<Books> GetAllBooks();

        Books GetBookById(int Bookid);
    }
}
