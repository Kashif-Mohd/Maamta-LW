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
    public partial class pendingvaccination : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "pendingvaccination";
               // ShowData();
            }
        }



        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }



        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT a.study_code,a.woman_nm,a.husband_nm,a.arm,a.dob,a.dod, a.current_age,a.dssid,			 (SELECT CONCAT(IF((z.bcg0_date !=''),'BCG, ',''), IF((z.opv0_date !=''),'OVP0, ',''))  FROM view_vaccination AS z WHERE (z.bcg0_date !='' || z.opv0_date !='' ) AND z.current_age>1 AND a.study_code=z.study_code) AS Done_After_Birth, (SELECT CONCAT(IF((z.bcg0_date IS NULL || z.bcg0_date =''),'BCG, ',''), IF((z.opv0_date IS NULL || z.opv0_date =''),'OVP0, ',''))  FROM view_vaccination AS z WHERE (z.bcg0_date IS NULL || z.bcg0_date ='' || z.opv0_date IS NULL || z.opv0_date ='' ) AND z.current_age>1 AND a.study_code=z.study_code) AS Pending_After_Birth, (SELECT CONCAT(IF((z.opv1_date !=''),'OPV1, ',''), IF((z.penta1_date !=''),'Penta1, ',''), IF((z.pcv1_date !=''),'PCV1, ',''), IF((z.rota1_date !=''),'Rota1, ',''))  FROM view_vaccination AS z WHERE (z.opv1_date !='' ||  z.penta1_date !='' || z.pcv1_date !='' || z.rota1_date !='' ) AND z.current_age>42	AND a.study_code=z.study_code) AS Done_Greater_6_Weeks, 					 (SELECT CONCAT(IF((z.opv1_date IS NULL || z.opv1_date =''),'OPV1, ',''), IF((z.penta1_date IS NULL || z.penta1_date =''),'Penta1, ',''), IF((z.pcv1_date IS NULL || z.pcv1_date =''),'PCV1, ',''), IF((z.rota1_date IS NULL || z.rota1_date =''),'Rota1, ',''))  FROM view_vaccination AS z WHERE (z.opv1_date IS NULL || z.opv1_date ='' || z.penta1_date IS NULL || z.penta1_date ='' || z.pcv1_date IS NULL || z.pcv1_date ='' || z.rota1_date IS NULL || z.rota1_date ='' ) AND z.current_age>42	AND a.study_code=z.study_code) AS Pending_Greater_6_Weeks, 			(SELECT CONCAT(IF((z.opv2_date !=''),'OPV2, ',''), IF((z.penta2_date !=''),'Penta2, ',''), IF((z.pcv2_date !=''),'PCV2, ',''), IF((z.rota2_date !=''),'Rota2, ',''))  FROM view_vaccination AS z WHERE (z.opv2_date !='' || z.penta2_date !='' || z.pcv2_date !='' || z.rota2_date !='' ) AND z.current_age>70	AND a.study_code=z.study_code) AS Done_Greater_10_Weeks, 				(SELECT CONCAT(IF((z.opv2_date IS NULL || z.opv2_date =''),'OPV2, ',''), IF((z.penta2_date IS NULL || z.penta2_date =''),'Penta2, ',''), IF((z.pcv2_date IS NULL || z.pcv2_date =''),'PCV2, ',''), IF((z.rota2_date IS NULL || z.rota2_date =''),'Rota2, ',''))  FROM view_vaccination AS z WHERE (z.opv2_date IS NULL || z.opv2_date ='' || z.penta2_date IS NULL || z.penta2_date ='' || z.pcv2_date IS NULL || z.pcv2_date ='' || z.rota2_date IS NULL || z.rota2_date ='' ) AND z.current_age>70	AND a.study_code=z.study_code) AS Pending_Greater_10_Weeks,  					(SELECT CONCAT(IF((z.opv3_date !=''),'OPV3, ',''), IF((z.penta3_date !=''),'Penta3, ',''), IF((z.pcv3_date !=''),'PCV3, ',''), IF((z.ipv_date !=''),'IPV, ',''))  FROM view_vaccination AS z WHERE (z.opv3_date !='' || z.penta3_date !='' || z.pcv3_date !='' || z.ipv_date !='') AND z.current_age>98	AND a.study_code=z.study_code) AS Done_Greater_14_Weeks, 			(SELECT CONCAT(IF((z.opv3_date IS NULL || z.opv3_date =''),'OPV3, ',''), IF((z.penta3_date IS NULL || z.penta3_date =''),'Penta3, ',''), IF((z.pcv3_date IS NULL || z.pcv3_date =''),'PCV3, ',''), IF((z.ipv_date IS NULL || z.ipv_date =''),'IPV, ',''))  FROM view_vaccination AS z WHERE (z.opv3_date IS NULL || z.opv3_date ='' || z.penta3_date IS NULL || z.penta3_date ='' || z.pcv3_date IS NULL || z.pcv3_date ='' || z.ipv_date IS NULL || z.ipv_date ='' ) AND z.current_age>98	AND a.study_code=z.study_code) AS Pending_Greater_14_Weeks,			 (SELECT IF((z.measles1_date !=''),'Measles-1','')  FROM view_vaccination AS z WHERE z.measles1_date !=''  AND z.current_age>270 AND a.study_code=z.study_code) AS Done_Measles1, (SELECT IF((z.measles1_date IS NULL || z.measles1_date =''),'Measles-1','')  FROM view_vaccination AS z WHERE (z.measles1_date IS NULL || z.measles1_date ='') AND z.current_age>270 AND a.study_code=z.study_code) AS Pending_Measles1, (SELECT IF((z.measles2_date !=''),'Measles-2','')  FROM view_vaccination AS z WHERE z.measles2_date !=''  AND z.current_age>470 AND a.study_code=z.study_code) AS Done_Measles2, (SELECT IF((z.measles2_date IS NULL || z.measles2_date =''),'Measles-2','')  FROM view_vaccination AS z WHERE (z.measles2_date IS NULL || z.measles2_date ='') AND z.current_age>470 AND a.study_code=z.study_code) AS Pending_Measles2    FROM view_vaccination AS a 		WHERE 	 a.dssid LIKE '" + txtdssid.Text + "%' ORDER BY a.site,MID(a.dssid,5,2);", con);

                //cmd = new MySqlCommand("select a.study_code,a.woman_nm,a.husband_nm,a.arm,a.dob, a.current_age,a.dssid,			(select concat(if((z.bcg0_date !=''),'BCG, ',''), if((z.opv0_date !=''),'OVP0, ',''))  from view_vaccination as z where (z.bcg0_date !='' || z.opv0_date !='' ) and z.current_age>1 and a.study_code=z.study_code) as Done_After_Birth,(select concat(if((z.bcg0_date is null || z.bcg0_date =''),'BCG, ',''), if((z.opv0_date is null || z.opv0_date =''),'OVP0, ',''))  from view_vaccination as z where (z.bcg0_date is null || z.bcg0_date ='' || z.opv0_date is null || z.opv0_date ='' ) and z.current_age>1 and a.study_code=z.study_code) as Pending_After_Birth,				(select concat(if((z.opv1_date !=''),'OPV1, ',''), if((z.penta1_date !=''),'Penta1, ',''), if((z.pcv1_date !=''),'PCV1, ',''), if((z.rota1_date !=''),'Rota1, ',''))  from view_vaccination as z where (z.opv1_date !='' ||  z.penta1_date !='' || z.pcv1_date !='' || z.rota1_date !='' ) and z.current_age>42	and a.study_code=z.study_code) as Done_Greater_6_Weeks, 					(select concat(if((z.opv1_date is null || z.opv1_date =''),'OPV1, ',''), if((z.penta1_date is null || z.penta1_date =''),'Penta1, ',''), if((z.pcv1_date is null || z.pcv1_date =''),'PCV1, ',''), if((z.rota1_date is null || z.rota1_date =''),'Rota1, ',''))  from view_vaccination as z where (z.opv1_date is null || z.opv1_date ='' || z.penta1_date is null || z.penta1_date ='' || z.pcv1_date is null || z.pcv1_date ='' || z.rota1_date is null || z.rota1_date ='' ) and z.current_age>42	and a.study_code=z.study_code) as Pending_Greater_6_Weeks, 			(select concat(if((z.opv2_date !=''),'OPV2, ',''), if((z.penta2_date !=''),'Penta2, ',''), if((z.pcv2_date !=''),'PCV2, ',''), if((z.rota2_date !=''),'Rota2, ',''))  from view_vaccination as z where (z.opv2_date !='' || z.penta2_date !='' || z.pcv2_date !='' || z.rota2_date !='' ) and z.current_age>70	and a.study_code=z.study_code) as Done_Greater_10_Weeks, 				(select concat(if((z.opv2_date is null || z.opv2_date =''),'OPV2, ',''), if((z.penta2_date is null || z.penta2_date =''),'Penta2, ',''), if((z.pcv2_date is null || z.pcv2_date =''),'PCV2, ',''), if((z.rota2_date is null || z.rota2_date =''),'Rota2, ',''))  from view_vaccination as z where (z.opv2_date is null || z.opv2_date ='' || z.penta2_date is null || z.penta2_date ='' || z.pcv2_date is null || z.pcv2_date ='' || z.rota2_date is null || z.rota2_date ='' ) and z.current_age>70	and a.study_code=z.study_code) as Pending_Greater_10_Weeks,  					(select concat(if((z.opv3_date !=''),'OPV3, ',''), if((z.penta3_date !=''),'Penta3, ',''), if((z.pcv3_date !=''),'PCV3, ',''), if((z.ipv_date !=''),'IPV, ',''))  from view_vaccination as z where (z.opv3_date !='' || z.penta3_date !='' || z.pcv3_date !='' || z.ipv_date !='') and z.current_age>98	and a.study_code=z.study_code) as Done_Greater_14_Weeks, 			(select concat(if((z.opv3_date is null || z.opv3_date =''),'OPV3, ',''), if((z.penta3_date is null || z.penta3_date =''),'Penta3, ',''), if((z.pcv3_date is null || z.pcv3_date =''),'PCV3, ',''), if((z.ipv_date is null || z.ipv_date =''),'IPV, ',''))  from view_vaccination as z where (z.opv3_date is null || z.opv3_date ='' || z.penta3_date is null || z.penta3_date ='' || z.pcv3_date is null || z.pcv3_date ='' || z.ipv_date is null || z.ipv_date ='' ) and z.current_age>98	and a.study_code=z.study_code) as Pending_Greater_14_Weeks			from view_vaccination as a 		where a.dod is null 		and ((select z.study_code  from view_vaccination as z where (z.bcg0_date is null || z.bcg0_date ='' || z.opv0_date is null || z.opv0_date ='' ) and z.current_age>1 and a.study_code=z.study_code) !='' || (select z.study_code  from view_vaccination as z where (z.opv1_date is null || z.opv1_date ='' || z.penta1_date is null || z.penta1_date ='' || z.pcv1_date is null || z.pcv1_date ='' || z.rota1_date is null || z.rota1_date ='' ) and z.current_age>42	and a.study_code=z.study_code) !='' || (select z.study_code from view_vaccination as z where (z.opv2_date is null || z.opv2_date ='' || z.penta2_date is null || z.penta2_date ='' || z.pcv2_date is null || z.pcv2_date ='' || z.rota2_date is null || z.rota2_date ='' ) and z.current_age>70	and a.study_code=z.study_code) !='' || (select z.study_code  from view_vaccination as z where (z.opv3_date is null || z.opv3_date ='' || z.penta3_date is null || z.penta3_date ='' || z.pcv3_date is null || z.pcv3_date ='' || z.ipv_date is null || z.ipv_date ='' ) and z.current_age>98	and a.study_code=z.study_code)!='') and a.dssid like '" + txtdssid.Text + "%' order by a.site,mid(a.dssid,5,2);", con);

                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }





        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExcelExport();
        }



        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {

                con.Open();
                MySqlCommand cmd;

                cmd = new MySqlCommand("SELECT a.study_code,a.woman_nm,a.husband_nm,a.arm,a.dob,a.dod, a.current_age,a.dssid,			 (SELECT CONCAT(IF((z.bcg0_date !=''),'BCG, ',''), IF((z.opv0_date !=''),'OVP0, ',''))  FROM view_vaccination AS z WHERE (z.bcg0_date !='' || z.opv0_date !='' ) AND z.current_age>1 AND a.study_code=z.study_code) AS Done_After_Birth, (SELECT CONCAT(IF((z.bcg0_date IS NULL || z.bcg0_date =''),'BCG, ',''), IF((z.opv0_date IS NULL || z.opv0_date =''),'OVP0, ',''))  FROM view_vaccination AS z WHERE (z.bcg0_date IS NULL || z.bcg0_date ='' || z.opv0_date IS NULL || z.opv0_date ='' ) AND z.current_age>1 AND a.study_code=z.study_code) AS Pending_After_Birth, (SELECT CONCAT(IF((z.opv1_date !=''),'OPV1, ',''), IF((z.penta1_date !=''),'Penta1, ',''), IF((z.pcv1_date !=''),'PCV1, ',''), IF((z.rota1_date !=''),'Rota1, ',''))  FROM view_vaccination AS z WHERE (z.opv1_date !='' ||  z.penta1_date !='' || z.pcv1_date !='' || z.rota1_date !='' ) AND z.current_age>42	AND a.study_code=z.study_code) AS Done_Greater_6_Weeks, 					 (SELECT CONCAT(IF((z.opv1_date IS NULL || z.opv1_date =''),'OPV1, ',''), IF((z.penta1_date IS NULL || z.penta1_date =''),'Penta1, ',''), IF((z.pcv1_date IS NULL || z.pcv1_date =''),'PCV1, ',''), IF((z.rota1_date IS NULL || z.rota1_date =''),'Rota1, ',''))  FROM view_vaccination AS z WHERE (z.opv1_date IS NULL || z.opv1_date ='' || z.penta1_date IS NULL || z.penta1_date ='' || z.pcv1_date IS NULL || z.pcv1_date ='' || z.rota1_date IS NULL || z.rota1_date ='' ) AND z.current_age>42	AND a.study_code=z.study_code) AS Pending_Greater_6_Weeks, 			(SELECT CONCAT(IF((z.opv2_date !=''),'OPV2, ',''), IF((z.penta2_date !=''),'Penta2, ',''), IF((z.pcv2_date !=''),'PCV2, ',''), IF((z.rota2_date !=''),'Rota2, ',''))  FROM view_vaccination AS z WHERE (z.opv2_date !='' || z.penta2_date !='' || z.pcv2_date !='' || z.rota2_date !='' ) AND z.current_age>70	AND a.study_code=z.study_code) AS Done_Greater_10_Weeks, 				(SELECT CONCAT(IF((z.opv2_date IS NULL || z.opv2_date =''),'OPV2, ',''), IF((z.penta2_date IS NULL || z.penta2_date =''),'Penta2, ',''), IF((z.pcv2_date IS NULL || z.pcv2_date =''),'PCV2, ',''), IF((z.rota2_date IS NULL || z.rota2_date =''),'Rota2, ',''))  FROM view_vaccination AS z WHERE (z.opv2_date IS NULL || z.opv2_date ='' || z.penta2_date IS NULL || z.penta2_date ='' || z.pcv2_date IS NULL || z.pcv2_date ='' || z.rota2_date IS NULL || z.rota2_date ='' ) AND z.current_age>70	AND a.study_code=z.study_code) AS Pending_Greater_10_Weeks,  					(SELECT CONCAT(IF((z.opv3_date !=''),'OPV3, ',''), IF((z.penta3_date !=''),'Penta3, ',''), IF((z.pcv3_date !=''),'PCV3, ',''), IF((z.ipv_date !=''),'IPV, ',''))  FROM view_vaccination AS z WHERE (z.opv3_date !='' || z.penta3_date !='' || z.pcv3_date !='' || z.ipv_date !='') AND z.current_age>98	AND a.study_code=z.study_code) AS Done_Greater_14_Weeks, 			(SELECT CONCAT(IF((z.opv3_date IS NULL || z.opv3_date =''),'OPV3, ',''), IF((z.penta3_date IS NULL || z.penta3_date =''),'Penta3, ',''), IF((z.pcv3_date IS NULL || z.pcv3_date =''),'PCV3, ',''), IF((z.ipv_date IS NULL || z.ipv_date =''),'IPV, ',''))  FROM view_vaccination AS z WHERE (z.opv3_date IS NULL || z.opv3_date ='' || z.penta3_date IS NULL || z.penta3_date ='' || z.pcv3_date IS NULL || z.pcv3_date ='' || z.ipv_date IS NULL || z.ipv_date ='' ) AND z.current_age>98	AND a.study_code=z.study_code) AS Pending_Greater_14_Weeks,			 (SELECT IF((z.measles1_date !=''),'Measles-1','')  FROM view_vaccination AS z WHERE z.measles1_date !=''  AND z.current_age>270 AND a.study_code=z.study_code) AS Done_Measles1, (SELECT IF((z.measles1_date IS NULL || z.measles1_date =''),'Measles-1','')  FROM view_vaccination AS z WHERE (z.measles1_date IS NULL || z.measles1_date ='') AND z.current_age>270 AND a.study_code=z.study_code) AS Pending_Measles1, (SELECT IF((z.measles2_date !=''),'Measles-2','')  FROM view_vaccination AS z WHERE z.measles2_date !=''  AND z.current_age>470 AND a.study_code=z.study_code) AS Done_Measles2, (SELECT IF((z.measles2_date IS NULL || z.measles2_date =''),'Measles-2','')  FROM view_vaccination AS z WHERE (z.measles2_date IS NULL || z.measles2_date ='') AND z.current_age>470 AND a.study_code=z.study_code) AS Pending_Measles2    FROM view_vaccination AS a 		WHERE 	 a.dssid LIKE '" + txtdssid.Text + "%' ORDER BY a.site,MID(a.dssid,5,2);", con);

                
                // before (03-07-2020)
               // cmd = new MySqlCommand("select a.study_code,a.woman_nm,a.husband_nm,a.arm,a.dob,a.dod, a.current_age,a.dssid,			(select concat(if((z.bcg0_date !=''),'BCG, ',''), if((z.opv0_date !=''),'OVP0, ',''))  from view_vaccination as z where (z.bcg0_date !='' || z.opv0_date !='' ) and z.current_age>1 and a.study_code=z.study_code) as Done_After_Birth,(select concat(if((z.bcg0_date is null || z.bcg0_date =''),'BCG, ',''), if((z.opv0_date is null || z.opv0_date =''),'OVP0, ',''))  from view_vaccination as z where (z.bcg0_date is null || z.bcg0_date ='' || z.opv0_date is null || z.opv0_date ='' ) and z.current_age>1 and a.study_code=z.study_code) as Pending_After_Birth,				(select concat(if((z.opv1_date !=''),'OPV1, ',''), if((z.penta1_date !=''),'Penta1, ',''), if((z.pcv1_date !=''),'PCV1, ',''), if((z.rota1_date !=''),'Rota1, ',''))  from view_vaccination as z where (z.opv1_date !='' ||  z.penta1_date !='' || z.pcv1_date !='' || z.rota1_date !='' ) and z.current_age>42	and a.study_code=z.study_code) as Done_Greater_6_Weeks, 					(select concat(if((z.opv1_date is null || z.opv1_date =''),'OPV1, ',''), if((z.penta1_date is null || z.penta1_date =''),'Penta1, ',''), if((z.pcv1_date is null || z.pcv1_date =''),'PCV1, ',''), if((z.rota1_date is null || z.rota1_date =''),'Rota1, ',''))  from view_vaccination as z where (z.opv1_date is null || z.opv1_date ='' || z.penta1_date is null || z.penta1_date ='' || z.pcv1_date is null || z.pcv1_date ='' || z.rota1_date is null || z.rota1_date ='' ) and z.current_age>42	and a.study_code=z.study_code) as Pending_Greater_6_Weeks, 			(select concat(if((z.opv2_date !=''),'OPV2, ',''), if((z.penta2_date !=''),'Penta2, ',''), if((z.pcv2_date !=''),'PCV2, ',''), if((z.rota2_date !=''),'Rota2, ',''))  from view_vaccination as z where (z.opv2_date !='' || z.penta2_date !='' || z.pcv2_date !='' || z.rota2_date !='' ) and z.current_age>70	and a.study_code=z.study_code) as Done_Greater_10_Weeks, 				(select concat(if((z.opv2_date is null || z.opv2_date =''),'OPV2, ',''), if((z.penta2_date is null || z.penta2_date =''),'Penta2, ',''), if((z.pcv2_date is null || z.pcv2_date =''),'PCV2, ',''), if((z.rota2_date is null || z.rota2_date =''),'Rota2, ',''))  from view_vaccination as z where (z.opv2_date is null || z.opv2_date ='' || z.penta2_date is null || z.penta2_date ='' || z.pcv2_date is null || z.pcv2_date ='' || z.rota2_date is null || z.rota2_date ='' ) and z.current_age>70	and a.study_code=z.study_code) as Pending_Greater_10_Weeks,  					(select concat(if((z.opv3_date !=''),'OPV3, ',''), if((z.penta3_date !=''),'Penta3, ',''), if((z.pcv3_date !=''),'PCV3, ',''), if((z.ipv_date !=''),'IPV, ',''))  from view_vaccination as z where (z.opv3_date !='' || z.penta3_date !='' || z.pcv3_date !='' || z.ipv_date !='') and z.current_age>70	and a.study_code=z.study_code) as Done_Greater_14_Weeks, 			(select concat(if((z.opv3_date is null || z.opv3_date =''),'OPV3, ',''), if((z.penta3_date is null || z.penta3_date =''),'Penta3, ',''), if((z.pcv3_date is null || z.pcv3_date =''),'PCV3, ',''), if((z.ipv_date is null || z.ipv_date =''),'IPV, ',''))  from view_vaccination as z where (z.opv3_date is null || z.opv3_date ='' || z.penta3_date is null || z.penta3_date ='' || z.pcv3_date is null || z.pcv3_date ='' || z.ipv_date is null || z.ipv_date ='' ) and z.current_age>98	and a.study_code=z.study_code) as Pending_Greater_14_Weeks			from view_vaccination as a 		where 	 a.dssid like '" + txtdssid.Text + "%' order by a.site,mid(a.dssid,5,2);", con);             
                // cmd = new MySqlCommand("select a.study_code,a.woman_nm,a.husband_nm,a.arm,a.dob, a.current_age,a.dssid,			(select concat(if((z.bcg0_date !=''),'BCG, ',''), if((z.opv0_date !=''),'OVP0, ',''))  from view_vaccination as z where (z.bcg0_date !='' || z.opv0_date !='' ) and z.current_age>1 and a.study_code=z.study_code) as Done_After_Birth,(select concat(if((z.bcg0_date is null || z.bcg0_date =''),'BCG, ',''), if((z.opv0_date is null || z.opv0_date =''),'OVP0, ',''))  from view_vaccination as z where (z.bcg0_date is null || z.bcg0_date ='' || z.opv0_date is null || z.opv0_date ='' ) and z.current_age>1 and a.study_code=z.study_code) as Pending_After_Birth,				(select concat(if((z.opv1_date !=''),'OPV1, ',''), if((z.penta1_date !=''),'Penta1, ',''), if((z.pcv1_date !=''),'PCV1, ',''), if((z.rota1_date !=''),'Rota1, ',''))  from view_vaccination as z where (z.opv1_date !='' ||  z.penta1_date !='' || z.pcv1_date !='' || z.rota1_date !='' ) and z.current_age>42	and a.study_code=z.study_code) as Done_Greater_6_Weeks, 					(select concat(if((z.opv1_date is null || z.opv1_date =''),'OPV1, ',''), if((z.penta1_date is null || z.penta1_date =''),'Penta1, ',''), if((z.pcv1_date is null || z.pcv1_date =''),'PCV1, ',''), if((z.rota1_date is null || z.rota1_date =''),'Rota1, ',''))  from view_vaccination as z where (z.opv1_date is null || z.opv1_date ='' || z.penta1_date is null || z.penta1_date ='' || z.pcv1_date is null || z.pcv1_date ='' || z.rota1_date is null || z.rota1_date ='' ) and z.current_age>42	and a.study_code=z.study_code) as Pending_Greater_6_Weeks, 			(select concat(if((z.opv2_date !=''),'OPV2, ',''), if((z.penta2_date !=''),'Penta2, ',''), if((z.pcv2_date !=''),'PCV2, ',''), if((z.rota2_date !=''),'Rota2, ',''))  from view_vaccination as z where (z.opv2_date !='' || z.penta2_date !='' || z.pcv2_date !='' || z.rota2_date !='' ) and z.current_age>70	and a.study_code=z.study_code) as Done_Greater_10_Weeks, 				(select concat(if((z.opv2_date is null || z.opv2_date =''),'OPV2, ',''), if((z.penta2_date is null || z.penta2_date =''),'Penta2, ',''), if((z.pcv2_date is null || z.pcv2_date =''),'PCV2, ',''), if((z.rota2_date is null || z.rota2_date =''),'Rota2, ',''))  from view_vaccination as z where (z.opv2_date is null || z.opv2_date ='' || z.penta2_date is null || z.penta2_date ='' || z.pcv2_date is null || z.pcv2_date ='' || z.rota2_date is null || z.rota2_date ='' ) and z.current_age>70	and a.study_code=z.study_code) as Pending_Greater_10_Weeks,  					(select concat(if((z.opv3_date !=''),'OPV3, ',''), if((z.penta3_date !=''),'Penta3, ',''), if((z.pcv3_date !=''),'PCV3, ',''), if((z.ipv_date !=''),'IPV, ',''))  from view_vaccination as z where (z.opv3_date !='' || z.penta3_date !='' || z.pcv3_date !='' || z.ipv_date !='') and z.current_age>98	and a.study_code=z.study_code) as Done_Greater_14_Weeks, 			(select concat(if((z.opv3_date is null || z.opv3_date =''),'OPV3, ',''), if((z.penta3_date is null || z.penta3_date =''),'Penta3, ',''), if((z.pcv3_date is null || z.pcv3_date =''),'PCV3, ',''), if((z.ipv_date is null || z.ipv_date =''),'IPV, ',''))  from view_vaccination as z where (z.opv3_date is null || z.opv3_date ='' || z.penta3_date is null || z.penta3_date ='' || z.pcv3_date is null || z.pcv3_date ='' || z.ipv_date is null || z.ipv_date ='' ) and z.current_age>98	and a.study_code=z.study_code) as Pending_Greater_14_Weeks			from view_vaccination as a 		where a.dod is null 		and ((select z.study_code  from view_vaccination as z where (z.bcg0_date is null || z.bcg0_date ='' || z.opv0_date is null || z.opv0_date ='' ) and z.current_age>1 and a.study_code=z.study_code) !='' || (select z.study_code  from view_vaccination as z where (z.opv1_date is null || z.opv1_date ='' || z.penta1_date is null || z.penta1_date ='' || z.pcv1_date is null || z.pcv1_date ='' || z.rota1_date is null || z.rota1_date ='' ) and z.current_age>42	and a.study_code=z.study_code) !='' || (select z.study_code from view_vaccination as z where (z.opv2_date is null || z.opv2_date ='' || z.penta2_date is null || z.penta2_date ='' || z.pcv2_date is null || z.pcv2_date ='' || z.rota2_date is null || z.rota2_date ='' ) and z.current_age>70	and a.study_code=z.study_code) !='' || (select z.study_code  from view_vaccination as z where (z.opv3_date is null || z.opv3_date ='' || z.penta3_date is null || z.penta3_date ='' || z.pcv3_date is null || z.pcv3_date ='' || z.ipv_date is null || z.ipv_date ='' ) and z.current_age>98	and a.study_code=z.study_code)!='') and a.dssid like '" + txtdssid.Text + "%' order by a.site,mid(a.dssid,5,2);", con);

                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView2.DataSource = dt;
                        GridView2.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }



        public void ExcelExport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Pending Vaccination (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2.AllowPaging = false;
                GridView2.CaptionAlign = TableCaptionAlign.Top;

                Exportdata();
                for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
                {
                    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#e17055");
                    GridView2.HeaderRow.Cells[i].Style.Add("Color", "white");
                    GridView2.HeaderRow.Cells[i].Style.Add("font-size", "15px");
                    GridView2.HeaderRow.Cells[i].Style.Add("height", "30px");
                }
                GridView2.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");
            }
        }


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[10].Text == "&nbsp;" && e.Row.Cells[11].Text == "&nbsp;")
                {
                    TableCell cell0 = e.Row.Cells[10];
                    cell0.BackColor = System.Drawing.Color.FromName("#636e72");
                    TableCell cell = e.Row.Cells[11];
                    cell.BackColor = System.Drawing.Color.FromName("#636e72");
                }
                if (e.Row.Cells[12].Text == "&nbsp;" && e.Row.Cells[13].Text == "&nbsp;")
                {
                    TableCell cell0 = e.Row.Cells[12];
                    cell0.BackColor = System.Drawing.Color.FromName("#636e72");
                    TableCell cell = e.Row.Cells[13];
                    cell.BackColor = System.Drawing.Color.FromName("#636e72");
                }
                if (e.Row.Cells[14].Text == "&nbsp;" && e.Row.Cells[15].Text == "&nbsp;")
                {
                    TableCell cell0 = e.Row.Cells[14];
                    cell0.BackColor = System.Drawing.Color.FromName("#636e72");
                    TableCell cell = e.Row.Cells[15];
                    cell.BackColor = System.Drawing.Color.FromName("#636e72");
                }

                if (e.Row.Cells[16].Text == "&nbsp;" && e.Row.Cells[17].Text == "&nbsp;")
                {
                    TableCell cell0 = e.Row.Cells[16];
                    cell0.BackColor = System.Drawing.Color.FromName("#636e72");
                    TableCell cell = e.Row.Cells[17];
                    cell.BackColor = System.Drawing.Color.FromName("#636e72");
                }
                if (e.Row.Cells[18].Text == "&nbsp;" && e.Row.Cells[19].Text == "&nbsp;")
                {
                    TableCell cell0 = e.Row.Cells[18];
                    cell0.BackColor = System.Drawing.Color.FromName("#636e72");
                    TableCell cell = e.Row.Cells[19];
                    cell.BackColor = System.Drawing.Color.FromName("#636e72");
                }



                // Pending Study_ID Red Color Indicator:
                if (e.Row.Cells[9].Text != "&nbsp;" && e.Row.Cells[20].Text == "&nbsp;")
                {
                    TableCell cell0 = e.Row.Cells[1];
                    cell0.BackColor = System.Drawing.Color.FromName("#ff7675");

                }
                if (e.Row.Cells[11].Text != "&nbsp;" && e.Row.Cells[20].Text == "&nbsp;")
                {
                    TableCell cell0 = e.Row.Cells[1];
                    cell0.BackColor = System.Drawing.Color.FromName("#ff7675");
                }
                if (e.Row.Cells[13].Text != "&nbsp;" && e.Row.Cells[20].Text == "&nbsp;")
                {
                    TableCell cell0 = e.Row.Cells[1];
                    cell0.BackColor = System.Drawing.Color.FromName("#ff7675");
                }
                if (e.Row.Cells[15].Text != "&nbsp;" && e.Row.Cells[20].Text == "&nbsp;")
                {
                    TableCell cell0 = e.Row.Cells[1];
                    cell0.BackColor = System.Drawing.Color.FromName("#ff7675");
                }
                if (e.Row.Cells[17].Text != "&nbsp;" && e.Row.Cells[20].Text == "&nbsp;")
                {
                    TableCell cell0 = e.Row.Cells[1];
                    cell0.BackColor = System.Drawing.Color.FromName("#ff7675");
                }
                if (e.Row.Cells[19].Text != "&nbsp;" && e.Row.Cells[20].Text == "&nbsp;")
                {
                    TableCell cell0 = e.Row.Cells[1];
                    cell0.BackColor = System.Drawing.Color.FromName("#ff7675");
                }



            
            }
        }


    }
}