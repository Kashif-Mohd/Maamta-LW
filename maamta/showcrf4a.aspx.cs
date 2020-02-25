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
    public partial class showcrf4a : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateFormatPageLoad();
                Session["WebForm"] = "showcrf4a";
                // ShowData();
                txtdssid.Focus();
            }

        }

        private void DateFormatPageLoad()
        {
            txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate.Attributes.Add("readonly", "readonly");
            txtCalndrDate1.Attributes.Add("readonly", "readonly");
            txtCalndrDate.Enabled = true;
            txtCalndrDate1.Enabled = true;
            CheckBox1.Checked = false;
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtCalndrDate.Enabled = !CheckBox1.Checked;
            txtCalndrDate1.Enabled = !CheckBox1.Checked;
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == false && DateTime.ParseExact(txtCalndrDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtCalndrDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
            {
                showalert("First Date should be Less or Equal than Second Date");
                txtCalndrDate.Focus();
            }
            else
            {
                ShowData();
                txtdssid.Focus();
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (CheckBox1.Checked == false)
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_crf4a where dssid like '%" + txtdssid.Text + "%' and (str_to_date(date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by str_to_date(date_of_attempt, '%d-%m-%Y'), STR_TO_DATE(time_of_attempt,  '%H:%i')", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 9999999;
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
                else
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_crf4a where dssid like '%" + txtdssid.Text + "%'  order by str_to_date(date_of_attempt, '%d-%m-%Y'), STR_TO_DATE(time_of_attempt,  '%H:%i')", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 9999999;
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[17].Text.Length == 1)
                {
                    e.Row.Cells[17].Text = "";
                }

                if (e.Row.Cells[16].Text == "1")
                {
                    e.Row.Cells[16].Text = "Complete";
                }
                else if (e.Row.Cells[16].Text == "2")
                {
                    e.Row.Cells[16].Text = "Woman/Baby not present";
                }
                else if (e.Row.Cells[16].Text == "3")
                {
                    e.Row.Cells[16].Text = "Refused";
                }
                else if (e.Row.Cells[16].Text == "4")
                {
                    e.Row.Cells[16].Text = "Household Locked";
                }
                else if (e.Row.Cells[16].Text == "5")
                {
                    e.Row.Cells[16].Text = "Permanent migration";
                }
                else if (e.Row.Cells[16].Text == "6")
                {
                    e.Row.Cells[16].Text = "Baby is adopted by someone else";
                }
            }
        }

        protected void Link_Study(object sender, EventArgs e)
        {
            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            string form_crf4a_id = commandArgs[0];
            string StudyId = commandArgs[1];

            Session["form_crf4a_id"] = form_crf4a_id;
            Session["StudyId_CRF4a"] = StudyId;
            Response.Redirect("showcrf4abyid.aspx");
        }
















































        protected void btnBMGF_Click(object sender, EventArgs e)
        {
            //ExcelExportBMGF();
            //txtdssid.Focus();
        }

        protected void btnBMGF_Details_Click(object sender, EventArgs e)
        {
            //ExcelExportBMGF_Details();
            //txtdssid.Focus();
        }








        private void ExportdataBMGF()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;

                cmd = new MySqlCommand("SELECT a.form_crf_4a_id,a.followup_num AS q1,c.study_code AS q2, DAYNAME(STR_TO_DATE(a.date_of_attempt, '%d-%m-%Y')) AS q3,a.date_of_attempt AS q4,a.time_of_attempt AS q5,  	  (CASE    WHEN aa.lw_crf_3a_19 LIKE '%a%' THEN '44'    WHEN aa.lw_crf_3a_19 LIKE '%b%' THEN '55'    WHEN aa.lw_crf_3a_19 LIKE '%c%' THEN '66' END)  AS q6,		 	SUBSTRING_INDEX(a.lw_crf4a_19, ':', 1)+1 AS q7, a.lw_crf4a_20 AS q8,a.lw_crf4a_21 AS q9,a.lw_crf4a_22 AS q10,a.lw_crf4a_23 AS q11,a.lw_crf4a_24 AS q12,a.lw_crf4a_25 AS q13,       			( (SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_28=1 AND form_crf_4a_id=a.form_crf_4a_id) + (SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_40=1 AND form_crf_4a_id=a.form_crf_4a_id) + (SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_46=1 AND form_crf_4a_id=a.form_crf_4a_id) + (SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_52=1 AND form_crf_4a_id=a.form_crf_4a_id) + (SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_58=1 AND form_crf_4a_id=a.form_crf_4a_id) + (SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_63=1 AND form_crf_4a_id=a.form_crf_4a_id) + (SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_68=1 AND form_crf_4a_id=a.form_crf_4a_id) + (SELECT COUNT(*) FROM form_crf_4a_details WHERE (lw_crf4a_73a=1 || lw_crf4a_73b=1 || lw_crf4a_73c=1 || lw_crf4a_73c=1 || lw_crf4a_73d=1 || lw_crf4a_73e=1  || lw_crf4a_73f=1  || lw_crf4a_73g=1 || lw_crf4a_73h=1 || lw_crf4a_73i=1  || lw_crf4a_73j!=2) AND form_crf_4a_id=a.form_crf_4a_id)   ) q57,			(SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_28=1 AND form_crf_4a_id=a.form_crf_4a_id) AS q58,				(  (SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_40=1 AND form_crf_4a_id=a.form_crf_4a_id) + (SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_46=1 AND form_crf_4a_id=a.form_crf_4a_id) + (SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_52=1 AND form_crf_4a_id=a.form_crf_4a_id) + (SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_58=1 AND form_crf_4a_id=a.form_crf_4a_id) + (SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_63=1 AND form_crf_4a_id=a.form_crf_4a_id) + (SELECT COUNT(*) FROM form_crf_4a_details WHERE lw_crf4a_68=1 AND form_crf_4a_id=a.form_crf_4a_id)) q59 ,			((SELECT COUNT(*) FROM form_crf_4a_details WHERE (lw_crf4a_73a=1 || lw_crf4a_73b=1 || lw_crf4a_73c=1 || lw_crf4a_73c=1 || lw_crf4a_73d=1 || lw_crf4a_73e=1  || lw_crf4a_73f=1  || lw_crf4a_73g=1 || lw_crf4a_73h=1 || lw_crf4a_73i=1  || lw_crf4a_73j!=2) AND form_crf_4a_id=a.form_crf_4a_id) ) q60 ,				a.counsil_end_time AS q62			FROM form_crf_4a AS a  LEFT JOIN studies AS c ON c.study_id=a.study_id	    LEFT JOIN form_crf_3a AS aa ON aa.assis_id=c.assis_id 	LEFT JOIN form_crf_3a AS i ON i.lw_crf_3a_4= c.study_code   GROUP  BY a.form_crf_4a_id ORDER BY c.study_code,a.followup_num", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;

                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridViewBMFG.DataSource = dt;
                        GridViewBMFG.DataBind();
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




        public void ExcelExportBMGF()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=BMFG CRF4a (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridViewBMFG.AllowPaging = false;
                GridViewBMFG.CaptionAlign = TableCaptionAlign.Top;

                ExportdataBMGF();
                for (int i = 0; i < GridViewBMFG.HeaderRow.Cells.Count; i++)
                {
                    GridViewBMFG.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridViewBMFG.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridViewBMFG.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");

            }
        }









        private void ExportdataBMGF_Details()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;

                cmd = new MySqlCommand("SELECT a.form_crf_4a_id AS form_crf_4a_id, a.lw_crf4a_27_from AS q15_a, a.lw_crf4a_27_to AS q15_b, (CASE WHEN a.lw_crf4a_28 !='' THEN '1' ELSE '2' END) AS q16, a.lw_crf4a_28 AS q17, a.lw_crf4a_29 AS q18, a.lw_crf4a_30 AS q19, a.lw_crf4a_31 AS q20, a.lw_crf4a_32 AS q21, a.lw_crf4a_33 AS q22, a.lw_crf4a_34 AS q23, a.lw_crf4a_35 AS q24, a.lw_crf4a_36 AS q25, a.lw_crf4a_37 AS q26, a.lw_crf4a_38 AS q27, a.lw_crf4a_39 AS q28, a.lw_crf4a_40 AS q29, a.lw_crf4a_41 AS q30, a.lw_crf4a_43 AS q31, a.lw_crf4a_45 AS q32, a.lw_crf4a_46 AS q33, a.lw_crf4a_47 AS q34, a.lw_crf4a_48 AS q35, a.lw_crf4a_49 AS q36, a.lw_crf4a_50 AS q37, a.lw_crf4a_51 AS q38, a.lw_crf4a_52 AS q39, a.lw_crf4a_53 AS q40, a.lw_crf4a_54 AS q41, a.lw_crf4a_55 AS q42, a.lw_crf4a_56 AS q43, a.lw_crf4a_57 AS q44, a.lw_crf4a_58 AS q45, a.lw_crf4a_60 AS q46, a.lw_crf4a_62 AS q47, a.lw_crf4a_63 AS q48, a.lw_crf4a_65 AS q49, a.lw_crf4a_67 AS q50, a.lw_crf4a_68 AS q51, a.lw_crf4a_69 AS q52, a.lw_crf4a_70 AS q53, a.lw_crf4a_71 AS q54, a.lw_crf4a_72 AS q55, a.lw_crf4a_73a AS q56_A, a.lw_crf4a_73b AS q56_B, a.lw_crf4a_73c AS q56_C, a.lw_crf4a_73d AS q56_D, a.lw_crf4a_73e AS q56_E, a.lw_crf4a_73f AS q56_F, a.lw_crf4a_73g AS q56_G, a.lw_crf4a_73h AS q56_H, a.lw_crf4a_73i AS q56_I, (CASE    WHEN a.lw_crf4a_73j LIKE '1:%' THEN '1'    WHEN a.lw_crf4a_73j NOT LIKE '1:%' THEN a.lw_crf4a_73j END)  AS q56_J, (CASE    WHEN a.lw_crf4a_73j LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf4a_73j, ':', 2), ':', -1)      END)  AS  q56_J_DESCRIPTION 			FROM 	form_crf_4a_details AS a", con);

                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;

                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridViewBMFG_Details.DataSource = dt;
                        GridViewBMFG_Details.DataBind();
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




        public void ExcelExportBMGF_Details()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=BMFG CRF4a_Details (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridViewBMFG_Details.AllowPaging = false;
                GridViewBMFG_Details.CaptionAlign = TableCaptionAlign.Top;

                ExportdataBMGF_Details();
                for (int i = 0; i < GridViewBMFG_Details.HeaderRow.Cells.Count; i++)
                {
                    GridViewBMFG_Details.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridViewBMFG_Details.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridViewBMFG_Details.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");
            }
        }















    }
}