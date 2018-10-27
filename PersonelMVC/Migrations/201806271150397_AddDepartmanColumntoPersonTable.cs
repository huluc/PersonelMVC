namespace PersonelMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmanColumntoPersonTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Departman_Id", c => c.Int());
            CreateIndex("dbo.People", "Departman_Id");
            AddForeignKey("dbo.People", "Departman_Id", "dbo.Departmants", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Departman_Id", "dbo.Departmants");
            DropIndex("dbo.People", new[] { "Departman_Id" });
            DropColumn("dbo.People", "Departman_Id");
        }
    }
}
