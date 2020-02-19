namespace upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aeewff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "FilePath", c => c.String());
            AddColumn("dbo.Submissions", "Authorised", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "Authorised");
            DropColumn("dbo.Submissions", "FilePath");
        }
    }
}
