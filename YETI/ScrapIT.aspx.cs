using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YETI
{
    public partial class ScrapIT : System.Web.UI.Page
    {
        YETIEntities context = new YETIEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkAgregar_Click(object sender, EventArgs e)
        {
            if (txtPedimento.Text != "" && txtQty.Text != "" && txtSky.Text != "" && certificado.HasFile && certificado.FileName.Contains("pdf"))
            {
                cqf_immexTransfer sp = new cqf_immexTransfer();
                sp.fi_qty = int.Parse(txtQty.Text);
                sp.fs_immexNombre = txtPedimento.Text;
                sp.fdt_fecha = DateTime.Now;
                sp.fs_sku = txtSky.Text;
                sp.fs_file = "Certificate" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf";

                context.cqf_immexTransfer.Add(sp);

                context.cqf_logActividad.Add(new cqf_logActividad
                {
                    fdt_fecha = DateTime.Now,
                    fi_idUsuario = int.Parse(Session["UserID"].ToString()),
                    fs_actividad = "Add Scrap Immex Transfer"
                }
                );
                certificado.SaveAs(Server.MapPath("~/Certificates/" + sp.fs_file));
                context.SaveChanges();
                //Limpiar
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

                //Abrir modal exito
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalSuccess();", true);
            }
            else
            {
                //Open Modal Error
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModalError();", true);
            }
        }
    }
}