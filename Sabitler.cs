using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Server
{
    class Sabitler
    {

        public static List<int> gecicideneme = new List<int>();

        public static GameServer server = ((GameServer)Application.OpenForms.OfType<GameServer>().SingleOrDefault());
        public static Dictionary<int, Client> bagli_client = new Dictionary<int, Client>();
        public static List<Oda> Odalar = new List<Oda>();
        public static MySql Mysql_Data = new MySql();
        public static MySqlConnection Sunucu_MySql_Baglanti = null;
        static Random rastgele = new Random();
        public static Oda OdayaYerlestir(int connectionID)
        {
            if (Odalar.Count() <= 0)
                Odalar.Add(new Oda());

            Oda oda = null;

            foreach (Oda Oda in Odalar)
            {
                if (Oda.getOdadakiKisiSayisi() < 2)
                {
                    Oda.OdayaEkle(Sabitler.bagli_client[connectionID]);
                    Oda.OdaNumarasi = RasgeleOdaSayıVer();
                    oda = Oda;
                    break;
                }
                else
                {
                    Oda newOda = new Oda();
                    newOda.OdayaEkle(Sabitler.bagli_client[connectionID]);
                    newOda.OdaNumarasi = RasgeleOdaSayıVer();
                    oda = newOda;

                    Odalar.Add(newOda);
                    break;
                }
            }

            Sabitler.bagli_client[connectionID].oda = oda;
            return oda;


        }


        static int RasgeleOdaSayıVer()
        {

            int sayi = rastgele.Next(1, 9999);
            foreach (Oda oda in Odalar)
            {
                if (oda.OdaNumarasi == sayi)
                    RasgeleOdaSayıVer();
            }

            return sayi;
        }
        public static void Oyuncu_baglandi(string connectionID)

        {
            bagli_kullanici_sayisi++;
            Yazi.Log_Yaz("Kullanıcı Server'a Bağlandı : " + connectionID);
            Sabitler.server.listBox1.Items.Add(connectionID);
            ServerHandleData.InitializePackets();    
        }

        public static void Oyuncu_cikti(string connectionID)

        {
            bagli_kullanici_sayisi--;
            Yazi.Log_Yaz("Kullanıcı Serverdan ayrıldı : " + connectionID);
            Sabitler.server.listBox1.Items.Remove(connectionID);
            

        }
        private static int bagli_kullanici_sayisi_ = 0;
        public static int bagli_kullanici_sayisi
        {
        get
          {
                return bagli_kullanici_sayisi_;

            }

    set
        {
        bagli_kullanici_sayisi_ = value;
                server.label1.Text = "Bağlı Kullanıcı sayısı : " + bagli_kullanici_sayisi.ToString();
        }





        }
    }
}
