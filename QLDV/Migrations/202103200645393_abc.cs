namespace QLDV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.XepLoais", "xeploai", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.XepLoais", "xeploai", c => c.String(nullable: false));
        }
    }
}
