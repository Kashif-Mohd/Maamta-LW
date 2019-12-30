using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;


namespace maamta
{
    public partial class dashboard : System.Web.UI.Page
    {
        MySqlDataReader dreader;
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UentryUname"] == null)
                {
                    txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
                }
                else
                {
                    txtCalndrDate.Text = Convert.ToString(Session["FirstEDate"]);
                    txtCalndrDate1.Text = Convert.ToString(Session["SecEDate"]);
                }
                Session["dssid"] = null;
                Session["UentryUname"] = null;
                Session["FirstEDate"] = null;
                Session["SecEDate"] = null;
                Session["showcrf1Hide"] = null;

                Session["WebForm"] = "Dashboard";
                lbeUname.Text = Convert.ToString(Session["MPusername"]);
                txtCalndrDate.Attributes.Add("readonly", "readonly");
                txtCalndrDate1.Attributes.Add("readonly", "readonly");
                ShowData();
                //ShowTotal();

                ShowEligible();
                ShowNotEligible();
                ShowDuplicate();
            }
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (DateTime.ParseExact(txtCalndrDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtCalndrDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
            {
                showalert("First Date should be Less or Equal than Second Date");
                txtCalndrDate.Focus();
            }
            else
            {
                ShowData();
                //ShowTotal();
                ShowDuplicate();
                ShowEligible();
                ShowNotEligible();
            }
        }


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                //if (CheckBox1.Checked == false)
                //{
                con.Open();
                //MySqlCommand cmd = new MySqlCommand("select count(a.form_crf_1_id) as total,b.name, d.site, e.title, (select count(*) from form_crf_1 as z where z.form_status=1 and z.team_id=a.team_id and (z.lw_crf1_02 between '" + txtCalndrDate.Text + "' and '" + txtCalndrDate1.Text + "')) as Complete, (select count(*) from form_crf_1 as z where z.form_status!=1 and z.team_id=a.team_id and (z.lw_crf1_02 between '" + txtCalndrDate.Text + "' and '" + txtCalndrDate1.Text + "')) as Incomplete from form_crf_1 as a  join emp as b on a.team_id=b.team_id join team as c on a.team_id=c.team_id join site as d on c.site_id=d.site_id join team_title as e on c.team_title_id=e.team_title_id where (a.lw_crf1_02 between '" + txtCalndrDate.Text + "' and '" + txtCalndrDate1.Text + "') group by a.team_id order by total desc", con);
                MySqlCommand cmd = new MySqlCommand("select count(a.form_crf_1_id) as total,b.name, d.site, e.title, (select count(*) from form_crf_1 as z where z.visit_status=0 and z.team_id=a.team_id and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as Complete, (select count(*) from form_crf_1 as z where z.visit_status!=0 and z.team_id=a.team_id and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as Incomplete from form_crf_1 as a  join emp as b on a.team_id=b.team_id join team as c on a.team_id=c.team_id join site as d on c.site_id=d.site_id join team_title as e on c.team_title_id=e.team_title_id where (str_to_date(a.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) group by a.team_id order by total desc", con);

                {
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
                //}
                //else
                //{
                //    MySqlCommand cmd = new MySqlCommand("select count(a.form_crf_1_id) as total,b.name, d.site, e.title, (select count(*) from form_crf_1 as z where z.form_status=1 and z.team_id=a.team_id ) as Complete, (select count(*) from form_crf_1 as z where z.form_status!=1 and z.team_id=a.team_id ) as Incomplete from form_crf_1 as a  join emp as b on a.team_id=b.team_id join team as c on a.team_id=c.team_id join site as d on c.site_id=d.site_id join team_title as e on c.team_title_id=e.team_title_id  group by a.team_id order by total desc", con);
                //    {
                //        MySqlDataAdapter sda = new MySqlDataAdapter();
                //        {
                //            cmd.Connection = con;
                //            sda.SelectCommand = cmd;
                //            DataTable dt = new DataTable();
                //            {
                //                sda.Fill(dt);
                //                GridView1.DataSource = dt;
                //                GridView1.DataBind();
                //                con.Close();
                //            }
                //        }
                //    }
                //}
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


        private void ShowEligible()
        {
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select count(*) as total from form_crf_1 where lw_crf1_21!='' and lw_crf1_21<24  and (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))", con);
                {
                    dreader = cmd.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbeElg.Text = dreader["total"].ToString();
                    }
                    con.Close();
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



        private void ShowNotEligible()
        {
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select count(*) as total from form_crf_1 where lw_crf1_21!='' and lw_crf1_21>=24  and (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))", con);
                {
                    dreader = cmd.ExecuteReader();

                    if (dreader.Read())
                    {
                        lbeNotElg.Text = dreader["total"].ToString();
                    }
                    con.Close();
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







        private void ShowDuplicate()
        {
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT count(*) AS duplicate FROM (SELECT count(*)as total,dssid, woman_nm, husband_nm from view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) group by dssid having count(dssid)>1 order by dssid) AS t", con);
                {
                    dreader = cmd.ExecuteReader();
                    if (dreader.Read())
                    {
                        linkDuplicate.Text = dreader["duplicate"].ToString();
                    }
                    con.Close();
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




        //protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    txtCalndrDate.Enabled = !CheckBox1.Checked;
        //    btnCalndrDate.Enabled = !CheckBox1.Checked;
        //}




        protected void btnExport_Click(object sender, EventArgs e)
        {
            ShowData();
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
        }



        public void ExcelExportMessage()
        {
            //GridView2.Caption = "MAAMTA LW trial    <br/>(Pregnant Women (PW) Screened)";
            GridView2.Caption = "<h2/>MAAMTA LW trial<br/>   <h4/>Pregnant Women (PW) Screened <br/>Date from '" + txtCalndrDate.Text + "' To '" + txtCalndrDate1.Text + "'";
            GridView3.Caption = "<br/><br/>    <h4/>Pregnant Women (PW) Screened <br/>CUMULATIVE REPORT";
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
                //Date Wise
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select b.site as Site,count(*) as 'Total Pregnant Women Approached',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='1' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Number of Pregnant Women Screened',(select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21<24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'MUAC less than 24.0 cm',(select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21>=24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'MUAC equal or greater than 24.0 cm',                        concat(((select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21<24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))/(SELECT count(*) FROM view_crf1 as z  where z.V_Status='1' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))) * 100,'%') as 'Percentage of MUAC less than 24.0 cm among Screened Pregnant Women',                                                                     (SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))    GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '2%' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women currently not available at home',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))    GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '3%' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))as 'Pregnant women currently refused',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status in ('4','5','6','7') and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Mentioned as pregnant in MWRS but either wrong DSS, or wrong info on pregnany or delivered', 										(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))    GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='8' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women shifted out of DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))    GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='9' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women died before screening',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))    GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='10' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women was a visitor' from view_crf1 as  b INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS bbc  ON  bbc.assis_id  = b.assis_id AND str_to_date(b.lw_crf1_02, '%d-%m-%Y') = bbc.TopDate  and   (str_to_date(b.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  group by b.site  union all           select 'Total',count(*) as 'Total Pregnant Women Approached',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='1' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Number of Pregnant Women Screened',(select count(*) from view_crf1  as z  where z.lw_crf1_21<24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'MUAC less than 24.0 cm',(select count(*) from view_crf1  as z  where z.lw_crf1_21>=24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'MUAC equal or greater than 24.0 cm',                        concat(((select count(*) from view_crf1  as z  where z.lw_crf1_21<24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))/(SELECT count(*) FROM view_crf1 as z  where z.V_Status='1' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))) * 100,'%') as 'Percentage of MUAC less than 24.0 cm among Screened Pregnant Women',                                                                     (SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '2%' and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women currently not available at home',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))    GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '3%' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))as 'Pregnant women currently refused',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))    GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status in ('4','5','6','7') and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Mentioned as pregnant in MWRS but either wrong DSS, or wrong info on pregnany or delivered ',										(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))    GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='8' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women shifted out of DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='9' and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women died before screening',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='10' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women was a visitor' from view_crf1 as  b INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS bbc  ON  bbc.assis_id  = b.assis_id AND str_to_date(b.lw_crf1_02, '%d-%m-%Y') = bbc.TopDate  and   (str_to_date(b.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))", con);



                // Last one before 04-Jan-2018                
                //MySqlCommand cmd = new MySqlCommand("select b.site as Site,count(*) as 'Total Pregnant Women Approached',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='1' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Number of Pregnant Women Screened',(select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21<24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'MUAC less than 24.0 cm',(select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21>=24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'MUAC equal or greater than 24.0 cm',                        concat(((select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21<24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))/(SELECT count(*) FROM view_crf1 as z  where z.V_Status='1' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))) * 100,'%') as 'Percentage of MUAC less than 24.0 cm among Screened Pregnant Women',                                                                     (SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '2%' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women currently not available at home',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '3%' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))as 'Pregnant women currently refused',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status in ('4','5','6','7') and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Mentioned as pregnant in MWRS but either wrong DSS, or wrong info on pregnany or delivered', 										(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='8' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women shifted out of DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='9' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women died before screening',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='10' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women was a visitor' from view_crf1 as  b INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  GROUP BY assis_id) AS bbc  ON  bbc.assis_id  = b.assis_id AND str_to_date(b.lw_crf1_02, '%d-%m-%Y') = bbc.TopDate  and   (str_to_date(b.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  group by b.site  union all select 'Total',count(*) as 'Total Pregnant Women Approached',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='1' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Number of Pregnant Women Screened',(select count(*) from view_crf1  as z  where z.lw_crf1_21<24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'MUAC less than 24.0 cm',(select count(*) from view_crf1  as z  where z.lw_crf1_21>=24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'MUAC equal or greater than 24.0 cm',                        concat(((select count(*) from view_crf1  as z  where z.lw_crf1_21<24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))/(SELECT count(*) FROM view_crf1 as z  where z.V_Status='1' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))) * 100,'%') as 'Percentage of MUAC less than 24.0 cm among Screened Pregnant Women',                                                                     (SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '2%' and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women currently not available at home',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '3%' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))as 'Pregnant women currently refused',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status in ('4','5','6','7') and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Mentioned as pregnant in MWRS but either wrong DSS, or wrong info on pregnany or delivered ',										(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='8' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women shifted out of DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='9' and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women died before screening',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='10' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women was a visitor' from view_crf1 as  b INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  GROUP BY assis_id) AS bbc  ON  bbc.assis_id  = b.assis_id AND str_to_date(b.lw_crf1_02, '%d-%m-%Y') = bbc.TopDate  and   (str_to_date(b.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))", con);

                // Last one before 10-Oct-2018
                //MySqlCommand cmd = new MySqlCommand("select b.site as Site,count(*) as 'Total Pregnant Women Approached',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='1' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Number of Pregnant Women Screened',(select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21<24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'MUAC less than 24.0 cm',(select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21>=24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'MUAC equal or greater than 24.0 cm',                        concat(((select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21<24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))/(SELECT count(*) FROM view_crf1 as z  where z.V_Status='1' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))) * 100,'%') as 'Percentage of MUAC less than 24.0 cm among Screened Pregnant Women',                                                                     (SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '2%' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women currently not available at home',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '3%' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))as 'Pregnant women currently refused',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='4' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Wrong information related to pregnancy or currently non pregnant',			(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='5' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Wrong information related to DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='6' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Women was never found pregnant',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='7' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Women was pregnant but recently delivered', 										(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='8' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women shifted out of DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='9' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women died before screening',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='10' and b.site=z.site  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women was a visitor' from view_crf1 as  b INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  GROUP BY assis_id) AS bbc  ON  bbc.assis_id  = b.assis_id AND str_to_date(b.lw_crf1_02, '%d-%m-%Y') = bbc.TopDate  and   (str_to_date(b.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  group by b.site union all select 'Total',count(*) as 'Total Pregnant Women Approached',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='1' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Number of Pregnant Women Screened',(select count(*) from view_crf1  as z  where z.lw_crf1_21<24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'MUAC less than 24.0 cm',(select count(*) from view_crf1  as z  where z.lw_crf1_21>=24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'MUAC equal or greater than 24.0 cm',                        concat(((select count(*) from view_crf1  as z  where z.lw_crf1_21<24  and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))/(SELECT count(*) FROM view_crf1 as z  where z.V_Status='1' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))) * 100,'%') as 'Percentage of MUAC less than 24.0 cm among Screened Pregnant Women',                                                                     (SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '2%' and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women currently not available at home',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '3%' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')))as 'Pregnant women currently refused',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='4' and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Wrong information related to pregnancy or currently non pregnant',			(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='5' and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Wrong information related to DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='6' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Women was never found pregnant',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='7' and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Women was pregnant but recently delivered', 										(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='8' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women shifted out of DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='9' and   (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women died before screening',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='10' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))) as 'Pregnant women was a visitor' from view_crf1 as  b INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  GROUP BY assis_id) AS bbc  ON  bbc.assis_id  = b.assis_id AND str_to_date(b.lw_crf1_02, '%d-%m-%Y') = bbc.TopDate  and   (str_to_date(b.lw_crf1_02, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView2.DataSource = dt;
                        GridView2.DataBind();
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



        private void ExportdataWithOutDate()
        {
            //Cumulative
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select b.site as Site,count(*) as 'Total Pregnant Women Approached',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='1' and b.site=z.site and (str_to_date(b.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Number of Pregnant Women Screened',(select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21<24 and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'MUAC less than 24.0 cm',(select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21>=24 and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'MUAC equal or greater than 24.0 cm',                        concat(((select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21<24 and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) )/(SELECT count(*) FROM view_crf1 as z  where z.V_Status='1' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) )) * 100,'%') as 'Percentage of MUAC less than 24.0 cm among Screened Pregnant Women',                                                                     (SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '2%' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women currently not available at home',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '3%' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) )as 'Pregnant women currently refused',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status in ('4','5','6','7') and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Mentioned as pregnant in MWRS but either wrong DSS, or wrong info on pregnany or delivered '				,(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='8' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women shifted out of DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='9' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women died before screening',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='10' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women was a visitor' from view_crf1 as  b INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) GROUP BY assis_id) AS bbc  ON  bbc.assis_id  = b.assis_id AND str_to_date(b.lw_crf1_02, '%d-%m-%Y') = bbc.TopDate where (str_to_date(b.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))    group by b.site  union all select 'Total',count(*) as 'Total Pregnant Women Approached',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='1' and (str_to_date(b.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Number of Pregnant Women Screened',(select count(*) from view_crf1  as z  where z.lw_crf1_21<24  and (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'MUAC less than 24.0 cm',(select count(*) from view_crf1  as z  where z.lw_crf1_21>=24 and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'MUAC equal or greater than 24.0 cm',                        concat(((select count(*) from view_crf1  as z  where z.lw_crf1_21<24  and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) )/(SELECT count(*) FROM view_crf1 as z  where z.V_Status='1'  and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) )) * 100,'%') as 'Percentage of MUAC less than 24.0 cm among Screened Pregnant Women',                                                                     (SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where  (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '2%'  and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women currently not available at home',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where  (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '3%'  and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) )as 'Pregnant women currently refused',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where  (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status in ('4','5','6','7') and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Mentioned as pregnant in MWRS but either wrong DSS, or wrong info on pregnany or delivered'				 ,(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='8' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women shifted out of DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='9'  and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women died before screening',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='10' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women was a visitor' from view_crf1 as  b INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS bbc  ON  bbc.assis_id  = b.assis_id AND str_to_date(b.lw_crf1_02, '%d-%m-%Y') = bbc.TopDate  where (str_to_date(b.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))", con);

                // Last one before 10-Oct-2018             
                //   MySqlCommand cmd = new MySqlCommand("select b.site as Site,count(*) as 'Total Pregnant Women Approached',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='1' and b.site=z.site and (str_to_date(b.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Number of Pregnant Women Screened',(select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21<24 and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'MUAC less than 24.0 cm',(select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21>=24 and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'MUAC equal or greater than 24.0 cm',                        concat(((select count(*) from view_crf1  as z  where z.site=b.site and z.lw_crf1_21<24 and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) )/(SELECT count(*) FROM view_crf1 as z  where z.V_Status='1' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) )) * 100,'%') as 'Percentage of MUAC less than 24.0 cm among Screened Pregnant Women',                                                                     (SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '2%' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women currently not available at home',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '3%' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) )as 'Pregnant women currently refused',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='4' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Wrong information related to pregnancy or currently non pregnant'			,(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='5' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Wrong information related to DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='6' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Women was never found pregnant',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='7' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Women was pregnant but recently delivered'		,(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='8' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women shifted out of DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='9' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women died before screening',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='10' and b.site=z.site and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women was a visitor' from view_crf1 as  b INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) GROUP BY assis_id) AS bbc  ON  bbc.assis_id  = b.assis_id AND str_to_date(b.lw_crf1_02, '%d-%m-%Y') = bbc.TopDate where (str_to_date(b.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))    group by b.site  union all select 'Total',count(*) as 'Total Pregnant Women Approached',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='1' and (str_to_date(b.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Number of Pregnant Women Screened',(select count(*) from view_crf1  as z  where z.lw_crf1_21<24  and (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'MUAC less than 24.0 cm',(select count(*) from view_crf1  as z  where z.lw_crf1_21>=24 and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'MUAC equal or greater than 24.0 cm',                        concat(((select count(*) from view_crf1  as z  where z.lw_crf1_21<24  and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) )/(SELECT count(*) FROM view_crf1 as z  where z.V_Status='1'  and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) )) * 100,'%') as 'Percentage of MUAC less than 24.0 cm among Screened Pregnant Women',                                                                     (SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where  (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '2%'  and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women currently not available at home',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where  (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status like '3%'  and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) )as 'Pregnant women currently refused',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where  (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='4' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Wrong information related to pregnancy or currently non pregnant'			,(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where  (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='5' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Wrong information related to DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1 where  (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='6'  and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Women was never found pregnant',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='7'  and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Women was pregnant but recently delivered'		 ,(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='8' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women shifted out of DSS',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='9'  and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women died before screening',(SELECT count(*) FROM view_crf1 as z INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))   GROUP BY assis_id) AS b  ON  z.assis_id = b.assis_id AND str_to_date(z.lw_crf1_02, '%d-%m-%Y') = b.TopDate where z.V_Status='10' and (str_to_date(z.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) ) as 'Pregnant women was a visitor' from view_crf1 as  b INNER JOIN (SELECT assis_id, MAX(str_to_date(lw_crf1_02, '%d-%m-%Y')) as TopDate FROM view_crf1  where (str_to_date(lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))  GROUP BY assis_id) AS bbc  ON  bbc.assis_id  = b.assis_id AND str_to_date(b.lw_crf1_02, '%d-%m-%Y') = bbc.TopDate  where (str_to_date(b.lw_crf1_02, '%d-%m-%Y') <= str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y'))", con);             
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 999999;
                    cmd.CommandType = CommandType.Text;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
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
                Response.AddHeader("content-disposition", "attachment;filename=Screening Report (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";

                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2.AllowPaging = false;
                GridView3.AllowPaging = false;
                ExcelExportMessage();
                GridView2.CaptionAlign = TableCaptionAlign.Top;
                GridView3.CaptionAlign = TableCaptionAlign.Top;
                Exportdata();
                ExportdataWithOutDate();

                for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
                {
                    GridView2.HeaderRow.Cells[i].Style.Add("font-size", "16px");
                    GridView2.HeaderRow.Cells[i].Style.Add("height", "80px");
                    //GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#00B894");
                    GridView2.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                // Footer Style: 
                GridView2.Rows[GridView2.Rows.Count - 1].Style.Add("font-size", "15px");
                GridView2.Rows[GridView2.Rows.Count - 1].Font.Bold = true;

                for (int i = 0; i < GridView3.HeaderRow.Cells.Count; i++)
                {
                    GridView3.HeaderRow.Cells[i].Style.Add("font-size", "16px");
                    GridView3.HeaderRow.Cells[i].Style.Add("height", "80px");
                    GridView3.HeaderRow.Cells[i].Style.Add("background-color", "#00B894");
                    GridView3.HeaderRow.Cells[i].Style.Add("Color", "white");

                }
                // Footer Style: 

                GridView3.Rows[GridView3.Rows.Count - 1].Style.Add("font-size", "15px");
                GridView3.Rows[GridView3.Rows.Count - 1].Font.Bold = true;

                GridView2.RenderControl(htmlWrite);
                GridView3.RenderControl(htmlWrite);

                Response.Write(stringWrite.ToString());
                Response.End();

            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");

            }
        }




        


        protected void Link_Duplicate(object sender, EventArgs e)
        {
            if (((LinkButton)sender).Text != "0")
            {
                Session["showcrf1Hide"] = "showcrf1Hide";
                Session["FirstEDate"] = txtCalndrDate.Text;
                Session["SecEDate"] = txtCalndrDate1.Text;
                Response.Redirect("showcrf1.aspx");
            }
        }



        protected void Link_Button1(object sender, EventArgs e)
        {
            string UentryNme = ((LinkButton)sender).CommandArgument;
            Session["UentryUname"] = UentryNme;
            Session["FirstEDate"] = txtCalndrDate.Text;
            Session["SecEDate"] = txtCalndrDate1.Text;
            Response.Redirect("scrUserdetail.aspx");
        }


        Int32 totCom = 0;
        Int32 totInCom = 0;
        
        
        protected void OnRowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totCom = totCom + Convert.ToInt32(e.Row.Cells[3].Text);
                lbeComplete.Text = totCom.ToString();

                totInCom = totInCom + Convert.ToInt32(e.Row.Cells[4].Text);
                lbeIncomplete.Text = totInCom.ToString();

                int totalAll = totCom + totInCom;
                lbeTotal.Text = totalAll.ToString();

                ////TAB USER:
                //TableCell cell2 = e.Row.Cells[2];
                //cell2.BackColor = System.Drawing.Color.FromName("#fff5bf");


                TableCell cell0 = e.Row.Cells[3];
                TableCell cell1 = e.Row.Cells[4];
                cell0.BackColor = System.Drawing.Color.FromName("#cef5cb");
                cell1.BackColor = System.Drawing.Color.FromName("#fff0f0");




                //if Text is 0 then will be chnage into GRAY

                if (e.Row.Cells[3].Text == "0")
                {
                    TableCell cell = e.Row.Cells[3];
                    cell.ForeColor = System.Drawing.Color.FromName("#8395a7");
                }
                if (e.Row.Cells[4].Text == "0")
                {
                    TableCell cell = e.Row.Cells[4];
                    cell.ForeColor = System.Drawing.Color.FromName("#8395a7");
                }
                if (e.Row.Cells[5].Text == "0")
                {
                    TableCell cell = e.Row.Cells[5];
                    cell.ForeColor = System.Drawing.Color.FromName("#8395a7");
                }
            }


        }
    }
}