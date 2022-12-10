using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1stProject
{
    public class AdminClass: AbstractWorker
    {
        public AdminClass(int id, string name, string telephoneNumber, string typeOfTimeTable)
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
