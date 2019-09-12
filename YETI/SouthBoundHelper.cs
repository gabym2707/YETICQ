using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YETI
{
    public class SouthBoundHelper
    {
        public string correoSouthBound(string enlace)
        {
            string Correo = @"<html>
                <head runat ='server'>
                    <meta http-equiv='Content-Type'content='text/html;charset=utf-8'/>
                    <link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css' >
                </head>
                <body>
                    <form id ='form1' runat='server'>
                        <div class='mt-3 ml-3' style ='width:800px; height:600px; padding:20px; text-align:center; border: 10px solid #16055e'>
                            <div style ='width:750px; height:550px; padding:20px; text-align:center; border: 5px solid #424242'>
                                <img src='http://65.151.189.66/VentasInternas/img/CARGOQUIN-CURVAS.png' width='200px'; height='150px'/>
                                <img src='https://www.yeti.com/on/demandware.static/-/Sites/default/dweb462676/images/slot/landing/YETI-Logo-Social.png' width='200px'; height:'200px'/><br/><br/>
                                <span style ='font-size:30px; font-weight:bold'>Commercial Invoice Notification</span> <br/>
                                <span style ='font-size:30px'><b> </b></span><br/>
                                <span style ='font-size:25px'>Please confirm that you received the commercial invoice for the NorthBound by clicking the button below</span> <span style='font-size:60px'>
                                </span >
                                <br/><br />
                                <div class='row'>
                                    <div class='col-3'></div>
                                    <div class='col-6'><a href='" + enlace + "' class='btn btn-success'>Confirm</a> </div>" +
                                @"</div><br/><br/>
                                <p style ='font-size:20px;' class='text-danger'>Please do not reply to this message.</p>
                            </div>
                        </div>
                    </form>
                </body>
            </html>";
            return Correo;
        }
    }
}