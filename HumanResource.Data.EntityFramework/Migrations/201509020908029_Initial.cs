namespace HumanResource.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Roles", "ModifiedBy", c => c.String());
            AlterColumn("dbo.Roles", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Roles", "CreatedBy", c => c.String());
            DropColumn("dbo.Roles", "UpdatedDate");
            DropColumn("dbo.Roles", "UpdatedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "UpdatedBy", c => c.String(maxLength: 100));
            AddColumn("dbo.Roles", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Roles", "CreatedBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.Roles", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Roles", "ModifiedBy");
            DropColumn("dbo.Roles", "ModifiedDate");
        }
    }
}
