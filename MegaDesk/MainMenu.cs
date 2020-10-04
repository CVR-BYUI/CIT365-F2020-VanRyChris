using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void AddQuoteButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddQuote aq = new AddQuote();
            aq.ShowDialog();
            this.Close();
        }

        private void ViewQuotesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAllQuotes vq = new ViewAllQuotes();
            vq.ShowDialog();
            this.Close();
        }

        private void SearchQuotesButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchQuotes sq = new SearchQuotes();
            sq.ShowDialog();
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            // Close the Main Menu Form
            Close();
        }
    }
}
