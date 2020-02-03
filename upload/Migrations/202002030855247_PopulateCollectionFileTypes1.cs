namespace upload.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCollectionFileTypes1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.CollectionFileTypes(Id,FileType,FileExtension) VALUES (1,'XLSX','.xlsx')");
            Sql("INSERT INTO dbo.CollectionFileTypes(Id,FileType,FileExtension) VALUES (2,'XLS','.xsl')");
            Sql("INSERT INTO dbo.CollectionFileTypes(Id,FileType,FileExtension) VALUES (3,'CSV','.csv')");
            Sql("INSERT INTO dbo.CollectionFileTypes(Id,FileType,FileExtension) VALUES (4,'XML','.xml')");
            Sql("INSERT INTO dbo.CollectionFileTypes(Id,FileType,FileExtension) VALUES (5,'JSON','.json')");
        }

        public override void Down()
        {
        }
    }
}
