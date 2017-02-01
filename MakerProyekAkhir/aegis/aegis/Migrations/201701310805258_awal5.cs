namespace aegis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awal5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.campaigns", "DetailForm_activitydate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.campaigns", "DetailForm_activitydate", c => c.DateTime(nullable: false));
        }
    }
}
