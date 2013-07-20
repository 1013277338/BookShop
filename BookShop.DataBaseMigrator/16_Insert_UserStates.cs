using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace BookShop.DataBaseMigrator
{
    [Migration(16)]
    public class _16_Insert_UserStates:Migration
    {
        public override void Up()
        {
            IfDatabase("sqlserver").Execute.Sql("SET IDENTITY_INSERT [UserStates] ON");
            Insert.IntoTable("UserStates")
                .Row(new { 
                    Id=1,
                    name="Normal"
                });
            Insert.IntoTable("UserStates")
                .Row(new
                {
                    Id = 2,
                    name = "Locked"
                });
            Insert.IntoTable("UserStates")
               .Row(new
               {
                   Id = 3,
                   name = "Unusual"
               });
            IfDatabase("sqlserver").Execute.Sql("SET IDENTITY_INSERT [UserStates] OFF");
        }

        public override void Down()
        {
            for (int i = 1; i <= 3; i++)
            {
                Delete.FromTable("UserStates").Row(new { id=i});
            }
        }
    }
}
