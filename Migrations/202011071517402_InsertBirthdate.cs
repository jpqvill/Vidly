namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertBirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE CUSTOMERS SET BIRTHDATE = '2020-01-10' WHERE ID = 1");
            Sql("UPDATE CUSTOMERS SET BIRTHDATE = '1997-04-30' WHERE ID = 2");
        }
        
        public override void Down()
        {
        }
    }
}
