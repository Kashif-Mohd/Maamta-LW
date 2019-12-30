using MySql.Data.MySqlClient;
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
    public partial class outcomePending : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "OutcomePending";
                ShowData();
                txtdssid.Focus();
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
            txtdssid.Focus();
        }




        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (DropDownList1.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;

                    //Expected Date: 01-August-2018
                    cmd = new MySqlCommand("SELECT a.assis_id, a.dssid,a.block,	a.lw_crf1_29 as 'a/c to Ultrasound',			if (	(a.lw_crf1_31 !='' & a.lw_crf1_32 !=''), DATE_FORMAT((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7)) DAY),'%d-%b-%Y'), DATE_FORMAT((str_to_date(a.lw_crf1_27, '%d-%m-%Y')), '%d-%b-%Y')) as Expected_Date,	a.woman_nm,a.husband_nm,c.lw_crf1_33 as Contact_No  FROM view_crf1 as a inner join contact_number as c on a.form_crf_1_id=c.form_crf_1_id where  a.dssid like '%" + txtdssid.Text + "%' and a.lw_crf1_27!='' and 		if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !='') , ((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7))  DAY)	 <= (CURDATE() + INTERVAL 60 DAY)),  (str_to_date(a.lw_crf1_27, '%d-%m-%Y') <= (CURDATE() + INTERVAL 90 DAY)))				and	if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !='') , ((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7))  DAY)	 >= (str_to_date('01-08-2018', '%d-%m-%Y'))),  (str_to_date(a.lw_crf1_27, '%d-%m-%Y') >= (str_to_date('01-08-2018', '%d-%m-%Y'))))				 and not EXISTS (select * from view_crf2 as b where a.assis_id=b.assis_id) group by a.form_crf_1_id 		order by a.site,a.block;", con);

                    // According to EDD and (Ultrasound Date and Week)= Ul_Date + (280 - (ul_weeks * 7)):
                    //cmd = new MySqlCommand("SELECT a.assis_id, a.dssid,		if (	(a.lw_crf1_31 !='' & a.lw_crf1_32 !=''), DATE_FORMAT((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7)) DAY),'%d-%b-%Y'), DATE_FORMAT((str_to_date(a.lw_crf1_27, '%d-%m-%Y')), '%d-%b-%Y')) as Expected_Date,	a.woman_nm,a.husband_nm,c.lw_crf1_33 as Contact_No  FROM view_crf1 as a inner join contact_number as c on a.form_crf_1_id=c.form_crf_1_id where  a.dssid like '%" + txtdssid.Text + "%' and a.lw_crf1_27!='' and 		if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !='') , ((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7))  DAY)	 <= (CURDATE() + INTERVAL 30 DAY)),  (str_to_date(a.lw_crf1_27, '%d-%m-%Y') <= (CURDATE() + INTERVAL 60 DAY)))				 and not EXISTS (select * from view_crf2 as b where a.assis_id=b.assis_id) group by a.form_crf_1_id order by str_to_date(a.lw_crf1_27, '%d-%m-%Y');", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 999999;
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

                    //Expected Date: 01-August-2018
                    cmd = new MySqlCommand("SELECT a.assis_id, a.dssid,a.block,	a.lw_crf1_29 as 'a/c to Ultrasound',			if (	(a.lw_crf1_31 !='' & a.lw_crf1_32 !=''), DATE_FORMAT((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7)) DAY),'%d-%b-%Y'), DATE_FORMAT((str_to_date(a.lw_crf1_27, '%d-%m-%Y')), '%d-%b-%Y')) as Expected_Date,	a.woman_nm,a.husband_nm,c.lw_crf1_33 as Contact_No  FROM view_crf1 as a inner join contact_number as c on a.form_crf_1_id=c.form_crf_1_id where a.dssid like '" + DropDownList1.SelectedValue + "%' and a.dssid like '%" + txtdssid.Text + "%' and a.lw_crf1_27!='' and 		if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !='') , ((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7))  DAY)	 <= (CURDATE() + INTERVAL 60 DAY)),  (str_to_date(a.lw_crf1_27, '%d-%m-%Y') <= (CURDATE() + INTERVAL 90 DAY)))		    and	if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !='') , ((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7))  DAY)	 >= (str_to_date('01-08-2018', '%d-%m-%Y'))),  (str_to_date(a.lw_crf1_27, '%d-%m-%Y') >= (str_to_date('01-08-2018', '%d-%m-%Y'))))			 and not EXISTS (select * from view_crf2 as b where a.assis_id=b.assis_id) group by a.form_crf_1_id 	order by a.site,a.block;", con);

                    // According to EDD and (Ultrasound Date and Week)= Ul_Date + (280 - (ul_weeks * 7)):
                    //cmd = new MySqlCommand("SELECT a.assis_id, a.dssid,		if (	(a.lw_crf1_31 !='' & a.lw_crf1_32 !=''), DATE_FORMAT((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7)) DAY),'%d-%b-%Y'), DATE_FORMAT((str_to_date(a.lw_crf1_27, '%d-%m-%Y')), '%d-%b-%Y')) as Expected_Date,	a.woman_nm,a.husband_nm,c.lw_crf1_33 as Contact_No  FROM view_crf1 as a inner join contact_number as c on a.form_crf_1_id=c.form_crf_1_id where a.dssid like '" + DropDownList1.SelectedValue + "%' and a.dssid like '%" + txtdssid.Text + "%' and a.lw_crf1_27!='' and 		if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !='') , ((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7))  DAY)	 <= (CURDATE() + INTERVAL 30 DAY)),  (str_to_date(a.lw_crf1_27, '%d-%m-%Y') <= (CURDATE() + INTERVAL 60 DAY)))				 and not EXISTS (select * from view_crf2 as b where a.assis_id=b.assis_id) group by a.form_crf_1_id order by str_to_date(a.lw_crf1_27, '%d-%m-%Y');", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 999999;
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





        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }


        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                if (DropDownList1.SelectedValue == "0")
                {
                    con.Open();
                    MySqlCommand cmd;

                    //Expected Date: 01-August-2018
                    cmd = new MySqlCommand("SELECT a.assis_id, a.dssid,a.block,	a.lw_crf1_29 as 'a/c to Ultrasound',			if (	(a.lw_crf1_31 !='' & a.lw_crf1_32 !=''), DATE_FORMAT((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7)) DAY),'%d-%b-%Y'), DATE_FORMAT((str_to_date(a.lw_crf1_27, '%d-%m-%Y')), '%d-%b-%Y')) as Expected_Date,	a.woman_nm,a.husband_nm,c.lw_crf1_33 as Contact_No  FROM view_crf1 as a inner join contact_number as c on a.form_crf_1_id=c.form_crf_1_id where  a.dssid like '%" + txtdssid.Text + "%' and a.lw_crf1_27!='' and 		if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !='') , ((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7))  DAY)	 <= (CURDATE() + INTERVAL 60 DAY)),  (str_to_date(a.lw_crf1_27, '%d-%m-%Y') <= (CURDATE() + INTERVAL 90 DAY)))				and	if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !='') , ((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7))  DAY)	 >= (str_to_date('01-08-2018', '%d-%m-%Y'))),  (str_to_date(a.lw_crf1_27, '%d-%m-%Y') >= (str_to_date('01-08-2018', '%d-%m-%Y'))))				 and not EXISTS (select * from view_crf2 as b where a.assis_id=b.assis_id) group by a.form_crf_1_id 		order by a.site,a.block;", con);



                    // According to EDD and (Ultrasound Date and Week)= Ul_Date + (280 - (ul_weeks * 7)):
                    // cmd = new MySqlCommand("SELECT a.assis_id, a.dssid,a.site,a.para,a.block,		if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !=''), DATE_FORMAT((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7)) DAY),'%d-%b-%Y'), DATE_FORMAT((str_to_date(a.lw_crf1_27, '%d-%m-%Y')), '%d-%b-%Y')) as Expected_Date,	a.woman_nm,a.husband_nm,c.lw_crf1_33 as Contact_No  FROM view_crf1 as a inner join contact_number as c on a.form_crf_1_id=c.form_crf_1_id where  a.dssid like '%" + txtdssid.Text + "%' and a.lw_crf1_27!='' and 		if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !='') , ((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7))  DAY)	 <= (CURDATE() + INTERVAL 30 DAY)),  (str_to_date(a.lw_crf1_27, '%d-%m-%Y') <= (CURDATE() + INTERVAL 60 DAY)))				 and not EXISTS (select * from view_crf2 as b where a.assis_id=b.assis_id) group by a.form_crf_1_id order by str_to_date(a.lw_crf1_27, '%d-%m-%Y');", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 999999;
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

                    //Expected Date: 01-August-2018
                    cmd = new MySqlCommand("SELECT a.assis_id, a.dssid,a.block,	a.lw_crf1_29 as 'a/c to Ultrasound',			if (	(a.lw_crf1_31 !='' & a.lw_crf1_32 !=''), DATE_FORMAT((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7)) DAY),'%d-%b-%Y'), DATE_FORMAT((str_to_date(a.lw_crf1_27, '%d-%m-%Y')), '%d-%b-%Y')) as Expected_Date,	a.woman_nm,a.husband_nm,c.lw_crf1_33 as Contact_No  FROM view_crf1 as a inner join contact_number as c on a.form_crf_1_id=c.form_crf_1_id where a.dssid like '" + DropDownList1.SelectedValue + "%' and a.dssid like '%" + txtdssid.Text + "%' and a.lw_crf1_27!='' and 		if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !='') , ((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7))  DAY)	 <= (CURDATE() + INTERVAL 60 DAY)),  (str_to_date(a.lw_crf1_27, '%d-%m-%Y') <= (CURDATE() + INTERVAL 90 DAY)))		    and	if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !='') , ((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7))  DAY)	 >= (str_to_date('01-08-2018', '%d-%m-%Y'))),  (str_to_date(a.lw_crf1_27, '%d-%m-%Y') >= (str_to_date('01-08-2018', '%d-%m-%Y'))))			 and not EXISTS (select * from view_crf2 as b where a.assis_id=b.assis_id) group by a.form_crf_1_id 	order by a.site,a.block;", con);


                    // According to EDD and (Ultrasound Date and Week)= Ul_Date + (280 - (ul_weeks * 7)):
                    //cmd = new MySqlCommand("SELECT a.assis_id, a.dssid,a.site,a.para,a.block,		if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !=''), DATE_FORMAT((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7)) DAY),'%d-%b-%Y'), DATE_FORMAT((str_to_date(a.lw_crf1_27, '%d-%m-%Y')), '%d-%b-%Y')) as Expected_Date,	a.woman_nm,a.husband_nm,c.lw_crf1_33 as Contact_No  FROM view_crf1 as a inner join contact_number as c on a.form_crf_1_id=c.form_crf_1_id where a.dssid like '" + DropDownList1.SelectedValue + "%' and a.dssid like '%" + txtdssid.Text + "%' and a.lw_crf1_27!='' and 		if ((a.lw_crf1_31 !='' & a.lw_crf1_32 !='') , ((str_to_date(a.lw_crf1_31, '%d-%m-%Y') + INTERVAL (280 - (a.lw_crf1_32 * 7))  DAY)	 <= (CURDATE() + INTERVAL 30 DAY)),  (str_to_date(a.lw_crf1_27, '%d-%m-%Y') <= (CURDATE() + INTERVAL 60 DAY)))				 and not EXISTS (select * from view_crf2 as b where a.assis_id=b.assis_id) group by a.form_crf_1_id order by str_to_date(a.lw_crf1_27, '%d-%m-%Y');", con);

                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    {
                        cmd.Connection = con;
                        cmd.CommandTimeout = 999999;
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
                Response.AddHeader("content-disposition", "attachment;filename=Outcome Pending (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
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