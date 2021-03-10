namespace QLDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addthem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiDoans",
                c => new
                    {
                        macd = c.String(nullable: false, maxLength: 128),
                        tencd = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.macd);
            
            CreateTable(
                "dbo.DoanViens",
                c => new
                    {
                        madv = c.String(nullable: false, maxLength: 128),
                        tendv = c.String(nullable: false, maxLength: 50),
                        ns = c.DateTime(nullable: false),
                        gioitinh = c.String(nullable: false),
                        quequan = c.String(nullable: false),
                        ngayvd = c.DateTime(nullable: false),
                        dantoc = c.String(nullable: false),
                        macd = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.madv)
                .ForeignKey("dbo.ChiDoans", t => t.macd)
                .Index(t => t.macd);
            
            CreateTable(
                "dbo.HoatDongs",
                c => new
                    {
                        mahd = c.Int(nullable: false, identity: true),
                        madv = c.String(nullable: false),
                        tenhd = c.String(nullable: false),
                        thoigiantc = c.DateTime(nullable: false),
                        ghichu = c.String(),
                    })
                .PrimaryKey(t => t.mahd);
            
            CreateTable(
                "dbo.KhenThuongs",
                c => new
                    {
                        makt = c.Int(nullable: false, identity: true),
                        tenkt = c.String(nullable: false),
                        madv = c.String(nullable: false, maxLength: 128),
                        mahd = c.Int(nullable: false),
                        thanhtich = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.makt)
                .ForeignKey("dbo.DoanViens", t => t.madv, cascadeDelete: true)
                .Index(t => t.madv);
            
            CreateTable(
                "dbo.XepLoais",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        madv = c.String(nullable: false, maxLength: 128),
                        namhoc = c.Int(nullable: false),
                        nhanxet = c.String(),
                        xeploai = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.DoanViens", t => t.madv, cascadeDelete: true)
                .Index(t => t.madv);
            
            CreateTable(
                "dbo.HoatDongDoanViens",
                c => new
                    {
                        HoatDong_mahd = c.Int(nullable: false),
                        DoanVien_madv = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.HoatDong_mahd, t.DoanVien_madv })
                .ForeignKey("dbo.HoatDongs", t => t.HoatDong_mahd, cascadeDelete: true)
                .ForeignKey("dbo.DoanViens", t => t.DoanVien_madv, cascadeDelete: true)
                .Index(t => t.HoatDong_mahd)
                .Index(t => t.DoanVien_madv);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.XepLoais", "madv", "dbo.DoanViens");
            DropForeignKey("dbo.KhenThuongs", "madv", "dbo.DoanViens");
            DropForeignKey("dbo.HoatDongDoanViens", "DoanVien_madv", "dbo.DoanViens");
            DropForeignKey("dbo.HoatDongDoanViens", "HoatDong_mahd", "dbo.HoatDongs");
            DropForeignKey("dbo.DoanViens", "macd", "dbo.ChiDoans");
            DropIndex("dbo.HoatDongDoanViens", new[] { "DoanVien_madv" });
            DropIndex("dbo.HoatDongDoanViens", new[] { "HoatDong_mahd" });
            DropIndex("dbo.XepLoais", new[] { "madv" });
            DropIndex("dbo.KhenThuongs", new[] { "madv" });
            DropIndex("dbo.DoanViens", new[] { "macd" });
            DropTable("dbo.HoatDongDoanViens");
            DropTable("dbo.XepLoais");
            DropTable("dbo.KhenThuongs");
            DropTable("dbo.HoatDongs");
            DropTable("dbo.DoanViens");
            DropTable("dbo.ChiDoans");
        }
    }
}
