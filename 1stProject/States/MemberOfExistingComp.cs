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
    internal class MemberOfExistingComp : IState
    {
        //ВЫВЕСТИ КОМПАНИИ В КОТОРЫХ УЧАСТВУЕТ ЮЗЕР
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage result = MessagesFromTg.AddNewCompany;

            switch (update.Type)
            {
                case UpdateType.CallbackQuery:
                    switch (update.CallbackQuery.Data)
                    {
                        case "Menu":
                            controller.State = new MenuForAdmin();
                            result = MessagesFromTg.ShowMenuForAdmin;
                            break;
                    }
                    break;
                case UpdateType.Message:
                    string newNameCompany = update.Message.Text;
                    controller.State = new MenuOfRegularUser();
                    result = MessagesFromTg.ShowMenuForRegularUser;
                    break;
            }
            return result;
        }
    }
}
