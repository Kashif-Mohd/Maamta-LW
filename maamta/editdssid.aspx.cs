using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;


namespace maamta
{
    public partial class editdssid : System.Web.UI.Page
    {
       // MySqlDataReader dreader;
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        string pwid;
        string dss_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "DeleteCRF1";

            if (!IsPostBack)
            {
                if (Session["Edit_Assis"] == null)
                {
                    Response.Redirect("dashboard.aspx");
                }
                else
                {
                    lbeAssess.Text = Convert.ToString(Session["Edit_Assis"]);
                    pwid = Convert.ToString(Session["Edit_id"]);
                    dss_id = Convert.ToString(Session["Edit_dss_id"]);
                    Session["Edit_Assis"] = null;
                    Session["Edit_id"] = null;
                    Session["Edit_dss_id"] = null;
                }
                    
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
                Session["BackButton"] = null;
                Response.Redirect("delscreeingform.aspx");
        }

        protected void OnSelectedIndexChangedMethod(object sender, EventArgs e)
        {
          
        }


       
    }
}