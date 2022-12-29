using _1stProject.Options;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _1stProject
{
    public class Employee: AbstractWorker
    {
        private string _name;
        private long _id;

        public Employee (Update update, string telephoneNumber, TimeTable typeOfTimeTable)
        {
            Id = GetEmployeeId(update);
            Name = GetEmployeeName(update);
            TelephoneNumber = telephoneNumber;
            TypeOfTimeTable = typeOfTimeTable;
        }

        public override void AddOvertimeHoursForApprove()
        {

        }

        public string GetEmployeeName(Update update)
        {
            _name = update.Message.Chat.Username;
            return _name;
        }     

        private long GetEmployeeId(Update update)
        {
            _id = update.Message.Chat.Id;
            return _id;
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

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, TypeOfTimeTable, TelephoneNumber);
        }

        public override void SwapShifts(Employee employee, Employee employee1, DateTime a, DateTime b)
        {

        }
    }
}
