using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YETI
{
    public partial class NorthBoundList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var context = new YETIEntities())
                {

                    var list = from g in context.NorthBounds
                               where g.fc_status == "A"
                               group g by new { g.fs_invoiceNumber , g.fs_upsTracking, g.fdt_invoiceDate, g.fs_trailerNumber, g.fs_sealNumber, g.fi_exportOfRecord, g.fi_importer, g.fi_shipper, g.fi_shipTo, g.fs_incoterm, g.fs_shipVia, g.fdt_shipDate, g.fd_totalWeight, g.fd_totalAmount} into gr
                               select new { gr.Key.fs_invoiceNumber, gr.Key.fs_upsTracking, gr.Key.fdt_invoiceDate, gr.Key.fs_trailerNumber, gr.Key.fs_sealNumber, gr.Key.fi_exportOfRecord, gr.Key.fi_importer, gr.Key.fi_shipper, gr.Key.fi_shipTo, gr.Key.fs_incoterm, gr.Key.fs_shipVia, gr.Key.fdt_shipDate, gr.Key.fd_totalWeight, gr.Key.fd_totalAmount };

                    rgSouthBoundList.DataSource = list.OrderByDescending(o => o.fdt_invoiceDate).ToList();
                    rgSouthBoundList.DataBind();
                }
            }
        }

        protected void download_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void rgSouthBoundList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                string PO = e.CommandArgument.ToString();
                using (var context = new YETIEntities())
                {
                    ReportDocument cryRpt = new ReportDocument();
                    cryRpt.Load(Server.MapPath("~/Reports/RNB.rpt"));

                    var t = context.NorthBounds.Where(w => w.fs_invoiceNumber == PO & w.fc_status == "A").Select(c => new {c.fs_SKU, c.fs_descYeti, c.fs_hsCodeYeti, c.fs_COOYeti, c.fi_qtyYeti, c.fd_unitPriceYeti, c.fd_extPriceYeti, c.fs_descSP, c.fs_hsCodeSP, c.fs_COOSP, c.fd_unitPriceSP, c.fd_extPriceSP, c.fd_totalEnteredValue }).ToList();

                    var list = (from g in context.NorthBounds
                               where g.fc_status == "A" && g.fs_invoiceNumber==PO
                               group g by new { g.fs_invoiceNumber, g.fs_upsTracking, g.fdt_invoiceDate, g.fs_trailerNumber, g.fs_sealNumber, g.fi_exportOfRecord, g.fi_importer, g.fi_shipper, g.fi_shipTo, g.fs_incoterm, g.fs_shipVia, g.fdt_shipDate, g.fd_totalWeight, g.fd_totalAmount } into gr
                               select new { gr.Key.fs_invoiceNumber, gr.Key.fs_upsTracking, gr.Key.fdt_invoiceDate, gr.Key.fs_trailerNumber, gr.Key.fs_sealNumber, gr.Key.fi_exportOfRecord, gr.Key.fi_importer, gr.Key.fi_shipper, gr.Key.fi_shipTo, gr.Key.fs_incoterm, gr.Key.fs_shipVia, gr.Key.fdt_shipDate, gr.Key.fd_totalWeight, gr.Key.fd_totalAmount }).ToList();

                    var exportid = context.NorthBounds.Where(w => w.fs_invoiceNumber == PO & w.fc_status == "A").Select(s => s.fi_exportOfRecord).FirstOrDefault();
                    var importid = context.NorthBounds.Where(w => w.fs_invoiceNumber == PO & w.fc_status == "A").Select(s => s.fi_importer).FirstOrDefault();
                    var shipperid = context.NorthBounds.Where(w => w.fs_invoiceNumber == PO & w.fc_status == "A").Select(s => s.fi_shipper).FirstOrDefault();
                    var shiptoid = context.NorthBounds.Where(w => w.fs_invoiceNumber == PO & w.fc_status == "A").Select(s => s.fi_shipTo).FirstOrDefault();

                    var ex = context.cqc_exports.Where(w => w.ci_id == importid).ToList();
                    var im = context.cqc_imports.Where(w => w.ci_id == exportid).ToList();
                    var sp = context.cqc_shippers.Where(w => w.ci_id == shiptoid).ToList();
                    var st = context.cqc_shipto.Where(w => w.ci_id == shipperid).ToList();


                    cryRpt.Database.Tables["DataTable3"].SetDataSource(ex);
                    cryRpt.Database.Tables["DataTable4"].SetDataSource(im);
                    cryRpt.Database.Tables["DataTable5"].SetDataSource(sp);
                    cryRpt.Database.Tables["DataTable6"].SetDataSource(st); 
                    cryRpt.Database.Tables["DataTable7"].SetDataSource(t);
                    cryRpt.Database.Tables["DataTable8"].SetDataSource(list);


                    crystalReportViewer1.ReportSource = cryRpt;

                    crystalReportViewer1.RefreshReport();
                    cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Server.MapPath("~/Reports/RNorthBound" + PO + ".pdf"));
                    cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "RNorthBound" + PO);
                    Response.Redirect("NorthBoundList.aspx");
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
                var list = from g in context.SouthBounds
                           where g.fc_status == "A"
                           group g by new { g.fs_productionOrder, g.fs_reference, g.fs_trucker, g.fs_invoice, g.fs_tracking, g.fd_date } into gr
                           select new { gr.Key.fs_productionOrder, gr.Key.fs_reference, gr.Key.fs_trucker, gr.Key.fs_invoice, gr.Key.fs_tracking, gr.Key.fd_date };
                rgSouthBoundList.DataSource = list.OrderByDescending(o => o.fd_date).ToList();
                rgSouthBoundList.DataBind();
            }
        }
    }
}
