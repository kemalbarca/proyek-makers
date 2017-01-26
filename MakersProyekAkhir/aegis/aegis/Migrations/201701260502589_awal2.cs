namespace aegis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awal2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.accounts", "name", c => c.String(nullable: false));
            AlterColumn("dbo.orders", "name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.orders", "name", c => c.String());
            AlterColumn("dbo.accounts", "name", c => c.String());
        }
    }
}
