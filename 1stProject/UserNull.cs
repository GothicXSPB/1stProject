using System;
using Telegram.Bot.Types;

namespace _1stProject
{
    public class UserNull
    {
        Storage storage = new Storage();

        public void WhoThisUser(TelegramBotManager id)
        {
            bool a = storage.allWorker.ContainsKey(id);

            if (a is true)
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
