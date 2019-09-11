﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YETI
{
    public partial class MExports : System.Web.UI.Page
    {
        YETIEntities context = new YETIEntities();
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
            context.cqc_exports.Add(new cqc_exports
            {
                cs_nombre = txtExporter.Text
            });
            context.SaveChanges();
            limpiarTextBox();
            gvNombres.DataSource = context.cqc_exports.ToList();
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