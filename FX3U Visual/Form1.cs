using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActUtlTypeLib;
namespace FX3U_Visual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        connection bien1 = new connection();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bien1.connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bien1.disconnect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bien1.plc.WriteDeviceBlock(txt_addD.Text, 1, Convert.ToInt16(txt_ValD.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int biennhan;
            bien1.plc.ReadDeviceBlock(txt_addD.Text, 1,out biennhan );
            txt_ValD.Text = biennhan.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bien1.plc.SetDevice(txt_addM.Text, Convert.ToInt16(txt_valM.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int biennhanM;
            bien1.plc.GetDevice(txt_addM.Text, out biennhanM);
            txt_valM.Text=biennhanM.ToString();
        }
    }
    public class connection
    {
        public ActUtlType plc = new ActUtlType();
        public int iret;
        public void connect()
        {
            plc.ActLogicalStationNumber = 300; // Station number
            plc.Open();
        }
        public void disconnect()
        {
            plc.Close();
        }

    }
}
