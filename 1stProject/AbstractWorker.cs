using _1stProject.Options;
namespace _1stProject
{
    public abstract class AbstractWorker
    {
        private Company _company;

        public long Id { get; protected set; }
        public string Name { get; protected set; }
        public TimeTable TypeOfTimeTable { get; set; }
        public string TelephoneNumber { get; protected set; }

        public abstract void AddOvertimeHoursForApprove();

        public abstract void SwapShifts(Employee employee, Employee employee1, DateTime a, DateTime b);

        public void ShowYourOwnMonthlyTimetable(DateTime thisdate)
        {

        }        

        public void ShowOwnPersonalCard()
        {

        }

        public void ShowHoursWorkedSinceBegOfMonth()
        {

        }

        public void ShowHoursOverworkedSinceBegOfMonth()
        {

        }

        public override bool Equals(object? obj)
        {
            return obj is AbstractWorker worker &&
                   Id == worker.Id &&
                   Name == worker.Name &&
                   TypeOfTimeTable == worker.TypeOfTimeTable &&
                   TelephoneNumber == worker.TelephoneNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, TypeOfTimeTable, TelephoneNumber);
        }
    }
}
