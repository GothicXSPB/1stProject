namespace _1stProject
{
    public abstract class AbstractWorker
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string TelephoneNumber { get; protected set; }
        public string TypeOfTimeTable { get; protected set; }
        public abstract void ChooseYourShiftsAndSendForApprove();
        public abstract void ShowYourOwnMonthlyTimetable();
        public abstract void ShowFullMonthlyTimetablee();
        public abstract void ShowFullTimetableForTheDate();
        public abstract void AddOvertimeHoursForApprove();
        public abstract void SwapShifts();
        public abstract void ShowOwnPersonalCard();
        public abstract void ShowHoursWorkedSinceBegOfMonth();
        public abstract void ShowHoursOverworkedSinceBegOfMonth();
    }
}
