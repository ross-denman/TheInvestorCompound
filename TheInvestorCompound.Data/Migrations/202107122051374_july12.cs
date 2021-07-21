namespace TheInvestorCompound.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class july12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Post", "PostedBy", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Post", "PostedBy", c => c.String(nullable: false));
        }
    }
}
