using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICUPro.Portal
{
    public partial class MyEMR_New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Page.Request.QueryString["guid"] != null)
                {
                    this.hidPatientGUID.Value = Page.Request.QueryString["guid"];
                }
                if (Page.Request.QueryString["type"] != null)
                {
                    this.hidType.Value = Page.Request.QueryString["type"];
                }
            }
        }
    }
}