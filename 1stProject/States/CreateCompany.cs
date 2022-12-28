using _1stProject.TgButtonsLogic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _1stProject.States
{
    public class CreateCompany : IState
    {
        Storage _storage1 = new Storage();
        //проверка существует ли компания
        //сделать первого юзера админом
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage message = MessagesFromTg.ShowMenuForCreatingNewCompany;
            if (update.Type == UpdateType.Message)
            {
                bool exists = IsThisCompanyAlreadyExist(update);
                if (exists == false)
                {
                    controller.State = new AddNewCompanyState();
                    Company company = new Company(update);
                    message = MessagesFromTg.GreatCompany;
                }
                else if (exists == true)
                {
                    message = MessagesFromTg.ShowThatCompanyIsNotUnique;
                }
            }
            return message;
        }

        public bool IsThisCompanyAlreadyExist(Update update)
        {
            bool answer = _storage1.AllCompany.ContainsValue(update.Message.Text);
            return answer;
        }
    }
}
