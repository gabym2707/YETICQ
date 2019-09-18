using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YETI.Reports;

namespace YETI
{
    public partial class ScrapMDList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                using (var context = new YETIEntities())
                {

                    var list = context.cqf_mexicanDutys.ToList();
                    rgSouthBoundList.DataSource = list.OrderByDescending(o => o.fi_id).ToList();
                   rgSouthBoundList.DataBind();
                }
            }
        }

        protected void download_Click(object sender, EventArgs e)
        {
             
        }

        protected void rgSouthBoundList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if(e.CommandName=="Download")
            {
                string WO = e.CommandArgument.ToString();
                using (var client = new WebClient())
                {
                    client.DownloadFile("http://localhost:61765/Certificates/"+WO, WO);
                }
                //Response.Redirect(Server.MapPath("~/Certificates/"+WO));
                
            }
        }

        protected void rgSouthBoundList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rgSouthBoundList_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            using (var context = new YETIEntities())
            {
                var list = context.cqf_mexicanDutys.ToList();
                rgSouthBoundList.DataSource = list.OrderByDescending(o => o.fi_id).ToList();
                rgSouthBoundList.DataBind();
            }
        }
    }
    }
