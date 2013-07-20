using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentMigrator;

namespace BookShop.DatabaseMigrator
{
    [Migration(4)]
   public class Books:Migration
    {
        public override void Up()
        {
            Create.Table("Books")
                .WithColumn("id").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("author").AsString().Nullable()
                .WithColumn("isbn").AsString()
                .WithColumn("publishdate").AsDateTime().Nullable()
                .WithColumn("wordscount").AsInt32().Nullable()
                .WithColumn("unitprice").AsFloat().Nullable()
                .WithColumn("contentdescription").AsString().Nullable()
                .WithColumn("editorcomment").AsString().Nullable()
                .WithColumn("toc").AsString().Nullable()
                .WithColumn("clicks").AsInt32().Nullable()
                .WithColumn("categoryid").AsInt32()
                .WithColumn("publisherid").AsInt32();
               

            Create.ForeignKey("Books_CategoriesId_FK")
                .FromTable("Books").ForeignColumn("categoryid")
                .ToTable("Categories").PrimaryColumn("id");
            Create.ForeignKey("Books_PublishersId_FK")
                .FromTable("Books").ForeignColumn("publisherid")
                .ToTable("Publishers").PrimaryColumn("id");
        }
        public override void Down()
        {
            Delete.Table("Books");
        }
    }
}
