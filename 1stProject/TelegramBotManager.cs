using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace _1stProject
{
    public class TelegramBotManager
    {
        ITelegramBotClient _bot;
        public long Id { get; set; }

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
           _bot.SendTextMessageAsync(update.Message.Chat.Id, $"Привет, " + update.Message.Chat.FirstName);
            Id = update.Message.Chat.Id;
        }

        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }

    }
}
