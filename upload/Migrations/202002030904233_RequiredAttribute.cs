namespace upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredAttribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Collections", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.CollectionPoints", "Attribute", c => c.String(nullable: false));
            AlterColumn("dbo.CollectionPoints", "DataType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CollectionPoints", "DataType", c => c.String());
            AlterColumn("dbo.CollectionPoints", "Attribute", c => c.String());
            AlterColumn("dbo.Collections", "Name", c => c.String());
        }
    }
}
