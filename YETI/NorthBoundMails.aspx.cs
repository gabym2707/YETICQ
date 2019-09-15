using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

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
                    rgMails.DataSource = context.NorthBoundMails.ToList();
                    rgMails.DataBind();

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
            rgMails.DataSource = context.NorthBoundMails.ToList();
            rgMails.DataBind();
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
                rgMails.DataSource = context.NorthBoundMails.ToList();
                rgMails.DataBind();
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
                rgMails.DataSource = context.NorthBoundMails.ToList();
                rgMails.DataBind();
            }
        }

        protected void rgMails_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                bool stat = bool.Parse(item["cb_active"].Text);
                //int scart = int.Parse(item["fi_statusCarta"].Text);
                TableCell deact = item["Deactivate"];
                TableCell react = item["Reactivate"];

                if (stat)
                {
                    deact.Visible = true;
                    react.Visible = false;
                }
                else
                {
                    deact.Visible = false;
                    react.Visible = true;
                }
                
            }
        }
    }
}