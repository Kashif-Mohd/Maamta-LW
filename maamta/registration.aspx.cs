using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maamta
{
    public partial class registration : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "Registration";
                txtwomanNm.Focus();
            }

        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }

        protected void btnRegis_Click(object sender, EventArgs e)
        {
            //if (txthusbnNm.Text == "")
            //{
            //    showalert("Case-ID last digit between 1 to 3, eg. 123451");
            //    txthusbnNm.Focus();
            //}
        }
    }
}