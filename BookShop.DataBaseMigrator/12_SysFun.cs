using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(12)]
   public class SysFun:Migration
    {
        public override void Up()
        {
            Create.Table("SysFun")
                .WithColumn("id").AsInt32().PrimaryKey().NotNullable()
                .WithColumn("displayname").AsString()
                .WithColumn("nodeurl").AsString()
                .WithColumn("displayorder").AsInt32()
                .WithColumn("parentnodeid").AsInt32();
        }
        public override void Down()
        {
            Delete.Table("SysFun");
        }
    }
}
