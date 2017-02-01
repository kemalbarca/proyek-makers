namespace aegis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awal31 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.invoices", "billingaddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.invoices", "billingaddress", c => c.String());
        }
    }
}
