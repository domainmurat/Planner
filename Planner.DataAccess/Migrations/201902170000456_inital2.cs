namespace Planner.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assignments", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Assignments", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Assignments", "DeletedDate", c => c.DateTime());
            AlterColumn("dbo.Assignments", "CreatedUser", c => c.Int());
            AlterColumn("dbo.Assignments", "UpdatedUser", c => c.Int());
            AlterColumn("dbo.Assignments", "DeletedUser", c => c.Int());
            AlterColumn("dbo.Subjects", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Subjects", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Subjects", "DeletedDate", c => c.DateTime());
            AlterColumn("dbo.Subjects", "CreatedUser", c => c.Int());
            AlterColumn("dbo.Subjects", "UpdatedUser", c => c.Int());
            AlterColumn("dbo.Subjects", "DeletedUser", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "DeletedUser", c => c.Int(nullable: false));
            AlterColumn("dbo.Subjects", "UpdatedUser", c => c.Int(nullable: false));
            AlterColumn("dbo.Subjects", "CreatedUser", c => c.Int(nullable: false));
            AlterColumn("dbo.Subjects", "DeletedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Subjects", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Subjects", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Assignments", "DeletedUser", c => c.Int(nullable: false));
            AlterColumn("dbo.Assignments", "UpdatedUser", c => c.Int(nullable: false));
            AlterColumn("dbo.Assignments", "CreatedUser", c => c.Int(nullable: false));
            AlterColumn("dbo.Assignments", "DeletedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Assignments", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Assignments", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
