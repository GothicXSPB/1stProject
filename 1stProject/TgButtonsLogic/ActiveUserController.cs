using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1stProject.TgButtonsLogic
{
    public class ActiveUserController
    {
        private Dictionary<long, UserController> _members;

        public UserController this[long UserTgId]
        {
            get
            {
                return _members[UserTgId];
            }
        }

        public ActiveUserController()
        {
            _members = new Dictionary<long, UserController>();
        }

        public void AddActiveMember(long UserTgId)
        {
            if (!_members.ContainsKey(UserTgId))
            {
                _members.Add(UserTgId, new UserController(UserTgId));
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool IsContais(long UserTgId)
        {
            return _members.ContainsKey(UserTgId);
        }
    }
}
