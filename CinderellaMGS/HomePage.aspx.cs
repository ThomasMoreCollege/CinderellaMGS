using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Sets all menu links to visible for admin access
        if (((string)Session["CurrentUser"]) == "Admin")
        {
            this.Master.CheckinLink.Visible = true;
            this.Master.AppointmentLink.Visible = true;
            this.Master.AlterationLink.Visible = true;
            this.Master.CheckoutLink.Visible = true;
            this.Master.RegistrationLink.Visible = true;
        }
        // Sets alterations menu link to visible for alterations access
        else if (((string)Session["CurrentUser"]) == "Alterations")
        {
            this.Master.AlterationLink.Visible = true;
        }
        // Sets checkout menu links to visible for checkout access
        else if (((string)Session["CurrentUser"]) == "Checkout")
        {
            this.Master.CheckoutLink.Visible = true;
        }
        // Sets checkin/registration menu links to visible for checkin access
        if (((string)Session["CurrentUser"]) == "Checkin")
        {
            this.Master.CheckinLink.Visible = true;
            this.Master.RegistrationLink.Visible = true;
        }
    }
}