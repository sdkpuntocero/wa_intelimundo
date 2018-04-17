<%@ Page Title="" Language="C#" MasterPageFile="~/intelimundo.Master" AutoEventWireup="true" CodeBehind="acceso.aspx.cs" Inherits="wa_intelimundo.acceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="section">
        <div class="container">
            <div class="col-md-12 text-center">
                <!-- Login Form -->
                <div class="nb-login">
                    <asp:Image CssClass="center-block img-responsive" ID="Image1" runat="server" ImageUrl="~/img/148705-essential-collection/png/locked-6.png" Width="128" Height="128" />
                    <br />
                    <h3 class="scenter">Control de Acceso</h3>
                    <div class="form-group">
                        <asp:DropDownList CssClass="form-control" ID="ddl_centro" runat="server" Visible="false"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txt_usuario" runat="server" TabIndex="1" placeholder="*Capturar Usuario"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox CssClass="form-control" ID="txt_clave" runat="server" TabIndex="3" placeholder="*Capturar Contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="checkbox">
                        <asp:LinkButton CssClass="text-left" ID="lkb_registro" runat="server" Visible="false" Text="Registrar" OnClick="lkb_registro_Click"></asp:LinkButton>
                    </div>
                    <asp:Button CssClass="btn btn-block" ID="cmd_acceso" runat="server" Text="Entrar" TabIndex="4" OnClick="cmd_acceso_Click" />
                    <%-- <div class="center or">OR</div>
                    <h3 class="center">Sign In Using</h3>
                    <div class="social">
                        <a href="#" class="facebook"><i class="fa fa-facebook"></i>&nbsp; Login with Facebook</a>
                        <a href="#" class="twitter"><i class="fa fa-twitter"></i>&nbsp; Login with Twitter</a>
                        <a href="#" class="google-plus"><i class="fa fa-google-plus"></i>&nbsp; Login with Google Plus</a>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap Modal Dialog -->
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
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
