using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YETI
{
    public partial class Yeti : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int usuario;
            if(!IsPostBack)
            {
                try
                {
                    usuario = int.Parse(Session["UserID"].ToString());
                    using (var context = new YETIEntities())
                    {
                        var user = context.cqc_usuarios.Where(c => c.ci_id == usuario).First();

                        if (!user.cb_southBound)
                        {
                            sb.Visible = false;
                        }
                        if (!user.cb_northBount)
                        {
                            nb.Visible = false;
                        }
                        if (!user.cb_masters)
                        {
                            ms.Visible = false;
                        }
                        if (!user.cb_workOrder)
                        {
                            work.Visible = false;
                        }
                        if (!user.cb_scrap)
                        {
                            scraping.Visible = false;
                        }
                        if (!user.cb_balance)
                        {
                            balance.Visible = false;
                        }
                    }
                }
                catch { Response.Redirect("Login.aspx"); }
           }
        }
    }
}