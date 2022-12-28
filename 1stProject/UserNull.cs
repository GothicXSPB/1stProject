using System;
using Telegram.Bot.Types;

namespace _1stProject
{
    public class UserNull
    {
        Storage storage = new Storage();
        public long CurrentCmId { get; set; }

        public bool CheckIsThisUserExistsInAllTgBase ()
        {
            bool workerIsExists = storage.AllWorker.ContainsKey(CurrentCmId);
            return workerIsExists;
        }
    }
}
