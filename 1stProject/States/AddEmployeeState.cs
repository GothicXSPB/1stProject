using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1stProject.TgButtonsLogic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _1stProject.States
{
    public class AddEmployeeState : IState
    {

        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            AdminClass admin = new AdminClass(update);
            Company _company = new Company(update);
            ModelOfMessage result = MessagesFromTg.ShowAddEmployee;

            switch (update.Type)
            {
                case UpdateType.CallbackQuery:
                    switch (update.CallbackQuery.Data)
                    {
                        case "Back":
                            controller.State = new MenuForAdmin();
                            result = MessagesFromTg.ShowMenuForAdmin;
                            break;
                    }
                    break;
                case UpdateType.Message:
                    admin.AddEmployee(Convert.ToInt64(update.Message.Text));
                    controller.State = new MenuForAdmin();
                    result = MessagesFromTg.ShowMenuForAdmin;
                    break;
            }
            return result;
        }
    }
}
