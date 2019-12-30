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
    public partial class moniChAnthro : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "moniChAnthro";
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
                cmd = new MySqlCommand("select i.study_code,i.dssid,i.q6 as woman_nm ,i.q7 as husband_nm,m.lw_crf_3a_19 as arm, j.lw_crf2_21 as dob,	DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, 		 l.lw_crf3b_44 as gender,						'Child Length', i.lw_crf3c_17 as crf3c_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=1 and a.study_id=q.study_id) as F1_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=2 and a.study_id=q.study_id) as F2_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=3 and a.study_id=q.study_id) as F3_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=4 and a.study_id=q.study_id) as F4_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=5 and a.study_id=q.study_id) as F5_ch_lenght ,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=6 and a.study_id=q.study_id) as F6_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=7 and a.study_id=q.study_id) as F7_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=8 and a.study_id=q.study_id) as F8_ch_length,  			'Child MUAC', i.lw_crf3c_19 as crf3c_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=1 and a.study_id=q.study_id) as F1_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=2 and a.study_id=q.study_id) as F2_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=3 and a.study_id=q.study_id) as F3_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=4 and a.study_id=q.study_id) as F4_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=5 and a.study_id=q.study_id) as F5_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=6 and a.study_id=q.study_id) as F6_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=7 and a.study_id=q.study_id) as F7_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=8 and a.study_id=q.study_id) as F8_ch_MUAC,					'Head Circum', i.lw_crf3c_21 as crf3c_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=1 and a.study_id=q.study_id) as F1_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=2 and a.study_id=q.study_id) as F2_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=3 and a.study_id=q.study_id) as F3_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=4 and a.study_id=q.study_id) as F4_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=5 and a.study_id=q.study_id) as F5_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=6 and a.study_id=q.study_id) as F6_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=7 and a.study_id=q.study_id) as F7_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=8 and a.study_id=q.study_id) as F8_ch_OFHC,			'Child Weight', j.lw_crf2_34 as crf2_ch_weight, i.lw_crf3c_15 as crf3c_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=1 and a.study_id=q.study_id) as F1_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=2 and a.study_id=q.study_id) as F2_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=3 and a.study_id=q.study_id) as F3_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=4 and a.study_id=q.study_id) as F4_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=5 and a.study_id=q.study_id) as F5_ch_weight ,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=6 and a.study_id=q.study_id) as F6_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=7 and a.study_id=q.study_id) as F7_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=8 and a.study_id=q.study_id) as F8_ch_weight,              i.lw_crf3c_2 as Enrollment_Date,	(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=1 and a.study_id=q.study_id) as F1_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=2 and a.study_id=q.study_id) as F2_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=3 and a.study_id=q.study_id) as F3_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=4 and a.study_id=q.study_id) as F4_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=5 and a.study_id=q.study_id) as F5_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=6 and a.study_id=q.study_id) as F6_DATE, (select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=7 and a.study_id=q.study_id) as F7_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=8 and a.study_id=q.study_id) as F8_DATE,           (select concat(ROUND(((sum(z.lw_crf5a_31)/sum(	if((z.lw_crf5a_29 is NULL || z.lw_crf5a_29 =''),    (SELECT (DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'), str_to_date(y.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as y where y.study_id=z.study_id), z.lw_crf5a_29)	))*100),1),'%')  from form_crf_5a as z where z.study_id=q.study_id) as Cumulative			    from view_crf3c as i 	left join studies as q on q.study_code=i.study_code 	 left join form_crf_2 as j on q.assis_id=j.assis_id left join form_crf_3b as l on l.study_id=q.study_id left join form_crf_3a as m on m.lw_crf_3a_4=i.study_code  			  			  			  			 where i.dssid like '" + txtdssid.Text + "%' group by i.study_code order by i.study_code", con);

                //cmd = new MySqlCommand("select i.study_code,i.dssid,i.q6 as woman_nm ,i.q7 as husband_nm,m.lw_crf_3a_19 as arm, j.lw_crf2_21 as dob,	DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, 		 l.lw_crf3b_44 as gender,						'Child Length', i.lw_crf3c_17 as crf3c_ch_length,(select a.lw_crf6_22 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_ch_length,(select b.lw_crf6_22 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_ch_length,(select c.lw_crf6_22 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_ch_length,(select d.lw_crf6_22 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_ch_length,(select e.lw_crf6_22 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_ch_lenght ,(select f.lw_crf6_22 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_ch_length,  			'Child MUAC', i.lw_crf3c_19 as crf3c_ch_MUAC,(select a.lw_crf6_24 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_ch_MUAC,(select b.lw_crf6_24 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_ch_MUAC,(select c.lw_crf6_24 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_ch_MUAC,(select d.lw_crf6_24 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_ch_MUAC,(select e.lw_crf6_24 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_ch_MUAC,(select f.lw_crf6_24 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_ch_MUAC,					'Head Circum', i.lw_crf3c_21 as crf3c_ch_OFHC,(select a.lw_crf6_27 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_ch_OFHC,(select b.lw_crf6_27 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_ch_OFHC,(select c.lw_crf6_27 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_ch_OFHC,(select d.lw_crf6_27 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_ch_OFHC,(select e.lw_crf6_27 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_ch_OFHC,(select f.lw_crf6_27 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_ch_OFHC,			'Child Weight', j.lw_crf2_34 as crf2_ch_weight, i.lw_crf3c_15 as crf3c_ch_weight,(select a.lw_crf6_20 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_ch_weight,(select b.lw_crf6_20 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_ch_weight,(select c.lw_crf6_20 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_ch_weight,(select d.lw_crf6_20 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_ch_weight,(select e.lw_crf6_20 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_ch_weight ,(select f.lw_crf6_20 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_ch_weight,                   i.lw_crf3c_2 as Enrollment_Date,	(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=1 and z.study_code=i.study_code) as F1_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=2 and z.study_code=i.study_code) as F2_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=3 and z.study_code=i.study_code) as F3_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=4 and z.study_code=i.study_code) as F4_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=5 and z.study_code=i.study_code) as F5_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=6 and z.study_code=i.study_code) as F6_DATE,            (select concat(ROUND(((sum(z.lw_crf5a_31)/sum(	if((z.lw_crf5a_29 is NULL || z.lw_crf5a_29 =''),    (SELECT (DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'), str_to_date(y.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as y where y.study_id=z.study_id), z.lw_crf5a_29)	))*100),1),'%')  from form_crf_5a as z where z.study_id=q.study_id) as Cumulative				  from view_crf3c as i left join view_crf2 as j on i.assis_id=j.assis_id left join view_crf3b as l on l.study_code=i.study_code left join view_crf3a as m on m.study_id=i.study_code  left join studies as q on q.study_code=i.study_code  where i.dssid like '" + txtdssid.Text + "%' group by i.study_code order by i.study_code", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=Child Anthro (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
                cmd = new MySqlCommand("select i.study_code,i.dssid,i.q6 as woman_nm ,i.q7 as husband_nm,m.lw_crf_3a_19 as arm, j.lw_crf2_21 as dob,	DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, 		 l.lw_crf3b_44 as gender,						'Child Length', i.lw_crf3c_17 as crf3c_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=1 and a.study_id=q.study_id) as F1_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=2 and a.study_id=q.study_id) as F2_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=3 and a.study_id=q.study_id) as F3_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=4 and a.study_id=q.study_id) as F4_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=5 and a.study_id=q.study_id) as F5_ch_lenght ,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=6 and a.study_id=q.study_id) as F6_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=7 and a.study_id=q.study_id) as F7_ch_length,(select a.lw_crf6_22 from form_crf_6 as a where a.followup_no=8 and a.study_id=q.study_id) as F8_ch_length,  			'Child MUAC', i.lw_crf3c_19 as crf3c_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=1 and a.study_id=q.study_id) as F1_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=2 and a.study_id=q.study_id) as F2_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=3 and a.study_id=q.study_id) as F3_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=4 and a.study_id=q.study_id) as F4_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=5 and a.study_id=q.study_id) as F5_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=6 and a.study_id=q.study_id) as F6_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=7 and a.study_id=q.study_id) as F7_ch_MUAC,(select a.lw_crf6_24 from form_crf_6 as a where a.followup_no=8 and a.study_id=q.study_id) as F8_ch_MUAC,					'Head Circum', i.lw_crf3c_21 as crf3c_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=1 and a.study_id=q.study_id) as F1_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=2 and a.study_id=q.study_id) as F2_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=3 and a.study_id=q.study_id) as F3_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=4 and a.study_id=q.study_id) as F4_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=5 and a.study_id=q.study_id) as F5_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=6 and a.study_id=q.study_id) as F6_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=7 and a.study_id=q.study_id) as F7_ch_OFHC,(select a.lw_crf6_27 from form_crf_6 as a where a.followup_no=8 and a.study_id=q.study_id) as F8_ch_OFHC,			'Child Weight', j.lw_crf2_34 as crf2_ch_weight, i.lw_crf3c_15 as crf3c_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=1 and a.study_id=q.study_id) as F1_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=2 and a.study_id=q.study_id) as F2_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=3 and a.study_id=q.study_id) as F3_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=4 and a.study_id=q.study_id) as F4_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=5 and a.study_id=q.study_id) as F5_ch_weight ,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=6 and a.study_id=q.study_id) as F6_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=7 and a.study_id=q.study_id) as F7_ch_weight,(select a.lw_crf6_20 from form_crf_6 as a where a.followup_no=8 and a.study_id=q.study_id) as F8_ch_weight,              i.lw_crf3c_2 as Enrollment_Date,	(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=1 and a.study_id=q.study_id) as F1_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=2 and a.study_id=q.study_id) as F2_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=3 and a.study_id=q.study_id) as F3_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=4 and a.study_id=q.study_id) as F4_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=5 and a.study_id=q.study_id) as F5_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=6 and a.study_id=q.study_id) as F6_DATE, (select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=7 and a.study_id=q.study_id) as F7_DATE,(select a.lw_crf6_2 from form_crf_6 as a where a.followup_no=8 and a.study_id=q.study_id) as F8_DATE,           (select concat(ROUND(((sum(z.lw_crf5a_31)/sum(	if((z.lw_crf5a_29 is NULL || z.lw_crf5a_29 =''),    (SELECT (DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'), str_to_date(y.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as y where y.study_id=z.study_id), z.lw_crf5a_29)	))*100),1),'%')  from form_crf_5a as z where z.study_id=q.study_id) as Cumulative			    from view_crf3c as i 	left join studies as q on q.study_code=i.study_code 	 left join form_crf_2 as j on q.assis_id=j.assis_id left join form_crf_3b as l on l.study_id=q.study_id left join form_crf_3a as m on m.lw_crf_3a_4=i.study_code  			  			 			  			 where i.dssid like '" + txtdssid.Text + "%' group by i.study_code order by i.study_code", con);

                //cmd = new MySqlCommand("select i.study_code,i.dssid,i.q6 as woman_nm ,i.q7 as husband_nm,m.lw_crf_3a_19 as arm, j.lw_crf2_21 as dob,	DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, 		 l.lw_crf3b_44 as gender,						'Child Length', i.lw_crf3c_17 as crf3c_ch_length,(select a.lw_crf6_22 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_ch_length,(select b.lw_crf6_22 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_ch_length,(select c.lw_crf6_22 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_ch_length,(select d.lw_crf6_22 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_ch_length,(select e.lw_crf6_22 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_ch_lenght ,(select f.lw_crf6_22 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_ch_length,  			'Child MUAC', i.lw_crf3c_19 as crf3c_ch_MUAC,(select a.lw_crf6_24 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_ch_MUAC,(select b.lw_crf6_24 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_ch_MUAC,(select c.lw_crf6_24 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_ch_MUAC,(select d.lw_crf6_24 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_ch_MUAC,(select e.lw_crf6_24 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_ch_MUAC,(select f.lw_crf6_24 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_ch_MUAC,					'Head Circum', i.lw_crf3c_21 as crf3c_ch_OFHC,(select a.lw_crf6_27 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_ch_OFHC,(select b.lw_crf6_27 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_ch_OFHC,(select c.lw_crf6_27 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_ch_OFHC,(select d.lw_crf6_27 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_ch_OFHC,(select e.lw_crf6_27 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_ch_OFHC,(select f.lw_crf6_27 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_ch_OFHC,			'Child Weight', j.lw_crf2_34 as crf2_ch_weight, i.lw_crf3c_15 as crf3c_ch_weight,(select a.lw_crf6_20 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_ch_weight,(select b.lw_crf6_20 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_ch_weight,(select c.lw_crf6_20 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_ch_weight,(select d.lw_crf6_20 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_ch_weight,(select e.lw_crf6_20 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_ch_weight ,(select f.lw_crf6_20 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_ch_weight,              i.lw_crf3c_2 as Enrollment_Date,	(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=1 and z.study_code=i.study_code) as F1_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=2 and z.study_code=i.study_code) as F2_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=3 and z.study_code=i.study_code) as F3_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=4 and z.study_code=i.study_code) as F4_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=5 and z.study_code=i.study_code) as F5_DATE,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=6 and z.study_code=i.study_code) as F6_DATE,            (select concat(ROUND(((sum(z.lw_crf5a_31)/sum(	if((z.lw_crf5a_29 is NULL || z.lw_crf5a_29 =''),    (SELECT (DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'), str_to_date(y.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as y where y.study_id=z.study_id), z.lw_crf5a_29)	))*100),1),'%')  from form_crf_5a as z where z.study_id=q.study_id) as Cumulative				  from view_crf3c as i left join view_crf2 as j on i.assis_id=j.assis_id left join view_crf3b as l on l.study_code=i.study_code left join view_crf3a as m on m.study_id=i.study_code  left join studies as q on q.study_code=i.study_code  where i.dssid like '" + txtdssid.Text + "%' group by i.study_code order by i.study_code", con);
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
                TableCell cell9 = e.Row.Cells[9];
                TableCell cell17 = e.Row.Cells[19];
                TableCell cell25 = e.Row.Cells[29];
                TableCell cell33 = e.Row.Cells[39];
                TableCell cell42 = e.Row.Cells[50];
                TableCell cell44 = e.Row.Cells[52];

                cell9.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell17.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell25.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell33.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell42.BackColor = System.Drawing.Color.FromName("#bdc3c7");
                cell44.BackColor = System.Drawing.Color.FromName("#bdc3c7");

                if (e.Row.Cells[8].Text == "f")
                {
                    e.Row.Cells[8].Text = "Female";
                }
                else if (e.Row.Cells[8].Text == "m")
                {
                    e.Row.Cells[8].Text = "Male";
                }


                TableCell cell_DSSID = e.Row.Cells[2];



                // Child Length

                if (e.Row.Cells[11].Text != "&nbsp;" && e.Row.Cells[10].Text != "&nbsp;" && (float.Parse(e.Row.Cells[11].Text) < float.Parse(e.Row.Cells[10].Text)))
                {
                    TableCell cell = e.Row.Cells[11];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
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



                // Child MUAC

               
                if (e.Row.Cells[21].Text != "&nbsp;" && e.Row.Cells[20].Text != "&nbsp;" && (float.Parse(e.Row.Cells[21].Text) < float.Parse(e.Row.Cells[20].Text)))
                {
                    TableCell cell = e.Row.Cells[21];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[22].Text != "&nbsp;" && e.Row.Cells[21].Text != "&nbsp;" && (float.Parse(e.Row.Cells[22].Text) < float.Parse(e.Row.Cells[21].Text)))
                {
                    TableCell cell = e.Row.Cells[22];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[23].Text != "&nbsp;" && e.Row.Cells[22].Text != "&nbsp;" && (float.Parse(e.Row.Cells[23].Text) < float.Parse(e.Row.Cells[22].Text)))
                {
                    TableCell cell = e.Row.Cells[23];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[24].Text != "&nbsp;" && e.Row.Cells[23].Text != "&nbsp;" && (float.Parse(e.Row.Cells[24].Text) < float.Parse(e.Row.Cells[23].Text)))
                {
                    TableCell cell = e.Row.Cells[24];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                // fsafsfdsfsd
                if (e.Row.Cells[25].Text != "&nbsp;" && e.Row.Cells[24].Text != "&nbsp;" && (float.Parse(e.Row.Cells[25].Text) < float.Parse(e.Row.Cells[24].Text)))
                {
                    TableCell cell = e.Row.Cells[25];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[26].Text != "&nbsp;" && e.Row.Cells[25].Text != "&nbsp;" && (float.Parse(e.Row.Cells[26].Text) < float.Parse(e.Row.Cells[25].Text)))
                {
                    TableCell cell = e.Row.Cells[26];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[27].Text != "&nbsp;" && e.Row.Cells[26].Text != "&nbsp;" && (float.Parse(e.Row.Cells[27].Text) < float.Parse(e.Row.Cells[26].Text)))
                {
                    TableCell cell = e.Row.Cells[27];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                if (e.Row.Cells[28].Text != "&nbsp;" && e.Row.Cells[27].Text != "&nbsp;" && (float.Parse(e.Row.Cells[28].Text) < float.Parse(e.Row.Cells[27].Text)))
                {
                    TableCell cell = e.Row.Cells[28];
                    cell.BackColor = System.Drawing.Color.FromName("#ff7675");
                    cell_DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }



            }

        }

       
    }
}