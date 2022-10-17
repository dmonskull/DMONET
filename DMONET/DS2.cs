using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JRPC_Client;
using XDevkit;
using System.Threading;

namespace DMONET
{
    public partial class DS2 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {


        JRPC JRPC = new JRPC();
        public DS2()
        {
            InitializeComponent();
        }
        private void DS2_Load(object sender, EventArgs e)
        {
            try
            {
                JRPC.Connect();
                if (JRPC.activeConnection == true)
                {

                    barHeaderItem1.Caption = "ACTIVE";
                    barHeaderItem1.Appearance.ForeColor = Color.Green;
                    MessageBox.Show("Connection Active", "DMONET");

                }

                else
                {
                    barHeaderItem1.Caption = "IDLE";
                    barHeaderItem1.Appearance.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Connecting to Console", "DMONET");
            }
        }

        public uint PlayerLevel = 3324845279U;
        public uint Souls = 3324845307U;
        public uint Vigor = 3324845077U;
        public uint Endurance = 3324845079U;
        public uint Vitality = 3324845081U;
        public uint Attunement = 3324845083U;
        public uint Strength = 3324845085U;
        public uint Dexterity = 3324845087U;
        public uint Intelligence = 3324845089U;
        public uint Adaptability = 3324845093U;
        public uint Faith = 3324845091U;


        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            try
            {
                JRPC.Connect();
                if (JRPC.activeConnection == true)
                {

                    barHeaderItem1.Caption = "ACTIVE";
                    MessageBox.Show("Re-connected to Tool :)", "DMONET");

                }

                else
                {
                    barHeaderItem1.Caption = "IDLE";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Re-Connecting to Console", "DMONET");
            }
        }

        const string formatter = "{0,10}{1,13}";
        public static void GetBytesUInt16(ushort argument)
        {
            byte[] byteArray = BitConverter.GetBytes(argument);
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            byte test = Convert.ToByte(numericUpDown1.Value);
            byte[] test2 = BitConverter.GetBytes(test);
            JRPC.SetMemory(PlayerLevel, test2);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            byte test = Convert.ToByte(numericUpDown3.Value);
            byte[] test2 = BitConverter.GetBytes(test);
            JRPC.SetMemory(Vigor, test2);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            byte test = Convert.ToByte(numericUpDown4.Value);
            byte[] test2 = BitConverter.GetBytes(test);
            JRPC.SetMemory(Endurance, test2);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            byte test = Convert.ToByte(numericUpDown5.Value);
            byte[] test2 = BitConverter.GetBytes(test);
            JRPC.SetMemory(Vitality, test2);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            byte test = Convert.ToByte(numericUpDown11.Value);
            byte[] test2 = BitConverter.GetBytes(test);
            JRPC.SetMemory(Faith, test2);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            byte test = Convert.ToByte(numericUpDown6.Value);
            byte[] test2 = BitConverter.GetBytes(test);
            JRPC.SetMemory(Attunement, test2);
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            byte test = Convert.ToByte(numericUpDown7.Value);
            byte[] test2 = BitConverter.GetBytes(test);
            JRPC.SetMemory(Strength, test2);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            byte test = Convert.ToByte(numericUpDown8.Value);
            byte[] test2 = BitConverter.GetBytes(test);
            JRPC.SetMemory(Dexterity, test2);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            byte test = Convert.ToByte(numericUpDown9.Value);
            byte[] test2 = BitConverter.GetBytes(test);
            JRPC.SetMemory(Intelligence, test2);
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            byte test = Convert.ToByte(numericUpDown10.Value);
            byte[] test2 = BitConverter.GetBytes(test);
            JRPC.SetMemory(Adaptability, test2);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            JRPC.SetMemory(0xC62D1CDD, new byte[] { 0xFF, 0xFF, 0xFF });
            JRPC.SetMemory(0xC62D1CF8, new byte[] { 0x0F, 0xFF, 0xFF, 0xFF });
            JRPC.SetMemory(0xC62D1C15, new byte[] { 0x63, 0x63, 0x63, 0x63, 0x63, 0x63, 0x63, 0x63});
            JRPC.SetMemory(0xC62D1C2B, new byte[] { 0x06, 0x63, 0x63, 0x63, 0x63, 0x63, 0x63, 0x63, 0x63, 0x63 });


        }
    }
}
