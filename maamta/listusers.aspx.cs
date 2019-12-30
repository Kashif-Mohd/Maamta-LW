using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class listusers : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "ListOfUsers";
            if (!IsPostBack)
            {
                ShowData();
                txtname.Focus();
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
            txtname.Focus();
        }

        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                if (DropDownList1.SelectedValue == "0")
                {
                    MySqlCommand cmd = new MySqlCommand("select d.title,c.site,a.name,b.user_name,b.password from emp as a join team as b on a.team_id=b.team_id join site as c on c.site_id=b.site_id join team_title as d on b.team_title_id=d.team_title_id where a.name like '%" + txtname.Text + "%' and a.access_status=1 order by d.title,c.site", con);
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
                else
                {
                    MySqlCommand cmd = new MySqlCommand("select d.title,c.site,a.name,b.user_name,b.password from emp as a join team as b on a.team_id=b.team_id join site as c on c.site_id=b.site_id join team_title as d on b.team_title_id=d.team_title_id where a.name like '%" + txtname.Text + "%' and a.access_status=1 and d.team_title_id='" + DropDownList1.SelectedValue + "' order by d.title,c.site", con);
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

        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.Cells[6].Text == "1")
            //    {
            //        e.Row.Cells[6].Text = "Active";
            //    }
            //    else if (e.Row.Cells[6].Text == "2")
            //    {
            //        e.Row.Cells[6].Text = "Deactive";
            //    }
            //}
        }


    }
}