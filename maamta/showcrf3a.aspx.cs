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
    public partial class showcrf3a : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["StudyIdCRF3a"] = null;
                DateFormatPageLoad();
                Session["WebForm"] = "showcrf3a";

                txtCalndrDate.Enabled = true;
                txtCalndrDate1.Enabled = true;
                CheckBox1.Checked = false;

                ShowData();
                txtdssid.Focus();

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
                    cmd = new MySqlCommand("select * from view_crf3a WHERE DSSID LIKE '%" + txtdssid.Text + "%' and (str_to_date(lw_crf_3a_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by form_crf_3a_id", con);
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
                    cmd = new MySqlCommand("select * from view_crf3a WHERE DSSID LIKE '%" + txtdssid.Text + "%'  order by form_crf_3a_id", con);
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
                    cmd = new MySqlCommand("select * from view_crf3a WHERE DSSID LIKE '%" + txtdssid.Text + "%' and (str_to_date(lw_crf_3a_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by form_crf_3a_id", con);
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
                    cmd = new MySqlCommand("select * from view_crf3a WHERE DSSID LIKE '%" + txtdssid.Text + "%' order by form_crf_3a_id", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=RANDOM CRF3a (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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


        protected void Link_StudyID(object sender, EventArgs e)
        {
            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            string form_crf_3a_id = commandArgs[0];
            string StudyId = commandArgs[1];

            Session["form_crf_3a_id"] = form_crf_3a_id;
            Session["StudyIdCRF3a"] = StudyId;
            Session["BackButtonCRF3a"] = "showcrf3a";
            Response.Redirect("showcrf3abyid.aspx");
        }


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[15].Text == "1")
                {
                    e.Row.Cells[15].Text = "Complete";
                }
                else if (e.Row.Cells[15].Text == "2")
                {
                    e.Row.Cells[15].Text = "Withdraw consent";
                }
                else if (e.Row.Cells[15].Text == "3")
                {
                    e.Row.Cells[15].Text = "Postponed by LW";
                }
                else if (e.Row.Cells[15].Text == "4")
                {
                    e.Row.Cells[15].Text = "Interrputed by Family";
                }
                else if (e.Row.Cells[15].Text == "5")
                {
                    e.Row.Cells[15].Text = "Baby is sick";
                }
                else if (e.Row.Cells[15].Text == "6")
                {
                    e.Row.Cells[15].Text = "LW is sick";
                }
            }
        }


        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[15].Text == "1")
                {
                    e.Row.Cells[15].Text = "Complete";
                }
                else if (e.Row.Cells[15].Text == "2")
                {
                    e.Row.Cells[15].Text = "Withdraw consent";
                }
                else if (e.Row.Cells[15].Text == "3")
                {
                    e.Row.Cells[15].Text = "Postponed by LW";
                }
                else if (e.Row.Cells[15].Text == "4")
                {
                    e.Row.Cells[15].Text = "Interrputed by Family";
                }
                else if (e.Row.Cells[15].Text == "5")
                {
                    e.Row.Cells[15].Text = "Baby is sick";
                }
                else if (e.Row.Cells[15].Text == "6")
                {
                    e.Row.Cells[15].Text = "LW is sick";
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

                cmd = new MySqlCommand("select c.assis_id as q1,a.lw_crf_3a_2 as q2,a.lw_crf_3a_3 as q3,a.lw_crf_3a_4 as q4,(a.lw_crf_3a_14+1)as q5, a.lw_crf_3a_15 as q6,a.lw_crf_3a_16 as q7,a.lw_crf_3a_18 as q8, 			(CASE    WHEN a.lw_crf_3a_19 like '%a%' THEN '44'    WHEN a.lw_crf_3a_19 like '%b%' THEN '55'    WHEN a.lw_crf_3a_19 like '%c%' THEN '66' END)  as q9					,a.lw_crf_3a_25 as q12  from form_crf_3a as a inner join pw as c on a.assis_id=c.id", con);

                //cmd = new MySqlCommand("select c.assis_id as q1,a.lw_crf_3a_2 as q2,a.lw_crf_3a_3 as q3,a.lw_crf_3a_4 as q4,(a.lw_crf_3a_14+1)as q5, a.lw_crf_3a_15 as q6,a.lw_crf_3a_16 as q7,a.lw_crf_3a_18 as q8, 			(CASE    WHEN a.lw_crf_3a_19 like '%a%' THEN '44'    WHEN a.lw_crf_3a_19 like '%b%' THEN '55'    WHEN a.lw_crf_3a_19 like '%c%' THEN '66' END)  as q9					,a.lw_crf_3a_20 as q10,a.lw_crf_3a_22 as q11,a.lw_crf_3a_25 as q12  from form_crf_3a as a inner join pw as c on a.assis_id=c.id", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=BMFG CRF3a (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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