<%@ Page Title="" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="ProductionOrder.aspx.cs" Inherits="YETI.WorkOrderImport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
         <div class="col-6">
             Export of records:<br />
            <asp:DropDownList ID="ddlsexport" runat="server" CssClass="form-control-sm"></asp:DropDownList>
         </div>
           <div class="col-6">
             Import of records:<br />
            <asp:DropDownList ID="ddlsimport" runat="server" CssClass="form-control-sm"></asp:DropDownList>
         </div>
         </div>
    <div class="row">
         <div class="col-6">
             Shipper:<br />
            <asp:DropDownList ID="ddlsShippers" runat="server" CssClass="form-control-sm"></asp:DropDownList>
         </div>
           <div class="col-6">
             Ship To:<br />
            <asp:DropDownList ID="ddlsShipTo" runat="server" CssClass="form-control-sm"></asp:DropDownList>
         </div>
        </div>
    <div class="row">
          <div class="col-2">
              Currency:<br />
            <asp:DropDownList ID="ddlsCurrency" runat="server" CssClass="form-control-sm"></asp:DropDownList>
         </div>
        
         <div class="col-sm-4">Template: <br />
             <asp:FileUpload ID="ImportSB" runat="server" />
         </div>
         <div class="col-sm-4">Commercial Invoice: <br />
             <asp:FileUpload ID="FileUpload1" runat="server" />
         </div>
         
         </div>
    <div class="row">
        <div class="col-sm-12"><br />
             <asp:LinkButton ID="btnUpload" runat="server" OnClick="btnUpload_Click" CssClass="btn bg-primary"  ForeColor="White">Upload Information</asp:LinkButton>         

         </div>
    </div>
 
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
