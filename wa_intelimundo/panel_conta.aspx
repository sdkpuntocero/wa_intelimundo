<%@ Page Title="" Language="C#" MasterPageFile="~/intelimundo.Master" AutoEventWireup="true" CodeBehind="panel_conta.aspx.cs" Inherits="wa_intelimundo.panel_conta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <div class="container">
                <div class="form-group">
                    <div class="panel panel-default" id="div_pnl" runat="server" visible="true">
                        <div class="panel-heading">
                            <h1 class="text-center"> Contacto alumno</h1>
                            <p class="text-right">
                                <asp:Label ID="lbl_bienvenida" runat="server" Text="Bienvenid@: "></asp:Label>
                                <asp:LinkButton ID="lkb_edita_usuario" runat="server" >
                                    <asp:Label CssClass="buttonClass" ID="lbl_fuser" runat="server" Text=""></asp:Label>
                                    <i class="fas  fa-barcode" id="i_editausuario" runat="server"></i>
                                </asp:LinkButton>
                                <br />
                                <asp:Label ID="lbl_tipousuario" runat="server" Text="Perfil: "></asp:Label>
                                <asp:Label ID="lbl_ftipousuario" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="lbl_centro" runat="server" Text="Centro: "></asp:Label>
                                <asp:LinkButton CssClass="buttonClass" ID="lkb_edita_centro" runat="server" >
                                    <asp:Label CssClass="buttonClass" ID="lbl_fcentro" runat="server" Text=""></asp:Label>
                                    <i class="fas  fa-building" id="i_editacentro" runat="server"></i>
                                </asp:LinkButton>
                            </p>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-sm-2">
                                    <div class="sidebar-nav">
                                        <div class="navbar navbar-default" role="navigation">
                                            <div class="navbar-header">
                                                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-navbar-collapse"><span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                                                <span class="visible-xs navbar-brand">Menú</span>
                                            </div>
                                            <div class="navbar-collapse collapse sidebar-navbar-collapse">
                                                <ul class="nav navbar-nav text-left">
                                                    <li>
                                                        <div id="div_resumen" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_resumen" runat="server">
                                                                <i class="fas  fa-tachometer-alt"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_resumen" runat="server" Text="Resumen"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                        <asp:Image ID="Image1" runat="server" />
                                                    </li>
                                                    <li>
                                                        <div id="div_ventas" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_ventas" runat="server">
                                                                <i class="fas fa-phone-square"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_ventas" runat="server" Text="Contacto"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="div_gastos" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_gastos" runat="server">
                                                                <i class="fas fa-male"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_gastos" runat="server" Text="Padre/Tutor"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="div_recepcion" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_recepcion" runat="server">
                                                                <i class="fas fa-gavel"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_recepcion" runat="server" Text="Fiscal"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="div_ordencompra" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_ordencompra" runat="server">
                                                                <i class="fas fa-medkit"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_ordencompra" runat="server" Text="Medicos"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="div_inventario" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_inventario" runat="server">
                                                                <i class="fas fa-book"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_inventario" runat="server" Text="Escolares"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="div_sucursales" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_sucursales" runat="server">
                                                                <i class="fas fa-money-bill-alt"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_sucursales" runat="server" Text="Bancarios"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <br />
                                                    <li>
                                                        <div id="div_salir" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_salir" runat="server">
                                                                <i class="fas  fa-times-circle" id="i_salir" runat="server"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_salir" runat="server" Text="Salir"></asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                </div>
                            <div class="col-md-4">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
