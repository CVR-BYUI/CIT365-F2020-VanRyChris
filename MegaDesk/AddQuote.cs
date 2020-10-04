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
    public partial class AddQuote : Form
    {      
        //
        public AddQuote()
        {
            InitializeComponent();

            // Display current date
            currentDate.Text = DateTime.UtcNow.ToString("dd MMMM yyyy");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mm = new MainMenu();
            mm.ShowDialog();
            this.Close();
        }

        private void submitOrderButton_Click(object sender, EventArgs e)
        {
            // Create new desk object
            Desk d = new Desk();

            // Convert width input to int
            try
            {
                d.Width = Convert.ToInt32(widthTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Convert depth input to int
            try
            {
                d.Depth = Convert.ToInt32(depthTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Calculate surface area
            d.SurfaceArea = d.Width * d.Depth;

            // Convert drawer input to int
            try
            {
                d.DrawerCount = Convert.ToInt32(drawerComboBox.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Convert desktop material input to string
            try
            {
                d.DesktopMaterial = Convert.ToString(desktopComboBox.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Return to main menu
            this.Hide();
            MainMenu mm = new MainMenu();
            mm.ShowDialog();
            this.Close();
        }
        
        // Width validation
        private void widthTextBoxInput(object sender, EventArgs e)
        {
            if (int.TryParse(widthTextBox.Text, out int widthInput) == true)
            {
                // Input too low or high
                if (widthInput < Desk.MINWIDTH || widthInput > Desk.MAXWIDTH)
                {
                    widthTextBox.Text = String.Empty;
                    widthTextBox.Focus();
                    widthErrorProvider.SetError(widthTextBox, $"Please enter numbers only, between {Desk.MINWIDTH} and {Desk.MAXWIDTH} inches.");
                }
                else
                {
                    // Reset error
                    widthErrorProvider.SetError(widthTextBox, "");
                }

            }
            // Input isn't in digit format
            else if (int.TryParse(widthTextBox.Text, out widthInput) == false && widthTextBox.Text.Length != 0)
            {
                widthTextBox.Text = String.Empty;
                widthTextBox.Focus();
                widthErrorProvider.SetError(widthTextBox, $"Please enter numbers only, between {Desk.MINWIDTH} and {Desk.MAXWIDTH} inches.");
            }
            else
            {
                // Reset error
                widthErrorProvider.SetError(widthTextBox, "");
            }
        }
        
        // Width validation - keypress event
        private void widthTextBoxKeypress (object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false)
            {
                e.Handled = true;
                widthTextBox.Focus();
                widthErrorProvider.SetError(widthTextBox, $"Please enter numbers only, between {Desk.MINWIDTH} and {Desk.MAXWIDTH} inches.");
            }
        }

        // Depth validation
        private void depthTextBoxInput(object sender, EventArgs e)
        {
            if (int.TryParse(depthTextBox.Text, out int depthInput) == true)
            {
                // Input too low or high
                if (depthInput < Desk.MINDEPTH || depthInput > Desk.MAXDEPTH)
                {
                    depthTextBox.Text = String.Empty;
                    depthTextBox.Focus();
                    depthErrorProvider.SetError(depthTextBox, $"Please enter numbers only, between {Desk.MINDEPTH} and {Desk.MAXDEPTH} inches.");
                }
                else
                {
                    // Reset error
                    depthErrorProvider.SetError(depthTextBox, "");
                }
            }
            // Input isn't in digit format
            else if (int.TryParse(depthTextBox.Text, out depthInput) == false && depthTextBox.Text.Length != 0)
            {
                depthTextBox.Text = String.Empty;
                depthTextBox.Focus();
                depthErrorProvider.SetError(depthTextBox, $"Please enter numbers only, between {Desk.MINDEPTH} and {Desk.MAXDEPTH} inches.");
            }
            else
            {
                // Reset error
                depthErrorProvider.SetError(depthTextBox, "");
            }
        }

        // Depth validation - keypress event
        private void depthTextBoxKeypress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false)
            {
                e.Handled = true;
                depthTextBox.Focus();
                depthErrorProvider.SetError(depthTextBox, $"Please enter numbers only, between {Desk.MINDEPTH} and {Desk.MAXDEPTH} inches.");
            }
        }





    }
}
