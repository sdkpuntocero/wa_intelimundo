<%@ Page Title="" Language="C#" MasterPageFile="~/intelimundo.Master" AutoEventWireup="true" CodeBehind="panel_alumno.aspx.cs" Inherits="wa_intelimundo.panel_alumno" %>
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
                                            <!--/.nav-collapse -->
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-10">
                                    --<asp:UpdatePanel ID="up_usuariof" runat="server">
                                        <ContentTemplate>
                                            <div class="panel panel-default" id="pnl_fusuario" runat="server" visible="true">
                                                <div class="panel-heading">
                                                    <h3>Datos de Director</h3>
                                                </div>
                                                <div class="panel-body">
                                                    <div class="row">
                                                        <div class="col-md-12 text-right">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_editar_fusuario" runat="server" >
                                                                <i class="fas fa-edit" id="i_editausuariof" runat="server"></i>
                                                            </asp:LinkButton>
                                                        </div>
                                                        <br />
                                                        <div class="col-md-2 text-center">
                                                            <i class="fas fa-5x fa-barcode"></i>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <asp:DropDownList CssClass="form-control" ID="ddl_genero_fusuario" runat="server"></asp:DropDownList>
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="txt_nombres_fusuario" runat="server" placeholder="*Nombre(s)"></asp:TextBox>
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="txt_apaterno_fusuario" runat="server" placeholder="*Apellido Paterno"></asp:TextBox>
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="txt_amaterno_fusuario" runat="server" placeholder="*Apellido Materno"></asp:TextBox>
                                                            <br />
                                                        </div>
                                                        <div class="col-md-5">
                                                            <asp:TextBox CssClass="form-control" ID="txt_cumple_fusuario" runat="server" placeholder="Fecha de Nacimiento"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="ce_cumple_dfusuario" runat="server" BehaviorID="txt_cumple_fusuario" TargetControlID="txt_cumple_fusuario" Format="yyyy/MM/dd" />
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="txt_usuario_fusuario" runat="server" placeholder="*Usuario"></asp:TextBox>
                                                            <br />
                                                            <asp:TextBox CssClass="form-control" ID="txt_clave_fusuario" runat="server" placeholder="*Contraseña" TextMode="Password"></asp:TextBox>
                                                            <br />
                                                            <br />
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12 text-right">
                                                            <asp:Button CssClass="btn" ID="btn_guarda_fusuario" runat="server" Text="Guardar" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-footer"></div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel> 
                            </div>
                        </div>
                        <div class="panel-footer">
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button class="btn" data-dismiss="modal" aria-hidden="true">Ok</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
