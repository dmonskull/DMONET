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

namespace DMONET
{
    public partial class DeadRising2otf : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        JRPC JRPC = new JRPC();
        public DeadRising2otf()
        {
            InitializeComponent();
        }


        public uint Levels = 3352533171U;
        public uint money = 3352533248U;

        private void DeadRising2otf_Load(object sender, EventArgs e)
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

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            string a;
            a = Application.StartupPath + "\\DR2OTFScreenShot.png";
            JRPC.xbConsole.ScreenShot(a);
            System.Diagnostics.Process.Start(Application.StartupPath + "\\DR2OTFScreenShot.png");
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            byte test = Convert.ToByte(numericUpDown1.Value);
            byte[] test2 = BitConverter.GetBytes(test);
            JRPC.SetMemory(Levels, test2);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        public bool Money;
        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            if (!Money)
            {
                simpleButton3.ForeColor = Color.Green;
                JRPC.SetMemory(money, new byte[] { 0x0F, 0xFF, 0xFF, 0xFF });
            }
            else
            {
                simpleButton3.ForeColor = Color.Red;
                JRPC.SetMemory(money, new byte[] { 0x00, 0x00, 0x00, 0x01 });
            }
            Money = !Money;
        }
        public bool level;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (!level)
            {
                simpleButton2.ForeColor = Color.Green;
                JRPC.SetMemory(0xC7D398B0, new byte[] { 0x0F, 0xFF, 0xFF, 0xFF });
            }
            else
            {
                simpleButton2.ForeColor = Color.Red;
                JRPC.SetMemory(0xC7D398B0, new byte[] { 0x00, 0x00, 0x00, 0x0A });
            }
            level = !level;
        }
        public bool health;
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (!health)
            {
                simpleButton4.ForeColor = Color.Green;
                JRPC.SetMemory(0xC7D398BC, new byte[] { 0x44, 0xBB, 0x80 });
            }
            else
            {
                simpleButton4.ForeColor = Color.Red;
                JRPC.SetMemory(0xC7D398BC, new byte[] { 0x42, 0x67, 0x00 });
            }
            health = !health;

        }
        public bool healthbars;
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (!healthbars)
            {
                simpleButton5.ForeColor = Color.Green;
                JRPC.SetMemory(0xC7D398EF, new byte[] { 0x0D });
            }
            else
            {
                simpleButton5.ForeColor = Color.Red;
                JRPC.SetMemory(0xC7D398EF, new byte[] { 0x04 });
            }
            healthbars = !healthbars;
        }
        public bool timergodmode;
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (!timergodmode)
            {
                simpleButton6.ForeColor = Color.Green;
                JRPC.SetMemory(0xC7D398EF, new byte[] { 0x0D });
                JRPC.SetMemory(0xC7D398BC, new byte[] { 0x44, 0xBB, 0x80 });
                timer1.Start();
            }
            else
            {
                simpleButton6.ForeColor = Color.Red;
                timer1.Stop();
            }
            timergodmode = !timergodmode;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            JRPC.SetMemory(0xC7D398BC, new byte[] { 0x44, 0xBB, 0x80 });
        }
    }
}
