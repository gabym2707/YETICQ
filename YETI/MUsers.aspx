<%@ Page Title="" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="MUsers.aspx.cs" Inherits="YETI.MUsers" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
              <telerik:RadScriptManager ID="smCloud" runat="server"></telerik:RadScriptManager>
			    <telerik:RadGrid runat="server" ID="rgSKUs" AllowPaging="True" AllowSorting="True" 
				CellSpacing="0" Culture="es-ES" GridLines="None" Skin="Metro" 
				PagerStyle-AlwaysVisible="true" 
                    HeaderStyle-BackColor="#cfd6e5" BorderColor="#00263e" HeaderStyle-BorderColor="#00263e">							
				<ClientSettings>
					<Scrolling AllowScroll="True" UseStaticHeaders="True" />
				</ClientSettings>
				<MasterTableView AutoGenerateColumns="False">
					<Columns>
						<telerik:GridBoundColumn HeaderStyle-HorizontalAlign="Center" DataField="ci_id" DataType="System.Int32" 
							FilterControlAltText="Filter ci_id column" HeaderText="ci_id" 
							Visible="false" ReadOnly="True" SortExpression="ci_id"
							UniqueName="ci_id">										
						</telerik:GridBoundColumn>
						<telerik:GridBoundColumn DataField="cs_nombre" 
							FilterControlAltText="Filter cs_nombre column" HeaderText="Name" 
							SortExpression="cs_nombre" UniqueName="cs_nombre" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cs_correo" 
							FilterControlAltText="Filter cs_correo column" HeaderText="Email" 
							SortExpression="cs_correo" UniqueName="cs_correo" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cb_southBound" DataType="System.Boolean"
							FilterControlAltText="Filter cb_southBound column" HeaderText="SouthBound Perm." 
							SortExpression="cb_southBound" UniqueName="cb_southBound" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cb_northBound" DataType="System.Boolean"
							FilterControlAltText="Filter cb_northBound column" HeaderText="NorthBound Perm." 
							SortExpression="cb_northBound" UniqueName="cb_northBound" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cb_masters" DataType="System.Boolean"
							FilterControlAltText="Filter cb_masters column" HeaderText="Masters Perm." 
							SortExpression="cb_masters" UniqueName="cb_masters" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cb_workOrder" DataType="System.Boolean"
							FilterControlAltText="Filter cb_workOrder column" HeaderText="WorkOrder Perm." 
							SortExpression="cb_workOrder" UniqueName="cb_workOrder" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cb_ups" DataType="System.Boolean"
							FilterControlAltText="Filter cb_ups column" HeaderText="UPS Perm." 
							SortExpression="cb_ups" UniqueName="cb_ups" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>                        
						<%--<telerik:GridButtonColumn HeaderStyle-HorizontalAlign="Center" ButtonType="ImageButton" ImageUrl="~/img/ic_view.png" 
							CommandName="Seguimiento" Text="Seguimiento" UniqueName="Seguimiento"></telerik:GridButtonColumn>--%>
					</Columns>				
				</MasterTableView>
				<FilterMenu EnableImageSprites="False"></FilterMenu>
			</telerik:RadGrid>
            
           </div>
    </div>
    <div class="modal fade" id="addModal" tabindex="-1" role="dialog" aria-labelledby="addModal-label">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="addModal-label">Add SKU #</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6 col-lg-6 col-sm-12">
                            <label class="col-form-label"><b>Name:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtName"/>
                        </div>
                        <div class="col-md-6 col-lg-6 col-sm-12">
                            <label class="col-form-label"><b>Email:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtMail"/>
                        </div>
                    </div>
                    <br />
                    <table class="table table-bordered table-responsive-lg table-sm" >
							<thead >
								<tr class="text-light" style="background-color:#424242">
									<th>Module</th>
									<th class="text-center">Allow</th>                                        
								</tr>
							</thead>                                
							<tbody>
								<tr>
									<td>SouthBound</td>
									<td class="text-center"><asp:CheckBox runat="server" ID="chkSouth" CssClass="form-check-input"/></td>
								</tr>
                                <tr>
									<td>NorthBound</td>
									<td class="text-center"><asp:CheckBox runat="server" ID="chkNorth" CssClass="form-check-input"/></td>
								</tr>
                                <tr>
									<td>Masters</td>
									<td class="text-center"><asp:CheckBox runat="server" ID="chkMasters" CssClass="form-check-input"/></td>
								</tr>
                                <tr>
									<td>Work Order</td>
									<td class="text-center"><asp:CheckBox runat="server" ID="chkWork" CssClass="form-check-input"/></td>
								</tr>
                                <tr>
									<td>UPS</td>
									<td class="text-center"><asp:CheckBox runat="server" ID="chkUps" CssClass="form-check-input"/></td>
								</tr>
							</tbody>
						</table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    <asp:LinkButton runat="server" ID="add" OnClick="add_Click" CssClass="btn btn-primary" Text="Add"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
