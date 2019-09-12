using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YETI
{
    public partial class NorthBoundMails : System.Web.UI.Page
    {
        YETIEntities context = new YETIEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var context = new YETIEntities())
                {
                    gvNombres.DataSource = context.NorthBoundMails.ToList();
                    gvNombres.DataBind();

                }
            }
        }

        protected void add_Click(object sender, EventArgs e)
        {
            context.NorthBoundMails.Add(new NorthBoundMail
            {
               cs_nombre = txtName.Text,
               cs_correo = txtMail.Text,
               cb_active = true
            });
            context.SaveChanges();
            limpiarTextBox();
            gvNombres.DataSource = context.NorthBoundMails.ToList();
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

        protected void btnDeactivate_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string[] commandArgs = btn.CommandArgument.ToString().Split(new char[] { '*' });
            int id = int.Parse(commandArgs[0]);
            NorthBoundMail m = context.NorthBoundMails.Where(d => d.ci_id == id).First();
            if (!m.cb_active)
                return;
            else
            {
                m.cb_active = false;
                context.SaveChanges();
                gvNombres.DataSource = context.NorthBoundMails.ToList();
                gvNombres.DataBind();
            }
        }

        protected void btnReactivate_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string[] commandArgs = btn.CommandArgument.ToString().Split(new char[] { '*' });
            int id = int.Parse(commandArgs[0]);
            NorthBoundMail m = context.NorthBoundMails.Where(d => d.ci_id == id).First();
            if (m.cb_active)
                return;
            else
            {
                m.cb_active = true;
                context.SaveChanges();
                gvNombres.DataSource = context.NorthBoundMails.ToList();
                gvNombres.DataBind();
            }
        }

       
    }
}