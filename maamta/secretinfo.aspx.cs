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
    public partial class infoNineMonths : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "secretinfo";
                AcceptReferralColor();
                DateFormatPageLoad();
                ShowAcceptReferral();
                txtdssidAcceptReferral.Focus();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }






        protected void btnChildAge_Click(object sender, EventArgs e)
        {
            ChildAge9MonthColor();
            //ShowChildAge();
        }

        protected void btnMissedFups_Click(object sender, EventArgs e)
        {
            MissedFupsColor();
            ddMissedFups.Focus();
        }

        protected void btnAcceptReferral_Click(object sender, EventArgs e)
        {
            AcceptReferralColor();
            DateFormatPageLoad();
            ShowAcceptReferral();
            txtdssidAcceptReferral.Focus();
        }









        private void ChildAge9MonthColor()
        {
            btnChildAge.Style.Add("color", "white");
            btnChildAge.Style.Add("background-color", "#55efc4");

            btnAcceptReferral.Style.Add("color", "#adadad");
            btnAcceptReferral.Style.Add("background-color", "#e0e0e0");
            btnMissedFups.Style.Add("color", "#adadad");
            btnMissedFups.Style.Add("background-color", "#e0e0e0");


            divChildAge.Visible = true;
            divMissedFups.Visible = false;
            divAcceptReferral.Visible = false;
        }



        private void MissedFupsColor()
        {
            btnMissedFups.Style.Add("color", "white");
            btnMissedFups.Style.Add("background-color", "#55efc4");

            btnChildAge.Style.Add("color", "#adadad");
            btnChildAge.Style.Add("background-color", "#e0e0e0");
            btnAcceptReferral.Style.Add("color", "#adadad");
            btnAcceptReferral.Style.Add("background-color", "#e0e0e0");

            divMissedFups.Visible = true;
            divChildAge.Visible = false;
            divAcceptReferral.Visible = false;
        }


        private void AcceptReferralColor()
        {
            btnAcceptReferral.Style.Add("color", "white");
            btnAcceptReferral.Style.Add("background-color", "#55efc4");

            btnChildAge.Style.Add("color", "#adadad");
            btnChildAge.Style.Add("background-color", "#e0e0e0");
            btnMissedFups.Style.Add("color", "#adadad");
            btnMissedFups.Style.Add("background-color", "#e0e0e0");

            divAcceptReferral.Visible = true;
            divChildAge.Visible = false;
            divMissedFups.Visible = false;
        }














        protected void GridView1MissedFups_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1MissedFups.PageIndex = e.NewPageIndex;
            ShowMissedFups();
        }

        protected void btnSearchMissedFups_Click(object sender, EventArgs e)
        {
            ShowMissedFups();
        }


        private void ShowMissedFups()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                if (ddMissedFups.SelectedValue == "0")
                {
                    showalert("Please Select Followups Status");
                    ddMissedFups.Focus();
                }
                else if (ddMissedFups.SelectedValue == "NB_Missed_Ex_Sunday")
                {
                    cmd = new MySqlCommand("select a.*,Datediff(str_to_date(end_date, '%d-%m-%Y'),str_to_date(date, '%d-%m-%Y')) as day_diff from view_followups4a as a where a.status='3' 	and  (str_to_date(a.end_date, '%d-%m-%Y') < CURDATE())	  and 		not exists (select z.id  from view_followups4a as z where z.status='3' and  (str_to_date(z.end_date, '%d-%m-%Y') < CURDATE())  and Datediff(str_to_date(z.end_date, '%d-%m-%Y'),str_to_date(z.date, '%d-%m-%Y')) ='0' and z.Day='Sunday' and z.id=a.id) order by a.study_code,str_to_date(a.date, '%d-%m-%Y')", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1MissedFups.DataSource = dt;
                            GridView1MissedFups.DataBind();
                            con.Close();
                        }
                    }
                }
                else if (ddMissedFups.SelectedValue == "NB_Missed_Inc_Sunday")
                {
                    cmd = new MySqlCommand("select a.*,Datediff(str_to_date(end_date, '%d-%m-%Y'),str_to_date(date, '%d-%m-%Y')) as day_diff from view_followups4a as a where a.status='3' 	and  (str_to_date(a.end_date, '%d-%m-%Y') < CURDATE())	  order by a.study_code,str_to_date(a.date, '%d-%m-%Y')", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1MissedFups.DataSource = dt;
                            GridView1MissedFups.DataBind();
                            con.Close();
                        }
                    }
                }
                else if (ddMissedFups.SelectedValue == "FFQ_Missed")
                {
                    cmd = new MySqlCommand("select *,Datediff(str_to_date(end_date, '%d-%m-%Y'),str_to_date(date, '%d-%m-%Y')) as day_diff from view_followups5b where status='3' and (str_to_date(end_date, '%d-%m-%Y') < CURDATE()) order by study_code,str_to_date(date, '%d-%m-%Y')", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1MissedFups.DataSource = dt;
                            GridView1MissedFups.DataBind();
                            con.Close();
                        }
                    }
                }
                else if (ddMissedFups.SelectedValue == "Anthro_Missed")
                {
                    cmd = new MySqlCommand("select *, Datediff(str_to_date(end_date, '%d-%m-%Y'),str_to_date(date, '%d-%m-%Y')) as day_diff from view_followups6 where status='3' and (str_to_date(end_date, '%d-%m-%Y') < CURDATE()) order by study_code,str_to_date(date, '%d-%m-%Y')", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1MissedFups.DataSource = dt;
                            GridView1MissedFups.DataBind();
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




        protected void btnExportMissedFups_Click(object sender, EventArgs e)
        {
            ShowMissedFups();
            if (GridView1MissedFups.Rows.Count != 0)
            {
                ExcelExportMissedFups();
            }
        }


        public void MissedFupsExcelExportMessage()
        {
            if (ddMissedFups.SelectedValue != "0")
            {
                GridView2MissedFups.Caption = "<h3/><b>" + ddMissedFups.SelectedItem.Text;
            }
        }



        private void ExportdataMissedFups()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                if (ddMissedFups.SelectedValue == "NB_Missed_Ex_Sunday")
                {
                    cmd = new MySqlCommand("select a.*,Datediff(str_to_date(end_date, '%d-%m-%Y'),str_to_date(date, '%d-%m-%Y')) as day_diff from view_followups4a as a where a.status='3' 	and  (str_to_date(a.end_date, '%d-%m-%Y') < CURDATE())	  and 		not exists (select z.id  from view_followups4a as z where z.status='3' and  (str_to_date(z.end_date, '%d-%m-%Y') < CURDATE())  and Datediff(str_to_date(z.end_date, '%d-%m-%Y'),str_to_date(z.date, '%d-%m-%Y')) ='0' and z.Day='Sunday' and z.id=a.id) order by a.study_code,str_to_date(a.date, '%d-%m-%Y')", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView2MissedFups.DataSource = dt;
                            GridView2MissedFups.DataBind();
                            con.Close();
                        }
                    }
                }
                else if (ddMissedFups.SelectedValue == "NB_Missed_Inc_Sunday")
                {
                    cmd = new MySqlCommand("select a.*,Datediff(str_to_date(end_date, '%d-%m-%Y'),str_to_date(date, '%d-%m-%Y')) as day_diff from view_followups4a as a where a.status='3' 	and  (str_to_date(a.end_date, '%d-%m-%Y') < CURDATE())	  order by a.study_code,str_to_date(a.date, '%d-%m-%Y')", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView2MissedFups.DataSource = dt;
                            GridView2MissedFups.DataBind();
                            con.Close();
                        }
                    }
                }
                else if (ddMissedFups.SelectedValue == "FFQ_Missed")
                {
                    cmd = new MySqlCommand("select *,Datediff(str_to_date(end_date, '%d-%m-%Y'),str_to_date(date, '%d-%m-%Y')) as day_diff from view_followups5b where status='3' and (str_to_date(end_date, '%d-%m-%Y') < CURDATE()) order by study_code,str_to_date(date, '%d-%m-%Y')", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView2MissedFups.DataSource = dt;
                            GridView2MissedFups.DataBind();
                            con.Close();
                        }
                    }
                }
                else if (ddMissedFups.SelectedValue == "Anthro_Missed")
                {
                    cmd = new MySqlCommand("select *,Datediff(str_to_date(end_date, '%d-%m-%Y'),str_to_date(date, '%d-%m-%Y')) as day_diff from view_followups6 where status='3' and (str_to_date(end_date, '%d-%m-%Y') < CURDATE()) order by study_code,str_to_date(date, '%d-%m-%Y')", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView2MissedFups.DataSource = dt;
                            GridView2MissedFups.DataBind();
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



        public void ExcelExportMissedFups()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=FollowupsMissed (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2MissedFups.AllowPaging = false;
                MissedFupsExcelExportMessage();
                GridView2MissedFups.CaptionAlign = TableCaptionAlign.Top;

                ExportdataMissedFups();
                for (int i = 0; i < GridView2MissedFups.HeaderRow.Cells.Count; i++)
                {
                    GridView2MissedFups.HeaderRow.Cells[i].Style.Add("background-color", "#e17055");
                    GridView2MissedFups.HeaderRow.Cells[i].Style.Add("Color", "white");
                    GridView2MissedFups.HeaderRow.Cells[i].Style.Add("font-size", "15px");
                    GridView2MissedFups.HeaderRow.Cells[i].Style.Add("height", "30px");
                }
                GridView2MissedFups.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");
            }
        }





























        private void DateFormatPageLoad()
        {
            txtAcceptReferralDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtAcceptReferralDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtAcceptReferralDate.Attributes.Add("readonly", "readonly");
            txtAcceptReferralDate1.Attributes.Add("readonly", "readonly");
            txtAcceptReferralDate.Enabled = true;
            txtAcceptReferralDate1.Enabled = true;
            chkAcceptReferral.Checked = false;
        }


        protected void btnSearchAcceptReferral_Click(object sender, EventArgs e)
        {
            if (chkAcceptReferral.Checked == false && DateTime.ParseExact(txtAcceptReferralDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtAcceptReferralDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
            {
                showalert("First Date should be Less or Equal than Second Date");
                txtAcceptReferralDate.Focus();
            }
            else
            {
                ShowAcceptReferral();
                txtdssidAcceptReferral.Focus();
            }
        }


        protected void chkAcceptReferral_CheckedChanged(object sender, EventArgs e)
        {
            txtAcceptReferralDate.Enabled = !chkAcceptReferral.Checked;
            txtAcceptReferralDate1.Enabled = !chkAcceptReferral.Checked;
        }

        protected void GridAcceptReferral_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridAcceptReferral.PageIndex = e.NewPageIndex;
            ShowAcceptReferral();
        }


        private void ShowAcceptReferral()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (chkAcceptReferral.Checked == false)
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select study_code,followup_num,lw_crf4b_2 as DOV, dssid,q10 as woman_nm, q11 as husband_nm from view_crf4b where lw_crf4b_54='1' and  dssid like '" + txtdssidAcceptReferral.Text + "%' and (str_to_date(lw_crf4b_2, '%d-%m-%Y') between str_to_date('" + txtAcceptReferralDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtAcceptReferralDate1.Text + "', '%d-%m-%Y')) order by study_code,followup_num;", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridAcceptReferral.DataSource = dt;
                            GridAcceptReferral.DataBind();
                            con.Close();
                        }
                    }
                }
                else
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select study_code,followup_num,lw_crf4b_2 as DOV, dssid,q10 as woman_nm, q11 as husband_nm from view_crf4b where lw_crf4b_54='1' and  dssid like '" + txtdssidAcceptReferral.Text + "%'  order by study_code,followup_num; ", con);
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridAcceptReferral.DataSource = dt;
                            GridAcceptReferral.DataBind();
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































        protected void btnSearchChildAge_Click(object sender, EventArgs e)
        {
            ShowChildAge();
        }

        private void ShowChildAge()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                if (ddChildAge.SelectedValue == "0")
                {
                    showalert("Please Select Child Age");
                    ddChildAge.Focus();
                }
                else if (ddChildAge.SelectedValue == "Age_9M")
                {
                    cmd = new MySqlCommand("select a.study_id,a.dssid,a.lw_crf1_09 as woman_nm, a.lw_crf1_10 as husband_nm, a.lw_crf_3a_2 as date_enrollment,b.lw_crf2_21 as dob,DATE_FORMAT((str_to_date(b.lw_crf2_21, '%d-%m-%Y') + INTERVAL 270 DAY),'%d-%b-%Y')  as 9_Months,       DATE_FORMAT((str_to_date(b.lw_crf2_21, '%d-%m-%Y') + INTERVAL 365 DAY),'%d-%b-%Y')  as 12_Months        from view_crf3a as a left join view_crf2 as b on a.assis_id=b.assis_id  where DATEDIFF(CURDATE(), str_to_date(b.lw_crf2_21, '%d-%m-%Y'))>=263       	        	and a.study_id not in (select z.study_code from view_crf6 as z where z.followup_no='7' )          order by str_to_date(b.lw_crf2_21, '%d-%m-%Y'), study_id", con);

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
                else if (ddChildAge.SelectedValue == "Age_12M")
                {

                    cmd = new MySqlCommand("select a.study_id,a.dssid,a.lw_crf1_09 as woman_nm, a.lw_crf1_10 as husband_nm, a.lw_crf_3a_2 as date_enrollment,b.lw_crf2_21 as dob,DATE_FORMAT((str_to_date(b.lw_crf2_21, '%d-%m-%Y') + INTERVAL 270 DAY),'%d-%b-%Y')  as 9_Months,       DATE_FORMAT((str_to_date(b.lw_crf2_21, '%d-%m-%Y') + INTERVAL 365 DAY),'%d-%b-%Y')  as 12_Months        from view_crf3a as a left join view_crf2 as b on a.assis_id=b.assis_id  where DATEDIFF(CURDATE(), str_to_date(b.lw_crf2_21, '%d-%m-%Y'))>=358       	        	and a.study_id not in (select z.study_code from view_crf6 as z where z.followup_no='8' )           order by str_to_date(b.lw_crf2_21, '%d-%m-%Y'), study_id", con);

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
            ShowChildAge();
        }





        protected void btnExport_Click(object sender, EventArgs e)
        {
            ShowChildAge();
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
        }


        public void ExcelExportMessage()
        {
            GridView2.Caption = "Pending Followups<h3/><b>" + ddChildAge.SelectedItem.Text;
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

                if (ddChildAge.SelectedValue == "Age_9M")
                {

                    cmd = new MySqlCommand("select a.study_id,a.dssid,a.lw_crf1_09 as woman_nm, a.lw_crf1_10 as husband_nm, a.lw_crf_3a_2 as date_enrollment,b.lw_crf2_21 as dob,DATE_FORMAT((str_to_date(b.lw_crf2_21, '%d-%m-%Y') + INTERVAL 270 DAY),'%d-%b-%Y')  as 9_Months,       DATE_FORMAT((str_to_date(b.lw_crf2_21, '%d-%m-%Y') + INTERVAL 365 DAY),'%d-%b-%Y')  as 12_Months        from view_crf3a as a left join view_crf2 as b on a.assis_id=b.assis_id  where DATEDIFF(CURDATE(), str_to_date(b.lw_crf2_21, '%d-%m-%Y'))>=263            	and a.study_id not in (select z.study_code from view_crf6 as z where z.followup_no='7' )         order by str_to_date(b.lw_crf2_21, '%d-%m-%Y'), study_id", con);

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
                else if (ddChildAge.SelectedValue == "Age_12M")
                {

                    cmd = new MySqlCommand("select a.study_id,a.dssid,a.lw_crf1_09 as woman_nm, a.lw_crf1_10 as husband_nm, a.lw_crf_3a_2 as date_enrollment,b.lw_crf2_21 as dob,DATE_FORMAT((str_to_date(b.lw_crf2_21, '%d-%m-%Y') + INTERVAL 270 DAY),'%d-%b-%Y')  as 9_Months,       DATE_FORMAT((str_to_date(b.lw_crf2_21, '%d-%m-%Y') + INTERVAL 365 DAY),'%d-%b-%Y')  as 12_Months        from view_crf3a as a left join view_crf2 as b on a.assis_id=b.assis_id  where DATEDIFF(CURDATE(), str_to_date(b.lw_crf2_21, '%d-%m-%Y'))>=358           	        	and a.study_id not in (select z.study_code from view_crf6 as z where z.followup_no='8' )           order by str_to_date(b.lw_crf2_21, '%d-%m-%Y'), study_id", con);

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
                Response.AddHeader("content-disposition", "attachment;filename=Child Greater than 9 Month(" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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


    }
}