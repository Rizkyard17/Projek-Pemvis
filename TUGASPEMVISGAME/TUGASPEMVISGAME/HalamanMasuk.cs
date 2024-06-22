using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TUGASPEMVISGAME
{
    public partial class HalamanMasuk : Form
    {
        public HalamanMasuk()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (username == "TDM" && password == "TDMGACOR")
            {
                // MessageBox.Show("Login berhasil");
                this.Hide();
                HalamanUtama mainForm = new HalamanUtama();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                // Show an error message
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
