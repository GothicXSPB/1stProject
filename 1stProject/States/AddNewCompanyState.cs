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
    public class AddNewCompanyState : IState
    {
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage result = MessagesFromTg.ShowMenuForAdmin;

            switch (update.Type)
            {
                case UpdateType.CallbackQuery:
                    switch (update.CallbackQuery.Data)
                    {
                        case "Menu":
                            controller.State = new ChooseYourCompany();
                            result = MessagesFromTg.ShowMenuForAdmin;
                            break;
                    }
                    break;
            }
            return result;
        }
    }
}
