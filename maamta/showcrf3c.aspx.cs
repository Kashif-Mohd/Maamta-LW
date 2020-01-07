using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class showcrf3c : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateFormatPageLoad();
                Session["WebForm"] = "showcrf3c";
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


        private void DateFormatPageLoad()
        {
            txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate.Attributes.Add("readonly", "readonly");
            txtCalndrDate1.Attributes.Add("readonly", "readonly");
            txtCalndrDate.Enabled = false;
            txtCalndrDate1.Enabled = false;
            CheckBox1.Checked = true;
        }


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtCalndrDate.Enabled = !CheckBox1.Checked;
            txtCalndrDate1.Enabled = !CheckBox1.Checked;
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
                if (CheckBox1.Checked == false)
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select a.*,h.reader_code1, h.reader_code2, h.reader1  as BabyWeight_R1, h.reader2  as BabyWeight_R2,	b.reader1 as BabyLength_R1, b.reader2 as BabyLength_R2,		 c.reader1  as BabyMUAC_R1, c.reader2  as BabyMUAC_R2, d.reader1  as BabyOFHC_R1, d.reader2  as BabyOFHC_R2, e.reader1  as LW_Weight_R1, e.reader2  as LW_Weight_R2, f.reader1  as LW_Height_R1, f.reader2  as LW_Height_R2, g.reader1  as LW_MUAC_R1, g.reader2  as LW_MUAC_R2      from view_crf3c as a           left join (select * from child_weight_crf3c where child_weight_crf3c_id in ( select max(child_weight_crf3c_id) from child_weight_crf3c group by form_crf_3c_id)) as h on a.form_crf_3c_id=h.form_crf_3c_id left join(select * from baby_length_crf3c where baby_length_crf3c_id in ( select max(baby_length_crf3c_id) from baby_length_crf3c group by form_crf_3c_id)) as b on a.form_crf_3c_id=b.form_crf_3c_id left join (select * from muac_baby_crf3c where muac_baby_crf3c_id in ( select max(muac_baby_crf3c_id) from muac_baby_crf3c group by form_crf_3c_id)) as c on a.form_crf_3c_id=c.form_crf_3c_id  left join (select * from front_head_circumference_crf3c where fhc_id in ( select max(fhc_id) from front_head_circumference_crf3c group by form_crf_3c_id)) as d on a.form_crf_3c_id=d.form_crf_3c_id  left join (select * from weight_lw_crf3c where weight_lw_crf3c_id in ( select max(weight_lw_crf3c_id) from weight_lw_crf3c group by form_crf_3c_id)) as e on a.form_crf_3c_id=e.form_crf_3c_id  left join (select * from height_lw_crf3c where height_lw_crf3c_id in ( select max(height_lw_crf3c_id) from height_lw_crf3c group by form_crf_3c_id)) as f on a.form_crf_3c_id=f.form_crf_3c_id  left join (select * from muac_lw_crf3c where muac_lw_crf3c_id in ( select max(muac_lw_crf3c_id) from muac_lw_crf3c group by form_crf_3c_id)) as g on a.form_crf_3c_id=g.form_crf_3c_id WHERE           a.DSSID LIKE '%" + txtdssid.Text + "%'  and (str_to_date(a.lw_crf3c_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  order by a.form_crf_3c_id", con);
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
                    cmd = new MySqlCommand("select a.*,h.reader_code1, h.reader_code2, h.reader1  as BabyWeight_R1, h.reader2  as BabyWeight_R2,	b.reader1 as BabyLength_R1, b.reader2 as BabyLength_R2,		 c.reader1  as BabyMUAC_R1, c.reader2  as BabyMUAC_R2, d.reader1  as BabyOFHC_R1, d.reader2  as BabyOFHC_R2, e.reader1  as LW_Weight_R1, e.reader2  as LW_Weight_R2, f.reader1  as LW_Height_R1, f.reader2  as LW_Height_R2, g.reader1  as LW_MUAC_R1, g.reader2  as LW_MUAC_R2  from view_crf3c as a           left join (select * from child_weight_crf3c where child_weight_crf3c_id in ( select max(child_weight_crf3c_id) from child_weight_crf3c group by form_crf_3c_id)) as h on a.form_crf_3c_id=h.form_crf_3c_id left join(select * from baby_length_crf3c where baby_length_crf3c_id in ( select max(baby_length_crf3c_id) from baby_length_crf3c group by form_crf_3c_id)) as b on a.form_crf_3c_id=b.form_crf_3c_id left join (select * from muac_baby_crf3c where muac_baby_crf3c_id in ( select max(muac_baby_crf3c_id) from muac_baby_crf3c group by form_crf_3c_id)) as c on a.form_crf_3c_id=c.form_crf_3c_id  left join (select * from front_head_circumference_crf3c where fhc_id in ( select max(fhc_id) from front_head_circumference_crf3c group by form_crf_3c_id)) as d on a.form_crf_3c_id=d.form_crf_3c_id  left join (select * from weight_lw_crf3c where weight_lw_crf3c_id in ( select max(weight_lw_crf3c_id) from weight_lw_crf3c group by form_crf_3c_id)) as e on a.form_crf_3c_id=e.form_crf_3c_id  left join (select * from height_lw_crf3c where height_lw_crf3c_id in ( select max(height_lw_crf3c_id) from height_lw_crf3c group by form_crf_3c_id)) as f on a.form_crf_3c_id=f.form_crf_3c_id  left join (select * from muac_lw_crf3c where muac_lw_crf3c_id in ( select max(muac_lw_crf3c_id) from muac_lw_crf3c group by form_crf_3c_id)) as g on a.form_crf_3c_id=g.form_crf_3c_id             WHERE a.DSSID LIKE '%" + txtdssid.Text + "%' order by a.form_crf_3c_id", con);
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
            ShowData();
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
            //else if (DropDownList1.SelectedValue == "1")
            //{
            //    GridView2.Caption = "MUAC Less than 24";
            //}
            //else if (DropDownList1.SelectedValue == "2")
            //{
            //    GridView2.Caption = "MUAC Greater than and Equal to 24";
            //}
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
                if (CheckBox1.Checked == false)
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select a.*,h.reader_code1, h.reader_code2, h.reader1  as BabyWeight_R1, h.reader2  as BabyWeight_R2,	b.reader1 as BabyLength_R1, b.reader2 as BabyLength_R2,		 c.reader1  as BabyMUAC_R1, c.reader2  as BabyMUAC_R2, d.reader1  as BabyOFHC_R1, d.reader2  as BabyOFHC_R2, e.reader1  as LW_Weight_R1, e.reader2  as LW_Weight_R2, f.reader1  as LW_Height_R1, f.reader2  as LW_Height_R2, g.reader1  as LW_MUAC_R1, g.reader2  as LW_MUAC_R2      from view_crf3c as a           left join (select * from child_weight_crf3c where child_weight_crf3c_id in ( select max(child_weight_crf3c_id) from child_weight_crf3c group by form_crf_3c_id)) as h on a.form_crf_3c_id=h.form_crf_3c_id left join(select * from baby_length_crf3c where baby_length_crf3c_id in ( select max(baby_length_crf3c_id) from baby_length_crf3c group by form_crf_3c_id)) as b on a.form_crf_3c_id=b.form_crf_3c_id left join (select * from muac_baby_crf3c where muac_baby_crf3c_id in ( select max(muac_baby_crf3c_id) from muac_baby_crf3c group by form_crf_3c_id)) as c on a.form_crf_3c_id=c.form_crf_3c_id  left join (select * from front_head_circumference_crf3c where fhc_id in ( select max(fhc_id) from front_head_circumference_crf3c group by form_crf_3c_id)) as d on a.form_crf_3c_id=d.form_crf_3c_id  left join (select * from weight_lw_crf3c where weight_lw_crf3c_id in ( select max(weight_lw_crf3c_id) from weight_lw_crf3c group by form_crf_3c_id)) as e on a.form_crf_3c_id=e.form_crf_3c_id  left join (select * from height_lw_crf3c where height_lw_crf3c_id in ( select max(height_lw_crf3c_id) from height_lw_crf3c group by form_crf_3c_id)) as f on a.form_crf_3c_id=f.form_crf_3c_id  left join (select * from muac_lw_crf3c where muac_lw_crf3c_id in ( select max(muac_lw_crf3c_id) from muac_lw_crf3c group by form_crf_3c_id)) as g on a.form_crf_3c_id=g.form_crf_3c_id            WHERE a.DSSID LIKE '%" + txtdssid.Text + "%'  and (str_to_date(a.lw_crf3c_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  order by a.form_crf_3c_id", con);
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
                    cmd = new MySqlCommand("select a.*,h.reader_code1, h.reader_code2, h.reader1  as BabyWeight_R1, h.reader2  as BabyWeight_R2,	b.reader1 as BabyLength_R1, b.reader2 as BabyLength_R2,		 c.reader1  as BabyMUAC_R1, c.reader2  as BabyMUAC_R2, d.reader1  as BabyOFHC_R1, d.reader2  as BabyOFHC_R2, e.reader1  as LW_Weight_R1, e.reader2  as LW_Weight_R2, f.reader1  as LW_Height_R1, f.reader2  as LW_Height_R2, g.reader1  as LW_MUAC_R1, g.reader2  as LW_MUAC_R2  from view_crf3c as a           left join (select * from child_weight_crf3c where child_weight_crf3c_id in ( select max(child_weight_crf3c_id) from child_weight_crf3c group by form_crf_3c_id)) as h on a.form_crf_3c_id=h.form_crf_3c_id left join(select * from baby_length_crf3c where baby_length_crf3c_id in ( select max(baby_length_crf3c_id) from baby_length_crf3c group by form_crf_3c_id)) as b on a.form_crf_3c_id=b.form_crf_3c_id left join (select * from muac_baby_crf3c where muac_baby_crf3c_id in ( select max(muac_baby_crf3c_id) from muac_baby_crf3c group by form_crf_3c_id)) as c on a.form_crf_3c_id=c.form_crf_3c_id  left join (select * from front_head_circumference_crf3c where fhc_id in ( select max(fhc_id) from front_head_circumference_crf3c group by form_crf_3c_id)) as d on a.form_crf_3c_id=d.form_crf_3c_id  left join (select * from weight_lw_crf3c where weight_lw_crf3c_id in ( select max(weight_lw_crf3c_id) from weight_lw_crf3c group by form_crf_3c_id)) as e on a.form_crf_3c_id=e.form_crf_3c_id  left join (select * from height_lw_crf3c where height_lw_crf3c_id in ( select max(height_lw_crf3c_id) from height_lw_crf3c group by form_crf_3c_id)) as f on a.form_crf_3c_id=f.form_crf_3c_id  left join (select * from muac_lw_crf3c where muac_lw_crf3c_id in ( select max(muac_lw_crf3c_id) from muac_lw_crf3c group by form_crf_3c_id)) as g on a.form_crf_3c_id=g.form_crf_3c_id         WHERE a.DSSID LIKE '%" + txtdssid.Text + "%' order by a.form_crf_3c_id", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=RANDOM CRF3c (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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





        protected void Link_StudyID(object sender, EventArgs e)
        {
            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            string form_crf_3c_id = commandArgs[0];
            string study_code = commandArgs[1];

            Session["form_crf_3c_id"] = form_crf_3c_id;
            Session["StudyIdCRF3c"] = study_code;
            // Session["BackButton"] = "showcrf3b";
            Response.Redirect("showcrf3cbyid.aspx");
        }















        protected void btnBMGF_Click(object sender, EventArgs e)
        {
            ExcelExportBMGF();
            txtdssid.Focus();
        }

        private void ExportdataBMGF()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("SELECT c.assis_id AS q1,b.study_code AS q2,a.lw_crf3c_2 AS q3,a.lw_crf3c_3 AS q4,	hh.reader_code1 AS q5, hh.reader_code2 AS q6, hh.reader1  AS q7_a, hh.reader2  AS q7_b,	a.lw_crf3c_15 AS q8,			bb.reader1 AS q9_a, bb.reader2 AS q9_b,	a.lw_crf3c_17 AS q10,	 cc.reader1  AS q11_a, cc.reader2  AS q11_b,a.lw_crf3c_19 AS q12, dd.reader1  AS q13_a, dd.reader2  AS q13_b,a.lw_crf3c_21 AS q14, ee.reader1  AS q15_a, ee.reader2  AS q15_b,	a.lw_crf3c_23 AS q16, ff.reader1  AS q17_a, ff.reader2  AS q17_b, a.lw_crf3c_25 AS q18, gg.reader1  AS q19_a, gg.reader2  AS q19_b,a.lw_crf3c_27 AS q20,	(CASE    WHEN a.lw_crf3c_28 LIKE '%a%' THEN '44'    WHEN a.lw_crf3c_28 LIKE '%b%' THEN '55'    WHEN a.lw_crf3c_28 LIKE '%c%' THEN '66' END)  AS q21,    a.lw_crf3c_29 AS q22, a.lw_crf3c_30 AS q23, a.lw_crf3c_32 AS q24, a.lw_crf3c_33 AS q25,		a.lw_crf3c_40 AS q26		FROM form_crf_3c AS a INNER JOIN studies AS b ON a.study_id=b.study_id INNER JOIN pw AS c ON b.assis_id=c.id 		       				     LEFT JOIN (SELECT * FROM child_weight_crf3c WHERE child_weight_crf3c_id IN ( SELECT MAX(child_weight_crf3c_id) FROM child_weight_crf3c GROUP BY form_crf_3c_id)) AS hh ON a.form_crf_3c_id=hh.form_crf_3c_id LEFT JOIN(SELECT * FROM baby_length_crf3c WHERE baby_length_crf3c_id IN ( SELECT MAX(baby_length_crf3c_id) FROM baby_length_crf3c GROUP BY form_crf_3c_id)) AS bb ON a.form_crf_3c_id=bb.form_crf_3c_id LEFT JOIN (SELECT * FROM muac_baby_crf3c WHERE muac_baby_crf3c_id IN ( SELECT MAX(muac_baby_crf3c_id) FROM muac_baby_crf3c GROUP BY form_crf_3c_id)) AS cc ON a.form_crf_3c_id=cc.form_crf_3c_id  LEFT JOIN (SELECT * FROM front_head_circumference_crf3c WHERE fhc_id IN ( SELECT MAX(fhc_id) FROM front_head_circumference_crf3c GROUP BY form_crf_3c_id)) AS dd ON a.form_crf_3c_id=dd.form_crf_3c_id  LEFT JOIN (SELECT * FROM weight_lw_crf3c WHERE weight_lw_crf3c_id IN ( SELECT MAX(weight_lw_crf3c_id) FROM weight_lw_crf3c GROUP BY form_crf_3c_id)) AS ee ON a.form_crf_3c_id=ee.form_crf_3c_id  LEFT JOIN (SELECT * FROM height_lw_crf3c WHERE height_lw_crf3c_id IN ( SELECT MAX(height_lw_crf3c_id) FROM height_lw_crf3c GROUP BY form_crf_3c_id)) AS ff ON a.form_crf_3c_id=ff.form_crf_3c_id  LEFT JOIN (SELECT * FROM muac_lw_crf3c WHERE muac_lw_crf3c_id IN ( SELECT MAX(muac_lw_crf3c_id) FROM muac_lw_crf3c GROUP BY form_crf_3c_id)) AS gg ON a.form_crf_3c_id=gg.form_crf_3c_id;", con);
                //cmd = new MySqlCommand("select c.assis_id as Q1,b.study_code as Q2,a.lw_crf3c_2 as Q3D,a.lw_crf3c_3 as Q3T,	hh.reader_code1 as Q27_CRF2, hh.reader_code2 as Q28_CRF2, hh.reader1  as Q33_a_CRF2, hh.reader2  as Q33_b_CRF2,	a.lw_crf3c_15 as Q34_CRF2,			bb.reader1 as Q16_A, bb.reader2 as Q16_B,	a.lw_crf3c_17 as Q17,	 cc.reader1  as Q18_A, cc.reader2  as Q18_B,a.lw_crf3c_19 as Q19, dd.reader1  as Q20_A, dd.reader2  as Q20_B,a.lw_crf3c_21 as Q21, ee.reader1  as Q22_A, ee.reader2  as Q22_B,	a.lw_crf3c_23 as Q23, ff.reader1  as Q24_A, ff.reader2  as Q24_B, a.lw_crf3c_25 as Q25, gg.reader1  as Q29_a_CRF2, gg.reader2  as Q29_b_CRF2 ,a.lw_crf3c_27 as Q30_CRF2,	(CASE    WHEN a.lw_crf3c_28 like '%a%' THEN '44'    WHEN a.lw_crf3c_28 like '%b%' THEN '55'    WHEN a.lw_crf3c_28 like '%c%' THEN '66' END)  as Q28,    a.lw_crf3c_29 as Q29, a.lw_crf3c_30 as Q30, a.lw_crf3c_32 as Q32, a.lw_crf3c_33 as Q33,		a.lw_crf3c_40 as Q34                             from form_crf_3c as a inner join studies as b on a.study_id=b.study_id inner join pw as c on b.assis_id=c.id 		       				     left join (select * from child_weight_crf3c where child_weight_crf3c_id in ( select max(child_weight_crf3c_id) from child_weight_crf3c group by form_crf_3c_id)) as hh on a.form_crf_3c_id=hh.form_crf_3c_id left join(select * from baby_length_crf3c where baby_length_crf3c_id in ( select max(baby_length_crf3c_id) from baby_length_crf3c group by form_crf_3c_id)) as bb on a.form_crf_3c_id=bb.form_crf_3c_id left join (select * from muac_baby_crf3c where muac_baby_crf3c_id in ( select max(muac_baby_crf3c_id) from muac_baby_crf3c group by form_crf_3c_id)) as cc on a.form_crf_3c_id=cc.form_crf_3c_id  left join (select * from front_head_circumference_crf3c where fhc_id in ( select max(fhc_id) from front_head_circumference_crf3c group by form_crf_3c_id)) as dd on a.form_crf_3c_id=dd.form_crf_3c_id  left join (select * from weight_lw_crf3c where weight_lw_crf3c_id in ( select max(weight_lw_crf3c_id) from weight_lw_crf3c group by form_crf_3c_id)) as ee on a.form_crf_3c_id=ee.form_crf_3c_id  left join (select * from height_lw_crf3c where height_lw_crf3c_id in ( select max(height_lw_crf3c_id) from height_lw_crf3c group by form_crf_3c_id)) as ff on a.form_crf_3c_id=ff.form_crf_3c_id  left join (select * from muac_lw_crf3c where muac_lw_crf3c_id in ( select max(muac_lw_crf3c_id) from muac_lw_crf3c group by form_crf_3c_id)) as gg on a.form_crf_3c_id=gg.form_crf_3c_id;", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridViewBMFG.DataSource = dt;
                        GridViewBMFG.DataBind();
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




        public void ExcelExportBMGF()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=BMFG CRF3c (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridViewBMFG.AllowPaging = false;
                ExcelExportMessage();
                GridViewBMFG.CaptionAlign = TableCaptionAlign.Top;

                ExportdataBMGF();
                for (int i = 0; i < GridViewBMFG.HeaderRow.Cells.Count; i++)
                {
                    GridViewBMFG.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridViewBMFG.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridViewBMFG.RenderControl(htmlWrite);
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