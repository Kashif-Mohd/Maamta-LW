using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class showcrf4b : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateFormatPageLoad();
                Session["WebForm"] = "showcrf4b";
                ShowData();
                txtdssid.Focus();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
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

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtCalndrDate.Enabled = !CheckBox1.Checked;
            txtCalndrDate1.Enabled = !CheckBox1.Checked;
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
                if (CheckBox1.Checked == false)
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_crf4b WHERE DSSID LIKE '%" + txtdssid.Text + "%' and (str_to_date(lw_crf4b_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by str_to_date(lw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(lw_crf4b_3,  '%H:%i')", con);
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
                            con.Close();
                        }
                    }
                }
                else
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_crf4b WHERE DSSID LIKE '%" + txtdssid.Text + "%'  order by str_to_date(lw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(lw_crf4b_3,  '%H:%i')", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=NEWBORN CRF4b (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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

        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (CheckBox1.Checked == false)
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_crf4b WHERE DSSID LIKE '%" + txtdssid.Text + "%' and (str_to_date(lw_crf4b_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by str_to_date(lw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(lw_crf4b_3,  '%H:%i')", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 999999;
                        cmd.CommandType = CommandType.Text;
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
                    cmd = new MySqlCommand("select * from view_crf4b WHERE DSSID LIKE '%" + txtdssid.Text + "%'  order by str_to_date(lw_crf4b_2, '%d-%m-%Y'), STR_TO_DATE(lw_crf4b_3,  '%H:%i')", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 999999;
                        cmd.CommandType = CommandType.Text;
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
                if (e.Row.Cells[16].Text.Length == 1)
                {
                    e.Row.Cells[16].Text = "";
                }

                if (e.Row.Cells[15].Text == "1")
                {
                    e.Row.Cells[15].Text = "Complete";
                }
                else if (e.Row.Cells[15].Text == "2")
                {
                    e.Row.Cells[15].Text = "Woman/Baby not present";
                }
                else if (e.Row.Cells[15].Text == "3")
                {
                    e.Row.Cells[15].Text = "Refused";
                }
                else if (e.Row.Cells[15].Text == "4")
                {
                    e.Row.Cells[15].Text = "Household Locked";
                }
                else if (e.Row.Cells[15].Text == "5")
                {
                    e.Row.Cells[15].Text = "Permanent migration";
                }
                else if (e.Row.Cells[15].Text == "6")
                {
                    e.Row.Cells[15].Text = "Baby is adopted by someone else";
                }
            }
        }


        protected void Link_Study(object sender, EventArgs e)
        {
            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            string form_crf4b_id = commandArgs[0];
            string StudyId = commandArgs[1];

            Session["form_crf4b_id"] = form_crf4b_id;
            Session["StudyId_CRF4b"] = StudyId;
            Response.Redirect("showcrf4bbyid.aspx");
        }



























        protected void btnBMGF_Click(object sender, EventArgs e)
        {
            ExcelExportBMGF();
            txtdssid.Focus();
        }

        private void ExportdataBMGF()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT  a.followup_num AS 'q1', DATEDIFF(STR_TO_DATE(a.lw_crf4b_2, '%d-%m-%Y'),STR_TO_DATE(c.lw_crf2_21, '%d-%m-%Y'))   AS q2, b.study_code AS 'q3', a.lw_crf4b_2 AS 'q4', a.lw_crf4b_3 AS 'q5', (CASE    WHEN a.lw_crf4b_19 LIKE '0%' THEN '1'    WHEN a.lw_crf4b_19 LIKE '1%' THEN '2'    WHEN a.lw_crf4b_19 LIKE '2%' THEN '3'    WHEN a.lw_crf4b_19 LIKE '3%' THEN '4'    WHEN a.lw_crf4b_19 LIKE '4%' THEN '5'    WHEN a.lw_crf4b_19 LIKE '5%' THEN '6'    WHEN a.lw_crf4b_19 LIKE '76%' THEN '77' END)  AS q6, a.lw_crf4b_20 AS 'q7', a.lw_crf4b_21a AS 'q8_a', a.lw_crf4b_21b AS 'q8_b', a.lw_crf4b_21c AS 'q8_c', a.lw_crf4b_21d AS 'q8_d', a.lw_crf4b_21e AS 'q8_e',a.lw_crf4b_21f AS 'q8_f', a.lw_crf4b_21g AS 'q8_g', a.lw_crf4b_21h AS 'q8_h', a.lw_crf4b_21i AS 'q8_i', a.lw_crf4b_21j AS 'q8_j', a.lw_crf4b_21k AS 'q8_k', a.lw_crf4b_21l AS 'q8_l', a.lw_crf4b_21m AS 'q8_m',a.lw_crf4b_21n AS 'q8_n', a.lw_crf4b_21o AS 'q8_o', a.lw_crf4b_21p AS 'q8_p', a.lw_crf4b_21q AS 'q8_q', a.lw_crf4b_21r AS 'q8_r', a.lw_crf4b_21s AS 'q8_s', a.lw_crf4b_21t AS 'q8_t', a.lw_crf4b_21u AS 'q8_u',a.lw_crf4b_21v AS 'q8_v', a.lw_crf4b_21w AS 'q8_w', a.lw_crf4b_21x AS 'q8_x', a.lw_crf4b_21y AS 'q8_y', (CASE    WHEN a.lw_crf4b_21z LIKE '1:%' THEN '1'    WHEN a.lw_crf4b_21z NOT LIKE '1:%' THEN a.lw_crf4b_21z END)  AS q8_z, (CASE    WHEN a.lw_crf4b_21z LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf4b_21z, ':', 2), ':', -1)      END)  AS  q8_z_Description_of_any_other_complication, a.lw_crf4b_22 AS 'q9', a.lw_crf4b_23a AS 'q10_a', a.lw_crf4b_23b AS 'q10_b', a.lw_crf4b_23c AS 'q10_c',a.lw_crf4b_23d AS 'q10_d', a.lw_crf4b_23e AS 'q10_e', a.lw_crf4b_23f AS 'q10_f',          (CASE    WHEN a.lw_crf4b_23g LIKE '1:%' THEN '1'    WHEN a.lw_crf4b_23g NOT LIKE '1:%' THEN a.lw_crf4b_23g END)  AS 'q10_g',         a.lw_crf4b_23h AS 'q10_h', a.lw_crf4b_23i AS 'q10_i', a.lw_crf4b_23j AS 'q10_j', a.lw_crf4b_23k AS 'q10_k',a.lw_crf4b_23l AS 'q10_l', a.lw_crf4b_23m AS 'q10_m', a.lw_crf4b_24 AS 'q11', a.lw_crf4b_25a AS 'q12_a', a.lw_crf4b_25b AS 'q12_b', a.lw_crf4b_25c AS 'q12_c', a.lw_crf4b_25d AS 'q12_d', a.lw_crf4b_25e AS 'q12_e',a.lw_crf4b_25f AS 'q12_f', a.lw_crf4b_25g AS 'q12_g', a.lw_crf4b_25h AS 'q12_h', (CASE    WHEN a.lw_crf4b_25i LIKE '1:%' THEN '1'    WHEN a.lw_crf4b_25i NOT LIKE '1:%' THEN a.lw_crf4b_25i END)  AS q12_i, (CASE    WHEN a.lw_crf4b_25i LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf4b_25i, ':', 2), ':', -1)      END)  AS  q12_i_Description_of_other_treatment , a.lw_crf4b_26 AS 'q13', a.lw_crf4b_27a AS 'q14_a', a.lw_crf4b_27b AS 'q14_b', a.lw_crf4b_27c AS 'q14_c',a.lw_crf4b_27d AS 'q14_d', a.lw_crf4b_27e AS 'q14_e', a.lw_crf4b_27f AS 'q14_f', a.lw_crf4b_28 AS 'q15', a.lw_crf4b_29a AS 'q16_a',a.lw_crf4b_29b AS 'q16_b', a.lw_crf4b_29c AS 'q16_c', a.lw_crf4b_29d AS 'q16_d', a.lw_crf4b_29e AS 'q16_e',a.lw_crf4b_29f AS 'q16_f', a.lw_crf4b_30 AS 'q17', a.lw_crf4b_31 AS 'q18', a.lw_crf4b_32_hours AS 'q19_h',a.lw_crf4b_32days AS 'q19_d', a.lw_crf4b_33 AS 'q20', a.lw_crf4b_34a AS 'q21_a', a.lw_crf4b_34b AS 'q21_b',a.lw_crf4b_35 AS 'q22', a.lw_crf4b_36 AS 'q23', a.lw_crf4b_37a AS 'q24_a', a.lw_crf4b_37b AS 'q24_b',a.lw_crf4b_38 AS 'q25', a.lw_crf4b_39 AS 'q26', a.lw_crf4b_40 AS 'q27', a.lw_crf4b_41 AS 'q28',a.lw_crf4b_42a AS 'q29_a', a.lw_crf4b_42b1 AS 'q29_b1', a.lw_crf4b_42b2 AS 'q29_b2', a.lw_crf4b_42b3 AS 'q29_b3',a.lw_crf4b_42b4 AS 'q29_b4', a.lw_crf4b_43 AS 'q30', a.lw_crf4b_44 AS 'q31', a.lw_crf4b_45 AS 'q32',a.lw_crf4b_46 AS 'q33', a.lw_crf4b_47 AS 'q34', a.lw_crf4b_48 AS 'q35', a.lw_crf4b_49 AS 'q36',a.lw_crf4b_50a AS 'q37_a', a.lw_crf4b_50b AS 'q37_b', a.lw_crf4b_50c AS 'q37_c', a.lw_crf4b_50d AS 'q37_d',a.lw_crf4b_50e AS 'q37_e', a.lw_crf4b_50f AS 'q37_f', a.lw_crf4b_50g AS 'q37_g', a.lw_crf4b_50h AS 'q37_h',a.lw_crf4b_50i AS 'q37_i', a.lw_crf4b_50j AS 'q37_j', a.lw_crf4b_50k AS 'q37_k', a.lw_crf4b_50l AS 'q37_l',a.lw_crf4b_50m AS 'q37_m', a.lw_crf4b_50n AS 'q37_n', a.lw_crf4b_50o AS 'q37_o', (CASE    WHEN a.lw_crf4b_50p LIKE '1:%' THEN '1'    WHEN a.lw_crf4b_50p NOT LIKE '1:%' THEN a.lw_crf4b_50p END)  AS q37_p, (CASE    WHEN a.lw_crf4b_50p LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf4b_50p, ':', 2), ':', -1)      END)  AS  q37_p_Description_of_other, a.lw_crf4b_51 AS 'q38',a.lw_crf4b_52 AS 'q39', a.lw_crf4b_53 AS 'q40',a.lw_crf4b_54 AS 'q41', a.lw_crf4b_55a AS 'q42_a',a.lw_crf4b_55b AS 'q42_b', a.lw_crf4b_55c AS 'q42_c',a.lw_crf4b_55d AS 'q42_d',a.lw_crf4b_55e AS 'q42_e',a.lw_crf4b_55f AS 'q42_f',a.lw_crf4b_55g AS 'q42_g',a.lw_crf4b_55h AS 'q42_h',a.lw_crf4b_55i AS 'q42_i',a.lw_crf4b_55j AS 'q42_j',a.lw_crf4b_55k AS 'q42_k',(CASE    WHEN a.lw_crf4b_55l LIKE '1:%' THEN '1'    WHEN a.lw_crf4b_55l NOT LIKE '1:%' THEN a.lw_crf4b_55l END)  AS q42_l, (CASE    WHEN a.lw_crf4b_55l LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf4b_55l, ':', 2), ':', -1)      END)  AS  q42_l_Description_of_other, a.lw_crf4b_56 AS 'q43'  		FROM form_crf_4b AS a INNER JOIN studies AS b ON b.study_id=a.study_id INNER JOIN form_crf_2 AS c ON c.assis_id=b.assis_id", con);

                //cmd = new MySqlCommand("select  a.followup_num as 'Q2_A', DATEDIFF(str_to_date(a.lw_crf4b_2, '%d-%m-%Y'),str_to_date(c.lw_crf2_21, '%d-%m-%Y'))   as Q2_B, b.study_code as 'Q3', a.lw_crf4b_2 as 'Q5D', a.lw_crf4b_3 as 'Q5T', (CASE    WHEN a.lw_crf4b_19 like '0%' THEN '1'    WHEN a.lw_crf4b_19 like '1%' THEN '2'    WHEN a.lw_crf4b_19 like '2%' THEN '3'    WHEN a.lw_crf4b_19 like '3%' THEN '4'    WHEN a.lw_crf4b_19 like '4%' THEN '5'    WHEN a.lw_crf4b_19 like '5%' THEN '6'    WHEN a.lw_crf4b_19 like '76%' THEN '77' END)  as Q19, a.lw_crf4b_20 as 'Q20', a.lw_crf4b_21a as 'Q21_A', a.lw_crf4b_21b as 'Q21_B', a.lw_crf4b_21c as 'Q21_C', a.lw_crf4b_21d as 'Q21_D', a.lw_crf4b_21e as 'Q21_E',a.lw_crf4b_21f as 'Q21_F', a.lw_crf4b_21g as 'Q21_G', a.lw_crf4b_21h as 'Q21_H', a.lw_crf4b_21i as 'Q21_I', a.lw_crf4b_21j as 'Q21_J', a.lw_crf4b_21k as 'Q21_K', a.lw_crf4b_21l as 'Q21_L', a.lw_crf4b_21m as 'Q21_M',a.lw_crf4b_21n as 'Q21_N', a.lw_crf4b_21o as 'Q21_O', a.lw_crf4b_21p as 'Q21_P', a.lw_crf4b_21q as 'Q21_Q', a.lw_crf4b_21r as 'Q21_R', a.lw_crf4b_21s as 'Q21_S', a.lw_crf4b_21t as 'Q21_T', a.lw_crf4b_21u as 'Q21_U',a.lw_crf4b_21v as 'Q21_V', a.lw_crf4b_21w as 'Q21_W', a.lw_crf4b_21x as 'Q21_X', a.lw_crf4b_21y as 'Q21_Y', (CASE    WHEN a.lw_crf4b_21z like '1:%' THEN '1'    WHEN a.lw_crf4b_21z not like '1:%' THEN a.lw_crf4b_21z END)  as Q21_Z, (CASE    WHEN a.lw_crf4b_21z like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf4b_21z, ':', 2), ':', -1)      END)  as  Q21_Z_Description_of_any_other_complication, a.lw_crf4b_22 as 'Q22', a.lw_crf4b_23a as 'Q23_A', a.lw_crf4b_23b as 'Q23_B', a.lw_crf4b_23c as 'Q23_C',a.lw_crf4b_23d as 'Q23_D', a.lw_crf4b_23e as 'Q23_E', a.lw_crf4b_23f as 'Q23_F',          (CASE    WHEN a.lw_crf4b_23g like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf4b_23g, ':', 2), ':', -1)      END)  as 'Q23_G',         a.lw_crf4b_23h as 'Q23_H', a.lw_crf4b_23i as 'Q23_I', a.lw_crf4b_23j as 'Q23_J', a.lw_crf4b_23k as 'Q23_K',a.lw_crf4b_23l as 'Q23_L', a.lw_crf4b_23m as 'Q23_M', a.lw_crf4b_24 as 'Q24', a.lw_crf4b_25a as 'Q25_A', a.lw_crf4b_25b as 'Q25_B', a.lw_crf4b_25c as 'Q25_C', a.lw_crf4b_25d as 'Q25_D', a.lw_crf4b_25e as 'Q25_E',a.lw_crf4b_25f as 'Q25_F', a.lw_crf4b_25g as 'Q25_G', a.lw_crf4b_25h as 'Q25_H', (CASE    WHEN a.lw_crf4b_25i like '1:%' THEN '1'    WHEN a.lw_crf4b_25i not like '1:%' THEN a.lw_crf4b_25i END)  as Q25_I, (CASE    WHEN a.lw_crf4b_25i like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf4b_25i, ':', 2), ':', -1)      END)  as  Q25_I_Description_of_other_treatment , a.lw_crf4b_26 as 'Q26', a.lw_crf4b_27a as 'Q27_A', a.lw_crf4b_27b as 'Q27_B', a.lw_crf4b_27c as 'Q27_C',a.lw_crf4b_27d as 'Q27_D', a.lw_crf4b_27e as 'Q27_E', a.lw_crf4b_27f as 'Q27_F', a.lw_crf4b_28 as 'Q28', a.lw_crf4b_29a as 'Q29_A',a.lw_crf4b_29b as 'Q29_B', a.lw_crf4b_29c as 'Q29_C', a.lw_crf4b_29d as 'Q29_D', a.lw_crf4b_29e as 'Q29_E',a.lw_crf4b_29f as 'Q29_F', a.lw_crf4b_30 as 'Q30', a.lw_crf4b_31 as 'Q31', a.lw_crf4b_32_hours as 'Q32H',a.lw_crf4b_32days as 'Q32D', a.lw_crf4b_33 as 'Q33', a.lw_crf4b_34a as 'Q34_A', a.lw_crf4b_34b as 'Q34_B',a.lw_crf4b_35 as 'Q35', a.lw_crf4b_36 as 'Q36', a.lw_crf4b_37a as 'Q37_A', a.lw_crf4b_37b as 'Q37_B',a.lw_crf4b_38 as 'Q38', a.lw_crf4b_39 as 'Q39', a.lw_crf4b_40 as 'Q40', a.lw_crf4b_41 as 'Q41',a.lw_crf4b_42a as 'Q42_A', a.lw_crf4b_42b1 as 'Q42_B1', a.lw_crf4b_42b2 as 'Q42_B2', a.lw_crf4b_42b3 as 'Q42_B3',a.lw_crf4b_42b4 as 'Q42_B4', a.lw_crf4b_43 as 'Q43', a.lw_crf4b_44 as 'Q44', a.lw_crf4b_45 as 'Q45',a.lw_crf4b_46 as 'Q46', a.lw_crf4b_47 as 'Q47', a.lw_crf4b_48 as 'Q48', a.lw_crf4b_49 as 'Q49',a.lw_crf4b_50a as 'Q50_A', a.lw_crf4b_50b as 'Q50_B', a.lw_crf4b_50c as 'Q50_C', a.lw_crf4b_50d as 'Q50_D',a.lw_crf4b_50e as 'Q50_E', a.lw_crf4b_50f as 'Q50_F', a.lw_crf4b_50g as 'Q50_G', a.lw_crf4b_50h as 'Q50_H',a.lw_crf4b_50i as 'Q50_I', a.lw_crf4b_50j as 'Q50_J', a.lw_crf4b_50k as 'Q50_K', a.lw_crf4b_50l as 'Q50_L',a.lw_crf4b_50m as 'Q50_M', a.lw_crf4b_50n as 'Q50_N', a.lw_crf4b_50o as 'Q50_O', (CASE    WHEN a.lw_crf4b_50p like '1:%' THEN '1'    WHEN a.lw_crf4b_50p not like '1:%' THEN a.lw_crf4b_50p END)  as Q50_P, (CASE    WHEN a.lw_crf4b_50p like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf4b_50p, ':', 2), ':', -1)      END)  as  Q50_P_Description_of_other, a.lw_crf4b_51 as 'Q51',a.lw_crf4b_52 as 'Q52', a.lw_crf4b_53 as 'Q53',a.lw_crf4b_54 as 'Q54', a.lw_crf4b_55a as 'Q55_A',a.lw_crf4b_55b as 'Q55_B', a.lw_crf4b_55c as 'Q55_C',a.lw_crf4b_55d as 'Q55_D',a.lw_crf4b_55e as 'Q55_E',a.lw_crf4b_55f as 'Q55_F',a.lw_crf4b_55g as 'Q55_G',a.lw_crf4b_55h as 'Q55_H',a.lw_crf4b_55i as 'Q55_I',a.lw_crf4b_55j as 'Q55_J',a.lw_crf4b_55k as 'Q55_K',(CASE    WHEN a.lw_crf4b_55l like '1:%' THEN '1'    WHEN a.lw_crf4b_55l not like '1:%' THEN a.lw_crf4b_55l END)  as Q55_L, (CASE    WHEN a.lw_crf4b_55l like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf4b_55l, ':', 2), ':', -1)      END)  as  Q55_L_Description_of_other, a.lw_crf4b_56 as 'Q56'  		from form_crf_4b as a inner join studies as b on b.study_id=a.study_id inner join form_crf_2 as c on c.assis_id=b.assis_id", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
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
                Response.AddHeader("content-disposition", "attachment;filename=BMFG CRF4b (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridViewBMFG.AllowPaging = false;
                ExcelExportMessage();
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













    }
}