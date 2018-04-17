<%@ Page Title="" Language="C#" MasterPageFile="~/intelimundo.Master" AutoEventWireup="true" CodeBehind="registro_inicial.aspx.cs" Inherits="wa_intelimundo.registro_inicial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="section">
                <div class="container">
                    <div class="form-group">
                        <div class="row">
                            <br />
                            <div class="panel panel-default" id="pnl_sucursales" runat="server" visible="true">
                                <div class="panel-heading">
                                    <h3 class="text-center">Registro de Corporativo y Director</h3>
                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-6 text-center">
                                            <h3>Corporativo</h3>
                                        </div>
                                        <div class="col-md-6 text-center">
                                            <h3>Director</h3>
                                        </div>
                                        <br />
                                        <div class="col-md-3">
                                            <asp:DropDownList CssClass="form-control" ID="ddl_licencias" runat="server"></asp:DropDownList>
                                            <br />
                                            <asp:TextBox CssClass="form-control" ID="txt_nombre_sucursal" runat="server" placeholder="*Nombre de la sucursal"></asp:TextBox>
                                            <br />
                                            <asp:TextBox CssClass="form-control" ID="txt_telefono_sucursal" runat="server" placeholder="*Teléfono"></asp:TextBox>
                                            <ajaxToolkit:MaskedEditExtender ID="mee_telefono_sucursal" runat="server" TargetControlID="txt_telefono_sucursal" Mask="(52) 99.99.99.99.99.99 ext 99999" />
                                            <br />
                                            <asp:TextBox CssClass="form-control" ID="txt_email_sucursal" runat="server" placeholder="*e-mail"></asp:TextBox>
                                            <br />
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox CssClass="form-control" ID="txt_callenum_sucursal" runat="server" placeholder="*Calle y número"></asp:TextBox>
                                            <br />
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="txt_cp_sucursal" runat="server" placeholder="*Código Postal" MaxLength="5"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_cp_sucursal" Mask="99999" />
                                                <span class="input-group-btn">
                                                    <asp:Button CssClass="btn" ID="btn_cp_sucursal" runat="server" Text="validar" OnClick="btn_cp_sucursal_Click" />
                                                </span>
                                            </div>
                                            <br />
                                            <asp:DropDownList CssClass="form-control" ID="ddl_colonia_sucursal" runat="server" ToolTip="*Colonia"></asp:DropDownList>
                                            <br />
                                            <asp:TextBox CssClass="form-control" ID="txt_municipio_sucursal" runat="server" placeholder="*Municipio" Enabled="false"></asp:TextBox>
                                            <br />
                                            <asp:TextBox CssClass="form-control" ID="txt_estado_sucursal" runat="server" placeholder="*Estado" Enabled="false"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:DropDownList CssClass="form-control" ID="ddl_genero" runat="server"></asp:DropDownList>
                                            <br />
                                            <asp:TextBox CssClass="form-control" ID="txt_nombres" runat="server" placeholder="*Nombre(s)"></asp:TextBox>
                                            <br />
                                            <asp:TextBox CssClass="form-control" ID="txt_apaterno" runat="server" placeholder="*Apellido Paterno"></asp:TextBox>
                                            <br />
                                            <asp:TextBox CssClass="form-control" ID="txt_amaterno" runat="server" placeholder="*Apellido Materno"></asp:TextBox>
                                            <br />
                                        </div>
                                        <div class="col-md-3">
                                            <asp:TextBox CssClass="form-control" ID="txt_cumple" runat="server" placeholder="Fecha de Nacimiento"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="ce_cumple" runat="server" BehaviorID="txt_cumple" TargetControlID="txt_cumple" Format="yyyy/MM/dd" />
                                            <br />
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="txt_usuario_usuario" runat="server" placeholder="*Usuario"></asp:TextBox>
                                                <span class="input-group-btn">
                                                    <asp:Button CssClass="btn" ID="btn_genera_usuario" runat="server" Text="+" OnClick="btn_genera_usuario_Click" />
                                                </span>
                                            </div>
                                            <br />
                                            <asp:TextBox CssClass="form-control" ID="txt_clave" runat="server" placeholder="*Contraseña" TextMode="Password"></asp:TextBox>
                                            <br />
                                        </div>
                                        <div class="col-md-12 text-right">
                                            <asp:Button CssClass="btn" ID="btn_salir" runat="server" Text="Salir" OnClick="btn_salir_Click" />
                                            <asp:Button CssClass="btn" ID="btn_guardar" runat="server" Text="Guardar" OnClick="btn_guardar_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="panel-footer"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true" onclick="window.location.href='/ctrl_acceso.aspx'">x</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button class="btn" data-dismiss="modal" aria-hidden="true" onclick="window.location.href='/acceso.aspx'">Ok </button>
                        </div>
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>