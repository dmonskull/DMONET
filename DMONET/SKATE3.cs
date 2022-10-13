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
    public partial class SKATE3 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {


        JRPC JRPC = new JRPC();
        public SKATE3()
        {
            InitializeComponent();
        }

        private void fluentDesignFormControl1_Click(object sender, EventArgs e)
        {

        }

        private void SKATE3_Load(object sender, EventArgs e)
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
            a = Application.StartupPath + "\\skate3ScreenShot.png";
            JRPC.xbConsole.ScreenShot(a);
            System.Diagnostics.Process.Start(Application.StartupPath + "\\skate3ScreenShot.png");
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            string Dir;
            Dir = JRPC.xbConsole.DebugTarget.RunningProcessInfo.ProgramName;
            var xexPath = @"Hdd:\" + Dir;
            JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
        }
        private bool backt;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!backt)
            {
                simpleButton1.ForeColor = Color.Green;
                JRPC.SetMemory(0x822F8B40, new byte[] { 0xF1 });
            }
            else
            {
                simpleButton1.ForeColor = Color.Red;
                JRPC.SetMemory(0x822F8B40, new byte[] { 0xA2 });
                Thread.Sleep(500);
                JRPC.SetMemory(0x822F8B40, new byte[] { 0xC1 });
            }
            backt = !backt;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            float value = float.Parse(this.textEdit1.Text);
            JRPC.WriteFloat(2184153920u, value);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            float value = float.Parse(this.textEdit2.Text);
            JRPC.WriteFloat(2184154064u, value);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            float value = float.Parse(this.textEdit3.Text);
            JRPC.WriteFloat(2182565592u, value);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            float value = float.Parse(this.textEdit4.Text);
            JRPC.WriteFloat(2182565596u, value);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            float TEXT1 = float.Parse(textEdit5.Text);
            JRPC.WriteFloat(2181484816u, TEXT1);
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            float value = float.Parse(this.textEdit6.Text);
            JRPC.WriteFloat(2184156672u, value);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            float value = float.Parse(this.textEdit7.Text);
            JRPC.WriteFloat(2181812836u, value);
        }

        private bool FLIP;

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (!FLIP)
            {
                simpleButton9.ForeColor = Color.Green;

            }
            else
            {
                simpleButton9.ForeColor = Color.Red;

            }
            FLIP = !FLIP;
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            textEdit1.Text = "-9.8";
            textEdit2.Text = "19.6";
            textEdit3.Text = "1456.35";
            textEdit4.Text = "1023.5";
            textEdit5.Text = "0.01745329";
            textEdit6.Text = "512";
            textEdit7.Text = "255";
        }
    }
}
