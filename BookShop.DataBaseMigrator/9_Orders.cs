using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(9)]
   public class Orders:Migration
    {
        public override void Up()
        {
            Create.Table("Orders")
                .WithColumn("orderid").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("orderdate").AsDateTime()
                .WithColumn("state").AsInt32()
                .WithColumn("postAddress").AsString()
                .WithColumn("totalprice").AsFloat()
                .WithColumn("userid").AsInt32();

            Create.ForeignKey("Orders_UserId_FK")
                .FromTable("Orders").ForeignColumn("userid")
                .ToTable("Users").PrimaryColumn("id");
        }

        public override void Down()
        {
            Delete.Table("Orders");
        }
    }
}
