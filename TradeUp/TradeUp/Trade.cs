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
    public partial class Trade : Form
    {
        public string conString = "Data Source=DESKTOP-CUJ78IF;Initial Catalog=TradeUpDB;Integrated Security=True";
        string usernameCopy;
        string phone;
        string textbookOne;
        string textbookTwo;
        string textbookThree;


        public Trade()
        {
            InitializeComponent();
        }

        public Trade(string username)
        {
            InitializeComponent();
            usernameCopy = username;
            PopulateMainFeedListBox();
            PopulateUserListBox();


        }

        private void PopulateMainFeedListBox()
        {
            SqlConnection con = new SqlConnection(conString);
            using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM[TradeUpDB].[dbo].[TextBook] T, [TradeUpDB].[dbo].[Post] P WHERE T.log# = P.textBookLog# and P.posterUsername != '{usernameCopy}';", con))
            {
                DataTable textbook = new DataTable();
                adapter.Fill(textbook);

                mainFeedListBox.DataSource = textbook;
                mainFeedListBox.DisplayMember = "title";
                mainFeedListBox.ValueMember = "post#";
               

            }
            con.Close();

        }

        private void PopulateUserListBox()
        {
            SqlConnection con = new SqlConnection(conString);
            using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM[TradeUpDB].[dbo].[TextBook] T, [TradeUpDB].[dbo].[Post] P WHERE T.log# = P.textBookLog# AND P.posterUsername = '{usernameCopy}';", con))
            {
                DataTable textbookCopy = new DataTable();
                adapter.Fill(textbookCopy);
                userListBox.DataSource = textbookCopy;
                userListBox.DisplayMember = "title";
                userListBox.ValueMember = "title";


            }
            con.Close();
        }

        private void tradeButton_Click(object sender, EventArgs e)
        {
            GetSenderPhone();
            if (userListBox.SelectedItems.Count == 1)
            {
                DataRowView One = userListBox.SelectedItems[0] as DataRowView;
                

                using (SqlConnection connection = new SqlConnection(conString))
                {
                    string queryString = $"INSERT INTO [TradeUpDB].[dbo].[TradeRequest] VALUES ('{mainFeedListBox.SelectedValue.ToString()}','{usernameCopy}','{phone}','{One["title"].ToString()}','NULL','NULL','NULL');";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }

            }
            else if (userListBox.SelectedItems.Count == 2)
            {
                DataRowView One = userListBox.SelectedItems[0] as DataRowView;
                DataRowView Two = userListBox.SelectedItems[1] as DataRowView;


                using (SqlConnection connection = new SqlConnection(conString))
                {
                    string queryString = $"INSERT INTO [TradeUpDB].[dbo].[TradeRequest] VALUES ('{mainFeedListBox.SelectedValue.ToString()}','{usernameCopy}','{phone}','{One["title"].ToString()}','{Two["title"].ToString()}','NULL','NULL');";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }

            }
            else if (userListBox.SelectedItems.Count == 3)
            {
                DataRowView One = userListBox.SelectedItems[0] as DataRowView;
                DataRowView Two = userListBox.SelectedItems[1] as DataRowView;
                DataRowView Three = userListBox.SelectedItems[2] as DataRowView;



                using (SqlConnection connection = new SqlConnection(conString))
                {
                    string queryString = $"INSERT INTO [TradeUpDB].[dbo].[TradeRequest] VALUES ('{mainFeedListBox.SelectedValue.ToString()}','{usernameCopy}','{phone}','{One["title"].ToString()}','{Two["title"].ToString()}','{Three["title"].ToString()}','NULL');";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }

            }
            else
            {
                MessageBox.Show("Select Up to 3 Textbooks");
            }
        }

        private void GetSenderPhone()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = $"SELECT phone FROM[TradeUpDB].[dbo].[User] WHERE username = '{usernameCopy}';";
                SqlCommand cmd = new SqlCommand(q, con);

                phone = (string)cmd.ExecuteScalar();

                con.Close();
            }


        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
