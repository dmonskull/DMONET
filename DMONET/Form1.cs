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
using System.Threading;
using System.Net;
using System.Diagnostics;

namespace DMONET
{
    public partial class Form1 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {


        JRPC JRPC = new JRPC();


        public string GameDir;
        public string GameName;
        public string Game;

        public string Ghost1 = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 6);
        public string re4 = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 11);
        public string mw2 = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 8);
        public string mW3 = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 7);
        public string gtaV = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 9);
        public string gtaSA = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 10);
        public string skate3 = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 15);
        public string Halo3 = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 16);
        public string haloReach = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 17);
        public string SaintsRow = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 18);
        public string DeadRising2OTF = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 19);
        public string bF3 = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 13);
        public string Bo3 = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 2);
        public string Bo2 = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 3);
        public string BlackOps = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 4);
        public string Aw = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 5);
        public string rTr = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 12);
        public string dS2 = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 14);


        public string GameFolder = ReadSpecificLine(AppDomain.CurrentDomain.BaseDirectory + "important.txt", 1);




        public string message2;

        public Form1(string message) // this takes username from Login Form and Uses it at top right of tool and when connecting to console to display username
        {


            InitializeComponent();
            message2 = message;

        }



        // Reads certain line in .txt file //
        static string ReadSpecificLine(string filePath, int lineNumber)
        {
            string content = null;
            try
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    for (int i = 1; i < lineNumber; i++)
                    {
                        file.ReadLine();

                        if (file.EndOfStream)
                        {
                            Console.WriteLine($"End of file.  The file only contains {i} lines.");
                            break;
                        }
                    }
                    content = file.ReadLine();
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("There was an error reading the file: ");
                Console.WriteLine(e.Message);
            }

            return content;

        }




        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            try
            {
                JRPC.Connect();
                if (JRPC.activeConnection == true)
                {
                    barHeaderItem1.Caption = "ACTIVE";
                    barHeaderItem1.Appearance.ForeColor = Color.Green;
                    JRPC.XNotify("[" + message2 +"]" + " Connected Successfully!");

                }
            }
            catch (Exception)
            {
                barHeaderItem1.Caption = "IDLE";
                barHeaderItem1.Appearance.ForeColor = Color.Red;
                MessageBox.Show("Failed to Connect", "Please check your Plugins!");
            }
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            try
            {
                if (JRPC.activeConnection == true)
                {
                    JRPC.RebootConsole();
                    MessageBox.Show("Rebooting Console Now", "DMONET");
                }
            }
            catch (Exception)
            {
                JRPC.Connect();
                JRPC.RebootConsole();
                MessageBox.Show("Rebooting Console Now", "DMONET");
            }
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            string a;
            a = Application.StartupPath + "\\Xbox360ScreenShot.png";
            JRPC.xbConsole.ScreenShot(a);
            System.Diagnostics.Process.Start(Application.StartupPath + "\\Xbox360ScreenShot.png");
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            try
            {
                string Dir;
                Dir = JRPC.xbConsole.DebugTarget.RunningProcessInfo.ProgramName;
                var xexPath = @"Hdd:\" + Dir;
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }

            catch (Exception) { MessageBox.Show("please connect to console first"); }
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            QuickLaunchForm qlform = new QuickLaunchForm();
            qlform.Show();
        }

        private void tileItem1_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + Bo3 + "\\default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }

            catch (Exception) { MessageBox.Show("please connect to console first"); }
        }

        private void tileItem4_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + Bo2 + "\\default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }

            catch (Exception) { MessageBox.Show("please connect to console first"); }
        }

        private void tileItem5_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + BlackOps + "\\default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }

            catch (Exception) { MessageBox.Show("please connect to console first"); }
        }

        private void tileItem6_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + Aw + "\\default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }

            catch (Exception) { MessageBox.Show("please connect to console first"); }
        }

        private void tileItem7_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + Ghost1 + "\\" + "default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }
            catch (Exception) { MessageBox.Show("please connect to console first"); }
        }

        private void tileItem8_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + mW3 + "\\default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }
            catch (Exception) { MessageBox.Show("please connect to console first"); }
        }

        private void tileItem9_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + mw2 + "\\default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }
            catch (Exception) { MessageBox.Show("please connect to console first"); }
        }

        private void tileItem15_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            SKATE3 skate3 = new SKATE3();
            skate3.Show();
        }
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {

            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        private void accordionControlElement9_Click(object sender, EventArgs e)
        {

        }

        private void tileItem15_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + skate3 + "\\default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }
            catch (Exception) { MessageBox.Show("please connect to console first"); }
        }

        private void tileItem10_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + gtaV + "\\default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }
            catch (Exception) { MessageBox.Show("please connect to console first"); }
        }

        private void tileItem11_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + gtaSA + "\\default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }
            catch (Exception) { MessageBox.Show("please connect to console first"); }
        }

        private void tileItem12_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + re4 + "\\default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }
            catch (Exception) { MessageBox.Show("please connect to console first"); }
        }

        private void tileItem13_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + Halo3 + "\\default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }
            catch (Exception) { MessageBox.Show("please connect to console first"); }

        }

        private void tileItem14_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + dS2 + "\\default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
            }
            catch (Exception)
            {
                MessageBox.Show("please connect to console first");
            }
        }

        private void tileItem16_RightItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            try
            {
                var xexPath = @"Hdd:\" + GameFolder + "\\" + haloReach + "\\default.xex";
                JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);

            }
            catch (Exception)
            {

                MessageBox.Show("please connect to console first");                
            }
        }

        private void tileItem9_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            MW2 mw2 = new MW2();
            mw2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            labelControl4.Text = "                                                                                                              " + labelControl4.Text; // this is the moving text
            labelControl1.Text = "                                                                                                              " + new WebClient().DownloadString("https://pastebin.com/raw/QWJTgjny");
            barStaticItem2.Caption = message2;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            char[] array = labelControl4.Text.ToCharArray(); // this starts the moving text
            char[] array2 = new char[array.Length];
            int num = array.Length;
            int num2 = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i + 1 < array.Length)
                {
                    array2[i] = array[i + 1];
                }
                else
                {
                    array2[num - 1] = array[num2];
                }
            }
            labelControl4.Text = new string(array2);
            char[] array3 = labelControl1.Text.ToCharArray(); // this starts the moving text
            char[] array4 = new char[array3.Length];
            int num4 = array3.Length;
            int num5 = 0;
            for (int i = 0; i < array3.Length; i++)
            {
                if (i + 1 < array3.Length)
                {
                    array4[i] = array3[i + 1];
                }
                else
                {
                    array4[num4 - 1] = array3[num5];
                }
            }
            labelControl1.Text = new string(array4);
        }

        private void tileItem18_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            INIEDITOR inieditor = new INIEDITOR();
            inieditor.Show();
        }

        private void tileItem4_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            BO2 bo2 = new BO2();
            bo2.Show();
        }

        private void accordionControlElement9_Click_1(object sender, EventArgs e)
        {

        }

        private void accordionControlElement10_Click(object sender, EventArgs e)
        {

        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            SAINTSROW sr = new SAINTSROW();
            sr.Show();
        }

        private void tileItem10_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

        }

        private void fluentDesignFormContainer1_Click(object sender, EventArgs e)
        {

        }

        private void tileItem1_RightItemClick_1(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var xexPath = @"Hdd:\" + GameFolder + "\\" + SaintsRow + "\\default.xex";
            JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            Byte[] buffer = { 0x0 };
            Byte[] buffer2 = { 0x0 };
            JRPC.GetMemory(2417350948U, 0); // reads first byte to see if Guide.MP.Purchase.xex is loaded

            if (buffer[0] == buffer2[0])
            {
                MessageBox.Show("Guide.MP.Purchase.xex is not loaded");
            }
            else
            {
                byte[] xampatch3 = { 0x48, 0x00, 0x00, 0xC8 };
                byte[] xampatch2 = { 0x60, 0x00, 0x00, 0x00 };
                byte[] xampatch1 = {0x38, 0x80, 0x00, 0x05, 0x80, 0x63, 0x00, 0x1C, 0x90, 0x83, 0x00, 0x04,0x38, 0x80, 0x09, 0xC4, 0x90, 0x83, 0x00, 0x08, 0x38, 0x60, 0x00, 0x00,0x4E, 0x80, 0x00, 0x20};
                uint memoryWrote2 = 0;
                JRPC.xbConsole.DebugTarget.SetMemory(0x8168A6F8, 28, xampatch1, out memoryWrote2);
                JRPC.xbConsole.DebugTarget.SetMemory(0x818E9BE4, 4, xampatch3, out memoryWrote2);
                JRPC.xbConsole.DebugTarget.SetMemory(0x818EE414, 4, xampatch2, out memoryWrote2);
                JRPC.xbConsole.DebugTarget.SetMemory(0x9015D860, 4, xampatch2, out memoryWrote2);
                JRPC.xbConsole.DebugTarget.SetMemory(0x9015D924, 4, xampatch2, out memoryWrote2);
                MessageBox.Show("Guide.MP.Purchase.xex is loaded and patched");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tileItem12_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            RE4 re4HD = new RE4();
            re4HD.Show();
        }

        private void tileItem14_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            DS2 ds2form = new DS2();
            ds2form.Show();
        }

        private void tileItem4_ItemClick_1(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            DeadRising2otf DR2OTF = new DeadRising2otf();
            DR2OTF.Show();
        }

        private void tileItem4_RightItemClick_1(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var xexPath = @"Hdd:\" + GameFolder + "\\" + DeadRising2OTF + "\\default.xex";
            JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
        }

        private void accordionControlElement10_Click_1(object sender, EventArgs e)
        {

        }

        private void tileItem5_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            PeekNPoke pnk = new PeekNPoke();
            pnk.Show();
        }

        private void tileItem17_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            consoleInfo cInfo = new consoleInfo();
            cInfo.Show();
        }
    }
}

