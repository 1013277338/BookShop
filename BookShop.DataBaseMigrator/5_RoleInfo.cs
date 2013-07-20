using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(5)]
   public class RoleInfo:Migration
    {
        public override void Up()
        {
            Create.Table("RoleInfo")
                .WithColumn("id").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("roledesc").AsString()
                .WithColumn("rolename").AsString();
                
        }
        public override void Down()
        {
            Delete.Table("RoleInfo");
        }
    }
}
