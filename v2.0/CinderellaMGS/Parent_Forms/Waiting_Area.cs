using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace CinderellaMGS
{
    public partial class Waiting_Area : Form
    {
        //Instantiate some Classes
        SQL_Queries sqlQuery = new SQL_Queries();
        //MatchMakers makeMatches = new MatchMakers();
        //initilize
        public Waiting_Area()
        {
            InitializeComponent();
            //start tick
            timer1.Enabled = true;
            timer2.Enabled = true;
        }
        //lists For Godmothers and cinderellas who are not paired
        public List<string> gMName = new List<string>();
        public List<string> cName = new List<string>();
        //lists For Godmothers and cinderellas who are paired
        public List<string> gMNamePaired = new List<string>();
        public List<string> cNamePaired = new List<string>();
        //method populatelists populates all four lists with db info
        public void populateLists()
        {
            int count = 0;
            //get cinderella ids of Paired
            //use class SQL_Queries and getCinderellaStatus method
            DataSet cdsPaired = sqlQuery.getCinderellaStatus("Paired", "transID");
            int c = 0;
            foreach (DataRow dr in cdsPaired.Tables[0].Rows)
            {
                //variables for name
                string fname = "";
                string lname = "";
                //name retreived from db
                string a = dr["Name"].ToString();
                //Breaks fname and lname up and swaps spots
                lname = a.Remove(a.IndexOf(","));
                fname = a.Remove(0, lname.Length + 2);
                cNamePaired.Add(fname + "  " + lname); 
                //tracks all cinderellas so display will not exceed 35
                c++;
                if (c >= 35)
                {
                    break;
                }
            }
            //get god mother ids Paired
            //use class SQL_Queries and getGodmotherStatus method
            DataSet gmdsPaired = sqlQuery.getGodmotherStatus("Paired", "transID", false);
            int f = 0;
            foreach (DataRow dr in gmdsPaired.Tables[0].Rows)
            {
                count++;
                //variables for name
                string fname = "";
                string lname = "";
                //name retreived from db
                string a = dr["Name"].ToString();
                //Breaks fname and lname up and swaps spots
                lname = a.Remove(a.IndexOf(","));
                fname = a.Remove(0, lname.Length + 2);
                gMNamePaired.Add(count.ToString() + "---" + fname + "  " + lname);
                //tracks all godmothers so display will not exceed 35
                f++;
                if (f >= 35)
                {
                    break;
                }
            }
            //get cinderella ids waiting
            //use class SQL_Queries and getCinderellaStatus method
            DataSet cds = sqlQuery.getCinderellaStatus("Waiting", "transID");
            foreach (DataRow dr in cds.Tables[0].Rows)
            {
                //variables for name
                string fname = "";
                string lname = "";
                //name retreived from db
                string a = dr["Name"].ToString();
                //Breaks fname and lname up and swaps spots
                lname = a.Remove(a.IndexOf(","));
                fname = a.Remove(0, lname.Length + 2);
                cName.Add(fname + "  " + lname);
                //tracks all cinderellas so display will not exceed 35
                c++;
                if (c >= 35)
                {
                    break;
                }
            }
            //get god mother ids available
            //use class SQL_Queries and getGodmotherStatus method
            DataSet gmds = sqlQuery.getGodmotherStatus("Available", "transID", false);
            foreach (DataRow dr in gmds.Tables[0].Rows)
            {
                //variables for name
                count++;
                string fname = "";
                string lname = "";
                //name retreived from db
                string a = dr["Name"].ToString();
                //Breaks fname and lname up and swaps spots
                lname = a.Remove(a.IndexOf(","));
                fname = a.Remove(0, lname.Length + 2);
                gMName.Add(count.ToString()+ "---" +fname + "  " + lname);
                //tracks all godmothers so display will not exceed 35
                f++;
                if (f >= 35)
                {
                    break;
                }
            }   
        }
        //methob populate form populates Cinderella and godmother LBs        
        public void populateForm()
        {
            //calling method to disables arrows
            disablePictures();
            //set a temp to 0
            int temp = 0;
            //clear list boxes
            godmotherLB.Items.Clear();
            cinderellaLB.Items.Clear();
            //display fairgodmothers paired
            for (int i = 0; i < gMNamePaired.Count; i++)
            {
                //places items from list to LB
                godmotherLB.Items.Add(gMNamePaired[i]);
                godmotherLB.SelectedIndex = i;
            }
            //display fairgodmothers not paired
            for (int i = 0; i < gMName.Count; i++)
            {
                //places items from list to LB
                godmotherLB.Items.Add(gMName[i]);
            }
            //display cinderellas paired
            for (int i = 0; i < cNamePaired.Count; i++)
            {
                //places items from list to LB
                cinderellaLB.Items.Add(cNamePaired[i]);
                cinderellaLB.SelectedIndex = i;
                temp++;
            }
            //display cinderellas not paired
            for (int i = 0; i < cName.Count; i++)
            {
                //places items from list to LB
                cinderellaLB.Items.Add(cName[i]);
            }
            //enables the proper arrows
            enableImages(temp);
            //clear all lists to be repopulated
            gMNamePaired.Clear();
            cNamePaired.Clear();
            gMName.Clear();
            cName.Clear();
        }
        //enables proper arrows based on a
        private void enableImages(int a)
        {
            //allows for a break point
            while (a > 0)
            {
                //enable a count to match up with a
                int count = 1;
                //arroes 1 and 36
                pictureBox1.Visible = true;
                pictureBox36.Visible = true;
                //compare a to count
                //if equal break
                if (a == count)
                    break;
                //repeats for all picture boxes 1- 70
                //2 37
                pictureBox2.Visible = true;
                pictureBox37.Visible = true;
                count++;
                if (a == count)
                    break;
                //3 38
                pictureBox3.Visible = true;
                pictureBox38.Visible = true;
                count++;
                if (a == count)
                    break;
                //4 39
                pictureBox4.Visible = true;
                pictureBox39.Visible = true;
                count++;
                if (a == count)
                    break;
                //5 40
                pictureBox5.Visible = true;
                pictureBox40.Visible = true;
                count++;
                if (a == count)
                    break;
                //6
                pictureBox6.Visible = true;
                pictureBox41.Visible = true;
                count++;
                if (a == count)
                    break;
                //7
                pictureBox7.Visible = true;
                pictureBox42.Visible = true;
                count++;
                if (a == count)
                    break;
                //8
                pictureBox8.Visible = true;
                pictureBox43.Visible = true;
                count++;
                if (a == count)
                    break;
                //9
                pictureBox9.Visible = true;
                pictureBox44.Visible = true;
                count++;
                if (a == count)
                    break;
                //10
                pictureBox10.Visible = true;
                pictureBox45.Visible = true;
                count++;
                if (a == count)
                    break;
                //11
                pictureBox11.Visible = true;
                pictureBox46.Visible = true;
                count++;
                if (a == count)
                    break;
                //12
                pictureBox12.Visible = true;
                pictureBox47.Visible = true;
                count++;
                if (a == count)
                    break;
                //13
                pictureBox13.Visible = true;
                pictureBox48.Visible = true;
                count++;
                if (a == count)
                    break;
                //14
                pictureBox14.Visible = true;
                pictureBox49.Visible = true;
                count++;
                if (a == count)
                    break;
                //15
                pictureBox15.Visible = true;
                pictureBox50.Visible = true;
                count++;
                if (a == count)
                    break;
                //16
                pictureBox16.Visible = true;
                pictureBox51.Visible = true;
                count++;
                if (a == count)
                    break;
                //17
                pictureBox17.Visible = true;
                pictureBox52.Visible = true;
                count++;
                if (a == count)
                    break;
                //18
                pictureBox18.Visible = true;
                pictureBox53.Visible = true;
                count++;
                if (a == count)
                    break;
                //19
                pictureBox19.Visible = true;
                pictureBox54.Visible = true;
                count++;
                if (a == count)
                    break;
                //20
                pictureBox20.Visible = true;
                pictureBox55.Visible = true;
                count++;
                if (a == count)
                    break;
                //21
                pictureBox21.Visible = true;
                pictureBox56.Visible = true;
                count++;
                if (a == count)
                    break;
                //22
                pictureBox22.Visible = true;
                pictureBox57.Visible = true;
                count++;
                if (a == count)
                    break;
                //23
                pictureBox23.Visible = true;
                pictureBox58.Visible = true;
                count++;
                if (a == count)
                    break;
                //24
                pictureBox24.Visible = true;
                pictureBox59.Visible = true;
                count++;
                if (a == count)
                    break;
                //25
                pictureBox25.Visible = true;
                pictureBox60.Visible = true;
                count++;
                if (a == count)
                    break;
                //26
                pictureBox26.Visible = true;
                pictureBox61.Visible = true;
                count++;
                if (a == count)
                    break;
                //27
                pictureBox27.Visible = true;
                pictureBox62.Visible = true;
                count++;
                if (a == count)
                    break;
                //28
                pictureBox28.Visible = true;
                pictureBox63.Visible = true;
                count++;
                if (a == count)
                    break;
                //29
                pictureBox29.Visible = true;
                pictureBox64.Visible = true;
                count++;
                if (a == count)
                    break;
                //30
                pictureBox30.Visible = true;
                pictureBox65.Visible = true;
                count++;
                if (a == count)
                    break;
                //31
                pictureBox31.Visible = true;
                pictureBox66.Visible = true;
                count++;
                if (a == count)
                    break;
                //32
                pictureBox32.Visible = true;
                pictureBox67.Visible = true;
                count++;
                if (a == count)
                    break;
                //33
                pictureBox33.Visible = true;
                pictureBox68.Visible = true;
                count++;
                if (a == count)
                    break;
                //34
                pictureBox34.Visible = true;
                pictureBox69.Visible = true;
                count++;
                if (a == count)
                    break;
                //35
                pictureBox35.Visible = true;
                pictureBox70.Visible = true;
                count++;
                if (a == count)
                    break;
            }
        }
        //disable the visability of all picture boxes
        private void disablePictures()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = false;
            pictureBox15.Visible = false;
            pictureBox16.Visible = false;
            pictureBox17.Visible = false;
            pictureBox18.Visible = false;
            pictureBox19.Visible = false;
            pictureBox20.Visible = false;
            pictureBox21.Visible = false;
            pictureBox22.Visible = false;
            pictureBox23.Visible = false;
            pictureBox24.Visible = false;
            pictureBox25.Visible = false;
            pictureBox26.Visible = false;
            pictureBox27.Visible = false;
            pictureBox28.Visible = false;
            pictureBox29.Visible = false;
            pictureBox30.Visible = false;
            pictureBox31.Visible = false;
            pictureBox32.Visible = false;
            pictureBox33.Visible = false;
            pictureBox34.Visible = false;
            pictureBox35.Visible = false;
            pictureBox36.Visible = false;
            pictureBox37.Visible = false;
            pictureBox38.Visible = false;
            pictureBox39.Visible = false;
            pictureBox40.Visible = false;
            pictureBox41.Visible = false;
            pictureBox42.Visible = false;
            pictureBox43.Visible = false;
            pictureBox44.Visible = false;
            pictureBox45.Visible = false;
            pictureBox46.Visible = false;
            pictureBox47.Visible = false;
            pictureBox48.Visible = false;
            pictureBox49.Visible = false;
            pictureBox50.Visible = false;
            pictureBox51.Visible = false;
            pictureBox52.Visible = false;
            pictureBox53.Visible = false;
            pictureBox54.Visible = false;
            pictureBox55.Visible = false;
            pictureBox56.Visible = false;
            pictureBox57.Visible = false;
            pictureBox58.Visible = false;
            pictureBox59.Visible = false;
            pictureBox60.Visible = false;
            pictureBox61.Visible = false;
            pictureBox62.Visible = false;
            pictureBox63.Visible = false;
            pictureBox64.Visible = false;
            pictureBox65.Visible = false;
            pictureBox66.Visible = false;
            pictureBox67.Visible = false;
            pictureBox68.Visible = false;
            pictureBox69.Visible = false;
            pictureBox70.Visible = false;         
        }
        //On loading the form
        private void Waiting_Area_Load(object sender, EventArgs e)
        {
            //method read db pop lists
            populateLists();
            //method print to form            
            populateForm();
            //timers
            timer1.Interval = GlobalVar.timerInterval;//10 sec refresh rate 
            timer2.Interval = timer1.Interval / 10;//.dots for load bar
            //enable timers
            timer1.Enabled = true;
            timer2.Enabled = true;
            //set some global variables from Class GlobalVar
            this.BackColor = GlobalVar.FormBackColor;
            groupBox1.BackColor = GlobalVar.FormBackColor;
            godmotherLB.BackColor = GlobalVar.FormBackColor;
            cinderellaLB.BackColor = GlobalVar.FormBackColor;
        }
        //occurs when form is clicked
        private void Waiting_Area_Click(object sender, EventArgs e)
        {
            //method to close form
            Closer();
        }
        //tick for timer one set to GlobalVar.timerInterval
        private void timer1_Tick(object sender, EventArgs e)
        {
            //read db pop lists
            populateLists();
            //print to form            
            populateForm();
            //clear label for load bar dots
            label3.Text = "";
        }
        //Performs the action of the load bar
        //time is a tenth of timer_1 tick
        private void timer2_Tick(object sender, EventArgs e)
        {
            //add a dot to timer bar
            label3.Text += ".";
        }
        //hidden button set to cancel 
        //allows one to exit to form by pressing esc
        private void button1_Click(object sender, EventArgs e)
        {
            //close form when escape is clicked
            Closer();
        }
        //method to close form
       public void Closer()
        {
           //close forms
            this.Close();
        }

       private void cinderellaLB_SelectedIndexChanged(object sender, EventArgs e)
       {

       }
    }
}
