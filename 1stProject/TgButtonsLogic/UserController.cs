using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1stProject.States;

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

    }
}
