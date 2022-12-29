using System.Text.Json;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using File = System.IO.File;

namespace _1stProject
{
    public class Company
    {
        private Storage _baseData;
        UserNull _userNull = new UserNull();

        public string NameCompany { get; set; }
        private string _companyName;
        private int _idCompany;
        public int IdCompany { get; set; }
        public string PathAdmins;
        public string PathEmployees;
        public string PathCalendar;
        public string PathAdminsDir;
        public string PathEmployeesDir;
        public string PathCalendarDir;
        public List<long> IdAdmins { get; set; }
        public List<long> IdEmployees { get; set; }
        public Dictionary<int, List<long>> Calendar { get; set; }

        public Company(Update update)
        {
            NameCompany = GetCompanyName(update);
            IdCompany = CreateUniqueCompanyId(update);
            IdAdmins = new List<long>();
            IdEmployees = new List<long>();
            Calendar = new Dictionary<int, List<long>>();
            PathAdminsDir = $@"../{NameCompany}";
            PathEmployeesDir = $@"../{NameCompany}";
            PathCalendarDir = $@"../{NameCompany}";
            PathAdmins = $@"../{NameCompany}/Admins.txt";
            PathEmployees = $@"../{NameCompany}/Employees.txt";
            PathCalendar = $@"../{NameCompany}/Calendar.txt";
        }

        public void CreateFiles ()
        {
            if (!File.Exists (PathAdmins))
            {
                SaveAllAdmins();
            }
            if (!File.Exists(PathEmployees))
            {
                SaveAllEmployees();
            }
            if (!File.Exists(PathCalendar))
            {
                SaveAllCalendar();
            }
        }

        public void CreateDirectory()
        {
            DirectoryInfo Admins = new DirectoryInfo(PathAdminsDir);
            DirectoryInfo Employees = new DirectoryInfo(PathEmployeesDir);
            DirectoryInfo Calendar = new DirectoryInfo(PathCalendarDir);
            if (!Admins.Exists)
            {
                Admins.Create();
            }
            if (!Employees.Exists)
            {
                Employees.Create();
            }
            if (!Calendar.Exists)
            {
                Calendar.Create();
            }
        }

        public string GetCompanyName(Update update)
        {
            _companyName = update.Message.Text;
            return _companyName;
        }

        private int CreateUniqueCompanyId(Update update)
        {
            Random random = new Random();
            int _idCompany = random.Next();
            while (CheckThatIdCompanyUnique(_idCompany) == false)
            {
                _idCompany = random.Next();
            }
            return _idCompany;
        }

        private bool CheckThatIdCompanyUnique(int _idCompany)
        {
            bool answer = false;
            //if (!_storage.AllCompany.ContainsKey(_idCompany))
            //{
            answer = true;
            //}
            return answer;
        }

        public void CreateTimetable(int a)
        {
            if (a % 4 == 0)
            {
                for (int i = 1; i <= 366; i++)
                {
                    Calendar.Add(i, new List<long>());
                }
            }
            else
            {
                for (int i = 1; i <= 365; i++)
                {
                    Calendar.Add(i, new List<long>());
                }
            }
        }

        public void ApproveTimeTableForEmployee(DateTime thisDate, Employee employee)
        {
            int firstDay = thisDate.DayOfYear;

            if (employee.TypeOfTimeTable == Options.TimeTable.Shift2x2)
            {
                if (firstDay == Calendar.Count - 1)
                {
                    Calendar[firstDay].Add(employee.Id);
                }
                else
                {
                    for (int i = firstDay + 1; i <= Calendar.Count - 1; i += 4)
                    {
                        Calendar[i].Add(employee.Id);
                        Calendar[i - 1].Add(employee.Id);
                    }

                }
            }

            if (employee.TypeOfTimeTable == Options.TimeTable.Shift1x3)
            {
                for (int i = firstDay; i <= Calendar.Count - 1; i += 4)
                {
                    Calendar[i].Add(employee.Id);
                }
            }

            if (employee.TypeOfTimeTable == Options.TimeTable.Shift5x2)
            {
                if (thisDate.DayOfWeek == DayOfWeek.Monday)
                {
                    for (int i = firstDay; i <= Calendar.Count - 1; i += 7)
                    {
                        Calendar[i].Add(employee.Id);
                        Calendar[i + 1].Add(employee.Id);
                        Calendar[i + 2].Add(employee.Id);
                        Calendar[i + 3].Add(employee.Id);
                        Calendar[i + 4].Add(employee.Id);
                    }
                }
                else
                {
                    Console.WriteLine("Work week must start on Monday");
                }
            }
        }

        public int DateToNumberDay(DateTime thisdate)
        {
            int numberperday = thisdate.DayOfYear;

            return numberperday;
        }

        public void SaveAllAdmins()
        {
            using (StreamWriter sw = new StreamWriter(PathAdmins))
            {

                string jsn = JsonSerializer.Serialize(IdAdmins);
                sw.WriteLine(jsn);
            }

        }

        public void SaveAllEmployees()
        {
            using (StreamWriter sw = new StreamWriter(PathEmployees))
            {

                string jsn = JsonSerializer.Serialize(IdEmployees);
                sw.WriteLine(jsn);
            }

        }

        public void SaveAllCalendar()
        {
            using (StreamWriter sw = new StreamWriter(PathCalendar))
            {
                string jsn = JsonSerializer.Serialize(Calendar);
                sw.WriteLine(jsn);
            }

        }

        public void LoadAllAdmins()
        {
            using (StreamReader sr = new StreamReader(PathAdmins))
            {
                string jsn = sr.ReadLine()!;
                IdAdmins = JsonSerializer.Deserialize<List<long>>(jsn)!;
            }

        }

        public void LoadAllEmployees()
        {
            using (StreamReader sr = new StreamReader(PathEmployees))
            {

                string jsn = sr.ReadLine()!;
                IdEmployees = JsonSerializer.Deserialize<List<long>>(jsn)!;
            }

        }

        public void LoadAllCalendar()
        {
            using (StreamReader sr = new StreamReader(PathCalendar))
            {
                string jsn = sr.ReadLine()!;
                Calendar = JsonSerializer.Deserialize<Dictionary<int, List<long>>>(jsn)!;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Company company &&
                   _baseData == company._baseData &&
                   _userNull == company._userNull &&
                   NameCompany == company.NameCompany &&
                   IdCompany == company.IdCompany &&
                   PathAdmins == company.PathAdmins &&
                   PathEmployees == company.PathEmployees &&
                   PathCalendar == company.PathCalendar &&
                   IdAdmins.SequenceEqual(company.IdAdmins) &&
                   IdEmployees.SequenceEqual(company.IdEmployees) &&
                   Calendar.SequenceEqual(company.Calendar);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(_baseData);
            hash.Add(_userNull);
            hash.Add(NameCompany);
            hash.Add(IdCompany);
            hash.Add(PathAdmins);
            hash.Add(PathEmployees);
            hash.Add(PathCalendar);
            hash.Add(IdAdmins);
            hash.Add(IdEmployees);
            hash.Add(Calendar);
            return hash.ToHashCode();
        }
    }
}
