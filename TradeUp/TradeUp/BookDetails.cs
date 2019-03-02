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
    public partial class BookDetails : Form
    {
        string postNumber;
        string posterUsername;
        string title;
        string author;
        string isbn; 

        public string conString = "Data Source=DESKTOP-CUJ78IF;Initial Catalog=TradeUpDB;Integrated Security=True";


        public BookDetails()
        {
            InitializeComponent();
        }

        public BookDetails(string postNumberCopy)
        {
            InitializeComponent();
            postNumber = postNumberCopy;
            PopulateTextBoxes();

        }

        public void PopulateTextBoxes()
        {
            SqlConnection con = new SqlConnection(conString);
            string q = $"SELECT P.posterUsername, T.isbn, T.title, T.author FROM[TradeUpDB].[dbo].[TextBook] T, [TradeUpDB].[dbo].[Post] P WHERE T.log# = P.textBookLog# and P.post# = '{postNumber}';";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            var dr = cmd.ExecuteReader();
            if (dr.Read()) // Read() returns TRUE if there are records to read, or FALSE if there is nothing
            {
                posterUsername = dr["posterUsername"].ToString();
                isbn = dr["isbn"].ToString();
                title = dr["title"].ToString();
                author = dr["author"].ToString();

                posterUsernameLabelCopy.Text = posterUsername;
                isbnLabelCopy.Text = isbn;
                titleLabelCopy.Text = title;
                authorLabelCopy.Text = author;
            }

            con.Close();

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
