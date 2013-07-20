using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace BookShop.DataBaseMigrator
{
    [Migration(21)]
    public class _21_Insert_Books:Migration
    {
        public override void Up()
        {
            IfDatabase("sqlserver").Execute.Sql("set identity_insert [Books] on");
            Insert.IntoTable("Books")
                .Row(new
                {
                    id=1,
                    author="author1",
                    isbn="111",
                    publishdate="2013-06-30",
                    wordscount=230,
                    unitprice=23,
                    contentdescription="",
                    editorcomment="",
                    toc="",
                    clicks=0,
                    categoryid=1,
                    publisherid=1

                });
            Insert.IntoTable("Books")
                .Row(new
                {
                    id = 2,
                    author = "author2",
                    isbn = "222",
                    publishdate = "2013-06-30",
                    wordscount = 230,
                    unitprice = 23,
                    contentdescription = "",
                    editorcomment = "",
                    toc = "",
                    clicks = 0,
                    categoryid = 1,
                    publisherid = 1

                });
            Insert.IntoTable("Books")
                .Row(new
                {
                    id = 3,
                    author = "author1",
                    isbn = "333",
                    publishdate = "2013-06-30",
                    wordscount = 230,
                    unitprice = 23,
                    contentdescription = "",
                    editorcomment = "",
                    toc = "",
                    clicks = 0,
                    categoryid = 1,
                    publisherid = 1

                });
            Insert.IntoTable("Books")
                .Row(new
                {
                    id = 4,
                    author = "author1",
                    isbn = "444",
                    publishdate = "2013-06-30",
                    wordscount = 230,
                    unitprice = 23,
                    contentdescription = "",
                    editorcomment = "",
                    toc = "",
                    clicks = 0,
                    categoryid = 1,
                    publisherid = 1

                });
            Insert.IntoTable("Books")
                .Row(new
                {
                    id = 5,
                    author = "author1",
                    isbn = "555",
                    publishdate = "2013-06-30",
                    wordscount = 230,
                    unitprice = 23,
                    contentdescription = "",
                    editorcomment = "",
                    toc = "",
                    clicks = 0,
                    categoryid = 1,
                    publisherid = 1

                });
            Insert.IntoTable("Books")
                .Row(new
                {
                    id = 6,
                    author = "author1",
                    isbn = "666",
                    publishdate = "2013-06-30",
                    wordscount = 230,
                    unitprice = 23,
                    contentdescription = "",
                    editorcomment = "",
                    toc = "",
                    clicks = 0,
                    categoryid = 1,
                    publisherid = 1

                });
            Insert.IntoTable("Books")
                .Row(new
                {
                    id = 7,
                    author = "author1",
                    isbn = "777",
                    publishdate = "2013-06-30",
                    wordscount = 230,
                    unitprice = 23,
                    contentdescription = "",
                    editorcomment = "",
                    toc = "",
                    clicks = 0,
                    categoryid = 1,
                    publisherid = 1

                });

            IfDatabase("sqlserver").Execute.Sql("set identity_insert [Books] off");
        }

        public override void Down()
        {
            
        }

    }
}
