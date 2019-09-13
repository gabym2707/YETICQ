using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YETI
{
    public partial class MUsers : System.Web.UI.Page
    {
        YETIEntities context = new YETIEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new YETIEntities())
            {
                rgSKUs.DataSource = context.cqc_usuarios.ToList();
                rgSKUs.DataBind();
            }
        }

        protected void add_Click(object sender, EventArgs e)
        {
            context.cqc_usuarios.Add(new cqc_usuarios
            {
                cs_nombre = txtName.Text,
                cs_correo = txtMail.Text,
                cs_alta = DateTime.Now,
                cs_modificacion = DateTime.Now,
                cb_southBound = chkSouth.Checked,
                cb_northBount = chkNorth.Checked,
                cb_masters = chkMasters.Checked,
                cb_workOrder = chkWork.Checked,
                cb_ups = chkUps.Checked
                
            });
            context.SaveChanges();
            limpiarTextBox();
            rgSKUs.DataSource = context.cqc_usuarios.ToList();
            rgSKUs.DataBind();
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