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

        public bool CheckIsThisUserExistsInAllTgBase ()
        {
            bool workerIsExists = storage.AllWorker.ContainsKey(CurrentCmId);
            return workerIsExists;
        }
        public bool IsTheUserExist()
        {

            return;
        }
        public bool IsTheUserAdminOrNot()
        {
            return;
        }
    }
}
