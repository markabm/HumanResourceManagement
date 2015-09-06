namespace HumanResource.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentPosition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmenName = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PositionName = c.String(),
                        PositionNoEmployee = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.PositionId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.Department_DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Positions", new[] { "Department_DepartmentId" });
            DropTable("dbo.Positions");
            DropTable("dbo.Departments");
        }
    }
}
