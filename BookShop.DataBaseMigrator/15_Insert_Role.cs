using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(15)]
    class _15_Insert_Role:Migration
    {
        public override void Up()
        {
            Insert.IntoTable("RoleInfo")
                .Row(new { 
                   id=1,
                   roledesc="user",
                   rolename="user"
                });
            Insert.IntoTable("RoleInfo")
                .Row(new
                {
                    id = 2,
                    roledesc = "admin",
                    rolename = "admin"
                });
        }

        public override void Down()
        {
            for (int i = 1; i <= 2; i++)
            {
                Delete.FromTable("RoleInfo").Row(new { id=i});
            }
        }
    }
}
