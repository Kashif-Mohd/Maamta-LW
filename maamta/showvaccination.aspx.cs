using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class showvaccination : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "showvaccination";
                ShowData();
                txtdssid.Focus();
            }
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


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select * from view_vaccination WHERE DSSID LIKE '" + txtdssid.Text + "%'  order by site,study_code", con);
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


        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
            txtdssid.Focus();
        }



        public void ExcelExportMessage()
        {
            if (txtdssid.Text != "")
            {
                GridView2.Caption = "DSSID, Search by: " + txtdssid.Text;
            }
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
                cmd = new MySqlCommand("select * from view_vaccination WHERE DSSID LIKE '" + txtdssid.Text + "%'  order by site,study_code", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=Vaccination (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[7].Text != "&nbsp;")
                {
                    //Null Current Age
                    e.Row.Cells[6].Text = "";

                    // Age of Death 
                    DateTime dob = DateTime.ParseExact(e.Row.Cells[5].Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    DateTime dod = DateTime.ParseExact(e.Row.Cells[7].Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    TimeSpan diff = dod.Subtract(dob);
                    int age_dod = diff.Days;
                    e.Row.Cells[8].Text = Convert.ToString(age_dod);
                }



                TableCell cell1 = e.Row.Cells[11];
                TableCell cell2 = e.Row.Cells[12];
                TableCell cell3 = e.Row.Cells[13];
                TableCell cell4 = e.Row.Cells[14];
                TableCell cell5 = e.Row.Cells[18];
                TableCell cell6 = e.Row.Cells[19];
                TableCell cell7 = e.Row.Cells[20];
                TableCell cell8 = e.Row.Cells[24];
                TableCell cell9 = e.Row.Cells[25];
                TableCell cell10 = e.Row.Cells[26];
                TableCell cell11 = e.Row.Cells[30];
                TableCell cell12 = e.Row.Cells[31];
                TableCell cell13 = e.Row.Cells[32];
                TableCell cell14 = e.Row.Cells[36];
                TableCell cell15 = e.Row.Cells[37];
                TableCell cell16 = e.Row.Cells[38];
                TableCell cell17 = e.Row.Cells[42];
                TableCell cell18 = e.Row.Cells[43];
                TableCell cell19 = e.Row.Cells[44];
                TableCell cell20 = e.Row.Cells[48];
                TableCell cell21 = e.Row.Cells[49];
                TableCell cell22 = e.Row.Cells[50];
                TableCell cell23 = e.Row.Cells[54];

                cell1.BackColor = System.Drawing.Color.FromName("#cef5cb");
                cell2.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell3.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell4.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell5.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell6.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell7.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell8.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell9.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell10.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell11.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell12.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell13.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell14.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell15.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell16.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell17.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell18.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell19.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell20.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell21.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell22.BackColor = System.Drawing.Color.FromName("#dfe6e9");
                cell23.BackColor = System.Drawing.Color.FromName("#dfe6e9");





                //BCG0 Pending   (Pending_After_Birth)
                if (e.Row.Cells[13].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 1)
                {
                    e.Row.Cells[55].Text = "BCG0, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //OPV0 Pending   (Pending_After_Birth)
                if (e.Row.Cells[16].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 1)
                {
                    e.Row.Cells[55].Text = e.Row.Cells[55].Text + "OPV0, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }





                //OPV1 Pending   (Pending_Greater_6_Weeks)
                if (e.Row.Cells[19].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 42)
                {
                    e.Row.Cells[56].Text = "OPV1, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //Penta1 Pending   (Pending_Greater_6_Weeks)
                if (e.Row.Cells[22].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 42)
                {
                    e.Row.Cells[56].Text = e.Row.Cells[56].Text + "Penta1, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //PCV1 Pending   (Pending_Greater_6_Weeks)
                if (e.Row.Cells[25].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 42)
                {
                    e.Row.Cells[56].Text = e.Row.Cells[56].Text + "PCV1, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //Rota1  Pending   (Pending_Greater_6_Weeks)
                if (e.Row.Cells[28].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 42)
                {
                    e.Row.Cells[56].Text = e.Row.Cells[56].Text + "Rota1, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }






                //OPV2  Pending   (Pending_Greater_10_Weeks)
                if (e.Row.Cells[31].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 70)
                {
                    e.Row.Cells[57].Text = e.Row.Cells[57].Text + "OPV2, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //Penta2  Pending   (Pending_Greater_10_Weeks)
                if (e.Row.Cells[34].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 70)
                {
                    e.Row.Cells[57].Text = e.Row.Cells[57].Text + "Penta2, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //PCV2  Pending   (Pending_Greater_10_Weeks)
                if (e.Row.Cells[37].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 70)
                {
                    e.Row.Cells[57].Text = e.Row.Cells[57].Text + "PCV2, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //Rota2  Pending   (Pending_Greater_10_Weeks)
                if (e.Row.Cells[40].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 70)
                {
                    e.Row.Cells[57].Text = e.Row.Cells[57].Text + "Rota2, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }






                //OPV3  Pending   (Pending_Greater_14_Weeks)
                if (e.Row.Cells[43].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 98)
                {
                    e.Row.Cells[58].Text = e.Row.Cells[58].Text + "OPV3, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //Penta3  Pending   (Pending_Greater_14_Weeks)
                if (e.Row.Cells[46].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 98)
                {
                    e.Row.Cells[58].Text = e.Row.Cells[58].Text + "Penta3, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //PCV3  Pending   (Pending_Greater_14_Weeks)
                if (e.Row.Cells[49].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 98)
                {
                    e.Row.Cells[58].Text = e.Row.Cells[58].Text + "PCV3, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //IPV  Pending   (Pending_Greater_14_Weeks)
                if (e.Row.Cells[52].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 98)
                {
                    e.Row.Cells[58].Text = e.Row.Cells[58].Text + "IPV, ";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }










                //Measles1  Pending   (Pending_Greater_9_Months)
                if (e.Row.Cells[62].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 270)
                {
                    e.Row.Cells[59].Text = e.Row.Cells[59].Text + "Measles 1";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }
                //Measles2  Pending   (Pending_Greater_15_Months)
                if (e.Row.Cells[65].Text == "&nbsp;" && e.Row.Cells[6].Text != "" && Convert.ToInt32(e.Row.Cells[6].Text) > 450)
                {
                    e.Row.Cells[60].Text = e.Row.Cells[60].Text + "Measles 2";
                    TableCell DSSID = e.Row.Cells[10];
                    DSSID.BackColor = System.Drawing.Color.FromName("#fab1a0");
                }


            }
        }

    }
}