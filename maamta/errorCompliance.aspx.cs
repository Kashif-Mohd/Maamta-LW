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
    public partial class errorCompliance : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "errorCompliance";
                ShowData();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



      


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select form_crf_5a_id,study_code,followup_num,age,Day,lw_crf5a_02 as DOV,lw_crf5a_03 as TOV,q10 as woman_nm,q11 as husband_nm, dssid,arm,lw_crf5a_29 as Required_Sachet_29,lw_crf5a_30 as Sachet_Received_30,lw_crf5a_31 as Sachet_used_by_LW_31,lw_crf5a_33 as Percentage,(lw_crf5a_31-lw_crf5a_29) as Xtra_Sachet_Used_by_LW, name as SRA_Name  	 from view_crf5a where (lw_crf5a_31-lw_crf5a_29)>1 and lw_crf5a_30!=lw_crf5a_31 order by study_code,followup_num", con);
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
                cmd = new MySqlCommand("select form_crf_5a_id,study_code,followup_num,age,Day,lw_crf5a_02 as DOV,lw_crf5a_03 as TOV,q10 as woman_nm,q11 as husband_nm, dssid,arm,lw_crf5a_29 as Required_Sachet_29,lw_crf5a_30 as Sachet_Received_30,lw_crf5a_31 as Sachet_used_by_LW_31,lw_crf5a_33 as Percentage,(lw_crf5a_31-lw_crf5a_29) as Xtra_Sachet_Used_by_LW, name as SRA_Name  	 from view_crf5a where (lw_crf5a_31-lw_crf5a_29)>1 and lw_crf5a_30!=lw_crf5a_31 order by study_code,followup_num", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=Error Compliance (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
                if (e.Row.Cells[13].Text == "&nbsp;" || e.Row.Cells[13].Text == "" || e.Row.Cells[13].Text == "null")
                {
                    float Vall;
                    Vall = (float.Parse(e.Row.Cells[12].Text) / float.Parse(e.Row.Cells[10].Text)) * 100;

                    e.Row.Cells[13].Text = (String.Format("{0:0.0}", Vall) + "%");
                }
            }
        }




    }
}