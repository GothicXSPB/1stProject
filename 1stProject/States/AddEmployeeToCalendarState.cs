using _1stProject.TgButtonsLogic;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;

namespace _1stProject.States
{
    public class AddEmployeeToCalendarState : IState
    {
        public ModelOfMessage HandleUpdate(Update update, UserController controller)
        {
            ModelOfMessage result = MessagesFromTg.ShowAddEmployeeToCalendar;

            switch (update.Type)
            {
                case UpdateType.CallbackQuery:
                    switch (update.CallbackQuery.Data)
                    {
                        case "Back":
                            controller.State = new MenuForAdmin();
                            result = MessagesFromTg.ShowMenuForAdmin;
                            break;
                    }
                    break;
                case UpdateType.Message:
                    string newNameCompany = update.Message.Text;
                    controller.State = new MenuForAdmin();
                    result = MessagesFromTg.ShowMenuForAdmin;
                    break;
            }

            return result;
        }
    }
}
