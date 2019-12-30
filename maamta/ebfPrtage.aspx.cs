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
    public partial class ebfPrtage : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "ebfPrtage";
               // ShowData();
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

                // 30-Apr-2019                
                cmd = new MySqlCommand("select c.study_code,  d.lw_crf1_09 as woman_nm,d.lw_crf1_10 as husband_nm,         concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16)as dssid,		  count(a.study_id) as crf4a_attempt,					(select count(*) from form_crf_4a as z where a.study_id=z.study_id and z.lw_crf4a_19='0') as crf4a_complete,		 f.lw_crf_3a_19 as ARM,       								sum( (select count(*) from form_crf_4a_details where lw_crf4a_28=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_40=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_46=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_52=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_58=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_63=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_68=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where (lw_crf4a_73a=1 || lw_crf4a_73b=1 || lw_crf4a_73c=1 || lw_crf4a_73c=1 || lw_crf4a_73d=1 || lw_crf4a_73e=1  || lw_crf4a_73f=1  || lw_crf4a_73g=1 || lw_crf4a_73h=1 || lw_crf4a_73i=1  || lw_crf4a_73j!=2) and form_crf_4a_id=a.form_crf_4a_id)  ) Q74 ,			sum((select count(*) from form_crf_4a_details where lw_crf4a_28=1 and form_crf_4a_id=a.form_crf_4a_id)) as Q75,				sum(  (select count(*) from form_crf_4a_details where lw_crf4a_40=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_46=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_52=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_58=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_63=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_68=1 and form_crf_4a_id=a.form_crf_4a_id)) Q76 ,			sum((select count(*) from form_crf_4a_details where (lw_crf4a_73a=1 || lw_crf4a_73b=1 || lw_crf4a_73c=1 || lw_crf4a_73c=1 || lw_crf4a_73d=1 || lw_crf4a_73e=1  || lw_crf4a_73f=1  || lw_crf4a_73g=1 || lw_crf4a_73h=1 || lw_crf4a_73i=1  || lw_crf4a_73j!=2) and form_crf_4a_id=a.form_crf_4a_id)   ) q77 			 from form_crf_4a as a  left join studies as c on c.study_id=a.study_id left join pw as d on d.id=c.assis_id left join dss_address as e on e.dss_id=d.dss_id    left join form_crf_3a as f on f.assis_id=d.id	where  	concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16) like '" + txtdssid.Text + "%' group  by c.study_code", con);

                // 08-Feb-2019                
                //cmd = new MySqlCommand("select c.study_code,  d.lw_crf1_09 as woman_nm,d.lw_crf1_10 as husband_nm,         concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16)as dssid,		  count(a.study_id) as crf4a_attempt,					(select count(*) from form_crf_4a as z where a.study_id=z.study_id and z.lw_crf4a_19='0') as crf4a_complete,		 f.lw_crf_3a_19 as ARM,       								sum( (select count(*) from form_crf_4a_details where lw_crf4a_28=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_40=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_46=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_52=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_58=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_43=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_68=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_73a=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73b=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73c=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73d=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73e=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73f=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73g=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73h=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73i=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73j=1 and form_crf_4a_id=a.form_crf_4a_id) ) Q74 ,			sum((select count(*) from form_crf_4a_details where lw_crf4a_28=1 and form_crf_4a_id=a.form_crf_4a_id)) as Q75,				sum(  (select count(*) from form_crf_4a_details where lw_crf4a_40=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_46=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_52=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_58=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_43=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_68=1 and form_crf_4a_id=a.form_crf_4a_id)) Q76 ,			sum((select count(*) from form_crf_4a_details where lw_crf4a_73a=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73b=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73c=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73d=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73e=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73f=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73g=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73h=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73i=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73j=1 and form_crf_4a_id=a.form_crf_4a_id) ) q77 			 from form_crf_4a as a  left join studies as c on c.study_id=a.study_id left join pw as d on d.id=c.assis_id left join dss_address as e on e.dss_id=d.dss_id    left join form_crf_3a as f on f.assis_id=d.id	where  	concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16) like '"+txtdssid.Text+"%' group  by c.study_code", con);
               
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
                Response.AddHeader("content-disposition", "attachment;filename=EBF-Cumulative (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
                // 30-Apr-2019                
                cmd = new MySqlCommand("select c.study_code,  d.lw_crf1_09 as woman_nm,d.lw_crf1_10 as husband_nm,         concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16)as dssid,		  count(a.study_id) as crf4a_attempt,					(select count(*) from form_crf_4a as z where a.study_id=z.study_id and z.lw_crf4a_19='0') as crf4a_complete,		 f.lw_crf_3a_19 as ARM,       								sum( (select count(*) from form_crf_4a_details where lw_crf4a_28=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_40=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_46=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_52=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_58=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_63=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_68=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where (lw_crf4a_73a=1 || lw_crf4a_73b=1 || lw_crf4a_73c=1 || lw_crf4a_73c=1 || lw_crf4a_73d=1 || lw_crf4a_73e=1  || lw_crf4a_73f=1  || lw_crf4a_73g=1 || lw_crf4a_73h=1 || lw_crf4a_73i=1  || lw_crf4a_73j!=2) and form_crf_4a_id=a.form_crf_4a_id)  ) Q74 ,			sum((select count(*) from form_crf_4a_details where lw_crf4a_28=1 and form_crf_4a_id=a.form_crf_4a_id)) as Q75,				sum(  (select count(*) from form_crf_4a_details where lw_crf4a_40=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_46=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_52=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_58=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_63=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_68=1 and form_crf_4a_id=a.form_crf_4a_id)) Q76 ,			sum((select count(*) from form_crf_4a_details where (lw_crf4a_73a=1 || lw_crf4a_73b=1 || lw_crf4a_73c=1 || lw_crf4a_73c=1 || lw_crf4a_73d=1 || lw_crf4a_73e=1  || lw_crf4a_73f=1  || lw_crf4a_73g=1 || lw_crf4a_73h=1 || lw_crf4a_73i=1  || lw_crf4a_73j!=2) and form_crf_4a_id=a.form_crf_4a_id)   ) q77 			 from form_crf_4a as a  left join studies as c on c.study_id=a.study_id left join pw as d on d.id=c.assis_id left join dss_address as e on e.dss_id=d.dss_id    left join form_crf_3a as f on f.assis_id=d.id	where  	concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16) like '" + txtdssid.Text + "%' group  by c.study_code", con);

                // 08-Feb-2019                
                //cmd = new MySqlCommand("select c.study_code,  d.lw_crf1_09 as woman_nm,d.lw_crf1_10 as husband_nm,         concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16)as dssid,		  count(a.study_id) as crf4a_attempt,					(select count(*) from form_crf_4a as z where a.study_id=z.study_id and z.lw_crf4a_19='0') as crf4a_complete,		 f.lw_crf_3a_19 as ARM,       								sum( (select count(*) from form_crf_4a_details where lw_crf4a_28=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_40=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_46=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_52=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_58=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_43=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_68=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_73a=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73b=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73c=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73d=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73e=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73f=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73g=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73h=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73i=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73j=1 and form_crf_4a_id=a.form_crf_4a_id) ) Q74 ,			sum((select count(*) from form_crf_4a_details where lw_crf4a_28=1 and form_crf_4a_id=a.form_crf_4a_id)) as Q75,				sum(  (select count(*) from form_crf_4a_details where lw_crf4a_40=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_46=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_52=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_58=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_43=1 and form_crf_4a_id=a.form_crf_4a_id) + (select count(*) from form_crf_4a_details where lw_crf4a_68=1 and form_crf_4a_id=a.form_crf_4a_id)) Q76 ,			sum((select count(*) from form_crf_4a_details where lw_crf4a_73a=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73b=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73c=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73d=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73e=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73f=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73g=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73h=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73i=1 and form_crf_4a_id=a.form_crf_4a_id)  + (select count(*) from form_crf_4a_details where lw_crf4a_73j=1 and form_crf_4a_id=a.form_crf_4a_id) ) q77 			 from form_crf_4a as a  left join studies as c on c.study_id=a.study_id left join pw as d on d.id=c.assis_id left join dss_address as e on e.dss_id=d.dss_id    left join form_crf_3a as f on f.assis_id=d.id	where  	concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16) like '"+txtdssid.Text+"%' group  by c.study_code", con);
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

                float  result  = (float.Parse(e.Row.Cells[10].Text) / float.Parse(e.Row.Cells[9].Text)) * 100;
                e.Row.Cells[8].Text = Math.Round(result,1) + "%";
            }
        }
    }
}