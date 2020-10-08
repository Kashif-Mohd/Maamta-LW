using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace maamta
{
    public partial class editChAnthro : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        static string form_crf_3c_id, form_crf_6_id;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "editChAnthro";
                CRF3cColor();
                txtdssidCRF3c.Focus();
            }
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }


        protected void btnCRF3c_Click(object sender, EventArgs e)
        {
            CRF3cColor();
            txtdssidCRF3c.Focus();
        }


        protected void btnCRF6_Click(object sender, EventArgs e)
        {
            CRF6Color();
            txtdssidCRF6.Focus();
        }


        public void CRF3cClearText()
        {
            txtCRF3cLengthR1.Text = "";
            txtCRF3cLengthR2.Text = "";
            txtCRF3cMUACR1.Text = "";
            txtCRF3cMUACR2.Text = "";
            txtCRF3cWeightR1.Text = "";
            txtCRF3cWeightR2.Text = "";
            txtCRF3cOFHCR1.Text = "";
            txtCRF3cOFHCR2.Text = "";
        }

        public void CRF6ClearText()
        {
            txtCRF6LengthR1.Text = "";
            txtCRF6LengthR2.Text = "";
            txtCRF6MUACR1.Text = "";
            txtCRF6MUACR2.Text = "";
            txtCRF6WeightR1.Text = "";
            txtCRF6WeightR2.Text = "";
            txtCRF6OFHCR1.Text = "";
            txtCRF6OFHCR2.Text = "";
        }




        private void CRF3cColor()
        {
            btnCRF3c.Style.Add("color", "white");
            btnCRF3c.Style.Add("background-color", "#55efc4");
            btnCRF6.Style.Add("color", "#adadad");
            btnCRF6.Style.Add("background-color", "#e0e0e0");

            divCRF3c.Visible = true;
            divShowCRF3c.Visible = true;
            divEntryCRF3c.Visible = false;
            form_crf_3c_id = null;
            divCRF6.Visible = false;
        }


        private void CRF6Color()
        {
            btnCRF6.Style.Add("color", "white");
            btnCRF6.Style.Add("background-color", "#55efc4");
            btnCRF3c.Style.Add("color", "#adadad");
            btnCRF3c.Style.Add("background-color", "#e0e0e0");

            divCRF6.Visible = true;
            divShowCRF6.Visible = true;
            divEntryCRF6.Visible = false;
            form_crf_6_id = null;
            divCRF3c.Visible = false;
        }




        protected void btnSearchCRF3c_Click(object sender, EventArgs e)
        {
            if (txtdssidCRF3c.Text.Length < 5)
            {
                showalert("Minimum 5 digit and char required!");
                txtdssidCRF3c.Focus();
            }
            else
            {
                ShowDataCRF3c();
                txtdssidCRF3c.Focus();
            }
        }


        private void ShowDataCRF3c()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select form_crf_3c_id,study_code, lw_crf3c_2 as DOV, q6 as woman_nm, q7 as husband_nm,dssid, lw_crf3c_15 as ch_weight, lw_crf3c_17 as ch_length, lw_crf3c_19 as ch_muac, lw_crf3c_21 as ch_ofhc  from view_crf3c where dssid  like '" + txtdssidCRF3c.Text.ToUpper() + "%'", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 9999999;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridViewCRF3c.DataSource = dt;
                        GridViewCRF3c.DataBind();
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



        protected void btnCRF3cWeight_Click(object sender, EventArgs e)
        {
            if (form_crf_3c_id == "" || form_crf_3c_id == null)
            {
                showalert("Something went wrong!");
                CRF3cColor();
                CRF3cClearText();
                txtdssidCRF3c.Focus();
            }
            else if (txtCRF3cWeightR1.Text == "" || txtCRF3cWeightR1.Text.Length < 4)
            {
                showalert("Enter Weight Reading 1");
                txtCRF3cWeightR1.Focus();
            }
            else if (txtCRF3cWeightR2.Text == "" || txtCRF3cWeightR2.Text.Length < 4)
            {
                showalert("Enter Weight Reading 2");
                txtCRF3cWeightR2.Focus();

            }
            else
            {
                MySqlConnection cn = new MySqlConnection(constr);
                cn.Open();
                try
                {
                    float Diff = float.Parse(txtCRF3cWeightR1.Text) - float.Parse(txtCRF3cWeightR2.Text);

                    float Avg = (float.Parse(txtCRF3cWeightR1.Text) + float.Parse(txtCRF3cWeightR2.Text)) / 2;
                    Avg = (float)Math.Round(Avg, 0);


                    //  Update in Main Table: 
                    MySqlCommand cmd = new MySqlCommand("update form_crf_3c set lw_crf3c_15='" + Avg + "' where  form_crf_3c_id='" + form_crf_3c_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    // Update in Second Table:
                    MySqlCommand cmd1 = new MySqlCommand("select max(child_weight_crf3c_id) as UID from child_weight_crf3c  where form_crf_3c_id='" + form_crf_3c_id + "'", cn);
                    cn.Open();
                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update child_weight_crf3c set difference='" + Diff + "', reader1='" + txtCRF3cWeightR1.Text + "',reader2='" + txtCRF3cWeightR2.Text + "' where  child_weight_crf3c_id='" + UID + "'", cn);
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                    }



                    // Update UserName in Audit Table:
                    cn.Open();
                    MySqlCommand cmd_audit = new MySqlCommand("SELECT MAX(id) as Audit_UID FROM audit_form_crf_3c", cn);
                    string Audit_UID = null;
                    MySqlDataReader dr_audit = cmd_audit.ExecuteReader();
                    if (dr_audit.Read() == true)
                    {
                        Audit_UID = dr_audit["Audit_UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_3c set update_status='Child-Weight (CRF3c)', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
                        Audit_UID2.ExecuteNonQuery();
                        cn.Close();
                    }



                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Weight Updated Successfully!');", true);
                    form_crf_3c_id = null;

                    CRF3cColor();
                    CRF3cClearText();
                    ShowDataCRF3c();
                    txtdssidCRF3c.Focus();
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

        }


        protected void btnCRF3cLength_Click(object sender, EventArgs e)
        {
            if (form_crf_3c_id == "" || form_crf_3c_id == null)
            {
                showalert("Something went wrong!");
                CRF3cColor();
                CRF3cClearText();
                txtdssidCRF3c.Focus();
            }
            else if (txtCRF3cLengthR1.Text == "" || txtCRF3cLengthR1.Text == "__._")
            {
                showalert("Enter Length Reading 1");
                txtCRF3cLengthR1.Focus();
            }
            else if (txtCRF3cLengthR2.Text == "" || txtCRF3cLengthR2.Text == "__._")
            {
                showalert("Enter Length Reading 2");
                txtCRF3cLengthR2.Focus();

            }
            else
            {
                MySqlConnection cn = new MySqlConnection(constr);
                cn.Open();
                try
                {
                    float Diff = float.Parse(txtCRF3cLengthR1.Text) - float.Parse(txtCRF3cLengthR2.Text);

                    float Avg = (float.Parse(txtCRF3cLengthR1.Text) + float.Parse(txtCRF3cLengthR2.Text)) / 2;
                    Avg = (float)Math.Round(Avg, 1);


                    //  Update in Main Table: 
                    MySqlCommand cmd = new MySqlCommand("update form_crf_3c set lw_crf3c_17='" + Avg + "' where  form_crf_3c_id='" + form_crf_3c_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    // Update in Second Table:
                    MySqlCommand cmd1 = new MySqlCommand("select max(baby_length_crf3c_id) as UID from baby_length_crf3c  where form_crf_3c_id='" + form_crf_3c_id + "'", cn);
                    cn.Open();
                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update baby_length_crf3c set difference='" + Diff + "', reader1='" + txtCRF3cLengthR1.Text + "',reader2='" + txtCRF3cLengthR2.Text + "' where  baby_length_crf3c_id='" + UID + "'", cn);
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                    }



                    // Update UserName in Audit Table:
                    cn.Open();
                    MySqlCommand cmd_audit = new MySqlCommand("SELECT MAX(id) as Audit_UID FROM audit_form_crf_3c", cn);
                    string Audit_UID = null;
                    MySqlDataReader dr_audit = cmd_audit.ExecuteReader();
                    if (dr_audit.Read() == true)
                    {
                        Audit_UID = dr_audit["Audit_UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_3c set update_status='Child-Length (CRF3c)', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
                        Audit_UID2.ExecuteNonQuery();
                        cn.Close();
                    }


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Length Updated Successfully!');", true);
                    form_crf_3c_id = null;

                    CRF3cColor();
                    CRF3cClearText();
                    ShowDataCRF3c();
                    txtdssidCRF3c.Focus();
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
        }


        protected void btnCRF3cOFHC_Click(object sender, EventArgs e)
        {
            if (form_crf_3c_id == "" || form_crf_3c_id == null)
            {
                showalert("Something went wrong!");
                CRF3cColor();
                CRF3cClearText();
                txtdssidCRF3c.Focus();
            }
            else if (txtCRF3cOFHCR1.Text == "" || txtCRF3cOFHCR1.Text == "__._")
            {
                showalert("Enter OFHC Reading 1");
                txtCRF3cOFHCR1.Focus();
            }
            else if (txtCRF3cOFHCR2.Text == "" || txtCRF3cOFHCR2.Text == "__._")
            {
                showalert("Enter OFHC Reading 2");
                txtCRF3cOFHCR2.Focus();

            }
            else
            {
                MySqlConnection cn = new MySqlConnection(constr);
                cn.Open();
                try
                {
                    float Diff = float.Parse(txtCRF3cOFHCR1.Text) - float.Parse(txtCRF3cOFHCR2.Text);

                    float Avg = (float.Parse(txtCRF3cOFHCR1.Text) + float.Parse(txtCRF3cOFHCR2.Text)) / 2;
                    Avg = (float)Math.Round(Avg, 1);


                    //  Update in Main Table: 
                    MySqlCommand cmd = new MySqlCommand("update form_crf_3c set lw_crf3c_21='" + Avg + "' where  form_crf_3c_id='" + form_crf_3c_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    // Update in Second Table:
                    MySqlCommand cmd1 = new MySqlCommand("select max(fhc_id) as UID from front_head_circumference_crf3c  where form_crf_3c_id='" + form_crf_3c_id + "'", cn);
                    cn.Open();
                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update front_head_circumference_crf3c set difference='" + Diff + "', reader1='" + txtCRF3cOFHCR1.Text + "',reader2='" + txtCRF3cOFHCR2.Text + "' where  fhc_id='" + UID + "'", cn);
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                    }



                    // Update UserName in Audit Table:
                    cn.Open();
                    MySqlCommand cmd_audit = new MySqlCommand("SELECT MAX(id) as Audit_UID FROM audit_form_crf_3c", cn);
                    string Audit_UID = null;
                    MySqlDataReader dr_audit = cmd_audit.ExecuteReader();
                    if (dr_audit.Read() == true)
                    {
                        Audit_UID = dr_audit["Audit_UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_3c set update_status='Child-OFHC (CRF3c)', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
                        Audit_UID2.ExecuteNonQuery();
                        cn.Close();
                    }


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('OFHC Updated Successfully!');", true);
                    form_crf_3c_id = null;

                    CRF3cColor();
                    CRF3cClearText();
                    ShowDataCRF3c();
                    txtdssidCRF3c.Focus();
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
        }





        protected void btnCRF3cMUAC_Click(object sender, EventArgs e)
        {
            if (form_crf_3c_id == "" || form_crf_3c_id == null)
            {
                showalert("Something went wrong!");
                CRF3cColor();
                CRF3cClearText();
                txtdssidCRF3c.Focus();
            }
            else if (txtCRF3cMUACR1.Text == "" || txtCRF3cMUACR1.Text == "__._")
            {
                showalert("Enter MUAC Reading 1");
                txtCRF3cMUACR1.Focus();
            }
            else if (txtCRF3cMUACR2.Text == "" || txtCRF3cMUACR2.Text == "__._")
            {
                showalert("Enter MUAC Reading 2");
                txtCRF3cMUACR2.Focus();
            }
            else
            {
                MySqlConnection cn = new MySqlConnection(constr);
                cn.Open();
                try
                {
                    float Diff = float.Parse(txtCRF3cMUACR1.Text) - float.Parse(txtCRF3cMUACR2.Text);

                    float Avg = (float.Parse(txtCRF3cMUACR1.Text) + float.Parse(txtCRF3cMUACR2.Text)) / 2;
                    Avg = (float)Math.Round(Avg, 1);


                    //  Update in Main Table: 
                    MySqlCommand cmd = new MySqlCommand("update form_crf_3c set lw_crf3c_19='" + Avg + "' where  form_crf_3c_id='" + form_crf_3c_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    // Update in Second Table:
                    MySqlCommand cmd1 = new MySqlCommand("select max(muac_baby_crf3c_id) as UID from muac_baby_crf3c  where form_crf_3c_id='" + form_crf_3c_id + "'", cn);
                    cn.Open();
                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update muac_baby_crf3c set difference='" + Diff + "', reader1='" + txtCRF3cMUACR1.Text + "',reader2='" + txtCRF3cMUACR2.Text + "' where  muac_baby_crf3c_id='" + UID + "'", cn);
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                    }




                    // Update UserName in Audit Table:
                    cn.Open();
                    MySqlCommand cmd_audit = new MySqlCommand("SELECT MAX(id) as Audit_UID FROM audit_form_crf_3c", cn);
                    string Audit_UID = null;
                    MySqlDataReader dr_audit = cmd_audit.ExecuteReader();
                    if (dr_audit.Read() == true)
                    {
                        Audit_UID = dr_audit["Audit_UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_3c set update_status='Child-MUAC (CRF3c)', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
                        Audit_UID2.ExecuteNonQuery();
                        cn.Close();
                    }


                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('MUAC Updated Successfully!');", true);
                    form_crf_3c_id = null;

                    CRF3cColor();
                    CRF3cClearText();
                    ShowDataCRF3c();
                    txtdssidCRF3c.Focus();
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
        }




















        protected void btnSearchCRF6_Click(object sender, EventArgs e)
        {
            if (txtdssidCRF6.Text.Length < 5)
            {
                showalert("Minimum 5 digit and char required!");
                txtdssidCRF6.Focus();
            }
            else
            {
                ShowDataCRF6();
                txtdssidCRF6.Focus();
            }
        }

        private void ShowDataCRF6()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select form_crf_6_id,study_code,followup_no,lw_crf6_2 as DOV, q9 as woman_nm, q10 as husband_nm,dssid, lw_crf6_20 as ch_weight,lw_crf6_22 as ch_length,lw_crf6_24 as ch_muac,lw_crf6_27 as ch_ofhc 	 from view_crf6 where dssid like '" + txtdssidCRF6.Text.ToUpper() + "%' order by study_code,followup_no", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 9999999;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridViewCRF6.DataSource = dt;
                        GridViewCRF6.DataBind();
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


        protected void btnCRF6Weight_Click(object sender, EventArgs e)
        {
            if (form_crf_6_id == "" || form_crf_6_id == null)
            {
                showalert("Something went wrong!");
                CRF6Color();
                CRF6ClearText();
                txtdssidCRF6.Focus();
            }
            else if (txtCRF6WeightR1.Text == "" || txtCRF6WeightR1.Text.Length < 4)
            {
                showalert("Enter Weight Reading 1");
                txtCRF6WeightR1.Focus();
            }
            else if (txtCRF6WeightR2.Text == "" || txtCRF6WeightR2.Text.Length < 4)
            {
                showalert("Enter Weight Reading 2");
                txtCRF6WeightR2.Focus();
            }
            else
            {
                MySqlConnection cn = new MySqlConnection(constr);
                cn.Open();
                try
                {
                    float Diff = float.Parse(txtCRF6WeightR1.Text) - float.Parse(txtCRF6WeightR2.Text);

                    float Avg = (float.Parse(txtCRF6WeightR1.Text) + float.Parse(txtCRF6WeightR2.Text)) / 2;
                    Avg = (float)Math.Round(Avg, 0);


                    //  Update in Main Table: 
                    MySqlCommand cmd = new MySqlCommand("update form_crf_6 set lw_crf6_20='" + Avg + "' where  form_crf_6_id='" + form_crf_6_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    // Update in Second Table:
                    MySqlCommand cmd1 = new MySqlCommand("select max(child_weight_crf6_id) as UID from child_weight_crf6  where form_crf_6_id='" + form_crf_6_id + "'", cn);
                    cn.Open();
                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update child_weight_crf6 set difference='" + Diff + "', reader1='" + txtCRF6WeightR1.Text + "',reader2='" + txtCRF6WeightR2.Text + "' where  child_weight_crf6_id='" + UID + "'", cn);
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                    }




                    // Update UserName in Audit Table:
                    cn.Open();
                    MySqlCommand cmd_audit = new MySqlCommand("SELECT MAX(id) as Audit_UID FROM audit_form_crf_6", cn);
                    string Audit_UID = null;
                    MySqlDataReader dr_audit = cmd_audit.ExecuteReader();
                    if (dr_audit.Read() == true)
                    {
                        Audit_UID = dr_audit["Audit_UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_6 set update_status='Child-Weight', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
                        Audit_UID2.ExecuteNonQuery();
                        cn.Close();
                    }



                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Weight Updated Successfully!');", true);
                    form_crf_6_id = null;

                    CRF6Color();
                    CRF6ClearText();
                    ShowDataCRF6();
                    txtdssidCRF6.Focus();
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

        }


        protected void btnCRF6Length_Click(object sender, EventArgs e)
        {
            if (form_crf_6_id == "" || form_crf_6_id == null)
            {
                showalert("Something went wrong!");
                CRF6Color();
                CRF6ClearText();
                txtdssidCRF6.Focus();
            }
            else if (txtCRF6LengthR1.Text == "" || txtCRF6LengthR1.Text == "__._")
            {
                showalert("Enter Length Reading 1");
                txtCRF6LengthR1.Focus();
            }
            else if (txtCRF6LengthR2.Text == "" || txtCRF6LengthR2.Text == "__._")
            {
                showalert("Enter Length Reading 2");
                txtCRF6LengthR2.Focus();

            }
            else
            {
                MySqlConnection cn = new MySqlConnection(constr);
                cn.Open();
                try
                {
                    float Diff = float.Parse(txtCRF6LengthR1.Text) - float.Parse(txtCRF6LengthR2.Text);

                    float Avg = (float.Parse(txtCRF6LengthR1.Text) + float.Parse(txtCRF6LengthR2.Text)) / 2;
                    Avg = (float)Math.Round(Avg, 1);


                    //  Update in Main Table: 
                    MySqlCommand cmd = new MySqlCommand("update form_crf_6 set lw_crf6_22='" + Avg + "' where  form_crf_6_id='" + form_crf_6_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    // Update in Second Table:
                    MySqlCommand cmd1 = new MySqlCommand("select max(baby_length_crf6_id) as UID from baby_length_crf6  where form_crf_6_id='" + form_crf_6_id + "'", cn);
                    cn.Open();
                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update baby_length_crf6 set difference='" + Diff + "', reader1='" + txtCRF6LengthR1.Text + "',reader2='" + txtCRF6LengthR2.Text + "' where  baby_length_crf6_id='" + UID + "'", cn);
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                    }



                    // Update UserName in Audit Table:
                    cn.Open();
                    MySqlCommand cmd_audit = new MySqlCommand("SELECT MAX(id) as Audit_UID FROM audit_form_crf_6", cn);
                    string Audit_UID = null;
                    MySqlDataReader dr_audit = cmd_audit.ExecuteReader();
                    if (dr_audit.Read() == true)
                    {
                        Audit_UID = dr_audit["Audit_UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_6 set update_status='Child-Length', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
                        Audit_UID2.ExecuteNonQuery();
                        cn.Close();
                    }




                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Length Updated Successfully!');", true);
                    form_crf_6_id = null;

                    CRF6Color();
                    CRF6ClearText();
                    ShowDataCRF6();
                    txtdssidCRF6.Focus();
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
        }


        protected void btnCRF6OFHC_Click(object sender, EventArgs e)
        {
            if (form_crf_6_id == "" || form_crf_6_id == null)
            {
                showalert("Something went wrong!");
                CRF6Color();
                CRF6ClearText();
                txtdssidCRF6.Focus();
            }
            else if (txtCRF6OFHCR1.Text == "" || txtCRF6OFHCR1.Text == "__._")
            {
                showalert("Enter OFHC Reading 1");
                txtCRF6OFHCR1.Focus();
            }
            else if (txtCRF6OFHCR2.Text == "" || txtCRF6OFHCR2.Text == "__._")
            {
                showalert("Enter OFHC Reading 2");
                txtCRF6OFHCR2.Focus();

            }
            else
            {
                MySqlConnection cn = new MySqlConnection(constr);
                cn.Open();
                try
                {
                    float Diff = float.Parse(txtCRF6OFHCR1.Text) - float.Parse(txtCRF6OFHCR2.Text);

                    float Avg = (float.Parse(txtCRF6OFHCR1.Text) + float.Parse(txtCRF6OFHCR2.Text)) / 2;
                    Avg = (float)Math.Round(Avg, 1);


                    //  Update in Main Table: 
                    MySqlCommand cmd = new MySqlCommand("update form_crf_6 set lw_crf6_27='" + Avg + "' where  form_crf_6_id='" + form_crf_6_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    // Update in Second Table:
                    MySqlCommand cmd1 = new MySqlCommand("select max(occipito_frontal_head_crf6_id) as UID from occipito_frontal_head_crf6  where form_crf_6_id='" + form_crf_6_id + "'", cn);
                    cn.Open();
                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update occipito_frontal_head_crf6 set difference='" + Diff + "', reader1='" + txtCRF6OFHCR1.Text + "',reader2='" + txtCRF6OFHCR2.Text + "' where  occipito_frontal_head_crf6_id='" + UID + "'", cn);
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                    }



                    // Update UserName in Audit Table:
                    cn.Open();
                    MySqlCommand cmd_audit = new MySqlCommand("SELECT MAX(id) as Audit_UID FROM audit_form_crf_6", cn);
                    string Audit_UID = null;
                    MySqlDataReader dr_audit = cmd_audit.ExecuteReader();
                    if (dr_audit.Read() == true)
                    {
                        Audit_UID = dr_audit["Audit_UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_6 set update_status='Child-FOHC', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
                        Audit_UID2.ExecuteNonQuery();
                        cn.Close();
                    }




                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('OFHC Updated Successfully!');", true);
                    form_crf_6_id = null;

                    CRF6Color();
                    CRF6ClearText();
                    ShowDataCRF6();
                    txtdssidCRF6.Focus();
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
        }


        protected void btnCRF6MUAC_Click(object sender, EventArgs e)
        {
            if (form_crf_6_id == "" || form_crf_6_id == null)
            {
                showalert("Something went wrong!");
                CRF6Color();
                CRF6ClearText();
                txtdssidCRF6.Focus();
            }
            else if (txtCRF6MUACR1.Text == "" || txtCRF6MUACR1.Text == "__._")
            {
                showalert("Enter MUAC Reading 1");
                txtCRF6MUACR1.Focus();
            }
            else if (txtCRF6MUACR2.Text == "" || txtCRF6MUACR2.Text == "__._")
            {
                showalert("Enter MUAC Reading 2");
                txtCRF6MUACR2.Focus();
            }
            else
            {
                MySqlConnection cn = new MySqlConnection(constr);
                cn.Open();
                try
                {
                    float Diff = float.Parse(txtCRF6MUACR1.Text) - float.Parse(txtCRF6MUACR2.Text);

                    float Avg = (float.Parse(txtCRF6MUACR1.Text) + float.Parse(txtCRF6MUACR2.Text)) / 2;
                    Avg = (float)Math.Round(Avg, 1);


                    //  Update in Main Table: 
                    MySqlCommand cmd = new MySqlCommand("update form_crf_6 set lw_crf6_24='" + Avg + "' where  form_crf_6_id='" + form_crf_6_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    // Update in Second Table:
                    MySqlCommand cmd1 = new MySqlCommand("select max(muac_baby_crf6_id) as UID from muac_baby_crf6  where form_crf_6_id='" + form_crf_6_id + "'", cn);
                    cn.Open();
                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update muac_baby_crf6 set difference='" + Diff + "', reader1='" + txtCRF6MUACR1.Text + "',reader2='" + txtCRF6MUACR2.Text + "' where  muac_baby_crf6_id='" + UID + "'", cn);
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                    }


                    // Update UserName in Audit Table:
                    cn.Open();
                    MySqlCommand cmd_audit = new MySqlCommand("SELECT MAX(id) as Audit_UID FROM audit_form_crf_6", cn);
                    string Audit_UID = null;
                    MySqlDataReader dr_audit = cmd_audit.ExecuteReader();
                    if (dr_audit.Read() == true)
                    {
                        Audit_UID = dr_audit["Audit_UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_6 set update_status='Child-MUAC', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
                        Audit_UID2.ExecuteNonQuery();
                        cn.Close();
                    }




                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('MUAC Updated Successfully!');", true);
                    form_crf_6_id = null;

                    CRF6Color();
                    CRF6ClearText();
                    ShowDataCRF6();
                    txtdssidCRF6.Focus();
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
        }



























        protected void Link_EditFormCRF3c(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Role"]) == "Web_Admin")
            {
                string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
                form_crf_3c_id = commandArgs[0];
                divShowCRF3c.Visible = false;
                divEntryCRF3c.Visible = true;
                txtCRF3cMUACR1.Focus();
            }
            else
            {
                showalert("Only Admin has rights to edit record!");
            }
        }




        protected void Link_EditFormCRF6(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Role"]) == "Web_Admin")
            {
                string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
                form_crf_6_id = commandArgs[0];
                divShowCRF6.Visible = false;
                divEntryCRF6.Visible = true;
                txtCRF6MUACR1.Focus();
            }
            else
            {
                showalert("Only Admin has rights to edit record!");
            }
        }



    }
}