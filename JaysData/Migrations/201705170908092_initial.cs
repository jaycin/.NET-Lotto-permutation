namespace JaysData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        EntryId = c.Long(nullable: false, identity: true),
                        N1_ID = c.Int(),
                        N2_ID = c.Int(),
                        N3_ID = c.Int(),
                        N4_ID = c.Int(),
                        N5_ID = c.Int(),
                        N6_ID = c.Int(),
                    })
                .PrimaryKey(t => t.EntryId)
                .ForeignKey("dbo.Numbers", t => t.N1_ID)
                .ForeignKey("dbo.Numbers", t => t.N2_ID)
                .ForeignKey("dbo.Numbers", t => t.N3_ID)
                .ForeignKey("dbo.Numbers", t => t.N4_ID)
                .ForeignKey("dbo.Numbers", t => t.N5_ID)
                .ForeignKey("dbo.Numbers", t => t.N6_ID)
                .Index(t => t.N1_ID)
                .Index(t => t.N2_ID)
                .Index(t => t.N3_ID)
                .Index(t => t.N4_ID)
                .Index(t => t.N5_ID)
                .Index(t => t.N6_ID);
            
            CreateTable(
                "dbo.Numbers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entries", "N6_ID", "dbo.Numbers");
            DropForeignKey("dbo.Entries", "N5_ID", "dbo.Numbers");
            DropForeignKey("dbo.Entries", "N4_ID", "dbo.Numbers");
            DropForeignKey("dbo.Entries", "N3_ID", "dbo.Numbers");
            DropForeignKey("dbo.Entries", "N2_ID", "dbo.Numbers");
            DropForeignKey("dbo.Entries", "N1_ID", "dbo.Numbers");
            DropIndex("dbo.Entries", new[] { "N6_ID" });
            DropIndex("dbo.Entries", new[] { "N5_ID" });
            DropIndex("dbo.Entries", new[] { "N4_ID" });
            DropIndex("dbo.Entries", new[] { "N3_ID" });
            DropIndex("dbo.Entries", new[] { "N2_ID" });
            DropIndex("dbo.Entries", new[] { "N1_ID" });
            DropTable("dbo.Numbers");
            DropTable("dbo.Entries");
        }
    }
}
