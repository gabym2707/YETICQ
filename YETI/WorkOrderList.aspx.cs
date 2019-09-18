using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YETI.Reports;

namespace YETI
{
    public partial class WorkOrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                using (var context = new YETIEntities())
                {

                    var list= from g in context.cqf_workOrder where g.fc_status=="A"
                                                  group g by new { g.fs_workOrder, g.fdt_date } into gr
                                                  select new { gr.Key.fs_workOrder
                             , gr.Key.fdt_date };
                    rgSouthBoundList.DataSource = list.OrderByDescending(o => o.fdt_date).ToList();
                   rgSouthBoundList.DataBind();
                }
            }
        }

        protected void download_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            string PO = lnk.CommandArgument.ToString();
            using (var context = new YETIEntities())
            {

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(Server.MapPath("~/Reports/RWO.rpt"));

                cryRpt.SetDataSource(context.cqf_workOrder.Where(w => w.fs_workOrder == PO).ToList());
                crystalReportViewer1.ReportSource = cryRpt;

                crystalReportViewer1.RefreshReport();
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Server.MapPath("~/Reports/RWO.pdf"));

                cqf_logActividad log = new cqf_logActividad();
                log.fdt_fecha = DateTime.Now;
                log.fi_idUsuario = int.Parse(Session["UserID"].ToString());
                log.fs_actividad = "Download Report Work Order:"+PO;

                context.cqf_logActividad.Add(log);
                context.SaveChanges();

            } 
        }

        protected void rgSouthBoundList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if(e.CommandName=="Download")
            {
                string WO = e.CommandArgument.ToString();
                using (var context = new YETIEntities())
                {
            ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(Server.MapPath("~/Reports/RWO.rpt"));

             //   var t = context.cqf_workOrder.Where(w => w.fs_workOrder == WO & w.fc_status=="A").Select(c=> new { c.fs_sku, c.fs_paintCode, c.fs_engraving, c.fi_qty}).ToList();
                     

                    var master =  from w in context.cqf_WorkOrderMaster
                                            where w.fc_status == "A" && w.fs_workOrder== WO
                                             
                                            select new
                                            {
                                                w.fs_workOrder,
                                                w.fdt_date,
                                                w.fs_shipperUpsAccount,
                                                w.fs_reference,
                                                w.fs_name,
                                                w.fs_telephone,
                                                w.fs_company,
                                                w.fs_streetAddress,
                                                w.fs_cityState,
                                                w.fs_deliverToName,
                                                w.fs_deliverPhone,
                                                w.fs_deliverCompany,
                                                w.fs_deliverStreetAddress,
                                                w.fs_deliverCityState,
                                                w.fd_weightLbs,
                                                w.fd_dimentionalWeight,
                                                w.fd_largePackage,
                                                w.fs_shipperRelease,
                                                w.fd_groundSdpShippingCharges,
                                                w.fd_declareValueCarriage,
                                                w.fd_amount,
                                                w.fd_aditionalHandlingCharge,
                                                w.fd_totalCharges,
                                                w.fb_billShipperAccountNumber,
                                                w.fb_billReceiver,
                                                w.fb_billThirdParty,
                                                w.fb_billCreditCard,
                                                w.fs_receiversThirdPartyUpsAcct,
                                                w.fs_thirdPartCompanyName,
                                                w.fs_thirdStreetAddress,
                                                w.fs_thirdCityState
                                            };

                    var content= context.cqf_workOrder.Where(w => w.fs_workOrder == WO && w.fc_status == "A").Select(c => new { c.fs_sku, c.fs_paintCode, c.fs_engraving, c.fi_qty }).ToList();
                     

                    cryRpt.Database.Tables["DataTable1"].SetDataSource(master);
                    cryRpt.Database.Tables["DataTable2"].SetDataSource(content); 


                    crystalReportViewer1.ReportSource = cryRpt;

                crystalReportViewer1.RefreshReport();
               cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Server.MapPath("~/Reports/RWO"+WO+".pdf"));
                cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "RWO"+WO);
                    Response.Redirect("Inicio.aspx");
                }
            }
        }

        protected void rgSouthBoundList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rgSouthBoundList_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            using (var context = new YETIEntities())
            {

                var list = from g in context.cqf_workOrder
                           where g.fc_status == "A"
                           group g by new { g.fs_workOrder, g.fdt_date } into gr
                           select new
                           {
                               gr.Key.fs_workOrder
      ,
                               gr.Key.fdt_date
                           };
                rgSouthBoundList.DataSource = list.OrderByDescending(o => o.fdt_date).ToList();
                rgSouthBoundList.DataBind();
            }
        }
    }
    }
