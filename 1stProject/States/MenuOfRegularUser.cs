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
    public class MenuOfRegularUser : IState
    {
        //проверка по спискам компаний
        //проверка по спискам существующих сотрудников админов и юзеров
        //предложить меню с функционалом юзера
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage result = MessagesFromTg.ShowMenuForRegularUser;

            switch (update.Type)
            {
                case UpdateType.CallbackQuery:
                    switch (update.CallbackQuery.Data)
                    {
                        case "1":

                            break;
                        case "2":

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
