using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

namespace maamta
{
    public partial class digitpreference : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "digitpreference";
            CRF2_Color();
           
            LoadChartCRF2_R1();
            LoadChartCRF2_R2();
        }



        protected void btnCRF2_Click(object sender, EventArgs e)
        {
            CRF2_Color();
           
            LoadChartCRF2_R1();
            LoadChartCRF2_R2();
        }

        protected void btnCRF3c_Click(object sender, EventArgs e)
        {
            // For Child:
            CRF3c_Ch_Color();

            LoadChartCRF3c_Length_R1();
            LoadChartCRF3c_Length_R2();

            LoadChartCRF3c_MUAC_R1();
            LoadChartCRF3c_MUAC_R2();

            LoadChartCRF3c_OFHC_R1();
            LoadChartCRF3c_OFHC_R2();
        }


        protected void btnlwCRF3c_Click(object sender, EventArgs e)
        {
            // For Lactating Woman:
            CRF3c_LW_Color();

            LoadChartCRF3c_LW_Weight_R1();
            LoadChartCRF3c_LW_Weight_R2();

            LoadChartCRF3c_LW_Height_R1();
            LoadChartCRF3c_LW_Height_R2();

            LoadChartCRF3c_LW_MUAC_R1();
            LoadChartCRF3c_LW_MUAC_R2();
        }


        protected void btnCRF6_Click(object sender, EventArgs e)
        {
            // For Child:
            CRF6_Ch_Color();

            //LoadChartCumulativeCRF6_Length();
            //LoadChartCRF6_Length_R1();
            //LoadChartCRF6_Length_R2();

            //LoadChartCumulativeCRF6_MUAC();
            //LoadChartCRF6_MUAC_R1();
            //LoadChartCRF6_MUAC_R2();

            //LoadChartCumulativeCRF6_OFHC();
            //LoadChartCRF6_OFHC_R1();
            //LoadChartCRF6_OFHC_R2();
        }

        protected void btnlwCRF6_Click(object sender, EventArgs e)
        {
            // For  Lactating Woman:
            CRF6_LW_Color();

            //LoadChartCumulativelwCRF6_Length();
            //LoadChartlwCRF6_Length_R1();
            //LoadChartlwCRF6_Length_R2();

            //LoadChartCumulativelwCRF6_MUAC();
            //LoadChartlwCRF6_MUAC_R1();
            //LoadChartlwCRF6_MUAC_R2();

            //LoadChartCumulativelwCRF6_OFHC();
            //LoadChartlwCRF6_OFHC_R1();
            //LoadChartlwCRF6_OFHC_R2();
        }






        private void CRF2_Color()
        {
            btnCRF2.Style.Add("color", "white");
            btnCRF2.Style.Add("background-color", "#55efc4");

            btnCRF3c.Style.Add("color", "#adadad");
            btnCRF3c.Style.Add("background-color", "#e0e0e0");
            btnlwCRF3c.Style.Add("color", "#adadad");
            btnlwCRF3c.Style.Add("background-color", "#e0e0e0");
            btnCRF6.Style.Add("color", "#adadad");
            btnCRF6.Style.Add("background-color", "#e0e0e0");
            btnlwCRF6.Style.Add("color", "#adadad");
            btnlwCRF6.Style.Add("background-color", "#e0e0e0");


            divCRF2.Visible = true;
            div_Ch_CRF3c.Visible = false;
            div_LW_CRF3c.Visible = false;
            // div_Ch_CRF6.Visible = false;
            // div_LW_CRF6.Visible = false;
        }



        private void CRF3c_Ch_Color()
        {
            btnCRF3c.Style.Add("color", "white");
            btnCRF3c.Style.Add("background-color", "#55efc4");

            btnCRF2.Style.Add("color", "#adadad");
            btnCRF2.Style.Add("background-color", "#e0e0e0");
            btnlwCRF3c.Style.Add("color", "#adadad");
            btnlwCRF3c.Style.Add("background-color", "#e0e0e0");
            btnCRF6.Style.Add("color", "#adadad");
            btnCRF6.Style.Add("background-color", "#e0e0e0");
            btnlwCRF6.Style.Add("color", "#adadad");
            btnlwCRF6.Style.Add("background-color", "#e0e0e0");

            divCRF2.Visible = false;
            div_Ch_CRF3c.Visible = true;
            div_LW_CRF3c.Visible = false;
            // div_Ch_CRF6.Visible = false;
            // div_LW_CRF6.Visible = false;
        }

        private void CRF3c_LW_Color()
        {
            btnlwCRF3c.Style.Add("color", "white");
            btnlwCRF3c.Style.Add("background-color", "#55efc4");

            btnCRF2.Style.Add("color", "#adadad");
            btnCRF2.Style.Add("background-color", "#e0e0e0");
            btnCRF3c.Style.Add("color", "#adadad");
            btnCRF3c.Style.Add("background-color", "#e0e0e0");
            btnCRF6.Style.Add("color", "#adadad");
            btnCRF6.Style.Add("background-color", "#e0e0e0");
            btnlwCRF6.Style.Add("color", "#adadad");
            btnlwCRF6.Style.Add("background-color", "#e0e0e0");

            divCRF2.Visible = false;
            div_Ch_CRF3c.Visible = false;
            div_LW_CRF3c.Visible = true;
            // div_Ch_CRF6.Visible = false;
            // div_LW_CRF6.Visible = false;
        }

        private void CRF6_Ch_Color()
        {
            btnCRF6.Style.Add("color", "white");
            btnCRF6.Style.Add("background-color", "#55efc4");

            btnCRF2.Style.Add("color", "#adadad");
            btnCRF2.Style.Add("background-color", "#e0e0e0");
            btnCRF3c.Style.Add("color", "#adadad");
            btnCRF3c.Style.Add("background-color", "#e0e0e0");
            btnlwCRF3c.Style.Add("color", "#adadad");
            btnlwCRF3c.Style.Add("background-color", "#e0e0e0");
            btnlwCRF6.Style.Add("color", "#adadad");
            btnlwCRF6.Style.Add("background-color", "#e0e0e0");

            divCRF2.Visible = false;
            div_Ch_CRF3c.Visible = false;
            // div_LW_CRF3c.Visible = false;
            // div_Ch_CRF6.Visible = true;
            // div_LW_CRF6.Visible = false;
        }

        private void CRF6_LW_Color()
        {
            btnlwCRF6.Style.Add("color", "white");
            btnlwCRF6.Style.Add("background-color", "#55efc4");

            btnCRF2.Style.Add("color", "#adadad");
            btnCRF2.Style.Add("background-color", "#e0e0e0");
            btnCRF3c.Style.Add("color", "#adadad");
            btnCRF3c.Style.Add("background-color", "#e0e0e0");
            btnlwCRF3c.Style.Add("color", "#adadad");
            btnlwCRF3c.Style.Add("background-color", "#e0e0e0");
            btnCRF6.Style.Add("color", "#adadad");
            btnCRF6.Style.Add("background-color", "#e0e0e0");

            divCRF2.Visible = false;
            div_Ch_CRF3c.Visible = false;
            // div_LW_CRF3c.Visible = false;
            // div_LW_CRF3c.Visible = false;
            // div_LW_CRF6.Visible = true;
        }









        //For Cumulative:
        private static DataTable GetData(string query)
        {
            string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

            MySqlConnection con = new MySqlConnection(constr);
            {
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    DataTable dt = new DataTable();
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(query, con))
                    {
                        sda.Fill(dt);
                    }
                    return dt;
                }
            }
        }




     



        private void LoadChartCRF2_R1()
        {
            ChartCRF2_R1.Series.Clear();
            ChartCRF2_R1.ChartAreas["ChartAreaCRF2_R1"].AxisX.MajorGrid.Enabled = false;
            ChartCRF2_R1.DataBindCrossTable(GetDataCRF2_R1().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF2_R1.DataBind();

            ChartCRF2_R1.Series[0].BorderWidth = 2;
            ChartCRF2_R1.Series[1].BorderWidth = 2;
            ChartCRF2_R1.Series[2].BorderWidth = 2;
            ChartCRF2_R1.Series[3].BorderWidth = 2;
            ChartCRF2_R1.Series[4].BorderWidth = 2;
            ChartCRF2_R1.Series[5].BorderWidth = 2;
            //ChartCRF2_R1.Series[6].BorderWidth = 2;
            //ChartCRF2_R1.Series[7].BorderWidth = 2;
            ChartCRF2_R1.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF2_R1.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF2_R1.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF2_R1.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF2_R1.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF2_R1.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF2_R1.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF2_R1.Series[7].ChartType = SeriesChartType.Line;
        }


        private DataTable GetDataCRF2_R1()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT code_of_reader_1 as Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf2 left join (select * from arm_reading as a where a.arm_reading_id in ( select max(a.arm_reading_id) from arm_reading as a group by a.form_crf_2_id)) as muac on muac.form_crf_2_id= view_crf2.form_crf_2  where view_crf2.lw_crf2_30!=''    group by code_of_reader_1,SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf2 left join (select * from arm_reading as a where a.arm_reading_id in ( select max(a.arm_reading_id) from arm_reading as a group by a.form_crf_2_id)) as muac on muac.form_crf_2_id= view_crf2.form_crf_2  where view_crf2.lw_crf2_30!=''   group by SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1))", con);
            //           MySqlCommand cmd = new MySqlCommand("SELECT Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf2 left join (select * from arm_reading as a where a.arm_reading_id in ( select max(a.arm_reading_id) from arm_reading as a group by a.form_crf_2_id)) as muac on muac.form_crf_2_id= view_crf2.form_crf_2  where view_crf2.lw_crf2_30!=''   and Tab_User!='Ameer' group by Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1)", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }


        private void LoadChartCRF2_R2()
        {
            ChartCRF2_R2.Series.Clear();
            ChartCRF2_R2.ChartAreas["ChartAreaCRF2_R2"].AxisX.MajorGrid.Enabled = false;
            ChartCRF2_R2.DataBindCrossTable(GetDataCRF2_R2().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF2_R2.DataBind();

            ChartCRF2_R2.Series[0].BorderWidth = 2;
            ChartCRF2_R2.Series[1].BorderWidth = 2;
            ChartCRF2_R2.Series[2].BorderWidth = 2;
            ChartCRF2_R2.Series[3].BorderWidth = 2;
            ChartCRF2_R2.Series[4].BorderWidth = 2;
            ChartCRF2_R2.Series[5].BorderWidth = 2;
            //ChartCRF2_R2.Series[6].BorderWidth = 2;
            //ChartCRF2_R1.Series[7].BorderWidth = 2;
            ChartCRF2_R2.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF2_R2.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF2_R2.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF2_R2.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF2_R2.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF2_R2.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF2_R2.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF2_R2.Series[7].ChartType = SeriesChartType.Line;
        }



        private DataTable GetDataCRF2_R2()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT code_of_reader_2 as Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf2 left join (select * from arm_reading as a where a.arm_reading_id in ( select max(a.arm_reading_id) from arm_reading as a group by a.form_crf_2_id)) as muac on muac.form_crf_2_id= view_crf2.form_crf_2  where view_crf2.lw_crf2_30!=''   group by code_of_reader_2,SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf2 left join (select * from arm_reading as a where a.arm_reading_id in ( select max(a.arm_reading_id) from arm_reading as a group by a.form_crf_2_id)) as muac on muac.form_crf_2_id= view_crf2.form_crf_2  where view_crf2.lw_crf2_30!=''   group by SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1))", con);
            //            MySqlCommand cmd = new MySqlCommand("SELECT Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf2 left join (select * from arm_reading as a where a.arm_reading_id in ( select max(a.arm_reading_id) from arm_reading as a group by a.form_crf_2_id)) as muac on muac.form_crf_2_id= view_crf2.form_crf_2  where view_crf2.lw_crf2_30!=''  and Tab_User!='Ameer'  group by Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1)", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }











      


        private void LoadChartCRF3c_Length_R1()
        {
            ChartCRF3c_Length_R1.Series.Clear();
            ChartCRF3c_Length_R1.ChartAreas["ChartAreaCRF3c_Length_R1"].AxisX.MajorGrid.Enabled = false;
            ChartCRF3c_Length_R1.DataBindCrossTable(GetDataCRF3c_Length_R1().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF3c_Length_R1.DataBind();

            ChartCRF3c_Length_R1.Series[0].BorderWidth = 2;
            ChartCRF3c_Length_R1.Series[1].BorderWidth = 2;
            ChartCRF3c_Length_R1.Series[2].BorderWidth = 2;
            ChartCRF3c_Length_R1.Series[3].BorderWidth = 2;
            ChartCRF3c_Length_R1.Series[4].BorderWidth = 2;
            ChartCRF3c_Length_R1.Series[5].BorderWidth = 2;
            //ChartCRF3c_Length_R1.Series[6].BorderWidth = 2;
            //ChartCRF3c_Length_R1.Series[7].BorderWidth = 2;
            ChartCRF3c_Length_R1.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF3c_Length_R1.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF3c_Length_R1.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF3c_Length_R1.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF3c_Length_R1.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF3c_Length_R1.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF3c_Length_R1.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF3c_Length_R1.Series[7].ChartType = SeriesChartType.Line;
        }


        private DataTable GetDataCRF3c_Length_R1()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT reader_code1 as  Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from baby_length_crf3c as a where a.baby_length_crf3c_id in ( select max(a.baby_length_crf3c_id) from baby_length_crf3c as a group by a.form_crf_3c_id)) as Ch_Length on Ch_Length.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_17!=''  group by reader_code1,SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from baby_length_crf3c as a where a.baby_length_crf3c_id in ( select max(a.baby_length_crf3c_id) from baby_length_crf3c as a group by a.form_crf_3c_id)) as Ch_Length on Ch_Length.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_17!=''  group by SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1))", con);
            //MySqlCommand cmd = new MySqlCommand("SELECT Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from baby_length_crf3c as a where a.baby_length_crf3c_id in ( select max(a.baby_length_crf3c_id) from baby_length_crf3c as a group by a.form_crf_3c_id)) as Ch_Length on Ch_Length.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_17!=''  group by Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1)", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }


        private void LoadChartCRF3c_Length_R2()
        {
            ChartCRF3c_Length_R2.Series.Clear();
            ChartCRF3c_Length_R2.ChartAreas["ChartAreaCRF3c_Length_R2"].AxisX.MajorGrid.Enabled = false;
            ChartCRF3c_Length_R2.DataBindCrossTable(GetDataCRF3c_Length_R2().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF3c_Length_R2.DataBind();

            ChartCRF3c_Length_R2.Series[0].BorderWidth = 2;
            ChartCRF3c_Length_R2.Series[1].BorderWidth = 2;
            ChartCRF3c_Length_R2.Series[2].BorderWidth = 2;
            ChartCRF3c_Length_R2.Series[3].BorderWidth = 2;
            ChartCRF3c_Length_R2.Series[4].BorderWidth = 2;
            ChartCRF3c_Length_R2.Series[5].BorderWidth = 2;
            //ChartCRF3c_Length_R2.Series[6].BorderWidth = 2;
            //ChartCRF3c_Length_R2.Series[7].BorderWidth = 2;
            ChartCRF3c_Length_R2.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF3c_Length_R2.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF3c_Length_R2.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF3c_Length_R2.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF3c_Length_R2.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF3c_Length_R2.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF3c_Length_R2.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF3c_Length_R2.Series[7].ChartType = SeriesChartType.Line;
        }


        private DataTable GetDataCRF3c_Length_R2()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT reader_code2 as Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from baby_length_crf3c as a where a.baby_length_crf3c_id in ( select max(a.baby_length_crf3c_id) from baby_length_crf3c as a group by a.form_crf_3c_id)) as Ch_Length on Ch_Length.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_17!=''  group by reader_code2,SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from baby_length_crf3c as a where a.baby_length_crf3c_id in ( select max(a.baby_length_crf3c_id) from baby_length_crf3c as a group by a.form_crf_3c_id)) as Ch_Length on Ch_Length.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_17!=''  group by SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1))", con);
            //MySqlCommand cmd = new MySqlCommand("SELECT Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from baby_length_crf3c as a where a.baby_length_crf3c_id in ( select max(a.baby_length_crf3c_id) from baby_length_crf3c as a group by a.form_crf_3c_id)) as Ch_Length on Ch_Length.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_17!=''  group by Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1)", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }












       


        private void LoadChartCRF3c_MUAC_R1()
        {
            ChartCRF3c_MUAC_R1.Series.Clear();
            ChartCRF3c_MUAC_R1.ChartAreas["ChartAreaCRF3c_MUAC_R1"].AxisX.MajorGrid.Enabled = false;
            ChartCRF3c_MUAC_R1.DataBindCrossTable(GetDataCRF3c_MUAC_R1().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF3c_MUAC_R1.DataBind();

            ChartCRF3c_MUAC_R1.Series[0].BorderWidth = 2;
            ChartCRF3c_MUAC_R1.Series[1].BorderWidth = 2;
            ChartCRF3c_MUAC_R1.Series[2].BorderWidth = 2;
            ChartCRF3c_MUAC_R1.Series[3].BorderWidth = 2;
            ChartCRF3c_MUAC_R1.Series[4].BorderWidth = 2;
            ChartCRF3c_MUAC_R1.Series[5].BorderWidth = 2;
            //ChartCRF3c_MUAC_R1.Series[6].BorderWidth = 2;
            //ChartCRF3c_MUAC_R1.Series[7].BorderWidth = 2;
            ChartCRF3c_MUAC_R1.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF3c_MUAC_R1.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF3c_MUAC_R1.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF3c_MUAC_R1.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF3c_MUAC_R1.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF3c_MUAC_R1.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF3c_MUAC_R1.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF3c_MUAC_R1.Series[7].ChartType = SeriesChartType.Line;
        }


        private DataTable GetDataCRF3c_MUAC_R1()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT reader_code1 as  Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from muac_baby_crf3c as a where a.muac_baby_crf3c_id in ( select max(a.muac_baby_crf3c_id) from muac_baby_crf3c as a group by a.form_crf_3c_id)) as muac on muac.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_19!='' and Tab_User!='Ameer'   group by reader_code1,SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from muac_baby_crf3c as a where a.muac_baby_crf3c_id in ( select max(a.muac_baby_crf3c_id) from muac_baby_crf3c as a group by a.form_crf_3c_id)) as muac on muac.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_19!='' and Tab_User!='Ameer'   group by SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1))", con);
            //MySqlCommand cmd = new MySqlCommand("SELECT Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from muac_baby_crf3c as a where a.muac_baby_crf3c_id in ( select max(a.muac_baby_crf3c_id) from muac_baby_crf3c as a group by a.form_crf_3c_id)) as muac on muac.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_19!=''  group by Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1)", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }


        private void LoadChartCRF3c_MUAC_R2()
        {
            ChartCRF3c_MUAC_R2.Series.Clear();
            ChartCRF3c_MUAC_R2.ChartAreas["ChartAreaCRF3c_MUAC_R2"].AxisX.MajorGrid.Enabled = false;
            ChartCRF3c_MUAC_R2.DataBindCrossTable(GetDataCRF3c_MUAC_R2().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF3c_MUAC_R2.DataBind();

            ChartCRF3c_MUAC_R2.Series[0].BorderWidth = 2;
            ChartCRF3c_MUAC_R2.Series[1].BorderWidth = 2;
            ChartCRF3c_MUAC_R2.Series[2].BorderWidth = 2;
            ChartCRF3c_MUAC_R2.Series[3].BorderWidth = 2;
            ChartCRF3c_MUAC_R2.Series[4].BorderWidth = 2;
            ChartCRF3c_MUAC_R2.Series[5].BorderWidth = 2;
            //ChartCRF3c_MUAC_R2.Series[6].BorderWidth = 2;
            //ChartCRF3c_MUAC_R2.Series[7].BorderWidth = 2;
            ChartCRF3c_MUAC_R2.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF3c_MUAC_R2.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF3c_MUAC_R2.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF3c_MUAC_R2.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF3c_MUAC_R2.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF3c_MUAC_R2.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF3c_MUAC_R2.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF3c_MUAC_R2.Series[7].ChartType = SeriesChartType.Line;
        }


        private DataTable GetDataCRF3c_MUAC_R2()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT reader_code2 as  Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from muac_baby_crf3c as a where a.muac_baby_crf3c_id in ( select max(a.muac_baby_crf3c_id) from muac_baby_crf3c as a group by a.form_crf_3c_id)) as muac on muac.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_19!='' and Tab_User!='Ameer'   group by reader_code2,SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from muac_baby_crf3c as a where a.muac_baby_crf3c_id in ( select max(a.muac_baby_crf3c_id) from muac_baby_crf3c as a group by a.form_crf_3c_id)) as muac on muac.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_19!='' and Tab_User!='Ameer'   group by SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1))", con);
            //MySqlCommand cmd = new MySqlCommand("SELECT Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from muac_baby_crf3c as a where a.muac_baby_crf3c_id in ( select max(a.muac_baby_crf3c_id) from muac_baby_crf3c as a group by a.form_crf_3c_id)) as muac on muac.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_19!=''  group by Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1)", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }















        


        private void LoadChartCRF3c_OFHC_R1()
        {
            ChartCRF3c_OFHC_R1.Series.Clear();
            ChartCRF3c_OFHC_R1.ChartAreas["ChartAreaCRF3c_OFHC_R1"].AxisX.MajorGrid.Enabled = false;
            ChartCRF3c_OFHC_R1.DataBindCrossTable(GetDataCRF3c_OFHC_R1().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF3c_OFHC_R1.DataBind();

            ChartCRF3c_OFHC_R1.Series[0].BorderWidth = 2;
            ChartCRF3c_OFHC_R1.Series[1].BorderWidth = 2;
            ChartCRF3c_OFHC_R1.Series[2].BorderWidth = 2;
            ChartCRF3c_OFHC_R1.Series[3].BorderWidth = 2;
            ChartCRF3c_OFHC_R1.Series[4].BorderWidth = 2;
            ChartCRF3c_OFHC_R1.Series[5].BorderWidth = 2;
            //ChartCRF3c_OFHC_R1.Series[6].BorderWidth = 2;
            //ChartCRF3c_OFHC_R1.Series[7].BorderWidth = 2;
            ChartCRF3c_OFHC_R1.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF3c_OFHC_R1.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF3c_OFHC_R1.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF3c_OFHC_R1.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF3c_OFHC_R1.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF3c_OFHC_R1.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF3c_OFHC_R1.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF3c_OFHC_R1.Series[7].ChartType = SeriesChartType.Line;
        }


        private DataTable GetDataCRF3c_OFHC_R1()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT reader_code1 as Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from front_head_circumference_crf3c as a where a.fhc_id in ( select max(a.fhc_id) from front_head_circumference_crf3c as a group by a.form_crf_3c_id)) as OFHC on OFHC.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_21!='' and Tab_User!='Ameer' group by reader_code1,SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from front_head_circumference_crf3c as a where a.fhc_id in ( select max(a.fhc_id) from front_head_circumference_crf3c as a group by a.form_crf_3c_id)) as OFHC on OFHC.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_21!=''   and Tab_User!='Ameer' group by SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1))", con);
            //MySqlCommand cmd = new MySqlCommand("SELECT Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from front_head_circumference_crf3c as a where a.fhc_id in ( select max(a.fhc_id) from front_head_circumference_crf3c as a group by a.form_crf_3c_id)) as OFHC on OFHC.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_21!=''  group by Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1)", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }


        private void LoadChartCRF3c_OFHC_R2()
        {
            ChartCRF3c_OFHC_R2.Series.Clear();
            ChartCRF3c_OFHC_R2.ChartAreas["ChartAreaCRF3c_OFHC_R2"].AxisX.MajorGrid.Enabled = false;
            ChartCRF3c_OFHC_R2.DataBindCrossTable(GetDataCRF3c_OFHC_R2().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF3c_OFHC_R2.DataBind();

            ChartCRF3c_OFHC_R2.Series[0].BorderWidth = 2;
            ChartCRF3c_OFHC_R2.Series[1].BorderWidth = 2;
            ChartCRF3c_OFHC_R2.Series[2].BorderWidth = 2;
            ChartCRF3c_OFHC_R2.Series[3].BorderWidth = 2;
            ChartCRF3c_OFHC_R2.Series[4].BorderWidth = 2;
            ChartCRF3c_OFHC_R2.Series[5].BorderWidth = 2;
            //ChartCRF3c_OFHC_R2.Series[6].BorderWidth = 2;
            //ChartCRF3c_OFHC_R2.Series[7].BorderWidth = 2;
            ChartCRF3c_OFHC_R2.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF3c_OFHC_R2.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF3c_OFHC_R2.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF3c_OFHC_R2.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF3c_OFHC_R2.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF3c_OFHC_R2.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF3c_OFHC_R2.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF3c_OFHC_R2.Series[7].ChartType = SeriesChartType.Line;
        }


        private DataTable GetDataCRF3c_OFHC_R2()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT reader_code2 as Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from front_head_circumference_crf3c as a where a.fhc_id in ( select max(a.fhc_id) from front_head_circumference_crf3c as a group by a.form_crf_3c_id)) as OFHC on OFHC.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_21!='' and Tab_User!='Ameer' group by reader_code2,SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from front_head_circumference_crf3c as a where a.fhc_id in ( select max(a.fhc_id) from front_head_circumference_crf3c as a group by a.form_crf_3c_id)) as OFHC on OFHC.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_21!=''   and Tab_User!='Ameer' group by SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1))", con);

            //MySqlCommand cmd = new MySqlCommand("SELECT Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from front_head_circumference_crf3c as a where a.fhc_id in ( select max(a.fhc_id) from front_head_circumference_crf3c as a group by a.form_crf_3c_id)) as OFHC on OFHC.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_21!=''  group by Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1)", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }




















        private void LoadChartCRF3c_LW_Weight_R1()
        {
            ChartCRF3c_LW_Weight_R1.Series.Clear();
            ChartCRF3c_LW_Weight_R1.ChartAreas["ChartAreaCRF3c_LW_Weight_R1"].AxisX.MajorGrid.Enabled = false;
            ChartCRF3c_LW_Weight_R1.DataBindCrossTable(GetDataCRF3c_LW_Weight_R1().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF3c_LW_Weight_R1.DataBind();

            ChartCRF3c_LW_Weight_R1.Series[0].BorderWidth = 2;
            ChartCRF3c_LW_Weight_R1.Series[1].BorderWidth = 2;
            ChartCRF3c_LW_Weight_R1.Series[2].BorderWidth = 2;
            ChartCRF3c_LW_Weight_R1.Series[3].BorderWidth = 2;
            ChartCRF3c_LW_Weight_R1.Series[4].BorderWidth = 2;
            ChartCRF3c_LW_Weight_R1.Series[5].BorderWidth = 2;
            //ChartCRF3c_LW_Weight_R1.Series[6].BorderWidth = 2;
            //ChartCRF3c_LW_Weight_R1.Series[7].BorderWidth = 2;
            ChartCRF3c_LW_Weight_R1.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Weight_R1.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Weight_R1.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Weight_R1.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Weight_R1.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Weight_R1.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF3c_LW_Weight_R1.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF3c_LW_Weight_R1.Series[7].ChartType = SeriesChartType.Line;
        }


        private DataTable GetDataCRF3c_LW_Weight_R1()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT reader_code1 as  Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from weight_lw_crf3c as a where a.weight_lw_crf3c_id in ( select max(a.weight_lw_crf3c_id) from weight_lw_crf3c as a group by a.form_crf_3c_id)) as LW_Weight on LW_Weight.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_23!='' and Tab_User!='Ameer' group by reader_code1,SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from weight_lw_crf3c as a where a.weight_lw_crf3c_id in ( select max(a.weight_lw_crf3c_id) from weight_lw_crf3c as a group by a.form_crf_3c_id)) as LW_Weight on LW_Weight.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_23!=''   and Tab_User!='Ameer' group by SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1))", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }


        private void LoadChartCRF3c_LW_Weight_R2()
        {
            ChartCRF3c_LW_Weight_R2.Series.Clear();
            ChartCRF3c_LW_Weight_R2.ChartAreas["ChartAreaCRF3c_LW_Weight_R2"].AxisX.MajorGrid.Enabled = false;
            ChartCRF3c_LW_Weight_R2.DataBindCrossTable(GetDataCRF3c_LW_Weight_R2().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF3c_LW_Weight_R2.DataBind();

            ChartCRF3c_LW_Weight_R2.Series[0].BorderWidth = 2;
            ChartCRF3c_LW_Weight_R2.Series[1].BorderWidth = 2;
            ChartCRF3c_LW_Weight_R2.Series[2].BorderWidth = 2;
            ChartCRF3c_LW_Weight_R2.Series[3].BorderWidth = 2;
            ChartCRF3c_LW_Weight_R2.Series[4].BorderWidth = 2;
            ChartCRF3c_LW_Weight_R2.Series[5].BorderWidth = 2;
            //ChartCRF3c_LW_Weight_R2.Series[6].BorderWidth = 2;
            //ChartCRF3c_LW_Weight_R2.Series[7].BorderWidth = 2;
            ChartCRF3c_LW_Weight_R2.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Weight_R2.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Weight_R2.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Weight_R2.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Weight_R2.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Weight_R2.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF3c_LW_Weight_R2.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF3c_LW_Weight_R2.Series[7].ChartType = SeriesChartType.Line;
        }


        private DataTable GetDataCRF3c_LW_Weight_R2()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT reader_code2 as Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from weight_lw_crf3c as a where a.weight_lw_crf3c_id in ( select max(a.weight_lw_crf3c_id) from weight_lw_crf3c as a group by a.form_crf_3c_id)) as LW_Weight on LW_Weight.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_23!='' and Tab_User!='Ameer' group by reader_code2,SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from weight_lw_crf3c as a where a.weight_lw_crf3c_id in ( select max(a.weight_lw_crf3c_id) from weight_lw_crf3c as a group by a.form_crf_3c_id)) as LW_Weight on LW_Weight.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_23!=''   and Tab_User!='Ameer' group by SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1))", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }





     


        private void LoadChartCRF3c_LW_Height_R1()
        {
            ChartCRF3c_LW_Height_R1.Series.Clear();
            ChartCRF3c_LW_Height_R1.ChartAreas["ChartAreaCRF3c_LW_Height_R1"].AxisX.MajorGrid.Enabled = false;
            ChartCRF3c_LW_Height_R1.DataBindCrossTable(GetDataCRF3c_LW_Height_R1().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF3c_LW_Height_R1.DataBind();

            ChartCRF3c_LW_Height_R1.Series[0].BorderWidth = 2;
            ChartCRF3c_LW_Height_R1.Series[1].BorderWidth = 2;
            ChartCRF3c_LW_Height_R1.Series[2].BorderWidth = 2;
            ChartCRF3c_LW_Height_R1.Series[3].BorderWidth = 2;
            ChartCRF3c_LW_Height_R1.Series[4].BorderWidth = 2;
            ChartCRF3c_LW_Height_R1.Series[5].BorderWidth = 2;
            //ChartCRF3c_LW_Height_R1.Series[6].BorderWidth = 2;
            //ChartCRF3c_LW_Height_R1.Series[7].BorderWidth = 2;
            ChartCRF3c_LW_Height_R1.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Height_R1.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Height_R1.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Height_R1.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Height_R1.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Height_R1.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF3c_LW_Height_R1.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF3c_LW_Height_R1.Series[7].ChartType = SeriesChartType.Line;
        }


        private DataTable GetDataCRF3c_LW_Height_R1()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT reader_code1 as Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from height_lw_crf3c as a where a.height_lw_crf3c_id in ( select max(a.height_lw_crf3c_id) from height_lw_crf3c as a group by a.form_crf_3c_id)) as LW_Height on LW_Height.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_25!='' and Tab_User!='Ameer' group by reader_code1,SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from height_lw_crf3c as a where a.height_lw_crf3c_id in ( select max(a.height_lw_crf3c_id) from height_lw_crf3c as a group by a.form_crf_3c_id)) as LW_Height on LW_Height.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_25!=''   and Tab_User!='Ameer' group by SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1))", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }


        private void LoadChartCRF3c_LW_Height_R2()
        {
            ChartCRF3c_LW_Height_R2.Series.Clear();
            ChartCRF3c_LW_Height_R2.ChartAreas["ChartAreaCRF3c_LW_Height_R2"].AxisX.MajorGrid.Enabled = false;
            ChartCRF3c_LW_Height_R2.DataBindCrossTable(GetDataCRF3c_LW_Height_R2().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF3c_LW_Height_R2.DataBind();

            ChartCRF3c_LW_Height_R2.Series[0].BorderWidth = 2;
            ChartCRF3c_LW_Height_R2.Series[1].BorderWidth = 2;
            ChartCRF3c_LW_Height_R2.Series[2].BorderWidth = 2;
            ChartCRF3c_LW_Height_R2.Series[3].BorderWidth = 2;
            ChartCRF3c_LW_Height_R2.Series[4].BorderWidth = 2;
            ChartCRF3c_LW_Height_R2.Series[5].BorderWidth = 2;
            //ChartCRF3c_LW_Height_R2.Series[6].BorderWidth = 2;
            //ChartCRF3c_LW_Height_R2.Series[7].BorderWidth = 2;
            ChartCRF3c_LW_Height_R2.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Height_R2.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Height_R2.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Height_R2.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Height_R2.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_Height_R2.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF3c_LW_Height_R2.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF3c_LW_Height_R2.Series[7].ChartType = SeriesChartType.Line;
        }


        private DataTable GetDataCRF3c_LW_Height_R2()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT reader_code2 as  Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from height_lw_crf3c as a where a.height_lw_crf3c_id in ( select max(a.height_lw_crf3c_id) from height_lw_crf3c as a group by a.form_crf_3c_id)) as LW_Height on LW_Height.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_25!='' and Tab_User!='Ameer' group by reader_code2,SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from height_lw_crf3c as a where a.height_lw_crf3c_id in ( select max(a.height_lw_crf3c_id) from height_lw_crf3c as a group by a.form_crf_3c_id)) as LW_Height on LW_Height.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_25!=''   and Tab_User!='Ameer' group by SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1))", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }













      


        private void LoadChartCRF3c_LW_MUAC_R1()
        {
            ChartCRF3c_LW_MUAC_R1.Series.Clear();
            ChartCRF3c_LW_MUAC_R1.ChartAreas["ChartAreaCRF3c_LW_MUAC_R1"].AxisX.MajorGrid.Enabled = false;
            ChartCRF3c_LW_MUAC_R1.DataBindCrossTable(GetDataCRF3c_LW_MUAC_R1().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF3c_LW_MUAC_R1.DataBind();

            ChartCRF3c_LW_MUAC_R1.Series[0].BorderWidth = 2;
            ChartCRF3c_LW_MUAC_R1.Series[1].BorderWidth = 2;
            ChartCRF3c_LW_MUAC_R1.Series[2].BorderWidth = 2;
            ChartCRF3c_LW_MUAC_R1.Series[3].BorderWidth = 2;
            ChartCRF3c_LW_MUAC_R1.Series[4].BorderWidth = 2;
            ChartCRF3c_LW_MUAC_R1.Series[5].BorderWidth = 2;
            //ChartCRF3c_LW_MUAC_R1.Series[6].BorderWidth = 2;
            //ChartCRF3c_LW_MUAC_R1.Series[7].BorderWidth = 2;
            ChartCRF3c_LW_MUAC_R1.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_MUAC_R1.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_MUAC_R1.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_MUAC_R1.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_MUAC_R1.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_MUAC_R1.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF3c_LW_MUAC_R1.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF3c_LW_MUAC_R1.Series[7].ChartType = SeriesChartType.Line;
        }


        private DataTable GetDataCRF3c_LW_MUAC_R1()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT reader_code1 as Tab_User,SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from muac_lw_crf3c as a where a.muac_lw_crf3c_id in ( select max(a.muac_lw_crf3c_id) from muac_lw_crf3c as a group by a.form_crf_3c_id)) as LW_MUAC on LW_MUAC.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_27!='' and Tab_User!='Ameer' group by reader_code1,SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader1,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader1,1),'.', -1)) as Total FROM view_crf3c left join (select * from muac_lw_crf3c as a where a.muac_lw_crf3c_id in ( select max(a.muac_lw_crf3c_id) from muac_lw_crf3c as a group by a.form_crf_3c_id)) as LW_MUAC on LW_MUAC.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_27!=''   and Tab_User!='Ameer' group by SUBSTRING_INDEX(format(reader1,1),'.', -1) order by SUBSTRING_INDEX(format(reader1,1),'.', -1))", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }


        private void LoadChartCRF3c_LW_MUAC_R2()
        {
            ChartCRF3c_LW_MUAC_R2.Series.Clear();
            ChartCRF3c_LW_MUAC_R2.ChartAreas["ChartAreaCRF3c_LW_MUAC_R2"].AxisX.MajorGrid.Enabled = false;
            ChartCRF3c_LW_MUAC_R2.DataBindCrossTable(GetDataCRF3c_LW_MUAC_R2().DefaultView, "Tab_User", "digit_Preference", "Total", "Label=Total");
            ChartCRF3c_LW_MUAC_R2.DataBind();

            ChartCRF3c_LW_MUAC_R2.Series[0].BorderWidth = 2;
            ChartCRF3c_LW_MUAC_R2.Series[1].BorderWidth = 2;
            ChartCRF3c_LW_MUAC_R2.Series[2].BorderWidth = 2;
            ChartCRF3c_LW_MUAC_R2.Series[3].BorderWidth = 2;
            ChartCRF3c_LW_MUAC_R2.Series[4].BorderWidth = 2;
            ChartCRF3c_LW_MUAC_R2.Series[5].BorderWidth = 2;
            //ChartCRF3c_LW_MUAC_R2.Series[6].BorderWidth = 2;
            //ChartCRF3c_LW_MUAC_R2.Series[7].BorderWidth = 2;
            ChartCRF3c_LW_MUAC_R2.Series[0].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_MUAC_R2.Series[1].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_MUAC_R2.Series[2].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_MUAC_R2.Series[3].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_MUAC_R2.Series[4].ChartType = SeriesChartType.Line;
            ChartCRF3c_LW_MUAC_R2.Series[5].ChartType = SeriesChartType.Line;
            //ChartCRF3c_LW_MUAC_R2.Series[6].ChartType = SeriesChartType.Line;
            //ChartCRF3c_LW_MUAC_R2.Series[7].ChartType = SeriesChartType.Line;
        }


        private DataTable GetDataCRF3c_LW_MUAC_R2()
        {
            MySqlConnection con = new MySqlConnection(constr);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("(SELECT reader_code2 as  Tab_User,SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from muac_lw_crf3c as a where a.muac_lw_crf3c_id in ( select max(a.muac_lw_crf3c_id) from muac_lw_crf3c as a group by a.form_crf_3c_id)) as LW_MUAC on LW_MUAC.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_27!='' and Tab_User!='Ameer' group by reader_code2,SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1)) union all (SELECT 'Cumulative',SUBSTRING_INDEX(format(reader2,1),'.', -1) as digit_Preference, count(SUBSTRING_INDEX(format(reader2,1),'.', -1)) as Total FROM view_crf3c left join (select * from muac_lw_crf3c as a where a.muac_lw_crf3c_id in ( select max(a.muac_lw_crf3c_id) from muac_lw_crf3c as a group by a.form_crf_3c_id)) as LW_MUAC on LW_MUAC.form_crf_3c_id= view_crf3c.form_crf_3c_id where view_crf3c.lw_crf3c_27!=''   and Tab_User!='Ameer' group by SUBSTRING_INDEX(format(reader2,1),'.', -1) order by SUBSTRING_INDEX(format(reader2,1),'.', -1))", con);
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                return dtData;
                con.Close();
            }
            con.Close();
        }

    }
}