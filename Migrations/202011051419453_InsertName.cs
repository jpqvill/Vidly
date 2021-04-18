namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MEMBERSHIPTYPES SET DISCOUNTNAME = 'PAY AS YOU GO' WHERE ID = 1");
            Sql("UPDATE MEMBERSHIPTYPES SET DISCOUNTNAME = 'MONTHLY' WHERE ID = 2");
            Sql("UPDATE MEMBERSHIPTYPES SET DISCOUNTNAME = 'QUARTERLY' WHERE ID = 3");
            Sql("UPDATE MEMBERSHIPTYPES SET DISCOUNTNAME = 'YEARLY' WHERE ID = 4");
        }
        
        public override void Down()
        {
        }
    }
}
