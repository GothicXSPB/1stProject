using _1stProject.TgButtonsLogic;
using Telegram.Bot.Types;


namespace _1stProject.States
{
    public class CreateCompany : IState
    {
        Storage _storage1 = new Storage();
        //проверка существует ли компания
        //сделать первого юзера админом
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage message;
            bool exists = IsThisCompanyAlreadyExist(update);
            if (exists == true)
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
        public bool IsThisCompanyAlreadyExist(Update update)
        {
            if (_storage1.AllCompany.ContainsValue(update.Message.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
