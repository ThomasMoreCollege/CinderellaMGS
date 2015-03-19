using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//using System.Web.UI.HtmlControls.HtmlElement;
//using System.Web.UI.HtmlControls.HtmlGenericControl;

public partial class MasterPage : System.Web.UI.MasterPage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void RevealAdmin(bool showAdmin)
    {
        if (showAdmin)
        {
            AdminTitle.Visible = true;
            UserTitle.Visible = true;

            //Enable all user features if they were disabled
            AlterationsHyperLink.Visible = true;
            AutomatedPairingHyperLink.Visible = true;
            ManageCinderellasHyperLink.Visible = true;
            ManagePackageHyperLink.Visible = true;
            ManageShoppingHyperLink.Visible = true;
        }
        else
        {
            AdminTitle.Visible = false;
            UserTitle.Visible = false;
        }
    }

    public void RevealAllUserFeatures(bool showAllUser)
    {
        if (showAllUser)
        {
            UserTitle.Visible = true;
            AdminTitle.Visible = false;

            //Enable all user features if they were disabled
            AlterationsHyperLink.Visible = true;
            AutomatedPairingHyperLink.Visible = true;
            ManageCinderellasHyperLink.Visible = true;
            ManagePackageHyperLink.Visible = true;
            ManageShoppingHyperLink.Visible = true;
        }
        else
        {
            UserTitle.Visible = false;
            AdminTitle.Visible = false;
        }
    }

    public void RevealAutonmatedPairingOnly(bool showAutoPairing)
    {
        if (showAutoPairing)
        {
            UserTitle.Visible = true;
            AdminTitle.Visible = false;

            //Disable all other links under user features except for automatted pairing
            AlterationsHyperLink.Visible = false;
            AutomatedPairingHyperLink.Visible = true;
            ManageCinderellasHyperLink.Visible = false;
            ManagePackageHyperLink.Visible = false;
            ManageShoppingHyperLink.Visible = false;

        }
        else
        {
            UserTitle.Visible = false;
            AdminTitle.Visible = false;
        }
    }

    public void LoginScreenLayout()
    {
        string currentPage = HttpContext.Current.Request.Url.AbsolutePath.ToString();
        if (currentPage == "/CinderellaMGS/Forms/DefaultForms/Login.aspx")
        {

            MenuNav.Visible = false;
            LoginNav.Visible = false;

            content.Style.Add("margin-left", "0px");
        }
    }

    public void PairingScreenLayout()
    {
        string currentPage = HttpContext.Current.Request.Url.AbsolutePath.ToString();
        if (currentPage == "/CinderellaMGS/Forms/UserForms/AutomatedPairing.aspx")
        {
            MenuNav.Visible = false;
            LoginNav.Visible = true;
            SideNav.Visible = false;

            content.Style.Add("margin-left", "0px");
            
        }
    }

    public void ManageMasterLayout()
    {
        //Manage login screen view
        LoginScreenLayout();

        //Disable caching and expire pages if not logged in 
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetNoStore();

        // Checking if a session is running
        if (Session["CurrentAccType"] != null)
        {
            if (Session["CurrentAccType"].ToString() == "Administrator")
            {
                WelcomeLabel.Text = "Welcome, " + Session["CurrentUser"].ToString() + " | ";
                WelcomeLabel.Visible = true;
                RevealAdmin(true);
                LogOffLinkButton.Visible = true;
                LoginHyperLink.Visible = false;
            }
            else if (Session["CurrentAccType"].ToString() == "Standard")
            {
                WelcomeLabel.Text = "Welcome, " + Session["CurrentUser"].ToString() + " | ";
                WelcomeLabel.Visible = true;
                RevealAllUserFeatures(true);
                LogOffLinkButton.Visible = true;
                LoginHyperLink.Visible = false;
            }
            else if (Session["CurrentAccType"].ToString() == "Pairing")
            {
                PairingScreenLayout();
                WelcomeLabel.Text = "Welcome, " + Session["CurrentUser"].ToString() + " | ";
                WelcomeLabel.Visible = true;
                RevealAutonmatedPairingOnly(true);
                LogOffLinkButton.Visible = true;
                LoginHyperLink.Visible = false;


            }
            //else
            //{
            //    //Disable caching if not logged in 
            //    Response.ExpiresAbsolute=DateTime.Now.AddDays(-1d);
            //    Response.Expires =-1500;
            //    Response.CacheControl = "no-cache";
            //    string currentPage = HttpContext.Current.Request.Url.AbsolutePath.ToString();

            //    // Redirect to login page if trying to access a page if not logged in
            //    if (currentPage != "/CinderellaMGS/Forms/DefaultForms/Login.aspx")
            //    {
            //        WelcomeLabel.Text = "--";
            //        WelcomeLabel.Visible = false;
            //        RevealAdmin(false);
            //        RevealAllUserFeatures(false);
            //        RevealAutonmatedPairingOnly(false);
            //        LogOffLinkButton.Visible = false;
            //        LoginHyperLink.Visible = true;
            //        Response.Redirect("~/Forms/DefaultForms/Login.aspx");
            //    }
            //    else
            //    {
            //        WelcomeLabel.Text = "--";
            //        WelcomeLabel.Visible = false;
            //        RevealAdmin(false);
            //        RevealAllUserFeatures(false);
            //        RevealAutonmatedPairingOnly(false);
            //        LogOffLinkButton.Visible = false;
            //        LoginHyperLink.Visible = true;
            //        //Response.Redirect("~/Forms/DefaultForms/Login.aspx");
            //    }
            //}
            
        }
        else
        {            
            // Redirect to login page if trying to access a page if not logged in
            string currentPage = HttpContext.Current.Request.Url.AbsolutePath.ToString();
            if (currentPage != "/CinderellaMGS/Forms/DefaultForms/Login.aspx")
            {
                WelcomeLabel.Text = "--";
                WelcomeLabel.Visible = false;
                RevealAdmin(false);
                RevealAllUserFeatures(false);
                RevealAutonmatedPairingOnly(false);
                LogOffLinkButton.Visible = false;
                LoginHyperLink.Visible = true;
                Response.Redirect("~/Forms/DefaultForms/Login.aspx");
            }
            else
            {
                WelcomeLabel.Text = "--";
                WelcomeLabel.Visible = false;
                RevealAdmin(false);
                RevealAllUserFeatures(false);
                RevealAutonmatedPairingOnly(false);
                LogOffLinkButton.Visible = false;
                LoginHyperLink.Visible = true;
                //Response.Redirect("~/Forms/DefaultForms/Login.aspx");
            }
        }
    }

    protected void LogOffLinkButton_Click(object sender, EventArgs e)
    {
        Session["CurrentAccType"] = null;
        Session["CurrentUser"] = null;
        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetNoStore();
        Response.Redirect("~/Forms/DefaultForms/HomePage.aspx");
    }
}
