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


namespace DMONET
{
    public partial class INIEDITOR : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        JRPC JRPC = new JRPC();
        public INIEDITOR()
        {
            InitializeComponent();
        }

        private void INIEDITOR_Load(object sender, EventArgs e)
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            JRPC.xbConsole.ReceiveFile(AppDomain.CurrentDomain.BaseDirectory + this.textEdit1.Text, this.comboBoxEdit1.SelectedItem + this.textEdit1.Text);
            this.richTextBox2.Text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + this.textEdit1.Text);
            bool flag2 = this.richTextBox2.Text.Contains("plugin1");
            if (flag2)
            {
                this.richTextBox2.SelectionStart = this.richTextBox2.Find("plugin1");
                this.richTextBox2.ScrollToCaret();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + this.textEdit1.Text, this.richTextBox2.Text);
            JRPC.xbConsole.SendFile(AppDomain.CurrentDomain.BaseDirectory + this.textEdit1.Text, this.comboBoxEdit1.Text + this.textEdit1.Text);
            bool flag2 = this.richTextBox2.Text.Contains("plugin1");
            if (flag2)
            {
                this.richTextBox2.SelectionStart = this.richTextBox2.Find("plugin1");
                this.richTextBox2.ScrollToCaret();
            }
        }
    }
}
