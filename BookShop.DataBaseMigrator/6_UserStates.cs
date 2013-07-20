using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(6)]
  public  class UserStates:Migration
    {
        public override void Up()
        {
            Create.Table("UserStates")
                .WithColumn("id").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("name").AsString();
        }
        public override void Down()
        {
            Delete.Table("UserStates");
        }
    }
}
