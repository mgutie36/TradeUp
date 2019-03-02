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
    public partial class AddTextBook : Form
    {
        string usernameCopy;
        string isbnCopy;
        string titleCopy;
        string authorCopy;
        int logNumber; 

        public string conString = "Data Source=DESKTOP-CUJ78IF;Initial Catalog=TradeUpDB;Integrated Security=True";

        public AddTextBook()
        {
            InitializeComponent();
        }

        public AddTextBook(string username)
        {
            InitializeComponent();
            usernameCopy = username;
      
        }

        public void InsertIntoDB()
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string queryString = $"INSERT INTO [TradeUpDB].[dbo].[TextBook] VALUES ('{isbnCopy}','{titleCopy}','{authorCopy}');";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }

            using (SqlConnection connection = new SqlConnection(conString))
            {
                string queryString = "SELECT MAX(log#) FROM [TradeUpDB].[dbo].[TextBook];";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                logNumber = (int)command.ExecuteScalar();
                command.Connection.Close();
            }

            using (SqlConnection connection = new SqlConnection(conString))
            {
                string queryString = $"INSERT INTO[TradeUpDB].[dbo].[Post] VALUES('{usernameCopy}', '{logNumber}'); ";;
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
           
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            isbnCopy = isbnTextBox.Text;
            titleCopy = titleTextBox.Text;
            authorCopy = authorTextBox.Text;

            InsertIntoDB();

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
