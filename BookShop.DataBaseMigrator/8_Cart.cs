using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(8)]
   public class Cart:Migration
    {
        public override void Up()
        {
            Create.Table("Cart")
                .WithColumn("id").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("count").AsInt32()
                 .WithColumn("userid").AsInt32()
                 .WithColumn("bookid").AsInt32();


            Create.ForeignKey("Cart_UserId_FK")
                .FromTable("Cart").ForeignColumn("userid")
                .ToTable("Users").PrimaryColumn("id");

            Create.ForeignKey("Cart_BooksId_FK")
                .FromTable("Cart").ForeignColumn("bookid")
                .ToTable("Books").PrimaryColumn("id");
        }
        public override void Down()
        {
            Delete.Table("Cart");
        }
    }
}
