namespace aegis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awal3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.cases", "DetailForm_actiondate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.cases", "DetailForm_actiondate", c => c.DateTime(nullable: false));
        }
    }
}
