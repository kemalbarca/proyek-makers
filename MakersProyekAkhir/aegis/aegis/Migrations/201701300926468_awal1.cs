namespace aegis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awal1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.opportunities", "accountId", "dbo.accounts");
            DropForeignKey("dbo.opportunities", "stageId", "dbo.stages");
            DropIndex("dbo.opportunities", new[] { "stageId" });
            DropIndex("dbo.opportunities", new[] { "accountId" });
            AlterColumn("dbo.accounts", "name", c => c.String(nullable: false));
            AlterColumn("dbo.cases", "DetailForm_actiondate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.products", "description", c => c.String(nullable: false));
            AlterColumn("dbo.producttypes", "code", c => c.String(nullable: false));
            AlterColumn("dbo.producttypes", "name", c => c.String(nullable: false));
            AlterColumn("dbo.leads", "code", c => c.String(nullable: false));
            AlterColumn("dbo.leads", "firstname", c => c.String(nullable: false));
            AlterColumn("dbo.leads", "lastname", c => c.String(nullable: false));
            AlterColumn("dbo.leads", "email", c => c.String(nullable: false));
            AlterColumn("dbo.leads", "phone", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.organizations", "code", c => c.String(nullable: false));
            AlterColumn("dbo.organizations", "name", c => c.String(nullable: false));
            AlterColumn("dbo.organizations", "fulladdress", c => c.String(nullable: false));
            AlterColumn("dbo.organizations", "phone", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.organizations", "email", c => c.String(nullable: false));
            AlterColumn("dbo.organizationtypes", "code", c => c.String(nullable: false));
            AlterColumn("dbo.organizationtypes", "name", c => c.String(nullable: false));
            AlterColumn("dbo.opportunities", "stageId", c => c.Int(nullable: false));
            AlterColumn("dbo.opportunities", "accountId", c => c.Int(nullable: false));
            AlterColumn("dbo.stages", "code", c => c.String(nullable: false));
            AlterColumn("dbo.stages", "name", c => c.String(nullable: false));
            AlterColumn("dbo.pipes", "code", c => c.String(nullable: false));
            AlterColumn("dbo.pipes", "name", c => c.String(nullable: false));
            AlterColumn("dbo.statusopportunities", "code", c => c.String(nullable: false));
            AlterColumn("dbo.statusopportunities", "name", c => c.String(nullable: false));
            AlterColumn("dbo.orders", "name", c => c.String(nullable: false));
            CreateIndex("dbo.opportunities", "stageId");
            CreateIndex("dbo.opportunities", "accountId");
            AddForeignKey("dbo.opportunities", "accountId", "dbo.accounts", "accountId", cascadeDelete: true);
            AddForeignKey("dbo.opportunities", "stageId", "dbo.stages", "stageId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.opportunities", "stageId", "dbo.stages");
            DropForeignKey("dbo.opportunities", "accountId", "dbo.accounts");
            DropIndex("dbo.opportunities", new[] { "accountId" });
            DropIndex("dbo.opportunities", new[] { "stageId" });
            AlterColumn("dbo.orders", "name", c => c.String());
            AlterColumn("dbo.statusopportunities", "name", c => c.String());
            AlterColumn("dbo.statusopportunities", "code", c => c.String());
            AlterColumn("dbo.pipes", "name", c => c.String());
            AlterColumn("dbo.pipes", "code", c => c.String());
            AlterColumn("dbo.stages", "name", c => c.String());
            AlterColumn("dbo.stages", "code", c => c.String());
            AlterColumn("dbo.opportunities", "accountId", c => c.Int());
            AlterColumn("dbo.opportunities", "stageId", c => c.Int());
            AlterColumn("dbo.organizationtypes", "name", c => c.String());
            AlterColumn("dbo.organizationtypes", "code", c => c.String());
            AlterColumn("dbo.organizations", "email", c => c.String());
            AlterColumn("dbo.organizations", "phone", c => c.String());
            AlterColumn("dbo.organizations", "fulladdress", c => c.String());
            AlterColumn("dbo.organizations", "name", c => c.String());
            AlterColumn("dbo.organizations", "code", c => c.String());
            AlterColumn("dbo.leads", "phone", c => c.String());
            AlterColumn("dbo.leads", "email", c => c.String());
            AlterColumn("dbo.leads", "lastname", c => c.String());
            AlterColumn("dbo.leads", "firstname", c => c.String());
            AlterColumn("dbo.leads", "code", c => c.String());
            AlterColumn("dbo.producttypes", "name", c => c.String());
            AlterColumn("dbo.producttypes", "code", c => c.String());
            AlterColumn("dbo.products", "description", c => c.String());
            AlterColumn("dbo.cases", "DetailForm_actiondate", c => c.DateTime());
            AlterColumn("dbo.accounts", "name", c => c.String());
            CreateIndex("dbo.opportunities", "accountId");
            CreateIndex("dbo.opportunities", "stageId");
            AddForeignKey("dbo.opportunities", "stageId", "dbo.stages", "stageId");
            AddForeignKey("dbo.opportunities", "accountId", "dbo.accounts", "accountId");
        }
    }
}
