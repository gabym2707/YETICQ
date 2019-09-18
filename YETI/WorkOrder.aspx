<%@ Page Title="" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="WorkOrder.aspx.cs" Inherits="YETI.WorkOrder" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="sss" runat="server"></asp:ScriptManager>
    <h4>Shipper From</h4>
         <div class="row">
         <div class="col-2">
              Shipper UPS Account:<br />
             <asp:TextBox ID="txtshipperAccount" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
          <div class="col-2">
               Reference #:<br />
             <asp:TextBox ID="txtReference" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
             <div class="col-2">
                   Name: <br />
             <asp:TextBox ID="txtName" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
             <div class="col-2">
                     Phone:<br />
             <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
             <div class="col-3">
                     Company: <br />
             <asp:TextBox ID="txtCompany" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
             <div class="col-2">
                 Street Address:<br />
             <asp:TextBox ID="txtsa" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>

         </div>
             <div class="col-2">
                  City and State:<br />
             <asp:TextBox ID="txtcs" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>

         </div>
         </div>
    <h4> Deliver To:</h4>
      <div class="row">
         <div class="col-3">
              Name:<br />
             <asp:TextBox ID="txtDelName" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>

         </div>
             <div class="col-2">
                  Phone:<br />
             <asp:TextBox ID="txtDelPhone" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
           <div class="col-3">
               Company: <br />
             <asp:TextBox ID="txtDelCom" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
           <div class="col-2">
                Street Address:<br />
             <asp:TextBox ID="txtDelSA" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
           <div class="col-2">
                City and State:<br />
             <asp:TextBox ID="txtDelCS" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
         </div>

    <h4> Weight Whole Lbs Only</h4>
      <div class="row">
         <div class="col-3">
              Weight Whole Lbs Only:<br />
             <asp:TextBox ID="txtWeight" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>

         </div>
             <div class="col-2">
                  Dimentional Weight:<br />
             <asp:TextBox ID="txtDimentional" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
           <div class="col-2">
                Large Package: <br />
             <asp:TextBox ID="txtLarge" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
           <div class="col-2">
                Shipper Release:<br />
             <asp:TextBox ID="txtShipper" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
            
         </div>
    <asp:UpdatePanel ID="updt" runat="server"><ContentTemplate>
      <div class="row">
          <div class="col-3">
                Ground SDP Shipping: <br />
             <asp:TextBox ID="txtGroud" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
         <div class="col-3">
              Declare Value for Carriage:<br />
             <asp:TextBox ID="txtDeclare" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>

         </div>
             <div class="col-2">
                  Amount:<br />
             <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
           <div class="col-3">
                Aditional Handling Charge: <br />
             <asp:TextBox ID="txtAditional" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>

          </div>
         <div class="row">
             <div class="col-3">
               Total Charges:<br />
             <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
           <div class="col-3">
                Method of Payment:<br />
               
            <asp:RadioButton ID="rbtn_shipAcc" GroupName="metodoPago" AutoPostBack="true" OnCheckedChanged="rbtn_shipAcc_CheckedChanged"  runat="server" Text="Bill Shipper´s account Number" /><br />
              <asp:RadioButton ID="rbtn_billReceiver" GroupName="metodoPago" OnCheckedChanged="rbtn_shipAcc_CheckedChanged" AutoPostBack="true" runat="server" Text="Bill Receiver" /><br />
              <asp:RadioButton ID="rbtn_billThirdParty" GroupName="metodoPago" OnCheckedChanged="rbtn_shipAcc_CheckedChanged" AutoPostBack="true" runat="server" Text="Bill Third Party" /><br />
              <asp:RadioButton ID="rbtn_CreditCard" GroupName="metodoPago" OnCheckedChanged="rbtn_shipAcc_CheckedChanged" runat="server" AutoPostBack="true" Text="Credit Card" /><br />
         </div>
           </div>
          <div class="row" id="thir" runat="server" visible="false">
                <div class="col-5">
                    Receiver´s Third Party's UPS Acct. Or Major Credit Card:<br/>
                    <asp:TextBox ID="txtUpsAcct" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox> 
                </div>
                <div class="col-3">
                   Third Part Company Name<br/>
                    <asp:TextBox ID="txtThirdCN" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox> 
                </div>
                <div class="col-2">
                    Street Address<br/>
                    <asp:TextBox ID="txtThirdSA" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox> 
                </div>
                <div class="col-2">
                    City and State:<br/>
                    <asp:TextBox ID="txtThirdCS" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox> 
                </div>
            </div></ContentTemplate></asp:UpdatePanel>
     <div class="row">
          <div class="col-2">
             Work Order:<br />
            <asp:TextBox ID="txtWorkOrder" runat="server" CssClass="form-control-sm"></asp:TextBox>
         </div>
          
         <div class="col-2">
             Date:<br />
            <asp:TextBox ID="txtWorkOrderDate" runat="server" type="date" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
         <div class="col-sm-4">Work Order Content: <br />
             <asp:FileUpload ID="ImportSB" runat="server" Width="100%" />
         </div>
        <div class="col-sm-2" >
            <br />
             <asp:LinkButton ID="btnUpload" runat="server" OnClick="btnUpload_Click" CssClass="btn btn-primary"  ForeColor="White">Upload</asp:LinkButton>     
        </div>
         </div>

    <div class="row" id="gridWO" visible="false">
        <div class="col-sm-12">
            <telerik:RadGrid ID="rgWorkOrder" ClientSettings-Scrolling-AllowScroll="true" Height="400px" runat="server" AutoGenerateColumns="false" ClientSettings-Scrolling-UseStaticHeaders="true" Skin="Metro">
                <MasterTableView>
                    <Columns>
                         <telerik:GridBoundColumn DataField="fs_sku" HeaderText="SKU #" >
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fs_paintcode" HeaderText="Paint Code" >
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fs_engraving" HeaderText="Engraving" >
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fi_qty" HeaderText="Qty." >
						</telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
        <br />
        <div class="col-sm-12">
            <asp:LinkButton style="float:right;" CssClass="btn btn-sm btn-primary" ID="UploadWO" runat="server" OnClick="UploadWO_Click">Finish Work Order</asp:LinkButton>
        </div>
    </div>

       <script type="text/javascript">
        function openModal() {
            $('#modal').modal('show');
        }

    </script>
        <script type="text/javascript">
        function openModal2() {
            $('#modal2').modal('show');
        }

    </script>
<div class="modal fade" id="modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
        <h5 class="modal-title">Work Order Repeat</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <p>This Work Order exist, do you want cancel previous one and take this?</p>
      </div>
      <div class="modal-footer">
        <asp:LinkButton ID="yes" runat="server" OnClick="yes_Click" CssClass="btn btn-primary"> Yes, Save this!</asp:LinkButton>
        <asp:LinkButton ID="no" runat="server" CssClass="btn btn-secondary" data-dismiss="modal">Don't Cancel anything</asp:LinkButton>
      </div>
    </div>
  </div>
</div>
    <div class="modal fade" id="modal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
        <h5 class="modal-title">Work Order Repeat</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <p>The Work Order Number and Work Order Date are requirement fields</p>
      </div>
       
    </div>
  </div>
</div>
</asp:Content>
