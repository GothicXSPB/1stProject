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
    public class Start : IState
    {
        //сказать привет, предложить вступить,создать, войти
        //функционал
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage model = MessagesFromTg.ShowStartMenu;
            if (update.Type == UpdateType.CallbackQuery)
            {
                string answer = update.CallbackQuery.Data;
                if (answer == "UseAvaliableFunction")
                {
                        controller.State = new MemberOfExistingComp();
                        model = MessagesFromTg.ShowMenuForChoosingCompany;
                }
                else if (answer == "newCompany")
                {
                    controller.State = new CreateCompany();
                    model = MessagesFromTg.ShowMenuForCreatingNewCompany;
                }   
            }

            return model;
        }
    }
}
