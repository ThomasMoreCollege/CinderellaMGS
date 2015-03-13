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
    protected void Button1_Click1(object sender, EventArgs e)
    {
        //testQueue.enqueue(Convert.ToInt32(TextBox1.Text));
        //Label1.Text = testQueue.getNumItems().ToString();
        //Label2.Text = testQueue.getValofLastNode().ToString();
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       // testQueue.dequeue();
       // Label1.Text = testQueue.getNumItems().ToString();
       // Label2.Text = testQueue.getValofLastNode().ToString();
    }
}