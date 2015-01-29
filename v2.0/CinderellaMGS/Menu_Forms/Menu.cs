using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace CinderellaMGS
{
    public partial class Menu : Form
    {
        UserAccounts Account = new UserAccounts();
        string myUsername = "Insufficient Permissions";
        string permissionMessage = "You do not have permission to access this resource.";
        string permissionHeader = "Access Denied";
        public Menu(string username)
        {
            InitializeComponent();
            loadPictures();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            userLabel.Text = "Username: " + username;
            myUsername = username;
            setFormStyle();
        }
        /// <summary>
        /// Sets the global style for the form.
        /// </summary>
        public void setFormStyle()
        {
            //Form
            this.BackColor = GlobalVar.FormBackColor;
        }
        /// <summary>
        /// Loads the pictures for the menu items.
        /// </summary>
        public void loadPictures()
        {
            Assembly myAssembly;
            Stream myStream;
            Bitmap bmp;

            //Exit Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.close64.png");
            bmp = new Bitmap(myStream);
            exitPB.Image = bmp;

            //Checkout Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.cart64.png");
            bmp = new Bitmap(myStream);
            checkoutPB.Image = bmp;

            //Checkout Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.edit64.png");
            bmp = new Bitmap(myStream);
            checkinPB.Image = bmp;

            //Checkout Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.alarm64.png");
            bmp = new Bitmap(myStream);
            waitingAreaPB.Image = bmp;

            //Administration Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.configure64.png");
            bmp = new Bitmap(myStream);
            administrationPB.Image = bmp;

            //Manage Godmothers Picture Box
            myAssembly = Assembly.GetExecutingAssembly();
            myStream = myAssembly.GetManifestResourceStream("CinderellaMGS.Resources.Icons.female_user.png");
            bmp = new Bitmap(myStream);
            manageGodmothersPB.Image = bmp;
        }
        /// <summary>
        /// Loads the Cinderella Checkin form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkinPB_Click(object sender, EventArgs e)
        {
            if (Account.userHasRole(myUsername, "Checkin"))
            {
            CinderellaCheckIn checkinForm = new CinderellaCheckIn();
            //this.Hide();
            this.Enabled = false;
            checkinForm.ShowDialog();
            //this.Show();
            this.Enabled = true;
            }
            else
            {
                MessageBox.Show(permissionMessage, permissionHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        /// <summary>
        /// Loads the Manage Godmothers form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manageGodmothersPB_Click(object sender, EventArgs e)
        {
             if (Account.userHasRole(myUsername, "Godmother Management"))
            {
            ManageGodmothers godmothersForm = new ManageGodmothers();
            //this.Hide();
            this.Enabled = false;
            godmothersForm.ShowDialog();
            //this.Show();
            this.Enabled = true;
                 }
            else
            {
                MessageBox.Show(permissionMessage, permissionHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        /// <summary>
        /// Loads the checkout form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkoutPB_Click(object sender, EventArgs e)
        {
             if (Account.userHasRole(myUsername, "Checkout"))
            {
            Checkout checkoutForm = new Checkout();
            //this.Hide();
            this.Enabled = false;
            checkoutForm.ShowDialog();
            //this.Show();
            this.Enabled = true;
                 }
            else
            {
                MessageBox.Show(permissionMessage, permissionHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        /// <summary>
        /// Loads the Waiting Area form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void waitingAreaPB_Click(object sender, EventArgs e)
        {
             if (Account.userHasRole(myUsername, "Waiting Area"))
            {
            Waiting_Area waitingAreaForm = new Waiting_Area();
            this.Hide();
            waitingAreaForm.WindowState = FormWindowState.Maximized;
            waitingAreaForm.FormBorderStyle = FormBorderStyle.Fixed3D;
            waitingAreaForm.TopMost = true;
            waitingAreaForm.ShowDialog();
            this.Show();
                 }
            else
            {
                MessageBox.Show(permissionMessage, permissionHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        /// <summary>
        /// Loads the Administration form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void administrationPB_Click(object sender, EventArgs e)
        {
             if (Account.userHasRole(myUsername, "Administrator"))
            {
            Administration adminForm = new Administration(myUsername);
            //this.Hide();
            this.Enabled = false;
            adminForm.ShowDialog();
            //this.Show();
            this.Enabled = true;
            }
             else
             {
                 MessageBox.Show(permissionMessage, permissionHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop);
             }
        }
        /// <summary>
        /// Exits the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitPB_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //This will disable the close button
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}
