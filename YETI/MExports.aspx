<%@ Page Title="" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="MExports.aspx.cs" Inherits="YETI.MExports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12"><h3>Exports</h3></div>
    </div>
    <div class="row">
         <div class="col-sm-12">
    <button type="button" class="btn" style="background-color:#cfd6e5" data-toggle="modal" data-target="#exampleModalCenter">
  Launch demo modal
</button>
         </div>
    </div>
    <div class="row">
          <div class="col-sm-12">
              <br />
             <asp:GridView runat="server" ID="gvNombres" AutoGenerateColumns="false" CssClass="table-sm table table-responsive" HeaderStyle-BackColor="#cfd6e5" BorderColor="#00263e" HeaderStyle-BorderColor="#00263e" GridLines="None">
                 <Columns>
                     <asp:TemplateField HeaderText="Export Name">
                         <ItemTemplate>
                             <%# Eval("cs_nombre") %>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
             </asp:GridView>
           </div>
    </div>
</asp:Content>
