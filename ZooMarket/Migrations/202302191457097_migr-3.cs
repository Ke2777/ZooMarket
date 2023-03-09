namespace ZooMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Discount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Discount");
        }
    }
}
