using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YETI
{
    public partial class WorkOrder : System.Web.UI.Page
    {
        YETIEntities context = new YETIEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if(txtWorkOrder.Text !="")
            { 
            if (ImportSB.HasFile && ImportSB.FileName.Contains(".xls"))
            {
                //UploadedFile file = layoutUpload.UploadedFiles[0];
                if (File.Exists(Server.MapPath("~/WorkOrders/" + txtWorkOrder.Text + ".xls")))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
                else
                {
                    ImportSB.SaveAs(Server.MapPath("~/WorkOrders/" + txtWorkOrder.Text + ".xls"));
                    context.cqf_logActividad.Add(new cqf_logActividad
                    {
                        fdt_fecha = DateTime.Now,
                        fi_idUsuario = int.Parse(Session["UserID"].ToString()),
                        fs_actividad = "Upload Work Order File"
                    });
                    context.SaveChanges();
                }

            }
            

            List<cqf_workOrder> SBs = new List<cqf_workOrder>();
            using (var stream = File.Open(Server.MapPath("~/WorkOrders/" + txtWorkOrder.Text + ".xls"), FileMode.Open, FileAccess.Read))
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
                                string[] ShipDate = txtWorkOrderDate.Text.Split('-');
                                cqf_workOrder s = new cqf_workOrder();
                                s.fc_status = "A";
                                s.fs_workOrder = txtWorkOrder.Text;
                                try{ s.fs_sku = reader.GetDouble(0).ToString(); } catch { s.fs_sku = reader.GetString(0).ToString(); }
                                try { s.fs_paintCode = reader.GetDouble(1).ToString(); } catch { s.fs_paintCode = reader.GetString(1).ToString(); }
                                s.fs_engraving = reader.GetString(2);
                                s.fdt_date = new DateTime(int.Parse(ShipDate[0]), int.Parse(ShipDate[1]), int.Parse(ShipDate[2]));
                                s.fi_qty = int.Parse(reader.GetDouble(3).ToString());

                                if (s.fs_sku == null)
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

                    rgWorkOrder.DataSource = SBs.ToList();
                    rgWorkOrder.DataBind();
                }
            }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal2();", true);

            }
        }

        protected void UploadWO_Click(object sender, EventArgs e)
        {
            if(txtWorkOrder.Text!="" && txtWorkOrderDate.Text !="")
            {
                string[] WODate = txtWorkOrderDate.Text.Split('-');
                cqf_WorkOrderMaster wom = new cqf_WorkOrderMaster();
                wom.fc_status = "A";
                wom.fs_workOrder = txtWorkOrder.Text;
                wom.fdt_date= new DateTime(int.Parse(WODate[0]), int.Parse(WODate[1]), int.Parse(WODate[2]));
                wom.fs_shipperUpsAccount = txtshipperAccount.Text;
                wom.fs_reference = txtReference.Text;
                wom.fs_name = txtName.Text;
                wom.fs_telephone = txtTelephone.Text;
                wom.fs_company = txtCompany.Text;
                wom.fs_streetAddress = txtsa.Text;
                wom.fs_cityState = txtcs.Text;
                wom.fs_deliverToName=txtDelName.Text;
                wom.fs_deliverPhone=txtDelPhone.Text;
                wom.fs_deliverCompany=txtDelCom.Text;
                wom.fs_deliverStreetAddress=txtDelSA.Text;
                wom.fs_deliverCityState=txtDelCS.Text;
                try { wom.fd_weightLbs = double.Parse(txtWeight.Text); } catch { wom.fd_weightLbs = 0.00; }
                try { wom.fd_dimentionalWeight = double.Parse(txtDimentional.Text); } catch { wom.fd_dimentionalWeight = 0.00; }
                try { wom.fd_largePackage = double.Parse(txtLarge.Text); } catch { wom.fd_largePackage = 0.00; }
                wom.fs_shipperRelease = txtShipper.Text; 
                try { wom.fd_groundSdpShippingCharges = decimal.Parse(txtGroud.Text); } catch { wom.fd_groundSdpShippingCharges = decimal.Parse("0.00"); }
                try { wom.fd_declareValueCarriage = decimal.Parse(txtDeclare.Text); } catch { wom.fd_declareValueCarriage = decimal.Parse("0.00"); }
                try { wom.fd_amount = decimal.Parse(txtAmount.Text); } catch { wom.fd_amount = decimal.Parse("0.00"); }
                try { wom.fd_aditionalHandlingCharge = decimal.Parse(txtAditional.Text); } catch { wom.fd_aditionalHandlingCharge = decimal.Parse("0.00"); }
                try { wom.fd_totalCharges = decimal.Parse(txtTotal.Text); } catch { wom.fd_totalCharges = decimal.Parse("0.00"); }
                wom.fb_billShipperAccountNumber = rbtn_shipAcc.Checked;
                wom.fb_billShipperAccountNumber = rbtn_billReceiver.Checked;
                wom.fb_billThirdParty = rbtn_billThirdParty.Checked;
                wom.fb_billCreditCard = rbtn_CreditCard.Checked;

                wom.fs_receiversThirdPartyUpsAcct = txtUpsAcct.Text;
                wom.fs_thirdPartCompanyName=txtThirdCN.Text;
                wom.fs_thirdCityState = txtThirdCS.Text;
                wom.fs_thirdStreetAddress = txtThirdSA.Text;

                context.cqf_WorkOrderMaster.Add(wom);
                context.SaveChanges();


                List<cqf_workOrder> SBs = new List<cqf_workOrder>();
            using (var stream = File.Open(Server.MapPath("~/WorkOrders/" + txtWorkOrder.Text + ".xls"), FileMode.Open, FileAccess.Read))
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
                                string[] ShipDate = txtWorkOrderDate.Text.Split('-');
                                cqf_workOrder s = new cqf_workOrder();
                                s.fc_status = "A";
                                s.fs_workOrder = txtWorkOrder.Text;
                                try { s.fs_sku = reader.GetDouble(0).ToString(); } catch { s.fs_sku = reader.GetString(0).ToString(); }
                                try { s.fs_paintCode = reader.GetDouble(1).ToString(); } catch { s.fs_paintCode = reader.GetString(1).ToString(); }
                                s.fs_engraving = reader.GetString(2);
                                s.fdt_date = new DateTime(int.Parse(ShipDate[0]), int.Parse(ShipDate[1]), int.Parse(ShipDate[2]));
                                s.fi_qty = int.Parse(reader.GetDouble(3).ToString());

                                if (s.fs_sku == null)
                                {
                                    reader.NextResult();
                                }
                                else
                                {
                                    using (var context = new YETIEntities())
                                    {
                                        context.cqf_workOrder.Add(s);
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
                        log.fs_actividad = "Add Work Order: " + txtWorkOrder.Text;

                        context.cqf_logActividad.Add(log);
                        context.SaveChanges();
                    }

                    Response.Redirect("Inicio.aspx");
                }
            }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal2();", true); 
            }
        }

        protected void yes_Click(object sender, EventArgs e)
        {
            using (var context = new YETIEntities())
            {
                var result = context.cqf_workOrder.Where(w => w.fs_workOrder == txtWorkOrder.Text && w.fc_status == "A").ToList();

                var resul2= context.cqf_WorkOrderMaster.Where(w => w.fs_workOrder == txtWorkOrder.Text && w.fc_status == "A").ToList();
                if (result != null)
                {
                    foreach (cqf_workOrder s in result)
                    {
                        s.fc_status = "C";
                        context.SaveChanges();

                        cqf_logActividad log = new cqf_logActividad();
                        log.fdt_fecha = DateTime.Now;
                        log.fi_idUsuario = int.Parse(Session["UserID"].ToString());
                        log.fs_actividad = "Cancel Work Order: " + txtWorkOrder;

                        context.cqf_logActividad.Add(log); 
                        context.SaveChanges();

                    }
                    foreach (cqf_WorkOrderMaster s in resul2)
                    {
                        s.fc_status = "C";
                        context.SaveChanges();

                        cqf_logActividad log = new cqf_logActividad();
                        log.fdt_fecha = DateTime.Now;
                        log.fi_idUsuario = int.Parse(Session["UserID"].ToString());
                        log.fs_actividad = "Cancel Work Order Master: " + txtWorkOrder;

                        context.cqf_logActividad.Add(log);
                        context.SaveChanges();

                    }


                }
            }


        }

        protected void rbtn_shipAcc_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtn_billThirdParty.Checked)
            {
                thir.Visible = true;
            }
            else
            {

                thir.Visible = false;
            }
        }
    }
}