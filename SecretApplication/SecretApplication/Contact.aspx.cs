using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecretApplication
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnsubmitMessagePost_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}