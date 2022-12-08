   using Newtonsoft.Json;
   
   namespace WestEdu;

   
   class accessJsonDb{


    public Enum authUser(string pswd){

        Enum result = ValidateUser(pswd);

        return result;
    }
    private static Enum ValidateUser(string pswd)
    {

       

        DotNetEnv.Env.Load();
        string? path = Environment.GetEnvironmentVariable("PATH");
        if (File.Exists(path))
        {
            dynamic? jsonFile = JsonConvert.DeserializeObject(File.ReadAllText(path));
            if (jsonFile != null)
            {

                var teacherpass = jsonFile["Teacher"]["password"];
                var administratorpass = jsonFile["Administrator"]["password"];
                var educationleadpass = jsonFile["Educationleader"]["password"];

                if (pswd == teacherpass.ToString())
                {
                    return AccessLevel.Teacher;
                }
                else if (pswd == administratorpass.ToString())
                {
                    return AccessLevel.Administrator;
                }
                else if (pswd == educationleadpass.ToString())
                {
                    return AccessLevel.EducationLeader;
                }
                else
                {
                    return AccessLevel.Student;
                }


            }
        }


        return AccessLevel.Student;

    }
       }