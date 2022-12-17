using _1stProject.Options;
namespace _1stProject
{
    public class Employee: AbstractWorker
    {
        public Employee (int id, string name, string telephoneNumber, TimeTable typeOfTimeTable)
        {
            Id = id;
            Name = name;
            TelephoneNumber = telephoneNumber;
            TypeOfTimeTable = typeOfTimeTable;
        }

        public override void AddOvertimeHoursForApprove()
        {

        }

        public override void SwapShifts()
        {

        }
        public override bool Equals(object? obj)
        {
            return obj is Employee employee &&
                   base.Equals(obj) &&
                   Id == employee.Id &&
                   Name == employee.Name &&
                   TypeOfTimeTable == employee.TypeOfTimeTable &&
                   TelephoneNumber == employee.TelephoneNumber;
        }
    }
}
