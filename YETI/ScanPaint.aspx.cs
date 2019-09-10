using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExcelDataReader;

namespace YETI
{
    public partial class ScanPaint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filePath = "";
            if (ImportSB.HasFile)
            {
                
                if (File.Exists(Server.MapPath("~/" + ImportSB.FileName)))
                    File.Delete(Server.MapPath("~/" + ImportSB.FileName));

                ImportSB.SaveAs(Server.MapPath("~/NorthBound/" + ImportSB.FileName));
                
                filePath = Server.MapPath("~/NorthBound/" + ImportSB.FileName);

            }

            List<NorthBound> SBs = new List<NorthBound>();
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {

                    while (reader.Read())
                    {
                        if (reader.Depth >= 1)
                        {
                            //reader.NextResult();

                            try
                            {
                                NorthBound s = new NorthBound();
                                s.fc_status = "A";
                                s.fdt_invoiceDate = reader.GetDateTime(0);
                                s.fs_invoiceNumber = reader.GetString(1);
                                s.fs_trailerNumber = reader.GetString(2);
                                s.fs_sealNumber = reader.GetString(3);
                                s.fi_exportOfRecord = 1;
                                s.fs_exportOfRecord = "Maquila Solutions Mexico SA de CV";
                                s.fi_importer = 1;
                                s.fs_importer = "YETI Coolers, LLC";
                                s.fi_shipper = 1;
                                s.fs_shipper = "Maquila Solutions c/o Scanpaint SA de CV";
                                s.fs_shipTo = reader.GetString(7);
                                s.fs_incoterm = "EXW";
                                s.fdt_shipDate = reader.GetDateTime(9);
                                s.fs_shipVia = reader.GetString(10);
                                s.fs_SKU = reader.GetString(11);
                                s.fs_descYeti = reader.GetString(12);
                                s.fs_hsCodeYeti = reader.GetString(13);
                                s.fs_COOYeti = "CN";
                                s.fi_qtyYeti = reader.GetInt32(15);
                                s.fd_unitPriceYeti = reader.GetDecimal(16);
                                s.fd_extPriceYeti = reader.GetDecimal(17);
                                s.fs_descSP = reader.GetString(18);
                                s.fs_hsCodeSP = reader.GetString(19);
                                s.fs_COOSP= "CN";
                                s.fd_unitPriceSP = reader.GetDecimal(21);
                                s.fs_WONumber = reader.GetString(22);
                                s.fs_upsTracking = reader.GetString(23);
                                s.fd_extPriceSP = reader.GetDecimal(24);
                                s.fd_totalEnteredValue = reader.GetDecimal(25);
                                s.fd_totalWeight = reader.GetDouble(26);
                                s.fd_totalAmount = reader.GetDecimal(27);

                                if (s.fs_descSP == null)
                                {
                                    reader.NextResult();
                                }
                                else
                                {
                                    using (var context = new YETIEntities())
                                    {

                                        context.NorthBounds.Add(s);
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
                }
            }
        }
    }
}