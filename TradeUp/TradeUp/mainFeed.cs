//Marco Gutierrez TradeUp
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
    public partial class mainFeed : Form
    {
        public string conString = "Data Source=DESKTOP-CUJ78IF;Initial Catalog=TradeUpDB;Integrated Security=True";
        DataTable tradeQuery = new DataTable();
        profile profileForm;
        LogOn LogOn;
        Trade trade;
        AddTextBook add;
        BookDetails details;
        TradeDetails tradeDetails;

        string username;

        public string Username { get => username; set => username = value; }

        public mainFeed()
        {
            InitializeComponent();
            PopulateListBox();
      
        }

        public mainFeed(string username)
        {
            InitializeComponent();
            Username = username;
            PopulateListBox();
            CheckForTradeRequests();
            searchTextBox.KeyDown += new KeyEventHandler(tb_KeyDown);

        }



        private void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profileForm = new profile(username);
            profileForm.Show(); 
        }

        private void mainFeed_Load(object sender, EventArgs e)
        {

        }

        private void PopulateListBox()
        {
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM[TradeUpDB].[dbo].[TextBook] T, [TradeUpDB].[dbo].[Post] P WHERE T.log# = P.textBookLog# and P.posterUsername != '{username}';", con);
            {
                DataTable textbook = new DataTable();
                adapter.Fill(textbook);

                mainFeedListBox.DisplayMember = "title";
                mainFeedListBox.ValueMember = "post#";
                mainFeedListBox.DataSource = textbook;
             
            }
            con.Close(); 

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOn = new LogOn();
            LogOn.Visible = true;
            this.Close();

        }

        private void addTextBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add = new AddTextBook(username);
            add.Show();
        }


        private void tradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trade = new Trade(username);
            trade.Show();
        }

        private void mainFeedListBox_DoubleClick(object sender, EventArgs e)
        {
            string postNumber = mainFeedListBox.SelectedValue.ToString();
            details = new BookDetails(postNumber);
            details.Show();
        }

        private void CheckForTradeRequests()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = $"SELECT T.senderUserName FROM[TradeUpDB].[dbo].[TradeRequest] T, [TradeUpDB].[dbo].[Post] P WHERE T.post# = P.Post# and P.posterUserName = '{username}';";
                string z = $"SELECT COUNT(*)  FROM[TradeUpDB].[dbo].[TradeRequest] T, [TradeUpDB].[dbo].[Post] P WHERE T.post# = P.Post# and P.posterUserName = '{username}' and T.tradeReviewed !='YES';";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlCommand cmdTwo = new SqlCommand(z, con);


                string tradeYN = (string)cmd.ExecuteScalar();
                int isNull = (int)cmdTwo.ExecuteScalar();

                con.Close();

                if (tradeYN == null || isNull == 0)
                {

                }
                else
                {
                    MessageBox.Show("You have a trade request!");

                    SqlConnection conn = new SqlConnection(conString);
                    using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT P.post#, T.req#, B.title,  T.senderPhone, T.senderUsername, T.textBookOne, T.TextbookTwo, T.textBookThree FROM  [TradeUpDB].[dbo].[TradeRequest] T, [TradeUpDB].[dbo].[Post] P, [TradeUpDB].[dbo].[TextBook] B WHERE B.log# = P.textBookLog# and P.post# = T.post# and P.posterUsername = '{username}' and T.tradeReviewed !='YES' Order by P.post#;", conn))
                    {
                        adapter.Fill(tradeQuery);

                    }
                    con.Close();

                    tradeRequestButton.Visible = true; 
                }
            }

           
        }

        private void tradeRequestButton_Click(object sender, EventArgs e)
        {
            tradeRequestButton.Visible = false; 
            tradeDetails = new TradeDetails(tradeQuery,username);

            for (int i = 0; i < tradeQuery.Rows.Count; i++)
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    string queryString = $"UPDATE [TradeUpDB].[dbo].[TradeRequest] SET tradeReviewed = 'YES' WHERE post# = '{tradeQuery.Rows[i][0].ToString()}';";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }

            tradeDetails.Show();
        }

       
        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter & searchTextBox.Text == "")
            {
                SqlConnection con = new SqlConnection(conString);
                using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM[TradeUpDB].[dbo].[TextBook] T, [TradeUpDB].[dbo].[Post] P WHERE T.log# = P.textBookLog# and P.posterUsername != '{username}';", con))
                {
                    DataTable textbook = new DataTable();
                    adapter.Fill(textbook);

                    mainFeedListBox.DisplayMember = "title";
                    mainFeedListBox.ValueMember = "post#";
                    mainFeedListBox.DataSource = textbook;

                }
                con.Close();

            }
            else if (e.KeyCode == Keys.Enter)
            {
                SqlConnection con = new SqlConnection(conString);
                using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM[TradeUpDB].[dbo].[TextBook] T, [TradeUpDB].[dbo].[Post] P WHERE T.log# = P.textBookLog# and P.posterUsername != '{username}' and T.title LIKE '{searchTextBox.Text}';", con))
                {
                    DataTable textbook = new DataTable();
                    adapter.Fill(textbook);

                    mainFeedListBox.DisplayMember = "title";
                    mainFeedListBox.ValueMember = "post#";
                    mainFeedListBox.DataSource = textbook;

                }
                con.Close();

            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0); 
        }
    }
}
