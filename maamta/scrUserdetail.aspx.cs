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
    public partial class scrUserdetail : System.Web.UI.Page
    {
        // MySqlDataReader dreader;
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "Dashboard";
            if (!IsPostBack)
            {
                Session["Assis"] = null;
                Session["Form1_ID"] = null;
                if (Session["UentryUname"] == null)
                {
                    Response.Redirect("dashboard.aspx");
                }
                else
                    lbeStatus.Text = Convert.ToString(Session["UentryUname"]);
                lbeFdate.Text = Convert.ToString(Session["FirstEDate"]);
                lbeSdate.Text = Convert.ToString(Session["SecEDate"]);
                ShowData();
                txtdssid.Focus();
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lbeComplete.Text = "0";
            lbeIncomplete.Text = "0";
            lbeElg.Text = "0";
            lbeNotElg.Text = "0";
            ShowData();
            txtdssid.Focus();
        }

        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                //MySqlCommand cmd = new MySqlCommand("select * from dash_crf1 where (visit_date between '" + Convert.ToString(Session["FirstEDate"]) + "' and '" + Convert.ToString(Session["SecEDate"]) + "') and name='" + lbeStatus.Text + "' and dssid like '%" + txtdssid.Text + "%'", con);
                MySqlCommand cmd = new MySqlCommand("select * from dash_crf1 where (str_to_date(visit_date, '%d-%m-%Y') between str_to_date('" + Convert.ToString(Session["FirstEDate"]) + "', '%d-%m-%Y') and str_to_date('" + Convert.ToString(Session["SecEDate"]) + "', '%d-%m-%Y')) and name='" + lbeStatus.Text + "' and dssid like '%" + txtdssid.Text + "%'", con);

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

        protected void Link_MUAC(object sender, EventArgs e)
        {

            string val = ((LinkButton)sender).Text;
            if (val != "0")
            {
                string[] arg = new string[2];
                arg = ((LinkButton)sender).CommandArgument.ToString().Split(';');
                Session["Form1_ID"] = arg[0];
                Session["Assis"] = arg[1];
                Response.Redirect("ScrMUAC.aspx");
            }
        }


        protected void Link_Assis(object sender, EventArgs e)
        {
            string[] arg = new string[2];
            arg = ((LinkButton)sender).CommandArgument.ToString().Split(';');
            Session["Form1_ID"] = arg[0];
            Session["Assis"] = arg[1];
            Session["BackButton"] = "scrUserdetail";
            Response.Redirect("showcrf1byid.aspx");
        }


        Int32 totCom = 0;
        Int32 totInCom = 0;
        Int32 Elg = 0;
        Int32 NotElg = 0;

        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[8].Text == "1")
                {
                    totCom = totCom + 1;
                    lbeComplete.Text = totCom.ToString();
                }
                else
                {
                    totInCom = totInCom + 1;
                    lbeIncomplete.Text = totInCom.ToString();
                }
                TableCell cellElg = e.Row.Cells[10];
                if (e.Row.Cells[10].Text != "&nbsp;" && (Convert.ToDouble(e.Row.Cells[10].Text) < 24.0))
                {
                    Elg = Elg + 1;
                    lbeElg.Text = Elg.ToString();
                    cellElg.BackColor = System.Drawing.Color.FromName("#C8F7C5");
                }
                if (e.Row.Cells[10].Text != "&nbsp;" && (Convert.ToDouble(e.Row.Cells[10].Text) >= 24))
                {
                    NotElg = NotElg + 1;
                    lbeNotElg.Text = NotElg.ToString();
                    cellElg.BackColor = System.Drawing.Color.FromName("#ffe6e7");
                }


                //For Visit Status:

                //TableCell cell = e.Row.Cells[8];
                //cell.BackColor = System.Drawing.Color.FromName("#dff9fb");
                if (e.Row.Cells[8].Text == "1")
                {
                    e.Row.Cells[8].Text = "Complete";
                }
                else if (e.Row.Cells[8].Text == "2")
                {
                    e.Row.Cells[8].Text = "Not at home";
                }
                else if (e.Row.Cells[8].Text == "3")
                {
                    e.Row.Cells[8].Text = "Refused";
                }
                else if (e.Row.Cells[8].Text == "4")
                {
                    e.Row.Cells[8].Text = "Wrong Information";
                }
                else if (e.Row.Cells[8].Text == "5")
                {
                    e.Row.Cells[8].Text = "Wrong Info. DSS";
                }
                else if (e.Row.Cells[8].Text == "6")
                {
                    e.Row.Cells[8].Text = "Woman was never found Pregnant";
                }
                else if (e.Row.Cells[8].Text == "7")
                {
                    e.Row.Cells[8].Text = "Woman was preg. but recently delivered";
                }
                else if (e.Row.Cells[8].Text == "8")
                {
                    e.Row.Cells[8].Text = "Shifted out of DSS";
                }
                else if (e.Row.Cells[8].Text == "9")
                {
                    e.Row.Cells[8].Text = "PW died";
                }
                else if (e.Row.Cells[8].Text == "10")
                {
                    e.Row.Cells[8].Text = "Visitor";
                }

            }
        }


    }
}