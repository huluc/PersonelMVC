namespace PersonelMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePersonAndDepartmentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departmants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
            DropTable("dbo.Departmants");
        }
    }
}
