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
                cb_ups = chkUps.Checked,
                cb_balance=chkBalance.Checked,
                cb_scrap=chkScrap.Checked
                
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

                if (c is CheckBox)
                {
                    CheckBox text = c as CheckBox;
                    text.Checked = false;
                }
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            int commandArgs = int.Parse(btn.CommandArgument.ToString());

            var t = context.cqc_usuarios.Where(w => w.ci_id == commandArgs).First();
            txtMailE.Text = t.cs_correo;
            txtNameE.Text = t.cs_nombre;
            chk_ms.Checked = t.cb_masters;
            chk_nb.Checked = t.cb_northBount;
            chk_sb.Checked = t.cb_southBound;
            chkWork.Checked = t.cb_workOrder;
            chk_ups.Checked = t.cb_ups;
            chk_scrap.Checked = t.cb_scrap;
            chk_balance.Checked = t.cb_balance;
            btnUpdate.CommandArgument = t.ci_id.ToString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void update_Click(object sender, EventArgs e)
        {
            LinkButton lnk =(LinkButton) sender;
            int uid = int.Parse(lnk.CommandArgument.ToString());

            var u = context.cqc_usuarios.Where(w => w.ci_id == uid).First();

            u.cs_correo = txtMailE.Text;
            u.cs_nombre = txtNameE.Text;
            u.cs_modificacion = DateTime.Now;
            u.cb_masters = chk_ms.Checked;
            u.cb_northBount = chk_nb.Checked;
            u.cb_southBound = chk_sb.Checked;
            u.cb_workOrder = chk_wo.Checked;
            u.cb_ups = chk_ups.Checked;
            u.cb_balance = chk_balance.Checked;
            u.cb_scrap = chk_scrap.Checked;

            context.SaveChanges();

            context.cqf_logActividad.Add(new cqf_logActividad
            {
                fdt_fecha = DateTime.Now,
                fi_idUsuario = int.Parse(Session["UserID"].ToString()),
                fs_actividad = "Update User: " + txtNameE.Text
            });
            context.SaveChanges();
            limpiarTextBox();
            rgSKUs.DataSource = context.cqc_usuarios.ToList();
            rgSKUs.DataBind();
        }
    }
}