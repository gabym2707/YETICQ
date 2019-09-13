<%@ Page Title="Exporters" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="MExports.aspx.cs" Inherits="YETI.MExports" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12"><h3>Exporters</h3></div>
    </div>
    <div class="row">
         <div class="col-sm-12">
    <button type="button" class="btn" style="background-color:#cfd6e5" data-toggle="modal" data-target="#addModal">
  Add Exporter
</button>
         </div>
    </div>
    <div class="row">
          <div class="col-sm-12">
              <br />
              <telerik:RadScriptManager ID="smCloud" runat="server"></telerik:RadScriptManager>
			    <telerik:RadGrid runat="server" ID="rgNombres" AllowPaging="True" AllowSorting="True" 
				CellSpacing="0" Culture="es-ES" GridLines="None" Skin="Metro"
				PagerStyle-AlwaysVisible="true" HeaderStyle-BackColor="#cfd6e5" BorderColor="#00263e" HeaderStyle-BorderColor="#00263e">							
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
                        <telerik:GridBoundColumn DataField="cs_address" 
							FilterControlAltText="Filter cs_address column" HeaderText="Address" 
							SortExpression="cs_address" UniqueName="cs_address" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cs_locacion" 
							FilterControlAltText="Filter cs_locacion column" HeaderText="Location" 
							SortExpression="cs_locacion" UniqueName="cs_locacion" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cs_phone" 
							FilterControlAltText="Filter cs_phone column" HeaderText="Phone" 
							SortExpression="cs_phone" UniqueName="cs_phone" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cs_ein" 
							FilterControlAltText="Filter cs_ein column" HeaderText="EIN" 
							SortExpression="cs_ein" UniqueName="cs_ein" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
						<%--<telerik:GridButtonColumn HeaderStyle-HorizontalAlign="Center" ButtonType="ImageButton" ImageUrl="~/img/ic_view.png" 
							CommandName="Seguimiento" Text="Seguimiento" UniqueName="Seguimiento"></telerik:GridButtonColumn>--%>
					</Columns>				
				</MasterTableView>
				<FilterMenu EnableImageSprites="False"></FilterMenu>
			</telerik:RadGrid>

             <%--<asp:GridView runat="server" ID="gvNombres" AutoGenerateColumns="false" CssClass="table-sm table table-responsive" HeaderStyle-BackColor="#cfd6e5" BorderColor="#00263e" HeaderStyle-BorderColor="#00263e" GridLines="None">
                 <Columns>
                     <asp:TemplateField HeaderText="Exporter Name">
                         <ItemTemplate>
                             <%# Eval("cs_nombre") %>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
             </asp:GridView>--%>
           </div>
    </div>

    <div class="modal fade" id="addModal" tabindex="-1" role="dialog" aria-labelledby="addModal-label">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="addModal-label">Add Exporter</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6 col-lg-6 col-sm-12">
                            <label class="col-form-label"><b>Exporter Name:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtExporter"/>
                        </div>
                        <div class="col-md-6 col-lg-6 col-sm-12">
                            <label class="col-form-label"><b>Address:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtAddress"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 col-lg-4 col-sm-12">
                            <label class="col-form-label"><b>Location:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtLocation"/>
                        </div>
                        <div class="col-md-4 col-lg-4 col-sm-12">
                            <label class="col-form-label"><b>Phone:</b></label>
							<asp:TextBox runat="server" CssClass="form-control" ID="txtPhone"/>
                        </div>
                        <div class="col-md-4 col-lg-4 col-sm-12">
                            <label class="col-form-label"><b>EIN:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtEin"/>
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
