using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCUS
{
    public partial class CCUS : Form
    {
        public string email;
        public string password;
        public string url;
        public string stateValue;
        public string folder { get; set; }
        public CCUS()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {   
            url = textBox1.Text;
            folder = folderBrowserDialog1.SelectedPath;
            email = emailBox.Text;
            password = passwordBox.Text;

            if (url != "" && folder != "" && stateValue != null)
            {
                Console.WriteLine(stateValue);
                navigate obj = new navigate();
                obj.BeforeTest(url, folder, email, password, true, stateValue);
            }
            else
            {
                MessageBox.Show("Se deben completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            emailBox.Text = Properties.Settings.Default.UserEmail;
            passwordBox.Text = Properties.Settings.Default.UserPassword;
            folderBrowserDialog1.SelectedPath = Properties.Settings.Default.UserFolder;
            textBox1.Text = Properties.Settings.Default.UserUrl;

            lblUbicacion.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                lblUbicacion.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            url = textBox1.Text;
            folder = folderBrowserDialog1.SelectedPath;
            email = emailBox.Text;
            password = passwordBox.Text;

            if (url != "" && folder != "" && stateValue != null)
            {
                navigate obj = new navigate();
                obj.BeforeTest(url, folder, email, password, false, stateValue);
            }
            else
            {
                MessageBox.Show("Se deben completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.UserEmail = emailBox.Text;
                Properties.Settings.Default.UserPassword = passwordBox.Text;
                Properties.Settings.Default.UserFolder = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.UserUrl = textBox1.Text;

                Properties.Settings.Default.Save();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = StateUs.SelectedIndex;
            stateValue = StateUs.Items[indice].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
