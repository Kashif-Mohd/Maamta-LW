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
    public partial class scrnduplicate : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "scrnDuplicate";
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

                MySqlCommand cmd = new MySqlCommand("select count(TableA.assis_id)as total,Year,dssid, woman_nm, husband_nm   from (select a.*,DATE_FORMAT(str_to_date(lw_crf1_02, '%d-%m-%Y'),'%Y') as Year,concat (DATE_FORMAT(str_to_date(a.lw_crf1_02, '%d-%m-%Y'),'%Y'),':',a.dssid) as dssidYear from view_crf1 as a where a.form_crf_1_id in (select max(z.form_crf_1_id) from form_crf_1 as z group by z.pw_assis_id)) TableA group by TableA.dssidYear HAVING COUNT(*) >= 2", con);

                // Updated Query Year Wise (03-Sept-2019)
                // MySqlCommand cmd = new MySqlCommand("select count(*)as total, Year,dssid, woman_nm, husband_nm  from (SELECT assis_id, dssid,DATE_FORMAT(str_to_date(lw_crf1_02, '%d-%m-%Y'),'%Y') as Year, concat (DATE_FORMAT(str_to_date(lw_crf1_02, '%d-%m-%Y'),'%Y'),':',dssid) as dssidYear, woman_nm, husband_nm, DATE_FORMAT(str_to_date(lw_crf1_02, '%d-%m-%Y'),'%Y') as dov FROM view_crf1 GROUP BY assis_id) b group by b.dssidYear having count(b.dssidYear)>1 order by b.dssidYear", con);

                // 01 August 2018
                //  MySqlCommand cmd = new MySqlCommand("select count(*)as total, dssid, woman_nm, husband_nm  from (SELECT assis_id,  dssid, woman_nm, husband_nm  FROM view_crf1 GROUP BY assis_id) b group by b.dssid having count(b.dssid)>1 order by b.dssid", con);
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
                ExcelExport();
            }
        }


        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT  a.*, b.totalCount AS Duplicate FROM  (SELECT z.* FROM view_crf1 as z INNER JOIN (SELECT MAX(form_crf_1_id) as form_crf_1_id,assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate  FROM view_crf1   GROUP BY assis_id) AS b  ON   b.form_crf_1_id=z.form_crf_1_id  GROUP BY  b.assis_id ) a INNER JOIN (SELECT  r.dssid, COUNT(*) totalCount FROM (SELECT z.*,concat (DATE_FORMAT(str_to_date(z.lw_crf1_02, '%d-%m-%Y'),'%Y'),':',dssid) as dssidYear FROM view_crf1 as z INNER JOIN (SELECT MAX(form_crf_1_id) as form_crf_1_id,assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate  FROM view_crf1   GROUP BY assis_id) AS b  ON   b.form_crf_1_id=z.form_crf_1_id  GROUP BY  b.assis_id ) as r GROUP BY r.dssidYear HAVING COUNT(*) >= 2) b ON a.dssid = b.dssid");

                // 02 August 2018
               // MySqlCommand cmd = new MySqlCommand("SELECT  a.*, b.totalCount AS Duplicate FROM  (SELECT z.* FROM view_crf1 as z INNER JOIN (SELECT MAX(form_crf_1_id) as form_crf_1_id,assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate  FROM view_crf1   GROUP BY assis_id) AS b  ON   b.form_crf_1_id=z.form_crf_1_id  GROUP BY  b.assis_id ) a INNER JOIN (SELECT  r.dssid, COUNT(*) totalCount FROM (SELECT z.* FROM view_crf1 as z INNER JOIN (SELECT MAX(form_crf_1_id) as form_crf_1_id,assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate  FROM view_crf1   GROUP BY assis_id) AS b  ON   b.form_crf_1_id=z.form_crf_1_id  GROUP BY  b.assis_id ) as r GROUP BY r.dssid HAVING COUNT(*) >= 2) b ON a.dssid = b.dssid");

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
            Session["BackButtonShowCRF1"] = null;
            Session["dssid"] = null;

            string dssid = ((LinkButton)sender).Text;
            Session["dssid"] = dssid;
            Session["BackButtonShowCRF1"] = "scrnduplicate";
            Response.Redirect("showcrf1.aspx");
        }

    }
}