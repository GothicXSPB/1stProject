using _1stProject.Options;
namespace _1stProject
{
    public class AdminClass: AbstractWorker
    {
        private Company _company;
        private Storage _storage;

        public AdminClass(long id, string name, string telephoneNumber, TimeTable typeOfTimeTable)
        {
            Id = id;
            Name = name;
            TelephoneNumber = telephoneNumber;
            TypeOfTimeTable = typeOfTimeTable;
            _company = new Company("1",1);/* - временные данные*/
            _storage = Storage.GetInstance();
        }

        public override void AddOvertimeHoursForApprove()
        {

        }

        public override void SwapShifts()
        {

        }

        public void CreateNullTimeTable(int year)
        {
            _company.CreateTimetable(year);
        }

        public void AddEmployee(Employee employee)
        {

            _company.IdEmployees.Add(employee.Id);
            _company.SaveAllEmployees();
        }

        public void DeleteEmployee(long id)
        {

            _company.IdEmployees.RemoveAll(Id=> Id == id);
            _company.SaveAllAdmins();
        }

        public void AddAdmin(AdminClass admin)
        {

            _company.IdAdmins.Add(admin.Id);
            _company.SaveAllAdmins();
        }

        public void ApproveTimeTableForEmployee ()
        {

            
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
