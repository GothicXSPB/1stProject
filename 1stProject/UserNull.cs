using System;
using Telegram.Bot.Types;

namespace _1stProject
{
    public class UserNull
    {
        Storage storage = new Storage();
        TelegramBotManager _telegramBotManager= new TelegramBotManager();
        public long UserTgId { get; set; }

        public UserNull ()
        {
            UserTgId = _telegramBotManager.Id;
        }

        public void CheckIsThisUserExistsInAllTgBase ()
        {
            bool workerIsExists = storage.allWorker.ContainsKey(UserTgId);

            if (workerIsExists is true)
            {
                ///по логике, тут кнопки с выбором компании
            }
            else
            {
                ///а тут кнопка "вы не зарегестрирвоаны ни в одной компании. Хотите создать новую?"
            }
        }
    }
}
