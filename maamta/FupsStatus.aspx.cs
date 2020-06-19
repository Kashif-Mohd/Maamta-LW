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
    public partial class crf4a_FupsStatus : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "FupsStatus";
            }
        }



        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }


        //private void DateFormatPageLoad()
        //{
        //    txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        //    txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
        //    txtCalndrDate.Attributes.Add("readonly", "readonly");
        //    txtCalndrDate1.Attributes.Add("readonly", "readonly");
        //    txtCalndrDate.Enabled = false;
        //    txtCalndrDate1.Enabled = false;
        //    CheckBox1.Checked = true;
        //}




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
                if (DropDownList1.SelectedValue == "0")
                {
                    showalert("Please Select Followups Status");
                    DropDownList1.Focus();
                }
                else if (DropDownList1.SelectedValue == "4a_Done")
                {
                    cmd = new MySqlCommand("select c.study_code,a.woman_nm,a.husband_nm,a.dssid,a.arm, (select 	concat(ROUND(((sum(z.lw_crf5a_31)/sum(		if((z.lw_crf5a_29 is NULL || z.lw_crf5a_29 =''), (SELECT (DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'), str_to_date(y.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as y where y.study_id=z.study_id), z.lw_crf5a_29)				))*100),1),'%')  from form_crf_5a as z where z.study_id=c.study_id) as Cumulative, (SELECT z.date_of_attempt FROM form_crf_4a AS z WHERE z.followup_num='47' AND z.study_id=c.study_id) AS last_DOV			from view_followups4a as a  left join studies as c on c.study_code=a.study_code left join form_crf_3a as d on d.assis_id=a.id where a.followups='47' and a.status=1  order by c.study_code;", con);
                    // cmd = new MySqlCommand("select c.study_code,a.woman_nm,a.husband_nm,a.dssid,a.arm, (select 	concat(ROUND(((sum(z.lw_crf5a_31)/sum(		if((z.lw_crf5a_29 is NULL || z.lw_crf5a_29 =''), (SELECT (DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'), str_to_date(y.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as y where y.study_id=z.study_id), z.lw_crf5a_29)				))*100),1),'%')  from form_crf_5a as z where z.study_id=c.study_id) as Cumulative			from view_followups4a as a  left join studies as c on c.study_code=a.study_code left join form_crf_3a as d on d.assis_id=a.id where a.followups='47' and a.status=1  order by c.study_code;", con);
                  

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
                else if (DropDownList1.SelectedValue == "4a_Pending")
                {
                    cmd = new MySqlCommand("SELECT 	a.study_code,a.woman_nm,a.husband_nm,a.dssid,a.arm,'Cumulative',	(SELECT CONCAT(   MAX(STR_TO_DATE(z.date_of_attempt,'%d-%m-%Y')) ,', F/ups: ', MAX(z.followup_num)) AS last_dov FROM form_crf_4a AS z WHERE z.study_id=c.study_id  GROUP BY z.study_id) AS last_DOV 	FROM view_followups4a AS a LEFT JOIN studies AS c ON c.study_code=a.study_code WHERE a.followups='47' AND a.status=3 ORDER BY a.site,a.study_code;", con);

                   // cmd = new MySqlCommand("select 	a.study_code,a.woman_nm,a.husband_nm,a.dssid,a.arm,'Cumulative' from view_followups4a as a where a.followups='47' and a.status=3 order by a.site,a.study_code;", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                            int temp = GridView1.Columns.Count;
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
        }


        public void ExcelExportMessage()
        {
            if (DropDownList1.SelectedValue != "0")
            {
                GridView2.Caption = "<h3/><b>" + DropDownList1.SelectedItem.Text;
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
                if (DropDownList1.SelectedValue == "4a_Done")
                {
                    con.Open();
                    MySqlCommand cmd;

                    cmd = new MySqlCommand("select c.study_code,a.woman_nm,a.husband_nm,a.dssid,a.arm, (select 	concat(ROUND(((sum(z.lw_crf5a_31)/sum(		if((z.lw_crf5a_29 is NULL || z.lw_crf5a_29 =''), (SELECT (DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'), str_to_date(y.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as y where y.study_id=z.study_id), z.lw_crf5a_29)				))*100),1),'%')  from form_crf_5a as z where z.study_id=c.study_id) as Cumulative, (SELECT z.date_of_attempt FROM form_crf_4a AS z WHERE z.followup_num='47' AND z.study_id=c.study_id) AS last_DOV			from view_followups4a as a  left join studies as c on c.study_code=a.study_code left join form_crf_3a as d on d.assis_id=a.id where a.followups='47' and a.status=1  order by c.study_code;", con);
                    // cmd = new MySqlCommand("select c.study_code,a.woman_nm,a.husband_nm,a.dssid,a.arm, (select 	concat(ROUND(((sum(z.lw_crf5a_31)/sum(		if((z.lw_crf5a_29 is NULL || z.lw_crf5a_29 =''), (SELECT (DATEDIFF(str_to_date(z.lw_crf5a_02, '%d-%m-%Y'), str_to_date(y.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as y where y.study_id=z.study_id), z.lw_crf5a_29)				))*100),1),'%')  from form_crf_5a as z where z.study_id=c.study_id) as Cumulative			from view_followups4a as a  left join studies as c on c.study_code=a.study_code left join form_crf_3a as d on d.assis_id=a.id where a.followups='47' and a.status=1  order by c.study_code;", con);

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
                else if (DropDownList1.SelectedValue == "4a_Pending")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("SELECT 	a.study_code,a.woman_nm,a.husband_nm,a.dssid,a.arm,'Cumulative',	(SELECT CONCAT(   MAX(STR_TO_DATE(z.date_of_attempt,'%d-%m-%Y')) ,', F/ups: ', MAX(z.followup_num)) AS last_dov FROM form_crf_4a AS z WHERE z.study_id=c.study_id  GROUP BY z.study_id) AS last_DOV 	FROM view_followups4a AS a LEFT JOIN studies AS c ON c.study_code=a.study_code WHERE a.followups='47' AND a.status=3 ORDER BY a.site,a.study_code;", con);

                    //cmd = new MySqlCommand("select 	a.study_code,a.woman_nm,a.husband_nm,a.dssid,a.arm,'Cumulative' from view_followups4a as a where a.followups='47' and a.status=3 order by a.site,a.study_code;", con);

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
                Response.AddHeader("content-disposition", "attachment;filename=CRF4a-FollowupsStatus (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
                if (e.Row.Cells[6].Text == "Cumulative")
                {
                    e.Row.Cells[6].Text = "Null";
                }
            }
        }


    }
}