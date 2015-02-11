﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        // Sets up the session for keeping track of username and directs to HomePage
        Session["CurrentUser"] = UsernameTextBox.Text;
        Response.Redirect("HomePage.aspx");
    }
}