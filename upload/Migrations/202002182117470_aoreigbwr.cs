namespace upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aoreigbwr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CollectionInstances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CollectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collections", t => t.CollectionId, cascadeDelete: true)
                .Index(t => t.CollectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectionInstances", "CollectionId", "dbo.Collections");
            DropIndex("dbo.CollectionInstances", new[] { "CollectionId" });
            DropTable("dbo.CollectionInstances");
        }
    }
}
