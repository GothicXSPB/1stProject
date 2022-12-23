using _1stProject.Options;
namespace _1stProject
{
    public class AdminClass: AbstractWorker
    {
        private Company _company;
        private Storage _storage;

        public AdminClass(int id, string name, string telephoneNumber, TimeTable typeOfTimeTable )
        {
            Id = id;
            Name = name;
            TelephoneNumber = telephoneNumber;
            TypeOfTimeTable = typeOfTimeTable;
            _company = new Company("1",1);
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
            _company.IdEmployees.Add(employee);
        }

        public void DeleteEmployee(int id)
        {
            _company.IdEmployees.RemoveAll(employee => employee.Id == id);
        }

        public void AddAdmin(AdminClass admin)
        {
            _company.IdAdmins.Add(admin);
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
    }
}
