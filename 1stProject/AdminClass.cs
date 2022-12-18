using System.Xml.Linq;
using _1stProject.Options;
namespace _1stProject
{
    public class AdminClass: AbstractWorker
    {
        private Company _company;

        public AdminClass(int id, string name, string telephoneNumber, TimeTable typeOfTimeTable)
        {
            Id = id;
            Name = name;
            TelephoneNumber = telephoneNumber;
            TypeOfTimeTable = typeOfTimeTable;
            _company = new Company();
        }

        public override void AddOvertimeHoursForApprove()
        {

        }

        public override void SwapShifts()
        {

        }

        public List<Employee> AddEmployee(Employee employee)
        {
            _company.Employees.Add(employee);
            _company.SaveAllEmployees();

            return _company.Employees;
        }

        public List<Employee> DeleteEmployee(int id)
        {
            _company.Employees.RemoveAll(employee => employee.Id == id);
            _company.SaveAllEmployees();

            return _company.Employees;
        }

        public List<AdminClass> AddAdmin(int idEmployee)
        {
            foreach (var objAdmin in _company.Employees)
            {
                if (objAdmin.Id == idEmployee)
                {
                    var admin = new AdminClass(objAdmin.Id, objAdmin.Name, objAdmin.TelephoneNumber, objAdmin.TypeOfTimeTable);
                    _company.Admins.Add(admin);
                }
            }
            DeleteEmployee(idEmployee);
            _company.SaveAllEmployees();
            _company.SaveAllAdmins();

            return _company.Admins;
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
