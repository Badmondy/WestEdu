namespace WestEdu;
using Npgsql;

class psqlDB
{


    
    private static string FetchConnectionString()
    {

        // Hämtar lokal .env fil
        DotNetEnv.Env.Load();
        var dbhost = Environment.GetEnvironmentVariable("HOST");
        var dbuser = Environment.GetEnvironmentVariable("USERNAME");
        var dbpswd = Environment.GetEnvironmentVariable("PASSWORD");
        var db = Environment.GetEnvironmentVariable("DATABASE");

        return $"Host={dbhost};Username={dbuser};Password={dbpswd};Database={db}";
    }

   public List<Courses> DisplayAllCourses(){
    
    return ListAllCourses();
   }

    private static List<Courses> ListAllCourses()
    {

        List<Courses> _allCourses = new List<Courses>();
        var cs = FetchConnectionString();

        using var con = new NpgsqlConnection(cs);

        con.Open();


        string sqlsearch = "SELECT * FROM courses";

        using var cmd = new NpgsqlCommand(sqlsearch, con);

        using NpgsqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {

            var stringToGuid = rdr.GetString(1);
         
            var guid = Guid.Parse(stringToGuid);


            _allCourses.Add(new Courses { CourseId = guid, Name = rdr.GetString(2), StartDate = rdr.GetDateTime(3), EndDate = rdr.GetDateTime(4), CourseNumber = rdr.GetString(5),Applied = rdr.GetString(6) });


        }

        return _allCourses;
    }



    public void ConnectToDataBase(string sqlCommand)
    {

        var cs = FetchConnectionString();

        using var con = new NpgsqlConnection(cs);
        con.Open();

        try
        {
            using var cmd = new NpgsqlCommand(sqlCommand, con);
            cmd.ExecuteScalar();
        }
        catch (Exception DuplicateKey)
        {
            string stored = DuplicateKey.Message;

            System.Console.WriteLine("Tyvärr finns redan den personen i vårat system.");
        }
    }
}