<%@ Page Title="NorthBound Mails" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="NorthBoundMails.aspx.cs" Inherits="YETI.NorthBoundMails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12"><h3>NorthBound Mails</h3></div>
    </div>
    <div class="row">
         <div class="col-sm-12">
    <button type="button" class="btn" style="background-color:#cfd6e5" data-toggle="modal" data-target="#addModal">
      Add Mail
    </button>
         </div>
    </div>
    <div class="row">
          <div class="col-sm-12">
              <br />
             <asp:GridView runat="server" ID="gvNombres" AutoGenerateColumns="false" CssClass="table-sm table table-responsive" 
                 HeaderStyle-BackColor="#cfd6e5" BorderColor="#00263e" HeaderStyle-BorderColor="#00263e" GridLines="None"
                 >
                 <Columns>
                     <asp:TemplateField Visible="false">
                         <ItemTemplate>
                             <%# Eval("ci_id") %>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Name">
                         <ItemTemplate>
                             <%# Eval("cs_nombre") %>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Mail">
                         <ItemTemplate>
                             <%# Eval("cs_correo") %>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Active">
                         <ItemTemplate>
                             <%# Eval("cb_active") %>
                         </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField>
                         <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDeactivate" OnClick="btnDeactivate_Click" CssClass="btn btn-warning btn-sm" Text="Deactivate"
                                CommandArgument='<%# Eval("ci_id")+"*" %>'></asp:LinkButton>
                         </ItemTemplate>                         
                    </asp:TemplateField>
                     <asp:TemplateField>
                         <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnReactivate" OnClick="btnReactivate_Click" CssClass="btn btn-success btn-sm" Text="Reactivate"
                                CommandArgument='<%# Eval("ci_id")+"*" %>'></asp:LinkButton>
                         </ItemTemplate>                         
                    </asp:TemplateField>
                 </Columns>
                 
                 
             </asp:GridView>
           </div>
    </div>

    <div class="modal fade" id="addModal" tabindex="-1" role="dialog" aria-labelledby="addModal-label">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="addModal-label">Add Mail</h4>
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
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    <asp:LinkButton runat="server" ID="add" OnClick="add_Click" CssClass="btn btn-primary" Text="Add"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
