<%@ Page Title="NorthBound" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="ScanPaint.aspx.cs" Inherits="YETI.ScanPaint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
 
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
