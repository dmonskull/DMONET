using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DevExpress.XtraSplashScreen;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace DMONET
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {


        public LoginForm()
        {
            InitializeComponent();
        }


        private void login()   // you can use this to login from a SQL Database
        {
            SplashScreenManager.ShowForm(this, typeof(waitform), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Checking for User:  " + textEdit1.Text);
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }

            DB db = new DB();
            String username = textEdit1.Text;
            String password = textEdit2.Text;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn and `password` = @pass", db.getConnection());
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                Form1 Dash = new Form1(textEdit1.Text);
                SplashScreenManager.CloseForm();
                Hide();
                Dash.Show();
            }
            else
            {
                SplashScreenManager.CloseForm();
                MessageBox.Show("Failed to Login, check credentials and try again!");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(waitform), true, true, false); // this is useless, but it makes you an enjoyer :)
            SplashScreenManager.Default.SetWaitFormCaption("DMONET Enjoyer:  " + textEdit1.Text);
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm(); // useless till here
            Form1 Dash = new Form1(textEdit1.Text);
            Hide();
            Dash.Show();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.YouTube.com");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}