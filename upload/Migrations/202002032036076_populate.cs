namespace upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.CollectionFileTypes(Id,FileType,FileExtension) VALUES (1,'XLSX','.xlsx')");
            Sql("INSERT INTO dbo.CollectionFileTypes(Id,FileType,FileExtension) VALUES (2,'XLS','.xsl')");
            Sql("INSERT INTO dbo.CollectionFileTypes(Id,FileType,FileExtension) VALUES (3,'CSV','.csv')");
            Sql("INSERT INTO dbo.CollectionFileTypes(Id,FileType,FileExtension) VALUES (4,'XML','.xml')");
            Sql("INSERT INTO dbo.CollectionFileTypes(Id,FileType,FileExtension) VALUES (5,'JSON','.json')");

            Sql("INSERT INTO dbo.ScheduleTypes(Type) VALUES ('Daily')");
            Sql("INSERT INTO dbo.ScheduleTypes(Type) VALUES ('Weekly')");
            Sql("INSERT INTO dbo.ScheduleTypes(Type) VALUES ('Monthly')");
            Sql("INSERT INTO dbo.ScheduleTypes(Type) VALUES ('Annual')");
            Sql("INSERT INTO dbo.ScheduleTypes(Type) VALUES ('Ad-Hoc')");

            Sql("INSERT INTO dbo.Schedules(Name, ScheduleTypeId) VALUES ('Test 1', 1)");
            Sql("INSERT INTO dbo.Schedules(Name, ScheduleTypeId) VALUES ('Test 2', 2)");
            Sql("INSERT INTO dbo.Schedules(Name, ScheduleTypeId) VALUES ('Test 3', 3)");
            Sql("INSERT INTO dbo.Schedules(Name, ScheduleTypeId) VALUES ('Test 4', 4)");
            Sql("INSERT INTO dbo.Schedules(Name, ScheduleTypeId) VALUES ('Test 5', 5)");
        }
        
        public override void Down()
        {
        }
    }
}
