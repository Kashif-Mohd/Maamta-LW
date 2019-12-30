using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace maamta
{
    public partial class main : System.Web.UI.MasterPage
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lbeUserName.Text = "(Logged in: " + Convert.ToString(Session["MPusername"]) + ")";
            lbeUserNav.Text = Convert.ToString(Session["MPusername"]);


           //  Start Navigation:
            if (Convert.ToString(Session["Role"]) != "Web_Admin" && Convert.ToString(Session["Role"]) != "Web_Standard")
            {
                navMonitoring.Visible = false;
            }
            if (Convert.ToString(Session["Role"]) != "Web_Admin")
            {
                delscreeningform.Visible = false;
                editChAnthro.Visible = false;
                editLWAnthro.Visible = false;
                //editdssid.Visible = false;
            }
            else
            {
                navdash.Visible = true;
            }


            // End Navigation:

            if (Session["MPusername"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Convert.ToString(Session["WebForm"]) == "Dashboard")
                {
                    dashboard.Attributes.Add("class", "active");
                    src.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "DashboardRandom")
                {
                    dashboard.Attributes.Add("class", "active");
                    random.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "DashboardNB")
                {
                    dashboard.Attributes.Add("class", "active");
                    nb.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "DangerSign")
                {
                    dashboard.Attributes.Add("class", "active");
                    dangersign.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }

                else if (Convert.ToString(Session["WebForm"]) == "OutcomePending")
                {
                    TaskList.Attributes.Add("class", "active");
                    outcomePending.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "AzithromycinTask")
                {
                    TaskList.Attributes.Add("class", "active");
                    azithromycin.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "followups4a")
                {
                    TaskList.Attributes.Add("class", "active");
                    followups4a.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "followups5b")
                {
                    TaskList.Attributes.Add("class", "active");
                    followups5b.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "followups6")
                {
                    TaskList.Attributes.Add("class", "active");
                    followups6.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "LABinvestigation")
                {
                    TaskList.Attributes.Add("class", "active");
                    labinvestigation.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "FupsStatus")
                {
                    TaskList.Attributes.Add("class", "active");
                    FupsStatus.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "ListOfUsers")
                {
                    TabUsr.Attributes.Add("class", "active");
                    listUsr.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "scrnDuplicate")
                {
                    duplicate.Attributes.Add("class", "active");
                    scrDuplicate.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "randDuplicate")
                {
                    duplicate.Attributes.Add("class", "active");
                    randDuplicate.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "nbDuplicate")
                {
                    duplicate.Attributes.Add("class", "active");
                    nbDuplicate.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "errorCompliance")
                {
                    duplicate.Attributes.Add("class", "active");
                    errorCompliance.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                    
                else if (Convert.ToString(Session["WebForm"]) == "DeleteCRF1")
                {
                    duplicate.Attributes.Add("class", "active");
                    delscreeningform.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "randomSequence")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    randomSequence.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf1")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf1.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf2")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf2.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf3a")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf3a.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf3b")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf3b.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf3c")
                {
                    ScrRandForms.Attributes.Add("class", "active");
                    showcrf3c.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showvaccination")
                {
                    NBForms.Attributes.Add("class", "active");
                    showvaccination.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf4a")
                {
                    NBForms.Attributes.Add("class", "active");
                    showcrf4a.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf4b")
                {
                    NBForms.Attributes.Add("class", "active");
                    showcrf4b.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf5a")
                {
                    NBForms.Attributes.Add("class", "active");
                    showcrf5a.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf5b")
                {
                    NBForms.Attributes.Add("class", "active");
                    showcrf5b.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "showcrf6")
                {
                    NBForms.Attributes.Add("class", "active");
                    showcrf6.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "moniLWAnthro")
                {
                    monitoring.Attributes.Add("class", "active");
                    moniLwAnt.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "moniChAnthro")
                {
                    monitoring.Attributes.Add("class", "active");
                    moniChAnt.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }


                else if (Convert.ToString(Session["WebForm"]) == "chkFollowupsNB")
                {
                    monitoring.Attributes.Add("class", "active");
                    chkFollowpsNB.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "compPrtage")
                {
                    monitoring.Attributes.Add("class", "active");
                    compPrtage.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "losttofollowup")
                {
                    monitoring.Attributes.Add("class", "active");
                    losttofollowup.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                    
                else if (Convert.ToString(Session["WebForm"]) == "ebfPrtage")
                {
                    monitoring.Attributes.Add("class", "active");
                    ebfPrtage.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "secretinfo")
                {
                    monitoring.Attributes.Add("class", "active");
                    secretinfo.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "pendingvaccination")
                {
                    monitoring.Attributes.Add("class", "active");
                    pendingvaccination.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "digitpreference")
                {
                    monitoring.Attributes.Add("class", "active");
                    digitpreference.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }

                else if (Convert.ToString(Session["WebForm"]) == "editChAnthro")
                {
                    monitoring.Attributes.Add("class", "active");
                    editChAnthro.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
                else if (Convert.ToString(Session["WebForm"]) == "editLWAnthro")
                {
                    monitoring.Attributes.Add("class", "active");
                    editLWAnthro.Attributes.Add("class", "active");
                    Session["WebForm"] = null;
                }
              
            }
        }












    }
}