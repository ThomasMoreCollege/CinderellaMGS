using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // ACCESSORS so child pages can access menu links
    public HyperLink CheckinLink
    {
        get { return CheckinHyperLink; }
        set { CheckinHyperLink = value; }
    }
    public HyperLink AppointmentLink
    {
        get { return AppointmentHyperLink; }
        set { AppointmentHyperLink = value; }
    }
    public HyperLink RegistrationLink
    {
        get { return RegistrationHyperLink; }
        set { RegistrationHyperLink = value; }
    }

    public HyperLink AlterationLink
    {
        get { return AlterationHyperLink; }
        set { AlterationHyperLink = value; }
    }

    public HyperLink CheckoutLink
    {
        get { return CheckoutHyperLink; }
        set { CheckoutHyperLink = value; }
    }
}
