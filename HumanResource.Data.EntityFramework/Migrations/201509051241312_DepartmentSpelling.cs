namespace HumanResource.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentSpelling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "DepartmentName", c => c.String());
            DropColumn("dbo.Departments", "DepartmenName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "DepartmenName", c => c.String());
            DropColumn("dbo.Departments", "DepartmentName");
        }
    }
}
