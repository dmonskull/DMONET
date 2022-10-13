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
    public partial class SAINTSROW : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        JRPC JRPC = new JRPC();
        public SAINTSROW()
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

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            string a;
            a = Application.StartupPath + "\\saintsrowScreenShot.png";
            JRPC.xbConsole.ScreenShot(a);
            System.Diagnostics.Process.Start(Application.StartupPath + "\\saintsrowScreenShot.png");
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            string Dir;
            Dir = JRPC.xbConsole.DebugTarget.RunningProcessInfo.ProgramName;
            var xexPath = @"Hdd:\" + Dir;
            JRPC.xbConsole.Reboot(xexPath, xexPath.Substring(0, xexPath.LastIndexOf(@"\", StringComparison.Ordinal)), null, XboxRebootFlags.Title);
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;

        }
        private bool weapon;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!jump)
            {
                simpleButton2.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
            {
                "give_player_n_weapons 7"
            });
            }
            else
            {
                simpleButton2.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
{
                "give_player_n_weapons 0"
});
            }
            weapon = !weapon;
        }

        private void SAINTSROW_Load(object sender, EventArgs e)
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
        private bool jump;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (!jump)
            {
                simpleButton2.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
{
                "Jump_height 21"
});
            }
            else
            {
                simpleButton2.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
{
                "Jump_height 1"
});
            }

            jump = !jump;
        }

        private bool uammo;
        private void simpleButton3_Click(object sender, EventArgs e)
        {

            if (!uammo)
            {
                simpleButton3.ForeColor = Color.Green;
                JRPC.SetMemory(2204058237U, new byte[]
                {
                    1
                });
            }
            else
            {
                simpleButton3.ForeColor = Color.Red;
                JRPC.SetMemory(2204058237U, new byte[1]);
            }
            uammo = !uammo;
        }

        private bool cash;
        private void simpleButton4_Click(object sender, EventArgs e)
        {

            if (!cash)
            {
                simpleButton4.ForeColor = Color.Green;
                JRPC.SetMemory(3260839472U, new byte[]
{
                    119,
                    119,
                    119,
                    119
});

            }
            else
            {
                simpleButton4.ForeColor = Color.Red;
                JRPC.SetMemory(3260839472U, new byte[]
                {
                        byte.MaxValue,
                        byte.MaxValue,
                        byte.MaxValue,
                        byte.MaxValue
                });
            }
            cash = !cash;
        }
        private bool walk;
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (!walk)
            {
                simpleButton5.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
{
                "item_glows"
});
            }
            else
            {
                simpleButton5.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
{
                "item_glows"
});
            }

            walk = !walk;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            JRPC.CallVoid(2187578128U, new object[]
            {
                textEdit1.Text
            }) ;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "vomit"
});
        }

        public uint[] PLAYERS_HEALTH_BARX = new uint[]
{
            3260816936U,
            3260839064U,
            3260881624U,
            3260903752U,
            3260925880U,
            3260946312U,
            3260968440U,
            3260990568U,
            3261011000U,
            3261033128U,
            3261055256U,
            3261119944U
};

        private bool god;
        private void simpleButton7_Click_1(object sender, EventArgs e)
        {
            if (!god)
            {
                simpleButton7.ForeColor = Color.Green;
                foreach (uint address in PLAYERS_HEALTH_BARX)
                {
                    JRPC.SetMemory(address, new byte[]
                    {
                        100
                    });
                }
            }
            else
            {
                simpleButton7.ForeColor = Color.Red;
                foreach (uint address in PLAYERS_HEALTH_BARX)
                {
                    JRPC.SetMemory(address, new byte[]
                    {
                        1
                    });
                }
            }

            god = !god;
        }

        private bool recoil;
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            if (!recoil)
            {
                simpleButton9.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
{
                "recoil 0"
});
            }
            else
            {
                simpleButton9.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
{
                "recoil 1"
});
            }

            recoil = !recoil;
        }

        private bool invis;
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            if (!invis)
            {
                simpleButton10.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "Nathaniel_hack"
                });
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "Nathaniel_hack_alpha 0"
                });
            }
            else
            {
                simpleButton10.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "Nathaniel_hack"
                });
            }

            invis = !invis;
        }
        private bool turret;
        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (!turret)
            {
                simpleButton11.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "turret"
                });
            }
            else
            {
                simpleButton11.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "turret"
                });
            }

            turret = !turret;
        }

        private bool fps;
        private void simpleButton12_Click(object sender, EventArgs e)
        {
            if (!fps)
            {
                simpleButton12.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "show_fps"
                });
            }
            else
            {
                simpleButton12.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "show_fps"
                });
            }

            fps = !fps;
        }

        private bool rlevel;
        private void simpleButton13_Click(object sender, EventArgs e)
        {
            if (!rlevel)
            {
                simpleButton13.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "R_level"
                });
            }
            else
            {
                simpleButton13.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "R_level"
                });
            }

            rlevel = !rlevel;
        }

        private bool rsky;
        private void simpleButton14_Click(object sender, EventArgs e)
        {
            if (!rsky)
            {
                simpleButton14.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "R_skybox"
                });
            }
            else
            {
                simpleButton14.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "R_skybox"
                });
            }

            rsky = !rsky;
        }

        private bool rshadows;
        private void simpleButton15_Click(object sender, EventArgs e)
        {
            if (!rshadows)
            {
                simpleButton15.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "r_shadows"
                });
            }
            else
            {
                simpleButton15.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "r_shadows"
                });
            }

            rshadows = !rshadows;
        }

        private bool ritems;
        private void simpleButton16_Click(object sender, EventArgs e)
        {
            if (!ritems)
            {
                simpleButton16.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "R_static"
                });
            }
            else
            {
                simpleButton16.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "R_static"
                });
            }

            ritems = !ritems;
        }

        private bool rchar;
        private void simpleButton17_Click(object sender, EventArgs e)
        {
            if (!rchar)
            {
                simpleButton17.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "R_chars"
                });
            }
            else
            {
                simpleButton17.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "R_chars"
                });
            }

            rchar = !rchar;
        }

        private bool rfog;
        private void simpleButton21_Click(object sender, EventArgs e)
        {
            if (!rfog)
            {
                simpleButton21.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "fog"
                });
            }
            else
            {
                simpleButton21.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "fog"
                });
            }

            rfog = !rfog;
        }

        private bool gdebug;
        private void simpleButton18_Click(object sender, EventArgs e)
        {
            if (!gdebug)
            {
                simpleButton18.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "glare_debug"
                });
            }
            else
            {
                simpleButton18.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "glare_debug"
                });
            }

            gdebug = !gdebug;
        }

        private bool ldebug;
        private void simpleButton20_Click(object sender, EventArgs e)
        {
            if (!ldebug)
            {
                simpleButton20.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "R_lights_debug"
                });
            }
            else
            {
                simpleButton20.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "R_lights_debug"
                });
            }

            ldebug = !ldebug;
        }

        private bool pPOVdebug;
        private void simpleButton19_Click(object sender, EventArgs e)
        {
            if (!pPOVdebug)
            {
                simpleButton19.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "r_player_pov"
                });
            }
            else
            {
                simpleButton19.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "r_player_pov"
                });
            }

            pPOVdebug = !pPOVdebug;
        }

        private bool occludersdebug;
        private void simpleButton22_Click(object sender, EventArgs e)
        {
            if (!occludersdebug)
            {
                simpleButton22.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "r_occluders"
                });
            }
            else
            {
                simpleButton22.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "r_occluders"
                });
            }

            occludersdebug = !occludersdebug;
        }

        private bool occludersdebug2;
        private void simpleButton23_Click(object sender, EventArgs e)
        {
            if (!occludersdebug2)
            {
                simpleButton23.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "r_rel_occluders"
                });
            }
            else
            {
                simpleButton23.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "r_rel_occluders"
                });
            }

            occludersdebug2 = !occludersdebug2;
        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {
            JRPC.CallVoid(0x8263cb10, new object[]
            {
                    "set_time_of_day 12"
            });
        }

        private void simpleButton26_Click(object sender, EventArgs e)
        {
            JRPC.CallVoid(0x8263cb10, new object[]
{
                    "set_time_of_day 1"
});
        }

        private void simpleButton25_Click(object sender, EventArgs e)
        {
            JRPC.CallVoid(0x8263cb10, new object[]
{
                    "set_time_of_day 20"
});
        }

        private void simpleButton27_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool fperson;
        private void simpleButton27_Click_1(object sender, EventArgs e)
        {
            if (!fperson)
            {
                simpleButton27.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "Nathaniel_hack"
                });
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "Nathaniel_hack_alpha 0"
                });
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "camera_radius 4"
                });
            }
            else
            {
                simpleButton27.ForeColor = Color.Red;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "Nathaniel_hack"
                });
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                    "camera_radius 1"
                });
            }

            fperson = !fperson;
        }

        private void simpleButton28_Click(object sender, EventArgs e)
        {

                simpleButton28.ForeColor = Color.Green;
                JRPC.CallVoid(0x8263cb10, new object[]
                {
                "hood_explore_all"
                });

        }

        private void simpleButton29_Click(object sender, EventArgs e)
        {
            simpleButton29.ForeColor = Color.Green;
            JRPC.CallVoid(0x8263cb10, new object[]
            {
                "hood_win_all"
            });
        }

        private void simpleButton30_Click(object sender, EventArgs e)
        {
            JRPC.CallVoid(0x8263cb10, new object[]
            {
                "player_set_name " + textEdit2.Text
            });
            simpleButton30.ForeColor = Color.Green;
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


		private void simpleButton31_Click(object sender, EventArgs e)
        {

        }

        private bool freeze;
        private void simpleButton31_Click_1(object sender, EventArgs e)
        {
            if (!freeze)
            {
                simpleButton23.ForeColor = Color.Green;
                JRPC.SetMemory(2204061010U, new byte[]
                {
                    1
                });
            }
            else
            {
                simpleButton23.ForeColor = Color.Red;
                JRPC.SetMemory(2204061010U, new byte[]
                {
                    0
                });
            }

            freeze = !freeze;
        }

        private bool timerbool;
        private void simpleButton32_Click(object sender, EventArgs e)
        {
            if (!timerbool)
            {
                simpleButton32.ForeColor = Color.Green;
                timer1.Start();
                timer2.Start();
            }
            else
            {
                simpleButton32.ForeColor = Color.Red;
                timer1.Stop();
                timer2.Stop();
            }
            timerbool = !timerbool;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            JRPC.CallVoid(0x8263cb10, new object[]
            {
                "char_ambient 148 0 211"
            });
            Thread.Sleep(1000);
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "char_ambient 75 0 130"
});
            Thread.Sleep(1000);
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "char_ambient 0 0 255"
});
            Thread.Sleep(1000);
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "char_ambient 0 255 0"
});
            Thread.Sleep(1000);
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "char_ambient 255 255 0"
});
            Thread.Sleep(1000);
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "char_ambient 255 127 0"
});
            Thread.Sleep(1000);
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "char_ambient 255 0 0"
});
            Thread.Sleep(1000);

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "level_ambient 255 0 0"
});
            Thread.Sleep(1000);
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "level_ambient 255 127 0"
});
            Thread.Sleep(1000);
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "level_ambient 255 255 0"
});
            Thread.Sleep(1000);
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "level_ambient 0 255 0"
});
            Thread.Sleep(1000);
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "level_ambient 0 0 255"
});
            Thread.Sleep(1000);
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "level_ambient 75 0 130"
});
            Thread.Sleep(1000);
            JRPC.CallVoid(0x8263cb10, new object[]
{
                "level_ambient 148 0 211"
});
            Thread.Sleep(1000);
        }

        private void simpleButton33_Click(object sender, EventArgs e)
        {
            simpleButton33.ForeColor = Color.Green;
            JRPC.CallVoid(0x8263cb10, new object[]
            {
                "activity_unlock_levels"
            });
        }

        private void simpleButton34_Click(object sender, EventArgs e)
        {
            simpleButton34.ForeColor = Color.Green;
            JRPC.CallVoid(0x8263cb10, new object[]
            {
                "cheats_unlock_all"
            });
        }

        private void simpleButton35_Click(object sender, EventArgs e)
        {
            JRPC.CallVoid(0x8263cb10, new object[]
            {
                "flip_car"
            });
        }

        private void simpleButton36_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text == "Blunt")
            {
                JRPC.SetMemory(0x827CF46F, new byte[]
                {
                    70
                });
            }
            if (comboBoxEdit1.Text == "Joint")
            {
                JRPC.SetMemory(0x827CF46F, new byte[]
                {
                    66
                });
            }
            if (comboBoxEdit1.Text == "Beer")
            {
                JRPC.SetMemory(0x827CF46F, new byte[]
                {
                    65
                });
            }
        }
    }
}
