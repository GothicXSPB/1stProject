using System.Text.Json;

namespace _1stProject
{
    public static class Database
    {
        private static string _pathAdmins = @"../admins.txt";
        private static string _pathEmployees = @"../employees.txt";
        private static string _pathCalendar = @"../calendar.txt";

        public static List<AdminClass> Admins { get; set; } = new List<AdminClass>();

        public static List<Employee> Employees { get; set; } = new List<Employee>();

        static List<int> Calendar { get; set; }

        public static void SaveAllAdmins()
        {

            using (StreamWriter sw = new StreamWriter(_pathAdmins))
            {
                string jsn = JsonSerializer.Serialize(Admins);
                sw.WriteLine(jsn);
            }

        }

        public static void SaveAllEmployees()
        {

            using (StreamWriter sw = new StreamWriter(_pathEmployees))
            {
                string jsn = JsonSerializer.Serialize(Employees);
                sw.WriteLine(jsn);
            }

        }
        
        public static void SaveAllCalendar()
        {

            using (StreamWriter sw = new StreamWriter(_pathCalendar))
            {
                string jsn = JsonSerializer.Serialize(Calendar);
                sw.WriteLine(jsn);
            }

        }
    }
}
