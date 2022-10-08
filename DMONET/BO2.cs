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
    public partial class BO2 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        JRPC JRPC = new JRPC();

        public BO2()
        {
            InitializeComponent();
        }


        public static uint g_freememory = 0x81aa2090;
        public static uint g_rguserinfo = 0x81aa2600;
        public static uint g_XamUserGetXUID = 0x816d7e78;
        public static uint g_XUserFindUserAddress = 0x81829018;

        private void BO2_Load(object sender, EventArgs e)
        {
            try
            {
                JRPC.Connect();
                if (JRPC.activeConnection == true)
                {

                    barHeaderItem1.Caption = "ACTIVE";
                    barHeaderItem1.Appearance.ForeColor = Color.Green;
                    MessageBox.Show("Connection Still Active", "StrawberryNet");

                }

                else
                {
                    barHeaderItem1.Caption = "IDLE";
                    barHeaderItem1.Appearance.ForeColor = Color.Red;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Connecting to Console", "StrawberryNet");
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
                    MessageBox.Show("Re-connected to Tool :)", "StrawberryNet");

                }

                else
                {
                    barHeaderItem1.Caption = "IDLE";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Re-Connecting to Console", "StrawberryNet");
            }
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            string a;
            a = Application.StartupPath + "\\BO2ScreenShot.png";
            JRPC.xbConsole.ScreenShot(a);
            System.Diagnostics.Process.Start(Application.StartupPath + "\\BO2ScreenShot.png");
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            string Dir;
            Dir = JRPC.xbConsole.DebugTarget.RunningProcessInfo.ProgramName;
            var xexPath = @"Hdd:\" + Dir;
            JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {

        }

        public static string ConvertStringToHex(string asciiString)
        {
            int num3;
            string str = "";
            string str2 = asciiString;
            for (int i = 0; i < str2.Length; i = num3 + 1)
            {
                int num2 = str2[i];
                if (num2 == 0)
                {
                    return str;
                }
                str = str + $"{Convert.ToUInt32(num2.ToString()):x2}";
                num3 = i;
            }
            return str;
        }
        private byte[] getBytes(byte[] test)
        {
            byte[] buffer = new byte[test.Length * 2];
            int index = 0;
            foreach (byte num3 in test)
            {
                buffer[index] = 0;
                buffer[index + 1] = num3;
                index += 2;
            }
            return buffer;
        }
        public static byte[] reverseBytes(string gamertag)
        {
            int num4;
            byte[] buffer = new byte[(gamertag.Length * 2) + 2];
            buffer[0] = 0;
            uint num = 1;
            for (int i = 0; i < gamertag.Length; i = num4 + 1)
            {
                char ch = gamertag[i];
                buffer[(uint)((UIntPtr)num)] = (byte)ch;
                uint num3 = num + 1;
                buffer[(uint)((UIntPtr)num3)] = 0;
                num = num3 + 1;
                num4 = i;
            }
            buffer[(uint)((UIntPtr)num)] = 0;
            return buffer;
        }
        public static byte[] hexString(string hex)
        {
            Func<int, byte> func = null;
            try
            {
                hex = hex.Replace(" ", "").Replace("0x", "");
                if (func == null)
                {
                    func = x => Convert.ToByte(hex.Substring(x, 2), 0x10);
                }
                Func<int, byte> selector = func;
                return (from x in Enumerable.Range(0, hex.Length)
                        where (x % 2) == 0
                        select x).Select<int, byte>(selector).ToArray<byte>();
            }
            catch (Exception)
            {
                return new byte[1];
            }
        }



        private void accordionControlElement9_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
        }



        public byte[] GetMem(uint Address, uint Length)
        {
            byte[] array;
            using (Mutex mutex = new Mutex(false, "MemComparisonMagicianMemEditLock"))
            {
                bool flag = !mutex.WaitOne(10000, false);
                if (flag)
                {
                    array = new byte[1];
                }
                else
                {
                    byte[] array2 = new byte[Length];
                    try
                    {
                        array2 = JRPC.GetMemory(Address, Length);
                    }
                    catch (Exception)
                    {
                    }
                    mutex.ReleaseMutex();
                    array = array2;
                }
            }
            return array;
        }

        private uint cheatNop = 2185854736U;
        private uint clientCommand = 2185237984U;
        public void sendClientCommand(string cmd)
        {
            byte[] array = new byte[4];
            array[0] = 57;
            array[1] = 96;
            bool flag = !this.GetMem(this.cheatNop, 4U).SequenceEqual(array);
            if (flag)
            {
                byte[] array2 = new byte[4];
                array2[0] = 57;
                array2[1] = 96;
                JRPC.SetMemory(this.cheatNop, array2);
            }
            JRPC.CallVoid(this.clientCommand, new object[]
            {
                0,
                cmd
            });
        }
        public void simpleButton1_Click(object sender, EventArgs e)
        {


        }


        public static byte[] StringToByteArray(string hex)
        {
            return (from x in Enumerable.Range(0, hex.Length)
                    where x % 2 == 0
                    select Convert.ToByte(hex.Substring(x, 2), 16)).ToArray<byte>();
        }
        public void statTimer_Tick(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
