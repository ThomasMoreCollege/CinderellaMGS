using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;



public partial class Forms_UserForms_TestPage : System.Web.UI.Page
{
    public static VolunteerQueue.VolunteerQueue testQueue = new VolunteerQueue.VolunteerQueue();

    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = DateTime.Now.DayOfWeek.ToString();
    }

    protected void VolunteerGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow currentRow = CinderellaGridView.SelectedRow;

        VolunteerClass selectedVolunteer = new VolunteerClass(Convert.ToInt32(currentRow.Cells[1].Text));

        //Label1.Text = selectedCinderella.Priority.ToString();

    }
    protected void AddButton_Click(object sender, EventArgs e)
    {
        GridViewRow currentRow = CinderellaGridView.SelectedRow;

        VolunteerClass selectedVolunteer = new VolunteerClass(Convert.ToInt32(currentRow.Cells[1].Text));

        testQueue.enqueue(selectedVolunteer);

        NumofCinLabel.Text = testQueue.getNumItems().ToString();
        FrontCinLabel.Text = testQueue.getValofFrontNode().VolunteerID.ToString();
        //PriorityOfFrontNodeLabel.Text = testQueue.getValofFrontNode().Priority.ToString();
    }
    protected void ButtonPop_Click(object sender, EventArgs e)
    {
        testQueue.dequeue();
        NumofCinLabel.Text = testQueue.getNumItems().ToString();
        FrontCinLabel.Text = testQueue.getValofFrontNode().VolunteerID.ToString();
        //PriorityOfFrontNodeLabel.Text = testQueue.getValofFrontNode().Priority.ToString();
    }
    protected void SelectivePopButton_Click(object sender, EventArgs e)
    {
        int VolunteerID = Convert.ToInt32(TextBox.Text);
        testQueue.selectiveDequeue(VolunteerID);
        NumofCinLabel.Text = testQueue.getNumItems().ToString();
        FrontCinLabel.Text = testQueue.getValofFrontNode().VolunteerID.ToString();
        //PriorityOfFrontNodeLabel.Text = testQueue.getValofFrontNode().Priority.ToString();
    }
    protected void AddToFrontButton_Click(object sender, EventArgs e)
    {
        GridViewRow currentRow = CinderellaGridView.SelectedRow;

        int selectedVolunteerID = Convert.ToInt32(currentRow.Cells[1].Text);

        VolunteerClass selectedVolunteer = new VolunteerClass(selectedVolunteerID);

        testQueue.enqueueToFront(selectedVolunteer);

        NumofCinLabel.Text = testQueue.getNumItems().ToString();
        FrontCinLabel.Text = testQueue.getValofFrontNode().VolunteerID.ToString();
        //PriorityOfFrontNodeLabel.Text = testQueue.getValofFrontNode().Priority.ToString();
    }
    protected void RecalibrateButton_Click(object sender, EventArgs e)
    {
        //testQueue.recalibratePriority();

        //NumofCinLabel.Text = testQueue.getNumItems().ToString();
        //FrontCinLabel.Text = testQueue.getValofFrontNode().CinderellaID.ToString();
        //PriorityOfFrontNodeLabel.Text = testQueue.getValofFrontNode().Priority.ToString();
    }
}