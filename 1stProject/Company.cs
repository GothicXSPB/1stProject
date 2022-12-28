using System.Linq;
using System.Text.Json;


namespace _1stProject
{
    public class Company
    {
        private Storage _storage;
        UserNull _userNull = new UserNull();
        public string NameCompany { get; set; }
        public int IdCompany { get; set; }
        public string _pathAdmins;
        public string _pathEmployees;
        public string _pathCalendar;
        public List<long> IdAdmins { get; set; }
        public List<long> IdEmployees { get; set; }
        public Dictionary<int, List<long>> Calendar { get; set; }

        public Company(string nameCompany, int idCompany)
        {
            NameCompany = nameCompany;
            IdCompany = idCompany;
            IdAdmins = new List<long>();
            IdEmployees = new List<long>();
            Calendar = new Dictionary<int, List<long>>();
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
                    for (int i = firstDay + 4; i <= Calendar.Count - 1; i += 7)
                    {
                        Calendar[i].Add(employee.Id);
                        Calendar[i - 1].Add(employee.Id);
                        Calendar[i - 2].Add(employee.Id);
                        Calendar[i - 3].Add(employee.Id);
                        Calendar[i - 4].Add(employee.Id);
                    }
                }
                else
                {
                    Console.WriteLine("Work week must start on Monday");
                }
            }
        }

        public void DateToNumberDay(DateTime thisdate)
        {
            int numberperday = thisdate.DayOfYear;
        }

        //public string IsTheUserExistAsAdminOrRegular() 
        //{
        //    SaveAllAdmins.ContainsKey(CurrentCmId);
        //    SaveAllEmployees.ContainsKey(CurrentCmId);
        //    return;
        //}
        //public int FindAllUsersCompanies( _userNull.  )
        //{
        //    return;
        //}

        public void SaveAllAdmins()
        {
            using (StreamWriter sw = new StreamWriter(_pathAdmins))
            {
                string jsn = JsonSerializer.Serialize(IdAdmins);
                sw.WriteLine(jsn);
            }
        }

        public void SaveAllEmployees()
        {
            using (StreamWriter sw = new StreamWriter(_pathEmployees))
            {
                string jsn = JsonSerializer.Serialize(IdEmployees);
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
                IdAdmins = JsonSerializer.Deserialize<List<long>>(jsn)!;
            }
        }

        public void LoadAllEmployees()
        {
            using (StreamReader sr = new StreamReader(_pathEmployees))
            {
                string jsn = sr.ReadLine()!;
                IdEmployees = JsonSerializer.Deserialize<List<long>>(jsn)!;
            }
        }

        public void LoadAllCalendar()
        {
            using (StreamReader sr = new StreamReader(_pathCalendar))
            {
                string jsn = sr.ReadLine()!;
                Calendar = JsonSerializer.Deserialize<Dictionary<int, List<long>>>(jsn)!;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Company company &&
                   _storage == company._storage &&
                   NameCompany == company.NameCompany &&
                   IdCompany == company.IdCompany &&
                   _pathAdmins == company._pathAdmins &&
                   _pathEmployees == company._pathEmployees &&
                   _pathCalendar == company._pathCalendar &&
                   IdAdmins.SequenceEqual(company.IdAdmins) &&
                   IdEmployees.SequenceEqual(company.IdEmployees) &&
                   Calendar.SequenceEqual(company.Calendar);
        }
    }
}
