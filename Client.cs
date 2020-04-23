using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    class Client
    {

        public Oda oda;
        public TcpClient socket;
        public NetworkStream stream;
        private byte[] recBuffer;
        public Kaan_ByteBuffer buffer;


        //oyuncu Bilgileri
        public int connectionID;
        public bool oyunda_mi = false;








        public void Start()

        {
            socket.SendBufferSize = 4096;
            socket.ReceiveBufferSize = 4096;
            stream = socket.GetStream();
            recBuffer = new byte[4096];
            stream.BeginRead(recBuffer, 0, socket.ReceiveBufferSize, OnReceiveData, null);
            Sabitler.Oyuncu_baglandi(connectionID.ToString());
            

        }

        private void OnReceiveData(IAsyncResult result)
        {
            try
            {
                int length = stream.EndRead(result);
                if (length <= 0)

                {
                    CloseConnection();
                    return;
                }
                byte[] newBytes = new byte[length];
                Array.Copy(recBuffer, newBytes, length);
                ServerHandleData.HandleData(connectionID, newBytes);
                stream.BeginRead(recBuffer, 0, socket.ReceiveBufferSize, OnReceiveData, null);
            }
            catch (Exception)
            {
                CloseConnection();
                

                return;
            }


        }
        private void CloseConnection()
        {
            Sabitler.bagli_client.Remove(connectionID);
            Sabitler.Oyuncu_cikti(connectionID.ToString());

            socket.Close();

            
           
        }




    }
}
