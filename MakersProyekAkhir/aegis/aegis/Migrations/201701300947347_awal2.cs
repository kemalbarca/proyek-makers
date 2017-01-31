namespace aegis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awal2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.cases", "code", c => c.String(nullable: false));
            AlterColumn("dbo.cases", "name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.cases", "name", c => c.String());
            AlterColumn("dbo.cases", "code", c => c.String());
        }
    }
}
