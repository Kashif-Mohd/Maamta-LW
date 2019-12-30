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
    public partial class showcrf1 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateFormatPageLoad();

                if (Session["dssid"] != null)
                {
                    Session["WebForm"] = "scrnDuplicate";
                    lbeDateFromTo.Text = "(search by DSSID: '" + Convert.ToString(Session["dssid"]) + "')";
                    txtdssid.Text = Convert.ToString(Session["dssid"]);
                    //Disable Calendar:
                    txtCalndrDate.Enabled = false;
                    txtCalndrDate1.Enabled = false;
                    CheckBox1.Checked = true;
                   
                    ShowData();
                    calendar.Visible = false;
                    divExportButton.Visible = false;
                    divSearch.Visible = false;
                }

                else if (Session["showcrf1Hide"] == null)
                {
                    ShowData();
                    divBackButton.Visible = false;
                    Session["WebForm"] = "showcrf1";
                    txtdssid.Focus();
                }
                else
                {
                    lbeDateFromTo.Text = "(Date From '" + Convert.ToString(Session["FirstEDate"]) + "' and '" + Convert.ToString(Session["SecEDate"]) + "')";
                    Session["WebForm"] = "Dashboard";
                    ShowDuplicateData();
                    divExportButton.Visible = false;
                    divSearch.Visible = false;
                }
            }
        }



        private void DateFormatPageLoad()
        {
            txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate.Attributes.Add("readonly", "readonly");
            txtCalndrDate1.Attributes.Add("readonly", "readonly");
            //txtCalndrDate.Enabled=false;
            //txtCalndrDate1.Enabled=false;
            CheckBox1.Checked = false;
        }


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtCalndrDate.Enabled = !CheckBox1.Checked;
            txtCalndrDate1.Enabled = !CheckBox1.Checked;
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

        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (CheckBox1.Checked == false)
                {
                    con.Open();
                    MySqlCommand cmd;
                    if (DropDownList1.SelectedValue == "1")
                    {
                        cmd = new MySqlCommand("SELECT a.*,b.code_of_reader_1 as code1,b.code_of_reader_2 as code2, b.reading_1  as LW_MUAC_R1,	b.reading_2  as LW_MUAC_R2 from view_crf1  as a 		left join(select * from muac_assessment  where id in ( select max(id) from muac_assessment group by form_crf_1_id)) as b on b.form_crf_1_id=a.form_crf_1_id          where a.lw_crf1_21!='' and a.lw_crf1_21<24  and a.dssid like '%" + txtdssid.Text + "%' and (str_to_date(a.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by a.form_crf_1_id", con);
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
                    else if (DropDownList1.SelectedValue == "2")
                    {
                        cmd = new MySqlCommand("SELECT a.*,b.code_of_reader_1 as code1,b.code_of_reader_2 as code2, b.reading_1  as LW_MUAC_R1,	b.reading_2  as LW_MUAC_R2 from view_crf1 as a 		left join(select * from muac_assessment  where id in ( select max(id) from muac_assessment group by form_crf_1_id)) as b on b.form_crf_1_id=a.form_crf_1_id              where a.lw_crf1_21!='' and a.lw_crf1_21>=24  and a.dssid like '%" + txtdssid.Text + "%' and (str_to_date(a.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by a.form_crf_1_id", con);
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
                        cmd = new MySqlCommand("SELECT a.*,b.code_of_reader_1 as code1,b.code_of_reader_2 as code2, b.reading_1  as LW_MUAC_R1,	b.reading_2  as LW_MUAC_R2 from view_crf1 as a 		left join(select * from muac_assessment  where id in ( select max(id) from muac_assessment group by form_crf_1_id)) as b on b.form_crf_1_id=a.form_crf_1_id              where a.dssid like '%" + txtdssid.Text + "%' and (str_to_date(a.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by a.form_crf_1_id", con);
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
                else 
                {
                    con.Open();
                    MySqlCommand cmd;
                    if (DropDownList1.SelectedValue == "1")
                    {
                        cmd = new MySqlCommand("SELECT a.*,b.code_of_reader_1 as code1,b.code_of_reader_2 as code2, b.reading_1  as LW_MUAC_R1,	b.reading_2  as LW_MUAC_R2 from view_crf1 as a 		left join(select * from muac_assessment  where id in ( select max(id) from muac_assessment group by form_crf_1_id)) as b on b.form_crf_1_id=a.form_crf_1_id              where a.lw_crf1_21!='' and a.lw_crf1_21<24  and a.dssid like '%" + txtdssid.Text + "%' order by a.form_crf_1_id", con);
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
                    else if (DropDownList1.SelectedValue == "2")
                    {
                        cmd = new MySqlCommand("SELECT a.*,b.code_of_reader_1 as code1,b.code_of_reader_2 as code2, b.reading_1  as LW_MUAC_R1,	b.reading_2  as LW_MUAC_R2 from view_crf1 as a 		left join(select * from muac_assessment  where id in ( select max(id) from muac_assessment group by form_crf_1_id)) as b on b.form_crf_1_id=a.form_crf_1_id          where a.lw_crf1_21!='' and a.lw_crf1_21>=24  and a.dssid like '%" + txtdssid.Text + "%' order by a.form_crf_1_id", con);
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
                        cmd = new MySqlCommand("SELECT a.*,b.code_of_reader_1 as code1,b.code_of_reader_2 as code2, b.reading_1  as LW_MUAC_R1,	b.reading_2  as LW_MUAC_R2 from view_crf1 as a 		left join(select * from muac_assessment  where id in ( select max(id) from muac_assessment group by form_crf_1_id)) as b on b.form_crf_1_id=a.form_crf_1_id              where a.dssid like '%" + txtdssid.Text + "%' order by a.form_crf_1_id", con);
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






        private void ShowDuplicateData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;

                cmd = new MySqlCommand("SELECT  a.*, count(*) as total FROM  view_crf1 a  INNER JOIN (SELECT  assis_id,dssid, COUNT(*) totalCount FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + Convert.ToString(Session["FirstEDate"]) + "', '%d-%m-%Y') and str_to_date('" + Convert.ToString(Session["SecEDate"]) + "', '%d-%m-%Y') )  GROUP BY dssid HAVING COUNT(*) >= 2 )  b ON a.dssid = b.dssid  GROUP BY a.assis_id  order by a.dssid", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
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







        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["BackButtonShowCRF1"]) == "scrnduplicate")
            {
                Response.Redirect("scrnduplicate.aspx");
            }
            else
            {
                Response.Redirect("Dashboard.aspx");
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
            else if (DropDownList1.SelectedValue == "1")
            {
                GridView2.Caption = "MUAC Less than 24";
            }
            else if (DropDownList1.SelectedValue == "2")
            {
                GridView2.Caption = "MUAC Greater than and Equal to 24";
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
                if (CheckBox1.Checked == false)
                {
                    con.Open();
                    MySqlCommand cmd;
                    if (DropDownList1.SelectedValue == "1")
                    {
                        //According to Max Visit Status
                        cmd = new MySqlCommand("SELECT a.*,bb.code_of_reader_1 as code1,bb.code_of_reader_2 as code2, bb.reading_1  as LW_MUAC_R1,	bb.reading_2  as LW_MUAC_R2 		 from view_crf1 as a    		left join(select * from muac_assessment  where id in ( select max(id) from muac_assessment group by form_crf_1_id)) as bb on bb.form_crf_1_id=a.form_crf_1_id                        inner join (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) GROUP BY assis_id) AS b  ON  a.assis_id = b.assis_id AND str_to_date(a.lw_crf1_02, '%d-%m-%Y') = b.TopDate  and lw_crf1_21!='' and lw_crf1_21<24  and  a.dssid like '%" + txtdssid.Text + "%' and (str_to_date(a.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))", con);

                        //cmd = new MySqlCommand("SELECT * from view_crf1 where lw_crf1_21!='' and lw_crf1_21<24  and dssid like '%" + txtdssid.Text + "%' and (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by form_crf_1_id", con);
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
                    else if (DropDownList1.SelectedValue == "2")
                    {
                        //According to Max Visit Status
                        cmd = new MySqlCommand("SELECT a.*,bb.code_of_reader_1 as code1,bb.code_of_reader_2 as code2, bb.reading_1  as LW_MUAC_R1,	bb.reading_2  as LW_MUAC_R2 		 from view_crf1 as a            		left join(select * from muac_assessment  where id in ( select max(id) from muac_assessment group by form_crf_1_id)) as bb on bb.form_crf_1_id=a.form_crf_1_id                    inner join (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) GROUP BY assis_id) AS b  ON  a.assis_id = b.assis_id AND str_to_date(a.lw_crf1_02, '%d-%m-%Y') = b.TopDate  and lw_crf1_21!='' and lw_crf1_21>=24  and  a.dssid like '%" + txtdssid.Text + "%' and (str_to_date(a.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))", con);

                        //cmd = new MySqlCommand("SELECT * from view_crf1 where lw_crf1_21!='' and lw_crf1_21>=24  and dssid like '%" + txtdssid.Text + "%' and (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by form_crf_1_id", con);
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
                        //According to Max Visit Status
                        cmd = new MySqlCommand("SELECT a.*,bb.code_of_reader_1 as code1,bb.code_of_reader_2 as code2, bb.reading_1  as LW_MUAC_R1,	bb.reading_2  as LW_MUAC_R2 		 from view_crf1 as a                    		left join(select * from muac_assessment  where id in ( select max(id) from muac_assessment group by form_crf_1_id)) as bb on bb.form_crf_1_id=a.form_crf_1_id                    inner join (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) GROUP BY assis_id) AS b  ON  a.assis_id = b.assis_id AND str_to_date(a.lw_crf1_02, '%d-%m-%Y') = b.TopDate and a.dssid like '%" + txtdssid.Text + "%' and (str_to_date(a.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))", con);

                        //cmd = new MySqlCommand("SELECT * from view_crf1 where dssid like '%" + txtdssid.Text + "%' and (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by form_crf_1_id", con);
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
                else
                {
                    con.Open();
                    MySqlCommand cmd;
                    if (DropDownList1.SelectedValue == "1")
                    {
                        //According to Max Visit Status
                        cmd = new MySqlCommand("SELECT a.*,bb.code_of_reader_1 as code1,bb.code_of_reader_2 as code2, bb.reading_1  as LW_MUAC_R1,	bb.reading_2  as LW_MUAC_R2 		 from view_crf1 as a            		left join(select * from muac_assessment  where id in ( select max(id) from muac_assessment group by form_crf_1_id)) as bb on bb.form_crf_1_id=a.form_crf_1_id                        inner join (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  a.assis_id = b.assis_id AND str_to_date(a.lw_crf1_02, '%d-%m-%Y') = b.TopDate  and lw_crf1_21!='' and lw_crf1_21<24  and and a.dssid like '%" + txtdssid.Text + "%'", con);

                        //cmd = new MySqlCommand("SELECT * from view_crf1 where lw_crf1_21!='' and lw_crf1_21<24  and dssid like '%" + txtdssid.Text + "%' order by form_crf_1_id", con);
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
                    else if (DropDownList1.SelectedValue == "2")
                    {
                        //According to Max Visit Status
                        cmd = new MySqlCommand("SELECT a.*,bb.code_of_reader_1 as code1,bb.code_of_reader_2 as code2, bb.reading_1  as LW_MUAC_R1,	bb.reading_2  as LW_MUAC_R2 		 from view_crf1 as a            		left join(select * from muac_assessment  where id in ( select max(id) from muac_assessment group by form_crf_1_id)) as bb on bb.form_crf_1_id=a.form_crf_1_id                    inner join (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  a.assis_id = b.assis_id AND str_to_date(a.lw_crf1_02, '%d-%m-%Y') = b.TopDate  and lw_crf1_21!='' and lw_crf1_21>=24  and and a.dssid like '%" + txtdssid.Text + "%'", con);

                        //cmd = new MySqlCommand("SELECT * from view_crf1 where lw_crf1_21!='' and lw_crf1_21>=24  and dssid like '%" + txtdssid.Text + "%' order by form_crf_1_id", con);
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
                        //According to Max Visit Status
                        cmd = new MySqlCommand("SELECT a.*,bb.code_of_reader_1 as code1,bb.code_of_reader_2 as code2, bb.reading_1  as LW_MUAC_R1,	bb.reading_2  as LW_MUAC_R2 		 from view_crf1 as a                		left join(select * from muac_assessment  where id in ( select max(id) from muac_assessment group by form_crf_1_id)) as bb on bb.form_crf_1_id=a.form_crf_1_id                    inner join (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  a.assis_id = b.assis_id AND str_to_date(a.lw_crf1_02, '%d-%m-%Y') = b.TopDate  and a.dssid like '%" + txtdssid.Text + "%'", con);
                        
                        //cmd = new MySqlCommand("SELECT * from view_crf1 where dssid like '%" + txtdssid.Text + "%' order by form_crf_1_id", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=SCREENING (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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





        protected void Link_Assis(object sender, EventArgs e)
        {
            //string[] arg = new string[2];
            //arg = ((LinkButton)sender).CommandArgument.ToString().Split(':');
            //string a = arg[2];
            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });

            string Assis = commandArgs[0];
            string Form1_ID = commandArgs[1];

            Session["Assis"] = Assis;
            Session["Form1_ID"] = Form1_ID;
            Session["BackButton"] = "showcrf1";
            Response.Redirect("showcrf1byid.aspx");
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[14].Text == "1")
                {
                    e.Row.Cells[14].Text = "Complete";
                }
                else if (e.Row.Cells[14].Text == "2")
                {
                    e.Row.Cells[14].Text = "Not at home";
                }
                else if (e.Row.Cells[14].Text == "3")
                {
                    e.Row.Cells[14].Text = "Refused";
                }
                else if (e.Row.Cells[14].Text == "4")
                {
                    e.Row.Cells[14].Text = "Wrong Information";
                }
                else if (e.Row.Cells[14].Text == "5")
                {
                    e.Row.Cells[14].Text = "Wrong Info. DSS";
                }
                else if (e.Row.Cells[14].Text == "6")
                {
                    e.Row.Cells[14].Text = "Woman was never found Pregnant";
                }
                else if (e.Row.Cells[14].Text == "7")
                {
                    e.Row.Cells[14].Text = "Woman was preg. but recently delivered";
                }
                else if (e.Row.Cells[14].Text == "8")
                {
                    e.Row.Cells[14].Text = "Shifted out of DSS";
                }
                else if (e.Row.Cells[14].Text == "9")
                {
                    e.Row.Cells[14].Text = "PW died";
                }
                else if (e.Row.Cells[14].Text == "10")
                {
                    e.Row.Cells[14].Text = "Visitor";
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
                    e.Row.Cells[15].Text = "Not at home";
                }
                else if (e.Row.Cells[15].Text == "3")
                {
                    e.Row.Cells[15].Text = "Refused";
                }
                else if (e.Row.Cells[15].Text == "4")
                {
                    e.Row.Cells[15].Text = "Wrong Information";
                }
                else if (e.Row.Cells[15].Text == "5")
                {
                    e.Row.Cells[15].Text = "Wrong Info. DSS";
                }
                else if (e.Row.Cells[15].Text == "6")
                {
                    e.Row.Cells[15].Text = "Woman was never found Pregnant";
                }
                else if (e.Row.Cells[15].Text == "7")
                {
                    e.Row.Cells[15].Text = "Woman was preg. but recently delivered";
                }
                else if (e.Row.Cells[15].Text == "8")
                {
                    e.Row.Cells[15].Text = "Shifted out of DSS";
                }
                else if (e.Row.Cells[15].Text == "9")
                {
                    e.Row.Cells[15].Text = "PW died";
                }
                else if (e.Row.Cells[15].Text == "10")
                {
                    e.Row.Cells[15].Text = "Visitor";
                }                
            }
        }





    }
}