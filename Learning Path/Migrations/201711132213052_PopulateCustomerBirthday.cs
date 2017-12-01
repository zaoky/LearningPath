namespace Learning_Path.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomerBirthday : DbMigration
    {
        public override void Up()
        {
            Sql($"UPDATE Customers set Birthday= CAST('1980-01-01' AS DATETIME) where id = 1");
        }

        public override void Down()
        {
        }
    }
}
