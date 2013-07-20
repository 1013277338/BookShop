using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace BookShop.DataBaseMigrator
{
    [Migration(18)]
    public class _18_Insert_Users:Migration
    {
      
        public override void Up()
        {
            IfDatabase("sqlserver").Execute.Sql("set identity_insert [users] on  ");

            Insert.IntoTable("Users")
                .Row(new
                {
                    id=1,
                    loginid="admin",
                    loginpwd="111111",
                    name="admin",
                    address="aaa",
                    phone="123",
                    mail="a.22.com",
                    money=100.00,
                    userstateid=1,
                    roleinfoid=1
                });

            Insert.IntoTable("Users")
               .Row(new
               {
                   id = 2,
                   loginid = "111111",
                   loginpwd = "111111",
                   name = "111111",
                   address = "aaa",
                   phone = "123",
                   mail = "a.22.com",
                   money = 100.00,
                   userstateid = 1,
                   roleinfoid = 2
               });

          

            IfDatabase("sqlserver").Execute.Sql("set identity_insert [users] off");
        }

        public override void Down()
        {
            for (int i = 1; i <= 2; i++)
            {
                Delete.FromTable("users").Row(new { id=i});
            }
        }

    }
}
