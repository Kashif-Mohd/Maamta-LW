using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class changepass : System.Web.UI.Page
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        SqlDataReader dreader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                lbeAccType.Text = "Standard User";
            }
            else
            {
                lbeAccType.Text = "Administrator";
            }
            txtOldPassword.Focus();
            if (!IsPostBack)
            {
                Session["WebForm"] = "changepass";
                txtOldPassword.Focus();                
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {

            if (txtOldPassword.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter Old Password!')</script>");
                txtOldPassword.Focus();
            }
            else if (txtOldPassword.Text.Length < 5 && txtOldPassword.Text != "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Password must be at least 6 characters long.')</script>");
                txtOldPassword.Text = "";
                txtOldPassword.Focus();
            }
            else if (txtNewPassword.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter New Password!')</script>");
                txtNewPassword.Focus();
            }
            else if (txtNewPassword.Text.Length < 5 && txtNewPassword.Text != "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Password must be at least 6 characters long.')</script>");
                txtNewPassword.Text = "";
                txtNewPassword.Focus();
            }

            else if (txtConfirmPassword.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter Confirm Password!')</script>");
                txtConfirmPassword.Focus();
            }
            else if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                Response.Write("<script type=\"text/javascript\">alert('Password Does Not Match!')</script>");
                txtConfirmPassword.Text = "";
                txtConfirmPassword.Focus();
            }
            else if (checkPassword() == false)
            {
                Response.Write("<script type=\"text/javascript\">alert('Password you entered is incorrect, please enter correct password!')</script>");
                txtOldPassword.Text = "";
                txtOldPassword.Focus();
            }
            else
            {
                changePassword();
            }
        }


        public void changePassword()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("update users SET password='" + txtNewPassword.Text + "' where  username='" + Convert.ToString(Session["CPusername"]) + "'", con);
                int result = cmd.ExecuteNonQuery();

                if (result == 1)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Password Changed Successfully!')</script>");
                    //Response.Write("<script>window.location.href='Login.aspx';</script>");
                    Clearr();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");

            }
        }


        public bool checkPassword()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from users where username='" + Convert.ToString(Session["CPusername"]) + "' and password='" + txtOldPassword.Text + "'", con);
            dreader = cmd.ExecuteReader();
            if (dreader.Read())
            {
                return true;
            }
            return false;
        }



        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clearr();
        }


        public void Clearr()
        {
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }


        //public void GetUserName()
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(constr);
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("select * from users where username='" + Convert.ToString(Session["CPusername"]) + "'", con);
        //        {
        //            dreader = cmd.ExecuteReader();
        //            if (dreader.Read())
        //            {
        //                lbeFullName.Text = Convert.ToString(Session["CPusername"]);
        //                con.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
        //    }
        //}

    }
}