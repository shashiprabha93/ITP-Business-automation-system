using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace megacoolnew
{
    public partial class Login : Form
    {
        private bool mouseDown;
        private Point lastLocation;


        public Login()
        {
            InitializeComponent();
        }
//Customized Close Button properties
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void close_MouseDown(object sender, MouseEventArgs e)
        {
            close.Image = Properties.Resources.cl_clicked;
        }

        private void close_MouseHover(object sender, EventArgs e)
        {
            close.Image = Properties.Resources.cl_hover;
        }

        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.Image = Properties.Resources.cl_nor;
        }

        private void close_MouseUp(object sender, MouseEventArgs e)
        {
            close.Image = Properties.Resources.cl_hover;
        }

//Customized minimize Button properties
        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void minimize_MouseDown(object sender, MouseEventArgs e)
        {
            minimize.Image = Properties.Resources.min_clicked;
        }

        private void minimize_MouseHover(object sender, EventArgs e)
        {
            minimize.Image = Properties.Resources.min_hover;
        }

        private void minimize_MouseLeave(object sender, EventArgs e)
        {
            minimize.Image = Properties.Resources.min_nor;
        }

        private void minimize_MouseUp(object sender, MouseEventArgs e)
        {
            minimize.Image = Properties.Resources.min_hover;
        }
//**end**
        private void loginbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.ShowDialog();
            Close();
        }
        //making the application dragable 
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        // ***end***


    }
}
