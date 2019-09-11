<%@ Page Title="NorthBound" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="ScanPaint.aspx.cs" Inherits="YETI.ScanPaint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">		
		function openModalMensajes() {
			$('#messageModal').modal('show');
		};		
	</script>
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
    <div class="modal fade" id="messageModal" tabindex="-1" role="dialog" aria-labelledby="messageModal-label">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="messageModal-label">Upload Status</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <p>The ScanPaint NorthBound Document Was Successfully Uploaded</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
