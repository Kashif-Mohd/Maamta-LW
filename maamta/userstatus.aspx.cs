using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace maamta
{
    public partial class userstatus : System.Web.UI.Page
    {

        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        SqlDataReader dreader;
        string Errorr;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                Session["WebForm"] = "Dashboard";
                lbeUname.Text = Convert.ToString(Session["CPusername"]);
                if (Session["Role"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                //ADMINUSER STATUS RIGHTS: 
                else if (Convert.ToString(Session["CPusername"]) == "adminuser" || Convert.ToString(Session["CPusername"]) == "ADMINUSER")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('YOU DO NOT HAVE RIGHTS TO CHECK DIO STATUS!');window.location.href='dashboard.aspx';", true);
                }
                else
                {
                    DIOnameDrop();
                    d1.Value = DateTime.Today.ToString("dd");
                    m1.Value = DateTime.Today.ToString("MM");
                    y1.Value = DateTime.Today.ToString("yyyy");

                    string DateMonth = DateTime.Now.AddDays(1).ToString("dd/MM");
                    string Yearss = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");

                    string firstTwo = DateMonth.Substring(0, 2);
                    string lastTwo = DateMonth.Substring(DateMonth.Length - 2);
                    string last4 = Yearss.Substring(Yearss.Length - 4);

                    d2.Value = firstTwo;
                    m2.Value = lastTwo;
                    y2.Value = last4;

                    DropDownList1.Focus();
                }
            }
        }



        protected void btnTotalStatus_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }

        protected void btnDIOstatus_Click(object sender, EventArgs e)
        {
            Response.Redirect("userstatus.aspx");
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string Date1 = y1.Value + "-" + m1.Value + "-" + d1.Value;
            string Date2 = y2.Value + "-" + m2.Value + "-" + d2.Value;

            DateTime Test;

            if (DropDownList1.Text == "Select DIO Name")
            {
                lbeEntryUser.Text = "";
                DropDownList1.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Please Select DIO Name!')", true);
            }
            else if (DateTime.TryParseExact(Date1, "yyyy-MM-dd", null, DateTimeStyles.None, out Test) == false)
            {
                lbeEntryUser.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Date From is Invalid !')", true);
                d1.Focus();
            }
            else if (DateTime.TryParseExact(Date2, "yyyy-MM-dd", null, DateTimeStyles.None, out Test) == false)
            {
                lbeEntryUser.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Date To is Invalid !')", true);
                d2.Focus();
            }
            else if (DateCheck() == false)
            {
                lbeEntryUser.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('1st Date (Date From) is greater or Equal than 2nd Date!')", true);
                d1.Focus();
            }
            else
            {
                Errorr = "";
                Search();
                DropDownList1.Focus();
            }
        }


        public void Search()
        {
            lbeEntryUser.Text = "Entry status of "+ DropDownList1.Text +", &nbsp date from &nbsp(" + d1.Value + "-" + m1.Value + "-" + y1.Value + ")&nbsp To &nbsp(" + d2.Value + "-" + m2.Value + "-" + y2.Value + ")";
            ShowLogData();

            if (Errorr == "")
            {
                ShowEntry1Data();
                ShowEntry2Data();
                Sum();
            }
        }



        private void ShowLogData()
        {
            string Date1 = d1.Value + "/" + m1.Value + "/" + y1.Value;
            string Date2 = d2.Value + "/" + m2.Value + "/" + y2.Value;

            try
            {
                SqlConnection con = new SqlConnection(constr);

                //con.Open();
                //SqlCommand cmd = new SqlCommand("SELECT count(Crf_No) as Total FROM form_logged where CRF_No='1' and (logged_date  between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_name='" + DropDownList1.Text + "'", con);
                //{
                //    dreader = cmd.ExecuteReader();

                //    if (dreader.Read())
                //    {
                //lbeLogCrf1.Text = dreader["Total"].ToString();
                lbeLogCrf1.Text = "0";
                lbeLogCrf1.Attributes.Add("style", "color:#BFBFBF;");
                //        if (lbeLogCrf1.Text != "0")
                //        {               
                //          lbeLogCrf1.Attributes.Add("style", "color:#2574A9;");
                //        }
                //    }
                //    con.Close();
                //}

                con.Open();
                SqlCommand cmd1a = new SqlCommand("SELECT count(Crf_No) as Total FROM form_logged where CRF_No='1a' and (logged_date  between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_name='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd1a.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbeLogCrf1a.Text = dreader["Total"].ToString();
                        lbeLogCrf1a.Attributes.Add("style", "color:#BFBFBF;");

                        if (lbeLogCrf1a.Text != "0")
                        {
                            lbeLogCrf1a.Attributes.Add("style", "color:#2574A9;");
                        }
                    }
                    con.Close();
                }

                con.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT count(Crf_No) as Total FROM form_logged where CRF_No='2' and (logged_date  between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_name='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd2.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbeLogCrf2.Text = dreader["Total"].ToString();
                        lbeLogCrf2.Attributes.Add("style", "color:#BFBFBF;");

                        if (lbeLogCrf2.Text != "0")
                        {
                            lbeLogCrf2.Attributes.Add("style", "color:#2574A9;");
                        }
                    }
                    con.Close();
                }
                con.Open();
                SqlCommand cmd3 = new SqlCommand("SELECT count(Crf_No) as Total FROM form_logged where CRF_No='3' and (logged_date  between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_name='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd3.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbeLogCrf3.Text = dreader["Total"].ToString();
                        lbeLogCrf3.Attributes.Add("style", "color:#BFBFBF;");

                        if (lbeLogCrf3.Text != "0")
                        {
                            lbeLogCrf3.Attributes.Add("style", "color:#2574A9;");
                        }
                    }
                    con.Close();
                }
                con.Open();
                SqlCommand cmd4 = new SqlCommand("SELECT count(Crf_No) as Total FROM form_logged where CRF_No='4' and (logged_date  between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_name='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd4.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbeLogCrf4.Text = dreader["Total"].ToString();
                        lbeLogCrf4.Attributes.Add("style", "color:#BFBFBF;");

                        if (lbeLogCrf4.Text != "0")
                        {
                            lbeLogCrf4.Attributes.Add("style", "color:#2574A9;");
                        }
                    }
                    con.Close();
                }
                con.Open();
                SqlCommand cmd5 = new SqlCommand("SELECT count(Crf_No) as Total FROM form_logged where CRF_No='5' and (logged_date  between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_name='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd5.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbeLogCrf5.Text = dreader["Total"].ToString();
                        lbeLogCrf5.Attributes.Add("style", "color:#BFBFBF;");
                        if (lbeLogCrf5.Text != "0")
                        {
                            lbeLogCrf5.Attributes.Add("style", "color:#2574A9;");
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('" + ex.Message + "')", true);
                //Response.Write("<script>window.location.href='WebForm2.aspx';</script>");
                Errorr = "Network Disconnect";
                clearlbe();
            }
        }




        private void ShowEntry1Data()
        {
            string Date1 = d1.Value + "/" + m1.Value + "/" + y1.Value;
            string Date2 = d2.Value + "/" + m2.Value + "/" + y2.Value;

            try
            {
                SqlConnection con = new SqlConnection(constr);

                //con.Open();
                //SqlCommand cmd = new SqlCommand("select count(study_id) as Total from crf1 where (entry_dt between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_nm='" + DropDownList1.Text + "'", con);
                //{
                //    dreader = cmd.ExecuteReader();

                //    if (dreader.Read())
                //    {
                //        lbe1Crf1.Text = dreader["Total"].ToString();
                lbe1Crf1.Text = "0";
                lbe1Crf1.Attributes.Add("style", "color:#BFBFBF;");

                //        if (lbe1Crf1.Text != "0")
                //        {              
                //lbe1Crf1.Attributes.Add("style", "color:#2C3E50;");
                //        }
                //    }
                //    con.Close();
                //}

                con.Open();
                SqlCommand cmd1a = new SqlCommand("select count(study_id) as Total from crf1a where (entry_dt between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_nm='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd1a.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbe1Crf1a.Text = dreader["Total"].ToString();
                        lbe1Crf1a.Attributes.Add("style", "color:#BFBFBF;");

                        if (lbe1Crf1a.Text != "0")
                        {
                            lbe1Crf1a.Attributes.Add("style", "color:#2C3E50;");
                        }
                    }
                    con.Close();
                }

                con.Open();
                SqlCommand cmd2 = new SqlCommand("select count(study_id) as Total from crf2 where (entry_dt between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_nm='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd2.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbe1Crf2.Text = dreader["Total"].ToString();
                        lbe1Crf2.Attributes.Add("style", "color:#BFBFBF;");

                        if (lbe1Crf2.Text != "0")
                        {
                            lbe1Crf2.Attributes.Add("style", "color:#2C3E50;");
                        }
                    }
                    con.Close();
                }
                con.Open();
                SqlCommand cmd3 = new SqlCommand("select count(study_id)  as Total from crf3 where (entry_dt between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_nm='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd3.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbe1Crf3.Text = dreader["Total"].ToString();
                        lbe1Crf3.Attributes.Add("style", "color:#BFBFBF;");

                        if (lbe1Crf3.Text != "0")
                        {
                            lbe1Crf3.Attributes.Add("style", "color:#2C3E50;");
                        }
                    }
                    con.Close();
                }
                con.Open();
                SqlCommand cmd4 = new SqlCommand("select count(study_id)  as Total from crf4 where (entry_dt between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_nm='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd4.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbe1Crf4.Text = dreader["Total"].ToString();
                        lbe1Crf4.Attributes.Add("style", "color:#BFBFBF;");

                        if (lbe1Crf4.Text != "0")
                        {
                            lbe1Crf4.Attributes.Add("style", "color:#2C3E50;");
                        }
                    }
                    con.Close();
                }
                con.Open();
                SqlCommand cmd5 = new SqlCommand("select count(study_id)  as Total from crf5 where (entry_dt between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_nm='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd5.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbe1Crf5.Text = dreader["Total"].ToString();
                        lbe1Crf5.Attributes.Add("style", "color:#BFBFBF;");
                        if (lbe1Crf5.Text != "0")
                        {
                            lbe1Crf5.Attributes.Add("style", "color:#2C3E50;");
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
        }


        private void ShowEntry2Data()
        {
            string Date1 = d1.Value + "/" + m1.Value + "/" + y1.Value;
            string Date2 = d2.Value + "/" + m2.Value + "/" + y2.Value;

            try
            {
                SqlConnection con = new SqlConnection(constr);

                //con.Open();
                //SqlCommand cmd = new SqlCommand("select count(study_id)  as Total from secondcrf1 where (entry_dt between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_nm='" + DropDownList1.Text + "'", con);
                //{
                //    dreader = cmd.ExecuteReader();

                //    if (dreader.Read())
                //    {
                //        lbe2Crf1.Text = dreader["Total"].ToString();
                lbe2Crf1.Text = "0";
                lbe2Crf1.Attributes.Add("style", "color:#BFBFBF;");

                //        if (lbe2Crf1.Text != "0")
                //        {                
                //lbe2Crf1.Attributes.Add("style", "color:#2C3E50;");
                //        }
                //    }
                //    con.Close();
                //}

                con.Open();
                SqlCommand cmd1a = new SqlCommand("select count(study_id)  as Total from secondcrf1a where (entry_dt between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_nm='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd1a.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbe2Crf1a.Text = dreader["Total"].ToString();
                        lbe2Crf1a.Attributes.Add("style", "color:#BFBFBF;");

                        if (lbe2Crf1a.Text != "0")
                        {
                            lbe2Crf1a.Attributes.Add("style", "color:#2C3E50;");
                        }
                    }
                    con.Close();
                }

                con.Open();
                SqlCommand cmd2 = new SqlCommand("select count(study_id)  as Total from secondcrf2 where (entry_dt between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_nm='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd2.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbe2Crf2.Text = dreader["Total"].ToString();
                        lbe2Crf2.Attributes.Add("style", "color:#BFBFBF;");

                        if (lbe2Crf2.Text != "0")
                        {
                            lbe2Crf2.Attributes.Add("style", "color:#2C3E50;");
                        }
                    }
                    con.Close();
                }
                con.Open();
                SqlCommand cmd3 = new SqlCommand("select count(study_id)  as Total from secondcrf3 where (entry_dt between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_nm='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd3.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbe2Crf3.Text = dreader["Total"].ToString();
                        lbe2Crf3.Attributes.Add("style", "color:#BFBFBF;");

                        if (lbe2Crf3.Text != "0")
                        {
                            lbe2Crf3.Attributes.Add("style", "color:#2C3E50;");
                        }
                    }
                    con.Close();
                }
                con.Open();
                SqlCommand cmd4 = new SqlCommand("select count(study_id)  as Total from secondcrf4 where (entry_dt between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_nm='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd4.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbe2Crf4.Text = dreader["Total"].ToString();
                        lbe2Crf4.Attributes.Add("style", "color:#BFBFBF;");

                        if (lbe2Crf4.Text != "0")
                        {
                            lbe2Crf4.Attributes.Add("style", "color:#2C3E50;");
                        }
                    }
                    con.Close();
                }
                con.Open();
                SqlCommand cmd5 = new SqlCommand("select count(study_id)  as Total from secondcrf5 where (entry_dt between CONVERT(datetime,'" + Date1 + "') AND CONVERT(datetime,'" + Date2 + "')) and dio_nm='" + DropDownList1.Text + "'", con);
                {
                    dreader = cmd5.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbe2Crf5.Text = dreader["Total"].ToString();
                        lbe2Crf5.Attributes.Add("style", "color:#BFBFBF;");
                        if (lbe2Crf5.Text != "0")
                        {
                            lbe2Crf5.Attributes.Add("style", "color:#2C3E50;");
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
        }




        public bool DateCheck()
        {
            DateTime dtDate1 = DateTime.Parse(y1.Value + "-" + m1.Value + "-" + d1.Value);
            DateTime dtDate2 = DateTime.Parse(y2.Value + "-" + m2.Value + "-" + d2.Value);
            TimeSpan diff = dtDate1.Subtract(dtDate2);

            if (diff.Days >= 0)
            {
                return false;
            }
            return true;
        }


        public void Sum()
        {
            lbeTotalCrf1.Text = Convert.ToString(Convert.ToInt32(lbe1Crf1.Text) + Convert.ToInt32(lbe2Crf1.Text));
            lbeTotalCrf1a.Text = Convert.ToString(Convert.ToInt32(lbe1Crf1a.Text) + Convert.ToInt32(lbe2Crf1a.Text));

            lbeTotalCrf2.Text = Convert.ToString(Convert.ToInt32(lbe1Crf2.Text) + Convert.ToInt32(lbe2Crf2.Text));
            lbeTotalCrf3.Text = Convert.ToString(Convert.ToInt32(lbe1Crf3.Text) + Convert.ToInt32(lbe2Crf3.Text));
            lbeTotalCrf4.Text = Convert.ToString(Convert.ToInt32(lbe1Crf4.Text) + Convert.ToInt32(lbe2Crf4.Text));
            lbeTotalCrf5.Text = Convert.ToString(Convert.ToInt32(lbe1Crf5.Text) + Convert.ToInt32(lbe2Crf5.Text));


            lbeLogTotal.Text = Convert.ToString(Convert.ToInt32(lbeLogCrf1.Text) + Convert.ToInt32(lbeLogCrf1a.Text) + Convert.ToInt32(lbeLogCrf2.Text) + Convert.ToInt32(lbeLogCrf3.Text) + Convert.ToInt32(lbeLogCrf4.Text) + Convert.ToInt32(lbeLogCrf5.Text));
            lbe1Total.Text = Convert.ToString(Convert.ToInt32(lbe1Crf1.Text) + Convert.ToInt32(lbe1Crf1a.Text) + Convert.ToInt32(lbe1Crf2.Text) + Convert.ToInt32(lbe1Crf3.Text) + Convert.ToInt32(lbe1Crf4.Text) + Convert.ToInt32(lbe1Crf5.Text));
            lbe2Total.Text = Convert.ToString(Convert.ToInt32(lbe2Crf1.Text) + Convert.ToInt32(lbe2Crf1a.Text) + Convert.ToInt32(lbe2Crf2.Text) + Convert.ToInt32(lbe2Crf3.Text) + Convert.ToInt32(lbe2Crf4.Text) + Convert.ToInt32(lbe2Crf5.Text));

            lbeGrandTotal.Text = Convert.ToString(Convert.ToInt32(lbe1Total.Text) + Convert.ToInt32(lbe2Total.Text));
        }



        public void clearlbe()
        {
            lbeLogCrf1.Text = "-";
            lbeLogCrf1a.Text = "-";
            lbeLogCrf2.Text = "-";
            lbeLogCrf3.Text = "-";
            lbeLogCrf4.Text = "-";
            lbeLogCrf5.Text = "-";

            lbeLogCrf1.Attributes.Add("style", "color:gray;");
            lbeLogCrf1a.Attributes.Add("style", "color:gray;");
            lbeLogCrf2.Attributes.Add("style", "color:gray;");
            lbeLogCrf3.Attributes.Add("style", "color:gray;");
            lbeLogCrf4.Attributes.Add("style", "color:gray;");
            lbeLogCrf5.Attributes.Add("style", "color:gray;");


            lbe1Crf1.Attributes.Add("style", "color:gray;");
            lbe1Crf1a.Attributes.Add("style", "color:gray;");
            lbe1Crf2.Attributes.Add("style", "color:gray;");
            lbe1Crf3.Attributes.Add("style", "color:gray;");
            lbe1Crf4.Attributes.Add("style", "color:gray;");
            lbe1Crf5.Attributes.Add("style", "color:gray;");

            lbe2Crf1.Attributes.Add("style", "color:gray;");
            lbe2Crf1a.Attributes.Add("style", "color:gray;");
            lbe2Crf2.Attributes.Add("style", "color:gray;");
            lbe2Crf3.Attributes.Add("style", "color:gray;");
            lbe2Crf4.Attributes.Add("style", "color:gray;");
            lbe2Crf5.Attributes.Add("style", "color:gray;");


            lbe1Crf1.Text = "-";
            lbe1Crf1a.Text = "-";
            lbe1Crf2.Text = "-";
            lbe1Crf3.Text = "-";
            lbe1Crf4.Text = "-";
            lbe1Crf5.Text = "-";


            lbe2Crf1.Text = "-";
            lbe2Crf1a.Text = "-";
            lbe2Crf2.Text = "-";
            lbe2Crf3.Text = "-";
            lbe2Crf4.Text = "-";
            lbe2Crf5.Text = "-";

            lbeTotalCrf1.Text = "-";
            lbeTotalCrf1a.Text = "-";
            lbeTotalCrf2.Text = "-";
            lbeTotalCrf3.Text = "-";
            lbeTotalCrf4.Text = "-";
            lbeTotalCrf5.Text = "-";

            lbeLogTotal.Text = "-";
            lbe1Total.Text = "-";
            lbe2Total.Text = "-";
            lbeGrandTotal.Text = "-";
        }


        public void DIOnameDrop()
        {
            if (DropDownList1.SelectedItem == null)
            {

                try
                {
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT username from users where role='local' order by username", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    DropDownList1.DataSource = ds.Tables[0];
                    DropDownList1.DataTextField = ds.Tables[0].Columns["username"].ToString();
                    DropDownList1.DataBind();
                    ListItem li = new ListItem("Select DIO Name");
                    DropDownList1.Items.Insert(0, li);
                }


                catch (Exception ex)
                {
                    Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");

                }
            }
        }
    }
}