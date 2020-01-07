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
    public partial class showcrf6 : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateFormatPageLoad();
                Session["WebForm"] = "showcrf6";
                ShowData();
                txtdssid.Focus();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
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
                if (CheckBox1.Checked == false)
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select a.*,b.reader_code1 as code1,b.reader_code2 as code2, b.reader1  as BabyLength_R1,	b.reader2  as BabyLength_R2 ,	c.reader1  as BabyMUAC_R1,	c.reader2  as BabyMUAC_R2 ,	d.reader1  as BabyOFHC_R1,	d.reader2  as BabyOFHC_R2 ,	e.reader1  as LW_Weight_R1,	e.reader2  as LW_Weight_R2 ,	f.reader1  as LW_MUAC_R1,	f.reader2  as LW_MUAC_R2 ,	g.reader1  as BabyWeight_R1,	g.reader2  as BabyWeight_R2 from view_crf6 as a	                	left join(select * from baby_length_crf6 where baby_length_crf6_id in ( select max(baby_length_crf6_id) from baby_length_crf6 group by form_crf_6_id)) as b on a.form_crf_6_id=b.form_crf_6_id		left join (select * from muac_baby_crf6 where muac_baby_crf6_id in ( select max(muac_baby_crf6_id) from muac_baby_crf6 group by form_crf_6_id)) as c on a.form_crf_6_id=c.form_crf_6_id		left join (select * from occipito_frontal_head_crf6 where occipito_frontal_head_crf6_id in ( select max(occipito_frontal_head_crf6_id) from occipito_frontal_head_crf6 group by form_crf_6_id)) as d on a.form_crf_6_id=d.form_crf_6_id		left join (select * from weight_lw_crf6 where weight_lw_crf6_id in ( select max(weight_lw_crf6_id) from weight_lw_crf6 group by form_crf_6_id)) as e on a.form_crf_6_id=e.form_crf_6_id		left join (select * from muac_lw_crf6 where muac_lw_crf6_id in ( select max(muac_lw_crf6_id) from muac_lw_crf6 group by form_crf_6_id)) as f on a.form_crf_6_id=f.form_crf_6_id		left join (select * from child_weight_crf6 where child_weight_crf6_id in ( select max(child_weight_crf6_id) from child_weight_crf6 group by form_crf_6_id)) as g on a.form_crf_6_id=g.form_crf_6_id WHERE a.DSSID LIKE '%" + txtdssid.Text + "%' and (str_to_date(a.lw_crf6_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  order by str_to_date(a.lw_crf6_2, '%d-%m-%Y'), STR_TO_DATE(a.lw_crf6_3,  '%H:%i')", con);
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
                    cmd = new MySqlCommand("select a.*,b.reader_code1 as code1,b.reader_code2 as code2, b.reader1  as BabyLength_R1,	b.reader2  as BabyLength_R2 ,	c.reader1  as BabyMUAC_R1,	c.reader2  as BabyMUAC_R2 ,	d.reader1  as BabyOFHC_R1,	d.reader2  as BabyOFHC_R2 ,	e.reader1  as LW_Weight_R1,	e.reader2  as LW_Weight_R2 ,	f.reader1  as LW_MUAC_R1,	f.reader2  as LW_MUAC_R2 ,	g.reader1  as BabyWeight_R1,	g.reader2  as BabyWeight_R2 from view_crf6 as a             	    	left join(select * from baby_length_crf6 where baby_length_crf6_id in ( select max(baby_length_crf6_id) from baby_length_crf6 group by form_crf_6_id)) as b on a.form_crf_6_id=b.form_crf_6_id		left join (select * from muac_baby_crf6 where muac_baby_crf6_id in ( select max(muac_baby_crf6_id) from muac_baby_crf6 group by form_crf_6_id)) as c on a.form_crf_6_id=c.form_crf_6_id		left join (select * from occipito_frontal_head_crf6 where occipito_frontal_head_crf6_id in ( select max(occipito_frontal_head_crf6_id) from occipito_frontal_head_crf6 group by form_crf_6_id)) as d on a.form_crf_6_id=d.form_crf_6_id		left join (select * from weight_lw_crf6 where weight_lw_crf6_id in ( select max(weight_lw_crf6_id) from weight_lw_crf6 group by form_crf_6_id)) as e on a.form_crf_6_id=e.form_crf_6_id		left join (select * from muac_lw_crf6 where muac_lw_crf6_id in ( select max(muac_lw_crf6_id) from muac_lw_crf6 group by form_crf_6_id)) as f on a.form_crf_6_id=f.form_crf_6_id		left join (select * from child_weight_crf6 where child_weight_crf6_id in ( select max(child_weight_crf6_id) from child_weight_crf6 group by form_crf_6_id)) as g on a.form_crf_6_id=g.form_crf_6_id WHERE a.DSSID LIKE '%" + txtdssid.Text + "%' order by str_to_date(a.lw_crf6_2, '%d-%m-%Y'), STR_TO_DATE(a.lw_crf6_3,  '%H:%i')", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=NEWBORN CRF6 (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
                if (CheckBox1.Checked == false)
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select a.*,b.reader_code1 as code1,b.reader_code2 as code2, b.reader1  as BabyLength_R1,	b.reader2  as BabyLength_R2 ,	c.reader1  as BabyMUAC_R1,	c.reader2  as BabyMUAC_R2 ,	d.reader1  as BabyOFHC_R1,	d.reader2  as BabyOFHC_R2 ,	e.reader1  as LW_Weight_R1,	e.reader2  as LW_Weight_R2 ,	f.reader1  as LW_MUAC_R1,	f.reader2  as LW_MUAC_R2 ,	g.reader1  as BabyWeight_R1,	g.reader2  as BabyWeight_R2 from view_crf6 as a                     		left join(select * from baby_length_crf6 where baby_length_crf6_id in ( select max(baby_length_crf6_id) from baby_length_crf6 group by form_crf_6_id)) as b on a.form_crf_6_id=b.form_crf_6_id		left join (select * from muac_baby_crf6 where muac_baby_crf6_id in ( select max(muac_baby_crf6_id) from muac_baby_crf6 group by form_crf_6_id)) as c on a.form_crf_6_id=c.form_crf_6_id		left join (select * from occipito_frontal_head_crf6 where occipito_frontal_head_crf6_id in ( select max(occipito_frontal_head_crf6_id) from occipito_frontal_head_crf6 group by form_crf_6_id)) as d on a.form_crf_6_id=d.form_crf_6_id		left join (select * from weight_lw_crf6 where weight_lw_crf6_id in ( select max(weight_lw_crf6_id) from weight_lw_crf6 group by form_crf_6_id)) as e on a.form_crf_6_id=e.form_crf_6_id		left join (select * from muac_lw_crf6 where muac_lw_crf6_id in ( select max(muac_lw_crf6_id) from muac_lw_crf6 group by form_crf_6_id)) as f on a.form_crf_6_id=f.form_crf_6_id		left join (select * from child_weight_crf6 where child_weight_crf6_id in ( select max(child_weight_crf6_id) from child_weight_crf6 group by form_crf_6_id)) as g on a.form_crf_6_id=g.form_crf_6_id              WHERE a.DSSID LIKE '%" + txtdssid.Text + "%' and (str_to_date(a.lw_crf6_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  order by str_to_date(a.lw_crf6_2, '%d-%m-%Y'), STR_TO_DATE(a.lw_crf6_3,  '%H:%i')", con);
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
                    cmd = new MySqlCommand("select a.*,b.reader_code1 as code1,b.reader_code2 as code2, b.reader1  as BabyLength_R1,	b.reader2  as BabyLength_R2 ,	c.reader1  as BabyMUAC_R1,	c.reader2  as BabyMUAC_R2 ,	d.reader1  as BabyOFHC_R1,	d.reader2  as BabyOFHC_R2 ,	e.reader1  as LW_Weight_R1,	e.reader2  as LW_Weight_R2 ,	f.reader1  as LW_MUAC_R1,	f.reader2  as LW_MUAC_R2 ,	g.reader1  as BabyWeight_R1,	g.reader2  as BabyWeight_R2 from view_crf6 as a                                 		left join(select * from baby_length_crf6 where baby_length_crf6_id in ( select max(baby_length_crf6_id) from baby_length_crf6 group by form_crf_6_id)) as b on a.form_crf_6_id=b.form_crf_6_id		left join (select * from muac_baby_crf6 where muac_baby_crf6_id in ( select max(muac_baby_crf6_id) from muac_baby_crf6 group by form_crf_6_id)) as c on a.form_crf_6_id=c.form_crf_6_id		left join (select * from occipito_frontal_head_crf6 where occipito_frontal_head_crf6_id in ( select max(occipito_frontal_head_crf6_id) from occipito_frontal_head_crf6 group by form_crf_6_id)) as d on a.form_crf_6_id=d.form_crf_6_id		left join (select * from weight_lw_crf6 where weight_lw_crf6_id in ( select max(weight_lw_crf6_id) from weight_lw_crf6 group by form_crf_6_id)) as e on a.form_crf_6_id=e.form_crf_6_id		left join (select * from muac_lw_crf6 where muac_lw_crf6_id in ( select max(muac_lw_crf6_id) from muac_lw_crf6 group by form_crf_6_id)) as f on a.form_crf_6_id=f.form_crf_6_id		left join (select * from child_weight_crf6 where child_weight_crf6_id in ( select max(child_weight_crf6_id) from child_weight_crf6 group by form_crf_6_id)) as g on a.form_crf_6_id=g.form_crf_6_id                  WHERE a.DSSID LIKE '%" + txtdssid.Text + "%' order by str_to_date(a.lw_crf6_2, '%d-%m-%Y'), STR_TO_DATE(a.lw_crf6_3,  '%H:%i')", con);
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


        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[16].Text == "1")
                {
                    e.Row.Cells[16].Text = "Complete";
                }
                else if (e.Row.Cells[16].Text == "2")
                {
                    e.Row.Cells[16].Text = "Refused";
                }
                else if (e.Row.Cells[16].Text == "3")
                {
                    e.Row.Cells[16].Text = "House Lock";
                }
                else if (e.Row.Cells[16].Text == "4")
                {
                    e.Row.Cells[16].Text = "Permanent Migrated";
                }
            }
        }

        protected void Link_Study(object sender, EventArgs e)
        {
            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            string form_crf_6_id = commandArgs[0];
            string StudyId = commandArgs[1];

            Session["form_crf_6_id"] = form_crf_6_id;
            Session["StudyId_CRF6"] = StudyId;
            Response.Redirect("showcrf6byid.aspx");
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
                cmd = new MySqlCommand("SELECT 	a.followup_no AS q1, c.study_code AS q2,  a.lw_crf6_2 AS q3,a.lw_crf6_3 AS q4,  (CASE    WHEN aa.lw_crf_3a_19 LIKE '%a%' THEN '44'    WHEN aa.lw_crf_3a_19 LIKE '%b%' THEN '55'    WHEN aa.lw_crf_3a_19 LIKE '%c%' THEN '66' END)  AS q5,		 a.lw_crf6_15 AS q6, a.lw_crf6_17 AS q7,a.lw_crf6_18 AS q8,b.reader_code1 AS q9,b.reader_code2 AS q10,	g.reader1  AS q11_a,	g.reader2  AS q11_b,a.lw_crf6_20 AS q12, b.reader1  AS q13_a,	b.reader2  AS q13_ab, a.lw_crf6_22 AS q14,c.reader1  AS q15_a,	c.reader2  AS q15_b,a.lw_crf6_24 AS q16, d.reader1  AS q17_a,	d.reader2  AS q17_b, a.lw_crf6_27 AS q18,a.lw_crf6_28 AS q19,e.reader1  AS q20_a,	e.reader2  AS q20_b, a.lw_crf6_30 AS q21,f.reader1  AS q22_a,	f.reader2  AS q22_b,a.lw_crf6_34 AS q23, a.lw_crf6_35 AS q24 		FROM form_crf_6 AS a   LEFT JOIN studies AS c ON c.study_id=a.study_id 	    LEFT JOIN form_crf_3a AS aa ON aa.assis_id=c.assis_id 	    LEFT JOIN(SELECT * FROM baby_length_crf6 WHERE baby_length_crf6_id IN ( SELECT MAX(baby_length_crf6_id) FROM baby_length_crf6 GROUP BY form_crf_6_id)) AS b ON a.form_crf_6_id=b.form_crf_6_id		LEFT JOIN (SELECT * FROM muac_baby_crf6 WHERE muac_baby_crf6_id IN ( SELECT MAX(muac_baby_crf6_id) FROM muac_baby_crf6 GROUP BY form_crf_6_id)) AS c ON a.form_crf_6_id=c.form_crf_6_id		LEFT JOIN (SELECT * FROM occipito_frontal_head_crf6 WHERE occipito_frontal_head_crf6_id IN ( SELECT MAX(occipito_frontal_head_crf6_id) FROM occipito_frontal_head_crf6 GROUP BY form_crf_6_id)) AS d ON a.form_crf_6_id=d.form_crf_6_id		LEFT JOIN (SELECT * FROM weight_lw_crf6 WHERE weight_lw_crf6_id IN ( SELECT MAX(weight_lw_crf6_id) FROM weight_lw_crf6 GROUP BY form_crf_6_id)) AS e ON a.form_crf_6_id=e.form_crf_6_id		LEFT JOIN (SELECT * FROM muac_lw_crf6 WHERE muac_lw_crf6_id IN ( SELECT MAX(muac_lw_crf6_id) FROM muac_lw_crf6 GROUP BY form_crf_6_id)) AS f ON a.form_crf_6_id=f.form_crf_6_id		LEFT JOIN (SELECT * FROM child_weight_crf6 WHERE child_weight_crf6_id IN ( SELECT MAX(child_weight_crf6_id) FROM child_weight_crf6 GROUP BY form_crf_6_id)) AS g ON a.form_crf_6_id=g.form_crf_6_id  ORDER BY c.study_code,a.followup_no", con);
                //cmd = new MySqlCommand("select 	a.followup_no as Q1, c.study_code as Q2,  a.lw_crf6_2 as Q4D,a.lw_crf6_3 as Q4T,  (CASE    WHEN aa.lw_crf_3a_19 like '%a%' THEN '44'    WHEN aa.lw_crf_3a_19 like '%b%' THEN '55'    WHEN aa.lw_crf_3a_19 like '%c%' THEN '66' END)  as Q14,		 a.lw_crf6_15 as Q15, a.lw_crf6_17 as Q17,a.lw_crf6_18 as Q18_A,b.reader_code1 as Q18_B,b.reader_code2 as Q18_C,	g.reader1  as Q19_A,	g.reader2  as Q19_B,a.lw_crf6_20 as Q20, b.reader1  as Q21_A,	b.reader2  as Q21_B, a.lw_crf6_22 as Q22,c.reader1  as Q23_A,	c.reader2  as Q23_B,a.lw_crf6_24,d.reader1  as Q25_A,	d.reader2  as Q25_B, a.lw_crf6_27 as Q27,a.lw_crf6_28 as Q28,e.reader1  as Q29_A,	e.reader2  as Q29_B, a.lw_crf6_30 as Q30,f.reader1  as Q31_A,	f.reader2  as Q31_B,a.lw_crf6_34 as Q33, a.lw_crf6_35 as Q34 from form_crf_6 as a   left join studies as c on c.study_id=a.study_id 	    left join form_crf_3a as aa on aa.assis_id=c.assis_id 	    left join(select * from baby_length_crf6 where baby_length_crf6_id in ( select max(baby_length_crf6_id) from baby_length_crf6 group by form_crf_6_id)) as b on a.form_crf_6_id=b.form_crf_6_id		left join (select * from muac_baby_crf6 where muac_baby_crf6_id in ( select max(muac_baby_crf6_id) from muac_baby_crf6 group by form_crf_6_id)) as c on a.form_crf_6_id=c.form_crf_6_id		left join (select * from occipito_frontal_head_crf6 where occipito_frontal_head_crf6_id in ( select max(occipito_frontal_head_crf6_id) from occipito_frontal_head_crf6 group by form_crf_6_id)) as d on a.form_crf_6_id=d.form_crf_6_id		left join (select * from weight_lw_crf6 where weight_lw_crf6_id in ( select max(weight_lw_crf6_id) from weight_lw_crf6 group by form_crf_6_id)) as e on a.form_crf_6_id=e.form_crf_6_id		left join (select * from muac_lw_crf6 where muac_lw_crf6_id in ( select max(muac_lw_crf6_id) from muac_lw_crf6 group by form_crf_6_id)) as f on a.form_crf_6_id=f.form_crf_6_id		left join (select * from child_weight_crf6 where child_weight_crf6_id in ( select max(child_weight_crf6_id) from child_weight_crf6 group by form_crf_6_id)) as g on a.form_crf_6_id=g.form_crf_6_id  order by c.study_code,a.followup_no", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=BMFG CRF6 (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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