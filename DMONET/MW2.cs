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

    public partial class MW2 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        JRPC JRPC = new JRPC();
        public MW2()
        {
            InitializeComponent();
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

        private void MW2_Load(object sender, EventArgs e)
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

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            string a;
            a = Application.StartupPath + "\\MW2ScreenShot.png";
            JRPC.xbConsole.ScreenShot(a);
            System.Diagnostics.Process.Start(Application.StartupPath + "\\MW2ScreenShot.png");
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            string Dir;
            Dir = JRPC.xbConsole.DebugTarget.RunningProcessInfo.ProgramName;
            var xexPath = @"Hdd:\" + Dir;
            JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
        }
        private bool nofalldamage;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!nofalldamage)
            {
                simpleButton1.ForeColor = Color.Green;
                float Values = 1f;
                JRPC.WriteFloat(0x82004D08, Values);
                JRPC.CallByte(0x822548D8, new object[]
{

                -1,
                    0,
                    "c \"No Fall Damage ON"

});
            }
            else
            {
                simpleButton1.ForeColor = Color.Fuchsia;
                float Values = 300f;
                JRPC.WriteFloat(0x82004D08, Values);
                JRPC.CallByte(0x822548D8, new object[]
{

                -1,
                    0,
                    "c \"No Fall Damage OFF"

});
            }
            nofalldamage = !nofalldamage;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void MW2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
