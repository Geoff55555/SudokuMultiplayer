using System;
using System.Runtime.Serialization;

namespace Sudoku_Multiplayer
{
    [Serializable]
    internal class DuplicateException : Exception
    {
        public int[] ConflictCoordinates = new int[2];

        public DuplicateException()
        {

        }

        public DuplicateException(int row, int column)
        {
            ConflictCoordinates[0] = row;
            ConflictCoordinates[1] = column;
        }

        //auto-generated methods
        public DuplicateException(string message) : base(message)
        {
        }

        public DuplicateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}