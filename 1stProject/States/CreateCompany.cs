using _1stProject.TgButtonsLogic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _1stProject.States
{
    public class CreateCompany : IState
    {
        //Storage _storage1 = new Stora;
        //проверка существует ли компания
        //сделать первого юзера админом
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage message = MessagesFromTg.ShowThatCompanyIsNotUnique;
            if (update.Type == UpdateType.Message)
            {
                bool exists = IsThisCompanyAlreadyExist(update);
                if (exists == false)
                {
                    controller.State = new AddNewCompanyState();
                    message = MessagesFromTg.GreatCompany;
                }
            }
            return message;
        }
        public bool IsThisCompanyAlreadyExist(Update update)
        {
            bool answer = Storage._storage.AllCompany.ContainsValue(update.Message.Text);
            return answer;
        }
    }
}
