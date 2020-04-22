using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    public enum ClientPackets
    {
        CMerhabaServer = 1,


    }
    static class DataReceiver
    {
        public static void HandleMerhabaServer(int connectionID, byte[] data)

        {
            Kaan_ByteBuffer buffer = new Kaan_ByteBuffer();
            buffer.Bytes_Yaz(data);
            int packetID = buffer.Int_Oku();
            string msg = buffer.String_Oku();
            buffer.Dispose();
            Yazi.Gelen_Mesaj(connectionID + " " + msg);
            

        }

   
    }
}
