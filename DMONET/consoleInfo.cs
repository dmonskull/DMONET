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
using System.IO;
using DevExpress.XtraEditors;


namespace DMONET
{
    public partial class consoleInfo : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        JRPC JRPC = new JRPC();
        public consoleInfo()
        {
            InitializeComponent();
        }


        private void consoleInfo_Load(object sender, EventArgs e)
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
            string gamertag2 = Encoding.BigEndianUnicode.GetString(JRPC.GetMemory(2175412476U, 30U)).Trim().Trim(new char[1]);
            gamertag.Text = Encoding.BigEndianUnicode.GetString(JRPC.GetMemory(2175412476U, 30U)).Trim().Trim(new char[1]);
            CPUKeyText.Text = JRPC.CPUKey();
            IPText.Text = JRPC.XboxIP();
            KernalVersion.Text = JRPC.GetKernalVersion();
            ConsoleType.Text = JRPC.ConsoleType();
            pictureBox1.ImageLocation = "http://xboxgamertag.com/gamercard/" + gamertag2 + "/newnxe/card.png";
            pictureBox2.ImageLocation = "http://avatar.xboxlive.com/avatar/" + gamertag2 + "/avatar-body.png";

        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            try
            {
                JRPC.Connect();
                if (JRPC.activeConnection == true)
                {

                    string gamertag = Encoding.BigEndianUnicode.GetString(JRPC.GetMemory(2175412476U, 30U)).Trim().Trim(new char[1]);
                    barHeaderItem1.Caption = "ACTIVE";
                    MessageBox.Show("Re-connected to Tool :)", "DMONET");
                    CPUKeyText.Text = JRPC.CPUKey();
                    IPText.Text = JRPC.XboxIP();
                    KernalVersion.Text = JRPC.GetKernalVersion();
                    ConsoleType.Text = JRPC.ConsoleType();
                    pictureBox1.ImageLocation = "http://xboxgamertag.com/gamercard/" + gamertag + "/newnxe/card.png";
                    pictureBox2.ImageLocation = "http://avatar.xboxlive.com/avatar/" + gamertag + "/avatar-body.png";
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
            a = Application.StartupPath + "\\ConsoleInfoScreenShot.png";
            JRPC.xbConsole.ScreenShot(a);
            System.Diagnostics.Process.Start(Application.StartupPath + "\\ConsoleInfoScreenShot.png");
        }


        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
        }
        private void SetTileAvatarImage(ITileItem Tile, string Gamertag)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fluentDesignFormControl1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            string text = CPUKeyText.Text;
            Clipboard.SetText(text);
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            string fileName = System.Environment.CurrentDirectory + "/CPUKey.txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (FileStream fs = File.Create(fileName))
            {
                // Add some text to file    
                byte[] author = new UTF8Encoding(true).GetBytes(CPUKeyText.Text);
                fs.Write(author, 0, author.Length);
            }
            MessageBox.Show("CPUKey.txt can be found in the same folder as DMONET");
        }




    }
}
