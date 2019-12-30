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
    public partial class moniLWAnthro : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "moniLWAnthro";
                ShowData();
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
                    cmd = new MySqlCommand("select i.study_code,i.dssid,i.q6 as woman_nm ,i.q7 as husband_nm,n.lw_crf_3a_19 as arm, j.date_of_attempt as crf2_dov,j.lw_crf2_21 as date_of_outcome,		'LW Height', i.lw_crf3c_25 as crf3c_LW_Height,			'LW MUAC', m.lw_crf1_21 as crf1_LW_MUAC, j.lw_crf2_30 as crf2_LW_MUAC, i.lw_crf3c_27 as crf3c_LW_MUAC, (select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=1 and a.study_id=o.study_id) as F1_LW_MUAC, (select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=2 and a.study_id=o.study_id) as F2_LW_MUAC,(select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=3 and a.study_id=o.study_id) as F3_LW_MUAC,(select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=4 and a.study_id=o.study_id) as F4_LW_MUAC,(select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=5 and a.study_id=o.study_id) as F5_LW_MUAC ,(select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=6 and a.study_id=o.study_id) as F6_LW_MUAC, (select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=7 and a.study_id=o.study_id) as F7_LW_MUAC,(select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=8 and a.study_id=o.study_id) as F8_LW_MUAC,			'LW Weight',  i.lw_crf3c_23 as crf3c_LW_weight, (select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=1 and a.study_id=o.study_id) as F1_LW_weight, (select a.lw_crf6_30 from  form_crf_6 as a where a.followup_no=2 and a.study_id=o.study_id) as F2_LW_weight,(select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=3 and a.study_id=o.study_id) as F3_LW_weight,(select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=4 and a.study_id=o.study_id) as F4_LW_weight,(select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=5 and a.study_id=o.study_id) as F5_LW_weight ,(select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=6 and a.study_id=o.study_id) as F6_LW_weight ,(select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=7 and a.study_id=o.study_id) as F7_LW_weight,(select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=8 and a.study_id=o.study_id) as F8_LW_weight 				 ,lw_crf1_02 as Screening_Date, i.lw_crf3c_2 as Enrollment_Date,	(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=1 and a.study_id=o.study_id) as F1_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=2 and a.study_id=o.study_id) as F2_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=3 and a.study_id=o.study_id) as F3_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=4 and a.study_id=o.study_id) as F4_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=5 and a.study_id=o.study_id) as F5_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=6 and a.study_id=o.study_id) as F6_DATE ,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=7 and a.study_id=o.study_id) as F7_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=8 and a.study_id=o.study_id) as F8_DATE         	from view_crf3c as i 		left join studies as o on o.study_code=i.study_code	left join form_crf_2 as j on j.assis_id=o.assis_id left join form_crf_1 as m on m.pw_assis_id=o.assis_id		       left join form_crf_3a as n on n.lw_crf_3a_4=i.study_code      where i.dssid like '" + txtdssid.Text + "%' group by i.study_code order by i.study_code", con);
                    //cmd = new MySqlCommand("select i.study_code,i.dssid,i.q6 as woman_nm ,i.q7 as husband_nm,n.lw_crf_3a_19 as arm, j.date_of_attempt as crf2_dov,j.lw_crf2_21 as date_of_outcome,		'LW Height', i.lw_crf3c_25 as crf3c_LW_Height,			'LW MUAC', m.lw_crf1_21 as crf1_LW_MUAC, j.lw_crf2_30 as crf2_LW_MUAC, i.lw_crf3c_27 as crf3c_LW_MUAC, (select a.lw_crf6_34 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_LW_MUAC, (select b.lw_crf6_34 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_LW_MUAC,(select c.lw_crf6_34 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_LW_MUAC,(select d.lw_crf6_34 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_LW_MUAC,(select e.lw_crf6_34 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_LW_MUAC ,(select f.lw_crf6_34 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_LW_MUAC, 			'LW Weight',  i.lw_crf3c_23 as crf3c_LW_weight, (select a.lw_crf6_30 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_LW_weight, (select b.lw_crf6_30 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_LW_weight,(select c.lw_crf6_30 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_LW_weight,(select d.lw_crf6_30 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_LW_weight,(select e.lw_crf6_30 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_LW_weight ,(select f.lw_crf6_30 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_LW_weight  				 ,m.lw_crf1_02 as Screening_Date, i.lw_crf3c_2 as Enrollment_Date,	(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=1 and z.study_code=i.study_code) as F1_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=2 and z.study_code=i.study_code) as F2_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=3 and z.study_code=i.study_code) as F3_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=4 and z.study_code=i.study_code) as F4_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=5 and z.study_code=i.study_code) as F5_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=6 and z.study_code=i.study_code) as F6_DATE		  from view_crf3c as i left join view_crf2 as j on i.assis_id=j.assis_id left join view_crf1 as m on m.assis_id=i.assis_id      left join view_crf3a as n on n.study_id=i.study_code  where i.dssid like '" + txtdssid.Text + "%' group by i.study_code order by i.study_code", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 9999999;
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
                Response.AddHeader("content-disposition", "attachment;filename=LW Anthro  (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
                    cmd = new MySqlCommand("select i.study_code,i.dssid,i.q6 as woman_nm ,i.q7 as husband_nm,n.lw_crf_3a_19 as arm, j.date_of_attempt as crf2_dov,j.lw_crf2_21 as date_of_outcome,		'LW Height', i.lw_crf3c_25 as crf3c_LW_Height,			'LW MUAC', m.lw_crf1_21 as crf1_LW_MUAC, j.lw_crf2_30 as crf2_LW_MUAC, i.lw_crf3c_27 as crf3c_LW_MUAC, (select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=1 and a.study_id=o.study_id) as F1_LW_MUAC, (select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=2 and a.study_id=o.study_id) as F2_LW_MUAC,(select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=3 and a.study_id=o.study_id) as F3_LW_MUAC,(select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=4 and a.study_id=o.study_id) as F4_LW_MUAC,(select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=5 and a.study_id=o.study_id) as F5_LW_MUAC ,(select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=6 and a.study_id=o.study_id) as F6_LW_MUAC, (select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=7 and a.study_id=o.study_id) as F7_LW_MUAC,(select a.lw_crf6_34 from form_crf_6 as a where a.followup_no=8 and a.study_id=o.study_id) as F8_LW_MUAC,			'LW Weight',  i.lw_crf3c_23 as crf3c_LW_weight, (select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=1 and a.study_id=o.study_id) as F1_LW_weight, (select a.lw_crf6_30 from  form_crf_6 as a where a.followup_no=2 and a.study_id=o.study_id) as F2_LW_weight,(select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=3 and a.study_id=o.study_id) as F3_LW_weight,(select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=4 and a.study_id=o.study_id) as F4_LW_weight,(select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=5 and a.study_id=o.study_id) as F5_LW_weight ,(select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=6 and a.study_id=o.study_id) as F6_LW_weight ,(select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=7 and a.study_id=o.study_id) as F7_LW_weight,(select a.lw_crf6_30 from form_crf_6 as a where a.followup_no=8 and a.study_id=o.study_id) as F8_LW_weight 				 ,lw_crf1_02 as Screening_Date, i.lw_crf3c_2 as Enrollment_Date,	(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=1 and a.study_id=o.study_id) as F1_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=2 and a.study_id=o.study_id) as F2_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=3 and a.study_id=o.study_id) as F3_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=4 and a.study_id=o.study_id) as F4_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=5 and a.study_id=o.study_id) as F5_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=6 and a.study_id=o.study_id) as F6_DATE ,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=7 and a.study_id=o.study_id) as F7_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=8 and a.study_id=o.study_id) as F8_DATE         	from view_crf3c as i 		left join studies as o on o.study_code=i.study_code	left join form_crf_2 as j on j.assis_id=o.assis_id left join form_crf_1 as m on m.pw_assis_id=o.assis_id		       left join form_crf_3a as n on n.lw_crf_3a_4=i.study_code      where i.dssid like '" + txtdssid.Text + "%' group by i.study_code order by i.study_code", con);
                    //cmd = new MySqlCommand("select i.study_code,i.dssid,i.q6 as woman_nm ,i.q7 as husband_nm,n.lw_crf_3a_19 as arm, j.date_of_attempt as crf2_dov,j.lw_crf2_21 as date_of_outcome,		'LW Height', i.lw_crf3c_25 as crf3c_LW_Height,			'LW MUAC', m.lw_crf1_21 as crf1_LW_MUAC, j.lw_crf2_30 as crf2_LW_MUAC, i.lw_crf3c_27 as crf3c_LW_MUAC, (select a.lw_crf6_34 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_LW_MUAC, (select b.lw_crf6_34 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_LW_MUAC,(select c.lw_crf6_34 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_LW_MUAC,(select d.lw_crf6_34 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_LW_MUAC,(select e.lw_crf6_34 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_LW_MUAC ,(select f.lw_crf6_34 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_LW_MUAC, 			'LW Weight',  i.lw_crf3c_23 as crf3c_LW_weight, (select a.lw_crf6_30 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_LW_weight, (select b.lw_crf6_30 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_LW_weight,(select c.lw_crf6_30 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_LW_weight,(select d.lw_crf6_30 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_LW_weight,(select e.lw_crf6_30 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_LW_weight ,(select f.lw_crf6_30 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_LW_weight  				 ,m.lw_crf1_02 as Screening_Date, i.lw_crf3c_2 as Enrollment_Date,	(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=1 and z.study_code=i.study_code) as F1_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=2 and z.study_code=i.study_code) as F2_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=3 and z.study_code=i.study_code) as F3_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=4 and z.study_code=i.study_code) as F4_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=5 and z.study_code=i.study_code) as F5_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=6 and z.study_code=i.study_code) as F6_DATE          		  from view_crf3c as i left join view_crf2 as j on i.assis_id=j.assis_id left join view_crf1 as m on m.assis_id=i.assis_id       left join view_crf3a as n on n.study_id=i.study_code   where i.dssid like '" + txtdssid.Text + "%' group by i.study_code order by i.study_code", con);
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

                TableCell cell8 = e.Row.Cells[8];
                TableCell cell10 = e.Row.Cells[10];
                TableCell cell20 = e.Row.Cells[22];
                TableCell cell28 = e.Row.Cells[32];
                TableCell cell41 = e.Row.Cells[41];

                cell8.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell10.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell20.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell28.BackColor = System.Drawing.Color.FromName("#bdc3c7");
                cell41.BackColor = System.Drawing.Color.FromName("#bdc3c7");

                TableCell cell_DSSID = e.Row.Cells[2];

                // LW MUAC

                if (e.Row.Cells[12].Text != "&nbsp;" && e.Row.Cells[11].Text != "&nbsp;" && (float.Parse(e.Row.Cells[12].Text) < float.Parse(e.Row.Cells[11].Text)))
                {
                    TableCell cell = e.Row.Cells[12];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[13].Text != "&nbsp;" && e.Row.Cells[12].Text != "&nbsp;" && (float.Parse(e.Row.Cells[13].Text) < float.Parse(e.Row.Cells[12].Text)))
                {
                    TableCell cell = e.Row.Cells[13];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[14].Text != "&nbsp;" && e.Row.Cells[13].Text != "&nbsp;" && (float.Parse(e.Row.Cells[14].Text) < float.Parse(e.Row.Cells[13].Text)))
                {
                    TableCell cell = e.Row.Cells[14];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[15].Text != "&nbsp;" && e.Row.Cells[14].Text != "&nbsp;" && (float.Parse(e.Row.Cells[15].Text) < float.Parse(e.Row.Cells[14].Text)))
                {
                    TableCell cell = e.Row.Cells[15];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[16].Text != "&nbsp;" && e.Row.Cells[15].Text != "&nbsp;" && (float.Parse(e.Row.Cells[16].Text) < float.Parse(e.Row.Cells[15].Text)))
                {
                    TableCell cell = e.Row.Cells[16];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[17].Text != "&nbsp;" && e.Row.Cells[16].Text != "&nbsp;" && (float.Parse(e.Row.Cells[17].Text) < float.Parse(e.Row.Cells[16].Text)))
                {
                    TableCell cell = e.Row.Cells[17];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[18].Text != "&nbsp;" && e.Row.Cells[17].Text != "&nbsp;" && (float.Parse(e.Row.Cells[18].Text) < float.Parse(e.Row.Cells[17].Text)))
                {
                    TableCell cell = e.Row.Cells[18];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[19].Text != "&nbsp;" && e.Row.Cells[18].Text != "&nbsp;" && (float.Parse(e.Row.Cells[19].Text) < float.Parse(e.Row.Cells[18].Text)))
                {
                    TableCell cell = e.Row.Cells[19];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[20].Text != "&nbsp;" && e.Row.Cells[19].Text != "&nbsp;" && (float.Parse(e.Row.Cells[20].Text) < float.Parse(e.Row.Cells[19].Text)))
                {
                    TableCell cell = e.Row.Cells[20];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[21].Text != "&nbsp;" && e.Row.Cells[20].Text != "&nbsp;" && (float.Parse(e.Row.Cells[21].Text) < float.Parse(e.Row.Cells[20].Text)))
                {
                    TableCell cell = e.Row.Cells[21];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }


            }
        }

       
    }
}