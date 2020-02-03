namespace upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectionFileTYpe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectionFileTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        FileType = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Collections", "CollectionFileTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Collections", "CollectionFileTypeId");
            AddForeignKey("dbo.Collections", "CollectionFileTypeId", "dbo.CollectionFileTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Collections", "CollectionFileTypeId", "dbo.CollectionFileTypes");
            DropIndex("dbo.Collections", new[] { "CollectionFileTypeId" });
            DropColumn("dbo.Collections", "CollectionFileTypeId");
            DropTable("dbo.CollectionFileTypes");
        }
    }
}
