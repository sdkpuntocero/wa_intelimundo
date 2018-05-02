<%@ Page Title="" Language="C#" MasterPageFile="~/intelimundo.Master" AutoEventWireup="true" CodeBehind="Vendedor.aspx.cs" Inherits="wa_intelimundo.Vendedor" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <div class="container">
                <div class="form-group">
                    <div class="panel panel-default" id="div_pnl" runat="server">
                        <div class="panel-heading">
							<!--<center><h1>DATOS MEDICOS</h1></center>
							<center><h5>Selecciona según corresponda, los espacios vacíos indican negación de los padecimientos </h5></center>-->
                            <p class="text-right">
                                <asp:Label ID="lbl_bienvenida" runat="server" Text="Bienvenid@: " >
									<asp:LinkButton ID="lKbIENVENIDO" runat="server" OnClick="lKbIENVENIDO_Click">LinkButton</asp:LinkButton>

                                </asp:Label>
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
														<div id="v_resumen" runat="server">
															<asp:LinkButton CssClass="buttonClass" ID="a_resumen" runat="server" OnClick="lkb_resumen_Click">
																<i class="fas  fa-tachometer-alt"></i>
																<asp:Label CssClass="buttonClass" ID="b_resumen" runat="server" Text="Resumen"> </asp:Label>
															</asp:LinkButton>
														</div>
													</li>
                                                    <li>
                                                        <div id="v_contacto" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="a_contacto" runat="server" OnClick="a_contacto_Click">
                                                                <i class="fas fa-phone-square"></i>
                                                                <asp:Label CssClass="buttonClass" ID="b_contacto" runat="server" Text="Contacto"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="v_gasto" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="a_gastos" runat="server" OnClick="a_gastos_Click">
                                                                <i class="fas fa-male"></i>
                                                                <asp:Label CssClass="buttonClass" ID="b_gastos" runat="server" Text="Padre/Tutor"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="v_recepcion" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="a_recepcion" runat="server" OnClick="a_recepcion_Click">
                                                                <i class="fas fa-gavel"></i>
                                                                <asp:Label CssClass="buttonClass" ID="b_recepcion" runat="server" Text="Fiscal"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="div_ordencompra" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_ordencompra" runat="server">
                                                                <i class="fas  fa-shopping-cart"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_ordencompra" runat="server" Text="Orden de Compra"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="div_inventario" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_inventario" runat="server">
                                                                <i class="fas  fa-dolly"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_inventario" runat="server" Text="Inventario"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="div_sucursales" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_sucursales" runat="server">
                                                                <i class="fas  fa-sitemap"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_sucursales" runat="server" Text="Sucursales"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="div_proveedores" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_proveedores" runat="server" >
                                                                <i class="fas  fa-address-book" id="id_proveedores" runat="server"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_proveedores" runat="server" Text="Proveedores"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="div_alumnos" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_alumnos" runat="server" >
                                                                <i class="fas  fa-graduation-cap" id="i_alumnos" runat="server"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_alumnos" runat="server" Text="Alumnos"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="div_usuarios" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_usuarios" runat="server" >
                                                                <i class="fas  fa-users" id="i_usuarios" runat="server"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_usuarios" runat="server" Text="Usuarios"></asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
                                                    <li>
                                                        <div id="div_empresa" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_empresa" runat="server" >
                                                                <i class="fas  fa-briefcase" id="i_empresa" runat="server"></i>
                                                                <asp:Label CssClass="buttonClass" ID="lbl_empresa" runat="server" Text="Empresa"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </li>
													<div id="div1" runat="server">
                                                            <asp:LinkButton CssClass="buttonClass" ID="LinkButton1" runat="server" >
                                                                <i class="fas  fa-briefcase" id="i1" runat="server"></i>
                                                                <asp:Label CssClass="buttonClass" ID="Label1" runat="server" Text="Datos medicos"> </asp:Label>
                                                            </asp:LinkButton>
                                                        </div>
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
								
	       						<asp:Panel ID="Panel0" runat="server">
									   <asp:Label ID="Label6" runat="server" Text="Label">BIENVENIDO</asp:Label>

									</asp:Panel>
							    <asp:Panel ID="Panel1" runat="server">
									<asp:Label ID="Label3" runat="server" Text="Label">Resumen</asp:Label>
									<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>


							    </asp:Panel>
								<asp:Panel ID="Panel2" runat="server">
								    <asp:Label ID="Label2" runat="server" Text="Label">panel contacto</asp:Label>

						     	</asp:Panel>
								<asp:Panel ID="Panel3" runat="server">
									<asp:Label ID="Label4" runat="server" Text="Label">hola</asp:Label>

								</asp:Panel>
								<asp:Panel ID="Panel4" runat="server">
									<asp:Label ID="Label5" runat="server" Text="Label">raquel</asp:Label>

								</asp:Panel>

								<asp:Panel ID="Panel5" runat="server">

									<asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
								</asp:Panel>

									
									<%--<asp:UpdatePanel ID="up_usuariof" runat="server">
                                        <ContentTemplate>
                                            <div class="panel panel-default" id="pnl_fusuario" runat="server" visible="false">
                                                <div class="panel-heading">
                                                    <h3>Datos de Director</h3>
                                                </div>
                                                <div class="panel-body">
                                                    <div class="row">
                                                        <div class="col-md-12 text-right">
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkb_editar_fusuario" runat="server" OnClick="lkb_editar_fusuario_Click">
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
                                                            <asp:Button CssClass="btn" ID="btn_guarda_fusuario" runat="server" Text="Guardar" OnClick="btn_guarda_fusuario_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-footer"></div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>--%>
                  




<%--        <script>
        function habilitar(value)
		{
            if(value=="1" || value==true)
			{
				// habilitamos
				document.getElementById("segundo").disabled=false;
			}else if(value!="2" || value==true){
				// deshabilitamos
				document.getElementById("segundo").disabled=true;
			}
		}
	    </script>

			<form name="evaluacion"  method="">
                        
            <p>
                <input type="radio" name="radio1" id="radio1" /><label>  Desmayos</label><br/>
                           
            </p>
            <p>
				<input type="radio" name="radio2" id="radio2" /><label>  Convulsiones</label><br/>
            </p>
			<p>
				<input type="radio" name="radio3" id="radio3" /><label>  Alergias</label><br/>
            </p>
			<p>
				<input type="radio" name="radio4" id="radio4" /><label>  Asma</label><br/>
            </p>
            <p>
				<input type="radio" name="radio5" id="radio5" /><label>  Hepatitis</label><br/>
            </p>
            <p>
				<input type="radio" name="radio6" id="radio6" /><label>  Problemas de visión</label><br/>
            </p>
		    <p>
				<input type="radio" name="radio7" id="radio7" /><label>  Problemas auditivos </label><br/>
            </p>
            <p>
				<input type="radio" name="radio8" id="radio8" /><label>  Problemas motrices </label><br/>
            </p>
		    <p>
				<input type="radio" name="radio9" id="radio9" /><label>  Toma algún medicamento  </label><br/>
				<label for="cual">¿Cuál?</label>
                <input type="text" name="med" placeholder="" required>
            </p>
            <p>
				<input type="radio" name="radio10" id="radio10" /><label>  Padece alguna enfermedad   </label><br/>
				<label for="cual1">¿Cuál?</label>
                <input type="text" name="enf" placeholder="" required>
            </p>
		    <p>
				<input type="radio" name="radio11" id="radio11" /><label>  Tratamiento psicológico   </label><br/>
            </p>

				  <center><input type="submit" value="enviar"></center>
				  <center>  <button>limpiar</button></center>
			</form>--%>
<!--

<br />Desmayos     <asp:RadioButton ID="RadioButton1" runat="server" />


<br />Convulsiones     <asp:RadioButton ID="RadioButton2" runat="server" />


<br />Alergias     <asp:RadioButton ID="RadioButton3" runat="server" />


<br />Asma     <asp:RadioButton ID="RadioButton4" runat="server" />


<br />Hepatitis     <asp:RadioButton ID="RadioButton5" runat="server" />


<br />Problemas de visión     <asp:RadioButton ID="RadioButton6" runat="server" />


<br />Problemas auditivos     <asp:RadioButton ID="RadioButton7" runat="server" />
									

<br />Problemas motrices     <asp:RadioButton ID="RadioButton8" runat="server" />


<br />Toma algún medicamento     <asp:RadioButton ID="RadioButton9" runat="server" />




									<br />
									<br />
			<asp:Button ID="Button1" runat="server" Text="GUARDAR" />
									-->
									

									       



									


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
