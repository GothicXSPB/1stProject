namespace _1stProject
{
    public class Employee: AbstractWorker
    {
        public Employee (int id, string name, string telephoneNumber, string typeOfTimeTable)
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
    }
}
