using System;
using Telegram.Bot.Types;

using Telegram.Bot.Types.Enums;

//namespace _1stProject
//{
//    public class UserNull
//    {
//        //Storage storage = new Storage();
//        public long CurrentCmId { get; set; }
//        private long _currentCmId;
//        public long GetTgUserId(Update update)
//        {
//            long userId;
//            if (update.Type == UpdateType.Message)
//            {
//                userId = update.Message.Chat.Id;
//            }
//            else if (update.Type == UpdateType.CallbackQuery)
//            {
//                userId = update.CallbackQuery.From.Id;
//            }
//            else
//            {
//                throw new ArgumentException();
//            }
//            return userId;
//        }

//        public bool CheckIsThisUserExistsInAllTgBase()
//        {
//            bool workerIsExists = storage.AllWorker.ContainsKey(CurrentCmId);
//            return workerIsExists;
//        }
//    }
//}
