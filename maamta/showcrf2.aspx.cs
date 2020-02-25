using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class showcrf2 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["RANDdssid"] != null)
                {
                    Session["WebForm"] = "randDuplicate";
                    lbeDateFromTo.Text = "(search by DSSID: '" + Convert.ToString(Session["RANDdssid"]) + "')";
                    txtdssid.Text = Convert.ToString(Session["RANDdssid"]);
                    //Disable Calendar:
                    txtCalndrDate.Enabled = false;
                    txtCalndrDate1.Enabled = false;
                    CheckBox1.Checked = true;

                    ShowData();
                    calendar.Visible = false;
                    divExportButton.Visible = false;
                    divSearch.Visible = false;
                }
                else
                {
                    divBackButton.Visible = false;
                    DateFormatPageLoad();
                    Session["WebForm"] = "showcrf2";
                    ShowData();
                    txtdssid.Focus();
                }
            }
        }




        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["BackButtonShowCRF2"]) == "randduplicate")
            {
                Session["BackButtonShowCRF2"] = null;
                Session["RANDdssid"] = null;
                Response.Redirect("randduplicate.aspx");
            }
        }



        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
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

        private void DateFormatPageLoad()
        {
            txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate.Attributes.Add("readonly", "readonly");
            txtCalndrDate1.Attributes.Add("readonly", "readonly");
            txtCalndrDate.Enabled = false;
            txtCalndrDate1.Enabled = false;
            CheckBox1.Checked = true;
        }


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtCalndrDate.Enabled = !CheckBox1.Checked;
            txtCalndrDate1.Enabled = !CheckBox1.Checked;
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
                    cmd = new MySqlCommand("select a.*,b.code_of_reader_1 as code1,b.code_of_reader_2 as code2, b.reader1  as LW_MUAC_R1,	b.reader2  as LW_MUAC_R2, c.reader1  as Child_Weight_R1,	c.reader2  as Child_Weight_R2  from view_crf2 as a 		left join(select * from arm_reading where arm_reading_id in ( select max(arm_reading_id) from arm_reading group by form_crf_2_id)) as b on b.form_crf_2_id=a.form_crf_2 left join(select * from child_weight where child_weight_id in ( select max(child_weight_id) from child_weight group by form_crf_2_id)) as c on c.form_crf_2_id=a.form_crf_2	         WHERE a.DSSID LIKE '%" + txtdssid.Text + "%' and (str_to_date(a.date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  order by a.form_crf_2", con);
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
                else
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select a.*,b.code_of_reader_1 as code1,b.code_of_reader_2 as code2, b.reader1  as LW_MUAC_R1,	b.reader2  as LW_MUAC_R2, c.reader1  as Child_Weight_R1,	c.reader2  as Child_Weight_R2  from view_crf2 as a 		left join(select * from arm_reading where arm_reading_id in ( select max(arm_reading_id) from arm_reading group by form_crf_2_id)) as b on b.form_crf_2_id=a.form_crf_2 left join(select * from child_weight where child_weight_id in ( select max(child_weight_id) from child_weight group by form_crf_2_id)) as c on c.form_crf_2_id=a.form_crf_2	         WHERE a.DSSID LIKE '%" + txtdssid.Text + "%' order by a.form_crf_2", con);
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




        protected void Link_Assis(object sender, EventArgs e)
        {
            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            string form_crf_2 = commandArgs[0];
            string AssismentId = commandArgs[1];

            Session["form_crf_2"] = form_crf_2;
            Session["AssismentIdCRF2"] = AssismentId;
            // Session["BackButton"] = "showcrf2";
            Response.Redirect("showcrf2byid.aspx");
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
            //else if (DropDownList1.SelectedValue == "1")
            //{
            //    GridView2.Caption = "MUAC Less than 24";
            //}
            //else if (DropDownList1.SelectedValue == "2")
            //{
            //    GridView2.Caption = "MUAC Greater than and Equal to 24";
            //}
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
                    cmd = new MySqlCommand("select a.*,b.code_of_reader_1 as code1,b.code_of_reader_2 as code2, b.reader1  as LW_MUAC_R1,	b.reader2  as LW_MUAC_R2, c.reader1  as Child_Weight_R1,	c.reader2  as Child_Weight_R2  from view_crf2 as a 		left join(select * from arm_reading where arm_reading_id in ( select max(arm_reading_id) from arm_reading group by form_crf_2_id)) as b on b.form_crf_2_id=a.form_crf_2 left join(select * from child_weight where child_weight_id in ( select max(child_weight_id) from child_weight group by form_crf_2_id)) as c on c.form_crf_2_id=a.form_crf_2	         WHERE a.DSSID LIKE '%" + txtdssid.Text + "%' and (str_to_date(a.date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  order by a.form_crf_2", con);
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
                else
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select a.*,b.code_of_reader_1 as code1,b.code_of_reader_2 as code2, b.reader1  as LW_MUAC_R1,	b.reader2  as LW_MUAC_R2, c.reader1  as Child_Weight_R1,	c.reader2  as Child_Weight_R2  from view_crf2 as a 		left join(select * from arm_reading where arm_reading_id in ( select max(arm_reading_id) from arm_reading group by form_crf_2_id)) as b on b.form_crf_2_id=a.form_crf_2 left join(select * from child_weight where child_weight_id in ( select max(child_weight_id) from child_weight group by form_crf_2_id)) as c on c.form_crf_2_id=a.form_crf_2	         WHERE a.DSSID LIKE '%" + txtdssid.Text + "%' order by a.form_crf_2", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=RANDOM CRF2 (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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

        int q44;

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                q44 = 0;
                //Q44 (Condition-1)
                if (e.Row.Cells[14].Text == "1" && e.Row.Cells[21].Text == "1" && e.Row.Cells[24].Text != "&nbsp;" && Convert.ToInt32(e.Row.Cells[24].Text) < 168)
                {
                    e.Row.Cells[47].Text = "True";
                    q44++;
                }
                //Q44 (Condition-2)
                if (e.Row.Cells[14].Text == "1" && e.Row.Cells[21].Text == "1" && e.Row.Cells[25].Text != "&nbsp;" && float.Parse(e.Row.Cells[25].Text) < 23)
                {
                    e.Row.Cells[48].Text = "True";
                    q44++;
                }
                //Q44 (Condition-3)
                if (e.Row.Cells[14].Text == "1" && e.Row.Cells[21].Text == "1" && e.Row.Cells[28].Text != "&nbsp;" && Convert.ToInt32(e.Row.Cells[28].Text) >= 1500)
                {
                    e.Row.Cells[49].Text = "True";
                    q44++;
                }
                //Q44 (Condition-4)
                if (e.Row.Cells[14].Text == "1" && e.Row.Cells[21].Text == "1" && e.Row.Cells[30].Text != "&nbsp;" && e.Row.Cells[30].Text == "1")
                {
                    e.Row.Cells[50].Text = "True";
                    q44++;
                }
                //Q44 (Condition-5)
                if (e.Row.Cells[14].Text == "1" && e.Row.Cells[21].Text == "1" && e.Row.Cells[31].Text != "&nbsp;" && e.Row.Cells[31].Text == "1")
                {
                    e.Row.Cells[51].Text = "True";
                    q44++;
                }
                //Q44 (Condition-6): [for Sum Q44]
                if (e.Row.Cells[14].Text == "1" && e.Row.Cells[21].Text == "1" && e.Row.Cells[32].Text != "&nbsp;" && e.Row.Cells[32].Text == "2" && e.Row.Cells[33].Text == "2")
                {
                    e.Row.Cells[52].Text = "True";
                    q44++;
                }


                //Q44 (Condition-7):
                if (e.Row.Cells[14].Text == "1" && e.Row.Cells[21].Text == "1" && e.Row.Cells[35].Text != "&nbsp;" && e.Row.Cells[35].Text == "2")
                {
                    e.Row.Cells[53].Text = "True";
                    q44++;
                }
                //Q44 (Condition-8):
                if (e.Row.Cells[14].Text == "1" && e.Row.Cells[21].Text == "1" && e.Row.Cells[36].Text != "&nbsp;" && e.Row.Cells[36].Text == "1")
                {
                    e.Row.Cells[54].Text = "True";
                    q44++;
                }

                //Q44 (Condition-9): [for Sum Q44]
                if (e.Row.Cells[14].Text == "1" && e.Row.Cells[21].Text == "1" && e.Row.Cells[37].Text != "&nbsp;" && e.Row.Cells[37].Text == "2" && e.Row.Cells[38].Text == "2" && e.Row.Cells[39].Text == "2" && e.Row.Cells[40].Text == "2" && e.Row.Cells[41].Text == "2" && e.Row.Cells[42].Text == "2")
                {
                    e.Row.Cells[55].Text = "True";
                    q44++;
                }

                //Q44 (Condition-10): 
                if (e.Row.Cells[14].Text == "1" && e.Row.Cells[21].Text == "1" && e.Row.Cells[44].Text != "&nbsp;" && e.Row.Cells[44].Text == "2")
                {
                    e.Row.Cells[56].Text = "True";
                    q44++;
                }
                //Q44 (Condition-11): 
                if (e.Row.Cells[14].Text == "1" && e.Row.Cells[21].Text == "1" && e.Row.Cells[45].Text != "&nbsp;" && e.Row.Cells[45].Text == "2")
                {
                    e.Row.Cells[57].Text = "True";
                    q44++;
                }

                //Q44 (Sum up): 
                if (e.Row.Cells[14].Text == "1" && e.Row.Cells[21].Text == "1")
                {
                    e.Row.Cells[46].Text = Convert.ToString(q44);
                }





                if (e.Row.Cells[14].Text == "1")
                {
                    e.Row.Cells[14].Text = "Complete";
                }
                else if (e.Row.Cells[14].Text == "2")
                {
                    e.Row.Cells[14].Text = "Not at home";
                }
                else if (e.Row.Cells[14].Text == "3")
                {
                    e.Row.Cells[14].Text = "Refused";
                }
                else if (e.Row.Cells[14].Text == "4")
                {
                    e.Row.Cells[14].Text = "False Pregnancy";
                }
                else if (e.Row.Cells[14].Text == "5")
                {
                    e.Row.Cells[14].Text = "Shifted out of DSS";
                }
                else if (e.Row.Cells[14].Text == "6")
                {
                    e.Row.Cells[14].Text = "Adopted Child from outside DSS";
                }
                else if (e.Row.Cells[14].Text == "7")
                {
                    e.Row.Cells[14].Text = "PW died before visit";
                }
            }
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
                    cmd = new MySqlCommand("select c.assis_id as q1,a.date_of_attempt as q2,a.time_of_attempt as q3, (a.lw_crf2_17+1)as q4 ,a.lw_crf2_18 as q5,(a.lw_crf2_19+1) as q6, (a.lw_crf2_20+1) as q7, a.lw_crf2_21 as q8,a.lw_crf2_22 as q9,a.lw_crf2_23 as q10,	if(a.lw_crf2_23='1',a.lw_crf2_26,NULL) as Q11,		if(a.lw_crf2_23='1',e.lw_crf1_26,NULL) as q12,	 if(a.lw_crf2_23='1',e.lw_crf1_27,NULL) as q13,		if(a.lw_crf2_23='1',a.lw_crf2_32,NULL) as q14,		(CASE    WHEN a.lw_crf2_23='1' and e.lw_crf1_31!='' THEN '1'    WHEN (a.lw_crf2_23='1' and (e.lw_crf1_31='' or e.lw_crf1_31 is null)) THEN '2' END) as q15, 	if(a.lw_crf2_23='1',e.lw_crf1_31,NULL) as q15_a,	if(a.lw_crf2_23='1',e.lw_crf1_32,NULL) as q16,	if(a.lw_crf2_23='1', if ((e.lw_crf1_31 !='' & e.lw_crf1_32 !=''),       DATE_FORMAT((str_to_date(e.lw_crf1_31, '%d-%m-%Y') - INTERVAL (e.lw_crf1_32 * 7) DAY),'%d-%m-%Y'), ''),NULL) as q17,	if(a.lw_crf2_23='1' and a.lw_crf2_30<23.0 ,  ROUND(  (to_days(str_to_date(a.lw_crf2_21,'%d-%m-%Y'))-to_days(DATE_FORMAT((str_to_date(e.lw_crf1_31, '%d-%m-%Y') - INTERVAL (e.lw_crf1_32 * 7) DAY),'%Y-%m-%d') ))/7,0) ,NULL) AS q18,	 bb.code_of_reader_1 as q19,	bb.code_of_reader_2 as q20,			 			 bb.reader1  as q21,		bb.reader2  as q22,	a.lw_crf2_30 as q23,	 (CASE    WHEN a.lw_crf2_31 like '1' THEN '2'    WHEN a.lw_crf2_31 like '2' THEN '1' END) as  q24,   	 cc.reader1  as q25,		cc.reader2  as q26,			a.lw_crf2_34 as q27, 	a.lw_crf2_36 as q28,	a.lw_crf2_37 as q29,	a.lw_crf2_38_a as q30,	(CASE    WHEN a.lw_crf2_38_b like '1:%' THEN '1'    WHEN a.lw_crf2_38_b like '2%' THEN '2' END)  as q31,		(CASE    WHEN a.lw_crf2_38_b like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf2_38_b, ':', 2), ':', -1)      END)  as q32,				a.lw_crf2_39 as q33,		a.lw_crf2_40 as q34,		a.lw_crf2_41_a as q35,	a.lw_crf2_41_b as q36,	a.lw_crf2_41_c as q37,	a.lw_crf2_41_d as q38,	a.lw_crf2_41_e as q39,		(CASE    WHEN a.lw_crf2_41_f like '1:%' THEN '1'    WHEN a.lw_crf2_41_f like '2%' THEN '2' END)  as q40,		(CASE    WHEN a.lw_crf2_41_f like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf2_41_f, ':', 2), ':', -1)      END)  as q40_description,	a.lw_crf2_42 as q41,	a.lw_crf2_43 as q42, 	(CASE    WHEN a.lw_crf2_44 >=11 THEN '1'    WHEN lw_crf2_44<11 THEN '2' END)  as q43, 	a.lw_crf2_45 as q44,	a.lw_crf2_46 as q45,	 (CASE    WHEN a.lw_crf2_47  like '2:%' THEN '2'   Else a.lw_crf2_47  END) as q46,	 (CASE    WHEN a.lw_crf2_48  like '2:%' THEN '2'   Else a.lw_crf2_48  END) as q47,	a.lw_crf2_49 as q48,	a.lw_crf2_50 as q49,	a.end_time_of_attempt as Endtime 				from form_crf_2 as a inner join pw as c on a.assis_id=c.id  	left join(select * from arm_reading where arm_reading_id in ( select max(arm_reading_id) from arm_reading group by form_crf_2_id)) as bb on bb.form_crf_2_id=a.form_crf_2 left join(select * from child_weight where child_weight_id in ( select max(child_weight_id) from child_weight group by form_crf_2_id)) as cc on cc.form_crf_2_id=a.form_crf_2		left join form_crf_1 as e on e.pw_assis_id=a.assis_id	where e.visit_status='0'		order by a.form_crf_2", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=BMFG CRF2 (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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