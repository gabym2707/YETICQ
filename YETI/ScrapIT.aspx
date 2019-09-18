<%@ Page Title="" Language="C#" MasterPageFile="~/Yeti.Master" AutoEventWireup="true" CodeBehind="ScrapIT.aspx.cs" Inherits="YETI.ScrapIT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-sm-12">
            <h2> New Scrap</h2>
        </div>
    </div>
        <div class="row">
        <div class="col-sm-3">
            <br />IMMEX Nombre:<br />
            <asp:TextBox ID="txtPedimento" Width="100%" runat="server" CssClass="form-control-sm"></asp:TextBox>
        </div>
             <div class="col-sm-2">
            <br />SKU #:<br />
            <asp:TextBox ID="txtSky" runat="server" CssClass="form-control-sm"></asp:TextBox>
        </div>
             <div class="col-sm-2">
            <br />Qty:<br />
            <asp:TextBox ID="txtQty" runat="server" CssClass="form-control-sm"></asp:TextBox>
        </div>
             <div class="col-sm-4">
            <br />Certificate of destruction :<br />
          <asp:FileUpload ID="certificado" runat="server" />
        </div>
              <div class="col-sm-1">
            <br /> <br />
            <asp:LinkButton ID="lnkAgregar" runat="server" Text="Save" CssClass="btn btn-primary btn-sm" OnClick="lnkAgregar_Click"></asp:LinkButton>
        </div>
    </div>
        <div class="row">
        <div class="col-sm-12">

        </div>
    </div>
       <script type="text/javascript">
        function openModalSuccess() {
            $('#modalSuccess').modal('show');
        }

    </script>
     <script type="text/javascript">
        function openModalError() {
            $('#modalError').modal('show');
        }

    </script>
   <div class="modal fade" id="modalSuccess" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Success</h5>
        
      </div>
      <div class="modal-body">
        <p>Your file has been added with success.</p>
      </div>
      
    </div>
  </div>
</div>

    <div class="modal fade" id="modalError" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Error</h5>
        
      </div>
      <div class="modal-body">
        <p>Please check all fields.</p>
      </div>
      
    </div>
  </div>
</div>
</asp:Content>
