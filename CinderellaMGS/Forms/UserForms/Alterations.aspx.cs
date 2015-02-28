using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_UserForms_Alterations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SubmitDressButton_Click(object sender, EventArgs e)
    {
        SearchTextBox.Text = "";
        StrapsCheckBox.Checked = false;
        GeneralMendingCheckBox.Checked = false;
        GeneralTakeinCheckBox.Checked = false;
        FixZipperCheckBox.Checked = false;
        DartsCheckBox.Checked = false;
        BustCheckBox.Checked = false;
        HemCheckBox.Checked = false;
        notesTextBox.Text = "";

    }
}