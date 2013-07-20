using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace BookShop.DataBaseMigrator
{
    [Migration(17)]
   public class _17_Insert_RoleInfo:Migration
    {
        public override void Up()
        {
            IfDatabase("sqlserver").Execute.Sql("SET IDENTITY_INSERT [RoleInfo] ON");

            Insert.IntoTable("RoleInfo")
                .Row(new
                {
                    id=1,
                    roledesc = "adminstrator",
                    rolename = "adminstrator"
                });
            Insert.IntoTable("RoleInfo")
               .Row(new
               {
                   id=2,
                   roledesc = "membership",
                   rolename = "membership"
               });
            IfDatabase("sqlserver").Execute.Sql("SET IDENTITY_INSERT [RoleInfo] OFF");
        }

        public override void Down()
        {
            
        }

    }
}
