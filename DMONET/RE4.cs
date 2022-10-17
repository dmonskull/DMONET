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
    public partial class RE4 : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        JRPC JRPC = new JRPC();
        public RE4()
        {
            InitializeComponent();
        }
        private void RE4_Load(object sender, EventArgs e)
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

        public uint SecondItemSlot = 3281685309U;
        public uint SecondItemSlotAmount = 3281685311U;
        public uint ThirdItemSlot = 3281685367U;
        public uint ThirdItemSlotAmount = 3281685367U;
        public uint FourthItemSlot = 3281685379U;

        public uint FirstAidSlotAmount = 3281685325U;
        public uint FirstAidSlot = 3281685323U;

        public byte ShotgunShells = 0x18;
        public byte MixedHerbsGRY = 0x15;
        public byte MixedHerbsGR = 0x14;
        public byte InfiniteLauncher = 0x6D;
        public byte PRL412 = 0x41;
        public byte ChicagoTypewriter = 0x34;
        public byte Handcannon = 0x37;
        public byte CombatKnife = 0x38;
        public byte Shotgun = 0x47;
        public byte RocketLauncherSpecial = 0x17;
        public byte MineThrower = 0x36;
        public byte RifleSemiInfaScope = 0x51;

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            try
            {
                JRPC.Connect();
                if (JRPC.activeConnection == true)
                {
                    barHeaderItem1.Appearance.ForeColor = Color.Green;
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
            a = Application.StartupPath + "\\RE4ScreenShot.png";
            JRPC.xbConsole.ScreenShot(a);
            System.Diagnostics.Process.Start(Application.StartupPath + "\\RE4ScreenShot.png");
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            string Dir;
            Dir = JRPC.xbConsole.DebugTarget.RunningProcessInfo.ProgramName;
            var xexPath = @"Hdd:\" + Dir;
            JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text == "Shotgun Shells")
            {
                JRPC.SetMemory(SecondItemSlot, new byte[]{ShotgunShells});
            }
            if (comboBoxEdit1.Text == "Mixed Herbs (G+R+Y)")
            {
                JRPC.SetMemory(SecondItemSlot, new byte[]{MixedHerbsGRY});
            }
            if (comboBoxEdit1.Text == "Infinite Launcher")
            {
                JRPC.SetMemory(SecondItemSlot, new byte[]{InfiniteLauncher});
            }
            if (comboBoxEdit1.Text == "P.R.L 412")
            {
                JRPC.SetMemory(SecondItemSlot, new byte[]{PRL412});
            }
            if (comboBoxEdit1.Text == "Chicago Typewriter")
            {
                JRPC.SetMemory(SecondItemSlot, new byte[] { ChicagoTypewriter });
            }
            if (comboBoxEdit1.Text == "Combat Knife")
            {
                JRPC.SetMemory(SecondItemSlot, new byte[] { CombatKnife });
            }
            if (comboBoxEdit1.Text == "Handcannon")
            {
                JRPC.SetMemory(SecondItemSlot, new byte[] { Handcannon });
            }
            if (comboBoxEdit1.Text == "Shotgun")
            {
                JRPC.SetMemory(SecondItemSlot, new byte[] { Shotgun });
            }
            if (comboBoxEdit1.Text == "Rocket Launcher Special")
            {
                JRPC.SetMemory(SecondItemSlot, new byte[] { RocketLauncherSpecial });
            }
            if (comboBoxEdit1.Text == "Mine Thrower")
            {
                JRPC.SetMemory(SecondItemSlot, new byte[] { MineThrower });
            }
            if (comboBoxEdit1.Text == "Rifle (semi auto) with Infared Scope")
            {
                JRPC.SetMemory(SecondItemSlot, new byte[] { RifleSemiInfaScope });
            }
        }


        public bool PTAS;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (!PTAS)
            {
                simpleButton2.ForeColor = Color.Green;
                JRPC.SetMemory(0xC265D848, new byte[]
                {
                0x0F, 0xFF, 0xFF, 0xFF
                });
            }
            else
            {
                simpleButton2.ForeColor = Color.Red;
                JRPC.SetMemory(0xC265D848, new byte[]
                {
                0x00, 0x00, 0x00, 0x00
                });
            }
            PTAS = !PTAS;

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit3.Text == "Shotgun Shells")
            {
                JRPC.SetMemory(FirstAidSlot, new byte[] { ShotgunShells });
            }
            if (comboBoxEdit3.Text == "Mixed Herbs (G+R+Y)")
            {
                JRPC.SetMemory(FirstAidSlot, new byte[] { MixedHerbsGRY });
            }
            if (comboBoxEdit3.Text == "Infinite Launcher")
            {
                JRPC.SetMemory(FirstAidSlot, new byte[] { InfiniteLauncher });
            }
            if (comboBoxEdit3.Text == "P.R.L 412")
            {
                JRPC.SetMemory(FirstAidSlot, new byte[] { PRL412 });
            }
            if (comboBoxEdit3.Text == "Chicago Typewriter")
            {
                JRPC.SetMemory(FirstAidSlot, new byte[] { ChicagoTypewriter });
            }
            if (comboBoxEdit3.Text == "Combat Knife")
            {
                JRPC.SetMemory(FirstAidSlot, new byte[] { CombatKnife });
            }
            if (comboBoxEdit3.Text == "Handcannon")
            {
                JRPC.SetMemory(FirstAidSlot, new byte[] { Handcannon });
            }
            if (comboBoxEdit3.Text == "Shotgun")
            {
                JRPC.SetMemory(FirstAidSlot, new byte[] { Shotgun });
            }
            if (comboBoxEdit3.Text == "Rocket Launcher Special")
            {
                JRPC.SetMemory(FirstAidSlot, new byte[] { RocketLauncherSpecial });
            }
            if (comboBoxEdit3.Text == "Mine Thrower")
            {
                JRPC.SetMemory(FirstAidSlot, new byte[] { MineThrower });
            }
            if (comboBoxEdit3.Text == "Rifle (semi auto) with Infared Scope")
            {
                JRPC.SetMemory(FirstAidSlot, new byte[] { RifleSemiInfaScope });
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit2.Text == "Shotgun Shells")
            {
                JRPC.SetMemory(ThirdItemSlot, new byte[] { ShotgunShells });
            }
            if (comboBoxEdit2.Text == "Mixed Herbs (G+R+Y)")
            {
                JRPC.SetMemory(ThirdItemSlot, new byte[] { MixedHerbsGRY });
            }
            if (comboBoxEdit2.Text == "Infinite Launcher")
            {
                JRPC.SetMemory(ThirdItemSlot, new byte[] { InfiniteLauncher });
            }
            if (comboBoxEdit2.Text == "P.R.L 412")
            {
                JRPC.SetMemory(ThirdItemSlot, new byte[] { PRL412 });
            }
            if (comboBoxEdit2.Text == "Chicago Typewriter")
            {
                JRPC.SetMemory(ThirdItemSlot, new byte[] { ChicagoTypewriter });
            }
            if (comboBoxEdit2.Text == "Combat Knife")
            {
                JRPC.SetMemory(ThirdItemSlot, new byte[] { CombatKnife });
            }
            if (comboBoxEdit2.Text == "Handcannon")
            {
                JRPC.SetMemory(ThirdItemSlot, new byte[] { Handcannon });
            }
            if (comboBoxEdit2.Text == "Shotgun")
            {
                JRPC.SetMemory(ThirdItemSlot, new byte[] { Shotgun });
            }
            if (comboBoxEdit2.Text == "Rocket Launcher Special")
            {
                JRPC.SetMemory(ThirdItemSlot, new byte[] { RocketLauncherSpecial });
            }
            if (comboBoxEdit2.Text == "Mine Thrower")
            {
                JRPC.SetMemory(ThirdItemSlot, new byte[] { MineThrower });
            }
            if (comboBoxEdit2.Text == "Rifle (semi auto) with Infared Scope")
            {
                JRPC.SetMemory(ThirdItemSlot, new byte[] { RifleSemiInfaScope });
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            JRPC.SetMemory(FirstAidSlotAmount, BitConverter.GetBytes((uint)this.numericUpDown3.Value));
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            JRPC.SetMemory(SecondItemSlotAmount, BitConverter.GetBytes((uint)this.numericUpDown2.Value));
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            JRPC.SetMemory(ThirdItemSlotAmount, BitConverter.GetBytes((uint)this.numericUpDown1.Value));
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {

        }
    }
}
