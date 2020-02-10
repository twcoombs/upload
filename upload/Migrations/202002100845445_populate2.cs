namespace upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.CollectionSchedules(Name, CollectionScheduleTypeId) VALUES ('Test 1', 11)");
            Sql("INSERT INTO dbo.CollectionSchedules(Name, CollectionScheduleTypeId) VALUES ('Test 2', 12)");
            Sql("INSERT INTO dbo.CollectionSchedules(Name, CollectionScheduleTypeId) VALUES ('Test 3', 13)");
            Sql("INSERT INTO dbo.CollectionSchedules(Name, CollectionScheduleTypeId) VALUES ('Test 4', 14)");
            Sql("INSERT INTO dbo.CollectionSchedules(Name, CollectionScheduleTypeId) VALUES ('Test 5', 15)");

            Sql("INSERT INTO dbo.PointTypes(Type) VALUES ('Number')");
            Sql("INSERT INTO dbo.PointTypes(Type) VALUES ('String')");
            Sql("INSERT INTO dbo.PointTypes(Type) VALUES ('Date')");
            Sql("INSERT INTO dbo.PointTypes(Type) VALUES ('DateTime')");
            Sql("INSERT INTO dbo.PointTypes(Type) VALUES ('Boolean')");
        }
        
        public override void Down()
        {
        }
    }
}
