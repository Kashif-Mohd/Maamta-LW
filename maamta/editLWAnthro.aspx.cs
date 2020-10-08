using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class editLWAnthro : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalMySql"].ConnectionString;

        static string form_crf_1_id, form_crf_2, Assisment_ID_CRF2, form_crf_3c_id, form_crf_6_id;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "editLWAnthro";
                CRF1Color();
                txtdssidCRF3c.Focus();
            }
        }



        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }






        protected void btnCRF1_Click(object sender, EventArgs e)
        {
            CRF1Color();
            txtdssidCRF1.Focus();
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




        public void CRF1ClearText()
        {
            txtCRF1MUACR1.Text = "";
            txtCRF1MUACR2.Text = "";
        }

        public void CRF3cClearText()
        {
            txtCRF3cHeightR1.Text = "";
            txtCRF3cHeightR2.Text = "";
            txtCRF3cMUACR1.Text = "";
            txtCRF3cMUACR2.Text = "";
            txtCRF3cWeightR1.Text = "";
            txtCRF3cWeightR2.Text = "";
        }

        public void CRF6ClearText()
        {
            txtCRF6MUACR1.Text = "";
            txtCRF6MUACR2.Text = "";
            txtCRF6WeightR1.Text = "";
            txtCRF6WeightR2.Text = "";
        }




        private void CRF1Color()
        {
            btnCRF1.Style.Add("color", "white");
            btnCRF1.Style.Add("background-color", "#55efc4");
            btnCRF3c.Style.Add("color", "#adadad");
            btnCRF3c.Style.Add("background-color", "#e0e0e0");
            btnCRF6.Style.Add("color", "#adadad");
            btnCRF6.Style.Add("background-color", "#e0e0e0");

            divCRF1.Visible = true;
            divShowCRF1.Visible = true;
            divEntryCRF1.Visible = false;
            form_crf_1_id = null;
            divCRF3c.Visible = false;
            divCRF6.Visible = false;
        }



        private void CRF3cColor()
        {
            btnCRF3c.Style.Add("color", "white");
            btnCRF3c.Style.Add("background-color", "#55efc4");
            btnCRF1.Style.Add("color", "#adadad");
            btnCRF1.Style.Add("background-color", "#e0e0e0");
            btnCRF6.Style.Add("color", "#adadad");
            btnCRF6.Style.Add("background-color", "#e0e0e0");

            divCRF3c.Visible = true;
            divShowCRF3c.Visible = true;
            divEntryCRF3c.Visible = false;
            form_crf_3c_id = null;
            divCRF1.Visible = false;
            divCRF6.Visible = false;
        }


        private void CRF6Color()
        {
            btnCRF6.Style.Add("color", "white");
            btnCRF6.Style.Add("background-color", "#55efc4");
            btnCRF1.Style.Add("color", "#adadad");
            btnCRF1.Style.Add("background-color", "#e0e0e0");
            btnCRF3c.Style.Add("color", "#adadad");
            btnCRF3c.Style.Add("background-color", "#e0e0e0");

            divCRF6.Visible = true;
            divShowCRF6.Visible = true;
            divEntryCRF6.Visible = false;
            form_crf_6_id = null;
            divCRF1.Visible = false;
            divCRF3c.Visible = false;
        }











        protected void btnSearchCRF1_Click(object sender, EventArgs e)
        {
            if (txtdssidCRF1.Text.Length < 5)
            {
                showalert("Minimum 5 digit and char required!");
                txtdssidCRF1.Focus();
            }
            else
            {
                ShowDataCRF1();
                txtdssidCRF1.Focus();
            }
        }


        private void ShowDataCRF1()
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select * from view_crf1 where V_Status='1' and dssid  like '" + txtdssidCRF1.Text.ToUpper() + "%'", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    cmd.CommandTimeout = 9999999;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridViewCRF1.DataSource = dt;
                        GridViewCRF1.DataBind();
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





        protected void btnCRF1MUAC_Click(object sender, EventArgs e)
        {
            if (form_crf_1_id == "" || form_crf_1_id == null)
            {
                showalert("Something went wrong!");
                CRF1Color();
                CRF1ClearText();
                txtdssidCRF1.Focus();
            }
            else if (txtCRF1MUACR1.Text == "" || txtCRF1MUACR1.Text == "__._")
            {
                showalert("Enter MUAC Reading 1");
                txtCRF1MUACR1.Focus();
            }
            else if (txtCRF1MUACR2.Text == "" || txtCRF1MUACR2.Text == "__._")
            {
                showalert("Enter MUAC Reading 2");
                txtCRF1MUACR2.Focus();
            }
            else
            {
                MySqlConnection cn = new MySqlConnection(constr);
                cn.Open();
                try
                {
                    float Diff = float.Parse(txtCRF1MUACR1.Text) - float.Parse(txtCRF1MUACR2.Text);

                    float Avg = (float.Parse(txtCRF1MUACR1.Text) + float.Parse(txtCRF1MUACR2.Text)) / 2;
                    Avg = (float)Math.Round(Avg, 1);


                    //  Update in Main Table: 
                    MySqlCommand cmd = new MySqlCommand("update form_crf_1 set lw_crf1_21='" + Avg + "' where  form_crf_1_id='" + form_crf_1_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    // Update in Second Table:
                    MySqlCommand cmd1 = new MySqlCommand("select max(id) as UID from muac_assessment  where form_crf_1_id='" + form_crf_1_id + "'", cn);
                    cn.Open();
                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update muac_assessment set difference='" + Diff + "', reading_1='" + txtCRF1MUACR1.Text + "', reading_2='" + txtCRF1MUACR2.Text + "' where id='" + UID + "'", cn);
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                    }

                    // Update UserName in Audit Table:
                    cn.Open();
                    MySqlCommand cmd_audit = new MySqlCommand("SELECT MAX(id) as Audit_UID FROM audit_form_crf_1", cn);
                    string Audit_UID = null;
                    MySqlDataReader dr_audit = cmd_audit.ExecuteReader();
                    if (dr_audit.Read() == true)
                    {
                        Audit_UID = dr_audit["Audit_UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_1 set update_status='LW-MUAC', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
                        Audit_UID2.ExecuteNonQuery();
                        cn.Close();
                    }



                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('MUAC Updated Successfully!');", true);
                    form_crf_1_id = null;

                    CRF1Color();
                    CRF1ClearText();
                    ShowDataCRF1();
                    txtdssidCRF1.Focus();
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
                cmd = new MySqlCommand("select * from view_crf3c where dssid  like '" + txtdssidCRF3c.Text.ToUpper() + "%'", con);
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

                try
                {
                    float Diff = float.Parse(txtCRF3cMUACR1.Text) - float.Parse(txtCRF3cMUACR2.Text);

                    float Avg = (float.Parse(txtCRF3cMUACR1.Text) + float.Parse(txtCRF3cMUACR2.Text)) / 2;
                    Avg = (float)Math.Round(Avg, 1);

                    // CRF3c:
                    //  Update in Main Table: 
                    cn.Open();
                    MySqlCommand cmd = new MySqlCommand("update form_crf_3c set lw_crf3c_27='" + Avg + "' where  form_crf_3c_id='" + form_crf_3c_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    // Update in Second Table:
                    cn.Open();
                    MySqlCommand cmd1 = new MySqlCommand("select max(muac_lw_crf3c_id) as UID from muac_lw_crf3c  where form_crf_3c_id='" + form_crf_3c_id + "'", cn);
                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update muac_lw_crf3c set difference='" + Diff + "', reader1='" + txtCRF3cMUACR1.Text + "',reader2='" + txtCRF3cMUACR2.Text + "' where  muac_lw_crf3c_id='" + UID + "'", cn);
                        cmd2.ExecuteNonQuery();
                        cn.Close();
                    }






                    // CRF2:
                    //  Update in Main Table: 
                    cn.Open();
                    MySqlCommand CRF2_form_id = new MySqlCommand("select * from view_crf2 where assis_id='" + Assisment_ID_CRF2 + "'", cn);
                    MySqlDataReader CRF2dr_form_2 = CRF2_form_id.ExecuteReader();
                    if (CRF2dr_form_2.Read() == true)
                    {
                        form_crf_2 = CRF2dr_form_2["form_crf_2"].ToString();
                    }
                    cn.Close();
                    cn.Open();
                    MySqlCommand CRF2cmd = new MySqlCommand("update form_crf_2 set lw_crf2_30='" + Avg + "' where  form_crf_2='" + form_crf_2 + "'", cn);
                    CRF2cmd.ExecuteNonQuery();
                    cn.Close();
                    // Update in Second Table:
                    cn.Open();
                    MySqlCommand CRF2cmd1 = new MySqlCommand("select max(arm_reading_id) as UID1 from arm_reading where form_crf_2_id='" + form_crf_2 + "'", cn);
                    string UID1 = null;
                    MySqlDataReader CRF2dr = CRF2cmd1.ExecuteReader();
                    if (CRF2dr.Read() == true)
                    {
                        UID1 = CRF2dr["UID1"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand CRF2cmd2 = new MySqlCommand("update arm_reading set difference='" + Diff + "', reader1='" + txtCRF3cMUACR1.Text + "',reader2='" + txtCRF3cMUACR2.Text + "' where  arm_reading_id='" + UID1 + "'", cn);
                        CRF2cmd2.ExecuteNonQuery();
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
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_3c set update_status='LW-MUAC (CRF2 and CRF3c)', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
                        Audit_UID2.ExecuteNonQuery();
                        cn.Close();
                    }





                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('MUAC Updated Successfully!');", true);
                    form_crf_2 = null;
                    Assisment_ID_CRF2 = null;
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
                    Avg = (float)Math.Round(Avg, 1);


                    //  Update in Main Table: 
                    MySqlCommand cmd = new MySqlCommand("update form_crf_3c set lw_crf3c_23='" + Avg + "' where  form_crf_3c_id='" + form_crf_3c_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    // Update in Second Table:
                    cn.Open();
                    MySqlCommand cmd1 = new MySqlCommand("select max(weight_lw_crf3c_id) as UID from weight_lw_crf3c where form_crf_3c_id='" + form_crf_3c_id + "'", cn);
                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update weight_lw_crf3c set difference='" + Diff + "', reader1='" + txtCRF3cWeightR1.Text + "',reader2='" + txtCRF3cWeightR2.Text + "' where  weight_lw_crf3c_id='" + UID + "'", cn);
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
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_3c set update_status='LW-Weight (CRF3c)', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
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


        protected void btnCRF3cHeight_Click(object sender, EventArgs e)
        {
            if (form_crf_3c_id == "" || form_crf_3c_id == null)
            {
                showalert("Something went wrong!");
                CRF3cColor();
                CRF3cClearText();
                txtdssidCRF3c.Focus();
            }
            else if (txtCRF3cHeightR1.Text == "" || txtCRF3cHeightR1.Text == "___._")
            {
                showalert("Enter Height Reading 1");
                txtCRF3cHeightR1.Focus();
            }
            else if (txtCRF3cHeightR2.Text == "" || txtCRF3cHeightR2.Text == "___._")
            {
                showalert("Enter Height Reading 2");
                txtCRF3cHeightR2.Focus();

            }
            else
            {
                MySqlConnection cn = new MySqlConnection(constr);
                cn.Open();
                try
                {
                    float Diff = float.Parse(txtCRF3cHeightR1.Text) - float.Parse(txtCRF3cHeightR2.Text);

                    float Avg = (float.Parse(txtCRF3cHeightR1.Text) + float.Parse(txtCRF3cHeightR2.Text)) / 2;
                    Avg = (float)Math.Round(Avg, 1);


                    //  Update in Main Table: 
                    MySqlCommand cmd = new MySqlCommand("update form_crf_3c set lw_crf3c_25='" + Avg + "' where  form_crf_3c_id='" + form_crf_3c_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    // Update in Second Table:
                    cn.Open();
                    MySqlCommand cmd1 = new MySqlCommand("select max(height_lw_crf3c_id) as UID from height_lw_crf3c where form_crf_3c_id='" + form_crf_3c_id + "'", cn);

                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();

                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update height_lw_crf3c set difference='" + Diff + "', reader1='" + txtCRF3cHeightR1.Text + "',reader2='" + txtCRF3cHeightR2.Text + "' where  height_lw_crf3c_id='" + UID + "'", cn);
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
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_3c set update_status='LW-Height (CRF3c)', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
                        Audit_UID2.ExecuteNonQuery();
                        cn.Close();
                    }




                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Height Updated Successfully!');", true);
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
                cmd = new MySqlCommand("select * from view_crf6 where dssid like '" + txtdssidCRF6.Text.ToUpper() + "%' order by study_code,followup_no", con);
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
                    MySqlCommand cmd = new MySqlCommand("update form_crf_6 set lw_crf6_34='" + Avg + "' where  form_crf_6_id='" + form_crf_6_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    // Update in Second Table:
                    cn.Open();
                    MySqlCommand cmd1 = new MySqlCommand("select max(muac_lw_crf6_id) as UID from muac_lw_crf6  where form_crf_6_id='" + form_crf_6_id + "'", cn);
                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update muac_lw_crf6 set difference='" + Diff + "', reader1='" + txtCRF6MUACR1.Text + "',reader2='" + txtCRF6MUACR2.Text + "' where  muac_lw_crf6_id='" + UID + "'", cn);
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
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_6 set update_status='LW-MUAC', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
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
                    Avg = (float)Math.Round(Avg, 1);


                    //  Update in Main Table: 
                    MySqlCommand cmd = new MySqlCommand("update form_crf_6 set lw_crf6_30='" + Avg + "' where  form_crf_6_id='" + form_crf_6_id + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    // Update in Second Table:
                    cn.Open();
                    MySqlCommand cmd1 = new MySqlCommand("select max(weight_lw_crf6_id) as UID from weight_lw_crf6  where form_crf_6_id='" + form_crf_6_id + "'", cn);
                    string UID = null;
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        UID = dr["UID"].ToString();
                        cn.Close();
                        cn.Open();
                        MySqlCommand cmd2 = new MySqlCommand("update weight_lw_crf6 set difference='" + Diff + "', reader1='" + txtCRF6WeightR1.Text + "',reader2='" + txtCRF6WeightR2.Text + "' where  weight_lw_crf6_id='" + UID + "'", cn);
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
                        MySqlCommand Audit_UID2 = new MySqlCommand("update audit_form_crf_6 set update_status='LW-Weight', user_name='" + Convert.ToString(Session["MPusername"]) + "' where  id='" + Audit_UID + "'", cn);
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









        protected void Link_EditFormCRF1(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Role"]) == "Web_Admin")
            {
                string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
                form_crf_1_id = commandArgs[0];
                divShowCRF1.Visible = false;
                divEntryCRF1.Visible = true;
                txtCRF1MUACR1.Focus();
            }
            else
            {
                showalert("Only Admin has rights to edit record!");
            }
        }




        protected void Link_EditFormCRF3c(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Role"]) == "Web_Admin")
            {
                string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
                form_crf_3c_id = commandArgs[0];
                Assisment_ID_CRF2 = commandArgs[1];
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