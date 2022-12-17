using _1stProject.Options;
namespace _1stProject
{
    public abstract class AbstractWorker
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public TimeTable TypeOfTimeTable { get; set; }
        public string TelephoneNumber { get; protected set; }

        public abstract void AddOvertimeHoursForApprove();

        public abstract void SwapShifts();

        public void ShowYourOwnMonthlyTimetable()
        {

        }

        public void ShowFullMonthlyTimetablee()
        {

        }

        public void ShowFullTimetableForTheDate()
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
    }
}
