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
    public partial class showcrf4abyid : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "showcrf4a";
                if (Session["StudyId_CRF4a"] == null)
                {
                    Response.Redirect("showcrf4a.aspx");
                }
                lbeStudyId.Text = Convert.ToString(Session["StudyId_CRF4a"]);
                ShowData();
                Show24Hours();
              
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["StudyId_CRF4a"] = null;
            Session["form_crf4a_id"] = null;
            Response.Redirect("showcrf4a.aspx");
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

                MySqlCommand cmd = new MySqlCommand("select * from view_crf4a_only where form_crf_4a_id='" + Convert.ToString(Session["form_crf4a_id"]) + "'", con);
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 9999999;
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
                MySqlCommand cmd = new MySqlCommand("select lw_crf4a_27_from	as	'Hours From',lw_crf4a_27_to	as 'Hours To',lw_crf4a_28	as	Q28,lw_crf4a_29	as	Q29,lw_crf4a_30	as	Q30,lw_crf4a_31	as Q31,lw_crf4a_32	as	Q32,lw_crf4a_33	as	Q33,lw_crf4a_34	as	Q34,lw_crf4a_35	as	Q35,lw_crf4a_36	as	Q36,lw_crf4a_37	as	Q37, lw_crf4a_38	as	Q38,lw_crf4a_39	as	Q39,lw_crf4a_40	as	Q40,lw_crf4a_41	as	Q41,lw_crf4a_42	as	Q42,lw_crf4a_43	as	Q43,lw_crf4a_44	as	Q44,lw_crf4a_45	as	Q45,lw_crf4a_46	as	Q46,lw_crf4a_47	as	Q47,lw_crf4a_48	as	Q48,lw_crf4a_49	as	Q49, lw_crf4a_50	as	Q50,lw_crf4a_51	as	Q51,lw_crf4a_52	as	Q52,lw_crf4a_53	as	Q53,lw_crf4a_54	as	Q54,lw_crf4a_55	as	Q55,lw_crf4a_56	as	Q56,lw_crf4a_57	as	Q57,lw_crf4a_58	as	Q58,lw_crf4a_59	as	Q59,lw_crf4a_60	as	Q60,lw_crf4a_61	as	Q61, lw_crf4a_62	as	Q62,lw_crf4a_63	as	Q63,lw_crf4a_64	as	Q64,lw_crf4a_65	as	Q65,lw_crf4a_66	as	Q66,lw_crf4a_67	as	Q67,lw_crf4a_68	as	Q68,lw_crf4a_69	as	Q69,lw_crf4a_70	as	Q70,lw_crf4a_71	as	Q71,lw_crf4a_72	as	Q72,lw_crf4a_73a	as	Q73a,lw_crf4a_73b	as	Q73b,lw_crf4a_73c	as	Q73c,lw_crf4a_73d	as	Q73d,lw_crf4a_73e	as	Q73e,lw_crf4a_73f	as	Q73f,lw_crf4a_73g	as	Q73g,lw_crf4a_73h	as	Q73h,lw_crf4a_73i	as	Q73i,lw_crf4a_73j	as	Q73j from form_crf_4a_details where form_crf_4a_id='" + Convert.ToString(Session["form_crf4a_id"]) + "' order by form_crf_4a_detail_id", con);
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