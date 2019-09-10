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
             Export of records:<br />
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control-sm"></asp:DropDownList>
         </div>
           <div class="col-6">
             Import of records:<br />
            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control-sm"></asp:DropDownList>
         </div>
          <div class="col-3">
            
         </div>
         <div class="col-sm-5"><br />
             <asp:FileUpload ID="ImportSB" runat="server" />
         </div>
         <div class="col-sm-2"><br />
             <asp:LinkButton ID="btnUpload" runat="server" OnClick="btnUpload_Click">Upload</asp:LinkButton>         

         </div>
         </div>
 
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
