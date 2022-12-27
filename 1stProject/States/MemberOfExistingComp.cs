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
        //проверка по спискам компаний
        //проверка по спискам существующих сотрудников админов и юзеров
        public ModelOfMessage HandleUpdate(Update update, UserController controller) /*- требует редактирования*/
        {
            ModelOfMessage message = MessagesFromTg.ShowMenuForAdmin;
            return message;
        }
    }
}
