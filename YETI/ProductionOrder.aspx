<%@ Page Title="" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="ProductionOrder.aspx.cs" Inherits="YETI.WorkOrderImport" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scmg" runat="server"></asp:ScriptManager>
     <div class="row">
         <div class="col-2">
             Invoice:<br />
             <asp:TextBox ID="txtInvoice" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
             </div>
          <div class="col-2">
             Trucker:<br />
             <asp:TextBox ID="txtTrucker" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
             </div>
          <div class="col-2">
             Date:<br />
             <asp:TextBox ID="txtDate" runat="server" type="date"  CssClass="form-control-sm" Width="100%" ></asp:TextBox>
             </div>
          <div class="col-2">
             Tracking:<br />
             <asp:TextBox ID="txtTracking" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
             </div>
         <div class="col-2">
             POs:<br />
             <asp:TextBox ID="txtPO" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
             </div>
         <div class="col-2">
             Reference:<br />
             <asp:TextBox ID="txtReference" runat="server" CssClass="form-control-sm" Width="100%"></asp:TextBox>
             </div>
         </div>
     <div class="row">
         <div class="col-3"><br />
             Export of records:<br />
            <asp:DropDownList ID="ddlsexport" runat="server" CssClass="form-control-sm" DataTextField="cs_nombre" Width="100%" DataValueField="ci_id"></asp:DropDownList>
         </div>
           <div class="col-3"><br />
            Import of records:<br />
            <asp:DropDownList ID="ddlsimport" runat="server" CssClass="form-control-sm" DataTextField="cs_nombre" Width="100%" DataValueField="ci_id"></asp:DropDownList>
         </div>
         <%--</div>
    <div class="row">--%>
         <div class="col-3"><br />
             Shipper:<br />
            <asp:DropDownList ID="ddlsShippers" runat="server" CssClass="form-control-sm" Width="100%" DataTextField="cs_nombre" DataValueField="ci_id"></asp:DropDownList>
         </div>
         
           <div class="col-3"><br />
             Ship To:<br />
            <asp:DropDownList ID="ddlsShipTo" runat="server" type="date" CssClass="form-control-sm" Width="100%" DataTextField="cs_nombre" DataValueField="ci_id"></asp:DropDownList>
         </div>
        </div>
    <div class="row">
          <div class="col-1">
             <br /> Currency:<br />
            <asp:DropDownList ID="ddlsCurrency" runat="server" Width="100%" CssClass="form-control-sm">
                <asp:ListItem Text="DLLS"></asp:ListItem>
                <asp:ListItem Text="MXN"></asp:ListItem>
            </asp:DropDownList>
         </div>
         <div class="col-2"><br />
             Incoterms:<br />
            <asp:DropDownList ID="ddlsIncoterms" runat="server" CssClass="form-control-sm" Width="100%">
                <asp:ListItem Text="EXW"></asp:ListItem>
                <asp:ListItem Text="DAP"></asp:ListItem>
                <asp:ListItem Text="FOB Origin"></asp:ListItem>
                <asp:ListItem Text="CFI / CFR"></asp:ListItem>
                <asp:ListItem Text="DDU"></asp:ListItem>
                <asp:ListItem Text="DDP"></asp:ListItem>
            </asp:DropDownList>
         </div>
         <div class="col-2"><br />
             Ship Date:<br />
            <asp:TextBox ID="txtShipDate" runat="server" type="date" CssClass="form-control-sm" Width="100%"></asp:TextBox>
         </div>
         <div class="col-sm-4"><br />Template: <br />
             <asp:FileUpload ID="ImportSB" runat="server" Width="100%" />
         </div>
        <div class="col-sm-2" >
            <br />
             <asp:LinkButton ID="btnUpload" runat="server" OnClick="btnUpload_Click" CssClass="btn bg-primary"  ForeColor="White">Upload</asp:LinkButton>     
        </div>
         </div>
    <div class="row">
        <div class="col-sm-12">    
            <telerik:RadGrid runat="server" ID="rgSouthBound" Skin="MetroTouch" AutoGenerateColumns="true"></telerik:RadGrid>
            <br />
            
         </div>
    </div>
 
      <div class="row" id="gridWO" visible="false">
        <div class="col-sm-12">
            <telerik:RadGrid ID="rgProductionOrder" ClientSettings-Scrolling-AllowScroll="true" Height="270px" runat="server" AutoGenerateColumns="false" ClientSettings-Scrolling-UseStaticHeaders="true" Skin="Metro">
                <MasterTableView>
                    <Columns>
                         <telerik:GridBoundColumn DataField="fs_partNumber" HeaderText="Part#" >
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fs_description" HeaderText="Description" >
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fs_scheduleHsCode" HeaderText="HS Code" >
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fs_coo" HeaderText="COO" >
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fi_qty" HeaderText="Qty" >
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fd_totalWeightKgs" HeaderText="Tot Weight Kgs" >
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fd_totalWeightLbs" HeaderText="Tot Weight Lbs" >
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fd_unitPrice" HeaderText="Unit Price" >
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fd_exitPrice" HeaderText="Exit Price" >
						</telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
        <br />
        <div class="col-sm-12">
            <asp:LinkButton ID="lnkInsertar" runat="server" OnClick="lnkInsertar_Click" CssClass="btn btn-success"  ForeColor="White" style="float:right;">Finish</asp:LinkButton>
        </div>
    </div>
     
       <script type="text/javascript">
        function openModal() {
            $('#modal').modal('show');
        }

    </script>
<div class="modal fade" id="modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
        <h5 class="modal-title">Production Order Repeat</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <p>This Production Order exist, do you want cancel previous one and take this?</p>
      </div>
      <div class="modal-footer">
        <asp:LinkButton ID="yes" runat="server" OnClick="yes_Click" CssClass="btn btn-primary"> Yes, Save this!</asp:LinkButton>
        <asp:LinkButton ID="no" runat="server" OnClick="no_Click" CssClass="btn btn-secondary" data-dismiss="modal">Don't Cancel anything</asp:LinkButton>
      </div>
    </div>
  </div>
</div>
</asp:Content>
