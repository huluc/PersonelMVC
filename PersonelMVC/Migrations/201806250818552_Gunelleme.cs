namespace PersonelMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gunelleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.People", "Gender", c => c.Boolean(nullable: false));
            AddColumn("dbo.People", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.People", "Married", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Married");
            DropColumn("dbo.People", "BirthDate");
            DropColumn("dbo.People", "Gender");
            DropColumn("dbo.People", "Salary");
        }
    }
}
