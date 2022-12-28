using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1stProject.States;
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
                    Text = "Доброго вам дня! Вас привествует система учета рабочего времени!",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Войти в компании") { CallbackData = "UseAvaliableFunction" },
                                new InlineKeyboardButton("Создать новую компанию") { CallbackData = "NewCompany" }
                            },
                        })
                };
            }
        }

        public static ModelOfMessage AddNewCompany
        {
            get
            {
                return new ModelOfMessage()
                {
                    Text = "Напиши название компании и через пробел ее идентификатор",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Вернуться в стартовое") { CallbackData = "Start" }
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
                    Text = "Ваши права администратора подтверждены. Информация о компании:" + "\r\n" + "Работкини:" + "\r\n" + "Админы:",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Добавить сотрудника") { CallbackData = "AddEmployee" },
                                new InlineKeyboardButton("Добавить сотрудника в календарь") { CallbackData = "AddEmployeeToCalendar" },
                            },
                            new[]
                            {
                                new InlineKeyboardButton("Удалить сотрудника") { CallbackData = "DeleteEmployee" },
                                new InlineKeyboardButton("Добавить админа") { CallbackData = "AddAdmin" }
                            },
                            new[]
                            {
                                new InlineKeyboardButton("Удалить сотрудник с даты") { CallbackData = "DeleteEmployeeToCalendar" },
                                new InlineKeyboardButton("Поставить сотрудник на даты") { CallbackData = "AddEmployeeToDays" },
                            },
                            new[]
                            {
                                new InlineKeyboardButton("Вернуться в стартовое") { CallbackData = "Start" },
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
                    Text = "Прекрасный денек! Что бы вы хотели сделать сегодня? =)",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Я хочу") { CallbackData = "хххх" },
                                new InlineKeyboardButton("Я хочу") { CallbackData = "хх" }
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
                    Text = "Напишите компанию в которой вы хотите продолжать работу",
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
                    Text = "Для создания компании укажите уникальное имя компании. Далее оно будет использоваться для авторизации вас и ваших сотрудников",
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
                    Text = "Многие люди думают одинаково. Такое имя уже существует. Попробуйте еще раз",
                    Keyboard = null
                };
            }
        }
    }
}
