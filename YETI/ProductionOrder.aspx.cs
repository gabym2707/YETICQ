using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YETI
{
    public partial class WorkOrderImport : System.Web.UI.Page
    {
        YETIEntities context = new YETIEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                using (var context = new YETIEntities())
                {
                    ddlsexport.DataSource = context.cqc_exports.Where(c=> c.ci_id >=1).ToList();
                    ddlsexport.DataBind();
                    ddlsimport.DataSource = context.cqc_imports.ToList();
                    ddlsimport.DataBind();
                    ddlsShippers.DataSource = context.cqc_shippers.ToList();
                    ddlsShippers.DataBind();
                    ddlsShipTo.DataSource = context.cqc_shipto.ToList();
                    ddlsShipTo.DataBind();
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //string filePath = "";
            if (ImportSB.HasFile && ImportSB.FileName.Contains(".xls"))
            {
                //UploadedFile file = layoutUpload.UploadedFiles[0];
                if (File.Exists(Server.MapPath("~/Southbound/" + txtPO.Text+".xls")))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
                else
                {
                    ImportSB.SaveAs(Server.MapPath("~/Southbound/" + txtPO.Text + ".xls"));
                    context.cqf_logActividad.Add(new cqf_logActividad {
                        fdt_fecha = DateTime.Now,
                        fi_idUsuario = int.Parse(Session["UserID"].ToString()),
                        fs_actividad = "Upload Production Order File" });
                    context.SaveChanges();
                } 
                
            }

            List<SouthBound> SBs = new List<SouthBound>();
            using (var stream = File.Open(Server.MapPath("~/Southbound/" + txtPO.Text + ".xls"), FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
                {

                    while (reader.Read())
                    {
                        if (reader.Depth >= 1)
                        {
                            //reader.NextResult();

                            try
                            {
                                string[] date = txtDate.Text.Split('-');
                                string[] ShipDate = txtShipDate.Text.Split('-');
                                SouthBound s = new SouthBound();
                                s.fc_status = "A";
                                s.fs_invoice = txtInvoice.Text;
                                s.fs_trucker = txtTrucker.Text;
                                s.fd_date = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));
                                s.fs_tracking = txtTracking.Text;
                                s.fs_productionOrder = txtPO.Text;
                                s.fs_reference = txtReference.Text;
                                s.fi_exportRecords = int.Parse(ddlsexport.SelectedItem.Value);
                                s.fs_exportRecords = ddlsexport.SelectedItem.Text;
                                s.fi_importRecords = int.Parse(ddlsimport.SelectedItem.Value);
                                s.fs_importRecords = ddlsimport.SelectedItem.Text;
                                s.fi_shipper = int.Parse(ddlsShippers.SelectedItem.Value);
                                s.fs_shipper = ddlsShippers.SelectedItem.Text;
                                s.fi_shipTo = int.Parse(ddlsShipTo.SelectedItem.Value);
                                s.fs_shipTo = ddlsShipTo.SelectedItem.Text;
                                s.fs_moneda = ddlsCurrency.SelectedItem.Text;
                                s.fs_incoterms = ddlsIncoterms.SelectedItem.Text;
                                s.fd_shipDate =  new DateTime(int.Parse(ShipDate[0]), int.Parse(ShipDate[1]), int.Parse(ShipDate[2]));
                                s.fs_partNumber = reader.GetString(1);
                                s.fs_description = reader.GetString(1);
                                s.fs_scheduleHsCode = reader.GetString(2);
                                s.fs_coo = reader.GetString(3);
                                s.fi_qty = int.Parse(reader.GetDouble(4).ToString());
                                s.fd_totalWeightLbs = reader.GetDouble(5);
                                s.fd_totalWeightKgs = reader.GetDouble(6);
                                s.fd_unitPrice = decimal.Parse(reader.GetDouble(7).ToString());
                                s.fd_exitPrice = decimal.Parse(reader.GetDouble(8).ToString());
                                if (s.fs_partNumber == null)
                                {
                                    reader.NextResult();
                                }
                                else
                                {
                                    SBs.Add(s);
                                    
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.Write(ex.Message);
                            }
                        }
                    }

                    rgProductionOrder.DataSource = SBs.ToList();
                    rgProductionOrder.DataBind();
                }
            }


        }

        protected void lnkInsertar_Click(object sender, EventArgs e)
        {
            
            List<SouthBound> SBs = new List<SouthBound>();
            using (var stream = File.Open(Server.MapPath("~/Southbound/"+txtPO.Text+".xls"), FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
                {

                    while (reader.Read())
                    {
                        if (reader.Depth >= 1)
                        {
                            //reader.NextResult();

                            try
                            {
                                string[] date = txtDate.Text.Split('-');
                                string[] ShipDate = txtShipDate.Text.Split('-');
                                SouthBound s = new SouthBound();
                                s.fc_status = "A";
                                s.fs_invoice = txtInvoice.Text;
                                s.fs_trucker = txtTrucker.Text;
                                s.fd_date = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));
                                s.fs_tracking = txtTracking.Text;
                                s.fs_productionOrder = txtPO.Text;
                                s.fs_reference = txtReference.Text;
                                s.fi_exportRecords = int.Parse(ddlsexport.SelectedItem.Value);
                                s.fs_exportRecords = ddlsexport.SelectedItem.Text;
                                s.fi_importRecords = int.Parse(ddlsimport.SelectedItem.Value);
                                s.fs_importRecords = ddlsimport.SelectedItem.Text;
                                s.fi_shipper = int.Parse(ddlsShippers.SelectedItem.Value);
                                s.fs_shipper = ddlsShippers.SelectedItem.Text;
                                s.fi_shipTo = int.Parse(ddlsShipTo.SelectedItem.Value);
                                s.fs_shipTo = ddlsShipTo.SelectedItem.Text;
                                s.fs_moneda = ddlsCurrency.SelectedItem.Text;
                                s.fs_incoterms = ddlsIncoterms.SelectedItem.Text;
                                s.fd_shipDate = new DateTime(int.Parse(ShipDate[0]), int.Parse(ShipDate[1]), int.Parse(ShipDate[2]));
                                try { s.fs_partNumber = reader.GetString(0); } catch { s.fs_partNumber = reader.GetDouble(0).ToString(); }
                                s.fs_description = reader.GetString(1);
                                s.fs_scheduleHsCode = reader.GetString(2);
                                s.fs_coo = reader.GetString(3);
                                s.fi_qty = int.Parse(reader.GetDouble(4).ToString());
                                s.fd_totalWeightLbs = reader.GetDouble(5);
                                s.fd_totalWeightKgs = reader.GetDouble(6);
                                s.fd_unitPrice = decimal.Parse(reader.GetDouble(7).ToString());
                                s.fd_exitPrice = decimal.Parse(reader.GetDouble(8).ToString());
                                if (s.fs_partNumber == null)
                                {
                                    reader.NextResult();
                                }
                                else
                                {
                                    using (var context = new YETIEntities())
                                    {

                                        context.SouthBounds.Add(s);
                                        context.SaveChanges();
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.Write(ex.Message);
                            }
                        }
                    }
                    using (var context = new YETIEntities())
                    {
                        cqf_logActividad log = new cqf_logActividad();
                        log.fdt_fecha = DateTime.Now;
                        log.fi_idUsuario = int.Parse(Session["UserID"].ToString());
                        log.fs_actividad = "Add Production Order: "+txtPO.Text;

                        context.cqf_logActividad.Add(log);
                        context.SaveChanges();
                    }
                }
            }

            Response.Redirect("SouthBoundList.aspx");
        }

        protected void yes_Click(object sender, EventArgs e)
        {
            using (var context = new YETIEntities())
            {
                var result = context.SouthBounds.Where(w => w.fs_productionOrder == txtPO.Text && w.fc_status=="A").ToList();
                if(result!=null)
                {
                    foreach(SouthBound s in result)
                    {
                        s.fc_status = "C";
                        context.SaveChanges();

                        cqf_logActividad log = new cqf_logActividad();
                        log.fdt_fecha = DateTime.Now;
                        log.fi_idUsuario = int.Parse(Session["UserID"].ToString());
                        log.fs_actividad = "Cancel Production Order: "+ txtPO;

                        context.cqf_logActividad.Add(log);

                        context.SaveChanges();

                    }

                }
            }

          
        }

        protected void no_Click(object sender, EventArgs e)
        {

        }
    }
}