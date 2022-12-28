using System.Linq;
using System.Text.Json;


namespace _1stProject
{
    public class Company
    {
        private Storage _baseData;
        UserNull _userNull = new UserNull();
        public string NameCompany { get; set; }
        public int IdCompany { get; set; }
        public string PathAdmins;
        public string PathEmployees;
        public string PathCalendar;
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
            PathAdmins = $@"../{nameCompany}/Admins.txt";
            PathEmployees = $@"../{nameCompany}/Employees.txt";
            PathCalendar = $@"../{nameCompany}/Calendar.txt";
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

        //public override bool Equals(object? obj)
        //{
        //    return obj is Company company &&
        //           _baseData == company._baseData &&
        //           _userNull == company._userNull &&
        //           NameCompany == company.NameCompany &&
        //           IdCompany == company.IdCompany &&
        //           PathAdmins == company.PathAdmins &&
        //           PathEmployees == company.PathEmployees &&
        //           PathCalendar == company.PathCalendar &&
        //           IdAdmins.SequenceEqual(company.IdAdmins) &&
        //           IdEmployees.SequenceEqual(company.IdEmployees) &&
        //           Calendar.SequenceEqual(company.Calendar);
        //}

        //public override int GetHashCode()
        //{
        //    HashCode hash = new HashCode();
        //    hash.Add(_baseData);
        //    hash.Add(_userNull);
        //    hash.Add(NameCompany);
        //    hash.Add(IdCompany);
        //    hash.Add(PathAdmins);
        //    hash.Add(PathEmployees);
        //    hash.Add(PathCalendar);
        //    hash.Add(IdAdmins);
        //    hash.Add(IdEmployees);
        //    hash.Add(Calendar);
        //    return hash.ToHashCode();
        //}

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
    }


}
