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
    public partial class delscreeingform : System.Web.UI.Page
    {
        MySqlDataReader dreader;
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        string pwid;
        string dss_id;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Convert.ToString(Session["Role"]) != "Web_Admin")
            {
                Response.Redirect("dashboard.aspx");
            }
            Session["WebForm"] = "DeleteCRF1";
            txtdssid.Focus();
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
            txtdssid.Focus();
        }


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select * from delete_crf1 where dssid like '%" + txtdssid.Text + "%' order by assis_id,id", con);
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

        protected void Link_Delete(object sender, EventArgs e)
        {
            string[] arg = new string[2];
            arg = ((LinkButton)sender).CommandArgument.ToString().Split(';');
            pwid = arg[0];
            dss_id = arg[1];
            
            if (CheckCRF2() == false)
            {
                DeleteRec();
            }
        }

        protected void Link_Assis(object sender, EventArgs e)
        {

            string[] arg = new string[3];
            arg = ((LinkButton)sender).CommandArgument.ToString().Split(';');
            string Edit_Assis = arg[0];
            string Edit_id = arg[1];
            string Edit_dss_id = arg[2];

            Session["Edit_Assis"] = Edit_Assis;
            Session["Edit_id"] = Edit_id;
            Session["Edit_dss_id"] = Edit_dss_id;

            Response.Redirect("editdssid.aspx");
        }



        private void DeleteRec()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select max(form_crf_1_id) as last_formid from form_crf_1 where pw_assis_id='" + pwid + "'", con);
                dreader = cmd.ExecuteReader();
                if (dreader.Read() == true)
                {
                    string last_formid = dreader["last_formid"].ToString();
                    con.Close();

                    //Delete Form CRF1:
                    con.Open();
                    MySqlCommand forForm;
                    forForm = new MySqlCommand("delete from form_crf_1 where  pw_assis_id='" + pwid + "'", con);
                    forForm.ExecuteNonQuery();
                    con.Close();


                    //Delete PW :
                    con.Open();
                    MySqlCommand forPW;
                    forPW = new MySqlCommand("delete from pw where id='" + pwid + "'", con);
                    forPW.ExecuteNonQuery();
                    con.Close();


                    //Delete DSSID:
                    con.Open();
                    MySqlCommand forDSSID;
                    forDSSID = new MySqlCommand("delete from dss_address where  dss_id='" + dss_id + "'", con);
                    forDSSID.ExecuteNonQuery();
                    con.Close();


                    //Delete MUAC Value:
                    con.Open();
                    MySqlCommand forMUAC;
                    forMUAC = new MySqlCommand("delete from muac_assessment where form_crf_1_id='" + last_formid + "'", con);
                    forMUAC.ExecuteNonQuery();
                    con.Close();

                    //Delete Contact Number:
                    con.Open();
                    MySqlCommand forContact;
                    forContact = new MySqlCommand("delete from contact_number where form_crf_1_id='" + last_formid + "'", con);
                    forContact.ExecuteNonQuery();
                    con.Close();

                    ShowData();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                pwid = null;
                dss_id = null;
              
                con.Close();
            }
        }




        public bool CheckCRF2()
        {
            MySqlConnection con = new MySqlConnection(constr);

            bool exist = false;
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from form_crf_2 where assis_id='" + pwid + "'", con);
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;
                    showalert("CRF-2 (ELIGIBILITY FORM) is filled according to this Assessment-id");
                    txtdssid.Focus();
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
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
                if (e.Row.Cells[6].Text == "1")
                {
                    e.Row.Cells[6].Text = "Complete";
                }
                else if (e.Row.Cells[6].Text == "2")
                {
                    e.Row.Cells[6].Text = "Not at home";
                }
                else if (e.Row.Cells[6].Text == "3")
                {
                    e.Row.Cells[6].Text = "Refused";
                }
                else if (e.Row.Cells[6].Text == "4")
                {
                    e.Row.Cells[6].Text = "Wrong Information";
                }
                else if (e.Row.Cells[6].Text == "5")
                {
                    e.Row.Cells[6].Text = "Wrong Info. DSS";
                }
                else if (e.Row.Cells[6].Text == "6")
                {
                    e.Row.Cells[6].Text = "Woman was never found Pregnant";
                }
                else if (e.Row.Cells[6].Text == "7")
                {
                    e.Row.Cells[6].Text = "Woman was preg. but recently delivered";
                }
                else if (e.Row.Cells[6].Text == "8")
                {
                    e.Row.Cells[6].Text = "Shifted out of DSS";
                }
                else if (e.Row.Cells[6].Text == "9")
                {
                    e.Row.Cells[6].Text = "PW died";
                }
                else if (e.Row.Cells[6].Text == "10")
                {
                    e.Row.Cells[6].Text = "Visitor";
                }
            }
        }


    }
}