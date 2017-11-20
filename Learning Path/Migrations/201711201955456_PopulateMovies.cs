namespace Learning_Path.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies ( Name, GenreId, ReleaseDate, DateAdded,StockNum) VALUES ('Hangover',1,CAST('2009-10-06' AS DATETIME),CAST('2016-05-04' AS DATETIME),5)");
            Sql("INSERT INTO Movies ( Name, GenreId, ReleaseDate, DateAdded,StockNum) VALUES ('Die Hard',2,CAST('2009-12-11' AS DATETIME),CAST('2016-05-04' AS DATETIME),5)");
            Sql("INSERT INTO Movies ( Name, GenreId, ReleaseDate, DateAdded,StockNum) VALUES ('The Terminator',2,CAST('2010-07-15' AS DATETIME),CAST('2016-05-04' AS DATETIME),5)");
            Sql("INSERT INTO Movies ( Name, GenreId, ReleaseDate, DateAdded,StockNum) VALUES ('Toy Story',3,CAST('2014-10-06' AS DATETIME),CAST('2016-05-04' AS DATETIME),5)");
            Sql("INSERT INTO Movies ( Name, GenreId, ReleaseDate, DateAdded,StockNum) VALUES ('Titanic',4,CAST('2014-10-06' AS DATETIME),CAST('2016-05-04' AS DATETIME),5)");
        }

        public override void Down()
        {
        }
    }
}
