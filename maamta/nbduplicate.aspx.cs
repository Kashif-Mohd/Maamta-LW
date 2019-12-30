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
    public partial class nbduplicate : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "nbDuplicate";
                ShowData();
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
        }

        public void ExcelExportMessage()
        {
            if (DropDownListForm.SelectedValue == "nb")
            {
                GridView2.Caption = "Newborn Duplicate";
            }
            else if (DropDownListForm.SelectedValue == "comp")
            {
                GridView2.Caption = "Compliance Duplicate";
            }

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
                if (DropDownListForm.SelectedValue == "nb")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select followup_num,study_code,Day,date_of_attempt,q10 as woman_nm, dssid from view_crf4a_only  group by concat(study_code,followup_num) having count(concat (study_code,followup_num))>1 order by dssid,study_code,followup_num", con);
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
                else if (DropDownListForm.SelectedValue == "comp")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select followup_num,study_code,Day,lw_crf5a_02 as date_of_attempt,q10 as woman_nm, dssid from view_crf5a  group by concat(study_code,followup_num) having count(concat (study_code,followup_num))>1 order by dssid,study_code,followup_num", con);
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






        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }




        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {

                if (DropDownListForm.SelectedValue == "nb")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select followup_num,study_code,Day,date_of_attempt,q10 as woman_nm, dssid from view_crf4a_only  group by concat(study_code,followup_num) having count(concat (study_code,followup_num))>1 order by dssid,study_code,followup_num", con);
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
                else if (DropDownListForm.SelectedValue == "comp")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select followup_num,study_code,Day,lw_crf5a_02 as date_of_attempt,q10 as woman_nm, dssid from view_crf5a  group by concat(study_code,followup_num) having count(concat (study_code,followup_num))>1 order by dssid,study_code,followup_num", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=Duplicate NB/Compliance (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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



        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.Cells[1].Text == "&nbsp;")
            //    {
            //        e.Row.Cells[1].Text = "1";
            //    }
            //}
        }


    }
}