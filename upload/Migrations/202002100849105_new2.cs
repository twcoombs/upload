namespace upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CollectionPoints", "LineKey");
            DropColumn("dbo.CollectionPoints", "Set");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CollectionPoints", "Set", c => c.Int(nullable: false));
            AddColumn("dbo.CollectionPoints", "LineKey", c => c.Int(nullable: false));
        }
    }
}
