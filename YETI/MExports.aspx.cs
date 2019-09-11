using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YETI
{
    public partial class MExports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var context = new YETIEntities())
                {
                    gvNombres.DataSource = context.cqc_exports.ToList();
                    gvNombres.DataBind();
                    //ddlsexport.DataSource = context.cqc_exports.Where(c => c.ci_id >= 1).ToList();
                    //ddlsexport.DataBind();
                }
            }
        }

        protected void add_Click(object sender, EventArgs e)
        {

        }
    }
}