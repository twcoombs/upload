namespace upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aeewffgrgerb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubmissionPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Attribute = c.String(nullable: false),
                        PointTypeId = c.Int(nullable: false),
                        Comments = c.String(),
                        CollectionPointId = c.Int(nullable: false),
                        SubmissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CollectionPoints", t => t.CollectionPointId, cascadeDelete: false)
                .ForeignKey("dbo.PointTypes", t => t.PointTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Submissions", t => t.SubmissionId, cascadeDelete: false)
                .Index(t => t.PointTypeId)
                .Index(t => t.CollectionPointId)
                .Index(t => t.SubmissionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubmissionPoints", "SubmissionId", "dbo.Submissions");
            DropForeignKey("dbo.SubmissionPoints", "PointTypeId", "dbo.PointTypes");
            DropForeignKey("dbo.SubmissionPoints", "CollectionPointId", "dbo.CollectionPoints");
            DropIndex("dbo.SubmissionPoints", new[] { "SubmissionId" });
            DropIndex("dbo.SubmissionPoints", new[] { "CollectionPointId" });
            DropIndex("dbo.SubmissionPoints", new[] { "PointTypeId" });
            DropTable("dbo.SubmissionPoints");
        }
    }
}
