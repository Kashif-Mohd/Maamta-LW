﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class showcrf5bbyid : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "showcrf5b";
                if (Session["StudyId_CRF5b"] == null)
                {
                    Response.Redirect("showcrf5b.aspx");
                }
                lbeStudyId.Text = Convert.ToString(Session["StudyId_CRF5b"]);
                ShowData();
                Show24Hours();
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["StudyId_CRF5b"] = null;
            Session["form_crf5b_id"] = null;
            Response.Redirect("showcrf5b.aspx");
        }



        public static DataTable FlipDataTable(DataTable dt)
        {
            DataTable table = new DataTable();
            //Get all the rows and change into columns
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }
            DataRow dr;
            //get all the columns and make it as rows
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                dr = table.NewRow();
                dr[0] = dt.Columns[j].ToString();
                for (int k = 1; k <= dt.Rows.Count; k++)
                    dr[k] = dt.Rows[k - 1][j];
                table.Rows.Add(dr);
            }

            return table;
        }



        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand("select * from view_crf5b_only where form_crf_5b_id='" + Convert.ToString(Session["form_crf_5b_id"]) + "'", con);
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataSource = FlipDataTable(dt);
                            GridView1.DataBind();
                            GridView1.HeaderRow.Visible = false;
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




        private void Show24Hours()
        {
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select lw_crf5b_25_from as 'Hours From',lw_crf5b_25_to as 'Hours To',lw_crf5b_26 as Q26,lw_crf5b_27 as Q27, lw_crf5b_28 as Q28, lw_crf5b_29 as Q29, lw_crf5b_30 as Q30,	lw_crf5b_31 as Q31, lw_crf5b_32 as Q32,	lw_crf5b_33 as Q33,	lw_crf5b_34 as Q34,	lw_crf5b_35 as Q35,	lw_crf5b_36 as Q36,	lw_crf5b_37 as Q37,	lw_crf5b_38 as Q38,	lw_crf5b_39 as Q39,	lw_crf5b_40 as Q40,	lw_crf5b_41 as Q41,	lw_crf5b_42 as Q42,	lw_crf5b_43 as Q43,	lw_crf5b_44 as Q44,	lw_crf5b_45 as Q45,	lw_crf5b_46 as Q46,	lw_crf5b_47 as Q47,	lw_crf5b_48 as Q48, lw_crf5b_49 as Q49 from form_crf_5b_details where form_crf_5b_id='" + Convert.ToString(Session["form_crf_5b_id"]) + "' order by form_crf_5b_details_id", con);
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataSource = FlipDataTable(dt);
                            GridView2.DataBind();
                            GridView2.HeaderRow.Visible = false;
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
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[0].Width = 230;

                e.Row.Cells[1].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[1].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[1].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[0].BorderColor = System.Drawing.Color.FromName("#126652");
            }
        }

        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Font.Bold = true;
                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[0].Width = 230;

                e.Row.Cells[1].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[2].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[3].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[4].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[5].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[6].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[7].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[8].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[9].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[10].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[11].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[12].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[13].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[14].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[15].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[16].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[17].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[18].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[19].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[20].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[21].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[22].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[23].ForeColor = System.Drawing.Color.FromName("#284775");
                e.Row.Cells[24].ForeColor = System.Drawing.Color.FromName("#284775");


                e.Row.Cells[1].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[2].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[3].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[4].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[5].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[6].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[7].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[8].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[9].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[10].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[11].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[12].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[13].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[14].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[15].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[16].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[17].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[18].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[19].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[20].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[21].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[22].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[23].BackColor = System.Drawing.Color.FromName("#C8F7C5");
                e.Row.Cells[24].BackColor = System.Drawing.Color.FromName("#C8F7C5");



                e.Row.Cells[1].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[2].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[3].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[4].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[5].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[6].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[7].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[8].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[9].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[10].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[11].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[12].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[13].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[14].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[15].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[16].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[17].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[18].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[19].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[20].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[21].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[22].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[23].BorderColor = System.Drawing.Color.FromName("#00b894");
                e.Row.Cells[24].BorderColor = System.Drawing.Color.FromName("#00b894");


                e.Row.Cells[0].BorderColor = System.Drawing.Color.FromName("#126652");
            }
        }

    }
}