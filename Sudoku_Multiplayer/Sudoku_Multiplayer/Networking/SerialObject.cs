using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Client_Server_SerialComm
{
    class SerialObject
    {
        //Attributes
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream memBuffer = new MemoryStream();

        //Directly Get and Set Serialized and Deserialized data
        //public byte[] Serialized { get { serialize(); return Serialized; } set { Serialized = value; } } //to push memBuffer into Serialized
        public byte[] Serialized = new byte[1000];
        public object Deserialized;

        //Serializing
        //--First use this
        public void AddDataToBeSerialized(int dataSize)
        {
            memBuffer.Write(Serialized, 0, dataSize);
        }

        //--When ready use this
        public void Serialize()
        {
            //as we know the object is Serialized, we should use GetDeserial
            formatter.Serialize(memBuffer, Deserialized);
            Serialized = memBuffer.GetBuffer();
            memBuffer.Close();
        }

        //Deserialize
        public void Deserialize()
        {
            //as we know the object is Serialized, we should use GetSerial
            memBuffer.Seek(0, SeekOrigin.Begin);
            Deserialized = formatter.Deserialize(memBuffer);
        }
    }
}
