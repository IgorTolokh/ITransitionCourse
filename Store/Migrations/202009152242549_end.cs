namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class end : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        CollectionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.CollectionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Collections");
        }
    }
}
