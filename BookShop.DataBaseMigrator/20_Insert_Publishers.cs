
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace BookShop.DataBaseMigrator
{
    [Migration(20)]
    public class _20_Insert_Publishers:Migration
    {
        public override void Up()
        {
            IfDatabase("sqlserver").Execute.Sql("set identity_insert [Publishers] on");

            Insert.IntoTable("Publishers")
                .Row(new { 
                    id=1,
                    name="publisher1"
                });
            Insert.IntoTable("Publishers")
                .Row(new
                {
                    id = 2,
                    name = "publisher2"
                });
            Insert.IntoTable("Publishers")
                .Row(new
                {
                    id = 3,
                    name = "publisher3"
                });
            IfDatabase("sqlserver").Execute.Sql("set identity_insert [Publishers] off");
        }

        public override void Down()
        {
            for (int i = 1; i <= 3; i++)
            {
                Delete.FromTable("Publishers").Row(new { id=i});
            }
        }

    }
}
