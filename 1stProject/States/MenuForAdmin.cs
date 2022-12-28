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

                            break;
                        case "AddEmployeeToCalendar":

                            break;
                        case "DeleteEmployee":

                            break;
                        case "AddAdmin":

                            break; 
                        case "DeleteEmployeeToCalendar":

                            break;
                        case "AddEmployeeToDays":

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
