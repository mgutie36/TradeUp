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
    public partial class TradeDetails : Form
    {
        DataTable tradeQuery;
        string userName; 
        int i = 0;
        int tradeYn;
        public string conString = "Data Source=DESKTOP-CUJ78IF;Initial Catalog=TradeUpDB;Integrated Security=True";

        public TradeDetails()
        {
            InitializeComponent();
        }

        public TradeDetails(DataTable copy, string user)
        {
            InitializeComponent();
            tradeQuery = copy;
            userName = user;
            showDetails();
  
        }

        private void showDetails()
        {
            interestUpdate.Text = tradeQuery.Rows[i][2].ToString();
            senderUpdate.Text = tradeQuery.Rows[i][4].ToString();
            oneUpdate.Text = tradeQuery.Rows[i][5].ToString();
            twoUpdate.Text = tradeQuery.Rows[i][6].ToString();
            threeUpdate.Text = tradeQuery.Rows[i][7].ToString();

            i++;

            if (i >= tradeQuery.Rows.Count)
            {

                nextButton.Enabled = false;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            acceptButton.Enabled = true; 

            if (i < tradeQuery.Rows.Count)
            {
              
                showDetails();
            }
            else
            {
                nextButton.Enabled = false; 
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            acceptButton.Enabled = false;

            MessageBox.Show($"Please contact me at: {tradeQuery.Rows[i-1][3].ToString()} to complete trade!");

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = $"SELECT COUNT(*) FROM[TradeUpDB].[dbo].[Finalized] WHERE post# = '{tradeQuery.Rows[i - 1][0].ToString()}' and posterUsername = '{userName}';";
                SqlCommand cmd = new SqlCommand(q, con);

                tradeYn = (int)cmd.ExecuteScalar();

                con.Close();
            }

            if (tradeYn == 0)
            {

                using (SqlConnection connection = new SqlConnection(conString))
                {
                    string queryString = $"INSERT INTO [TradeUpDB].[dbo].[Finalized] VALUES ('{tradeQuery.Rows[i - 1][0].ToString()}','{userName}','{tradeQuery.Rows[i - 1][2].ToString()}','{ tradeQuery.Rows[i - 1][4].ToString()}','{tradeQuery.Rows[i - 1][3].ToString()}','{tradeQuery.Rows[i - 1][5].ToString()}','{tradeQuery.Rows[i - 1][6].ToString()}','{tradeQuery.Rows[i - 1][7].ToString()}');";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    string queryString = $"UPDATE [TradeUpDB].[dbo].[Finalized] SET posterUsername = '{userName}', bookOfInterest = '{tradeQuery.Rows[i - 1][2].ToString()}', senderUserName = '{ tradeQuery.Rows[i - 1][4].ToString()}', senderPhone = '{tradeQuery.Rows[i - 1][3].ToString()}', bookOne = '{tradeQuery.Rows[i - 1][5].ToString()}', bookTwo = '{tradeQuery.Rows[i - 1][6].ToString()}', bookThree = '{tradeQuery.Rows[i - 1][7].ToString()}' WHERE Post# = '{tradeQuery.Rows[i - 1][0].ToString()}';";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }

            }


        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
