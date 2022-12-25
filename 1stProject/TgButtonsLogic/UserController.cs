﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1stProject.States;
using Telegram.Bot.Types;

namespace _1stProject.TgButtonsLogic
{
    public class UserController
    {
        public long UserId { get; set; }
        public IState State { get; set; }
        public UserController(long userId)
        {
            UserId = userId;
            State = new Start();
        }
        public ModelOfMessage GetReply (Update update) 
        {
            return State.HandleUpdate(update, this);
        }
    }
}
