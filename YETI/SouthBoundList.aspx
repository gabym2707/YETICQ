<%@ Page Title="" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="SouthBoundList.aspx.cs" Inherits="YETI.SouthBoundList" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="Sd" runat="server"></asp:ScriptManager>
    
      <div class="row">
        
        <div class="col-sm-12">    
            <telerik:RadGrid runat="server" ID="rgSouthBoundList" Skin="MetroTouch" AutoGenerateColumns="false" OnItemCommand="rgSouthBoundList_ItemCommand">
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="Production Order">
                            <ItemTemplate><%#Eval("fs_productionOrder") %></ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Date">
                            <ItemTemplate><%#Eval("fd_date","{0: dd/MMM/yyyy}") %></ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Invoice">
                            <ItemTemplate><%#Eval("fs_invoice") %></ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Reference">
                            <ItemTemplate><%#Eval("fs_reference") %></ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Trucker">
                            <ItemTemplate><%#Eval("fs_trucker") %></ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Tracking">
                            <ItemTemplate><%#Eval("fs_tracking") %></ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <%--<telerik:GridButtonColumn UniqueName="Download" ButtonType="LinkButton" CommandArgument='<%#Eval("fs_productionOrder") %>' Text="Download" CommandName="Download">
                        </telerik:GridButtonColumn>--%>
                         <telerik:GridTemplateColumn HeaderText="Tracking">
                            <ItemTemplate><asp:Button ID="btnReject" runat="server" CommandName="Download"  CommandArgument='<%# Eval("fs_productionOrder") %>'/>
       </ItemTemplate>
                        </telerik:GridTemplateColumn>
                            
                            
                        
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            <br /> 
         </div>
    </div>
      <CR:CrystalReportViewer ID="crystalReportViewer1" runat="server" AutoDataBind="true" />
</asp:Content>
