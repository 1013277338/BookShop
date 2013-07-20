using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.Models
{
    public class BooksView
    {
        public int id { get; set; }
        public string author { get; set; }
        public string isbn { get; set; }
        public System.DateTime publishdate { get; set; }
        public int wordscount { get; set; }
        public float unitprice { get; set; }
        public string contentdescription { get; set; }
        public string editorcomment { get; set; }
        public string toc { get; set; }
        public int clicks { get; set; }
        public int categoryid { get; set; }
        public int publisherid { get; set; }

        
    }
}