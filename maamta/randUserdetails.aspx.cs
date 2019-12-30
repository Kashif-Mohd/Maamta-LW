using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class randUserdetails : System.Web.UI.Page
    {
        // MySqlDataReader dreader;
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "DashboardRandom";
            if (Session["RandTeamUname"] == null)
            {
                Response.Redirect("dashboardRandom.aspx");
            }
            else
                lbeStatus.Text = Convert.ToString(Session["RandTeamUname"]);
            lbeFdate.Text = Convert.ToString(Session["FirstEDate"]);
            lbeSdate.Text = Convert.ToString(Session["SecEDate"]);
            //   ShowData();
            txtdssid.Focus();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {           
           // ShowData();
            txtdssid.Focus();
        }


    }
}