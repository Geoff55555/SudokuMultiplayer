using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Multiplayer.Classes
{
    [Serializable]
    class CaseClick : EventArgs
    {
        //public Sudoku_Numb_Label caseClicked; useless because we always send the "sender" with the event
        public string message;
    }
}
