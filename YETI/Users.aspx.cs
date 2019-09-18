using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace YETI
{
    public partial class Users : System.Web.UI.Page
    {
        YETIEntities context = new YETIEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var context = new YETIEntities())
                {
                    rgMails.DataSource = context.cqc_usuarios.ToList();
                    rgMails.DataBind();

                }
            }
        }

        protected void add_Click(object sender, EventArgs e)
        {
            context.cqc_usuarios.Add(new cqc_usuarios
            {
                cs_nombre = txtName.Text,
                cs_correo = txtMail.Text,
                cb_active = true,
                cb_masters = chkb_ms.Checked,
                cb_southBound = chkb_sb.Checked,
                cb_northBount = chkb_nb.Checked,
                cb_workOrder = chkb_wo.Checked,
                cb_ups = chkb_ups.Checked,
                cs_alta = DateTime.Now,
                cs_modificacion = DateTime.Now,
                cs_contrasena = "UABhAHMAcwB3ADAAcgBkACoA"
            }); 
            context.SaveChanges();
            context.cqf_logActividad.Add(new cqf_logActividad
            {
                fdt_fecha = DateTime.Now,
                fi_idUsuario = int.Parse(Session["UserID"].ToString()),
                fs_actividad = "Add User: " + txtName.Text
            });
            context.SaveChanges();
            limpiarTextBox();
            rgMails.DataSource = context.cqc_usuarios.ToList();
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
                if(c is CheckBox)
                {
                    CheckBox check = c as CheckBox;
                    check.Checked = false;
                }
            }

        }

        protected void btnDeactivate_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string[] commandArgs = btn.CommandArgument.ToString().Split(new char[] { '*' });
            int id = int.Parse(commandArgs[0]);
            cqc_usuarios m = context.cqc_usuarios.Where(d => d.ci_id == id).First();
            if (!m.cb_active)
                return;
            else
            {
                m.cb_active = false;
                context.SaveChanges();
                rgMails.DataSource = context.cqc_usuarios.ToList();
                rgMails.DataBind();
            }

            context.cqf_logActividad.Add(new cqf_logActividad
            {
                fdt_fecha = DateTime.Now,
                fi_idUsuario = int.Parse(Session["UserID"].ToString()),
                fs_actividad = "Update User: " + m.cs_nombre
            });
            context.SaveChanges();
        }

        protected void btnReactivate_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string[] commandArgs = btn.CommandArgument.ToString().Split(new char[] { '*' });
            int id = int.Parse(commandArgs[0]);
            cqc_usuarios m = context.cqc_usuarios.Where(d => d.ci_id == id).First();
            if (m.cb_active)
                return;
            else
            {
                m.cb_active = true;
                context.SaveChanges();
                rgMails.DataSource = context.cqc_usuarios.ToList();
                rgMails.DataBind();
            }
            context.cqf_logActividad.Add(new cqf_logActividad
            {
                fdt_fecha = DateTime.Now,
                fi_idUsuario = int.Parse(Session["UserID"].ToString()),
                fs_actividad = "Update User: " + m.cs_nombre
            });
            context.SaveChanges();
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