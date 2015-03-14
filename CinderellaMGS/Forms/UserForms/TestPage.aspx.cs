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
    public static CinderellaQueue.CinderellaQueue testQueue = new CinderellaQueue.CinderellaQueue();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void VolunteerGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow currentRow = CinderellaGridView.SelectedRow;

        CinderellaClass selectedCinderella = new CinderellaClass(Convert.ToInt32(currentRow.Cells[1].Text));

        Label1.Text = selectedCinderella.Priority.ToString();

    }
    protected void AddButton_Click(object sender, EventArgs e)
    {
        GridViewRow currentRow = CinderellaGridView.SelectedRow;

        CinderellaClass selectedCinderella = new CinderellaClass(Convert.ToInt32(currentRow.Cells[1].Text));

        testQueue.enqueue(selectedCinderella);

        NumofCinLabel.Text = testQueue.getNumItems().ToString();
        FrontCinLabel.Text = testQueue.getValofFrontNode().CinderellaID.ToString();
    }
    protected void ButtonPop_Click(object sender, EventArgs e)
    {
        testQueue.dequeue();
        NumofCinLabel.Text = testQueue.getNumItems().ToString();
        FrontCinLabel.Text = testQueue.getValofFrontNode().CinderellaID.ToString();
    }
    protected void SelectivePopButton_Click(object sender, EventArgs e)
    {
        int CinderellaID = Convert.ToInt32(TextBox.Text);
        testQueue.selectiveDequeue(CinderellaID);
        NumofCinLabel.Text = testQueue.getNumItems().ToString();
        FrontCinLabel.Text = testQueue.getValofFrontNode().CinderellaID.ToString();
    }
}