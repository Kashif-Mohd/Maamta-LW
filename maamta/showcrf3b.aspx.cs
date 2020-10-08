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
    public partial class showcrf3b : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateFormatPageLoad();
                Session["WebForm"] = "showcrf3b";

                txtCalndrDate.Enabled = true;
                txtCalndrDate1.Enabled = true;
                CheckBox1.Checked = false;

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
                    cmd = new MySqlCommand("select * from view_crf3b WHERE DSSID LIKE '%" + txtdssid.Text + "%' and (str_to_date(lw_crf3b_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by form_crf_3b_id", con);
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
                    cmd = new MySqlCommand("select * from view_crf3b WHERE DSSID LIKE '%" + txtdssid.Text + "%'  order by form_crf_3b_id", con);
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
                    cmd = new MySqlCommand("select * from view_crf3b WHERE DSSID LIKE '%" + txtdssid.Text + "%' and (str_to_date(lw_crf3b_2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by form_crf_3b_id", con);
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
                    cmd = new MySqlCommand("select * from view_crf3b WHERE DSSID LIKE '%" + txtdssid.Text + "%' order by form_crf_3b_id", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=RANDOM CRF3b (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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
            string form_crf_3b_id = commandArgs[0];
            string study_code = commandArgs[1];

            Session["form_crf_3b_id"] = form_crf_3b_id;
            Session["StudyIdCRF3b"] = study_code;
            // Session["BackButton"] = "showcrf3b";
            Response.Redirect("showcrf3bbyid.aspx");
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
               cmd = new MySqlCommand("select c.assis_id as q1,e.study_code as q2, a.lw_crf3b_2 as q3,a.lw_crf3b_3 as q4,		(CASE    WHEN a.lw_crf3b_13 like '14:%' THEN '14'    ELSE a.lw_crf3b_13 END)  as q5,	(CASE    WHEN a.lw_crf3b_14 like '8:%' THEN '8'    ELSE a.lw_crf3b_14 END)  as q6,			lw_crf3b_15 as q7, lw_crf3b_16 as q8,lw_crf3b_17 as q9,(CASE    WHEN a.lw_crf3b_18 like '8:%' THEN '8'    ELSE  	a.lw_crf3b_18 END) as q10,(CASE    WHEN a.lw_crf3b_19 like '5:%' THEN '5'    ELSE  	a.lw_crf3b_19 END) as q11, (CASE    WHEN a.lw_crf3b_20 like '6:%' THEN '6'    ELSE a.lw_crf3b_20 END) as q12 	, (CASE    WHEN a.lw_crf3b_21 like '8:%' THEN '8'    ELSE a.lw_crf3b_21 END) as q13, lw_crf3b_22 as q14,lw_crf3b_23 as q15, (CASE    WHEN a.lw_crf3b_24 like '8:%' THEN '8'    ELSE a.lw_crf3b_24 END) as q16, lw_crf3b_25 as q17,lw_crf3b_26 as q18,lw_crf3b_27 as q19,(CASE    WHEN a.lw_crf3b_28 like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_28, ':', 2), ':', -1)      END)  as q20,	lw_crf3b_29a as q21_a,lw_crf3b_29b as q21_b,lw_crf3b_29c as q21_c,lw_crf3b_29d as q21_d,(CASE    WHEN a.lw_crf3b_29e like '1:%' THEN '1'    WHEN a.lw_crf3b_29e not like '1:%' THEN a.lw_crf3b_29e END)  as q21_e,(CASE    WHEN a.lw_crf3b_29e like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_29e, ':', 2), ':', -1)      END)  as  q21_e_description,lw_crf3b_30 as q22,(CASE    WHEN a.lw_crf3b_31 like '7:%' THEN '7'    WHEN a.lw_crf3b_31 not like '7:%' THEN a.lw_crf3b_31 END)  as q23,(CASE    WHEN a.lw_crf3b_31 like '7:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_31, ':', 2), ':', -1)      END)  as  q23_other_description,lw_crf3b_32 as q24,lw_crf3b_33 as q25,lw_crf3b_34 as q26,lw_crf3b_35 as q27,lw_crf3b_36a as q28_a,lw_crf3b_36b as q28_b,lw_crf3b_36c as q28_c,lw_crf3b_36d as q28_d,lw_crf3b_36e as q28_e,lw_crf3b_36f as q28_f,lw_crf3b_36g as q28_g,lw_crf3b_36h as q28_h,lw_crf3b_36i as q28_i,lw_crf3b_36j as q28_j,lw_crf3b_36k as q28_k,lw_crf3b_36l as q28_l,lw_crf3b_36m as q28_m,lw_crf3b_36n as q28_n,lw_crf3b_36o as q28_o,lw_crf3b_36p as q28_p,lw_crf3b_36q as q28_q,lw_crf3b_36r as q28_r,lw_crf3b_36s as q28_s,lw_crf3b_36t as q28_t,lw_crf3b_36u as q28_u,lw_crf3b_36v as q28_v,lw_crf3b_36w as q28_w,lw_crf3b_36x as q28_x,(CASE    WHEN a.lw_crf3b_36y like '1:%' THEN '1'    WHEN a.lw_crf3b_36y not like '1:%' THEN a.lw_crf3b_36y END)  as q28_y,(CASE    WHEN a.lw_crf3b_36y like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_36y, ':', 2), ':', -1)      END)  as  q28_y_description,lw_crf3b_37 as q29,(CASE    WHEN a.lw_crf3b_38 like '7:%' THEN '7'    WHEN a.lw_crf3b_38 not like '7:%' THEN a.lw_crf3b_38 END)  as q30,(CASE    WHEN a.lw_crf3b_38 like '7:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_38, ':', 2), ':', -1)      END)  as  q30_other_description,lw_crf3b_39a as q31_a,lw_crf3b_39b as q31_b,lw_crf3b_39c as q31_c,lw_crf3b_39d as q31_d,lw_crf3b_39e as q31_e,lw_crf3b_39f as q31_f,lw_crf3b_39g as q31_g,lw_crf3b_39h as q31_h,lw_crf3b_39i as q31_i,(CASE    WHEN a.lw_crf3b_39j like '1:%' THEN '1'    WHEN a.lw_crf3b_39j not like '1:%' THEN a.lw_crf3b_39j END)  as q31_j,(CASE    WHEN a.lw_crf3b_39j like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_39j, ':', 2), ':', -1)      END)  as  q31_j_description, lw_crf3b_40a as q32_a,lw_crf3b_40b as q32_b,lw_crf3b_40c as q32_c,lw_crf3b_40d as q32_d,lw_crf3b_40e as q32_e,lw_crf3b_40f as q32_f,lw_crf3b_40g as q32_g,lw_crf3b_40h as q32_h,lw_crf3b_40i as q32_i,lw_crf3b_40j as q32_j,lw_crf3b_40k as q32_k,lw_crf3b_40l as q32_l,lw_crf3b_40m as q32_m,lw_crf3b_40n as q32_n,lw_crf3b_40o as q32_o,lw_crf3b_40p as q32_p, lw_crf3b_40q as q32_q,(CASE    WHEN a.lw_crf3b_40r like '1:%' THEN '1'    WHEN a.lw_crf3b_40r not like '1:%' THEN a.lw_crf3b_40r END)  as q32_r,(CASE    WHEN a.lw_crf3b_40r like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_40r, ':', 2), ':', -1)      END)  as  q32_r_description, lw_crf3b_41 as q33,			(CASE    WHEN a.lw_crf3b_42 like '7:%' THEN '7'    ELSE a.lw_crf3b_42 END) as q34,lw_crf3b_43a as q35_a,lw_crf3b_43b as q35_b,lw_crf3b_43c as q35_c,lw_crf3b_43d as q35_d,lw_crf3b_43e as q35_e,lw_crf3b_43f as q35_f,lw_crf3b_43g as q35_g,lw_crf3b_43h as q35_h,lw_crf3b_43i as q35_i,lw_crf3b_43j as q35_j, (CASE    WHEN a.lw_crf3b_43k like '1:%' THEN '1'    WHEN a.lw_crf3b_43k not like '1:%' THEN a.lw_crf3b_43k END)  as q35_k,(CASE    WHEN a.lw_crf3b_43k like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_43k, ':', 2), ':', -1)      END)  as  q35_k_description, lw_crf3b_44 as q36, (CASE  WHEN a.lw_crf3b_45 like '5:%' THEN '5' 	WHEN a.lw_crf3b_45 like '6:%' THEN '6' 	 WHEN a.lw_crf3b_45 like '7:%' THEN '7'   WHEN a.lw_crf3b_45 like '8:%' THEN '8'	 WHEN a.lw_crf3b_45 like '10:%' THEN '10'  	WHEN a.lw_crf3b_45 like '11:%' THEN '11'   ELSE  a.lw_crf3b_45  END) as q37,   lw_crf3b_46 as q38,lw_crf3b_47 as q39,		(CASE    WHEN a.lw_crf3b_48 like '3:%' THEN '3'    ELSE a.lw_crf3b_48 END) as q40, 		lw_crf3b_49 as q41,lw_crf3b_50 as q42,(CASE    WHEN a.lw_crf3b_51 like '7:%' THEN '7'    ELSE a.lw_crf3b_51 END)  as q43, lw_crf3b_52 as q44,lw_crf3b_53 as q45,lw_crf3b_54 as q46,lw_crf3b_55 as q47,lw_crf3b_56 as q48,lw_crf3b_57 as q49,lw_crf3b_58 as q50,lw_crf3b_59 as q51,(CASE    WHEN a.lw_crf3b_60 like '7:%' THEN '7'    ELSE a.lw_crf3b_60 END)  as q52,lw_crf3b_61 as q53,(CASE    WHEN a.lw_crf3b_62 like '6:%' THEN '6'    ELSE a.lw_crf3b_62 END) as q54,lw_crf3b_63 as q55,lw_crf3b_64 as q56,lw_crf3b_65a as q57_a,lw_crf3b_65b as q57_b,lw_crf3b_65c as q57_c,lw_crf3b_65d as q57_d,lw_crf3b_65e as q57_e,lw_crf3b_65f as q57_f,lw_crf3b_65g as q57_g,lw_crf3b_65h as q57_h,lw_crf3b_65i as q57_i,lw_crf3b_65j as q57_j,lw_crf3b_65k as q57_k,lw_crf3b_65l as q57_l,(CASE    WHEN a.lw_crf3b_65m like '1:%' THEN '1'    WHEN a.lw_crf3b_65m not like '1:%' THEN a.lw_crf3b_65m END)  as q57_m,(CASE    WHEN a.lw_crf3b_65m like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_65m, ':', 2), ':', -1)      END)  as  q57_m_description,      ((lw_crf3b_66a * 1440) + (lw_crf3b_66b * 60)  + lw_crf3b_66c) as q58,lw_crf3b_67 as q59,                    ((lw_crf3b_68a * 1440) + (lw_crf3b_68b * 60)  + lw_crf3b_68c) as q60,       lw_crf3b_69 as q61,lw_crf3b_70a as q62_a,lw_crf3b_70b as q62_b,lw_crf3b_70c as q62_c,lw_crf3b_70d as q62_d,lw_crf3b_70e as q62_e,lw_crf3b_70f as q62_f,lw_crf3b_70g as q62_g,lw_crf3b_70h as q62_h,	lw_crf3b_70i as q62_i,lw_crf3b_70j as q62_j,lw_crf3b_70k as q62_k,lw_crf3b_70l as q62_l,lw_crf3b_70m as q62_m,lw_crf3b_70n as q62_n,(CASE    WHEN a.lw_crf3b_70o like '1:%' THEN '1'    WHEN a.lw_crf3b_70o not like '1:%' THEN a.lw_crf3b_70o END)  as q62_o,(CASE    WHEN a.lw_crf3b_70o like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_70o, ':', 2), ':', -1)      END)  as  q62_o_description,lw_crf3b_71a as q63_a,lw_crf3b_71b as q63_b,lw_crf3b_71c as q63_c,lw_crf3b_71d as q63_d,lw_crf3b_71e as q63_e,lw_crf3b_71f as q63_f,lw_crf3b_71g as q63_g,lw_crf3b_71h as q63_h,lw_crf3b_71i as q63_i,lw_crf3b_71j as q63_j,lw_crf3b_71k as q63_k,(CASE    WHEN a.lw_crf3b_71l like '1:%' THEN '1'    WHEN a.lw_crf3b_71l not like '1:%' THEN a.lw_crf3b_71l END)  as q63_l,(CASE    WHEN a.lw_crf3b_71l like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_71l, ':', 2), ':', -1)      END)  as  q63_l_descrition,lw_crf3b_72 as q64,lw_crf3b_73a as q65_a,lw_crf3b_73b as q65_b,lw_crf3b_73c as q65_c,lw_crf3b_73d as q65_d,lw_crf3b_73e as q65_e,lw_crf3b_73f as q65_f,lw_crf3b_73g as q65_g,lw_crf3b_73h as q65_h,lw_crf3b_73i as q65_i,lw_crf3b_73j as q65_j,lw_crf3b_73k as q65_k,lw_crf3b_73l as q65_l,lw_crf3b_73m as q65_m,lw_crf3b_73n as q65_n,lw_crf3b_73o as q65_o,lw_crf3b_73p as q65_p,lw_crf3b_73q as q65_q,lw_crf3b_73r as q65_r,lw_crf3b_73s as q65_s,lw_crf3b_73t as q65_t,lw_crf3b_73u as q65_u,lw_crf3b_73v as q65_v,lw_crf3b_73w as q65_w,lw_crf3b_73x as q65_x,lw_crf3b_73y as q65_y,(CASE    WHEN (a.lw_crf3b_73z !='2' and a.lw_crf3b_73z !='') THEN '1'    WHEN a.lw_crf3b_73z ='2'  THEN '2' END)  as q65_z, (CASE    WHEN (a.lw_crf3b_73z !='2' and a.lw_crf3b_73z !='') THEN  SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_73z, ':', 2), ':', -1)  END)  as q65_z_description, lw_crf3b_74 as q66,lw_crf3b_75a as q67_a,lw_crf3b_75b as q67_b,lw_crf3b_75c as q67_c,lw_crf3b_75d as q67_d,lw_crf3b_75e as q67_e,lw_crf3b_75f as q67_f,lw_crf3b_75g as q67_g,lw_crf3b_75h as q67_h,lw_crf3b_75i as q67_i,lw_crf3b_75j as q67_j,lw_crf3b_75k as q67_k,lw_crf3b_75l as q67_l,lw_crf3b_75m as q67_m,	lw_crf3b_76 as q68,lw_crf3b_77a as q69_a,lw_crf3b_77b as q69_b,lw_crf3b_77c as q69_c,lw_crf3b_77d as q69_d,lw_crf3b_77e as q69_e, lw_crf3b_77f as q69_f, lw_crf3b_77g as q69_g, lw_crf3b_77h as q69_h,(CASE    WHEN (a.lw_crf3b_77i !='2' and a.lw_crf3b_77i !='') THEN '1'    WHEN a.lw_crf3b_77i ='2'  THEN '2' END)  as q69_i, (CASE    WHEN (a.lw_crf3b_77i !='2' and a.lw_crf3b_77i !='') THEN a.lw_crf3b_77i END)  as q69_i_description, lw_crf3b_78a as q70_hrs,lw_crf3b_78b as q70_days,lw_crf3b_79 as q71,lw_crf3b_80a as q72_a,lw_crf3b_80b as q72_b,lw_crf3b_81 as q73,lw_crf3b_82 as q74,lw_crf3b_83a as q75_a,lw_crf3b_83b as q75_b,lw_crf3b_84 as q76,lw_crf3b_85 as q77,lw_crf3b_86 as q78,lw_crf3b_87 as q79,lw_crf3b_88a as q80_a,lw_crf3b_88ba as q80_b1,lw_crf3b_88bb as q80_b2,lw_crf3b_88bc as q80_b3,lw_crf3b_88bd as q80_b4,lw_crf3b_89 as q81,lw_crf3b_90 as q82,lw_crf3b_91 as q83,lw_crf3b_92 as q84,lw_crf3b_93 as q85,lw_crf3b_94 as q86,lw_crf3b_95 as q87,lw_crf3b_96a as q88_a,lw_crf3b_96b as q88_b,lw_crf3b_96c as q88_c,lw_crf3b_96d as q88_d,lw_crf3b_96e as q88_e,lw_crf3b_96f as q88_f, lw_crf3b_96g as q88_g,lw_crf3b_96h as q88_h,lw_crf3b_96i as q88_i,lw_crf3b_96j as q88_j,lw_crf3b_96k as q88_k,lw_crf3b_96l as q88_l,lw_crf3b_96m as q88_m,lw_crf3b_96n as q88_n,lw_crf3b_96o as q88_o,(CASE    WHEN a.lw_crf3b_96p like '1:%' THEN '1'    WHEN a.lw_crf3b_96p not like '1:%' THEN a.lw_crf3b_96p END)  as q88_p, (CASE    WHEN a.lw_crf3b_96p like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_96p, ':', 2), ':', -1)      END)  as  q88_p_description, lw_crf3b_97 as q89,lw_crf3b_98 as q90,lw_crf3b_99 as q91,lw_crf3b_100 as q92,lw_crf3b_101a as q93_a,lw_crf3b_101b as q93_b,lw_crf3b_101c as q93_c,lw_crf3b_101d as q93_d,lw_crf3b_101e as q93_e,lw_crf3b_101f as q93_f,lw_crf3b_101g as q93_g,lw_crf3b_101h as q93_h,lw_crf3b_101i as q93_i,lw_crf3b_101j as q93_j,lw_crf3b_101k as q93_k, (CASE    WHEN a.lw_crf3b_101l like '1:%' THEN '1'    WHEN a.lw_crf3b_101l not like '1:%' THEN a.lw_crf3b_101l END)  as q93_l, (CASE    WHEN a.lw_crf3b_101l like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_101l, ':', 2), ':', -1)      END)  as  q93_l_description, lw_crf3b_102 as q94,lw_crf3b_103 as q95,lw_crf3b_104a as q96_a,lw_crf3b_104b as q96_b,lw_crf3b_104c as q96_c,lw_crf3b_105a as q97_a,lw_crf3b_105b as q97_b,lw_crf3b_105c as q97_c,lw_crf3b_105d as q97_d,lw_crf3b_106 as q98		from form_crf_3b as a inner join pw as c on a.assis_id=c.id inner join studies as e on e.study_id=a.study_id", con);

               // Pending to Run Query (Q36: Male and Female) 30-07-2020
               // cmd = new MySqlCommand("SELECT c.assis_id AS q1,e.study_code AS q2, a.lw_crf3b_2 AS q3,a.lw_crf3b_3 AS q4,		(CASE    WHEN a.lw_crf3b_13 LIKE '14:%' THEN '14'    ELSE a.lw_crf3b_13 END)  AS q5,	(CASE    WHEN a.lw_crf3b_14 LIKE '8:%' THEN '8'    ELSE a.lw_crf3b_14 END)  AS q6,			lw_crf3b_15 AS q7, lw_crf3b_16 AS q8,lw_crf3b_17 AS q9,(CASE    WHEN a.lw_crf3b_18 LIKE '8:%' THEN '8'    ELSE  	a.lw_crf3b_18 END) AS q10,(CASE    WHEN a.lw_crf3b_19 LIKE '5:%' THEN '5'    ELSE  	a.lw_crf3b_19 END) AS q11, (CASE    WHEN a.lw_crf3b_20 LIKE '6:%' THEN '6'    ELSE a.lw_crf3b_20 END) AS q12 	, (CASE    WHEN a.lw_crf3b_21 LIKE '8:%' THEN '8'    ELSE a.lw_crf3b_21 END) AS q13, lw_crf3b_22 AS q14,lw_crf3b_23 AS q15, (CASE    WHEN a.lw_crf3b_24 LIKE '8:%' THEN '8'    ELSE a.lw_crf3b_24 END) AS q16, lw_crf3b_25 AS q17,lw_crf3b_26 AS q18,lw_crf3b_27 AS q19,(CASE    WHEN a.lw_crf3b_28 LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_28, ':', 2), ':', -1)      END)  AS q20,	lw_crf3b_29a AS q21_a,lw_crf3b_29b AS q21_b,lw_crf3b_29c AS q21_c,lw_crf3b_29d AS q21_d,(CASE    WHEN a.lw_crf3b_29e LIKE '1:%' THEN '1'    WHEN a.lw_crf3b_29e NOT LIKE '1:%' THEN a.lw_crf3b_29e END)  AS q21_e,(CASE    WHEN a.lw_crf3b_29e LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_29e, ':', 2), ':', -1)      END)  AS  q21_e_description,lw_crf3b_30 AS q22,(CASE    WHEN a.lw_crf3b_31 LIKE '7:%' THEN '7'    WHEN a.lw_crf3b_31 NOT LIKE '7:%' THEN a.lw_crf3b_31 END)  AS q23,(CASE    WHEN a.lw_crf3b_31 LIKE '7:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_31, ':', 2), ':', -1)      END)  AS  q23_other_description,lw_crf3b_32 AS q24,lw_crf3b_33 AS q25,lw_crf3b_34 AS q26,lw_crf3b_35 AS q27,lw_crf3b_36a AS q28_a,lw_crf3b_36b AS q28_b,lw_crf3b_36c AS q28_c,lw_crf3b_36d AS q28_d,lw_crf3b_36e AS q28_e,lw_crf3b_36f AS q28_f,lw_crf3b_36g AS q28_g,lw_crf3b_36h AS q28_h,lw_crf3b_36i AS q28_i,lw_crf3b_36j AS q28_j,lw_crf3b_36k AS q28_k,lw_crf3b_36l AS q28_l,lw_crf3b_36m AS q28_m,lw_crf3b_36n AS q28_n,lw_crf3b_36o AS q28_o,lw_crf3b_36p AS q28_p,lw_crf3b_36q AS q28_q,lw_crf3b_36r AS q28_r,lw_crf3b_36s AS q28_s,lw_crf3b_36t AS q28_t,lw_crf3b_36u AS q28_u,lw_crf3b_36v AS q28_v,lw_crf3b_36w AS q28_w,lw_crf3b_36x AS q28_x,(CASE    WHEN a.lw_crf3b_36y LIKE '1:%' THEN '1'    WHEN a.lw_crf3b_36y NOT LIKE '1:%' THEN a.lw_crf3b_36y END)  AS q28_y,(CASE    WHEN a.lw_crf3b_36y LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_36y, ':', 2), ':', -1)      END)  AS  q28_y_description,lw_crf3b_37 AS q29,(CASE    WHEN a.lw_crf3b_38 LIKE '7:%' THEN '7'    WHEN a.lw_crf3b_38 NOT LIKE '7:%' THEN a.lw_crf3b_38 END)  AS q30,(CASE    WHEN a.lw_crf3b_38 LIKE '7:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_38, ':', 2), ':', -1)      END)  AS  q30_other_description,lw_crf3b_39a AS q31_a,lw_crf3b_39b AS q31_b,lw_crf3b_39c AS q31_c,lw_crf3b_39d AS q31_d,lw_crf3b_39e AS q31_e,lw_crf3b_39f AS q31_f,lw_crf3b_39g AS q31_g,lw_crf3b_39h AS q31_h,lw_crf3b_39i AS q31_i,(CASE    WHEN a.lw_crf3b_39j LIKE '1:%' THEN '1'    WHEN a.lw_crf3b_39j NOT LIKE '1:%' THEN a.lw_crf3b_39j END)  AS q31_j,(CASE    WHEN a.lw_crf3b_39j LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_39j, ':', 2), ':', -1)      END)  AS  q31_j_description, lw_crf3b_40a AS q32_a,lw_crf3b_40b AS q32_b,lw_crf3b_40c AS q32_c,lw_crf3b_40d AS q32_d,lw_crf3b_40e AS q32_e,lw_crf3b_40f AS q32_f,lw_crf3b_40g AS q32_g,lw_crf3b_40h AS q32_h,lw_crf3b_40i AS q32_i,lw_crf3b_40j AS q32_j,lw_crf3b_40k AS q32_k,lw_crf3b_40l AS q32_l,lw_crf3b_40m AS q32_m,lw_crf3b_40n AS q32_n,lw_crf3b_40o AS q32_o,lw_crf3b_40p AS q32_p, lw_crf3b_40q AS q32_q,(CASE    WHEN a.lw_crf3b_40r LIKE '1:%' THEN '1'    WHEN a.lw_crf3b_40r NOT LIKE '1:%' THEN a.lw_crf3b_40r END)  AS q32_r,(CASE    WHEN a.lw_crf3b_40r LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_40r, ':', 2), ':', -1)      END)  AS  q32_r_description, lw_crf3b_41 AS q33,			(CASE    WHEN a.lw_crf3b_42 LIKE '7:%' THEN '7'    ELSE a.lw_crf3b_42 END) AS q34,lw_crf3b_43a AS q35_a,lw_crf3b_43b AS q35_b,lw_crf3b_43c AS q35_c,lw_crf3b_43d AS q35_d,lw_crf3b_43e AS q35_e,lw_crf3b_43f AS q35_f,lw_crf3b_43g AS q35_g,lw_crf3b_43h AS q35_h,lw_crf3b_43i AS q35_i,lw_crf3b_43j AS q35_j, (CASE    WHEN a.lw_crf3b_43k LIKE '1:%' THEN '1'    WHEN a.lw_crf3b_43k NOT LIKE '1:%' THEN a.lw_crf3b_43k END)  AS q35_k,(CASE    WHEN a.lw_crf3b_43k LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_43k, ':', 2), ':', -1)      END)  AS  q35_k_description,  (CASE  WHEN a.lw_crf3b_44 LIKE 'm' THEN '1' WHEN a.lw_crf3b_44 LIKE 'f' THEN '2'	END) AS q36, (CASE  WHEN a.lw_crf3b_45 LIKE '5:%' THEN '5' 	WHEN a.lw_crf3b_45 LIKE '6:%' THEN '6' 	 WHEN a.lw_crf3b_45 LIKE '7:%' THEN '7'   WHEN a.lw_crf3b_45 LIKE '8:%' THEN '8'	 WHEN a.lw_crf3b_45 LIKE '10:%' THEN '10'  	WHEN a.lw_crf3b_45 LIKE '11:%' THEN '11'   ELSE  a.lw_crf3b_45  END) AS q37,   lw_crf3b_46 AS q38,lw_crf3b_47 AS q39,		(CASE    WHEN a.lw_crf3b_48 LIKE '3:%' THEN '3'    ELSE a.lw_crf3b_48 END) AS q40, 		lw_crf3b_49 AS q41,lw_crf3b_50 AS q42,(CASE    WHEN a.lw_crf3b_51 LIKE '7:%' THEN '7'    ELSE a.lw_crf3b_51 END)  AS q43, lw_crf3b_52 AS q44,lw_crf3b_53 AS q45,lw_crf3b_54 AS q46,lw_crf3b_55 AS q47,lw_crf3b_56 AS q48,lw_crf3b_57 AS q49,lw_crf3b_58 AS q50,lw_crf3b_59 AS q51,(CASE    WHEN a.lw_crf3b_60 LIKE '7:%' THEN '7'    ELSE a.lw_crf3b_60 END)  AS q52,lw_crf3b_61 AS q53,(CASE    WHEN a.lw_crf3b_62 LIKE '6:%' THEN '6'    ELSE a.lw_crf3b_62 END) AS q54,lw_crf3b_63 AS q55,lw_crf3b_64 AS q56,lw_crf3b_65a AS q57_a,lw_crf3b_65b AS q57_b,lw_crf3b_65c AS q57_c,lw_crf3b_65d AS q57_d,lw_crf3b_65e AS q57_e,lw_crf3b_65f AS q57_f,lw_crf3b_65g AS q57_g,lw_crf3b_65h AS q57_h,lw_crf3b_65i AS q57_i,lw_crf3b_65j AS q57_j,lw_crf3b_65k AS q57_k,lw_crf3b_65l AS q57_l,(CASE    WHEN a.lw_crf3b_65m LIKE '1:%' THEN '1'    WHEN a.lw_crf3b_65m NOT LIKE '1:%' THEN a.lw_crf3b_65m END)  AS q57_m,(CASE    WHEN a.lw_crf3b_65m LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_65m, ':', 2), ':', -1)      END)  AS  q57_m_description,      ((lw_crf3b_66a * 1440) + (lw_crf3b_66b * 60)  + lw_crf3b_66c) AS q58,lw_crf3b_67 AS q59,                    ((lw_crf3b_68a * 1440) + (lw_crf3b_68b * 60)  + lw_crf3b_68c) AS q60,       lw_crf3b_69 AS q61,lw_crf3b_70a AS q62_a,lw_crf3b_70b AS q62_b,lw_crf3b_70c AS q62_c,lw_crf3b_70d AS q62_d,lw_crf3b_70e AS q62_e,lw_crf3b_70f AS q62_f,lw_crf3b_70g AS q62_g,lw_crf3b_70h AS q62_h,	lw_crf3b_70i AS q62_i,lw_crf3b_70j AS q62_j,lw_crf3b_70k AS q62_k,lw_crf3b_70l AS q62_l,lw_crf3b_70m AS q62_m,lw_crf3b_70n AS q62_n,(CASE    WHEN a.lw_crf3b_70o LIKE '1:%' THEN '1'    WHEN a.lw_crf3b_70o NOT LIKE '1:%' THEN a.lw_crf3b_70o END)  AS q62_o,(CASE    WHEN a.lw_crf3b_70o LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_70o, ':', 2), ':', -1)      END)  AS  q62_o_description,lw_crf3b_71a AS q63_a,lw_crf3b_71b AS q63_b,lw_crf3b_71c AS q63_c,lw_crf3b_71d AS q63_d,lw_crf3b_71e AS q63_e,lw_crf3b_71f AS q63_f,lw_crf3b_71g AS q63_g,lw_crf3b_71h AS q63_h,lw_crf3b_71i AS q63_i,lw_crf3b_71j AS q63_j,lw_crf3b_71k AS q63_k,(CASE    WHEN a.lw_crf3b_71l LIKE '1:%' THEN '1'    WHEN a.lw_crf3b_71l NOT LIKE '1:%' THEN a.lw_crf3b_71l END)  AS q63_l,(CASE    WHEN a.lw_crf3b_71l LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_71l, ':', 2), ':', -1)      END)  AS  q63_l_descrition,lw_crf3b_72 AS q64,lw_crf3b_73a AS q65_a,lw_crf3b_73b AS q65_b,lw_crf3b_73c AS q65_c,lw_crf3b_73d AS q65_d,lw_crf3b_73e AS q65_e,lw_crf3b_73f AS q65_f,lw_crf3b_73g AS q65_g,lw_crf3b_73h AS q65_h,lw_crf3b_73i AS q65_i,lw_crf3b_73j AS q65_j,lw_crf3b_73k AS q65_k,lw_crf3b_73l AS q65_l,lw_crf3b_73m AS q65_m,lw_crf3b_73n AS q65_n,lw_crf3b_73o AS q65_o,lw_crf3b_73p AS q65_p,lw_crf3b_73q AS q65_q,lw_crf3b_73r AS q65_r,lw_crf3b_73s AS q65_s,lw_crf3b_73t AS q65_t,lw_crf3b_73u AS q65_u,lw_crf3b_73v AS q65_v,lw_crf3b_73w AS q65_w,lw_crf3b_73x AS q65_x,lw_crf3b_73y AS q65_y,(CASE    WHEN (a.lw_crf3b_73z !='2' AND a.lw_crf3b_73z !='') THEN '1'    WHEN a.lw_crf3b_73z ='2'  THEN '2' END)  AS q65_z, (CASE    WHEN (a.lw_crf3b_73z !='2' AND a.lw_crf3b_73z !='') THEN  SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_73z, ':', 2), ':', -1)  END)  AS q65_z_description, lw_crf3b_74 AS q66,lw_crf3b_75a AS q67_a,lw_crf3b_75b AS q67_b,lw_crf3b_75c AS q67_c,lw_crf3b_75d AS q67_d,lw_crf3b_75e AS q67_e,lw_crf3b_75f AS q67_f,lw_crf3b_75g AS q67_g,lw_crf3b_75h AS q67_h,lw_crf3b_75i AS q67_i,lw_crf3b_75j AS q67_j,lw_crf3b_75k AS q67_k,lw_crf3b_75l AS q67_l,lw_crf3b_75m AS q67_m,	lw_crf3b_76 AS q68,lw_crf3b_77a AS q69_a,lw_crf3b_77b AS q69_b,lw_crf3b_77c AS q69_c,lw_crf3b_77d AS q69_d,lw_crf3b_77e AS q69_e, lw_crf3b_77f AS q69_f, lw_crf3b_77g AS q69_g, lw_crf3b_77h AS q69_h,(CASE    WHEN (a.lw_crf3b_77i !='2' AND a.lw_crf3b_77i !='') THEN '1'    WHEN a.lw_crf3b_77i ='2'  THEN '2' END)  AS q69_i, (CASE    WHEN (a.lw_crf3b_77i !='2' AND a.lw_crf3b_77i !='') THEN a.lw_crf3b_77i END)  AS q69_i_description, lw_crf3b_78a AS q70_hrs,lw_crf3b_78b AS q70_days,lw_crf3b_79 AS q71,lw_crf3b_80a AS q72_a,lw_crf3b_80b AS q72_b,lw_crf3b_81 AS q73,lw_crf3b_82 AS q74,lw_crf3b_83a AS q75_a,lw_crf3b_83b AS q75_b,lw_crf3b_84 AS q76,lw_crf3b_85 AS q77,lw_crf3b_86 AS q78,lw_crf3b_87 AS q79,lw_crf3b_88a AS q80_a,lw_crf3b_88ba AS q80_b1,lw_crf3b_88bb AS q80_b2,lw_crf3b_88bc AS q80_b3,lw_crf3b_88bd AS q80_b4,lw_crf3b_89 AS q81,lw_crf3b_90 AS q82,lw_crf3b_91 AS q83,lw_crf3b_92 AS q84,lw_crf3b_93 AS q85,lw_crf3b_94 AS q86,lw_crf3b_95 AS q87,lw_crf3b_96a AS q88_a,lw_crf3b_96b AS q88_b,lw_crf3b_96c AS q88_c,lw_crf3b_96d AS q88_d,lw_crf3b_96e AS q88_e,lw_crf3b_96f AS q88_f, lw_crf3b_96g AS q88_g,lw_crf3b_96h AS q88_h,lw_crf3b_96i AS q88_i,lw_crf3b_96j AS q88_j,lw_crf3b_96k AS q88_k,lw_crf3b_96l AS q88_l,lw_crf3b_96m AS q88_m,lw_crf3b_96n AS q88_n,lw_crf3b_96o AS q88_o,(CASE    WHEN a.lw_crf3b_96p LIKE '1:%' THEN '1'    WHEN a.lw_crf3b_96p NOT LIKE '1:%' THEN a.lw_crf3b_96p END)  AS q88_p, (CASE    WHEN a.lw_crf3b_96p LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_96p, ':', 2), ':', -1)      END)  AS  q88_p_description, lw_crf3b_97 AS q89,lw_crf3b_98 AS q90,lw_crf3b_99 AS q91,lw_crf3b_100 AS q92,lw_crf3b_101a AS q93_a,lw_crf3b_101b AS q93_b,lw_crf3b_101c AS q93_c,lw_crf3b_101d AS q93_d,lw_crf3b_101e AS q93_e,lw_crf3b_101f AS q93_f,lw_crf3b_101g AS q93_g,lw_crf3b_101h AS q93_h,lw_crf3b_101i AS q93_i,lw_crf3b_101j AS q93_j,lw_crf3b_101k AS q93_k, (CASE    WHEN a.lw_crf3b_101l LIKE '1:%' THEN '1'    WHEN a.lw_crf3b_101l NOT LIKE '1:%' THEN a.lw_crf3b_101l END)  AS q93_l, (CASE    WHEN a.lw_crf3b_101l LIKE '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_101l, ':', 2), ':', -1)      END)  AS  q93_l_description, lw_crf3b_102 AS q94,lw_crf3b_103 AS q95,lw_crf3b_104a AS q96_a,lw_crf3b_104b AS q96_b,lw_crf3b_104c AS q96_c,lw_crf3b_105a AS q97_a,lw_crf3b_105b AS q97_b,lw_crf3b_105c AS q97_c,lw_crf3b_105d AS q97_d,lw_crf3b_106 AS q98		FROM form_crf_3b AS a INNER JOIN pw AS c ON a.assis_id=c.id INNER JOIN studies AS e ON e.study_id=a.study_id", con);
                
                //cmd = new MySqlCommand("select c.assis_id as Q1,e.study_code as Q2, a.lw_crf3b_2 as Q3_D,a.lw_crf3b_3 as Q3_T,		(CASE    WHEN a.lw_crf3b_13 like '14:%' THEN '14'    ELSE a.lw_crf3b_13 END)  as Q13,	(CASE    WHEN a.lw_crf3b_14 like '8:%' THEN '8'    ELSE a.lw_crf3b_14 END)  as Q14,			lw_crf3b_15 as Q15, lw_crf3b_16 as Q16,lw_crf3b_17 as Q17,(CASE    WHEN a.lw_crf3b_18 like '8:%' THEN '8'    ELSE  	a.lw_crf3b_18 END) as Q18,(CASE    WHEN a.lw_crf3b_19 like '5:%' THEN '5'    ELSE  	a.lw_crf3b_19 END) as Q19, (CASE    WHEN a.lw_crf3b_20 like '6:%' THEN '6'    ELSE a.lw_crf3b_20 END) as Q20 	, (CASE    WHEN a.lw_crf3b_21 like '8:%' THEN '8'    ELSE a.lw_crf3b_21 END) as Q21, lw_crf3b_22 as Q22,lw_crf3b_23 as Q23, (CASE    WHEN a.lw_crf3b_24 like '8:%' THEN '8'    ELSE a.lw_crf3b_24 END) as Q24, lw_crf3b_25 as Q25,lw_crf3b_26 as Q26,lw_crf3b_27 as Q27,(CASE    WHEN a.lw_crf3b_28 like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_28, ':', 2), ':', -1)      END)  as Q28,lw_crf3b_29a as Q29_A,lw_crf3b_29b as Q29_B,lw_crf3b_29c as Q29_C,lw_crf3b_29d as Q29_D,(CASE    WHEN a.lw_crf3b_29e like '1:%' THEN '1'    WHEN a.lw_crf3b_29e not like '1:%' THEN a.lw_crf3b_29e END)  as Q29_E,(CASE    WHEN a.lw_crf3b_29e like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_29e, ':', 2), ':', -1)      END)  as  Q29_E_DESCRIPTION,lw_crf3b_30 as Q30,(CASE    WHEN a.lw_crf3b_31 like '7:%' THEN '7'    WHEN a.lw_crf3b_31 not like '7:%' THEN a.lw_crf3b_31 END)  as Q31,(CASE    WHEN a.lw_crf3b_31 like '7:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_31, ':', 2), ':', -1)      END)  as  Q31_7_DESCRIPTION,lw_crf3b_32 as Q32,lw_crf3b_33 as Q33,lw_crf3b_34 as Q34,lw_crf3b_35 as Q35,lw_crf3b_36a as Q36_A,lw_crf3b_36b as Q36_B,lw_crf3b_36c as Q36_C,lw_crf3b_36d as Q36_D,lw_crf3b_36e as Q36_E,lw_crf3b_36f as Q36_F,lw_crf3b_36g as Q36_G,lw_crf3b_36h as Q36_H,lw_crf3b_36i as Q36_I,lw_crf3b_36j as Q36_J,lw_crf3b_36k as Q36_K,lw_crf3b_36l as Q36_L,lw_crf3b_36m as Q36_M,lw_crf3b_36n as Q36_N,lw_crf3b_36o as Q36_O,lw_crf3b_36p as Q36_P,lw_crf3b_36q as Q36_Q,lw_crf3b_36r as Q36_R,lw_crf3b_36s as Q36_S,lw_crf3b_36t as Q36_T,lw_crf3b_36u as Q36_U,lw_crf3b_36v as Q36_V,lw_crf3b_36w as Q36_W,lw_crf3b_36x as Q36_X,(CASE    WHEN a.lw_crf3b_36y like '1:%' THEN '1'    WHEN a.lw_crf3b_36y not like '1:%' THEN a.lw_crf3b_36y END)  as Q36_Y,(CASE    WHEN a.lw_crf3b_36y like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_36y, ':', 2), ':', -1)      END)  as  Q36_Y_DESCRIPTION,lw_crf3b_37 as Q37,(CASE    WHEN a.lw_crf3b_38 like '7:%' THEN '7'    WHEN a.lw_crf3b_38 not like '7:%' THEN a.lw_crf3b_38 END)  as Q38,(CASE    WHEN a.lw_crf3b_38 like '7:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_38, ':', 2), ':', -1)      END)  as  Q38_DESCRIPTION,lw_crf3b_39a as Q39_A,lw_crf3b_39b as Q39_B,lw_crf3b_39c as Q39_C,lw_crf3b_39d as Q39_D,lw_crf3b_39e as Q39_E,lw_crf3b_39f as Q39_F,lw_crf3b_39g as Q39_G,lw_crf3b_39h as Q39_H,lw_crf3b_39i as Q39_I,(CASE    WHEN a.lw_crf3b_39j like '1:%' THEN '1'    WHEN a.lw_crf3b_39j not like '1:%' THEN a.lw_crf3b_39j END)  as Q39_J,(CASE    WHEN a.lw_crf3b_39j like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_39j, ':', 2), ':', -1)      END)  as  Q39_J_DESCRIPTION, lw_crf3b_40a as Q40_A,lw_crf3b_40b as Q40_B,lw_crf3b_40c as Q40_C,lw_crf3b_40d as Q40_D,lw_crf3b_40e as Q40_E,lw_crf3b_40f as Q40_F,lw_crf3b_40g as Q40_G,lw_crf3b_40h as Q40_H,lw_crf3b_40i as Q40_I,lw_crf3b_40j as Q40_J,lw_crf3b_40k as Q40_K,lw_crf3b_40l as Q40_L,lw_crf3b_40m as Q40_M,lw_crf3b_40n as Q40_N,lw_crf3b_40o as Q40_O,lw_crf3b_40p as Q40_P, lw_crf3b_40q as Q40_Q,(CASE    WHEN a.lw_crf3b_40r like '1:%' THEN '1'    WHEN a.lw_crf3b_40r not like '1:%' THEN a.lw_crf3b_40r END)  as Q40_R,(CASE    WHEN a.lw_crf3b_40r like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_40r, ':', 2), ':', -1)      END)  as  Q40_R_DESCRIPTION, lw_crf3b_41 as Q41,			(CASE    WHEN a.lw_crf3b_42 like '7:%' THEN '7'    ELSE a.lw_crf3b_42 END) as Q42,lw_crf3b_43a as Q43_A,lw_crf3b_43b as Q43_B,lw_crf3b_43c as Q43_C,lw_crf3b_43d as Q43_D,lw_crf3b_43e as Q43_E,lw_crf3b_43f as Q43_F,lw_crf3b_43g as Q43_G,lw_crf3b_43h as Q43_H,lw_crf3b_43i as Q43_I,lw_crf3b_43j as Q43_J, (CASE    WHEN a.lw_crf3b_43k like '1:%' THEN '1'    WHEN a.lw_crf3b_43k not like '1:%' THEN a.lw_crf3b_43k END)  as Q43_K,(CASE    WHEN a.lw_crf3b_43k like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_43k, ':', 2), ':', -1)      END)  as  Q43_K_DESCRIPTION, lw_crf3b_44 as Q44 , (CASE  WHEN a.lw_crf3b_45 like '5:%' THEN '5' 	WHEN a.lw_crf3b_45 like '6:%' THEN '6' 	 WHEN a.lw_crf3b_45 like '7:%' THEN '7'   WHEN a.lw_crf3b_45 like '8:%' THEN '8'	 WHEN a.lw_crf3b_45 like '10:%' THEN '10'  	WHEN a.lw_crf3b_45 like '11:%' THEN '11'   ELSE  a.lw_crf3b_45  END) as Q45,   lw_crf3b_46 as Q46,lw_crf3b_47 as Q47,		(CASE    WHEN a.lw_crf3b_48 like '3:%' THEN '3'    ELSE a.lw_crf3b_48 END) as Q48, 		lw_crf3b_49 as Q49,lw_crf3b_50 as Q50,(CASE    WHEN a.lw_crf3b_51 like '7:%' THEN '7'    ELSE a.lw_crf3b_51 END)  as Q51, lw_crf3b_52 as Q52,lw_crf3b_53 as Q53,lw_crf3b_54 as Q54,lw_crf3b_55 as Q55,lw_crf3b_56 as Q56,lw_crf3b_57 as Q57,lw_crf3b_58 as Q58,lw_crf3b_59 as Q59,(CASE    WHEN a.lw_crf3b_60 like '7:%' THEN '7'    ELSE a.lw_crf3b_60 END)  as Q60,lw_crf3b_61 as Q61,(CASE    WHEN a.lw_crf3b_62 like '6:%' THEN '6'    ELSE a.lw_crf3b_62 END) as Q62,lw_crf3b_63 as Q63,lw_crf3b_64 as Q64,lw_crf3b_65a as Q65_A,lw_crf3b_65b as Q65_B,lw_crf3b_65c as Q65_C,lw_crf3b_65d as Q65_D,lw_crf3b_65e as Q65_E,lw_crf3b_65f as Q65_F,lw_crf3b_65g as Q65_G,lw_crf3b_65h as Q65_H,lw_crf3b_65i as Q65_I,lw_crf3b_65j as Q65_J,lw_crf3b_65k as Q65_K,lw_crf3b_65l as Q65_L,(CASE    WHEN a.lw_crf3b_65m like '1:%' THEN '1'    WHEN a.lw_crf3b_65m not like '1:%' THEN a.lw_crf3b_65m END)  as Q65_M,(CASE    WHEN a.lw_crf3b_65m like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_65m, ':', 2), ':', -1)      END)  as  Q65_M_DESCRIPTION,      ((lw_crf3b_66a * 1440) + (lw_crf3b_66b * 60)  + lw_crf3b_66c) as Q66,lw_crf3b_67 as Q67,                    ((lw_crf3b_68a * 1440) + (lw_crf3b_68b * 60)  + lw_crf3b_68c) as Q68,       lw_crf3b_69 as Q69,lw_crf3b_70a as Q70_A,lw_crf3b_70b as Q70_B,lw_crf3b_70c as Q70_C,lw_crf3b_70d as Q70_D,lw_crf3b_70e as Q70_E,lw_crf3b_70f as Q70_F,lw_crf3b_70g as Q70_G,lw_crf3b_70h as Q70_H,lw_crf3b_70i as Q70_I,lw_crf3b_70j as Q70_J,lw_crf3b_70k as Q70_K,lw_crf3b_70l as Q70_L,lw_crf3b_70m as Q70_M,lw_crf3b_70n as Q70_N,(CASE    WHEN a.lw_crf3b_70o like '1:%' THEN '1'    WHEN a.lw_crf3b_70o not like '1:%' THEN a.lw_crf3b_70o END)  as Q70_O,(CASE    WHEN a.lw_crf3b_70o like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_70o, ':', 2), ':', -1)      END)  as  Q70_O_DESCRIPTION,lw_crf3b_71a as Q71_A,lw_crf3b_71b as Q71_B,lw_crf3b_71c as Q71_C,lw_crf3b_71d as Q71_D,lw_crf3b_71e as Q71_E,lw_crf3b_71f as Q71_F,lw_crf3b_71g as Q71_G,lw_crf3b_71h as Q71_H,lw_crf3b_71i as Q71_I,lw_crf3b_71j as Q71_J,lw_crf3b_71k as Q71_K,(CASE    WHEN a.lw_crf3b_71l like '1:%' THEN '1'    WHEN a.lw_crf3b_71l not like '1:%' THEN a.lw_crf3b_71l END)  as Q71_L,(CASE    WHEN a.lw_crf3b_71l like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_71l, ':', 2), ':', -1)      END)  as  Q71_L_DESCRITION,lw_crf3b_72 as Q72,lw_crf3b_73a as Q73_A,lw_crf3b_73b as Q73_B,lw_crf3b_73c as Q73_C,lw_crf3b_73d as Q73_D,lw_crf3b_73e as Q73_E,lw_crf3b_73f as Q73_F,lw_crf3b_73g as Q73_G,lw_crf3b_73h as Q73_H,lw_crf3b_73i as Q73_I,lw_crf3b_73j as Q73_J,lw_crf3b_73k as Q73_K,lw_crf3b_73l as Q73_L,lw_crf3b_73m as Q73_M,lw_crf3b_73n as Q73_N,lw_crf3b_73o as Q73_O,lw_crf3b_73p as Q73_P,lw_crf3b_73q as Q73_Q,lw_crf3b_73r as Q73_R,lw_crf3b_73s as Q73_S,lw_crf3b_73t as Q73_T,lw_crf3b_73u as Q73_U,lw_crf3b_73v as Q73_V,lw_crf3b_73w as Q73_W,lw_crf3b_73x as Q73_X,lw_crf3b_73y as Q73_Y,(CASE    WHEN (a.lw_crf3b_73z !='2' and a.lw_crf3b_73z !='') THEN '1'    WHEN a.lw_crf3b_73z ='2'  THEN '2' END)  as Q73_Z, (CASE    WHEN (a.lw_crf3b_73z !='2' and a.lw_crf3b_73z !='') THEN  SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_73z, ':', 2), ':', -1)  END)  as Q73_Z_DESCRIPTION, lw_crf3b_74 as Q74,lw_crf3b_75a as Q75_A,lw_crf3b_75b as Q75_B,lw_crf3b_75c as Q75_C,lw_crf3b_75d as Q75_D,lw_crf3b_75e as Q75_E,lw_crf3b_75f as Q75_F,lw_crf3b_75g as Q75_G,lw_crf3b_75h as Q75_H,lw_crf3b_75i as Q75_I,lw_crf3b_75j as Q75_J,lw_crf3b_75k as Q75_K,lw_crf3b_75l as Q75_L,lw_crf3b_75m as Q75_M,lw_crf3b_76 as Q76,lw_crf3b_77a as Q77_A,lw_crf3b_77b as Q77_B,lw_crf3b_77c as Q77_C,lw_crf3b_77d as Q77_D,lw_crf3b_77e as Q77_E, lw_crf3b_77f as Q77_F, lw_crf3b_77g as Q77_G, lw_crf3b_77h as Q77_H,(CASE    WHEN (a.lw_crf3b_77i !='2' and a.lw_crf3b_77i !='') THEN '1'    WHEN a.lw_crf3b_77i ='2'  THEN '2' END)  as Q77_I, (CASE    WHEN (a.lw_crf3b_77i !='2' and a.lw_crf3b_77i !='') THEN a.lw_crf3b_77i END)  as Q77_I_DESCRIPTION, lw_crf3b_78a as Q78_A,lw_crf3b_78b as Q78_B,lw_crf3b_79 as Q79,lw_crf3b_80a as Q80a,lw_crf3b_80b as Q80b,lw_crf3b_81 as Q81,lw_crf3b_82 as Q82,lw_crf3b_83a as Q83a,lw_crf3b_83b as Q83b,lw_crf3b_84 as Q84,lw_crf3b_85 as Q85,lw_crf3b_86 as Q86,lw_crf3b_87 as Q87,lw_crf3b_88a as Q88a,lw_crf3b_88ba as Q88_B1,lw_crf3b_88bb as Q88_B2,lw_crf3b_88bc as Q88_B3,lw_crf3b_88bd as Q88_B4,lw_crf3b_89 as Q89,lw_crf3b_90 as Q90,lw_crf3b_91 as Q91,lw_crf3b_92 as Q92,lw_crf3b_93 as Q93,lw_crf3b_94 as Q94,lw_crf3b_95 as Q95,lw_crf3b_96a as Q96_A,lw_crf3b_96b as Q96_B,lw_crf3b_96c as Q96_C,lw_crf3b_96d as Q96_D,lw_crf3b_96e as Q96_E,lw_crf3b_96f as Q96_F, lw_crf3b_96g as Q96_G,lw_crf3b_96h as Q96_H,lw_crf3b_96i as Q96_I,lw_crf3b_96j as Q96_J,lw_crf3b_96k as Q96_K,lw_crf3b_96l as Q96_L,lw_crf3b_96m as Q96_M,lw_crf3b_96n as Q96_N,lw_crf3b_96o as Q96_O,(CASE    WHEN a.lw_crf3b_96p like '1:%' THEN '1'    WHEN a.lw_crf3b_96p not like '1:%' THEN a.lw_crf3b_96p END)  as Q96_P, (CASE    WHEN a.lw_crf3b_96p like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_96p, ':', 2), ':', -1)      END)  as  Q96_P_DESCRIPTION, lw_crf3b_97 as Q97,lw_crf3b_98 as Q98,lw_crf3b_99 as Q99,lw_crf3b_100 as Q100,lw_crf3b_101a as Q101_A,lw_crf3b_101b as Q101_B,lw_crf3b_101c as Q101_C,lw_crf3b_101d as Q101_D,lw_crf3b_101e as Q101_E,lw_crf3b_101f as Q101_F,lw_crf3b_101g as Q101_G,lw_crf3b_101h as Q101_H,lw_crf3b_101i as Q101_I,lw_crf3b_101j as Q101_J,lw_crf3b_101k as Q101_K, (CASE    WHEN a.lw_crf3b_101l like '1:%' THEN '1'    WHEN a.lw_crf3b_101l not like '1:%' THEN a.lw_crf3b_101l END)  as Q101_L, (CASE    WHEN a.lw_crf3b_101l like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_101l, ':', 2), ':', -1)      END)  as  Q101_L_DESCRIPTION, lw_crf3b_102 as Q102,lw_crf3b_103 as Q103,lw_crf3b_104a as Q104_A,lw_crf3b_104b as Q104_B,lw_crf3b_104c as Q104_C,lw_crf3b_105a as Q105_A,lw_crf3b_105b as Q105_B,lw_crf3b_105c as Q105_C,lw_crf3b_105d as Q105_D,lw_crf3b_106 as Q106 		from form_crf_3b as a inner join pw as c on a.assis_id=c.id inner join studies as e on e.study_id=a.study_id", con);
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
                Response.AddHeader("content-disposition", "attachment;filename=BMFG CRF3b (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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