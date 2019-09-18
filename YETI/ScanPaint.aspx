<%@ Page Title="NorthBound" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="ScanPaint.aspx.cs" Inherits="YETI.ScanPaint" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">		
		function openModalMensajes() {
			$('#messageModal').modal('show');
		};		
	</script>
     <div class="row">
        <div class="col-sm-12"><h3>ScanPaint's NorthBounds</h3></div>
    </div>
    <div class="row">
         
          <div class="col-3">
            
         </div>
         <div class="col-sm-5"><br />
             <asp:FileUpload ID="ImportSB" runat="server" />
         </div>
         <div class="col-sm-2"><br />
             <asp:LinkButton ID="btnUpload" CssClass="btn btn-primary" OnClick="btnUpload_Click" runat="server" >Upload</asp:LinkButton>         

         </div>
         </div>
  <div class="row">
         <asp:ScriptManager ID="www" runat="server"></asp:ScriptManager>
          <div class="col-12">

                <telerik:RadGrid ID="rgNorthBound" ClientSettings-Scrolling-AllowScroll="true" Height="270px" runat="server" AutoGenerateColumns="False" ClientSettings-Scrolling-UseStaticHeaders="true" Skin="Metro" GridLines="None">
<ClientSettings>
<Scrolling AllowScroll="True" UseStaticHeaders="True"></Scrolling>
</ClientSettings>

<MasterTableView >
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="fs_invoiceNumber" FilterControlAltText="Filter fs_invoiceNumber column" HeaderText="Invoice #" SortExpression="fs_invoiceNumber" UniqueName="fs_invoiceNumber">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fdt_invoiceDate" DataType="System.DateTime" FilterControlAltText="Filter fdt_invoiceDate column" HeaderText="Invoice Date" DataFormatString="{0: dd/MMM/yyyy}" SortExpression="fdt_invoiceDate" UniqueName="fdt_invoiceDate">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_trailerNumber" FilterControlAltText="Filter fs_trailerNumber column" HeaderText="Trailer #" SortExpression="fs_trailerNumber" UniqueName="fs_trailerNumber">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_sealNumber" FilterControlAltText="Filter fs_sealNumber column" HeaderText="Seal #" SortExpression="fs_sealNumber" UniqueName="fs_sealNumber">
        </telerik:GridBoundColumn> 
        <telerik:GridBoundColumn DataField="fs_exportOfRecord" FilterControlAltText="Filter fs_exportOfRecord column" HeaderText="Export of Records" SortExpression="fs_exportOfRecord" UniqueName="fs_exportOfRecord">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_importer" FilterControlAltText="Filter fs_importer column" HeaderText="Importer of Record" SortExpression="fs_importer" UniqueName="fs_importer">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_shipper" FilterControlAltText="Filter fs_shipper column" HeaderText="Shipper" SortExpression="fs_shipper" UniqueName="fs_shipper">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_shipTo" FilterControlAltText="Filter fs_shipTo column" HeaderText="Ship To" SortExpression="fs_shipTo" UniqueName="fs_shipTo">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_incoterm" FilterControlAltText="Filter fs_incoterm column" HeaderText="Incoterm" SortExpression="fs_incoterm" UniqueName="fs_incoterm">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fdt_shipDate" DataType="System.DateTime" FilterControlAltText="Filter fdt_shipDate column" HeaderText="Ship Date" DataFormatString="{0: dd/MMM/yyyy}" SortExpression="fdt_shipDate" UniqueName="fdt_shipDate">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_shipVia" FilterControlAltText="Filter fs_shipVia column" HeaderText="Ship Via" SortExpression="fs_shipVia" UniqueName="fs_shipVia">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_SKU" FilterControlAltText="Filter fs_SKU column" HeaderText="SKU#" SortExpression="fs_SKU" UniqueName="fs_SKU">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_descYeti" FilterControlAltText="Filter fs_descYeti column" HeaderText="Description" SortExpression="fs_descYeti" UniqueName="fs_descYeti">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_hsCodeYeti" FilterControlAltText="Filter fs_hsCodeYeti column" HeaderText="HS Code" SortExpression="fs_hsCodeYeti" UniqueName="fs_hsCodeYeti">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_COOYeti" FilterControlAltText="Filter fs_COOYeti column" HeaderText="COO" SortExpression="fs_COOYeti" UniqueName="fs_COOYeti">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fi_qtyYeti" DataType="System.Int32" FilterControlAltText="Filter fi_qtyYeti column" HeaderText="Qty" SortExpression="fi_qtyYeti" UniqueName="fi_qtyYeti">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fd_unitPriceYeti" DataType="System.Decimal" FilterControlAltText="Filter fd_unitPriceYeti column" HeaderText="Unity Price" SortExpression="fd_unitPriceYeti" UniqueName="fd_unitPriceYeti">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fd_extPriceYeti" DataType="System.Decimal" FilterControlAltText="Filter fd_extPriceYeti column" HeaderText="Exit Price" SortExpression="fd_extPriceYeti" UniqueName="fd_extPriceYeti">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_descSP" FilterControlAltText="Filter fs_descSP column" HeaderText="Description" SortExpression="fs_descSP" UniqueName="fs_descSP">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_hsCodeSP" FilterControlAltText="Filter fs_hsCodeSP column" HeaderText="HS Code" SortExpression="fs_hsCodeSP" UniqueName="fs_hsCodeSP">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_COOSP" FilterControlAltText="Filter fs_COOSP column" HeaderText="COO" SortExpression="fs_COOSP" UniqueName="fs_COOSP">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fd_unitPriceSP" DataType="System.Decimal" FilterControlAltText="Filter fd_unitPriceSP column" HeaderText="Unit Price" SortExpression="fd_unitPriceSP" UniqueName="fd_unitPriceSP">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fd_extPriceSP" DataType="System.Decimal" FilterControlAltText="Filter fd_extPriceSP column" HeaderText="Exit Price" SortExpression="fd_extPriceSP" UniqueName="fd_extPriceSP">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_WONumber" FilterControlAltText="Filter fs_WONumber column" HeaderText="Work Order" SortExpression="fs_WONumber" UniqueName="fs_WONumber">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fs_upsTracking" FilterControlAltText="Filter fs_upsTracking column" HeaderText="UPS Tracking" SortExpression="fs_upsTracking" UniqueName="fs_upsTracking">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fd_totalEnteredValue" DataType="System.Decimal" FilterControlAltText="Filter fd_totalEnteredValue column" HeaderText="Total Entered Value" SortExpression="fd_totalEnteredValue" UniqueName="fd_totalEnteredValue">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fd_totalWeight" DataType="System.Double" FilterControlAltText="Filter fd_totalWeight column" HeaderText="Total Weight" SortExpression="fd_totalWeight" UniqueName="fd_totalWeight">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="fd_totalAmount" DataType="System.Decimal" FilterControlAltText="Filter fd_totalAmount column" HeaderText="Total Amount" SortExpression="fd_totalAmount" UniqueName="fd_totalAmount">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
                </telerik:RadGrid>

              </div></div>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <br /><br />
    <asp:Label ID="lblFilename" runat="server" Visible="false"></asp:Label>
    <asp:LinkButton ID="uploadinformation" runat="server" style="float:right;" CssClass="btn btn-sm btn-primary"  OnClick="uploadinformation_Click"></asp:LinkButton>
    <div class="modal fade" id="messageModal" tabindex="-1" role="dialog" aria-labelledby="messageModal-label">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="messageModal-label">Upload Status</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <p>The ScanPaint NorthBound Document Was Successfully Uploaded</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
