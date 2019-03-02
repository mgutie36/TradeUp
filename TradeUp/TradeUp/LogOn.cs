using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TradeUp
{
    public partial class LogOn : Form
    {
        mainFeed main;
        public string conString = "Data Source=DESKTOP-CUJ78IF;Initial Catalog=TradeUpDB;Integrated Security=True";
        string username;
        string password; 

        SignUp signUp;

        public LogOn()
        {
            InitializeComponent();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            signUp = new SignUp();
            signUp.Show();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            username = userNameTextBox.Text;
            password = passwordTextBox.Text;
            string result;

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = $"SELECT [userPassword] FROM [TradeUpDB].[dbo].[User] WHERE [username] = '{username}'; ";
                SqlCommand cmd = new SqlCommand(q, con);

                result = (string)cmd.ExecuteScalar();
                con.Close();
                if (result == password)
                {
                    main = new mainFeed(username);
                    this.Visible = false;
                    main.Show();
                   

                }
                else
                {
                    MessageBox.Show("Incorrect username or password.");
                }

            }

           
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);  
        }
    }
}
