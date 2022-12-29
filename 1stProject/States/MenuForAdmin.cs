using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using _1stProject.TgButtonsLogic;

namespace _1stProject.States
{
    public class MenuForAdmin : IState
    {
        //предложить меню с функционалом админа
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage result = MessagesFromTg.ShowMenuForAdmin;

            switch (update.Type)
            {
                case UpdateType.CallbackQuery:
                    switch (update.CallbackQuery.Data)
                    {
                        case "AddEmployee":
                            controller.State = new AddEmployeeState();
                            result = MessagesFromTg.ShowAddEmployee;
                            break;
                        case "AddEmployeeToCalendar":
                            controller.State = new AddEmployeeToCalendarState();
                            result = MessagesFromTg.ShowAddEmployeeToCalendar;
                            break;
                        case "DeleteEmployee":
                            controller.State = new DeleteEmployeeState();
                            result = MessagesFromTg.ShowDeleteEmployee;
                            break;
                        case "AddAdmin":
                            controller.State = new AddAdminState();
                            result = MessagesFromTg.ShowAddAdmin;
                            break; 
                        case "DeleteEmployeeToCalendar":
                            controller.State = new DeleteEmployeeToCalendarState();
                            result = MessagesFromTg.ShowDeleteEmployeeToCalendar;
                            break;
                        case "AddEmployeeToDays":
                            controller.State = new AddEmployeeToDaysState();
                            result = MessagesFromTg.ShowAddEmployeeToDays;
                            break;
                        case "Start":
                            controller.State = new Start();
                            result = MessagesFromTg.ShowStartMenu;
                            break;
                    }
                    break;
            }
            return result;
        }
    }
}
