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
        // Validation variables
        bool validName = false;
        bool validWidth = false;
        bool validDepth = false;


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

        // Form validation for name, width, and depth
        private void validateName(object sender, CancelEventArgs e)
        {
            // Name not left blank
            if (!string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                validName = true;
                return;
            }
        }

        private void validateWidth(object sender, CancelEventArgs e)
        {

            // numbers outside of range
            if (int.TryParse(widthTextBox.Text, out int widthInput) == true)
            {
                if (widthInput < Desk.MINWIDTH || widthInput > Desk.MAXWIDTH)
                {
                    MessageBox.Show("Width must be between 12 and 96.");
                    widthTextBox.SelectAll();
                    e.Cancel = true;
                    return;
                }
            }

            // left blank
            if (string.IsNullOrWhiteSpace(widthTextBox.Text))
            {
                MessageBox.Show("Please enter the width.");
                e.Cancel = true;
                return;
            }

            // valid input
            validWidth = true;
            return;

        }

        private void validateDepth(object sender, CancelEventArgs e)
        {
            // numbers outside of range
            if (int.TryParse(depthTextBox.Text, out int depthInput) == true)
            {
                if (depthInput < Desk.MINDEPTH || depthInput > Desk.MAXDEPTH)
                {
                    MessageBox.Show("Depth must be between 12 and 48.");
                    depthTextBox.SelectAll();
                    e.Cancel = true;
                    return;
                }
            }

            // left blank
            if (string.IsNullOrWhiteSpace(depthTextBox.Text))
            {
                MessageBox.Show("Please enter the depth.");
                e.Cancel = true;
                return;
            }

            // valid input
            validDepth = true;
            return;
        }

        // Calculate surface area and display in summary
        private void calcSurfaceArea(object sender, EventArgs e)
        {
            int surfaceArea = 0;
            int extraSurfaceArea = 0;

            if (validWidth == true && validDepth == true)
            {
                surfaceArea = int.Parse(widthTextBox.Text) * int.Parse(depthTextBox.Text);
                surfaceAreaProduct.Text = surfaceArea.ToString();
                
            }

            if (surfaceArea > Desk.INCLSURFACEAREA)
            {
                extraSurfaceArea = surfaceArea - Desk.INCLSURFACEAREA;
                summarySurfaceArea.Text = extraSurfaceArea.ToString();
            }
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
    }
}
