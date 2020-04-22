using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Server
{
    public partial class GameServer : Form
    {
        public GameServer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.AppendText("Oyun Sunucusu baslatılıyor");
            richTextBox2.AppendText("Oyun Sunucusu baslatılıyor");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            General.Sunucuyu_Baslat();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = Sabitler.gecicideneme.Count.ToString(); 
        }
    }
}
