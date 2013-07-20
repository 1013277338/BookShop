using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(1)]
   public class BillSetttings:Migration
    {
        public override void Up()
        {
            Create.Table("BillSetttings")
                  .WithColumn("partner").AsString().NotNullable()
                  .WithColumn("return_url").AsString()
                  .WithColumn("subject").AsString()
                  .WithColumn("body").AsString()
                  .WithColumn("out_trade_no").AsString()
                  .WithColumn("total_fee").AsFloat()
                  .WithColumn("seller_email").AsString()
                  .WithColumn("key").AsString()
                  .WithColumn("sign").AsString()
                  .WithColumn("gatewayurl").AsString();

                   
        }
        public override void Down()
        {
            Delete.Table("BillSetttings");
        }
    }
}
