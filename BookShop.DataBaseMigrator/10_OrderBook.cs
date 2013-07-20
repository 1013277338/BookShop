using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(10)]
   public class OrderBook:Migration
    {
        public override void Up()
        {
            Create.Table("OrderBook")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("orderid").AsInt32().NotNullable()
                .WithColumn("quantity").AsInt32()
                .WithColumn("unitprice").AsFloat()
                .WithColumn("bookid").AsInt32();

            Create.ForeignKey("OrderBook_BookId_FK")
                .FromTable("OrderBook").ForeignColumn("bookid")
                .ToTable("Books").PrimaryColumn("id");

            Create.ForeignKey("OrderBook_OrderId_FK")
                .FromTable("OrderBook").ForeignColumn("orderid")
                .ToTable("Orders").PrimaryColumn("orderid").OnDelete(System.Data.Rule.Cascade);
        }
        public override void Down()
        {
            Delete.Table("OrderBook");
        }
    }
}
