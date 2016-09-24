<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Altas.aspx.cs" Inherits="Altas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .form-control {
            margin: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="row">
        <div class="col-xs-12">
            <asp:Image ImageUrl="~/content/img/sinImagen.png" ID="imgFotoPort" runat="server" Style="width: 800px; margin: auto;" CssClass="img-responsive img-rounded" /><br />
            <asp:FileUpload runat="server" Style="width: 800px; margin: auto;" ID="fuFotoPort" CssClass="form-control" OnLoad="fuFotoPort_Load" />
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-xs-3">
            <asp:Image ImageUrl="~/content/img/sinImagen-mini.jpg" ID="imgFotoMini" runat="server" Style="margin: auto;" CssClass="img-responsive img-rounded" Width="100px" />
            <asp:FileUpload runat="server" ID="fuFotoMini" CssClass="form-control" />
        </div>
        <div class="col-xs-9">
            <div class="row">
                <div class="col-xs-4">
                    <asp:TextBox runat="server" ID="txtNomb" class="form-control" placeholder="Nombre" />
                </div>
                <div class="col-xs-4">
                    <asp:TextBox runat="server" ID="txtProd" class="form-control" placeholder="Productor" />
                </div>
                <div class="col-xs-4">
                    <asp:CheckBox Text="&nbsp;&nbsp; Estatus" ID="chkEsta" CssClass="form-control" runat="server" />
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList runat="server" ID="ddlCLas" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="Clasificación" />
                    </asp:DropDownList>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList runat="server" ID="ddlGene" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="Género" />
                    </asp:DropDownList>
                </div>
                <div class="col-xs-4">
                    <asp:DropDownList runat="server" ID="ddlAnio" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="Año" Value="0" />
                    </asp:DropDownList>
                </div>
                <div class="col-xs-12">
                    <asp:TextBox runat="server" ID="txtSino" CssClass="form-control" placeholder="Sinopsis" Rows="4" TextMode="MultiLine" />
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-xs-4">
            <asp:TextBox runat="server" placeholder="URL del vídeo" ID="txtVide" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtVide_TextChanged" />
        </div>
        <div class="col-xs-4">
            <asp:Button Text="Actualizar" Visible="false" ID="btnActualizar" CssClass="btn btn-warning" runat="server" OnClick="btnActualizar_Click" />
        </div>
        <div class="col-xs-4">
            <asp:Button Text="Agregar" Visible="false" ID="btnAgregar" CssClass="btn btn-success" runat="server" OnClick="btnAgregar_Click" />
        </div>

        <div class="col-xs-12">
            <iframe src="https://www.youtube.com/embed/m0DMQk94j4Q" width="800" height="600" frameborder="0" allowfullscreen style="width: 100%;" runat="server" id="ifVideo"></iframe>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfId" />
    <asp:HiddenField runat="server" ID="hfMini" />
    <asp:HiddenField runat="server" ID="hfPort" />

</asp:Content>

