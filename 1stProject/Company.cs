using System.Text.Json;
using _1stProject.Options;

namespace _1stProject
{
<<<<<<< HEAD:1stProject/Database.cs
    public class Database
=======
    public class Company
>>>>>>> master:1stProject/Company.cs
    {
        public string _pathAdmins;
        public string _pathEmployees;
        public string _pathCalendar;
        public List<AdminClass> Admins { get; set; }
        public List<Employee> Employees { get; set; }
        public Dictionary<int, int[]> Calendar { get; set; }

<<<<<<< HEAD:1stProject/Database.cs
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

        public void DateToNumberDay(DateTime thisdate)
        {
            int numberperday = thisdate.DayOfYear;
=======
        public Company()
        {
            Admins = new List<AdminClass>();
            Employees = new List<Employee>();
            Calendar = new Dictionary<int, int[]>();
            _pathAdmins = @"../admins.txt";
            _pathEmployees = @"../employees.txt";
            _pathCalendar = @"../calendar.txt";
>>>>>>> master:1stProject/Company.cs
        }

        public void SaveAllAdmins()
        {
            using (StreamWriter sw = new StreamWriter(_pathAdmins))
            {
                string jsn = JsonSerializer.Serialize(Admins);
                sw.WriteLine(jsn);
            }

        }

        public void SaveAllEmployees()
        {
            using (StreamWriter sw = new StreamWriter(_pathEmployees))
            {
                string jsn = JsonSerializer.Serialize(Employees);
                sw.WriteLine(jsn);
            }

        }

        public void SaveAllCalendar()
        {
            using (StreamWriter sw = new StreamWriter(_pathCalendar))
            {
                string jsn = JsonSerializer.Serialize(Calendar);
                sw.WriteLine(jsn);
            }
        }

        public void LoadAllAdmins()
        {
            using (StreamReader sr = new StreamReader(_pathAdmins))
            {
                string jsn = sr.ReadLine()!;
                Admins = JsonSerializer.Deserialize<List<AdminClass>>(jsn)!;
            }
        }

        public void LoadAllEmployees()
        {
            using (StreamReader sr = new StreamReader(_pathEmployees))
            {
                string jsn = sr.ReadLine()!;
                Admins = JsonSerializer.Deserialize<List<AdminClass>>(jsn)!;
            }
        }

        public void LoadAllCalendar()
        {
            using (StreamReader sr = new StreamReader(_pathCalendar))
            {
                string jsn = sr.ReadLine()!;
                Calendar = JsonSerializer.Deserialize<Dictionary<int, int[]>>(jsn)!;
            }
        }
    }
}
