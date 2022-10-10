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

        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
        }
    }
}
