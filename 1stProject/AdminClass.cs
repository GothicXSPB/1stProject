using _1stProject.Options;
namespace _1stProject
{
    public class AdminClass: AbstractWorker
    {
        public AdminClass(int id, string name, string telephoneNumber, TimeTable typeOfTimeTable)
        {
            Id = id;
            Name = name;
            TelephoneNumber = telephoneNumber;
            TypeOfTimeTable = typeOfTimeTable;
        }

        public override void ChooseYourShiftsAndSendForApprove()
        {

        }

        public override void AddOvertimeHoursForApprove()
        {

        }

        public override void SwapShifts()
        {

        }

        public void AddEmployee()
        {

        }

        public void DeleteEmployee ()
        {

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
