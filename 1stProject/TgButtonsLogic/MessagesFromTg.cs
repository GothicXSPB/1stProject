﻿using Telegram.Bot.Types.ReplyMarkups;

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
                    Message = "Доброго вам дня! Вас привествует система учета рабочего времени!",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Я зарегистрированный пользователь в компании") { CallbackData = "UseAvaliableFunction" },
                                new InlineKeyboardButton("Я хочу создать новую компанию") { CallbackData = "newCompany" }
                            },
                        })
                };
            }
        }

        public static ModelOfMessage ShowMenuForAdmin
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Ваши права администратора подтверждены. Прекласный сегодня денек! =) Что бы вы хотели сделать сегодня?",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Я хочу ") { CallbackData = "хххх" },
                                new InlineKeyboardButton("Я хочу") { CallbackData = "хх" }
                            },
                            new[]
                            {
                                new InlineKeyboardButton("Вернуться назад") { CallbackData = "return" },
                            },
                        })
                };
            }
        }

        public static ModelOfMessage ShowMenuForRegularUser
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Прекрасный денек! Что бы вы хотели сделать сегодня? =)",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Я хочу ") { CallbackData = "хххх" },
                                new InlineKeyboardButton("Я хочу") { CallbackData = "хх" }
                            },
                                 new[]
                            {
                                new InlineKeyboardButton("Вернуться назад") { CallbackData = "return" },
                            },
                        })
                };
            }
        }

        public static ModelOfMessage ShowMenuForChoosingCompany
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Выберите компанию в которой вы хотите продолжать работу ТУТ ВЫВОДИМ СПИСОК КОМПАНИЙ",
                    Keyboard = null 

                };
            }

        }
        public static ModelOfMessage ShowMenuForCreatingNewCompany
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Для создания компании укажите уникальное имя компании. Далее оно будет использоваться для авторизации вас и ваших сотрудников",
                    Keyboard = null
                };
            }
        }
        public static ModelOfMessage ShowThatCompanyIsNotUnique
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Многие люди думают одинаково. Такое имя уже существует. Попробуйте еще раз",
                    Keyboard = null
                };
            }
        }
    }
}
