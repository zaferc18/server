using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{


    public enum ServerPackets
    {
        SHosGeldinMesaji = 1,

    }

    static class DataSender
    {
    public static void SendHosGeldinMesaji(int connectionID)
        {
            Kaan_ByteBuffer buffer = new Kaan_ByteBuffer();
         
            buffer.Int_Yaz((int)ServerPackets.SHosGeldinMesaji); // Paket numarası
            buffer.Int_Yaz(connectionID); //ConnectionID yani port numarası
            buffer.String_Yaz("Merhaba, Sunucuya Hos Geldin..");
            ClientManager.SendDataTo(connectionID, buffer.ToArray());
            buffer.Dispose();
           
        }

      

    }
}
