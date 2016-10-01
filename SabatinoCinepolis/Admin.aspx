<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="Server">
    <div class="row">
        <div class="col-xs-12" style="overflow: scroll; height:400px;">
            <asp:GridView CssClass="table table-responsive table-hover" runat="server" ID="gvPeliculas" AutoGenerateColumns="False" ShowFooter="True" OnRowCancelingEdit="gvPeliculas_RowCancelingEdit" OnRowDeleting="gvPeliculas_RowDeleting" OnRowEditing="gvPeliculas_RowEditing" OnRowUpdating="gvPeliculas_RowUpdating" DataKeyNames="id, generoId, clasificacionId, anio, fotoMini, fotoPortada" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvPeliculas_PageIndexChanging" PageSize="10" OnSorting="gvPeliculas_Sorting">
                <Columns>
                    <asp:TemplateField HeaderText="[Nombre]" SortExpression="nombre">
                        <EditItemTemplate>
                            <asp:TextBox ID="EITtxtNombre" CssClass="form-control" runat="server" Text='<%# Bind("nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" CssClass="form-control" placeholder="Nombre" ID="FTtxtNombre" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Sinopsis]">
                        <EditItemTemplate>
                            <asp:TextBox ID="EITtxtSinopsis" CssClass="form-control" runat="server" Text='<%# Bind("sinopsis") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="ITlblSinopsis" runat="server" Text='<%# Bind("sinopsis") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="FTtxtSinopsis" placeholder="Sinopsis" CssClass="form-control" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Genero]">
                        <EditItemTemplate>
                            <asp:DropDownList ID="EITddlGenero" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="[Genero]" Value="0" />
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Genero.nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList Width="120" ID="FTddlGenero" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="[Genero]" Value="0" />
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Clasificación]">
                        <EditItemTemplate>
                            <asp:DropDownList ID="EITddlClasi" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="[Clasificación]" Value="0" />
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Clasificacion.nombre") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList Width="120" ID="FTddlClasi" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="[Clasificación]" Value="0" />
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Foto Mini]">
                        <EditItemTemplate>
                            <asp:FileUpload ID="EITfuFotoMini" runat="server" CssClass="form-control"></asp:FileUpload>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Label5" Width="75" Height="80" runat="server" ImageUrl='<%# Bind("fotoMini") %>'></asp:Image>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:FileUpload Width="150" ID="FTfuFotoMini" runat="server" CssClass="form-control"></asp:FileUpload>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Foto Port]">
                        <EditItemTemplate>
                            <asp:FileUpload ID="EITfuFotoPort" runat="server" CssClass="form-control"></asp:FileUpload>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Label6" Width="150" runat="server" ImageUrl='<%# Bind("fotoPortada") %>'></asp:Image>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:FileUpload ID="FTfuFotoPort" Width="150" runat="server" CssClass="form-control"></asp:FileUpload>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Año]">
                        <EditItemTemplate>
                            <asp:DropDownList ID="EITddlAnio" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="[año]" Value="0" />
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("anio") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:DropDownList ID="FTddlAnio" Width="80" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="[año]" Value="0" />
                            </asp:DropDownList>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Fecha]">
                        <EditItemTemplate>
                            <asp:TextBox ID="EITtxtFecha" CssClass="form-control" runat="server" Text='<%# Bind("fechaAlta", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("fechaAlta", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="FTtxtFecha" runat="server" CssClass="form-control"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Estatus]">
                        <EditItemTemplate>
                            <asp:CheckBox ID="EITchkEstatus" runat="server" Checked='<%# Bind("estatus") %>'></asp:CheckBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="Label9" runat="server" Enabled="false" Checked='<%# Bind("estatus") %>'></asp:CheckBox>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:CheckBox ID="FTchkEstatus" runat="server" Checked="true"></asp:CheckBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Video]">
                        <EditItemTemplate>
                            <asp:TextBox ID="EITtxtVideo" CssClass="form-control" runat="server" Text='<%# Bind("video") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <iframe width="180" height="90" runat="server" id="ifVideo" src='<%# Bind("video") %>' frameborder="0" allowfullscreen></iframe>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="FTtxtVideo" runat="server" placeholder="Video" CssClass="form-control"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="[Productor]">
                        <EditItemTemplate>
                            <asp:TextBox ID="EITtxtProductor" runat="server" CssClass="form-control" Text='<%# Bind("productor") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("productor") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" placeholder="Productor" ID="FTtxtProductor" CssClass="form-control" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False" HeaderText="Edición">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkActualizar" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="lnkCancelar" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditar" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton Text="Agregar" ID="FTlnkAgregar" runat="server" OnClick="FTlnkAgregar_Click" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False" HeaderText="Borrar">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkBorrar" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick='<%# string.Format ("return confirm(\"Se eliminará la pelicula {0}, está seguro?\");",Eval("nombre")) %>' Text="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

