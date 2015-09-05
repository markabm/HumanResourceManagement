namespace HumanResource.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentForeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Positions", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Positions", new[] { "Department_DepartmentId" });
            RenameColumn(table: "dbo.Positions", name: "Department_DepartmentId", newName: "DepartmentId");
            AlterColumn("dbo.Positions", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Positions", "DepartmentId");
            AddForeignKey("dbo.Positions", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Positions", new[] { "DepartmentId" });
            AlterColumn("dbo.Positions", "DepartmentId", c => c.Int());
            RenameColumn(table: "dbo.Positions", name: "DepartmentId", newName: "Department_DepartmentId");
            CreateIndex("dbo.Positions", "Department_DepartmentId");
            AddForeignKey("dbo.Positions", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
        }
    }
}
