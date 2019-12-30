﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class dangersign : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                byEnrollmentColor();

                Session["WebForm"] = "DangerSign";
                ShowDataDSbyEnrollment();
                txtdssidbyEnrollment.Focus();
            }
        }


        protected void btnbyEnrollment_Click(object sender, EventArgs e)
        {
            byEnrollmentColor();
            ShowDataDSbyEnrollment();
            txtdssidbyEnrollment.Focus();
        }


        protected void btnbyFollowups_Click(object sender, EventArgs e)
        {
            byFollowupsColor();
            ShowDataDSbyFollowups();
            txtdssidbyFollowups.Focus();
        }


        private void byEnrollmentColor()
        {

            btnbyFollowups.Style.Add("color", "#adadad");
            btnbyFollowups.Style.Add("background-color", "#e0e0e0");
            btnbyEnrollment.Style.Add("color", "white");
            btnbyEnrollment.Style.Add("background-color", "#55efc4");
            divbyEnrollment.Visible = true;
            divbyFollowups.Visible = false;
        }

        private void byFollowupsColor()
        {
            btnbyFollowups.Style.Add("color", "white");
            btnbyFollowups.Style.Add("background-color", "#55efc4");
            btnbyEnrollment.Style.Add("color", "#adadad");
            btnbyEnrollment.Style.Add("background-color", "#e0e0e0");
            divbyEnrollment.Visible = false;
            divbyFollowups.Visible = true;
        }









        protected void btnSearchbyEnrollment_Click(object sender, EventArgs e)
        {
            ShowDataDSbyEnrollment();
            txtdssidbyEnrollment.Focus();
        }


        private void ShowDataDSbyEnrollment()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select a.assis_id,a.study_code,a.dssid,a.q5 as 'Woman_Name',a.q6 as 'Husband_Name', a.lw_crf3b_2 as 'Date_of_Enrollment',concat(if(a.lw_crf3b_73a!=2,'Difficult in feeding, ',''), if(a.lw_crf3b_73b!=2,'Cough, ',''), if(a.lw_crf3b_73c!=2,'Cold/Flu/Runny nose, ','') , if(a.lw_crf3b_73d!=2,'Difficulty in breathing / Fast respiratory rate, ','') , if(a.lw_crf3b_73e!=2,'Convulsions, ','') , if(a.lw_crf3b_73f!=2,'Fever, ','') , if(a.lw_crf3b_73g!=2,'Hypothermia, ','') , if(a.lw_crf3b_73h!=2,'Lethargy or no movement, ','') , if(a.lw_crf3b_73i!=2,'Pustules, ','') , if(a.lw_crf3b_73j!=2,'Jaundice, ','') , if(a.lw_crf3b_73k!=2,'Umbilical redness or discharge, ','') , if(a.lw_crf3b_73l!=2,'Vomiting, ','') , if(a.lw_crf3b_73m!=2,'Diarrhea, ','') , if(a.lw_crf3b_73n!=2,'Oral Thrush, ','') , if(a.lw_crf3b_73o!=2,'Irritability or too much crying, ','') , if(a.lw_crf3b_73p!=2,'Redness of eyes or watery discharge, ','') , if(a.lw_crf3b_73q!=2,'Grunting, ','') , if(a.lw_crf3b_73r!=2,'Lips / tongue turning blue or black, ','') , if(a.lw_crf3b_73s!=2,'Peripheral cyanosis, ','') , if(a.lw_crf3b_73t!=2,'Bleeding from nose, ','') , if(a.lw_crf3b_73u!=2,'Constipation, ','') , if(a.lw_crf3b_73v!=2,'Dysentery, ','') , if(a.lw_crf3b_73w!=2,'Urine stopped, ','') , if(a.lw_crf3b_73x!=2,'Ear discharge or pus, ','') , if(a.lw_crf3b_73y!=2,'Chest congestion, ','') , if(a.lw_crf3b_73z=2,'', a.lw_crf3b_73z)) as q73,	   (CASE WHEN a.lw_crf3b_74= '1' THEN 'Yes' WHEN a.lw_crf3b_74 = '2' THEN 'No' WHEN a.lw_crf3b_74 = '3' THEN 'Unnecessary' END) as q74,		concat(if(a.lw_crf3b_75a!=2,'Vital Pakistan / AKU Center, ',''), if(a.lw_crf3b_75b!=2,'Attiya Hospital, ',''), if(a.lw_crf3b_75c!=2,'Koohi Goth Hospital, ','') , if(a.lw_crf3b_75d!=2,'Jinnah, ','') , if(a.lw_crf3b_75e!=2,'Civil, ','') , if(a.lw_crf3b_75f!=2,'Korangi-5 govt. hospital, ','') , if(a.lw_crf3b_75h!=2,'Private Hospital, ','') , if(a.lw_crf3b_75i!=2,'Clinic, ','') , if(a.lw_crf3b_75j!=2,'Rural Health Center, ','') , if(a.lw_crf3b_75k!=2,'Dispensary, ','') , if(a.lw_crf3b_75l!=2,'Medical Store, ','') , if(a.lw_crf3b_75m!=2,'Self Medication, ',''),  if(a.lw_crf3b_75g=2,'', a.lw_crf3b_75g)) as q75,	(CASE WHEN a.lw_crf3b_76= '1' THEN 'Yes' WHEN a.lw_crf3b_76 = '2' THEN 'No' WHEN a.lw_crf3b_76 = '9' THEN 'Don`t Know' END) as q76,		concat(if(a.lw_crf3b_77a!=2,'Kept in incubator, ',''), if(a.lw_crf3b_77b!=2,'Injectable antibiotics were administered, ',''), if(a.lw_crf3b_77c!=2,'Antibiotic Syrup was given, ','') , if(a.lw_crf3b_77d!=2,'Drip was administered, ','') , if(a.lw_crf3b_77e!=2,'Oxygen was given through bag,tube or mask, ','') , if(a.lw_crf3b_77f!=2,'Kept on a ventilator, ','') , if(a.lw_crf3b_77g!=2,'Baby was kept on NG feed, ','') , if(a.lw_crf3b_77h!=2,'Some other medicine-not powdered one, ','') , if(a.lw_crf3b_77i=2,'', a.lw_crf3b_77i)) as q77			 from view_crf3b as a where a.lw_crf3b_72=1 and a.dssid like '" + txtdssidbyEnrollment.Text + "%' and  not exists (select b.* from view_crf4b as b where b.q19=1 and a.study_code=b.study_code)", con);
                //cmd = new MySqlCommand("select a.assis_id,a.study_code,a.dssid,a.q5 as 'Woman_Name',a.q6 as 'Husband_Name', a.lw_crf3b_2 as 'Date_of_Enrollment',concat(if(a.lw_crf3b_73a=1,'Difficult in feeding, ',''), if(a.lw_crf3b_73b=1,'Cough, ',''), if(a.lw_crf3b_73c=1,'Cold/Flu/Runny nose, ','') , if(a.lw_crf3b_73d=1,'Difficulty in breathing / Fast respiratory rate, ','') , if(a.lw_crf3b_73e=1,'Convulsions, ','') , if(a.lw_crf3b_73f=1,'Fever, ','') , if(a.lw_crf3b_73g=1,'Hypothermia, ','') , if(a.lw_crf3b_73h=1,'Lethargy or no movement, ','') , if(a.lw_crf3b_73i=1,'Pustules, ','') , if(a.lw_crf3b_73j=1,'Jaundice, ','') , if(a.lw_crf3b_73k=1,'Umbilical redness or discharge, ','') , if(a.lw_crf3b_73l=1,'Vomiting, ','') , if(a.lw_crf3b_73m=1,'Diarrhea, ','') , if(a.lw_crf3b_73n=1,'Oral Thrush, ','') , if(a.lw_crf3b_73o=1,'Irritability or too much crying, ','') , if(a.lw_crf3b_73p=1,'Redness of eyes or watery discharge, ','') , if(a.lw_crf3b_73q=1,'Grunting, ','') , if(a.lw_crf3b_73r=1,'Lips / tongue turning blue or black, ','') , if(a.lw_crf3b_73s=1,'Peripheral cyanosis, ','') , if(a.lw_crf3b_73t=1,'Bleeding from nose, ','') , if(a.lw_crf3b_73u=1,'Constipation, ','') , if(a.lw_crf3b_73v=1,'Dysentery, ','') , if(a.lw_crf3b_73w=1,'Urine stopped, ','') , if(a.lw_crf3b_73x=1,'Ear discharge or pus, ','') , if(a.lw_crf3b_73y=1,'Chest congestion, ','') , if(a.lw_crf3b_73z=2,'', a.lw_crf3b_73z)) as 'Problem_Disease'			 from view_crf3b as a where a.lw_crf3b_72=1 and a.dssid like '" + txtdssidbyEnrollment.Text + "%' and  not exists (select b.* from view_crf4b as b where b.q19=1 and a.study_code=b.study_code)", con);
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




      




        protected void btnExportbyEnrollment_Click(object sender, EventArgs e)
        {
            ShowDataDSbyEnrollment();
            if (GridView1.Rows.Count != 0)
            {
                ExcelExportDSbyEnrollment();
            }

            txtdssidbyEnrollment.Focus();
        }





        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


        private void ExportDSbyEnrollment()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select a.assis_id,a.study_code,a.dssid,a.q5 as 'Woman_Name',a.q6 as 'Husband_Name', a.lw_crf3b_2 as 'Date_of_Enrollment',concat(if(a.lw_crf3b_73a!=2,'Difficult in feeding, ',''), if(a.lw_crf3b_73b!=2,'Cough, ',''), if(a.lw_crf3b_73c!=2,'Cold/Flu/Runny nose, ','') , if(a.lw_crf3b_73d!=2,'Difficulty in breathing / Fast respiratory rate, ','') , if(a.lw_crf3b_73e!=2,'Convulsions, ','') , if(a.lw_crf3b_73f!=2,'Fever, ','') , if(a.lw_crf3b_73g!=2,'Hypothermia, ','') , if(a.lw_crf3b_73h!=2,'Lethargy or no movement, ','') , if(a.lw_crf3b_73i!=2,'Pustules, ','') , if(a.lw_crf3b_73j!=2,'Jaundice, ','') , if(a.lw_crf3b_73k!=2,'Umbilical redness or discharge, ','') , if(a.lw_crf3b_73l!=2,'Vomiting, ','') , if(a.lw_crf3b_73m!=2,'Diarrhea, ','') , if(a.lw_crf3b_73n!=2,'Oral Thrush, ','') , if(a.lw_crf3b_73o!=2,'Irritability or too much crying, ','') , if(a.lw_crf3b_73p!=2,'Redness of eyes or watery discharge, ','') , if(a.lw_crf3b_73q!=2,'Grunting, ','') , if(a.lw_crf3b_73r!=2,'Lips / tongue turning blue or black, ','') , if(a.lw_crf3b_73s!=2,'Peripheral cyanosis, ','') , if(a.lw_crf3b_73t!=2,'Bleeding from nose, ','') , if(a.lw_crf3b_73u!=2,'Constipation, ','') , if(a.lw_crf3b_73v!=2,'Dysentery, ','') , if(a.lw_crf3b_73w!=2,'Urine stopped, ','') , if(a.lw_crf3b_73x!=2,'Ear discharge or pus, ','') , if(a.lw_crf3b_73y!=2,'Chest congestion, ','') , if(a.lw_crf3b_73z=2,'', a.lw_crf3b_73z)) as q73,	   (CASE WHEN a.lw_crf3b_74= '1' THEN 'Yes' WHEN a.lw_crf3b_74 = '2' THEN 'No' WHEN a.lw_crf3b_74 = '3' THEN 'Unnecessary' END) as q74,		concat(if(a.lw_crf3b_75a!=2,'Vital Pakistan / AKU Center, ',''), if(a.lw_crf3b_75b!=2,'Attiya Hospital, ',''), if(a.lw_crf3b_75c!=2,'Koohi Goth Hospital, ','') , if(a.lw_crf3b_75d!=2,'Jinnah, ','') , if(a.lw_crf3b_75e!=2,'Civil, ','') , if(a.lw_crf3b_75f!=2,'Korangi-5 govt. hospital, ','') , if(a.lw_crf3b_75h!=2,'Private Hospital, ','') , if(a.lw_crf3b_75i!=2,'Clinic, ','') , if(a.lw_crf3b_75j!=2,'Rural Health Center, ','') , if(a.lw_crf3b_75k!=2,'Dispensary, ','') , if(a.lw_crf3b_75l!=2,'Medical Store, ','') , if(a.lw_crf3b_75m!=2,'Self Medication, ',''),  if(a.lw_crf3b_75g=2,'', a.lw_crf3b_75g)) as q75,	(CASE WHEN a.lw_crf3b_76= '1' THEN 'Yes' WHEN a.lw_crf3b_76 = '2' THEN 'No' WHEN a.lw_crf3b_76 = '9' THEN 'Don`t Know' END) as q76,		concat(if(a.lw_crf3b_77a!=2,'Kept in incubator, ',''), if(a.lw_crf3b_77b!=2,'Injectable antibiotics were administered, ',''), if(a.lw_crf3b_77c!=2,'Antibiotic Syrup was given, ','') , if(a.lw_crf3b_77d!=2,'Drip was administered, ','') , if(a.lw_crf3b_77e!=2,'Oxygen was given through bag,tube or mask, ','') , if(a.lw_crf3b_77f!=2,'Kept on a ventilator, ','') , if(a.lw_crf3b_77g!=2,'Baby was kept on NG feed, ','') , if(a.lw_crf3b_77h!=2,'Some other medicine-not powdered one, ','') , if(a.lw_crf3b_77i=2,'', a.lw_crf3b_77i)) as q77			 from view_crf3b as a where a.lw_crf3b_72=1 and a.dssid like '" + txtdssidbyEnrollment.Text + "%' and  not exists (select b.* from view_crf4b as b where b.q19=1 and a.study_code=b.study_code)", con);
                //cmd = new MySqlCommand("select a.assis_id,a.study_code,a.dssid,a.q5 as 'Woman_Name',a.q6 as 'Husband_Name', a.lw_crf3b_2 as 'Date_of_Enrollment',concat(if(a.lw_crf3b_73a=1,'Difficult in feeding, ',''), if(a.lw_crf3b_73b=1,'Cough, ',''), if(a.lw_crf3b_73c=1,'Cold/Flu/Runny nose, ','') , if(a.lw_crf3b_73d=1,'Difficulty in breathing / Fast respiratory rate, ','') , if(a.lw_crf3b_73e=1,'Convulsions, ','') , if(a.lw_crf3b_73f=1,'Fever, ','') , if(a.lw_crf3b_73g=1,'Hypothermia, ','') , if(a.lw_crf3b_73h=1,'Lethargy or no movement, ','') , if(a.lw_crf3b_73i=1,'Pustules, ','') , if(a.lw_crf3b_73j=1,'Jaundice, ','') , if(a.lw_crf3b_73k=1,'Umbilical redness or discharge, ','') , if(a.lw_crf3b_73l=1,'Vomiting, ','') , if(a.lw_crf3b_73m=1,'Diarrhea, ','') , if(a.lw_crf3b_73n=1,'Oral Thrush, ','') , if(a.lw_crf3b_73o=1,'Irritability or too much crying, ','') , if(a.lw_crf3b_73p=1,'Redness of eyes or watery discharge, ','') , if(a.lw_crf3b_73q=1,'Grunting, ','') , if(a.lw_crf3b_73r=1,'Lips / tongue turning blue or black, ','') , if(a.lw_crf3b_73s=1,'Peripheral cyanosis, ','') , if(a.lw_crf3b_73t=1,'Bleeding from nose, ','') , if(a.lw_crf3b_73u=1,'Constipation, ','') , if(a.lw_crf3b_73v=1,'Dysentery, ','') , if(a.lw_crf3b_73w=1,'Urine stopped, ','') , if(a.lw_crf3b_73x=1,'Ear discharge or pus, ','') , if(a.lw_crf3b_73y=1,'Chest congestion, ','') , if(a.lw_crf3b_73z=2,'', a.lw_crf3b_73z)) as 'Problem_Disease'			 from view_crf3b as a where a.lw_crf3b_72=1 and a.dssid like '" + txtdssidbyEnrollment.Text + "%' and  not exists (select b.* from view_crf4b as b where b.q19=1 and a.study_code=b.study_code)", con);
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




        public void ExcelExportDSbyEnrollment()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=DSbyEnrollment (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2.AllowPaging = false;

                GridView2.CaptionAlign = TableCaptionAlign.Top;

                ExportDSbyEnrollment();
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
























        protected void btnSearchbyFollowups_Click(object sender, EventArgs e)
        {
            ShowDataDSbyFollowups();
            txtdssidbyFollowups.Focus();
        }



        private void ShowDataDSbyFollowups()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select b.study_code,b.followup_num,b.lw_crf4b_2 as 'Date_of_Followup',b.dssid,b.q10 as 'Woman_Name', b.q11 as 'Husband_Name',		concat(if(b.lw_crf4b_21a!=2,'Difficult in feeding, ',''), if(b.lw_crf4b_21b!=2,'Cough, ',''), if(b.lw_crf4b_21c!=2,'Cold/Flu/Runny nose, ','') , if(b.lw_crf4b_21d!=2,'Difficulty in breathing / Fast respiratory rate, ','') , if(b.lw_crf4b_21e!=2,'Convulsions, ','') , if(b.lw_crf4b_21f!=2,'Fever, ','') , if(b.lw_crf4b_21g!=2,'Hypothermia, ','') , if(b.lw_crf4b_21h!=2,'Lethargy or no movement, ','') , if(b.lw_crf4b_21i!=2,'Pustules, ','') , if(b.lw_crf4b_21j!=2,'Jaundice, ','') , if(b.lw_crf4b_21k!=2,'Umbilical redness or discharge, ','') , if(b.lw_crf4b_21l!=2,'Vomiting, ','') , if(b.lw_crf4b_21m!=2,'Diarrhea, ','') , if(b.lw_crf4b_21n!=2,'Oral Thrush, ','') , if(b.lw_crf4b_21o!=2,'Irritability or too much crying, ','') , if(b.lw_crf4b_21p!=2,'Redness of eyes or watery discharge, ','') , if(b.lw_crf4b_21q!=2,'Grunting, ','') , if(b.lw_crf4b_21r!=2,'Lips / tongue turning blue or black, ','') , if(b.lw_crf4b_21s!=2,'Peripheral cyanosis, ','') , if(b.lw_crf4b_21t!=2,'Bleeding from nose, ','') , if(b.lw_crf4b_21u!=2,'Constipation, ','') , if(b.lw_crf4b_21v!=2,'Dysentery, ','') , if(b.lw_crf4b_21w!=2,'Urine stopped, ','') , if(b.lw_crf4b_21x!=2,'Ear discharge or pus, ','') , if(b.lw_crf4b_21y!=2,'Chest congestion, ','') , if(b.lw_crf4b_21z=2,'', b.lw_crf4b_21z)) as 'q21',					(CASE WHEN b.lw_crf4b_22= '1' THEN 'Yes' WHEN b.lw_crf4b_22 = '2' THEN 'No' WHEN b.lw_crf4b_22 = '3' THEN 'Unnecessary' END) as q22,		concat(if(b.lw_crf4b_23a!=2,'Vital Pakistan / AKU Center, ',''), if(b.lw_crf4b_23b!=2,'Attiya Hospital, ',''), if(b.lw_crf4b_23c!=2,'Koohi Goth Hospital, ','') , if(b.lw_crf4b_23d!=2,'Jinnah, ','') , if(b.lw_crf4b_23e!=2,'Civil, ','') , if(b.lw_crf4b_23f!=2,'Korangi-5 govt. hospital, ','') , if(b.lw_crf4b_23h!=2,'Private Hospital, ','') , if(b.lw_crf4b_23i!=2,'Clinic, ','') , if(b.lw_crf4b_23j!=2,'Rural Health Center, ','') , if(b.lw_crf4b_23k!=2,'Dispensary, ','') , if(b.lw_crf4b_23l!=2,'Medical Store, ','') , if(b.lw_crf4b_23m!=2,'Self Medication, ',''),  if(b.lw_crf4b_23g=2,'', b.lw_crf4b_23g)) as 'q23', 			(CASE WHEN b.lw_crf4b_24= '1' THEN 'Yes' WHEN b.lw_crf4b_24 = '2' THEN 'No' WHEN b.lw_crf4b_24 = '9' THEN 'Don`t Know' END) as q24,		concat(if(b.lw_crf4b_25a!=2,'Kept in incubator, ',''), if(b.lw_crf4b_25b!=2,'Injectable antibiotics were administered, ',''), if(b.lw_crf4b_25c!=2,'Antibiotic Syrup was given, ','') , if(b.lw_crf4b_25d!=2,'Drip was administered, ','') , if(b.lw_crf4b_25e!=2,'Oxygen was given through bag,tube or mask, ','') , if(b.lw_crf4b_25f!=2,'Kept on a ventilator, ','') , if(b.lw_crf4b_25g!=2,'Baby was kept on NG feed, ','') , if(b.lw_crf4b_25h!=2,'Some other medicine-not powdered one, ','') , if(b.lw_crf4b_25i=2,'', b.lw_crf4b_25i)) as q25,			(CASE WHEN b.lw_crf4b_26= '1' THEN 'Yes' WHEN b.lw_crf4b_26 = '2' THEN 'No' END) as q26,  concat(if(b.lw_crf4b_27a!='', concat(b.lw_crf4b_27a, ', '),''),  if(b.lw_crf4b_27b!='', concat(b.lw_crf4b_27b, ', '),''),  if(b.lw_crf4b_27c!='', concat(b.lw_crf4b_27c,', '),''),  if(b.lw_crf4b_27d!='', concat(b.lw_crf4b_27d, ', '),''),  if(b.lw_crf4b_27e!='', concat(b.lw_crf4b_27e, ', '),''),  if(b.lw_crf4b_27f!='', concat(b.lw_crf4b_27f, ', '),'')) as 'q27'				  from (select study_code,max(followup_num) as followup_num  from view_crf4b where q19='1'  group by study_code) as a left join view_crf4b as b on b.study_code=a.study_code and b.followup_num=a.followup_num  where b.lw_crf4b_20='1' and b.dssid like '" + txtdssidbyFollowups.Text + "%' AND b.followup_num!='47'", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
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







        protected void btnExportbyFollowups_Click(object sender, EventArgs e)
        {
            ShowDataDSbyFollowups();
            if (GridView3.Rows.Count != 0)
            {
                ExcelExportDSbyFollowups();
            }
            txtdssidbyFollowups.Focus();
        }




        private void ExportDSbyFollowups()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select b.study_code,b.followup_num,b.lw_crf4b_2 as 'Date_of_Followup',b.dssid,b.q10 as 'Woman_Name', b.q11 as 'Husband_Name',		concat(if(b.lw_crf4b_21a!=2,'Difficult in feeding, ',''), if(b.lw_crf4b_21b!=2,'Cough, ',''), if(b.lw_crf4b_21c!=2,'Cold/Flu/Runny nose, ','') , if(b.lw_crf4b_21d!=2,'Difficulty in breathing / Fast respiratory rate, ','') , if(b.lw_crf4b_21e!=2,'Convulsions, ','') , if(b.lw_crf4b_21f!=2,'Fever, ','') , if(b.lw_crf4b_21g!=2,'Hypothermia, ','') , if(b.lw_crf4b_21h!=2,'Lethargy or no movement, ','') , if(b.lw_crf4b_21i!=2,'Pustules, ','') , if(b.lw_crf4b_21j!=2,'Jaundice, ','') , if(b.lw_crf4b_21k!=2,'Umbilical redness or discharge, ','') , if(b.lw_crf4b_21l!=2,'Vomiting, ','') , if(b.lw_crf4b_21m!=2,'Diarrhea, ','') , if(b.lw_crf4b_21n!=2,'Oral Thrush, ','') , if(b.lw_crf4b_21o!=2,'Irritability or too much crying, ','') , if(b.lw_crf4b_21p!=2,'Redness of eyes or watery discharge, ','') , if(b.lw_crf4b_21q!=2,'Grunting, ','') , if(b.lw_crf4b_21r!=2,'Lips / tongue turning blue or black, ','') , if(b.lw_crf4b_21s!=2,'Peripheral cyanosis, ','') , if(b.lw_crf4b_21t!=2,'Bleeding from nose, ','') , if(b.lw_crf4b_21u!=2,'Constipation, ','') , if(b.lw_crf4b_21v!=2,'Dysentery, ','') , if(b.lw_crf4b_21w!=2,'Urine stopped, ','') , if(b.lw_crf4b_21x!=2,'Ear discharge or pus, ','') , if(b.lw_crf4b_21y!=2,'Chest congestion, ','') , if(b.lw_crf4b_21z=2,'', b.lw_crf4b_21z)) as 'q21',					(CASE WHEN b.lw_crf4b_22= '1' THEN 'Yes' WHEN b.lw_crf4b_22 = '2' THEN 'No' WHEN b.lw_crf4b_22 = '3' THEN 'Unnecessary' END) as q22,		concat(if(b.lw_crf4b_23a!=2,'Vital Pakistan / AKU Center, ',''), if(b.lw_crf4b_23b!=2,'Attiya Hospital, ',''), if(b.lw_crf4b_23c!=2,'Koohi Goth Hospital, ','') , if(b.lw_crf4b_23d!=2,'Jinnah, ','') , if(b.lw_crf4b_23e!=2,'Civil, ','') , if(b.lw_crf4b_23f!=2,'Korangi-5 govt. hospital, ','') , if(b.lw_crf4b_23h!=2,'Private Hospital, ','') , if(b.lw_crf4b_23i!=2,'Clinic, ','') , if(b.lw_crf4b_23j!=2,'Rural Health Center, ','') , if(b.lw_crf4b_23k!=2,'Dispensary, ','') , if(b.lw_crf4b_23l!=2,'Medical Store, ','') , if(b.lw_crf4b_23m!=2,'Self Medication, ',''),  if(b.lw_crf4b_23g=2,'', b.lw_crf4b_23g)) as 'q23', 			(CASE WHEN b.lw_crf4b_24= '1' THEN 'Yes' WHEN b.lw_crf4b_24 = '2' THEN 'No' WHEN b.lw_crf4b_24 = '9' THEN 'Don`t Know' END) as q24,		concat(if(b.lw_crf4b_25a!=2,'Kept in incubator, ',''), if(b.lw_crf4b_25b!=2,'Injectable antibiotics were administered, ',''), if(b.lw_crf4b_25c!=2,'Antibiotic Syrup was given, ','') , if(b.lw_crf4b_25d!=2,'Drip was administered, ','') , if(b.lw_crf4b_25e!=2,'Oxygen was given through bag,tube or mask, ','') , if(b.lw_crf4b_25f!=2,'Kept on a ventilator, ','') , if(b.lw_crf4b_25g!=2,'Baby was kept on NG feed, ','') , if(b.lw_crf4b_25h!=2,'Some other medicine-not powdered one, ','') , if(b.lw_crf4b_25i=2,'', b.lw_crf4b_25i)) as q25,			(CASE WHEN b.lw_crf4b_26= '1' THEN 'Yes' WHEN b.lw_crf4b_26 = '2' THEN 'No' END) as q26,  concat(if(b.lw_crf4b_27a!='', concat(b.lw_crf4b_27a, ', '),''),  if(b.lw_crf4b_27b!='', concat(b.lw_crf4b_27b, ', '),''),  if(b.lw_crf4b_27c!='', concat(b.lw_crf4b_27c,', '),''),  if(b.lw_crf4b_27d!='', concat(b.lw_crf4b_27d, ', '),''),  if(b.lw_crf4b_27e!='', concat(b.lw_crf4b_27e, ', '),''),  if(b.lw_crf4b_27f!='', concat(b.lw_crf4b_27f, ', '),'')) as 'q27'				  from (select study_code,max(followup_num) as followup_num  from view_crf4b where q19='1'  group by study_code) as a left join view_crf4b as b on b.study_code=a.study_code and b.followup_num=a.followup_num  where b.lw_crf4b_20='1' and b.dssid like '" + txtdssidbyFollowups.Text + "%' AND b.followup_num!='47'", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView4.DataSource = dt;
                        GridView4.DataBind();
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




        public void ExcelExportDSbyFollowups()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=DSbyFollowups (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView4.AllowPaging = false;

                GridView4.CaptionAlign = TableCaptionAlign.Top;

                ExportDSbyFollowups();
                for (int i = 0; i < GridView4.HeaderRow.Cells.Count; i++)
                {
                    GridView4.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridView4.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView4.RenderControl(htmlWrite);
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