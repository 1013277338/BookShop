using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Services.EntityModels;

namespace BookShop.Services
{
   public class BookService:IBookService
    {

       public IRepository<Books> booksRepository { get; set; }

       public BookService(IRepository<Books> BooksRepository)
       {
           booksRepository = BooksRepository;
       }

       public List<Books> GetAllBooks()
       {
           return booksRepository.Table.ToList();
       }

       public Books GetBookById(int Bookid)
       {
           return booksRepository.Table.FirstOrDefault(b=>b.id==Bookid);
       }

    }
}
