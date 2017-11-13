namespace Learning_Path.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes set name='Pay as you go' where id = 1");
            Sql("UPDATE MembershipTypes set name='Monthly' where id = 2");
            Sql("UPDATE MembershipTypes set name='Quarterly' where id = 3");
            Sql("UPDATE MembershipTypes set name='Annual' where id = 4");

        }

        public override void Down()
        {
        }
    }
}
