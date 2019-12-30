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
    public partial class losttofollowup : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "losttofollowup";
                //ShowData();
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
            if (txtdssid.Text == "" || txtdssid.Text.Length < 5)
            {
                showalert("Enter DSSID, minimun length should be 5");
                txtdssid.Focus();
            }
            else
            {
                ShowData();
                txtdssid.Focus();
            }
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
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select a.study_id,a.lw_crf1_09 as woman_nm,a.lw_crf1_10 as husband_nm,a.dssid,	b.wm_status  from view_crf3a as a left join participant_status as b on  a.study_id=b.study_code where a.dssid like '%" + txtdssid.Text + "%'", con);
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



        protected void btnExport_Click(object sender, EventArgs e)
        {
           
                ExcelExport();
           
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
                cmd = new MySqlCommand("select * from participant_status where dssid like '%" + txtdssid.Text + "%'", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=Lost to Followup (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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



        protected void Link_EditForm(object sender, EventArgs e)
        {
            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            txtStudyID.Text = commandArgs[0];
            txtdssidEntry.Text = commandArgs[1];
            txtWomanNm.Text = commandArgs[2];
            txtHusbandNm.Text = commandArgs[3];
            if (commandArgs[4] != "")
            {
                txtStatus.SelectedValue = commandArgs[4];
            }

            divShowData.Visible = false;
            divEntry.Visible = true;
            txtStatus.Focus();
        }










        protected void submit_Click(object sender, EventArgs e)
        {

            MySqlConnection cn = new MySqlConnection(constr);
          
            try
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from participant_status where study_code='" + txtStudyID.Text + "'", cn);
                cmd.ExecuteNonQuery();
                cn.Close();

                if (txtStatus.SelectedValue != "None")
                {
                    cn.Open();
                    MySqlCommand cmd1 = new MySqlCommand("insert into participant_status(study_code,dssid ,woman_nm ,husband_nm,wm_status ,entry_dt	,entry_nm) values ('" + txtStudyID.Text + "','" + txtdssidEntry.Text.ToUpper() + "','" + txtWomanNm.Text.ToUpper() + "','" + txtHusbandNm.Text.ToUpper() + "','" + txtStatus.Text + "','" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + Convert.ToString(Session["MPusername"]) + "')", cn);
                    cmd1.ExecuteNonQuery();
                    cn.Close();
                }
                Response.Redirect("losttofollowup.aspx");
            }
            catch (Exception ex)
            {
                showalert(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }



    }
}