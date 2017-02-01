namespace aegis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201701270653296_awal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.accounts", "telephone", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.accounts", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.accounts", "email", c => c.String());
            AlterColumn("dbo.accounts", "telephone", c => c.String(nullable: false));
        }
    }
}
