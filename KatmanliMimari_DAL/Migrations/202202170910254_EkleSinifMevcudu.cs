namespace KatmanliMimari_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EkleSinifMevcudu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sinifs", "SinifMevcudu", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sinifs", "SinifMevcudu");
        }
    }
}
