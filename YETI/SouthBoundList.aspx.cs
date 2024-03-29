﻿using CrystalDecisions.CrystalReports.Engine;
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
                    rgSouthBoundList.DataSource = list.OrderByDescending(o => o.fd_date).ToList();
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

                cqf_logActividad log = new cqf_logActividad();
                log.fdt_fecha = DateTime.Now;
                log.fi_idUsuario = int.Parse(Session["UserID"].ToString());
                log.fs_actividad = "Download South Bound Report Production Order:"+PO;

                context.cqf_logActividad.Add(log);
                context.SaveChanges();

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
                cryRpt.Load(Server.MapPath("~/Reports/RSB.rpt"));

                var t = context.SouthBounds.Where(w => w.fs_productionOrder == PO & w.fc_status=="A").Select(c=> new { c.fs_partNumber, c.fs_description, c.fs_scheduleHsCode, c.fs_coo, c.fi_qty, c.fd_totalWeightKgs, c.fd_totalWeightLbs, c.fd_unitPrice, c.fd_exitPrice}).ToList();
                     

                    var master = context.MasterInvoiceSBs.Where(w => w.fs_productionOrder == PO).Select(c=> new {c.fc_status, c.fs_invoice, c.fs_trucker, c.fs_tracking, c.fd_date, c.fs_productionOrder, c.fs_reference, c.fs_moneda, c.fd_totalWeightKgs, c.fs_totalWightLbs, c.fd_exitPrice }).ToList();
                    var exportid = context.SouthBounds.Where(w => w.fs_productionOrder == PO & w.fc_status == "A").Select(s => s.fi_exportRecords).FirstOrDefault();
                    var importid = context.SouthBounds.Where(w => w.fs_productionOrder == PO & w.fc_status == "A").Select(s => s.fi_importRecords).FirstOrDefault();
                    var shipperid = context.SouthBounds.Where(w => w.fs_productionOrder == PO & w.fc_status == "A").Select(s => s.fi_shipper).FirstOrDefault();
                    var shiptoid = context.SouthBounds.Where(w => w.fs_productionOrder == PO & w.fc_status == "A").Select(s => s.fi_shipTo).FirstOrDefault();

                    var ex = context.cqc_exports.Where(w => w.ci_id == exportid).ToList();
                    var im = context.cqc_imports.Where(w => w.ci_id == importid).ToList();
                    var sp = context.cqc_shippers.Where(w => w.ci_id == shipperid).ToList();
                    var st = context.cqc_shipto.Where(w => w.ci_id == shiptoid).ToList();

                    cryRpt.Database.Tables["DataTable1"].SetDataSource(t);
                    cryRpt.Database.Tables["DataTable2"].SetDataSource(master);
                    cryRpt.Database.Tables["DataTable3"].SetDataSource(ex);
                    cryRpt.Database.Tables["DataTable4"].SetDataSource(im);
                    cryRpt.Database.Tables["DataTable5"].SetDataSource(sp);
                    cryRpt.Database.Tables["DataTable6"].SetDataSource(st);


                    crystalReportViewer1.ReportSource = cryRpt;

                crystalReportViewer1.RefreshReport();
               cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Server.MapPath("~/Reports/RSouthBound"+PO+".pdf"));
                cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "RSouthBound"+PO+".pdf");
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
