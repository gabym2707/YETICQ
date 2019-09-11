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
            string filePath = "";
            if (ImportSB.HasFile)
            {
                //UploadedFile file = layoutUpload.UploadedFiles[0];
                if (File.Exists(Server.MapPath("~/" + ImportSB.FileName)))
                    File.Delete(Server.MapPath("~/" + ImportSB.FileName));

                ImportSB.SaveAs(Server.MapPath("~/" + ImportSB.FileName));

                filePath = Server.MapPath("~/" + ImportSB.FileName);

            }

            List<SouthBound> SBs = new List<SouthBound>();
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
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
                            SouthBound s = new SouthBound();
                            s.fc_status = "A";
                            s.fs_reference = ""; //WONumber.Text;
                            s.fs_productionOrder = "";// WONumber.Text;
                            s.fs_partNumber= reader.GetString(1);
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
                            else { 
                            using (var context = new YETIEntities())
                            {
 
                                context.SouthBounds.Add(s); 
                                context.SaveChanges();
                            }
                            }

                        }
                        catch(Exception ex)
                        {
                            Console.Write(ex.Message);
                        }
                        }
                    }
                }
            }
           
        }
    }
}