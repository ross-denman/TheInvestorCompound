namespace TheInvestorCompound.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21July1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentedBy = c.Guid(nullable: false),
                        PostId = c.Int(nullable: false),
                        CommentContent = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropTable("dbo.Comment");
        }
    }
}
