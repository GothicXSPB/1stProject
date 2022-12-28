using _1stProject.Options;
namespace _1stProject
{
    public class AdminClass: AbstractWorker
    {
        private Company _company;
        private Storage _storage;

        public AdminClass(long id, string name, string telephoneNumber, TimeTable typeOfTimeTable, string nameCompany, int idCompany)
        {
            Id = id;
            Name = name;
            TelephoneNumber = telephoneNumber;
            TypeOfTimeTable = typeOfTimeTable;
            _company = new Company("1",1);/* - временные данные*/
            _storage = Storage.GetInstance();
        }

        public void ShowFullMonthlyTimetablee(DateTime thisdate)
        {
            _company.LoadAllCalendar();
            int a = thisdate.DayOfYear;
            int v = a + 30;
            for (int i = a; i <= v; i++)
            {
                Console.WriteLine(_company.Calendar[i]);
            }
        }

        public void ShowFullTimetableForTheDate(DateTime thisdate)
        {
            _company.LoadAllCalendar();
            int i = thisdate.DayOfYear;
            Console.WriteLine(_company.Calendar[i]);
        }

        public void ShowScheduleForThePeriod2(DateTime thisdate1, DateTime thisdate2)
        {
            //int a = thisdate1.DayOfYear;
            //int j = thisdate2.DayOfYear;
            //for (int i = thisdate1.DayOfYear; i <= j; i++)
            //{
            //    Console.WriteLine(_company.Calendar[i]);

            //}
            foreach (KeyValuePair<int, List<long>> pair in _company.Calendar)
            {
                Console.WriteLine("{0}, {1}",
                                    pair.Key,
                                    pair.Value);
                Console.WriteLine(_company.Calendar[i].);
            }

        }

        public override void AddOvertimeHoursForApprove()
        {

        }

        public void AddEmployeeForThisDate(Employee employee, DateTime a)
        {
            int AddEmployeeDay = a.DayOfYear;

            _company.Calendar[AddEmployeeDay].Add(employee.Id);
        }

        public void RemoveAnEmployeeFromThisDate(Employee employee, DateTime a)
        {
            int RemoveDay = a.DayOfYear;

            _company.Calendar[RemoveDay].Remove(employee.Id);
        }

        public override void SwapShifts(Employee employee1, Employee employee2, DateTime a, DateTime b)
        {
            int firstDay = a.DayOfYear;
            int secondDay = b.DayOfYear;
            
            if (_company.Calendar[firstDay].Contains(employee1.Id)&& _company.Calendar[secondDay].Contains(employee2.Id))
            {
            _company.Calendar[firstDay].Add(employee2.Id);
            _company.Calendar[secondDay].Add(employee1.Id);
            _company.Calendar[firstDay].Remove(employee1.Id);
            _company.Calendar[secondDay].Remove(employee2.Id);
            }
        }

        public void CreateNullTimeTable(int year)
        {
            _company.CreateTimetable(year);
        }

        public void AddEmployee(Employee employee)
        {
            _company.LoadAllEmployees();
            _company.IdEmployees.Add(employee.Id);
            _company.SaveAllEmployees();
        }

        public void DeleteEmployee(long id)
        {
            _company.LoadAllEmployees();
            _company.IdEmployees.RemoveAll(Id=> Id == id);
            _company.SaveAllAdmins();
        }

        public void AddAdmin(AdminClass admin)
        {
            _company.LoadAllEmployees();
            _company.IdAdmins.Add(admin.Id);
            _company.SaveAllAdmins();
        }

        public void ApproveTimeTableForEmployeeAndSave(int day, int month, int year, Employee employee, int firstDay)
        {
            _company.ApproveTimeTableForEmployee(day, month, year, employee, firstDay);
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
}
