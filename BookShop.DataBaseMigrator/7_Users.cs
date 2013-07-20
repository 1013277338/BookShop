using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(7)]
   public class Users:Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("loginid").AsString()
                .WithColumn("loginpwd").AsString()
                .WithColumn("name").AsString()
                .WithColumn("address").AsString()
                .WithColumn("phone").AsString()
                .WithColumn("mail").AsString()
                .WithColumn("money").AsDecimal()
                .WithColumn("userstateid").AsInt32()
                .WithColumn("roleinfoid").AsInt32();

            Create.ForeignKey("Users_UserStates_FK")
                .FromTable("Users").ForeignColumn("userstateid")
                .ToTable("UserStates").PrimaryColumn("id");

            Create.ForeignKey("Users_RoleInfo_FK")
                .FromTable("Users").ForeignColumn("roleinfoid")
                .ToTable("RoleInfo").PrimaryColumn("id");

        }
        public override void Down()
        {
            Delete.Table("Users");
        }
    }
}
