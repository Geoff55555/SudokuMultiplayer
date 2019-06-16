using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Server_SerialComm
{
    class commArgs : EventArgs
    {
        public bool coSuccess;
        public string message;

        public commArgs() { }

        public commArgs(string msg)
        {
            message = msg;
        }
    }
}
