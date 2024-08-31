namespace MVCProjectImplementationOfMasterDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllowanceCategories",
                c => new
                    {
                        AllowanceCategoryId = c.Int(nullable: false, identity: true),
                        AllowanceCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.AllowanceCategoryId);
            
            CreateTable(
                "dbo.AllowanceTypes",
                c => new
                    {
                        AllowanceTypeId = c.Int(nullable: false, identity: true),
                        AllowanceName = c.String(),
                        AllowanceCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AllowanceTypeId)
                .ForeignKey("dbo.AllowanceCategories", t => t.AllowanceCategoryId, cascadeDelete: true)
                .Index(t => t.AllowanceCategoryId);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        DetailsId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        AllowanceTypeId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetailsId)
                .ForeignKey("dbo.AllowanceTypes", t => t.AllowanceTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.AllowanceTypeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        PayDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Address = c.String(),
                        PhoneNo = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Details", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Details", "AllowanceTypeId", "dbo.AllowanceTypes");
            DropForeignKey("dbo.AllowanceTypes", "AllowanceCategoryId", "dbo.AllowanceCategories");
            DropIndex("dbo.Details", new[] { "AllowanceTypeId" });
            DropIndex("dbo.Details", new[] { "EmployeeId" });
            DropIndex("dbo.AllowanceTypes", new[] { "AllowanceCategoryId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Details");
            DropTable("dbo.AllowanceTypes");
            DropTable("dbo.AllowanceCategories");
        }
    }
}
