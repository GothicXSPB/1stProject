using System.Text.Json;

namespace _1stProject
{
    public abstract class AbstractWorker
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string TelephoneNumber { get; protected set; }
        public string TypeOfTimeTable { get; protected set; }
        private string _path = @".../calendar.txt";
    
        public abstract void ChooseYourShiftsAndSendForApprove();

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

        public void SaveAll()
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                string jsn = JsonSerializer.Serialize(Timetable);
                sw.WriteLine(jsn);
            }

        }
    }
}
