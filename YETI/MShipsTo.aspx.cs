using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YETI
{
    public partial class MShipsTo : System.Web.UI.Page
    {
        YETIEntities context = new YETIEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var context = new YETIEntities())
                {
                    gvNombres.DataSource = context.cqc_shipto.ToList();
                    gvNombres.DataBind();                   
                }
            }
        }

        protected void add_Click(object sender, EventArgs e)
        {
            context.cqc_shipto.Add(new cqc_shipto
            {
                cs_nombre = txtShipTo.Text
            });
            context.SaveChanges();
            limpiarTextBox();
            gvNombres.DataSource = context.cqc_shipto.ToList();
            gvNombres.DataBind();
        }

        private void limpiarTextBox()
        {
            ContentPlaceHolder content = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");

            foreach (Control c in content.Controls)
            {
                if (c is TextBox)
                {
                    TextBox text = c as TextBox;
                    text.Text = "";
                }                
            }

        }
    }
}