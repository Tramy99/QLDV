namespace QLDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HoatDongs", "KhenThuong_makt", c => c.Int());
            CreateIndex("dbo.HoatDongs", "KhenThuong_makt");
            AddForeignKey("dbo.HoatDongs", "KhenThuong_makt", "dbo.KhenThuongs", "makt");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HoatDongs", "KhenThuong_makt", "dbo.KhenThuongs");
            DropIndex("dbo.HoatDongs", new[] { "KhenThuong_makt" });
            DropColumn("dbo.HoatDongs", "KhenThuong_makt");
        }
    }
}
