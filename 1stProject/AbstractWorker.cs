using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1stProject
{
    public abstract class AbstractWorker
    {
        public string Name { get; protected set; }
        public string TelephoneNumber { get; protected set; }
        public int Id { get; protected set; }

    }
}
