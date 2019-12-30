using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class followups : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateFormatPageLoad();
                Session["WebForm"] = "followups4a";
                ShowData();
                txtdssid.Focus();
            }
        }



        private void DateFormatPageLoad()
        {
            txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate.Attributes.Add("readonly", "readonly");
            txtCalndrDate1.Attributes.Add("readonly", "readonly");
            txtCalndrDate.Enabled = true;
            txtCalndrDate1.Enabled = true;
            CheckBox1.Checked = false;
        }


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtCalndrDate.Enabled = !CheckBox1.Checked;
            txtCalndrDate1.Enabled = !CheckBox1.Checked;
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (CheckBox1.Checked == false && DateTime.ParseExact(txtCalndrDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtCalndrDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
            {
                showalert("First Date should be Less or Equal than Second Date");
                txtCalndrDate.Focus();
            }
            else
            {
                ShowData();
                txtdssid.Focus();
            }
        }




        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (byEndDate.Checked == true)
                {
                    // For Every Date:
                    if (CheckBox1.Checked == true)
                    {
                        if (DropDownList1.SelectedValue == "0")
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 	and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
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
                        else
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 	and a.site='" + DropDownList1.SelectedValue + "' and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
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
                        if (DropDownList1.SelectedValue == "0")
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 	and (str_to_date(a.end_date, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
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
                        else
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 			and a.site='" + DropDownList1.SelectedValue + "'	and (str_to_date(a.end_date, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
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
                else
                {
                    if (CheckBox1.Checked == true)
                    {
                        if (DropDownList1.SelectedValue == "0")
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 	and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
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
                        else
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 	and a.site='" + DropDownList1.SelectedValue + "' and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
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
                        if (DropDownList1.SelectedValue == "0")
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 	and (str_to_date(date, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
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
                        else
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 			and a.site='" + DropDownList1.SelectedValue + "'	and (str_to_date(date, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
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

        }




        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
            txtdssid.Focus();
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

                if (byEndDate.Checked == true)
                {
                    // For Every Date:
                    if (CheckBox1.Checked == true)
                    {
                        if (DropDownList1.SelectedValue == "0")
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 	and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
                            MySqlDataAdapter sda = new MySqlDataAdapter();
                            {
                                cmd.Connection = con;
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
                        else
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 	and a.site='" + DropDownList1.SelectedValue + "' and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
                            MySqlDataAdapter sda = new MySqlDataAdapter();
                            {
                                cmd.Connection = con;
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

                    else
                    {
                        if (DropDownList1.SelectedValue == "0")
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 	and (str_to_date(a.end_date, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
                            MySqlDataAdapter sda = new MySqlDataAdapter();
                            {
                                cmd.Connection = con;
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
                        else
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 			and a.site='" + DropDownList1.SelectedValue + "'	and (str_to_date(a.end_date, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
                            MySqlDataAdapter sda = new MySqlDataAdapter();
                            {
                                cmd.Connection = con;
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
                }
                else
                {
                    if (CheckBox1.Checked == true)
                    {
                        if (DropDownList1.SelectedValue == "0")
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 	and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
                            MySqlDataAdapter sda = new MySqlDataAdapter();
                            {
                                cmd.Connection = con;
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
                        else
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 	and a.site='" + DropDownList1.SelectedValue + "' and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
                            MySqlDataAdapter sda = new MySqlDataAdapter();
                            {
                                cmd.Connection = con;
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

                    else
                    {
                        if (DropDownList1.SelectedValue == "0")
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 	and (str_to_date(date, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
                            MySqlDataAdapter sda = new MySqlDataAdapter();
                            {
                                cmd.Connection = con;
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
                        else
                        {
                            con.Open();
                            MySqlCommand cmd;
                            cmd = new MySqlCommand("select *, DATEDIFF(str_to_date(a.end_date, '%d-%m-%Y') , str_to_date(a.date, '%d-%m-%Y') ) as Days from view_followups4a as a left join participant_status as b on  a.study_code=b.study_code    where  a.status=3 	and 	not exists (select z.* from view_followups4a as z where a.id=z.id and (z.Day='Sunday' and DATEDIFF(str_to_date(z.end_date, '%d-%m-%Y') , str_to_date(z.date, '%d-%m-%Y')) =0)  ) 			and a.site='" + DropDownList1.SelectedValue + "'	and (str_to_date(date, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  and a.dssid like '%" + txtdssid.Text + "%' 	 order by str_to_date(a.date, '%d-%m-%Y'),a.study_code,a.age;", con);
                            MySqlDataAdapter sda = new MySqlDataAdapter();
                            {
                                cmd.Connection = con;
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
                Response.AddHeader("content-disposition", "attachment;filename=NB-Followups4a Pending (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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


    }
}
