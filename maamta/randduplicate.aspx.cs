using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace maamta
{
    public partial class randduplicate : System.Web.UI.Page
    {

        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "randDuplicate";
            Session["dssid"] = null;
            if (!IsPostBack)
            {
                ShowData();
            }
        }




        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT count(*)as total,assis_id,  dssid, lw_crf1_09 as woman_nm, lw_crf1_10 as husband_nm FROM view_crf2 group by assis_id having count(assis_id)>1 order by dssid", con);
                
                // 20-June-2019
                //  MySqlCommand cmd = new MySqlCommand("select count(*)as total, dssid, lw_crf1_09 as woman_nm, lw_crf1_10 as husband_nm from (SELECT assis_id,  dssid, lw_crf1_09, lw_crf1_10 FROM view_crf2 ) b group by b.dssid having count(b.dssid)>1 order by b.dssid", con);
                {
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



        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }



        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count != 0)
            {
              //  ExcelExport();
            }
        }


        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("");
                {
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
                Response.AddHeader("content-disposition", "attachment;filename=Duplicate Screening(" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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


        protected void Link_DSSID(object sender, EventArgs e)
        {
            string dssid = ((LinkButton)sender).Text;
            Session["RANDdssid"] = dssid;
            Session["BackButtonShowCRF2"] = "randduplicate";
            Response.Redirect("showcrf2.aspx");
        }



    }
}