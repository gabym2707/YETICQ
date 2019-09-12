using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YETI.Reports;

namespace YETI
{
    public partial class SouthBoundList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                using (var context = new YETIEntities())
                {

                    var list= from g in context.SouthBounds where g.fc_status=="A"
                                                  group g by new { g.fs_productionOrder, g.fs_reference, g.fs_trucker, g.fs_invoice, g.fs_tracking, g.fd_date } into gr
                                                  select new { gr.Key.fs_productionOrder, gr.Key.fs_reference, gr.Key.fs_trucker, gr.Key.fs_invoice, gr.Key.fs_tracking, gr.Key.fd_date };
                    rgSouthBoundList.DataSource = list.ToList();
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
                cryRpt.Load(Server.MapPath("~/Reports/RSouthBound.rpt"));

                cryRpt.SetDataSource(context.SouthBounds.Where(w => w.fs_productionOrder == PO).ToList());
                crystalReportViewer1.ReportSource = cryRpt;

                crystalReportViewer1.RefreshReport();
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Server.MapPath("~/Reports/RSouthBound.pdf"));
            } 
        }

        protected void rgSouthBoundList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if(e.CommandName=="Download")
            {
                string PO = e.CommandArgument.ToString();
                using (var context = new YETIEntities())
                {

                    ReportDocument cryRpt = new ReportDocument();
                    cryRpt.Load(Server.MapPath("~/Reports/RSouthBound.rpt"));

                    var t = context.SouthBounds.Where(w => w.fs_productionOrder == PO & w.fc_status=="A").ToList();
                    cryRpt.Database.Tables["SouthBound"].SetDataSource(t);

                    var exportid = context.SouthBounds.Where(w => w.fs_productionOrder == PO & w.fc_status == "A").Select(s => s.fi_exportRecords).FirstOrDefault();
                    var importid = context.SouthBounds.Where(w => w.fs_productionOrder == PO & w.fc_status == "A").Select(s => s.fi_importRecords).FirstOrDefault();
                    var shipperid = context.SouthBounds.Where(w => w.fs_productionOrder == PO & w.fc_status == "A").Select(s => s.fi_shipper).FirstOrDefault();
                    var shiptoid = context.SouthBounds.Where(w => w.fs_productionOrder == PO & w.fc_status == "A").Select(s => s.fi_shipTo).FirstOrDefault();

                    var ex =  context.cqc_exports.Where(w => w.ci_id == exportid).ToList();
                    var im = context.cqc_imports.Where(w => w.ci_id == importid).ToList();
                    var sp = context.cqc_shippers.Where(w => w.ci_id == shipperid).ToList();
                    var st = context.cqc_shipto.Where(w => w.ci_id == shiptoid).ToList();
                    var master= context.MasterInvoiceSBs.Where(w => w.fs_productionOrder == PO).ToList();
                    cryRpt.Database.Tables["cqc_exports"].SetDataSource(ex);
                    cryRpt.Database.Tables["cqc_imports"].SetDataSource(im);
                    cryRpt.Database.Tables["cqc_shippers"].SetDataSource(sp);
                    cryRpt.Database.Tables["cqc_shipto"].SetDataSource(st);
                    cryRpt.Database.Tables["MasterInvoiceSBs"].SetDataSource(master);

                    crystalReportViewer1.ReportSource = cryRpt;

                    crystalReportViewer1.RefreshReport();
                    //rpt.SetDatabaseLogon("", "",, "ADMIN-PC\\ADMIN", "dbRMC");
                  //  cryRpt.SetDatabaseLogon("cqrepo", "ZKmrbXT8KaG5", "65.151.189.66","YETI");
                    //cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Server.MapPath("~/Reports/RSouthBound.pdf"));
                    cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "TEST");
                }
            }
        }
    }
    }
