﻿using System.Text.Json;
using _1stProject.Options;
namespace _1stProject
{
    public class Company
    {
        public string _pathAdmins;
        public string _pathEmployees;
        public string _pathCalendar;
        public List<AdminClass> Admins { get; set; }
        public List<Employee> Employees { get; set; }
        public Dictionary<int, int[]> Calendar { get; set; }

        public Company()
        {
            Admins = new List<AdminClass>();
            Employees = new List<Employee>();
            Calendar = new Dictionary<int, int[]>();
            _pathAdmins = @"../admins.txt";
            _pathEmployees = @"../employees.txt";
            _pathCalendar = @"../calendar.txt";
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
