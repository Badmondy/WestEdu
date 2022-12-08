using Npgsql;
using Newtonsoft.Json;
namespace WestEdu;
class Program
{
    static void Main(string[] args)
    {


        Console.WriteLine("Välkommen till WestCoast Education");
        Console.Write("Användarnamn: ");
        Console.ReadLine();
        Console.Write("Lösenord: ");
        string? pswd = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(pswd))
        {

            pswd = Console.ReadLine();
        }


        var validator = new accessJsonDb();

        Enum authorhizeUser = validator.authUser(pswd);







        switch (authorhizeUser)
        {

            case AccessLevel.Teacher:
                Console.WriteLine("Du loggas nu in i Lärar portalen.");
                // Implementera logik för lärare!
                break;
            case AccessLevel.Administrator:
                Console.WriteLine("Du loggas nu in i Admin portalen.");
                // Implementera logik för admin!
                break;
            case AccessLevel.EducationLeader:
                Console.WriteLine("Du loggas nu in i Utbildnings portalen.");
                // Implementera logik för Utbildnings-ledare!
                break;
            case AccessLevel.Student:
                Console.WriteLine("Välkommen Student");
                //Implementera logik för stuent!


                //Lista alla kurser
                var fetchCoruses = new psqlDB();

                var CourseList = fetchCoruses.DisplayAllCourses();

                foreach (var item in CourseList)
                {

                    Console.WriteLine(@"
           Kursid: {0}
           Kursnamn: {1}
           Startdatum: {2}
           Slutdatum: {3}
           Kursnummer: {4}
           Anmälda: {5}",
                    item.CourseId, item.Name, item.StartDate.ToString("yyyy/MM/dd"), 
                    item.EndDate.ToString("yyyy/MM/dd"), item.CourseNumber, item.Applied);
                }



                // Anmäl till kurs
                System.Console.WriteLine("Fyll i ditt namn ?(förnamn efternamn) om du vill anmäla dig till kursen");
                string? FullName = Console.ReadLine();
                System.Console.WriteLine("Fyll i den kurs du vill anmäla dig till");
                string? kurs = Console.ReadLine();
                
                fetchCoruses.ConnectToDataBase(@$"UPDATE courses
                SET antagna = antagna || '{FullName}'
                WHERE coursenumber = '{kurs+","}';");
                break;
        }
    }











}
