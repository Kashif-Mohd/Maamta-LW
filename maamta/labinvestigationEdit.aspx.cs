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
    public partial class labinvestigationEdit : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;
        static string DOB;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "LABinvestigation";
                txtRandomid.Text = Request.QueryString["RandID"];
                DOB = null;
                FieldFill();
            }
        }





        protected void InfantBlood42_CheckedChanged(object sender, EventArgs e)
        {
            if (chk42InfantBlood.Checked == true)
            {
                txt42InfantBlood.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt42InfantBlood.Attributes.Add("readonly", "readonly");
                txt42InfantBlood.Enabled = true;
            }
            else
            {
                txt42InfantBlood.Text = "";
                txt42InfantBlood.Enabled = false;
            }
        }


        protected void InfantStool42_CheckedChanged(object sender, EventArgs e)
        {
            if (chk42InfantStool.Checked == true)
            {
                txt42InfantStool.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt42InfantStool.Attributes.Add("readonly", "readonly");
                txt42InfantStool.Enabled = true;
            }
            else
            {
                txt42InfantStool.Text = "";
                txt42InfantStool.Enabled = false;
            }
        }


        protected void BreastMilk42_CheckedChanged(object sender, EventArgs e)
        {
            if (chk42BreastMilk.Checked == true)
            {
                txt42BreastMilk.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt42BreastMilk.Attributes.Add("readonly", "readonly");
                txt42BreastMilk.Enabled = true;
            }
            else
            {
                txt42BreastMilk.Text = "";
                txt42BreastMilk.Enabled = false;
            }
        }


        protected void lwBlood42_CheckedChanged(object sender, EventArgs e)
        {
            if (chk42lwBlood.Checked == true)
            {
                txt42lwBlood.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt42lwBlood.Attributes.Add("readonly", "readonly");
                txt42lwBlood.Enabled = true;
            }
            else
            {
                txt42lwBlood.Text = "";
                txt42lwBlood.Enabled = false;
            }
        }


        protected void lwStool42_CheckedChanged(object sender, EventArgs e)
        {
            if (chk42lwStool.Checked == true)
            {
                txt42lwStool.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt42lwStool.Attributes.Add("readonly", "readonly");
                txt42lwStool.Enabled = true;
            }
            else
            {
                txt42lwStool.Text = "";
                txt42lwStool.Enabled = false;
            }
        }












        protected void InfantBlood56_CheckedChanged(object sender, EventArgs e)
        {
            if (chk56InfantBlood.Checked == true)
            {
                txt56InfantBlood.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt56InfantBlood.Attributes.Add("readonly", "readonly");
                txt56InfantBlood.Enabled = true;
            }
            else
            {
                txt56InfantBlood.Text = "";
                txt56InfantBlood.Enabled = false;
            }
        }


        protected void InfantStool56_CheckedChanged(object sender, EventArgs e)
        {
            if (chk56InfantStool.Checked == true)
            {
                txt56InfantStool.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt56InfantStool.Attributes.Add("readonly", "readonly");
                txt56InfantStool.Enabled = true;
            }
            else
            {
                txt56InfantStool.Text = "";
                txt56InfantStool.Enabled = false;
            }
        }


        protected void BreastMilk56_CheckedChanged(object sender, EventArgs e)
        {
            if (chk56BreastMilk.Checked == true)
            {
                txt56BreastMilk.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt56BreastMilk.Attributes.Add("readonly", "readonly");
                txt56BreastMilk.Enabled = true;
            }
            else
            {
                txt56BreastMilk.Text = "";
                txt56BreastMilk.Enabled = false;
            }
        }


        protected void lwBlood56_CheckedChanged(object sender, EventArgs e)
        {
            if (chk56lwBlood.Checked == true)
            {
                txt56lwBlood.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt56lwBlood.Attributes.Add("readonly", "readonly");
                txt56lwBlood.Enabled = true;
            }
            else
            {
                txt56lwBlood.Text = "";
                txt56lwBlood.Enabled = false;
            }
        }


        protected void lwStool56_CheckedChanged(object sender, EventArgs e)
        {
            if (chk56lwStool.Checked == true)
            {
                txt56lwStool.Text = DateTime.Now.ToString("dd-MM-yyyy");
                txt56lwStool.Attributes.Add("readonly", "readonly");
                txt56lwStool.Enabled = true;
            }
            else
            {
                txt56lwStool.Text = "";
                txt56lwStool.Enabled = false;
            }
        }





        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }




        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("labinvestigation.aspx");
        }








        protected void submit_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(constr);
            cn.Open();
            try
            {
                string currentdate = DateTime.Now.ToString("dd-MM-yyyy");

                //42 InfantBlood:
                if (chk42InfantBlood.Checked == true && (DateTime.ParseExact(txt42InfantBlood.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 42_InfantBlood Date should be Less than Current Date!");
                    txt42InfantBlood.Focus();
                }
                else if (chk42InfantBlood.Checked == true && DOB != null && (DateTime.ParseExact(txt42InfantBlood.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= (DateTime.ParseExact(DOB, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 42_InfantBlood Date should be greater than DOB: " + DOB + "");
                    txt42InfantBlood.Focus();
                }

                // 42 InfantStool
                else if (chk42InfantStool.Checked == true && (DateTime.ParseExact(txt42InfantStool.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 42_InfantStool Date should be Less than Current Date!");
                    txt42InfantStool.Focus();
                }
                else if (chk42InfantStool.Checked == true && DOB != null && (DateTime.ParseExact(txt42InfantStool.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= (DateTime.ParseExact(DOB, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 42_InfantStool Date should be greater than DOB: " + DOB + "");
                    txt42InfantStool.Focus();
                }

                // 42 BreastMilk
                else if (chk42BreastMilk.Checked == true && (DateTime.ParseExact(txt42BreastMilk.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 42_BreastMilk Date should be Less than Current Date!");
                    txt42BreastMilk.Focus();
                }
                else if (chk42BreastMilk.Checked == true && DOB != null && (DateTime.ParseExact(txt42BreastMilk.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= (DateTime.ParseExact(DOB, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 42_BreastMilk Date should be greater than DOB: " + DOB + "");
                    txt42BreastMilk.Focus();
                }

                // 42 lwBlood
                else if (chk42lwBlood.Checked == true && (DateTime.ParseExact(txt42lwBlood.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 42_LW_Blood Date should be Less than Current Date!");
                    txt42lwBlood.Focus();
                }
                else if (chk42lwBlood.Checked == true && DOB != null && (DateTime.ParseExact(txt42lwBlood.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= (DateTime.ParseExact(DOB, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 42_LW_Blood Date should be greater than DOB: " + DOB + "");
                    txt42lwBlood.Focus();
                }

                // 42 lwStool
                else if (chk42lwStool.Checked == true && (DateTime.ParseExact(txt42lwStool.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 42_LW_Stool Date should be Less than Current Date!");
                    txt42lwStool.Focus();
                }
                else if (chk42lwStool.Checked == true && DOB != null && (DateTime.ParseExact(txt42lwStool.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= (DateTime.ParseExact(DOB, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 42_LW_Stool Date should be greater than DOB: " + DOB + "");
                    txt42lwStool.Focus();
                }



                //56 InfantBlood:
                else if (chk56InfantBlood.Checked == true && (DateTime.ParseExact(txt56InfantBlood.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 56_InfantBlood Date should be Less than Current Date!");
                    txt56InfantBlood.Focus();
                }
                else if (chk56InfantBlood.Checked == true && DOB != null && (DateTime.ParseExact(txt56InfantBlood.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= (DateTime.ParseExact(DOB, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 56_InfantBlood Date should be greater than DOB: " + DOB + "");
                    txt56InfantBlood.Focus();
                }

                // 56 InfantStool
                else if (chk56InfantStool.Checked == true && (DateTime.ParseExact(txt56InfantStool.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 56_InfantStool Date should be Less than Current Date!");
                    txt56InfantStool.Focus();
                }
                else if (chk56InfantStool.Checked == true && DOB != null && (DateTime.ParseExact(txt56InfantStool.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= (DateTime.ParseExact(DOB, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 56_InfantStool Date should be greater than DOB: " + DOB + "");
                    txt56InfantStool.Focus();
                }

                // 56 BreastMilk
                else if (chk56BreastMilk.Checked == true && (DateTime.ParseExact(txt56BreastMilk.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 56_BreastMilk Date should be Less than Current Date!");
                    txt56BreastMilk.Focus();
                }
                else if (chk56BreastMilk.Checked == true && DOB != null && (DateTime.ParseExact(txt56BreastMilk.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= (DateTime.ParseExact(DOB, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 56_BreastMilk Date should be greater than DOB: " + DOB + "");
                    txt56BreastMilk.Focus();
                }

                // 56 lwBlood
                else if (chk56lwBlood.Checked == true && (DateTime.ParseExact(txt56lwBlood.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 56_LW_Blood Date should be Less than Current Date!");
                    txt56lwBlood.Focus();
                }
                else if (chk56lwBlood.Checked == true && DOB != null && (DateTime.ParseExact(txt56lwBlood.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= (DateTime.ParseExact(DOB, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 56_LW_Blood Date should be greater than DOB: " + DOB + "");
                    txt56lwBlood.Focus();
                }

                // 56 lwStool
                else if (chk56lwStool.Checked == true && (DateTime.ParseExact(txt56lwStool.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 56_LW_Stool Date should be Less than Current Date!");
                    txt56lwStool.Focus();
                }
                else if (chk56lwStool.Checked == true && DOB != null && (DateTime.ParseExact(txt56lwStool.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= (DateTime.ParseExact(DOB, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, 56_LW_Stool Date should be greater than DOB: " + DOB + "");
                    txt56lwStool.Focus();
                }


                else
                {
                    MySqlCommand cmd = new MySqlCommand("update lab_investigation set description='" + txtDescription.Text + "',  42_infant_blood='" + txt42InfantBlood.Text + "', 42_infant_stool='" + txt42InfantStool.Text + "', 42_breast_milk='" + txt42BreastMilk.Text + "', 42_lw_blood='" + txt42lwBlood.Text + "', 42_lw_stool='" + txt42lwStool.Text + "', 56_infant_blood='" + txt56InfantBlood.Text + "', 56_infant_stool='" + txt56InfantStool.Text + "', 56_breast_milk='" + txt56BreastMilk.Text + "', 56_lw_blood='" + txt56lwBlood.Text + "', 56_lw_stool='" + txt56lwStool.Text + "', entry_date='" + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") + "', enter_by='" + Convert.ToString(Session["MPusername"]) + "'  where  randomization_id='" + Request.QueryString["RandID"] + "'", cn);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Record Updated Successfully!');window.location.href='labinvestigation.aspx';", true);
                }
            }
            catch (Exception ex)
            {
                showalert(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }







        public void FieldFill()
        {
            MySqlConnection con = new MySqlConnection(constr);
            MySqlCommand cmd = new MySqlCommand("select * from view_lab_invest where lw_crf_3a_18='" + Request.QueryString["RandID"] + "'", con);
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {

                    DOB = dr["DOB"].ToString();

                    string[] DateOfBirth = DOB.Split(new char[] { '-' });
                    string Day = DateOfBirth[0];
                    string Month = DateOfBirth[1];
                    string Year = DateOfBirth[2];

                    if (Day.Length == 1) Day = "0" + Day;
                    if (Month.Length == 1) Month = "0" + Month;
                    DOB = Day + "-" + Month + "-" + Year;



                    txtDescription.Text = dr["description"].ToString();


                    txt42InfantBlood.Text = dr["42_infant_blood"].ToString();
                    txt42InfantStool.Text = dr["42_infant_stool"].ToString();
                    txt42BreastMilk.Text = dr["42_breast_milk"].ToString();
                    txt42lwBlood.Text = dr["42_lw_blood"].ToString();
                    txt42lwStool.Text = dr["42_lw_stool"].ToString();


                    txt56InfantBlood.Text = dr["56_infant_blood"].ToString();
                    txt56InfantStool.Text = dr["56_infant_stool"].ToString();
                    txt56BreastMilk.Text = dr["56_breast_milk"].ToString();
                    txt56lwBlood.Text = dr["56_lw_blood"].ToString();
                    txt56lwStool.Text = dr["56_lw_stool"].ToString();


                    //  Day 42

                    if (txt42InfantBlood.Text != "")
                    {
                        chk42InfantBlood.Checked = true;
                        txt42InfantBlood.Attributes.Add("readonly", "readonly");
                        txt42InfantBlood.Enabled = true;
                    }
                    if (txt42InfantStool.Text != "")
                    {
                        chk42InfantStool.Checked = true;
                        txt42InfantStool.Attributes.Add("readonly", "readonly");
                        txt42InfantStool.Enabled = true;
                    }
                    if (txt42BreastMilk.Text != "")
                    {
                        chk42BreastMilk.Checked = true;
                        txt42BreastMilk.Attributes.Add("readonly", "readonly");
                        txt42BreastMilk.Enabled = true;
                    }
                    if (txt42lwBlood.Text != "")
                    {
                        chk42lwBlood.Checked = true;
                        txt42lwBlood.Attributes.Add("readonly", "readonly");
                        txt42lwBlood.Enabled = true;
                    }
                    if (txt42lwStool.Text != "")
                    {
                        chk42lwStool.Checked = true;
                        txt42lwStool.Attributes.Add("readonly", "readonly");
                        txt42lwStool.Enabled = true;
                    }


                    //  Day 56

                    if (txt56InfantBlood.Text != "")
                    {
                        chk56InfantBlood.Checked = true;
                        txt56InfantBlood.Attributes.Add("readonly", "readonly");
                        txt56InfantBlood.Enabled = true;
                    }
                    if (txt56InfantStool.Text != "")
                    {
                        chk56InfantStool.Checked = true;
                        txt56InfantStool.Attributes.Add("readonly", "readonly");
                        txt56InfantStool.Enabled = true;
                    }
                    if (txt56BreastMilk.Text != "")
                    {
                        chk56BreastMilk.Checked = true;
                        txt56BreastMilk.Attributes.Add("readonly", "readonly");
                        txt56BreastMilk.Enabled = true;
                    }
                    if (txt56lwBlood.Text != "")
                    {
                        chk56lwBlood.Checked = true;
                        txt56lwBlood.Attributes.Add("readonly", "readonly");
                        txt56lwBlood.Enabled = true;
                    }
                    if (txt56lwStool.Text != "")
                    {
                        chk56lwStool.Checked = true;
                        txt56lwStool.Attributes.Add("readonly", "readonly");
                        txt56lwStool.Enabled = true;
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }


    }
}