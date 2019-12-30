using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace maamta
{
    public partial class Login : System.Web.UI.Page
    {
        MySqlDataReader dreader;
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["MPusername"] = null;
            Session["Role"] = null;
            txtUserNme.Focus();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Loginn();
        }


        private void Loginn()
        {
            if (txtUserNme.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter User Name!')</script>");
                txtUserNme.Focus();
            }

            else if (txtPass.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter Password!')</script>");
                txtPass.Focus();
            }
            else if (LogSeach() == false)
            {
                Response.Write("<script>alert('Incorrect User Name or Password')</script>");
                txtPass.Text = "";
                txtPass.Focus();
            }
            else if (Security() == false)
            {
                Response.Write("<script>alert('You are doing some irrelevant thing, Complaint registered')</script>");
                txtPass.Text = "";
                txtPass.Focus();
            }
            else
            {
                Session["MPusername"] = txtUserNme.Text;
                Response.Redirect("dashboard.aspx");

            }
        }



        public bool Security()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select count(*) as total from team where user_name='" + txtUserNme.Text + "'", con);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read() && dr["total"].ToString() == "1")
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }



        public bool LogSeach()
        {
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from team as a left join team_title as b on a.team_title_id=b.team_title_id where a.password='" + txtPass.Text + "' and a.user_name='" + txtUserNme.Text + "' and a.user_name!='akupi'", con);
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    Session["Role"] = dreader["title"].ToString(); 
                    return true;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
                Response.Write("<script>window.location.href='Login.aspx';</script>");
            }
            finally
            {
                con.Close();
            }
            return false;
        }

    }
}