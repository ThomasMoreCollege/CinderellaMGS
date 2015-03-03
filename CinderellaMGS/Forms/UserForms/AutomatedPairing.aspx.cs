using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_UserForms_AutomatedPairing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        (this.Master as MasterPage).ManageMasterLayout();
    }
}