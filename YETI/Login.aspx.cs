using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YETI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session.Remove("UserID");
            }
        }

        protected void lnkInicio_Click(object sender, EventArgs e)
        {
            string pass = Seguridad.Encriptar(inputPassword.Value);
            using (var context = new YETIEntities())
            {
                int users = context.cqc_usuarios.Where(w => w.cb_active == true && w.cs_correo==inputEmail.Value && w.cs_contrasena==pass).Count();

                if (users > 0)
                {
                    
                    Session["UserID"] = context.cqc_usuarios.Where(w => w.cb_active == true && w.cs_correo == inputEmail.Value && w.cs_contrasena == pass).Select(c => c.ci_id).First().ToString();

                    cqf_logActividad log = new cqf_logActividad();
                    log.fdt_fecha = DateTime.Now;
                    log.fi_idUsuario = int.Parse(Session["UserID"].ToString());
                    log.fs_actividad = "Sign In ";

                    context.cqf_logActividad.Add(log);
                    context.SaveChanges();


                    Response.Redirect("Inicio.aspx");
                }
                
                else
                {
                    //Usuario o Contraseña equivocados
                }
                
            }
        }
    }
}