using System;
using Telegram.Bot.Types;

namespace _1stProject
{
    public class UserNull
    {
        Storage storage = new Storage();

        public void CheckIsThisUserExistsInAllTgBase (TelegramBotManager id)
        {
            bool workerIsExists = storage.allWorker.ContainsKey(id);

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
