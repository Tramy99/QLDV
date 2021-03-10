namespace QLDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsuabai : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoatDongs", "KhenThuong_makt", "dbo.KhenThuongs");
            DropIndex("dbo.HoatDongs", new[] { "KhenThuong_makt" });
            CreateTable(
                "dbo.KhenThuongHoatDongs",
                c => new
                    {
                        KhenThuong_makt = c.Int(nullable: false),
                        HoatDong_mahd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.KhenThuong_makt, t.HoatDong_mahd })
                .ForeignKey("dbo.KhenThuongs", t => t.KhenThuong_makt, cascadeDelete: true)
                .ForeignKey("dbo.HoatDongs", t => t.HoatDong_mahd, cascadeDelete: true)
                .Index(t => t.KhenThuong_makt)
                .Index(t => t.HoatDong_mahd);
            
            DropColumn("dbo.HoatDongs", "KhenThuong_makt");
            DropColumn("dbo.KhenThuongs", "mahd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KhenThuongs", "mahd", c => c.Int(nullable: false));
            AddColumn("dbo.HoatDongs", "KhenThuong_makt", c => c.Int());
            DropForeignKey("dbo.KhenThuongHoatDongs", "HoatDong_mahd", "dbo.HoatDongs");
            DropForeignKey("dbo.KhenThuongHoatDongs", "KhenThuong_makt", "dbo.KhenThuongs");
            DropIndex("dbo.KhenThuongHoatDongs", new[] { "HoatDong_mahd" });
            DropIndex("dbo.KhenThuongHoatDongs", new[] { "KhenThuong_makt" });
            DropTable("dbo.KhenThuongHoatDongs");
            CreateIndex("dbo.HoatDongs", "KhenThuong_makt");
            AddForeignKey("dbo.HoatDongs", "KhenThuong_makt", "dbo.KhenThuongs", "makt");
        }
    }
}
