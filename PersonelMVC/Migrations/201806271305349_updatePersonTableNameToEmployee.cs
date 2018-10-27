namespace PersonelMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePersonTableNameToEmployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Departman_Id", "dbo.Departmants");

            RenameTable(name: "dbo.People", newName: "Employees");
            DropIndex("dbo.Employees", new[] { "Departman_Id" });
            RenameColumn(table: "dbo.Employees", name: "Departman_Id", newName: "DepartmantId");
            AlterColumn("dbo.Employees", "DepartmantId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "DepartmantId");
            AddForeignKey("dbo.Employees", "DepartmantId", "dbo.Departmants", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartmantId", "dbo.Departmants");
            DropIndex("dbo.Employees", new[] { "DepartmantId" });
            AlterColumn("dbo.Employees", "DepartmantId", c => c.Int());
            RenameColumn(table: "dbo.Employees", name: "DepartmantId", newName: "Departman_Id");
            CreateIndex("dbo.Employees", "Departman_Id");
            AddForeignKey("dbo.People", "Departman_Id", "dbo.Departmants", "Id");
            RenameTable(name: "dbo.Employees", newName: "People");
        }
    }
}
