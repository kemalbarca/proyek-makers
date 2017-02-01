namespace aegis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awal4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.opportunities", "stageId", "dbo.stages");
            DropForeignKey("dbo.opportunities", "statusopportunityId", "dbo.statusopportunities");
            DropIndex("dbo.opportunities", new[] { "stageId" });
            DropIndex("dbo.opportunities", new[] { "statusopportunityId" });
            AlterColumn("dbo.campaigns", "code", c => c.String(nullable: false));
            AlterColumn("dbo.marketinglists", "code", c => c.String(nullable: false));
            AlterColumn("dbo.marketinglists", "name", c => c.String(nullable: false));
            AlterColumn("dbo.opportunities", "stageId", c => c.Int(nullable: false));
            AlterColumn("dbo.opportunities", "statusopportunityId", c => c.Int(nullable: false));
            AlterColumn("dbo.opportunities", "code", c => c.String(nullable: false));
            AlterColumn("dbo.opportunities", "name", c => c.String(nullable: false));
            AlterColumn("dbo.statusopportunities", "code", c => c.String(nullable: false));
            AlterColumn("dbo.statusopportunities", "name", c => c.String(nullable: false));
            AlterColumn("dbo.orders", "name", c => c.String(nullable: false));
            AlterColumn("dbo.orders", "address", c => c.String(nullable: false));
            AlterColumn("dbo.orders", "shipaddress", c => c.String(nullable: false));
            AlterColumn("dbo.quotes", "code", c => c.String(nullable: false));
            AlterColumn("dbo.quotes", "name", c => c.String(nullable: false));
            CreateIndex("dbo.opportunities", "stageId");
            CreateIndex("dbo.opportunities", "statusopportunityId");
            AddForeignKey("dbo.opportunities", "stageId", "dbo.stages", "stageId", cascadeDelete: true);
            AddForeignKey("dbo.opportunities", "statusopportunityId", "dbo.statusopportunities", "statusopportunityId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.opportunities", "statusopportunityId", "dbo.statusopportunities");
            DropForeignKey("dbo.opportunities", "stageId", "dbo.stages");
            DropIndex("dbo.opportunities", new[] { "statusopportunityId" });
            DropIndex("dbo.opportunities", new[] { "stageId" });
            AlterColumn("dbo.quotes", "name", c => c.String());
            AlterColumn("dbo.quotes", "code", c => c.String());
            AlterColumn("dbo.orders", "shipaddress", c => c.String());
            AlterColumn("dbo.orders", "address", c => c.String());
            AlterColumn("dbo.orders", "name", c => c.String());
            AlterColumn("dbo.statusopportunities", "name", c => c.String());
            AlterColumn("dbo.statusopportunities", "code", c => c.String());
            AlterColumn("dbo.opportunities", "name", c => c.String());
            AlterColumn("dbo.opportunities", "code", c => c.String());
            AlterColumn("dbo.opportunities", "statusopportunityId", c => c.Int());
            AlterColumn("dbo.opportunities", "stageId", c => c.Int());
            AlterColumn("dbo.marketinglists", "name", c => c.String());
            AlterColumn("dbo.marketinglists", "code", c => c.String());
            AlterColumn("dbo.campaigns", "code", c => c.String());
            CreateIndex("dbo.opportunities", "statusopportunityId");
            CreateIndex("dbo.opportunities", "stageId");
            AddForeignKey("dbo.opportunities", "statusopportunityId", "dbo.statusopportunities", "statusopportunityId");
            AddForeignKey("dbo.opportunities", "stageId", "dbo.stages", "stageId");
        }
    }
}
