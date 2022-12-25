using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace _1stProject.TgButtonsLogic
{
    public static class MessagesFromTg
    {
        public static ModelOfMessage ShowStartMenu 
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Вас привествует система учета рабочего времени!",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Я зарегистрированный пользователь в компании") { CallbackData = "UseAvaliableFunction" },
                                new InlineKeyboardButton("Я новый пользователь или я хочу создать новую компанию") { CallbackData = "newUserOrCompany" }
                            },
                        })
                };
            }

        }

        public static ModelOfMessage ShowMenuForAdmin
        {

        }
        public static ModelOfMessage ShowMenuForRegularUser
        {

        }
        public static ModelOfMessage ShowMenuForAdmin
        {

        }
        public static ModelOfMessage ShowMenuForChoosingCompany
        {

        }
        public static ModelOfMessage ShowMenuForCreatingNewCompany
        {

        }
    }
}
