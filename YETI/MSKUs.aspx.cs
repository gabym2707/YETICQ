using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YETI
{
    public partial class MSKUs : System.Web.UI.Page
    {
        YETIEntities context = new YETIEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            
                using (var context = new YETIEntities())
                {
                    rgSKUs.DataSource = context.cqc_skus.ToList();
                    rgSKUs.DataBind();
                    //ddlsexport.DataSource = context.cqc_exports.Where(c => c.ci_id >= 1).ToList();
                    //ddlsexport.DataBind();
                }
            
        }

        protected void add_Click(object sender, EventArgs e)
        {
            context.cqc_skus.Add(new cqc_skus
            {
                cs_sku = txtSKU.Text,
                cs_plant = txtPlant.Text,
                cs_description = txtDescription.Text,
                cs_comodityCode = txtCode.Text,
                cs_cost = decimal.Parse(txtCost.Text),
                cs_materialGroup = txtGroup.Text
            });
            context.SaveChanges();
            limpiarTextBox();
            rgSKUs.DataSource = context.cqc_imports.ToList();
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