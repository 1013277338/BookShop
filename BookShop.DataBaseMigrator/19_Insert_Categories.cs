using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace BookShop.DataBaseMigrator
{
    [Migration(19)]
    public class _19_Insert_Categories:Migration
    {
        public override void Up()
        {
            IfDatabase("sqlserver").Execute.Sql("set identity_insert [Categories] on");
            Insert.IntoTable("Categories")
                .Row(new
                {
                    id=1,
                    name="C#"
                });
            Insert.IntoTable("Categories")
               .Row(new
               {
                   id = 2,
                   name = "C"
               });
            Insert.IntoTable("Categories")
               .Row(new
               {
                   id = 3,
                   name = "JAVA"
               });

            IfDatabase("sqlserver").Execute.Sql("set identity_insert [Categories] off");
               
        }

        public override void Down()
        {
            for (int i = 1; i <= 3; i++)
            {
                Delete.FromTable("Categories").Row(new { id=i});
            }
        }

    }
}
