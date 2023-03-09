namespace ZooMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ImagePath");
        }
    }
}
