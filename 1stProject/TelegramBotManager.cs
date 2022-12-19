using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot;
using _1stProject;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;

namespace _1stProject
{
    internal class TelegramBotManager
    {
        ITelegramBotClient _bot;

        public TelegramBotManager()
        {
            string token = @"5910759542:AAHMbJh_wprscd-3TGi8T5kUaRwZG1LKB7s";
            _bot = new TelegramBotClient(token);

            Console.WriteLine("Запущен бот " + _bot.GetMeAsync().Result.FirstName);
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { },
            };

            _bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(update.Message.Chat.FirstName + " " + update.Message.Chat.Id);

            if (update.Message.Text == "/start")
            {
                _bot.SendTextMessageAsync(update.Message.Chat.Id, $"Привет, я телеграмм бот менеджер,напиши" + "\r\n" + "/keyboard" + "\r\n" +
                    $"1-Создать новую компанию" + "\r\n" + $"2-Зайти в существующую компанию");
            }
            if (update.Message.Text == "Меню")
            {
                _bot.SendTextMessageAsync(update.Message.Chat.Id, $"Привет, я телеграмм бот менеджер,напиши" + "\r\n" +
                    "/keyboard" + "\r\n" +
                    $"1-Создать новую компанию" + "\r\n" +
                    $"2-Зайти в существующую компанию");
            }
            if (update.Message.Text == "1")
            {
                _bot.SendTextMessageAsync(update.Message.Chat.Id, $"Введи имя компании");
            }
            if (update.Message.Text != null)
            {
                Company company1 = new Company(update.Message.Text, 11234);
                AdminClass admin = new AdminClass(update.Message.Chat.Id, update.Message.Chat.FirstName, "123", 0);
                Console.WriteLine(update.Message.Chat.FirstName + "Создал компанию " + company1.NameCompany + " " + company1.IDCompany);

                _bot.SendTextMessageAsync(update.Message.Chat.Id, $"Твоя комания:" + "\r\n" +
                        "Name:" + company1.NameCompany + "\r\n" + "Id" + company1.IDCompany);
            }
        }

        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }

    }
}
