using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(11)]
   public class PayInfo:Migration
    {
        public override void Up()
        {
            Create.Table("PayInfo")
                .WithColumn("guid").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("money").AsFloat()
                .WithColumn("date").AsDateTime()
                .WithColumn("userid").AsInt32()
                .WithColumn("remark").AsString()
                .WithColumn("state").AsInt32();

            Create.ForeignKey("PayInfo_UserId_FK")
                .FromTable("PayInfo").ForeignColumn("userid")
                .ToTable("Users").PrimaryColumn("id");

        }
        public override void Down()
        {
            Delete.Table("PayInfo");
        }
    }
}
