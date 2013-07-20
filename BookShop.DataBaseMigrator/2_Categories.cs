using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(2)]
  public  class Categories:Migration
    {
        public override void Up()
        {
            Create.Table("Categories")
                .WithColumn("id").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("name").AsString();
        }
        public override void Down()
        {
            Delete.Table("Categories");
        }
    }
}
