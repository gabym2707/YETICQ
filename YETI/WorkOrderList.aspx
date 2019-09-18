<%@ Page Title="" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="WorkOrderList.aspx.cs" Inherits="YETI.WorkOrderList" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="Sd" runat="server"></asp:ScriptManager>
     <div class="row"> 
        <div class="col-sm-12">  
            <h2>Work Orders</h2>  
            </div>
         </div>
      <div class="row">
        
        <div class="col-sm-12">    
            <telerik:RadGrid runat="server" ID="rgSouthBoundList" Skin="Metro" AutoGenerateColumns="false" OnItemCommand="rgSouthBoundList_ItemCommand" AllowPaging="true" PagerStyle-Mode="NextPrevAndNumeric" OnPageIndexChanged="rgSouthBoundList_PageIndexChanged" PagerStyle-AlwaysVisible="true" pages>
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="Production Order">
                            <ItemTemplate><%#Eval("fs_workOrder") %></ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Date">
                            <ItemTemplate><%#Eval("fdt_date","{0: dd/MMM/yyyy}") %></ItemTemplate>
                        </telerik:GridTemplateColumn>
                        
                         <telerik:GridTemplateColumn HeaderText="Tracking">
                            <ItemTemplate><asp:Button ID="btnReject" runat="server" CommandName="Download" Text="Download" CssClass="btn btn-primary btn-sm"  CommandArgument='<%# Eval("fs_workOrder") %>'/>
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
