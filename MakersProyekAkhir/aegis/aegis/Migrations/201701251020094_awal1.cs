namespace aegis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awal1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.products", "name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.products", "name", c => c.String());
        }
    }
}
