namespace upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
           
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        CollectionId = c.Int(nullable: false),
                        CollectionFileTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collections", t => t.CollectionId, cascadeDelete: false)
                .ForeignKey("dbo.CollectionFileTypes", t => t.CollectionFileTypeId, cascadeDelete: false)
                .Index(t => t.CollectionId)
                .Index(t => t.CollectionFileTypeId);
  
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Submissions", "CollectionFileTypeId", "dbo.CollectionFileTypes");
            DropForeignKey("dbo.Submissions", "CollectionId", "dbo.Collections");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CollectionSchedules", "CollectionScheduleTypeId", "dbo.CollectionScheduleTypes");
            DropForeignKey("dbo.CollectionPoints", "PointTypeId", "dbo.PointTypes");
            DropForeignKey("dbo.CollectionPoints", "CollectionId", "dbo.Collections");
            DropForeignKey("dbo.Collections", "CollectionFileTypeId", "dbo.CollectionFileTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Submissions", new[] { "CollectionFileTypeId" });
            DropIndex("dbo.Submissions", new[] { "CollectionId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CollectionSchedules", new[] { "CollectionScheduleTypeId" });
            DropIndex("dbo.CollectionPoints", new[] { "CollectionId" });
            DropIndex("dbo.CollectionPoints", new[] { "PointTypeId" });
            DropIndex("dbo.Collections", new[] { "CollectionFileTypeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Submissions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.CollectionScheduleTypes");
            DropTable("dbo.CollectionSchedules");
            DropTable("dbo.PointTypes");
            DropTable("dbo.CollectionPoints");
            DropTable("dbo.CollectionFileTypes");
            DropTable("dbo.Collections");
        }
    }
}
