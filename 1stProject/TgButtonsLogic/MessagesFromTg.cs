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
                    Message = "Доброго вам дня! Вас привествует система учета рабочего времени!",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Войти в компании") { CallbackData = "UseAvaliableFunction" },
                                new InlineKeyboardButton("Создать новую компанию") { CallbackData = "newCompany" }
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
                    Message = "Напиши название компании",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Вернуться в стартовое меню") { CallbackData = "Start" }
                            }
                        })
                };
            }
        }

        public static ModelOfMessage GreatCompany
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Компания успешно создана",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Меню") { CallbackData = "Menu" }
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
                    Message = "Ваши права администратора подтверждены. Информация о компании:" + "\r\n" + "Работники:" + "\r\n" + "Админы:",
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
                                new InlineKeyboardButton("Вернуться в стартовое меню") { CallbackData = "Start" },
                            }
                        })
                };
            }
        }

        public static ModelOfMessage ShowAddEmployee
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Введите Id сотрудника, которого хотите добавить",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Назад") { CallbackData = "Back" },
                            },
                        })
                };
            }
        }

        public static ModelOfMessage ShowAddEmployeeToCalendar
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Введите Id сотрудника, которого хотите добавить в календарь",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Назад") { CallbackData = "Back" },
                            },
                        })
                };
            }
        }

        public static ModelOfMessage ShowDeleteEmployee
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Введите Id сотрудника, которого хотите удалить",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Назад") { CallbackData = "Back" },
                            },
                        })
                };
            }
        }

        public static ModelOfMessage ShowAddAdmin
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Введите Id сотрудника, которого хотите сделать админом",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Назад") { CallbackData = "Back" },
                            },
                        })
                };
            }
        }

        public static ModelOfMessage ShowDeleteEmployeeToCalendar
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Введите Id сотрудника и дату с которой его нужно убрать",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Назад") { CallbackData = "Back" },
                            },
                        })
                };
            }
        }

        public static ModelOfMessage ShowAddEmployeeToDays
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Введите Id сотрудника и дату на которую его нужно поставить",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Назад") { CallbackData = "Back" },
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
                                new InlineKeyboardButton("Посмотреть график за период") { CallbackData = "x" }
                            },
                            new[]
                            {
                                new InlineKeyboardButton("Поменяться сменами") { CallbackData = "x" },
                            },
                            new[]
                            {
                                new InlineKeyboardButton("Вернуться в стартовое меню") { CallbackData = "Start" },
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
                    Message = "Напишите компанию в которой вы хотите продолжать работу: " ,
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

        public static ModelOfMessage ShowThatCompanyIsNotExist
        {
            get
            {
                return new ModelOfMessage()
                {
                    Message = "Такой компании не существует. Попробуйте еще раз",
                    Keyboard = new InlineKeyboardMarkup(
                        new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("Вернуться в стартовое меню") { CallbackData = "Start" },
                            },
                        })
                };
            }
        }
    }
}
