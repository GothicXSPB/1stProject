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
    internal class Start : IState
    {
        //сказать привет, предложить вступить,создать, войти
        //функционал
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage result = MessagesFromTg.ShowStartMenu;

            switch (update.Type)
            {
                case UpdateType.CallbackQuery:
                    switch (update.CallbackQuery.Data)
                    {
                        case "newUserOrCompany":
                            //controller.State = new SozdatState();
                            //result = MessagesFromTg.SozdatSektaNameQuestion;
                            break;
                    }
                    break;
            }
            return result;
        }
    }
}
