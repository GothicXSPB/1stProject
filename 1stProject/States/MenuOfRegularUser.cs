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
    public class MenuOfRegularUser:IState
    {
        //предложить меню с функционалом юзера
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage message = MessagesFromTg;
            return;
        }
    }
}
