namespace aegis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awal1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.campaigns", "name", c => c.String(nullable: false));
            AlterColumn("dbo.invoices", "code", c => c.String(nullable: false));
            AlterColumn("dbo.invoices", "name", c => c.String(nullable: false));
            AlterColumn("dbo.orders", "code", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.orders", "code", c => c.String());
            AlterColumn("dbo.invoices", "name", c => c.String());
            AlterColumn("dbo.invoices", "code", c => c.String());
            AlterColumn("dbo.campaigns", "name", c => c.String());
        }
    }
}
