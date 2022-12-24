using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace _1stProject
{
    public class TelegramBotManager
    {
        ITelegramBotClient _bot;
        public long UserTgId { get; set; }
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
            UserTgId = GetTgUserId(update);
            //=======

            Console.WriteLine(update.Message.Chat.FirstName + " " + update.Message.Chat.Id);
            if (update.Message.Text == "/keyboard")
            {
                ReplyKeyboardMarkup keyboard = new(new[]
                {
                new KeyboardButton[] {"Меню"},
                new KeyboardButton[] {"1", "2"}
                })
                {
                    ResizeKeyboard = true
                };
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Выбирай:", replyMarkup: keyboard);
                return;
            }

            if (update.Message.Text == "/start")
            {
                _bot.SendTextMessageAsync(update.Message.Chat.Id, $"Привет, я телеграмм бот менеджер,напиши" + "\r\n" + "/keyboard" + "\r\n" +
                    $"1-Создать новую компанию" + "\r\n" + $"2-Зайти в существующую компанию");
                return;
            }
            if (update.Message.Text == "Меню")
            {
                _bot.SendTextMessageAsync(update.Message.Chat.Id, $"Привет, я телеграмм бот менеджер,напиши" + "\r\n" +
                    "/keyboard" + "\r\n" +
                    $"1-Создать новую компанию" + "\r\n" +
                    $"2-Зайти в существующую компанию");
                return;
            }
            if (update.Message.Text == "1")
            {
                _bot.SendTextMessageAsync(update.Message.Chat.Id, $"Введи имя компании");
                return;
            }
            if (update.Message.Text != null)
            {
                Company company1 = new Company(update.Message.Text, 11234); //(long)Convert.ToDouble(update.Message.Text)
                AdminClass admin = new AdminClass(update.Message.Chat.Id, update.Message.Chat.FirstName, "123", 0);
                admin.AddAdmin(admin);
                Console.WriteLine(update.Message.Chat.FirstName + "Создал компанию " + company1.NameCompany + " " + company1.IDCompany);

                _bot.SendTextMessageAsync(update.Message.Chat.Id, $"Твоя комания:" + "\r\n" +
                        "Name:" + company1.NameCompany + "\r\n" + "Id" + company1.IDCompany);
                return;
            }

        }
        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }

        public long GetTgUserId(Update update)
        {
            long userId;
            if (update.Type == UpdateType.Message)
            {
                userId = update.Message.Chat.Id;
            }
            else if (update.Type == UpdateType.CallbackQuery)
            {
                userId = update.CallbackQuery.From.Id;
            }
            else
            {
                throw new ArgumentException();
            }
            return userId;
        }
    }
}
