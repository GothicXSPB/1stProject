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
    public class CreateCompany: IState
    {
        Storage _storage1 = new Storage();
        //проверка существует ли компания
        //сделать первого юзера админом
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage message;
            bool exists = _storage1.IsThisCompanyAlreadyExist();
            if  (exists = true)
            {
                message = MessagesFromTg.ShowThatCompanyIsNotUnique;
            }
            else
            {
                controller.State = new Start();
                message = MessagesFromTg.ShowStartMenu;

            }
            return message;
        }
    }
}
