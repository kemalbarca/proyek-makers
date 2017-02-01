namespace aegis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awal3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.accounts", "code", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.accounts", "code", c => c.String());
        }
    }
}
