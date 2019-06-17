using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Server_SerialComm
{
    public class commArgs : EventArgs
    {
        public bool Reception; //to know if it is received or sent
        public string Info; //add personalized info about what parameter is exchanged
        public string Message; //data string transfered when received OR complementary info when Sent
        public object ObjectData; //data transfert
    }
}
