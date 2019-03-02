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
    public partial class profile : Form
    {
        string usernameCopy;
        public string conString = "Data Source=DESKTOP-CUJ78IF;Initial Catalog=TradeUpDB;Integrated Security=True";


        public profile()
        {
            InitializeComponent();
        }

        public profile(string username)
        {
            InitializeComponent();
            usernameCopy = username;
            PopulateListBox();
            PopulateSuccess();
        }

        private void PopulateListBox()
        {
            SqlConnection con = new SqlConnection(conString);
            using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM[TradeUpDB].[dbo].[TextBook] T, [TradeUpDB].[dbo].[Post] P WHERE T.log# = P.textBookLog# AND P.posterUsername = '{usernameCopy}';", con))
            {
                DataTable textbook = new DataTable();
                adapter.Fill(textbook);

                userListBox.DataSource = textbook;
                userListBox.DisplayMember = "title";
                userListBox.ValueMember = "post#";
              

            }
            con.Close();

        }

        private void PopulateSuccess()
        {
            SqlConnection con = new SqlConnection(conString);
            using (SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM[TradeUpDB].[dbo].[Finalized] WHERE posterUsername = '{usernameCopy}' or senderUsername = '{usernameCopy}'", con))
            {
                DataTable textbook = new DataTable();
                adapter.Fill(textbook);

                dataGridView1.DataSource = textbook;
                
               

            }
            con.Close();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (userListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select Textbook");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    string queryString = $"DELETE FROM [TradeUpDB].[dbo].[Post] WHERE post# = '{userListBox.SelectedValue.ToString()}';";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }

            }

            PopulateListBox();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
