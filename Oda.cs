using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Server
{
    class Oda
    {

        public int OdaNumarasi { get; set; }

        public static Dictionary<int, Client> odadakiler = new Dictionary<int, Client>();

        public int getOdadakiKisiSayisi()
        {
            return odadakiler.Count();
        }

        public void OdayaEkle(Client client)
        {
            odadakiler.Add(client.connectionID, client);
        }

        public void OdadanSil(int connectionID)
        {
            odadakiler.Remove(connectionID);
        }

        public Client GetOdaClient(int connectionID)
        {
            return odadakiler[connectionID];
        }

    }
}
