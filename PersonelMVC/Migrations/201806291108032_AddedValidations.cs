namespace PersonelMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departmants", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Surname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Surname", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
            AlterColumn("dbo.Departmants", "Name", c => c.String());
        }
    }
}
