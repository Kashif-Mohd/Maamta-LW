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
    public partial class addnewuser : System.Web.UI.Page
    {
        string ConDataBase = System.Configuration.ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "Setting";
                txtUserName.Focus();
                if (Session["Role"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                if (Convert.ToString(Session["CPusername"]) == "adminuser" || Convert.ToString(Session["CPusername"]) == "ADMINUSER")
                {
                    dropdownRole.Disabled = true;
                    dropdownRole.Value = "local";
                }
            }
        }
      
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Please Enter User Name!')", true);
                txtUserName.Focus();
            }
            else if (txtUserName.Text.Length <= 3)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Minimum 4 Character is Require!')", true);
                txtUserName.Focus();
            }           
            else if (txtPassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Please Enter Password!')", true);
                txtPassword.Focus();
            }
            else if (txtPassword.Text.Length <= 3)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Password must be 4 character or digit long!')", true);
                txtPassword.Focus();
            }
            else if (txtConfirmPassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Please Enter Confirm Password!')", true);
                txtConfirmPassword.Focus();
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Password Not Match!')", true);
                txtConfirmPassword.Focus();
                txtConfirmPassword.Text = "";
            }
            else if (dropdownRole.Value == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Please Select User Roles!')", true);
                dropdownRole.Focus();
            }
            else if (FindUser() == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('User Name is already exists!')", true);
                txtUserName.Text = "";
                txtUserName.Focus();
            }
            else
            {
                insertUser();
            }

        }



        public void insertUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConDataBase);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into users (username,password,role) values ('" + txtUserName.Text.ToLower() + "','" + txtPassword.Text.ToLower() + "','" + dropdownRole.Value + "')", con);
                cmd.ExecuteNonQuery();
                Clear();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('User Created Successfully!')", true);
                con.Close();                
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }

        }




        public void Clear()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            dropdownRole.Value = "0";
            txtUserName.Focus();
        }




        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }


        public bool FindUser()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from users where username='" + txtUserName.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

    }
}