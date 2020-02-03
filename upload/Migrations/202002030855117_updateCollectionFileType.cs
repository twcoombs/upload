namespace upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCollectionFileType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CollectionFileTypes", "FileType", c => c.String());
            AlterColumn("dbo.CollectionFileTypes", "FileExtension", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CollectionFileTypes", "FileExtension", c => c.Byte(nullable: false));
            AlterColumn("dbo.CollectionFileTypes", "FileType", c => c.Byte(nullable: false));
        }
    }
}
