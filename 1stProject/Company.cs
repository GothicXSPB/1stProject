﻿using System.Text.Json;

namespace _1stProject
{
    public class Company
    {
        private Storage _storage;
        public string NameCompany { get; set; }
        public int IdCompany { get; set; }
        public string _pathAdmins;
        public string _pathEmployees;
        public string _pathCalendar;
        public List<long> IdAdmins { get; set; }
        public List<long> IdEmployees { get; set; }
        public Dictionary<int, List<int>> Calendar { get; set; }

        public Company(string nameCompany, int idCompany)
        {
            NameCompany = nameCompany;
            IdCompany = idCompany;
            IdAdmins = new List<long>();
            IdEmployees = new List<long>();
            Calendar = new Dictionary<int, List<int>>();
            _pathAdmins = $@"../{nameCompany}/Admins.txt";
            _pathEmployees = $@"../{nameCompany}/Employees.txt";
            _pathCalendar = $@"../{nameCompany}/Calendar.txt";
        }

        public void CreateTimetable(int a)
        {
            if (a % 4 == 0)
            {
                for (int i = 1; i <= 366; i++)
                {
                    Calendar.Add(i, new List<int>());
                }
            }
            else
            {
                for (int i = 1; i <= 365; i++)
                {
                    Calendar.Add(i, new List<int>());
                }
            }
        }

        public void ApproveTimeTableForEmployee(int day, int month, int year, Employee employee, int firstDay)
        {
            DateTime dt = new DateTime(year, month, day);

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
                if (dt.DayOfWeek == DayOfWeek.Monday)
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
                IdAdmins = JsonSerializer.Deserialize<List<int>>(jsn)!;
            }
        }

        public void LoadAllEmployees()
        {
            using (StreamReader sr = new StreamReader(_pathEmployees))
            {
                string jsn = sr.ReadLine()!;
                IdAdmins = JsonSerializer.Deserialize<List<int>>(jsn)!;
            }
        }

        public void LoadAllCalendar()
        {
            using (StreamReader sr = new StreamReader(_pathCalendar))
            {
                string jsn = sr.ReadLine()!;
                Calendar = JsonSerializer.Deserialize<Dictionary<int, List<int>>>(jsn)!;
            }
        }
    }
}
