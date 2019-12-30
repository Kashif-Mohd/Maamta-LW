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

                cmd = new MySqlCommand("select c.assis_id as Q1,e.study_code as Q2, a.lw_crf3b_2 as Q3_D,a.lw_crf3b_3 as Q3_T,		(CASE    WHEN a.lw_crf3b_13 like '14:%' THEN '14'    ELSE a.lw_crf3b_13 END)  as Q13,	(CASE    WHEN a.lw_crf3b_14 like '8:%' THEN '8'    ELSE a.lw_crf3b_14 END)  as Q14,			lw_crf3b_15 as Q15, lw_crf3b_16 as Q16,lw_crf3b_17 as Q17,(CASE    WHEN a.lw_crf3b_18 like '8:%' THEN '8'    ELSE  	a.lw_crf3b_18 END) as Q18,(CASE    WHEN a.lw_crf3b_19 like '5:%' THEN '5'    ELSE  	a.lw_crf3b_19 END) as Q19, (CASE    WHEN a.lw_crf3b_20 like '6:%' THEN '6'    ELSE a.lw_crf3b_20 END) as Q20 	, (CASE    WHEN a.lw_crf3b_21 like '8:%' THEN '8'    ELSE a.lw_crf3b_21 END) as Q21, lw_crf3b_22 as Q22,lw_crf3b_23 as Q23, (CASE    WHEN a.lw_crf3b_24 like '8:%' THEN '8'    ELSE a.lw_crf3b_24 END) as Q24, lw_crf3b_25 as Q25,lw_crf3b_26 as Q26,lw_crf3b_27 as Q27,(CASE    WHEN a.lw_crf3b_28 like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_28, ':', 2), ':', -1)      END)  as Q28,lw_crf3b_29a as Q29_A,lw_crf3b_29b as Q29_B,lw_crf3b_29c as Q29_C,lw_crf3b_29d as Q29_D,(CASE    WHEN a.lw_crf3b_29e like '1:%' THEN '1'    WHEN a.lw_crf3b_29e not like '1:%' THEN a.lw_crf3b_29e END)  as Q29_E,(CASE    WHEN a.lw_crf3b_29e like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_29e, ':', 2), ':', -1)      END)  as  Q29_E_DESCRIPTION,lw_crf3b_30 as Q30,(CASE    WHEN a.lw_crf3b_31 like '7:%' THEN '7'    WHEN a.lw_crf3b_31 not like '7:%' THEN a.lw_crf3b_31 END)  as Q31,(CASE    WHEN a.lw_crf3b_31 like '7:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_31, ':', 2), ':', -1)      END)  as  Q31_7_DESCRIPTION,lw_crf3b_32 as Q32,lw_crf3b_33 as Q33,lw_crf3b_34 as Q34,lw_crf3b_35 as Q35,lw_crf3b_36a as Q36_A,lw_crf3b_36b as Q36_B,lw_crf3b_36c as Q36_C,lw_crf3b_36d as Q36_D,lw_crf3b_36e as Q36_E,lw_crf3b_36f as Q36_F,lw_crf3b_36g as Q36_G,lw_crf3b_36h as Q36_H,lw_crf3b_36i as Q36_I,lw_crf3b_36j as Q36_J,lw_crf3b_36k as Q36_K,lw_crf3b_36l as Q36_L,lw_crf3b_36m as Q36_M,lw_crf3b_36n as Q36_N,lw_crf3b_36o as Q36_O,lw_crf3b_36p as Q36_P,lw_crf3b_36q as Q36_Q,lw_crf3b_36r as Q36_R,lw_crf3b_36s as Q36_S,lw_crf3b_36t as Q36_T,lw_crf3b_36u as Q36_U,lw_crf3b_36v as Q36_V,lw_crf3b_36w as Q36_W,lw_crf3b_36x as Q36_X,(CASE    WHEN a.lw_crf3b_36y like '1:%' THEN '1'    WHEN a.lw_crf3b_36y not like '1:%' THEN a.lw_crf3b_36y END)  as Q36_Y,(CASE    WHEN a.lw_crf3b_36y like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_36y, ':', 2), ':', -1)      END)  as  Q36_Y_DESCRIPTION,lw_crf3b_37 as Q37,(CASE    WHEN a.lw_crf3b_38 like '7:%' THEN '7'    WHEN a.lw_crf3b_38 not like '7:%' THEN a.lw_crf3b_38 END)  as Q38,(CASE    WHEN a.lw_crf3b_38 like '7:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_38, ':', 2), ':', -1)      END)  as  Q38_DESCRIPTION,lw_crf3b_39a as Q39_A,lw_crf3b_39b as Q39_B,lw_crf3b_39c as Q39_C,lw_crf3b_39d as Q39_D,lw_crf3b_39e as Q39_E,lw_crf3b_39f as Q39_F,lw_crf3b_39g as Q39_G,lw_crf3b_39h as Q39_H,lw_crf3b_39i as Q39_I,(CASE    WHEN a.lw_crf3b_39j like '1:%' THEN '1'    WHEN a.lw_crf3b_39j not like '1:%' THEN a.lw_crf3b_39j END)  as Q39_J,(CASE    WHEN a.lw_crf3b_39j like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_39j, ':', 2), ':', -1)      END)  as  Q39_J_DESCRIPTION, lw_crf3b_40a as Q40_A,lw_crf3b_40b as Q40_B,lw_crf3b_40c as Q40_C,lw_crf3b_40d as Q40_D,lw_crf3b_40e as Q40_E,lw_crf3b_40f as Q40_F,lw_crf3b_40g as Q40_G,lw_crf3b_40h as Q40_H,lw_crf3b_40i as Q40_I,lw_crf3b_40j as Q40_J,lw_crf3b_40k as Q40_K,lw_crf3b_40l as Q40_L,lw_crf3b_40m as Q40_M,lw_crf3b_40n as Q40_N,lw_crf3b_40o as Q40_O,lw_crf3b_40p as Q40_P, lw_crf3b_40q as Q40_Q,(CASE    WHEN a.lw_crf3b_40r like '1:%' THEN '1'    WHEN a.lw_crf3b_40r not like '1:%' THEN a.lw_crf3b_40r END)  as Q40_R,(CASE    WHEN a.lw_crf3b_40r like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_40r, ':', 2), ':', -1)      END)  as  Q40_R_DESCRIPTION, lw_crf3b_41 as Q41,			(CASE    WHEN a.lw_crf3b_42 like '7:%' THEN '7'    ELSE a.lw_crf3b_42 END) as Q42,lw_crf3b_43a as Q43_A,lw_crf3b_43b as Q43_B,lw_crf3b_43c as Q43_C,lw_crf3b_43d as Q43_D,lw_crf3b_43e as Q43_E,lw_crf3b_43f as Q43_F,lw_crf3b_43g as Q43_G,lw_crf3b_43h as Q43_H,lw_crf3b_43i as Q43_I,lw_crf3b_43j as Q43_J, (CASE    WHEN a.lw_crf3b_43k like '1:%' THEN '1'    WHEN a.lw_crf3b_43k not like '1:%' THEN a.lw_crf3b_43k END)  as Q43_K,(CASE    WHEN a.lw_crf3b_43k like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_43k, ':', 2), ':', -1)      END)  as  Q43_K_DESCRIPTION, lw_crf3b_44 as Q44 , (CASE  WHEN a.lw_crf3b_45 like '5:%' THEN '5' 	WHEN a.lw_crf3b_45 like '6:%' THEN '6' 	 WHEN a.lw_crf3b_45 like '7:%' THEN '7'   WHEN a.lw_crf3b_45 like '8:%' THEN '8'	 WHEN a.lw_crf3b_45 like '10:%' THEN '10'  	WHEN a.lw_crf3b_45 like '11:%' THEN '11'   ELSE  a.lw_crf3b_45  END) as Q45,   lw_crf3b_46 as Q46,lw_crf3b_47 as Q47,		(CASE    WHEN a.lw_crf3b_48 like '3:%' THEN '3'    ELSE a.lw_crf3b_48 END) as Q48, 		lw_crf3b_49 as Q49,lw_crf3b_50 as Q50,(CASE    WHEN a.lw_crf3b_51 like '7:%' THEN '7'    ELSE a.lw_crf3b_51 END)  as Q51, lw_crf3b_52 as Q52,lw_crf3b_53 as Q53,lw_crf3b_54 as Q54,lw_crf3b_55 as Q55,lw_crf3b_56 as Q56,lw_crf3b_57 as Q57,lw_crf3b_58 as Q58,lw_crf3b_59 as Q59,(CASE    WHEN a.lw_crf3b_60 like '7:%' THEN '7'    ELSE a.lw_crf3b_60 END)  as Q60,lw_crf3b_61 as Q61,(CASE    WHEN a.lw_crf3b_62 like '6:%' THEN '6'    ELSE a.lw_crf3b_62 END) as Q62,lw_crf3b_63 as Q63,lw_crf3b_64 as Q64,lw_crf3b_65a as Q65_A,lw_crf3b_65b as Q65_B,lw_crf3b_65c as Q65_C,lw_crf3b_65d as Q65_D,lw_crf3b_65e as Q65_E,lw_crf3b_65f as Q65_F,lw_crf3b_65g as Q65_G,lw_crf3b_65h as Q65_H,lw_crf3b_65i as Q65_I,lw_crf3b_65j as Q65_J,lw_crf3b_65k as Q65_K,lw_crf3b_65l as Q65_L,(CASE    WHEN a.lw_crf3b_65m like '1:%' THEN '1'    WHEN a.lw_crf3b_65m not like '1:%' THEN a.lw_crf3b_65m END)  as Q65_M,(CASE    WHEN a.lw_crf3b_65m like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_65m, ':', 2), ':', -1)      END)  as  Q65_M_DESCRIPTION,      ((lw_crf3b_66a * 1440) + (lw_crf3b_66b * 60)  + lw_crf3b_66c) as Q66,lw_crf3b_67 as Q67,                    ((lw_crf3b_68a * 1440) + (lw_crf3b_68b * 60)  + lw_crf3b_68c) as Q68,       lw_crf3b_69 as Q69,lw_crf3b_70a as Q70_A,lw_crf3b_70b as Q70_B,lw_crf3b_70c as Q70_C,lw_crf3b_70d as Q70_D,lw_crf3b_70e as Q70_E,lw_crf3b_70f as Q70_F,lw_crf3b_70g as Q70_G,lw_crf3b_70h as Q70_H,lw_crf3b_70i as Q70_I,lw_crf3b_70j as Q70_J,lw_crf3b_70k as Q70_K,lw_crf3b_70l as Q70_L,lw_crf3b_70m as Q70_M,lw_crf3b_70n as Q70_N,(CASE    WHEN a.lw_crf3b_70o like '1:%' THEN '1'    WHEN a.lw_crf3b_70o not like '1:%' THEN a.lw_crf3b_70o END)  as Q70_O,(CASE    WHEN a.lw_crf3b_70o like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_70o, ':', 2), ':', -1)      END)  as  Q70_O_DESCRIPTION,lw_crf3b_71a as Q71_A,lw_crf3b_71b as Q71_B,lw_crf3b_71c as Q71_C,lw_crf3b_71d as Q71_D,lw_crf3b_71e as Q71_E,lw_crf3b_71f as Q71_F,lw_crf3b_71g as Q71_G,lw_crf3b_71h as Q71_H,lw_crf3b_71i as Q71_I,lw_crf3b_71j as Q71_J,lw_crf3b_71k as Q71_K,(CASE    WHEN a.lw_crf3b_71l like '1:%' THEN '1'    WHEN a.lw_crf3b_71l not like '1:%' THEN a.lw_crf3b_71l END)  as Q71_L,(CASE    WHEN a.lw_crf3b_71l like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_71l, ':', 2), ':', -1)      END)  as  Q71_L_DESCRITION,lw_crf3b_72 as Q72,lw_crf3b_73a as Q73_A,lw_crf3b_73b as Q73_B,lw_crf3b_73c as Q73_C,lw_crf3b_73d as Q73_D,lw_crf3b_73e as Q73_E,lw_crf3b_73f as Q73_F,lw_crf3b_73g as Q73_G,lw_crf3b_73h as Q73_H,lw_crf3b_73i as Q73_I,lw_crf3b_73j as Q73_J,lw_crf3b_73k as Q73_K,lw_crf3b_73l as Q73_L,lw_crf3b_73m as Q73_M,lw_crf3b_73n as Q73_N,lw_crf3b_73o as Q73_O,lw_crf3b_73p as Q73_P,lw_crf3b_73q as Q73_Q,lw_crf3b_73r as Q73_R,lw_crf3b_73s as Q73_S,lw_crf3b_73t as Q73_T,lw_crf3b_73u as Q73_U,lw_crf3b_73v as Q73_V,lw_crf3b_73w as Q73_W,lw_crf3b_73x as Q73_X,lw_crf3b_73y as Q73_Y,(CASE    WHEN (a.lw_crf3b_73z !='2' and a.lw_crf3b_73z !='') THEN '1'    WHEN a.lw_crf3b_73z ='2'  THEN '2' END)  as Q73_Z, (CASE    WHEN (a.lw_crf3b_73z !='2' and a.lw_crf3b_73z !='') THEN  SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_73z, ':', 2), ':', -1)  END)  as Q73_Z_DESCRIPTION, lw_crf3b_74 as Q74,lw_crf3b_75a as Q75_A,lw_crf3b_75b as Q75_B,lw_crf3b_75c as Q75_C,lw_crf3b_75d as Q75_D,lw_crf3b_75e as Q75_E,lw_crf3b_75f as Q75_F,lw_crf3b_75g as Q75_G,lw_crf3b_75h as Q75_H,lw_crf3b_75i as Q75_I,lw_crf3b_75j as Q75_J,lw_crf3b_75k as Q75_K,lw_crf3b_75l as Q75_L,lw_crf3b_75m as Q75_M,lw_crf3b_76 as Q76,lw_crf3b_77a as Q77_A,lw_crf3b_77b as Q77_B,lw_crf3b_77c as Q77_C,lw_crf3b_77d as Q77_D,lw_crf3b_77e as Q77_E, lw_crf3b_77f as Q77_F, lw_crf3b_77g as Q77_G, lw_crf3b_77h as Q77_H,(CASE    WHEN (a.lw_crf3b_77i !='2' and a.lw_crf3b_77i !='') THEN '1'    WHEN a.lw_crf3b_77i ='2'  THEN '2' END)  as Q77_I, (CASE    WHEN (a.lw_crf3b_77i !='2' and a.lw_crf3b_77i !='') THEN a.lw_crf3b_77i END)  as Q77_I_DESCRIPTION, lw_crf3b_78a as Q78_A,lw_crf3b_78b as Q78_B,lw_crf3b_79 as Q79,lw_crf3b_80a as Q80a,lw_crf3b_80b as Q80b,lw_crf3b_81 as Q81,lw_crf3b_82 as Q82,lw_crf3b_83a as Q83a,lw_crf3b_83b as Q83b,lw_crf3b_84 as Q84,lw_crf3b_85 as Q85,lw_crf3b_86 as Q86,lw_crf3b_87 as Q87,lw_crf3b_88a as Q88a,lw_crf3b_88ba as Q88_B1,lw_crf3b_88bb as Q88_B2,lw_crf3b_88bc as Q88_B3,lw_crf3b_88bd as Q88_B4,lw_crf3b_89 as Q89,lw_crf3b_90 as Q90,lw_crf3b_91 as Q91,lw_crf3b_92 as Q92,lw_crf3b_93 as Q93,lw_crf3b_94 as Q94,lw_crf3b_95 as Q95,lw_crf3b_96a as Q96_A,lw_crf3b_96b as Q96_B,lw_crf3b_96c as Q96_C,lw_crf3b_96d as Q96_D,lw_crf3b_96e as Q96_E,lw_crf3b_96f as Q96_F, lw_crf3b_96g as Q96_G,lw_crf3b_96h as Q96_H,lw_crf3b_96i as Q96_I,lw_crf3b_96j as Q96_J,lw_crf3b_96k as Q96_K,lw_crf3b_96l as Q96_L,lw_crf3b_96m as Q96_M,lw_crf3b_96n as Q96_N,lw_crf3b_96o as Q96_O,(CASE    WHEN a.lw_crf3b_96p like '1:%' THEN '1'    WHEN a.lw_crf3b_96p not like '1:%' THEN a.lw_crf3b_96p END)  as Q96_P, (CASE    WHEN a.lw_crf3b_96p like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_96p, ':', 2), ':', -1)      END)  as  Q96_P_DESCRIPTION, lw_crf3b_97 as Q97,lw_crf3b_98 as Q98,lw_crf3b_99 as Q99,lw_crf3b_100 as Q100,lw_crf3b_101a as Q101_A,lw_crf3b_101b as Q101_B,lw_crf3b_101c as Q101_C,lw_crf3b_101d as Q101_D,lw_crf3b_101e as Q101_E,lw_crf3b_101f as Q101_F,lw_crf3b_101g as Q101_G,lw_crf3b_101h as Q101_H,lw_crf3b_101i as Q101_I,lw_crf3b_101j as Q101_J,lw_crf3b_101k as Q101_K, (CASE    WHEN a.lw_crf3b_101l like '1:%' THEN '1'    WHEN a.lw_crf3b_101l not like '1:%' THEN a.lw_crf3b_101l END)  as Q101_L, (CASE    WHEN a.lw_crf3b_101l like '1:%' THEN SUBSTRING_INDEX(SUBSTRING_INDEX(a.lw_crf3b_101l, ':', 2), ':', -1)      END)  as  Q101_L_DESCRIPTION, lw_crf3b_102 as Q102,lw_crf3b_103 as Q103,lw_crf3b_104a as Q104_A,lw_crf3b_104b as Q104_B,lw_crf3b_104c as Q104_C,lw_crf3b_105a as Q105_A,lw_crf3b_105b as Q105_B,lw_crf3b_105c as Q105_C,lw_crf3b_105d as Q105_D,lw_crf3b_106 as Q106 		from form_crf_3b as a inner join pw as c on a.assis_id=c.id inner join studies as e on e.study_id=a.study_id", con);
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