﻿using _1stProject.Options;
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

        public override void AddOvertimeHoursForApprove()
        {

        }

        public override void SwapShifts()
        {

        }

        public void AddEmployee(Employee employee)
        {
            Database.Employees.Add(employee);
        }

        public void DeleteEmployee(int id)
        {
            Database.Employees.RemoveAll(employee => employee.Id == id);
        }

        public void AddAdmin(int idEmployee)
        {
            foreach (var objAdmin in Database.Employees)
            {
                if (objAdmin.Id == idEmployee)
                {
                    var admin = new AdminClass(objAdmin.Id, objAdmin.Name, objAdmin.TelephoneNumber, objAdmin.TypeOfTimeTable);
                    Database.Admins.Add(admin);
                }
            }
            DeleteEmployee(idEmployee);
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
