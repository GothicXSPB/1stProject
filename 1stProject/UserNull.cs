using System;
using Telegram.Bot.Types;

namespace _1stProject
{
    public class UserNull
    {
        Storage storage = new Storage();
        TelegramBotManager _telegramBotManager= new TelegramBotManager();
        public long CurrentCmId { get; set; }

        public UserNull ()
        {
            CurrentCmId = _telegramBotManager.UserTgId;
        }

        public void CheckIsThisUserExistsInAllTgBase ()
        {
            bool workerIsExists = storage.AllWorker.ContainsKey(CurrentCmId);

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
