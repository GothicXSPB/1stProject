using System.Text.Json;
using _1stProject.Options;

namespace _1stProject
{
    public class Company
    {
        public string NameCompany { get; set; }
        public int IDCompany { get; set; }
        public string _pathAdmins;
        public string _pathEmployees;
        public string _pathCalendar;
        public List<int> Admins { get; set; }
        public List<int> Employees { get; set; }
        public Dictionary<int, List<int>> Calendar { get; set; }
        List<int> SpisokSotrydnikovVSmene = new List<int>();

        public Company(string nameCompany, int idCompany)
        {
            NameCompany = nameCompany;
            IDCompany = idCompany;
            Admins = new List<AdminClass>();
            Employees = new List<Employee>();
            Calendar = new Dictionary<int, List<int>>();
            _pathAdmins = $@"../{nameCompany}Admins.txt";
            _pathEmployees = $@"../{nameCompany}Employees.txt";
            _pathCalendar = $@"../{nameCompany}Calendar.txt";
        }

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
                Calendar = JsonSerializer.Deserialize< Dictionary<int, List<int>>> (jsn)!;
            }
        }
    }
}
