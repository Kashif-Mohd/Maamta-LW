using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class chkFollowpsNB : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "chkFollowupsNB";
                //  ShowData();
                txtdssid.Focus();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }




        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ShowData();

            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
            txtdssid.Focus();
        }



        public void ExcelExportMessage()
        {
            if (txtdssid.Text != "")
            {
                GridView2.Caption = "DSSID, Search by: " + txtdssid.Text;
            }
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
                if (ddAgeMonth.SelectedValue == "0")
                {
                    showalert("Please select Child Age");
                    ddAgeMonth.Focus();
                }
                else if (ddAgeMonth.SelectedValue == "<160")
                {
                    cmd = new MySqlCommand("select c.study_code,concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) as dssid,a.lw_crf1_09 as woman_nm,a.lw_crf1_10 as husband_nm, 			(to_days(curdate()) - to_days(str_to_date(e.lw_crf2_21,'%d-%m-%Y'))) AS current_age,d.lw_crf_3a_19 as ARM,	(select count(z.study_code) from view_followups4a as z where z.study_code=c.study_code and str_to_date(z.date, '%d-%m-%Y') <= CURDATE()) as Total_Followups, 	(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id) as CRF4a_Filled,(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 ='0') as CRF4a_Complete,	(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 !='0') as CRF4a_InComplete,		(select count(z.study_id) from form_crf_5a as z where z.study_id=c.study_id) as CRF5a_Complete			from pw as a left join dss_address as b on a.dss_id=b.dss_id left join studies as c on c.assis_id=a.id left join form_crf_3a as d on d.assis_id=a.id left join form_crf_2 as e on e.assis_id=d.assis_id where c.study_code is not null and  concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) like '" + txtdssid.Text.ToUpper() + "%' and 		(to_days(curdate()) - to_days(str_to_date(e.lw_crf2_21,'%d-%m-%Y'))) <160 order by c.study_code", con);
                    //cmd = new MySqlCommand("select c.study_code,concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) as dssid,a.lw_crf1_09 as woman_nm,a.lw_crf1_10 as husband_nm, d.lw_crf_3a_19 as ARM,			(select count(z.study_code) from view_followups4a as z where z.study_code=c.study_code and str_to_date(z.date, '%d-%m-%Y') <= CURDATE()) as Total_Followups, (select count(z.study_code) from view_followups4a as z where z.study_code=c.study_code and str_to_date(z.date, '%d-%m-%Y') <= CURDATE() and z.Day='Sunday') as Total_Sunday,	(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id) as CRF4a_Filled,(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 !='0') as CRF4a_Incomplete,(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 ='0') as CRF4a_Complete,		(select count(z.study_id) from form_crf_5a as z where z.study_id=c.study_id) as CRF5a_Complete		from pw as a left join dss_address as b on a.dss_id=b.dss_id left join studies as c on c.assis_id=a.id left join form_crf_3a as d on d.assis_id=a.id where c.study_code is not null and  concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) like '" + txtdssid.Text.ToUpper() + "%' order by c.study_code", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                            con.Close();
                        }
                    }
                }
                else if (ddAgeMonth.SelectedValue == ">=160")
                {
                    cmd = new MySqlCommand("select c.study_code,concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) as dssid,a.lw_crf1_09 as woman_nm,a.lw_crf1_10 as husband_nm, 			(to_days(curdate()) - to_days(str_to_date(e.lw_crf2_21,'%d-%m-%Y'))) AS current_age,d.lw_crf_3a_19 as ARM,	(select count(z.study_code) from view_followups4a as z where z.study_code=c.study_code and str_to_date(z.date, '%d-%m-%Y') <= CURDATE()) as Total_Followups, 	(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id) as CRF4a_Filled,(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 ='0') as CRF4a_Complete,	(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 !='0') as CRF4a_InComplete,		(select count(z.study_id) from form_crf_5a as z where z.study_id=c.study_id) as CRF5a_Complete			from pw as a left join dss_address as b on a.dss_id=b.dss_id left join studies as c on c.assis_id=a.id left join form_crf_3a as d on d.assis_id=a.id left join form_crf_2 as e on e.assis_id=d.assis_id where c.study_code is not null and  concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) like '" + txtdssid.Text.ToUpper() + "%' and 		(to_days(curdate()) - to_days(str_to_date(e.lw_crf2_21,'%d-%m-%Y'))) >=160 order by c.study_code", con);
                    //cmd = new MySqlCommand("select c.study_code,concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) as dssid,a.lw_crf1_09 as woman_nm,a.lw_crf1_10 as husband_nm, d.lw_crf_3a_19 as ARM,			(select count(z.study_code) from view_followups4a as z where z.study_code=c.study_code and str_to_date(z.date, '%d-%m-%Y') <= CURDATE()) as Total_Followups, (select count(z.study_code) from view_followups4a as z where z.study_code=c.study_code and str_to_date(z.date, '%d-%m-%Y') <= CURDATE() and z.Day='Sunday') as Total_Sunday,	(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id) as CRF4a_Filled,(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 !='0') as CRF4a_Incomplete,(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 ='0') as CRF4a_Complete,		(select count(z.study_id) from form_crf_5a as z where z.study_id=c.study_id) as CRF5a_Complete		from pw as a left join dss_address as b on a.dss_id=b.dss_id left join studies as c on c.assis_id=a.id left join form_crf_3a as d on d.assis_id=a.id where c.study_code is not null and  concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) like '" + txtdssid.Text.ToUpper() + "%' order by c.study_code", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                            con.Close();
                        }
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
                Response.AddHeader("content-disposition", "attachment;filename=Compliance% Cumulative  (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2.AllowPaging = false;
                ExcelExportMessage();
                GridView2.CaptionAlign = TableCaptionAlign.Top;

                Exportdata();
                for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
                {
                    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridView2.HeaderRow.Cells[i].Style.Add("Color", "white");
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


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
            txtdssid.Focus();
        }



        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;

                if (ddAgeMonth.SelectedValue == "0")
                {
                    showalert("Please select Child Age");
                    ddAgeMonth.Focus();
                }
                else if (ddAgeMonth.SelectedValue == "<160")
                {
                    cmd = new MySqlCommand("select c.study_code,concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) as dssid,a.lw_crf1_09 as woman_nm,a.lw_crf1_10 as husband_nm, 			(to_days(curdate()) - to_days(str_to_date(e.lw_crf2_21,'%d-%m-%Y'))) AS current_age,d.lw_crf_3a_19 as ARM,	(select count(z.study_code) from view_followups4a as z where z.study_code=c.study_code and str_to_date(z.date, '%d-%m-%Y') <= CURDATE()) as Total_Followups, 	(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id) as CRF4a_Filled,(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 ='0') as CRF4a_Complete,	(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 !='0') as CRF4a_InComplete,		(select count(z.study_id) from form_crf_5a as z where z.study_id=c.study_id) as CRF5a_Complete			from pw as a left join dss_address as b on a.dss_id=b.dss_id left join studies as c on c.assis_id=a.id left join form_crf_3a as d on d.assis_id=a.id left join form_crf_2 as e on e.assis_id=d.assis_id where c.study_code is not null and  concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) like '" + txtdssid.Text.ToUpper() + "%' and 		(to_days(curdate()) - to_days(str_to_date(e.lw_crf2_21,'%d-%m-%Y'))) <160 order by c.study_code", con);
                    //cmd = new MySqlCommand("select c.study_code,concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) as dssid,a.lw_crf1_09 as woman_nm,a.lw_crf1_10 as husband_nm, d.lw_crf_3a_19 as ARM,			(select count(z.study_code) from view_followups4a as z where z.study_code=c.study_code and str_to_date(z.date, '%d-%m-%Y') <= CURDATE()) as Total_Followups, (select count(z.study_code) from view_followups4a as z where z.study_code=c.study_code and str_to_date(z.date, '%d-%m-%Y') <= CURDATE() and z.Day='Sunday') as Total_Sunday,	(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id) as CRF4a_Filled,(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 !='0') as CRF4a_Incomplete,(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 ='0') as CRF4a_Complete,		(select count(z.study_id) from form_crf_5a as z where z.study_id=c.study_id) as CRF5a_Complete		from pw as a left join dss_address as b on a.dss_id=b.dss_id left join studies as c on c.assis_id=a.id left join form_crf_3a as d on d.assis_id=a.id where c.study_code is not null and  concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) like '" + txtdssid.Text.ToUpper() + "%' order by c.study_code", con);

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
                else if (ddAgeMonth.SelectedValue == ">=160")
                {
                    cmd = new MySqlCommand("select c.study_code,concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) as dssid,a.lw_crf1_09 as woman_nm,a.lw_crf1_10 as husband_nm, 			(to_days(curdate()) - to_days(str_to_date(e.lw_crf2_21,'%d-%m-%Y'))) AS current_age,d.lw_crf_3a_19 as ARM,	(select count(z.study_code) from view_followups4a as z where z.study_code=c.study_code and str_to_date(z.date, '%d-%m-%Y') <= CURDATE()) as Total_Followups, 	(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id) as CRF4a_Filled,(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 ='0') as CRF4a_Complete,	(select count(z.study_id) from form_crf_4a as z where z.study_id=c.study_id and z.lw_crf4a_19 !='0') as CRF4a_InComplete,		(select count(z.study_id) from form_crf_5a as z where z.study_id=c.study_id) as CRF5a_Complete			from pw as a left join dss_address as b on a.dss_id=b.dss_id left join studies as c on c.assis_id=a.id left join form_crf_3a as d on d.assis_id=a.id left join form_crf_2 as e on e.assis_id=d.assis_id where c.study_code is not null and  concat(b.lw_crf_1_11,b.lw_crf_1_12,b.lw_crf_1_13,b.lw_crf_1_14,b.lw_crf_1_15,b.lw_crf_1_16) like '" + txtdssid.Text.ToUpper() + "%' and 		(to_days(curdate()) - to_days(str_to_date(e.lw_crf2_21,'%d-%m-%Y'))) >=160 order by c.study_code", con);
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


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    TableCell cell8 = e.Row.Cells[8];
            //    TableCell cell10 = e.Row.Cells[10];
            //    TableCell cell20 = e.Row.Cells[20];
            //    TableCell cell28 = e.Row.Cells[28];

            //    cell8.BackColor = System.Drawing.Color.FromName("#ffeaa7");
            //    cell10.BackColor = System.Drawing.Color.FromName("#ffeaa7");
            //    cell20.BackColor = System.Drawing.Color.FromName("#ffeaa7");
            //    cell28.BackColor = System.Drawing.Color.FromName("#bdc3c7");

            //    // LW MUAC

            //    if (e.Row.Cells[12].Text != "&nbsp;" && e.Row.Cells[11].Text != "&nbsp;" && (float.Parse(e.Row.Cells[12].Text) < float.Parse(e.Row.Cells[11].Text)))
            //    {
            //        TableCell cell = e.Row.Cells[12];
            //        cell.BackColor = System.Drawing.Color.FromName("#ff7675");
            //    }               
            //}
        }



    }
}