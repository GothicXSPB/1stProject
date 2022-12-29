using _1stProject.TgButtonsLogic;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace _1stProject.States
{
    public class CreateCompany : IState
    {
        Storage _storage1 = new Storage();
        Company _company;
        AdminClass _adminClass;
        //проверка существует ли компания
        //сделать первого юзера админом
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage message = MessagesFromTg.ShowMenuForCreatingNewCompany;
            
            bool exists = IsThisCompanyAlreadyExist(update);
            if (exists == false)
            {
                _company = new Company(update);
                _company.CreateDirectory();
                _storage1.AddNewCompany(_company.IdCompany, _company.NameCompany);
                _adminClass = new AdminClass(update);
                controller.State = new AddNewCompanyState();
                message = MessagesFromTg.GreatCompany;
            }
            else
            {
            message = MessagesFromTg.ShowThatCompanyIsNotUnique;
            }
              return message;
        }

        public bool IsThisCompanyAlreadyExist(Update update)
        {
            
            _storage1.LoadAllCompany();
            bool answer =_storage1.AllCompany.ContainsValue(update.Message.Text);
            return answer;
        }
    }
}
