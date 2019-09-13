using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YETI
{
    public partial class MImporters : System.Web.UI.Page
    {
        YETIEntities context = new YETIEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            
                using (var context = new YETIEntities())
                {
                    rgNombres.DataSource = context.cqc_imports.ToList();
                    rgNombres.DataBind();
                }
            
        }

        protected void add_Click(object sender, EventArgs e)
        {
            context.cqc_imports.Add(new cqc_imports
            {
                cs_nombre = txtImporter.Text,
                cs_address = txtAddress.Text,
                cs_locacion = txtLocation.Text,
                cs_rfc = txtRFC.Text,
                immex = txtImmex.Text
            });
            context.SaveChanges();
            limpiarTextBox();
            rgNombres.DataSource = context.cqc_imports.ToList();
            rgNombres.DataBind();
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