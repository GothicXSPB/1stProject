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
            ModelOfMessage result = null;
            
            switch (update.Type)
            {
                case UpdateType.CallbackQuery:
                    switch (update.CallbackQuery.Data)
                    {
                        case "AddEmployee":
                            controller.State = new ChooseYourCompany();
                            result = MessagesFromTg.ShowMenuForAdmin;
                            break;
                        case "AddEmployeeToCalendar":
                            controller.State = new AddNewCompanyState();
                            result = MessagesFromTg.ShowMenuForRegularUser;
                            break;
                        case "DeleteEmployee":
                            controller.State = new ChooseYourCompany();
                            result = MessagesFromTg.ShowMenuForAdmin;
                            break;
                        case "AddAdmin":
                            controller.State = new AddNewCompanyState();
                            result = MessagesFromTg.ShowMenuForRegularUser;
                            break; 
                        case "DeleteEmployeeToCalendar":
                            controller.State = new ChooseYourCompany();
                            result = MessagesFromTg.ShowMenuForAdmin;
                            break;
                        case "AddEmployeeToDays":
                            controller.State = new AddNewCompanyState();
                            result = MessagesFromTg.ShowMenuForRegularUser;
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
