﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace _1stProject.TgButtonsLogic
{
    public class ModelOfMessage
    {
       public string Message { get; set; }
       public InlineKeyboardMarkup Keyboard { get; set; }
    }
}
