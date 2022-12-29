using System.ComponentModel.DataAnnotations;
using _1stProject.Options;
namespace _1stProject;

using Microsoft.VisualBasic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

    public class AdminClass: AbstractWorker
    {
        private Company _company;
        private Storage _storage;

        public AdminClass(Update update, long id, string name, string telephoneNumber, TimeTable typeOfTimeTable, string nameCompany, int idCompany)
        {
            Id = id;
            Name = name;
            TelephoneNumber = telephoneNumber;
            TypeOfTimeTable = typeOfTimeTable;
            _company = new Company(update);
            _storage = Storage.GetInstance();
        }        

        public void ShowFullTimetableForTheDate(DateTime thisdate)
        {
            _company.LoadAllCalendar();
            int dayOfInterest = _company.DateToNumberDay(thisdate);
            List<long> value = null;

            _company.Calendar.TryGetValue(dayOfInterest, out value);
            PrintCalendar(value);

            void PrintCalendar(List<long> value)
            {
                foreach (int item in value)
                {
                    Console.Write($"Сотрудник(и):{item}");
                }
            }
        }

        public void ShowScheduleForThePeriod(DateTime thisdate1, DateTime thisdate2)
        {
            _company.LoadAllCalendar();
            int firstDay = _company.DateToNumberDay(thisdate1);
            int lastDay = _company.DateToNumberDay(thisdate2);
            List<long> value = null;                     

            for (int j = firstDay; j <= lastDay; j++)
            {
                _company.Calendar.TryGetValue(j, out value);
                DateTime D = new DateTime(2023, 1, 1);
                Console.WriteLine(D.AddDays(j).ToString("D"));
                PrintCalendar(value);
            }            

            void PrintCalendar(List<long> value)
            {
                foreach (int item in value)
                {
                    Console.Write($"Сотрудник(и):{item};  ");
                }
            }
        }

        public override void AddOvertimeHoursForApprove()
        {

        }

        public void AddEmployeeForThisDate(Employee employee, DateTime a)
        {
            _company.LoadAllCalendar();
            int AddEmployeeDay = _company.DateToNumberDay(a);

            _company.Calendar[AddEmployeeDay].Add(employee.Id);
            _company.SaveAllCalendar();
        }

        public void RemoveAnEmployeeFromThisDate(Employee employee, DateTime a)
        {
            _company.LoadAllCalendar();
            int RemoveDay = _company.DateToNumberDay(a);
            if (_company.Calendar[RemoveDay].Contains(employee.Id))
            {
                _company.Calendar[RemoveDay].Remove(employee.Id);
            }
            else
            {
                Console.WriteLine("В этот день данный сотрудник не работает");
            }
            _company.SaveAllCalendar();
        }

        public override void SwapShifts(Employee employee1, Employee employee2, DateTime a, DateTime b)
        {
            _company.LoadAllCalendar();
            int firstDay = _company.DateToNumberDay(a);
            int secondDay = _company.DateToNumberDay(b);

            if (_company.Calendar[firstDay].Contains(employee1.Id)&& _company.Calendar[secondDay].Contains(employee2.Id))
            {
            _company.Calendar[firstDay].Add(employee2.Id);
            _company.Calendar[secondDay].Add(employee1.Id);
            _company.Calendar[firstDay].Remove(employee1.Id);
            _company.Calendar[secondDay].Remove(employee2.Id);
            }
            _company.SaveAllCalendar();
        }

        public void CreateNullTimeTable(int year)
        {
            _company.CreateTimetable(year);
        }

        public void AddEmployee(long id)
        {
            _company.LoadAllEmployees();
            _company.IdEmployees.Add(id);
            _company.SaveAllEmployees();
        }

        public void DeleteEmployee(long id)
        {
            _company.LoadAllEmployees();
            _company.IdEmployees.RemoveAll(id => Id == id);
            _company.SaveAllEmployees();
        }

        public void AddAdmin(long idEmployee)
        {
            _company.LoadAllEmployees();
            _company.LoadAllAdmins();
            _company.IdAdmins.Add(idEmployee);
            DeleteEmployee(idEmployee);
            _company.SaveAllEmployees();
            _company.SaveAllAdmins();
        }

        public void ApproveTimeTableForEmployeeAndSave(DateTime thisdata, Employee employee)
        {
            _company.ApproveTimeTableForEmployee(thisdata, employee);
            _company.SaveAllCalendar();
        }        

        public void ApproveOvertime ()
        {

        }

        public void ApproveShiftsSwapping ()
        {

        }

        public void AddLatingToWork ()
        {

        }

        public void SendWorkingMessage ()
        {

        }

        public void ShowPersonalCardOfYourWorker ()
        {

        }

        public void ChangeInformationInPersonalCard ()
        {

        }

        public void GiveAdminAccess ()
        {

        }

        public void SendTimetableToAllStaff ()
        {

        }

        public void MarkWorkersAbsence ()
        {

        }

        public override bool Equals(object? obj)
        {
            return obj is AdminClass @class &&
                   base.Equals(obj) &&
                   Id == @class.Id &&
                   Name == @class.Name &&
                   TypeOfTimeTable == @class.TypeOfTimeTable &&
                   TelephoneNumber == @class.TelephoneNumber &&
                   EqualityComparer<Company>.Default.Equals(_company, @class._company);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, TypeOfTimeTable, TelephoneNumber, _company);
        }
    }

