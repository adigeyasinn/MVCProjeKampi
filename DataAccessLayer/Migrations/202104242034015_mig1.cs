namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Headings", "Writer_WriterID", "dbo.Writers");
            DropIndex("dbo.Headings", new[] { "Writer_WriterID" });
            DropIndex("dbo.Contents", new[] { "WriterID" });
            RenameColumn(table: "dbo.Headings", name: "Writer_WriterID", newName: "WriterID");
            AlterColumn("dbo.Headings", "WriterID", c => c.Int(nullable: false));
            AlterColumn("dbo.Contents", "WriterID", c => c.Int());
            CreateIndex("dbo.Headings", "WriterID");
            CreateIndex("dbo.Contents", "WriterID");
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID");
            AddForeignKey("dbo.Headings", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headings", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropIndex("dbo.Headings", new[] { "WriterID" });
            AlterColumn("dbo.Contents", "WriterID", c => c.Int(nullable: false));
            AlterColumn("dbo.Headings", "WriterID", c => c.Int());
            RenameColumn(table: "dbo.Headings", name: "WriterID", newName: "Writer_WriterID");
            CreateIndex("dbo.Contents", "WriterID");
            CreateIndex("dbo.Headings", "Writer_WriterID");
            AddForeignKey("dbo.Headings", "Writer_WriterID", "dbo.Writers", "WriterID");
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: true);
        }
    }
}
