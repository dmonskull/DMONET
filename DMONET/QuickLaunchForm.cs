using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMONET
{
    public partial class QuickLaunchForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public QuickLaunchForm()
        {
            InitializeComponent();
        }
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {

            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "important.txt", richTextBox2.Text);
        }

        private void QuickLaunchForm_Load(object sender, EventArgs e)
        {
            richTextBox2.Text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "important.txt");
        }
    }
}
