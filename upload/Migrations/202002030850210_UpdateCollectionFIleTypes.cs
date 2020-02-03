namespace upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCollectionFIleTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectionFileTypes", "FileExtension", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CollectionFileTypes", "FileExtension");
        }
    }
}
