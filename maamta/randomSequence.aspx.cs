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
    public partial class randomSequence : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["StudyId_RandomSeq"] = null;
                Session["WebForm"] = "randomSequence";

                if (Session["RandomSeq_Site"] != null)
                {
                    DropDownList1.SelectedValue = Convert.ToString(Session["RandomSeq_Site"]);
                    ShowData();
                    Session["RandomSeq_Site"] = null;
                }
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
                if (DropDownList1.SelectedValue == "0")
                {
                    showalert("Please select Site");
                    DropDownList1.Focus();
                }
                else
                {
                    cmd = new MySqlCommand("SELECT a.form_crf_3a_id,a.study_id,a.lw_crf_3a_2, a.lw_crf_3a_3,a.lw_crf_3a_18,a.lw_crf_3a_19,c.lw_crf3c_28,a.dssid,b.randomization_id,b.treatment FROM view_crf3a AS a LEFT JOIN lab_investigation AS b ON a.lw_crf_3a_18=b.randomization_id LEFT JOIN view_crf3c AS c ON c.study_code=a.study_id WHERE a.lw_crf_3a_18 like '%" + DropDownList1.SelectedValue + "%' ORDER BY STR_TO_DATE(a.lw_crf_3a_2, '%d-%m-%Y'), STR_TO_DATE(a.lw_crf_3a_3,  '%H:%i')", con);
                    //old before (23-Jan-2020)

                   // cmd = new MySqlCommand("select a.form_crf_3a_id,a.study_id,a.lw_crf_3a_2, a.lw_crf_3a_3,a.lw_crf_3a_18,a.lw_crf_3a_19,a.dssid,b.randomization_id,b.treatment from view_crf3a as a left join lab_investigation as b on a.lw_crf_3a_18=b.randomization_id where a.site='" + DropDownList1.SelectedValue + "' order by str_to_date(a.lw_crf_3a_2, '%d-%m-%Y'), STR_TO_DATE(a.lw_crf_3a_3,  '%H:%i')", con);

                    //old before (01-Sept-2018)
                    //cmd = new MySqlCommand("select form_crf_3a_id,study_id,lw_crf_3a_2, lw_crf_3a_3,lw_crf_3a_18,dssid from view_crf3a where site='" + DropDownList1.SelectedValue + "' order by str_to_date(lw_crf_3a_2, '%d-%m-%Y'), STR_TO_DATE(lw_crf_3a_3,  '%H:%i')", con);

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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }

        protected void Link_StudyID(object sender, EventArgs e)
        {
            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            string form_crf_3a_id = commandArgs[0];
            string StudyId = commandArgs[1];

            Session["form_crf_3a_id"] = form_crf_3a_id;
            Session["StudyId_RandomSeq"] = StudyId;
            Session["RandomSeq_Site"] = DropDownList1.SelectedValue;
            Session["BackButtonRandomSeq"] = "randomSequence";
            Response.Redirect("showcrf3abyid.aspx");
        }



        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExcelExport();
        }


        public void ExcelExportMessage()
        {
            if (DropDownList1.SelectedValue != "0")
            {
                GridView2.Caption = "<h3/><b>Site: " + DropDownList1.SelectedItem.Text;
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
                if (DropDownList1.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("SELECT a.form_crf_3a_id,a.site,a.study_id,a.lw_crf_3a_2, a.lw_crf_3a_3,a.lw_crf_3a_18,a.lw_crf_3a_19,c.lw_crf3c_28,a.dssid,b.randomization_id,b.treatment FROM view_crf3a AS a LEFT JOIN lab_investigation AS b ON a.lw_crf_3a_18=b.randomization_id LEFT JOIN view_crf3c AS c ON c.study_code=a.study_id  ORDER BY STR_TO_DATE(a.lw_crf_3a_2, '%d-%m-%Y'), STR_TO_DATE(a.lw_crf_3a_3,  '%H:%i')", con);

                    // cmd = new MySqlCommand("select a.form_crf_3a_id,a.site,a.study_id,a.lw_crf_3a_2, a.lw_crf_3a_3,a.lw_crf_3a_18,a.lw_crf_3a_19,a.dssid,b.randomization_id,b.treatment from view_crf3a as a left join lab_investigation as b on a.lw_crf_3a_18=b.randomization_id  order by a.site,str_to_date(a.lw_crf_3a_2, '%d-%m-%Y'), STR_TO_DATE(a.lw_crf_3a_3,  '%H:%i')", con);

                    //old before (01-Sept-2018)
                    //cmd = new MySqlCommand("select form_crf_3a_id,site,study_id,lw_crf_3a_2, lw_crf_3a_3,lw_crf_3a_18,dssid from view_crf3a  order by site,str_to_date(lw_crf_3a_2, '%d-%m-%Y'), STR_TO_DATE(lw_crf_3a_3,  '%H:%i')", con);
                   
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
                else
                {
                    con.Open();
                    MySqlCommand cmd;

                    cmd = new MySqlCommand("SELECT a.form_crf_3a_id,a.site,a.study_id,a.lw_crf_3a_2, a.lw_crf_3a_3,a.lw_crf_3a_18,a.lw_crf_3a_19,c.lw_crf3c_28,a.dssid,b.randomization_id,b.treatment FROM view_crf3a AS a LEFT JOIN lab_investigation AS b ON a.lw_crf_3a_18=b.randomization_id LEFT JOIN view_crf3c AS c ON c.study_code=a.study_id WHERE a.lw_crf_3a_18 like '%" + DropDownList1.SelectedValue + "%'  ORDER BY STR_TO_DATE(a.lw_crf_3a_2, '%d-%m-%Y'), STR_TO_DATE(a.lw_crf_3a_3,  '%H:%i')", con);

                    //old before (01-Sept-2018)
                    //cmd = new MySqlCommand("select form_crf_3a_id,site,study_id,lw_crf_3a_2, lw_crf_3a_3,lw_crf_3a_18,dssid from view_crf3a where site='" + DropDownList1.SelectedValue + "' order by str_to_date(lw_crf_3a_2, '%d-%m-%Y'), STR_TO_DATE(lw_crf_3a_3,  '%H:%i')", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=RANDOM SEQUENCE (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
                TableCell cell1 = e.Row.Cells[5];
                cell1.BackColor = System.Drawing.Color.FromName("#cef5cb");

                if (e.Row.Cells[6].Text.ToUpper() != e.Row.Cells[8].Text)
                {
                    TableCell cell0 = e.Row.Cells[6];
                    cell0.BackColor = System.Drawing.Color.FromName("#ff7675");
                    TableCell cell = e.Row.Cells[6];
                    cell.ForeColor = System.Drawing.Color.FromName("#ffffff");
                }
                if (e.Row.Cells[7].Text.ToUpper() != e.Row.Cells[8].Text)
                {
                    TableCell cell0 = e.Row.Cells[7];
                    cell0.BackColor = System.Drawing.Color.FromName("#ff7675");
                    TableCell cell = e.Row.Cells[7];
                    cell.ForeColor = System.Drawing.Color.FromName("#ffffff");
                }  
            }
        }

    }
}