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
        Storage _storage1 = new Storage();
        Company _company;

        //ВЫВЕСТИ КОМПАНИИ В КОТОРЫХ УЧАСТВУЕТ ЮЗЕР
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage message = MessagesFromTg.AddNewCompany;

            switch (update.Type)
            {
                case UpdateType.CallbackQuery:
                    switch (update.CallbackQuery.Data)
                    {
                        case "Start":
                            controller.State = new Start();
                            message = MessagesFromTg.ShowStartMenu;
                            break;
                    }
                    break;
                case UpdateType.Message:
                    
                    bool exists = IsThisCompanyAlreadyExist(update);
                    if (exists)
                    {
                        _company = new Company(update);
                        controller.State = new MenuOfRegularUser();
                        message = MessagesFromTg.ShowMenuForRegularUser;
                    }
                    else
                    {
                        message = MessagesFromTg.ShowThatCompanyIsNotExist;
                    }
                    break;
            }

            return message;
        }

        public bool IsThisCompanyAlreadyExist(Update update)
        {
            _storage1.LoadAllCompany();
            bool answer = _storage1.AllCompany.ContainsValue(update.Message.Text);
            return answer;
        }
    }
}
