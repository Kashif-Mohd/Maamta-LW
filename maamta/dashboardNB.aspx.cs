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
    public partial class dashboardNB : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "DashboardNB";

                txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");

                txtCalndrDate.Attributes.Add("readonly", "readonly");
                txtCalndrDate1.Attributes.Add("readonly", "readonly");

                ShowData();
            }
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
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
                con.Open();
                MySqlCommand cmd = new MySqlCommand("(select a.Site,a.name as Tab_User,(select count(*)  from view_crf4b as x where a.name=x.name  and (str_to_date(x.lw_crf4b_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  TotalApporach,(select count(*)  from view_crf4b as x where a.name=x.name  and x.q19!='1' and (str_to_date(x.lw_crf4b_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  Incomplete_CRF4,(select count(*)  from view_crf4b as x where a.name=x.name  and x.q19='1' and (str_to_date(x.lw_crf4b_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  Complete_CRF4,(select count(*)  from view_crf5a as x where a.name=x.name  and (str_to_date(x.lw_crf5a_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  Complete_CRF5a from (select cc.site,aa.name,bb.team_title_id from emp  as aa inner join team as bb on aa.team_id=bb.team_id inner join site as cc on cc.site_id=bb.site_id where team_title_id=3 and aa.access_status=1 order by Site)  as a ) union all (select '','Total',(select count(*)  from view_crf4b as x where (str_to_date(x.lw_crf4b_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  TotalApporach_CRF4b,(select count(*)  from view_crf4b as x where  x.q19!='1' and (str_to_date(x.lw_crf4b_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  IncompleteCRF4,(select count(*)  from view_crf4b as x where  x.q19='1' and (str_to_date(x.lw_crf4b_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  Complete_CRF4, (select count(*)  from view_crf5a as x where (str_to_date(x.lw_crf5a_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  TotalFilled_CRF5a)", con);             

                //MySqlCommand cmd = new MySqlCommand("(select a.Site,a.name as Tab_User,(select count(*)  from view_crf4a as x where a.name=x.name  and (str_to_date(x.date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  TotalApporach,(select count(*)  from view_crf4a as x where a.name=x.name and x.Q19_Vstatus!=1 and (str_to_date(x.date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  Incomplete_CRF4a,(select count(*)  from view_crf4a as x where a.name=x.name and x.Q19_Vstatus=1 and (str_to_date(x.date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  Complete_CRF4a,(select count(*)  from view_crf4b as x where a.name=x.name  and x.q19='1' and (str_to_date(x.lw_crf4b_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  Complete_CRF4b,(select count(*)  from view_crf5a as x where a.name=x.name  and (str_to_date(x.lw_crf5a_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  Complete_CRF5a from (select cc.site,aa.name,bb.team_title_id from emp  as aa inner join team as bb on aa.team_id=bb.team_id inner join site as cc on cc.site_id=bb.site_id where team_title_id=3 and aa.access_status=1 order by Site)  as a ) union all (select '','Total',(select count(*)  from view_crf4a as x where (str_to_date(x.date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  TotalApporach_CRF4a,(select count(*)  from view_crf4a as x where x.Q19_Vstatus!=1 and (str_to_date(x.date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  Incomplete_CRF4a,(select count(*)  from view_crf4a as x where x.Q19_Vstatus=1 and (str_to_date(x.date_of_attempt, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  Complete_CRF4a,(select count(*)  from view_crf4b as x where  x.q19='1' and (str_to_date(x.lw_crf4b_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  TotalFilled_CRF4b, (select count(*)  from view_crf5a as x where (str_to_date(x.lw_crf5a_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as  TotalFilled_CRF5a)", con);             
                cmd.CommandTimeout = 0;
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
                          //  GridView1.Rows[GridView1.Rows.Count - 1].BackColor = System.Drawing.Color.FromName("#cef5cb");
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

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //TAB NAME: 
                TableCell cell1 = e.Row.Cells[1];
                cell1.BackColor = System.Drawing.Color.FromName("#e0f0ff");

                //RED
                TableCell cell3 = e.Row.Cells[3];

                cell3.BackColor = System.Drawing.Color.FromName("#fff0f0");




                //if Text is 0 then will be chnage into GRAY
                if (e.Row.Cells[2].Text == "0" )
                {
                    TableCell cell = e.Row.Cells[2];
                    cell.ForeColor = System.Drawing.Color.FromName("#8395a7");
                }
                if (e.Row.Cells[3].Text == "0" )
                {
                    TableCell cell = e.Row.Cells[3];
                    cell.ForeColor = System.Drawing.Color.FromName("#8395a7");
                }
                if (e.Row.Cells[4].Text == "0" )
                {
                    TableCell cell = e.Row.Cells[4];
                    cell.ForeColor = System.Drawing.Color.FromName("#8395a7");
                }
                if (e.Row.Cells[5].Text == "0" )
                {
                    TableCell cell = e.Row.Cells[5];
                    cell.ForeColor = System.Drawing.Color.FromName("#8395a7");
                }

            }
        }

    }
}