<%@ Page Title="Users" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="YETI.Users" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-sm-12"><h3>Users</h3></div>
    </div>
    <div class="row">
         <div class="col-sm-12">
    <button type="button" class="btn" style="background-color:#cfd6e5" data-toggle="modal" data-target="#addModal">
      Add User
    </button>
         </div>
    </div>
    <div class="row">
          <div class="col-sm-12">
              <br />
             <telerik:RadGrid runat="server" ID="rgMails" AutoGenerateColumns="false" Skin="Metro" GridLines="None"
                  OnItemDataBound="rgMails_ItemDataBound" MasterTableView-PagerStyle-AlwaysVisible="true" AllowPaging="true"
                 HeaderStyle-BackColor="#cfd6e5" BorderColor="#00263e" HeaderStyle-BorderColor="#00263e">
                  <ClientSettings>
					<Scrolling AllowScroll="True" UseStaticHeaders="True" />
				</ClientSettings>
                  <MasterTableView>
                      <Columns>
                          <telerik:GridBoundColumn DataField="ci_id" 
							FilterControlAltText="Filter ci_id column" HeaderText="Id" 
							SortExpression="ci_id" UniqueName="ci_id" 
							AllowFiltering="false" Visible="false">
						</telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="cs_nombre" 
							FilterControlAltText="Filter cs_nombre column" HeaderText="Name" 
							SortExpression="cs_nombre" UniqueName="cs_nombre" 
							AllowFiltering="false" >
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cs_correo" 
							FilterControlAltText="Filter cs_correo column" HeaderText="Email" 
							SortExpression="cs_correo" UniqueName="cs_correo" 
							AllowFiltering="false" >
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cb_active" 
							FilterControlAltText="Filter cb_active column" HeaderText="Active" 
							SortExpression="cb_active" UniqueName="cb_active" 
							AllowFiltering="false" >
						</telerik:GridBoundColumn>
                     <telerik:GridTemplateColumn UniqueName="Deactivate">
                         <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDeactivate" OnClick="btnDeactivate_Click" CssClass="btn btn-warning btn-sm" Text="Deactivate"
                                CommandArgument='<%# Eval("ci_id")+"*" %>'></asp:LinkButton>
                         </ItemTemplate>                         
                    </telerik:GridTemplateColumn>
                     <telerik:GridTemplateColumn UniqueName="Reactivate">
                         <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnReactivate" OnClick="btnReactivate_Click" CssClass="btn btn-success btn-sm" Text="Reactivate"
                                CommandArgument='<%# Eval("ci_id")+"*" %>'></asp:LinkButton>
                         </ItemTemplate>                         
                    </telerik:GridTemplateColumn>
                          <telerik:GridBoundColumn DataField="cb_southBound" 
							FilterControlAltText="Filter cb_southBound column" HeaderText="South Bound" 
							SortExpression="cb_southBound" UniqueName="cb_southBound" 
							AllowFiltering="false" >
						</telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="cb_northBount" 
							FilterControlAltText="Filter cb_northBount column" HeaderText="North Bound" 
							SortExpression="cb_northBount" UniqueName="cb_northBount" 
							AllowFiltering="false" >
						</telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="cb_workOrder" 
							FilterControlAltText="Filter cb_workOrder column" HeaderText="Work Order" 
							SortExpression="cb_workOrder" UniqueName="cb_workOrder" 
							AllowFiltering="false" >
						</telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="cb_ups" 
							FilterControlAltText="Filter cb_ups column" HeaderText="UPS" 
							SortExpression="cb_ups" UniqueName="cb_ups" 
							AllowFiltering="false" >
						</telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="cb_master" 
							FilterControlAltText="Filter cb_master column" HeaderText="Admin" 
							SortExpression="cb_master" UniqueName="cb_master" 
							AllowFiltering="false" >
						</telerik:GridBoundColumn>
                 </Columns>
                  </MasterTableView>
              </telerik:RadGrid>
           </div>
    </div>

    <div class="modal fade" id="addModal" tabindex="-1" role="dialog" aria-labelledby="addModal-label">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="addModal-label">Add User</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <div class="row">                        
                        <div class="col-md-6 col-lg-6 col-sm-12">
                            <label class="col-form-label"><b>Name:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtName"/>
                        </div>
                        <div class="col-md-6 col-lg-6 col-sm-12">
                            <label class="col-form-label"><b>Mail:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtMail"/>
                        </div>
                    </div>
                    <div class="row">  
                        <div class="col-md-6 col-lg-6 col-sm-12">                      
                           <asp:CheckBox ID="chkb_sb" runat="server" Text="South Bound" /><br />
                            <asp:CheckBox ID="chkb_nb" runat="server" Text="North Bound" /><br />
                            <asp:CheckBox ID="chkb_ms" runat="server" Text="Administrador" /><br />
                            <asp:CheckBox ID="chkb_wo" runat="server" Text="Work Order" /><br />
                            <asp:CheckBox ID="chkb_ups" runat="server" Text="UPS" /><br />
                           </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    <asp:LinkButton runat="server" ID="add" OnClick="add_Click" CssClass="btn btn-primary" Text="Add"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
