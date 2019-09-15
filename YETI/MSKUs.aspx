<%@ Page Title="MSKUs" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="MSKUs.aspx.cs" Inherits="YETI.MSKUs" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12"><h3>SKU's</h3></div>
    </div>
    <div class="row">
         <div class="col-sm-12">
    <button type="button" class="btn" style="background-color:#cfd6e5" data-toggle="modal" data-target="#addModal">
  Add SKU
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
						<telerik:GridBoundColumn DataField="cs_sku" 
							FilterControlAltText="Filter cs_sku column" HeaderText="Material SKU #" 
							SortExpression="cs_sku" UniqueName="cs_sku" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cs_plant" 
							FilterControlAltText="Filter cs_plant column" HeaderText="Plant" 
							SortExpression="cs_plant" UniqueName="cs_plant" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cs_description" 
							FilterControlAltText="Filter cs_description column" HeaderText="Description" 
							SortExpression="cs_description" UniqueName="cs_description" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cs_comodityCode" 
							FilterControlAltText="Filter cs_comodityCode column" HeaderText="Commodity Code" 
							SortExpression="cs_comodityCode" UniqueName="cs_comodityCode" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cs_cost" DataType="System.Double" DataFormatString="{0:C}"
							FilterControlAltText="Filter cs_cost column" HeaderText="1200 Cost" 
							SortExpression="cs_cost" UniqueName="cs_cost" 
							AllowFiltering="false">
						</telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="cs_materialGroup" 
							FilterControlAltText="Filter cs_materialGroup column" HeaderText="Material Group" 
							SortExpression="cs_materialGroup" UniqueName="cs_materialGroup" 
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
                            <label class="col-form-label"><b>SKU:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtSKU"/>
                        </div>
                        <div class="col-md-6 col-lg-6 col-sm-12">
                            <label class="col-form-label"><b>Plant:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtPlant"/>
                        </div>
                    </div>
                    <div class="row">                        
                        <div class="col-md-6 col-lg-6 col-sm-12">
                            <label class="col-form-label"><b>Description:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtDescription"/>
                        </div>
                        <div class="col-md-6 col-lg-6 col-sm-12">
                            <label class="col-form-label"><b>Comodity Code:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtCode"/>
                        </div>
                    </div>
                    <div class="row">                        
                        <div class="col-md-6 col-lg-6 col-sm-12">
                            <label class="col-form-label"><b>Cost:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtCost"/>
                        </div>
                        <div class="col-md-6 col-lg-6 col-sm-12">
                            <label class="col-form-label"><b>Material Group:</b></label>
							<asp:TextBox runat="server" CssClass="form-control"  ID="txtGroup"/>
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
