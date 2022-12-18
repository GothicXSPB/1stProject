using System.Text.Json;
using _1stProject.Options;
namespace _1stProject
{
    public class Database
    {
        private static string _pathAdmins = @"../admins.txt";
        private static string _pathEmployees = @"../employees.txt";
        private static string _pathCalendar = @"../calendar.txt";

        public static List<AdminClass> Admins { get; set; } = new List<AdminClass>();

        public static List<Employee> Employees { get; set; } = new List<Employee>();

        static Dictionary<int, List<int>> Calendar { get; set; } = new Dictionary<int, List<int>>();

        List<int> SpisokSotrydnikovVSmene = new List<int>() { 0, 0, 0 };

        public void CreateTimetable(int a)
        {
            if (a % 4 == 0)
            {
                for (int i = 1; i <= 366; i++)
                {
                    Calendar.Add(i, SpisokSotrydnikovVSmene);
                }
            }
            else
            {
                for (int i = 1; i <= 365; i++)
                {
                    Calendar.Add(i, SpisokSotrydnikovVSmene);
                }
            }
        }

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

        public static void LoadAllAdmins()
        {
            using (StreamReader sr = new StreamReader(_pathAdmins))
            {
                string jsn = sr.ReadLine()!;
                Admins = JsonSerializer.Deserialize<List<AdminClass>>(jsn)!;
            }
        }

        public static void LoadAllEmployees()
        {
            using (StreamReader sr = new StreamReader(_pathEmployees))
            {
                string jsn = sr.ReadLine()!;
                Admins = JsonSerializer.Deserialize<List<AdminClass>>(jsn)!;
            }
        }

        public static void LoadAllCalendar()
        {
            using (StreamReader sr = new StreamReader(_pathCalendar))
            {
                string jsn = sr.ReadLine()!;
                Calendar = JsonSerializer.Deserialize<Dictionary<int, int[]>>(jsn)!;
            }
        }
    }
}
