using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(14)]
   public class RoleRight:Migration
    {
        public override void Up()
        {
            Create.Table("RoleRight")
                .WithColumn("id").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("roleinfoid").AsInt32()
                .WithColumn("sysfunid").AsInt32();

            Create.ForeignKey("RoleRight_RoleInfo_FK")
                .FromTable("RoleRight").ForeignColumn("roleinfoid")
                .ToTable("RoleInfo").PrimaryColumn("id");

            Create.ForeignKey("RoleRight_SysFun_FK")
                .FromTable("RoleRight").ForeignColumn("sysfunid")
                .ToTable("SysFun").PrimaryColumn("id");
        }
        public override void Down()
        {
            Delete.Table("RoleRight");
        }
    }
}
