using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Desktop_App
{
    public partial class Form1 : Form
    {
        int cookieClick = 1;
        int Cprice = 5;
        int cookies = 0;

        int Gprice = 10;
        int Grandma = 0;

        int Fprice = 100;
        int Farm = 0;

        int CPS = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            label1.Text = cookieClick.ToString();
            try
            {
                string connstring = "server=localhost;uid=root;pwd=;database=dbs10041809;";
                //string connstring = "server=rdbms.strato.de;uid=dbu2577448;pwd=KabouterST06;database=dbs10041809;";
                MySqlConnection conn = new MySqlConnection
                {
                    ConnectionString = connstring
                };
                conn.Open();
                string sql = "SELECT * FROM users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                label3.Text = "username" + Environment.NewLine;
                label13.Text = "password" + Environment.NewLine;
                while (reader.Read())
                {
                    
                    label3.Text += reader["username"] + Environment.NewLine;
                    label13.Text += reader["password"] + Environment.NewLine;
                }
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            cookies += cookieClick;
            label4.Text = cookies.ToString();
            //pictureBox2.Size = new Size(275, 275);
            //pictureBox2.Size = new Size(300, 300);
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            cookies = CPS + cookies;
            label4.Text = cookies.ToString();
        }
        public void Cupdate()
        {
            label10.Text = CPS.ToString();
            label4.Text = cookies.ToString();
        }
        private void UpgradeC_Click_2(object sender, EventArgs e)
        {
            if (cookies >= Cprice)
            {
                cookies -= Cprice;
                cookieClick++;
                Cprice += 5;
                label2.Text = Cprice.ToString();
                label1.Text = cookieClick.ToString();
                Cupdate();
            }
        }
        private void UpgradeG_Click(object sender, EventArgs e)
        {
            if (cookies >= Gprice)
            {
                cookies -= Gprice;
                Grandma++;
                Gprice += 10;
                CPS++;
                label5.Text = Gprice.ToString();
                label6.Text = Grandma.ToString();
                Cupdate();
            }
        }

        private void UpgradeF_Click_1(object sender, EventArgs e)
        {
            if (cookies >= Fprice)
            {
                cookies -= Fprice;
                Farm++;
                Fprice += 50;
                CPS += 5;
                label12.Text = Fprice.ToString();
                label11.Text = Farm.ToString();
                Cupdate();
            }
                

        }

        

        private void Button2_Click(object sender, EventArgs e)
        {
            //if (textBox1 == reader["password"])
            //{

            //}
        }
    }
}




