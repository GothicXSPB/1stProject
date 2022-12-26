using _1stProject.TgButtonsLogic;
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
        private ActiveUserController _activeUsers;
        public long UserTgId { get; set; }
        public TelegramBotManager()
        {
            _activeUsers = new ActiveUserController();

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
            long UserTgId = GetTgUserId(update);

            if (!_activeUsers.IsContais(UserTgId))
            {
                _activeUsers.AddActiveMember(UserTgId);
            }

            ModelOfMessage message = _activeUsers[UserTgId].GetReply(update);

            await _bot.SendTextMessageAsync(UserTgId, message.Text, replyMarkup: message.Keyboard);
        }
        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine("Error");
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
