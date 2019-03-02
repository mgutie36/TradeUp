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
    public partial class SignUp : Form
    {
        public string conString = "Data Source=DESKTOP-CUJ78IF;Initial Catalog=TradeUpDB;Integrated Security=True";

        private string username;
        private string password;
        private string firstName;
        private string lastName;
        private string phone; 

        public SignUp()
        {
            InitializeComponent();
           

        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            username = userNameTextBox.Text;
            password = passwordTextBox.Text;
            firstName = firstNameTextBox.Text;
            lastName = lastNameTextBox.Text;
            phone = phoneTextBox.Text;

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = $"insert into [TradeUpDB].[dbo].[User] values('{username}','{password}','{firstName}','{lastName}','{phone}'); ";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();

            }

            con.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
    
}
