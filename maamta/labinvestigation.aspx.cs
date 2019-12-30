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
    public partial class labinvestigation : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "LABinvestigation";
                DateFormatPageLoad();
                ShowData();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        private void DateFormatPageLoad()
        {
            txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate.Attributes.Add("readonly", "readonly");
            txtCalndrDate1.Attributes.Add("readonly", "readonly");
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (DateTime.ParseExact(txtCalndrDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtCalndrDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
            {
                showalert("First Date should be Less or Equal than Second Date");
                txtCalndrDate.Focus();
            }
            else
            {
                ShowData();
            }
        }


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (DropDownListDSSID.SelectedValue == "0" && DropDownListBabyAge.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest", con);
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
                else if (DropDownListDSSID.SelectedValue != "0" && DropDownListBabyAge.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest where site = '" + DropDownListDSSID.SelectedValue + "'", con);
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
                else if (DropDownListDSSID.SelectedValue == "0" && DropDownListBabyAge.SelectedValue == "40")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest  where  str_to_date(Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   order by current_age_baby  desc", con);
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
                else if (DropDownListDSSID.SelectedValue != "0" && DropDownListBabyAge.SelectedValue == "40")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest  where site = '" + DropDownListDSSID.SelectedValue + "'   and  str_to_date(Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   order by current_age_baby  desc", con);
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
                else if (DropDownListDSSID.SelectedValue == "0" && DropDownListBabyAge.SelectedValue == "56")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest where  str_to_date(Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   order by current_age_baby  desc", con);
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
                else if (DropDownListDSSID.SelectedValue != "0" && DropDownListBabyAge.SelectedValue == "56")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest  where site = '" + DropDownListDSSID.SelectedValue + "'  and  str_to_date(Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   order by current_age_baby  desc", con);
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
                if (DropDownListDSSID.SelectedValue == "0" && DropDownListBabyAge.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest", con);
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
                else if (DropDownListDSSID.SelectedValue != "0" && DropDownListBabyAge.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest where site = '" + DropDownListDSSID.SelectedValue + "'", con);
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
                else if (DropDownListDSSID.SelectedValue == "0" && DropDownListBabyAge.SelectedValue == "40")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest  where  str_to_date(Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   order by current_age_baby  desc", con);
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
                else if (DropDownListDSSID.SelectedValue != "0" && DropDownListBabyAge.SelectedValue == "40")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest  where site = '" + DropDownListDSSID.SelectedValue + "'   and  str_to_date(Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   order by current_age_baby  desc", con);
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
                else if (DropDownListDSSID.SelectedValue == "0" && DropDownListBabyAge.SelectedValue == "56")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest where  str_to_date(Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   order by current_age_baby  desc", con);
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
                else if (DropDownListDSSID.SelectedValue != "0" && DropDownListBabyAge.SelectedValue == "56")
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_lab_invest  where site = '" + DropDownListDSSID.SelectedValue + "'  and  str_to_date(Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')   order by current_age_baby  desc", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=Lab Investigation (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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







        protected void btnReport_Click(object sender, EventArgs e)
        {
            ExcelExportReport();
        }

        public void ExcelReportMessage()
        {
            //GridView2.Caption = "MAAMTA LW trial    <br/>(Pregnant Women (PW) Screened)";
            GridView3.Caption = "<h2/>MAAMTA LW trial<br/>   <h4/>LAB Investigation (Blood of Infant) <br/>Date from '" + txtCalndrDate.Text + "' To '" + txtCalndrDate1.Text + "'";
            GridView4.Caption = "<br/><br/>    <h4/>Breast Milk, LW stool, LW Blood and Infant stool <br/>Date from '" + txtCalndrDate.Text + "' To '" + txtCalndrDate1.Text + "'";
        }

        private void ReportOverAllSample()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select a.site,(select count(z.study_code) from view_lab_invest_report as z where a.site=z.site and z.treatment='A' and (str_to_date(z.Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_A_40,(select count(z.study_code) from view_lab_invest_report as z where a.site=z.site and z.treatment='A' and (str_to_date(z.Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_A_56,   (select count(z.study_code) from view_lab_invest_report as z where a.site=z.site and z.treatment='B' and (str_to_date(z.Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_B_40,(select count(z.study_code) from view_lab_invest_report as z where a.site=z.site and z.treatment='B' and (str_to_date(z.Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_B_56,  (select count(z.study_code) from view_lab_invest_report as z where a.site=z.site and z.treatment='C' and (str_to_date(z.Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_C_40,(select count(z.study_code) from view_lab_invest_report as z where a.site=z.site and z.treatment='C' and (str_to_date(z.Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_C_56    from view_lab_invest_report as a     group by a.site union all select 'Total',(select count(z.study_code) from view_lab_invest_report as z where  z.treatment='A' and (str_to_date(z.Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_A_40,		(select count(z.study_code) from view_lab_invest_report as z where  z.treatment='A' and (str_to_date(z.Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_A_56,	   (select count(z.study_code) from view_lab_invest_report as z where  z.treatment='B' and (str_to_date(z.Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_B_40,		(select count(z.study_code) from view_lab_invest_report as z where  z.treatment='B' and (str_to_date(z.Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_B_56,		(select count(z.study_code) from view_lab_invest_report as z where  z.treatment='C' and (str_to_date(z.Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_C_40,	(select count(z.study_code) from view_lab_invest_report as z where  z.treatment='C' and (str_to_date(z.Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_C_56    from view_lab_invest_report as a group by 'Total'", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
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



        private void ReportSelectedSample()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select a.site,(select count(z.study_code) from view_lab_invest_report as z where description not like '' and a.site=z.site and z.treatment='A' and (str_to_date(z.Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_A_40,(select count(z.study_code) from view_lab_invest_report as z where description not like '' and a.site=z.site and z.treatment='A' and (str_to_date(z.Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_A_56,   (select count(z.study_code) from view_lab_invest_report as z where description not like '' and a.site=z.site and z.treatment='B' and (str_to_date(z.Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_B_40,(select count(z.study_code) from view_lab_invest_report as z where description not like '' and a.site=z.site and z.treatment='B' and (str_to_date(z.Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_B_56,  (select count(z.study_code) from view_lab_invest_report as z where description not like '' and a.site=z.site and z.treatment='C' and (str_to_date(z.Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_C_40,(select count(z.study_code) from view_lab_invest_report as z where description not like '' and a.site=z.site and z.treatment='C' and (str_to_date(z.Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_C_56    from view_lab_invest_report as a     group by a.site union all select 'Total',(select count(z.study_code) from view_lab_invest_report as z where description not like '' and  z.treatment='A' and (str_to_date(z.Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_A_40,		(select count(z.study_code) from view_lab_invest_report as z where description not like '' and  z.treatment='A' and (str_to_date(z.Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_A_56,	   (select count(z.study_code) from view_lab_invest_report as z where description not like '' and  z.treatment='B' and (str_to_date(z.Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_B_40,		(select count(z.study_code) from view_lab_invest_report as z where description not like '' and  z.treatment='B' and (str_to_date(z.Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_B_56,		(select count(z.study_code) from view_lab_invest_report as z where description not like '' and  z.treatment='C' and (str_to_date(z.Age_Day_40, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_C_40,	(select count(z.study_code) from view_lab_invest_report as z where description not like '' and  z.treatment='C' and (str_to_date(z.Age_Day_56, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as ARM_C_56    from view_lab_invest_report as a group by 'Total'", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView4.DataSource = dt;
                        GridView4.DataBind();
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



        public void ExcelExportReport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Lab Invest Report (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView3.AllowPaging = false;
                GridView4.AllowPaging = false;
                ExcelReportMessage();
                GridView3.CaptionAlign = TableCaptionAlign.Top;
                GridView4.CaptionAlign = TableCaptionAlign.Top;
                ReportOverAllSample();
                ReportSelectedSample();

                for (int i = 0; i < GridView3.HeaderRow.Cells.Count; i++)
                {
                    GridView3.HeaderRow.Cells[i].Style.Add("font-size", "16px");
                    GridView3.HeaderRow.Cells[i].Style.Add("height", "80px");
                    GridView3.HeaderRow.Cells[i].Style.Add("background-color", "#00B894");
                    GridView3.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                // Footer Style: 
                GridView3.Rows[GridView3.Rows.Count - 1].Style.Add("font-size", "15px");
                GridView3.Rows[GridView3.Rows.Count - 1].Font.Bold = true;

                for (int i = 0; i < GridView4.HeaderRow.Cells.Count; i++)
                {
                    GridView4.HeaderRow.Cells[i].Style.Add("font-size", "16px");
                    GridView4.HeaderRow.Cells[i].Style.Add("height", "80px");
                    GridView4.HeaderRow.Cells[i].Style.Add("background-color", "#00B894");
                    GridView4.HeaderRow.Cells[i].Style.Add("Color", "white");

                }
                // Footer Style: 

                GridView4.Rows[GridView4.Rows.Count - 1].Style.Add("font-size", "15px");
                GridView4.Rows[GridView4.Rows.Count - 1].Font.Bold = true;

                GridView3.RenderControl(htmlWrite);
                GridView4.RenderControl(htmlWrite);

                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");

            }
        }


















        protected void btnReportPending_Click(object sender, EventArgs e)
        {
            ExcelExportSpecimenPending();
        }



        private void SpecimenPendingSample()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select a.dssid,a.study_id,a.lw_crf_3a_18 Random_ID,a.woman_nm,a.husband_nm,a.DOB,a.current_age_baby as Current_Age,a.treatment as ARM , (case when a.description!='' Then 'Infant Blood, Breast Milk, LW stool, LW Blood and Infant stool' when (a.description='' or a.description is null) Then 'Infant Blood' END) as description, (select  concat( IF(z.42_infant_blood!='','Infant Blood, ','' ), IF(z.42_infant_stool!='','Infant Stool, ','' ), IF(z.42_breast_milk!='','Breast Milk, ','' ),IF(z.42_lw_blood!='','LW Blood, ','' ), IF(z.42_lw_stool!='','LW Stool' ,'') ) from view_lab_invest_report as z where a.study_id = z.study_code and z.current_age_baby >40)  as Day42_SampleDone, (select  IF((z.description='Selected for Breast Milk, LW stool, LW Blood and Infant stool'), concat( IF((z.42_infant_blood='' or z.42_infant_blood is null),'Infant Blood, ','' ), IF((z.42_infant_stool='' or z.42_infant_stool is null),'Infant Stool, ','' ), IF((z.42_breast_milk='' or z.42_breast_milk is null),'Breast Milk, ','' ),IF((z.42_lw_blood='' or z.42_lw_blood is null),'LW Blood, ','' ), IF((z.42_lw_stool='' or z.42_lw_stool is null),'LW Stool' ,'')),    IF((z.42_infant_blood='' or z.42_infant_blood is null),'Infant Blood','')) from view_lab_invest_report as z where a.study_id = z.study_code and z.current_age_baby >40)  as Day42_SamplePending, (select  concat( IF(z.56_infant_blood!='','Infant Blood, ','' ), IF(z.56_infant_stool!='','Infant Stool, ','' ), IF(z.56_breast_milk!='','Breast Milk, ','' ),IF(z.56_lw_blood!='','LW Blood, ','' ), IF(z.56_lw_stool!='','LW Stool' ,'') ) from view_lab_invest_report as z where a.study_id = z.study_code and z.current_age_baby >56)  as Day56_SampleDone, (select  IF((z.description='Selected for Breast Milk, LW stool, LW Blood and Infant stool'), concat( IF((z.56_infant_blood='' or z.56_infant_blood is null),'Infant Blood, ','' ), IF((z.56_infant_stool='' or z.56_infant_stool is null),'Infant Stool, ','' ), IF((z.56_breast_milk='' or z.56_breast_milk is null),'Breast Milk, ','' ),IF((z.56_lw_blood='' or z.56_lw_blood is null),'LW Blood, ','' ), IF((z.56_lw_stool='' or z.56_lw_stool is null),'LW Stool' ,'')),    IF((z.56_infant_blood='' or z.56_infant_blood is null),'Infant Blood','')) from view_lab_invest_report as z where a.study_id = z.study_code and z.current_age_baby >56)  as Day56_SamplePending from view_lab_invest as a", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView5.DataSource = dt;
                        GridView5.DataBind();
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




        public void ExcelExportSpecimenPending()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Specimen Pending Report (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView5.AllowPaging = false;
                GridView5.CaptionAlign = TableCaptionAlign.Top;
                SpecimenPendingSample();
                for (int i = 0; i < GridView5.HeaderRow.Cells.Count; i++)
                {
                    GridView5.HeaderRow.Cells[i].Style.Add("font-size", "16px");
                    GridView5.HeaderRow.Cells[i].Style.Add("height", "80px");
                    GridView5.HeaderRow.Cells[i].Style.Add("background-color", "#00B894");
                    GridView5.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                //// Footer Style: 
                //GridView5.Rows[GridView5.Rows.Count - 1].Style.Add("font-size", "15px");
                //GridView5.Rows[GridView5.Rows.Count - 1].Font.Bold = true;

                GridView5.RenderControl(htmlWrite);

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
                TableCell cell14 = e.Row.Cells[14];
                cell14.BackColor = System.Drawing.Color.FromName("#bdc3c7");
            }
        }

        protected void Link_EditForm(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Role"]) == "Web_Admin" || Convert.ToString(Session["Role"]) == "Web_Standard")
            {
                string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
                string RandID = commandArgs[0];
                Response.Redirect("labinvestigationEdit.aspx?&RandID=" + RandID);
            }
            else 
            {
                showalert("Only Admin has rights to edit record!");
            }
        }










    }
}