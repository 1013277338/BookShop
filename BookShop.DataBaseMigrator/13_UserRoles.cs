using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(13)]
   public class UserRoles:Migration
    {
        public override void Up()
        {
            Create.Table("UserRoles")
                .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("name").AsString();

        }
        public override void Down()
        {
            Delete.Table("UserRoles");
        }
    }
}
