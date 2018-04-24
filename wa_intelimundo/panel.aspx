<%@ Page Title="" Language="C#" MasterPageFile="~/intelimundo.Master" AutoEventWireup="true" CodeBehind="panel.aspx.cs" Inherits="wa_intelimundo.panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<br />
			<div class="container">
				<div class="form-group">
					<div class="panel panel-default" id="div_pnl" runat="server">
						<div class="panel-heading">
							<p class="text-right">
								<asp:Label ID="lbl_bienvenida" runat="server" Text="Bienvenid@: "></asp:Label>
								<asp:LinkButton ID="lkb_edita_usuario" runat="server" OnClick="lkb_edita_usuario_Click">
									<asp:Label CssClass="buttonClass" ID="lbl_fuser" runat="server" Text=""></asp:Label>
									<i class="fas  fa-barcode" id="i_editausuario" runat="server"></i>
								</asp:LinkButton>
								<br />
								<asp:Label ID="lbl_tipousuario" runat="server" Text="Perfil: "></asp:Label>
								<asp:Label ID="lbl_ftipousuario" runat="server" Text=""></asp:Label>
								<br />
								<asp:Label ID="lbl_centro" runat="server" Text="Centro: "></asp:Label>
								<asp:LinkButton CssClass="buttonClass" ID="lkb_edita_centro" runat="server" OnClick="lkb_edita_centro_Click">
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
													</li>
													<li>
														<div id="div_ventas" runat="server">
															<asp:LinkButton CssClass="buttonClass" ID="lkb_ventas" runat="server">
																<i class="fas  fa-shopping-basket"></i>
																<asp:Label CssClass="buttonClass" ID="lbl_ventas" runat="server" Text="Ventas"> </asp:Label>
															</asp:LinkButton>
														</div>
													</li>
													<li>
														<div id="div_gastos" runat="server">
															<asp:LinkButton CssClass="buttonClass" ID="lkb_gastos" runat="server">
																<i class="fas  fa-credit-card"></i>
																<asp:Label CssClass="buttonClass" ID="lbl_gastos" runat="server" Text="Gastos"> </asp:Label>
															</asp:LinkButton>
														</div>
													</li>
													<li>
														<div id="div_recepcion" runat="server">
															<asp:LinkButton CssClass="buttonClass" ID="lkb_recepcion" runat="server">
																<i class="fas  fa-truck"></i>
																<asp:Label CssClass="buttonClass" ID="lbl_recepcion" runat="server" Text="Recepción"> </asp:Label>
															</asp:LinkButton>
														</div>
													</li>
													<li>
														<div id="div_ordencompra" runat="server">
															<asp:LinkButton CssClass="buttonClass" ID="lkb_ordencompra" runat="server">
																<i class="fas  fa-shopping-cart"></i>
																<asp:Label CssClass="buttonClass" ID="lbl_ordencompra" runat="server" Text="Orde de Compra"> </asp:Label>
															</asp:LinkButton>
														</div>
													</li>
													<li>
														<div id="div_inventario" runat="server">
															<asp:LinkButton CssClass="buttonClass" ID="lkb_inventario" runat="server" OnClick="lkb_inventario_Click">
																<i class="fas  fa-dolly" id="i_inventarios" runat="server"></i>
																<asp:Label CssClass="buttonClass" ID="lbl_inventario" runat="server" Text="Inventario"> </asp:Label>
															</asp:LinkButton>
														</div>
													</li>
													<li>
														<div id="div_sucursales" runat="server">
															<asp:LinkButton CssClass="buttonClass" ID="lkb_sucursales" runat="server" OnClick="lkb_sucursales_Click">
																<i class="fas  fa-sitemap" id="i_sucursales" runat="server"></i>
																<asp:Label CssClass="buttonClass" ID="lbl_sucursales" runat="server" Text="Sucursales"> </asp:Label>
															</asp:LinkButton>
														</div>
													</li>
													<li>
														<div id="div_proveedores" runat="server">
															<asp:LinkButton CssClass="buttonClass" ID="lkb_proveedores" runat="server" OnClick="lkb_proveedores_Click">
																<i class="fas  fa-address-book" id="i_proveedores" runat="server"></i>
																<asp:Label CssClass="buttonClass" ID="lbl_proveedores" runat="server" Text="Proveedores"> </asp:Label>
															</asp:LinkButton>
														</div>
													</li>
													<li>
														<div id="div_alumnos" runat="server">
															<asp:LinkButton CssClass="buttonClass" ID="lkb_alumnos" runat="server" OnClick="lkb_alumnos_Click">
																<i class="fas  fa-graduation-cap" id="i_alumnos" runat="server"></i>
																<asp:Label CssClass="buttonClass" ID="lbl_alumnos" runat="server" Text="Alumnos"> </asp:Label>
															</asp:LinkButton>
														</div>
													</li>
													<li>
														<div id="div_usuarios" runat="server">
															<asp:LinkButton CssClass="buttonClass" ID="lkb_usuarios" runat="server" OnClick="lkb_usuarios_Click">
																<i class="fas  fa-users" id="i_usuarios" runat="server"></i>
																<asp:Label CssClass="buttonClass" ID="lbl_usuarios" runat="server" Text="Usuarios"></asp:Label>
															</asp:LinkButton>
														</div>
													</li>
													<li>
														<div id="div_empresa" runat="server">
															<asp:LinkButton CssClass="buttonClass" ID="lkb_empresa" runat="server" OnClick="lkb_empresa_Click">
																<i class="fas  fa-briefcase" id="i_empresa" runat="server"></i>
																<asp:Label CssClass="buttonClass" ID="lbl_empresa" runat="server" Text="Empresa"> </asp:Label>
															</asp:LinkButton>
														</div>
													</li>
													<br />
													<li>
														<div id="div_salir" runat="server">
															<asp:LinkButton CssClass="buttonClass" ID="lkb_salir" runat="server" OnClick="lkb_salir_Click">
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
									<asp:UpdatePanel ID="up_usuariof" runat="server">
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
									</asp:UpdatePanel>
									<asp:UpdatePanel ID="up_centrof" runat="server">
										<ContentTemplate>
											<div class="panel panel-default" id="pnl_centro" runat="server" visible="false">
												<div class="panel-heading">
													<h3>Datos de Centro</h3>
												</div>
												<div class="panel-body">
													<div class="row">
														<div class="col-md-12 text-right">
															<asp:LinkButton CssClass="buttonClass" ID="lkb_editar_centro" runat="server" OnClick="lkb_editar_centro_Click">
																<i class="fas fa-edit" id="i_editacentrof" runat="server"></i>
															</asp:LinkButton>
															<br />
														</div>
														<br />
														<div class="col-md-2 text-center">
															<i class="fas fa-5x fa-building"></i>
														</div>
														<div class="col-md-5">
															<asp:DropDownList CssClass="form-control" ID="ddl_licencias_centro" runat="server"></asp:DropDownList>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_nombre_centro" runat="server" placeholder="*Nombre de la centro"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_telefono_centro" runat="server" placeholder="*Teléfono"></asp:TextBox>
															<ajaxToolkit:MaskedEditExtender ID="mee_telefono_centro" runat="server" TargetControlID="txt_telefono_centro" Mask="(52) 99.99.99.99.99.99 ext 99999" />
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_email_centro" runat="server" placeholder="*e-mail"></asp:TextBox>
															<br />
														</div>
														<div class="col-md-5">
															<asp:TextBox CssClass="form-control" ID="txt_callenum_centro" runat="server" placeholder="*Calle y número"></asp:TextBox>
															<br />
															<div class="input-group">
																<asp:TextBox CssClass="form-control" ID="txt_cp_centro" runat="server" placeholder="*Código Postal" MaxLength="5"></asp:TextBox>
																<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_cp_centro" Mask="99999" />
																<span class="input-group-btn">
																	<asp:Button CssClass="btn" ID="btn_cp_centro" runat="server" Text="validar" OnClick="btn_cp_centro_Click" />
																</span>
															</div>
															<br />
															<asp:DropDownList CssClass="form-control" ID="ddl_colonia_centro" runat="server" ToolTip="*Colonia"></asp:DropDownList>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_municipio_centro" runat="server" placeholder="*Municipio" Enabled="false"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_estado_centro" runat="server" placeholder="*Estado" Enabled="false"></asp:TextBox>
															<br />
														</div>
														<div class="col-md-12 text-right">
															<asp:Button CssClass="btn" ID="btn_guarda_centro" runat="server" Text="Guardar" OnClick="btn_guarda_centro_Click" />
														</div>
													</div>
												</div>
												<div class="panel-footer"></div>
											</div>
										</ContentTemplate>
									</asp:UpdatePanel>
									<asp:UpdatePanel ID="up_usuarios" runat="server">
										<ContentTemplate>
											<div class="panel panel-default" id="pnl_usuarios" runat="server" visible="false">
												<div class="panel-heading">
													<h3>Control de Usuarios</h3>
												</div>
												<div class="panel-body">
													<div class="row">
														<div class="col-md-10">
														</div>
														<div class="col-md-2">
															<asp:LinkButton CssClass="buttonClass" ID="lkbtn_nuevo_usuario" runat="server" OnClick="lkbtn_nuevo_usuario_Click">
																<i class="fas fa-plus-square" id="i_agrega_usuario" runat="server"></i>
															</asp:LinkButton>
															&nbsp;
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkbtn_edita_usuario" runat="server" OnClick="lkbtn_edita_usuario_Click">
																<i class="fas fa-edit" id="i_edita_usuario" runat="server"></i>
															</asp:LinkButton>
															&nbsp;
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkbtn_baja_usuario" runat="server" OnClick="lkbtn_baja_usuario_Click">
																<i class="fas fa-trash" id="i_baja_usuario" runat="server"></i>
															</asp:LinkButton>
														</div>
													</div>
													<div class="col-md-offset-3 col-md-6">
														<div class="form-group">
															<div class="input-group">
																<asp:TextBox CssClass="form-control" ID="txt_buscar_usuario" runat="server" placeholder="Buscar" Visible="false"></asp:TextBox>
																<span class="input-group-btn">
																	<asp:Button CssClass="btn" ID="btn_busca_usuario" runat="server" Text="Ir" Visible="false" OnClick="btn_busca_usuario_Click" />
																</span>
															</div>
														</div>
													</div>
													<br />
													<div class="col-md-12">
														<asp:GridView CssClass="table" ID="gv_usuarios" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gv_usuarios_PageIndexChanging">
															<Columns>
																<asp:TemplateField>
																	<ItemTemplate>
																		<asp:CheckBox ID="chk_usuario" runat="server" onclick="CheckOne(this)" AutoPostBack="true" OnCheckedChanged="chk_usuario_CheckedChanged" />
																	</ItemTemplate>
																</asp:TemplateField>
																<asp:BoundField DataField="codigo_usuario" HeaderText="ID de Usuario" SortExpression="codigo_usuario" Visible="true" />
																<asp:BoundField DataField="desc_estatus" HeaderText="Estatus" SortExpression="desc_estatus" />
																<asp:BoundField DataField="nombres" HeaderText="Nombre de Usuario" SortExpression="nombres" />
																<asp:BoundField DataField="a_paterno" HeaderText="Apellido Paterno" SortExpression="a_paterno" />
																<asp:BoundField DataField="a_materno" HeaderText="Apellido Materno" SortExpression="a_materno" />
																<asp:BoundField DataField="fecha_registro" HeaderText="Fecha de Registro" SortExpression="fecha_registro" DataFormatString="{0:dd/MM/yyyy}" />
															</Columns>
														</asp:GridView>
														<br />
													</div>

													<div class="col-md-2 text-left">
														<i class="fas fa-3x fa-users"></i>
														<br />
														<asp:CheckBox ID="chkb_administrador" runat="server" Text="Administrador" OnCheckedChanged="chkb_administrador_CheckedChanged" AutoPostBack="true" />
														<br />
														<asp:CheckBox ID="chkb_gerente" runat="server" Text="Gerente" OnCheckedChanged="chkb_gerente_CheckedChanged" AutoPostBack="true" />
														<br />
														<asp:CheckBox ID="chkb_facilitador" runat="server" Text="Facilitador" OnCheckedChanged="chkb_facilitador_CheckedChanged" AutoPostBack="true" />
														<br />
														<asp:CheckBox ID="chkb_ejecutivo" runat="server" Text="Ejecute" OnCheckedChanged="chkb_ejecutivo_CheckedChanged" AutoPostBack="true" />
														<br />
														<asp:CheckBox ID="chkb_contador" runat="server" Text="Contador" OnCheckedChanged="chkb_contador_CheckedChanged" AutoPostBack="true" />
														<br />
														<asp:CheckBox ID="chkb_vendedor" runat="server" Text="Vendedor" OnCheckedChanged="chkb_vendedor_CheckedChanged" AutoPostBack="true" />
													</div>
													<div class="col-md-5">
														<asp:DropDownList CssClass="form-control" ID="ddl_genero_usuario" runat="server"></asp:DropDownList>
														<br />
														<asp:TextBox CssClass="form-control" ID="txt_nombres_usuario" runat="server" placeholder="*Nombre(s)"></asp:TextBox>
														<br />
														<asp:TextBox CssClass="form-control" ID="txt_apaterno_usuario" runat="server" placeholder="*Apellido Paterno"></asp:TextBox>
														<br />
														<asp:TextBox CssClass="form-control" ID="txt_amaterno_usuario" runat="server" placeholder="*Apellido Materno"></asp:TextBox>
														<br />
													</div>
													<div class="col-md-5">
														<asp:TextBox CssClass="form-control" ID="txt_cumple_usuario" runat="server" placeholder="Fecha de Nacimiento"></asp:TextBox>
														<ajaxToolkit:CalendarExtender ID="ce_cumple" runat="server" BehaviorID="txt_cumple_usuario" TargetControlID="txt_cumple_usuario" Format="yyyy/MM/dd" />
														<br />
														<div class="input-group">
															<asp:TextBox CssClass="form-control" ID="txt_usuario_usuario" runat="server" placeholder="*Usuario" Enabled="false"></asp:TextBox>
															<span class="input-group-btn">
																<asp:Button CssClass="btn" ID="btn_genera_usuario" runat="server" Text="+" OnClick="btn_genera_usuario_Click" />
															</span>
														</div>

														<br />
														<asp:TextBox CssClass="form-control" ID="txt_clave_usuario" runat="server" placeholder="*Contraseña" TextMode="Password"></asp:TextBox>
														<br />
													</div>
													<div class="col-md-12 text-right">
														<asp:Button CssClass="btn" ID="btn_guardar_usuario" runat="server" Text="Guardar" OnClick="btn_guardar_usuario_Click" />
													</div>
												</div>
												<div class="panel-footer"></div>
											</div>
										</ContentTemplate>
									</asp:UpdatePanel>
									<asp:UpdatePanel ID="up_empresa" runat="server">
										<ContentTemplate>
											<div class="panel panel-default" id="pnl_empresa" runat="server" visible="false">
												<div class="panel-heading">
													<h3>Datos de Empresa</h3>
												</div>
												<div class="panel-body">
													<div class="row">
														<div class="col-md-12 text-right">
															<asp:LinkButton CssClass="buttonClass" ID="lkb_editar_empresa" runat="server" OnClick="lkb_editar_empresa_Click">
																<i class="fas fa-edit" id="i_editaempresa" runat="server"></i>
															</asp:LinkButton>
														</div>
														<div class="col-md-2 text-center">
															<i class="fas fa-5x fa-briefcase"></i>
														</div>
														<br />
														<div class="col-md-5">
															<asp:DropDownList CssClass="form-control" ID="ddl_tipo_rfc_empresa" runat="server"></asp:DropDownList>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_rfc_empresa" runat="server" placeholder="*RFC" Visible="True"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_rs_empresa" runat="server" placeholder="*Nombre de la empresa"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_telefono_empresa" runat="server" placeholder="*Teléfono"></asp:TextBox>
															<ajaxToolkit:MaskedEditExtender ID="mee_telefono_empresa" runat="server" TargetControlID="txt_telefono_empresa" Mask="(52) 99.99.99.99.99.99 ext 99999" />
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_email_empresa" runat="server" placeholder="*e-mail"></asp:TextBox>
															<br />
														</div>
														<div class="col-md-5">
															<asp:TextBox CssClass="form-control" ID="txt_callenum_empresa" runat="server" placeholder="*Calle y número"></asp:TextBox>
															<br />
															<div class="input-group">
																<asp:TextBox CssClass="form-control" ID="txt_cp_empresa" runat="server" placeholder="*Código Postal" MaxLength="5"></asp:TextBox>
																<ajaxToolkit:MaskedEditExtender ID="mee_cp_empresa" runat="server" TargetControlID="txt_cp_empresa" Mask="99999" />
																<span class="input-group-btn">
																	<asp:Button CssClass="btn" ID="btn_cp_empresa" runat="server" Text="validar" OnClick="btn_cp_empresa_Click" />
																</span>
															</div>
															<br />
															<asp:DropDownList CssClass="form-control" ID="ddl_colonia_empresa" runat="server" ToolTip="*Colonia"></asp:DropDownList>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_municipio_empresa" runat="server" placeholder="*Municipio" Enabled="false"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_estado_empresa" runat="server" placeholder="*Estado" Enabled="false"></asp:TextBox>
															<br />
														</div>
													</div>
													<div class="row">
														<div class="col-md-12 text-right">
															<asp:Button CssClass="btn" ID="btn_guarda_empresa" runat="server" Text="Guardar" OnClick="btn_guarda_empresa_Click" />
														</div>
													</div>
												</div>
												<div class="panel-footer"></div>
											</div>
										</ContentTemplate>
									</asp:UpdatePanel>
									<asp:UpdatePanel ID="up_proveedores" runat="server">
										<ContentTemplate>
											<div class="panel panel-default" id="pnl_proveedores" runat="server" visible="false">
												<div class="panel-heading">
													<h3>Control de Proveedores</h3>
												</div>
												<div class="panel-body">
													<div class="row">
														<div class="col-md-10">
														</div>
														<div class="col-md-2">
															<asp:LinkButton CssClass="buttonClass" ID="lkbtn_nuevo_proveedor" runat="server" OnClick="lkbtn_nuevo_proveedor_Click">
																<i class="fas fa-plus-square" id="i_agrega_proveedor" runat="server"></i>
															</asp:LinkButton>
															&nbsp;
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkbtn_edita_proveedor" runat="server" OnClick="lkbtn_edita_proveedor_Click">
																<i class="fas fa-edit" id="i_edita_proveedor" runat="server"></i>
															</asp:LinkButton>
															&nbsp;
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkbtn_baja_proveedor" runat="server" OnClick="lkbtn_baja_proveedor_Click">
																<i class="fas fa-trash" id="i_baja_proveedor" runat="server"></i>
															</asp:LinkButton>
														</div>
														<div class="col-md-offset-3 col-md-6">
															<div class="form-group">
																<div class="input-group">
																	<asp:TextBox CssClass="form-control" ID="txt_buscar_proveedor" runat="server" placeholder="Buscar" Visible="false"></asp:TextBox>
																	<span class="input-group-btn">
																		<asp:Button CssClass="btn" ID="btn_buscar_proveedor" runat="server" Text="Ir" Visible="false" OnClick="btn_buscar_proveedor_Click" />
																	</span>
																</div>
															</div>
														</div>
														<br />
														<div class="col-md-12">
															<asp:GridView CssClass="table" ID="gv_proveedor" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gv_proveedor_PageIndexChanging">
																<Columns>
																	<asp:TemplateField>
																		<ItemTemplate>
																			<asp:CheckBox ID="chk_proveedor" runat="server" onclick="CheckOne(this)" OnCheckedChanged="chk_proveedor_CheckedChanged" AutoPostBack="true" />
																		</ItemTemplate>
																	</asp:TemplateField>
																	<asp:BoundField DataField="rfc" HeaderText="RFC" SortExpression="rfc" Visible="true" />
																	<asp:BoundField DataField="desc_tipo_rfc" HeaderText="Tipo RFC" SortExpression="desc_tipo_rfc" />
																	<asp:BoundField DataField="razon_social" HeaderText="Razón Social" SortExpression="razon_social" />
																	<asp:BoundField DataField="fecha_registro" HeaderText="Fecha de Registro" SortExpression="fecha_registro" DataFormatString="{0:dd/MM/yyyy}" />
																</Columns>
															</asp:GridView>
															<br />
														</div>
														<div class="col-md-2 text-center">
															<i class="fas fa-5x fa-address-book"></i>
															<h4 class="text-center">Proveedor</h4>
														</div>

														<div class="col-md-5">
															<asp:DropDownList CssClass="form-control" ID="ddl_tipo_rfc_proveedor" runat="server"></asp:DropDownList>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_rfc_proveedor" runat="server" placeholder="*RFC" Visible="True"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_empresa_proveedor" runat="server" placeholder="*Nombre de la empresa"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_telefono_proveedor" runat="server" placeholder="*Teléfono"></asp:TextBox>
															<ajaxToolkit:MaskedEditExtender ID="mee_telefono_proveedor" runat="server" TargetControlID="txt_telefono_proveedor" Mask="(52) 99.99.99.99.99.99 ext 99999" />
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_email_proveedor" runat="server" placeholder="*e-mail"></asp:TextBox>
															<br />
														</div>
														<div class="col-md-5">
															<asp:TextBox CssClass="form-control" ID="txt_callenum_proveedor" runat="server" placeholder="*Calle y número"></asp:TextBox>
															<br />
															<div class="input-group">
																<asp:TextBox CssClass="form-control" ID="txt_cp_proveedor" runat="server" placeholder="*Código Postal" MaxLength="5"></asp:TextBox>
																<ajaxToolkit:MaskedEditExtender ID="mee_cp" runat="server" TargetControlID="txt_cp_proveedor" Mask="99999" />
																<span class="input-group-btn">
																	<asp:Button CssClass="btn" ID="btn_cp_proveedor" runat="server" Text="validar" OnClick="btn_cp_proveedor_Click" />
																</span>
															</div>
															<br />
															<asp:DropDownList CssClass="form-control" ID="ddl_colonia_proveedor" runat="server" ToolTip="*Colonia"></asp:DropDownList>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_municipio_proveedor" runat="server" placeholder="*Municipio" Enabled="false"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_estado_proveedor" runat="server" placeholder="*Estado" Enabled="false"></asp:TextBox>
														</div>
													</div>
													<hr />
													<div class="row">
														<div class="col-md-2 text-center">
															<i class="fas fa-5x fa-address-book"></i>
															<h4 class="text-center">Contacto Proveedor</h4>
														</div>
														<div class="col-md-5">
															<asp:TextBox CssClass="form-control" ID="txt_nombres_cproveedor" runat="server" placeholder="*Nombre(s)"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_apaterno_cproveedor" runat="server" placeholder="*Apellido Paterno"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_amaterno_cproveedor" runat="server" placeholder="*Apellido Materno"></asp:TextBox>
															<br />
														</div>
														<div class="col-md-5">
															<asp:TextBox CssClass="form-control" ID="txt_telefono_cproveedor" runat="server" placeholder="*Teléfono"></asp:TextBox>
															<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_telefono_cproveedor" Mask="(52) 99.99.99.99.99.99 ext 99999" />
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_email_cproveedor" runat="server" placeholder="*e-mail"></asp:TextBox>
															<br />
														</div>
														<div class="col-md-12 text-right">
															<asp:Button CssClass="btn" ID="btn_guardar_proveedor" runat="server" Text="Guardar" OnClick="btn_guardar_proveedor_Click" />
														</div>
													</div>
												</div>
												<div class="panel-footer"></div>
											</div>
										</ContentTemplate>
									</asp:UpdatePanel>
									<asp:UpdatePanel ID="up_alumnos" runat="server">
										<ContentTemplate>
											<div class="panel panel-default" id="pnl_alumnos" runat="server" visible="false">
												<div class="panel-heading">
													<h3>Control de Alumnos</h3>
												</div>
												<div class="panel-body">
													<div class="col-md-10">
													</div>
													<div class="col-md-2">
														<asp:LinkButton CssClass="buttonClass" ID="lkbtn_nuevo_alumno" runat="server" OnClick="lkbtn_nuevo_alumno_Click">
															<i class="fas fa-plus-square" id="i_agrega_alumno" runat="server"></i>
														</asp:LinkButton>
														&nbsp;
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkbtn_edita_alumno" runat="server" OnClick="lkbtn_edita_alumno_Click">
																<i class="fas fa-edit" id="i_edita_alumno" runat="server"></i>
															</asp:LinkButton>
														&nbsp;
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkbtn_baja_alumno" runat="server" OnClick="lkbtn_baja_alumno_Click">
																<i class="fas fa-trash" id="i_baja_alumno" runat="server"></i>
															</asp:LinkButton>
													</div>
													<div class="col-md-offset-3 col-md-6">
														<div class="form-group">
															<div class="input-group">
																<asp:TextBox CssClass="form-control" ID="txt_buscar_alumno" runat="server" placeholder="Buscar" Visible="false"></asp:TextBox>
																<span class="input-group-btn">
																	<asp:Button CssClass="btn" ID="btn_buscar_alumno" runat="server" Text="Ir" OnClick="btn_buscar_alumno_Click" Visible="false" />
																</span>
															</div>
														</div>
													</div>
													<br />
													<div class="col-md-12">
														<asp:GridView CssClass="table" ID="gv_alumnos" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gv_alumnos_PageIndexChanging">
															<Columns>
																<asp:TemplateField>
																	<ItemTemplate>
																		<asp:CheckBox ID="chk_alumno" runat="server" onclick="CheckOne(this)" AutoPostBack="true" OnCheckedChanged="chk_alumno_CheckedChanged" />
																	</ItemTemplate>
																</asp:TemplateField>
																<asp:BoundField DataField="codigo_alumno" HeaderText="Código Alumno" SortExpression="codigo_alumno" Visible="true" />
																<asp:BoundField DataField="desc_estatus" HeaderText="Estatus" SortExpression="desc_estatus" />
																<asp:BoundField DataField="nombres" HeaderText="Nombre de Usuario" SortExpression="nombres" />
																<asp:BoundField DataField="a_paterno" HeaderText="Apellido Paterno" SortExpression="a_paterno" />
																<asp:BoundField DataField="a_materno" HeaderText="Apellido Materno" SortExpression="a_materno" />
																<asp:BoundField DataField="fecha_registro" HeaderText="Fecha de Registro" SortExpression="fecha_registro" DataFormatString="{0:dd/MM/yyyy}" />
															</Columns>
														</asp:GridView>
														<br />
													</div>
													<div class="col-md-2 text-center">
														<i class="fas fa-5x fa-graduation-cap"></i>
													</div>
													<br />
													<div class="col-md-5">
														<asp:DropDownList CssClass="form-control" ID="ddl_genero_alumno" runat="server"></asp:DropDownList>
														<br />
														<asp:TextBox CssClass="form-control" ID="txt_cumple_alumno" runat="server" placeholder="*Fecha de Nacimiento"></asp:TextBox>
														<ajaxToolkit:CalendarExtender ID="ce_cumple_alumno" runat="server" BehaviorID="txt_cumple_alumno" TargetControlID="txt_cumple_alumno" Format="yyyy/MM/dd" />
														<br />
														<asp:TextBox CssClass="form-control" ID="txt_nombres_alumno" runat="server" placeholder="*Nombre(s)"></asp:TextBox>
														<br />
														<asp:TextBox CssClass="form-control" ID="txt_apaterno_alumno" runat="server" placeholder="*Apellido Paterno"></asp:TextBox>
														<br />
														<asp:TextBox CssClass="form-control" ID="txt_amaterno_alumno" runat="server" placeholder="*Apellido Materno"></asp:TextBox>
														<br />
													</div>
													<div class="col-md-5">
														<asp:TextBox CssClass="form-control" ID="txt_email_alumno" runat="server" placeholder="*e-mail"></asp:TextBox>
														<br />

														<div class="input-group">
															<asp:TextBox CssClass="form-control" ID="txt_usuario_alumno" runat="server" placeholder="*Usuario" Enabled="false"></asp:TextBox>
															<span class="input-group-btn">
																<asp:Button CssClass="btn" ID="btn_usuario_alumno" runat="server" Text="+" OnClick="btn_usuario_alumno_Click" />
															</span>
														</div>
														<br />
														<asp:TextBox CssClass="form-control" ID="txt_clave_alumno" runat="server" placeholder="*Contraseña" TextMode="Password"></asp:TextBox>
														<br />
													</div>
													<div class="col-md-12 text-right">
														<asp:Button CssClass="btn" ID="btn_guardar_alumno" runat="server" Text="Guardar" OnClick="btn_guardar_alumno_Click" />
													</div>
												</div>
												<div class="panel-footer"></div>
											</div>
										</ContentTemplate>
									</asp:UpdatePanel>
									<asp:UpdatePanel ID="up_sucursales" runat="server">
										<ContentTemplate>
											<div class="panel panel-default" id="pnl_sucursales" runat="server" visible="false">
												<div class="panel-heading">
													<h3>Control de Sucursales</h3>
												</div>
												<div class="panel-body">
													<div class="row">
														<div class="col-md-10">
														</div>
														<div class="col-md-2">
															<asp:LinkButton CssClass="buttonClass" ID="lkbtn_nuevo_sucursal" runat="server" OnClick="lkbtn_nuevo_sucursal_Click">
																<i class="fas fa-plus-square" id="i_agrega_sucursal" runat="server"></i>
															</asp:LinkButton>
															&nbsp;
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkbtn_edita_sucursal" runat="server" OnClick="lkbtn_edita_sucursal_Click">
																<i class="fas fa-edit" id="i_edita_sucursal" runat="server"></i>
															</asp:LinkButton>
															&nbsp;
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkbtn_baja_sucursal" runat="server" OnClick="lkbtn_baja_sucursal_Click">
																<i class="fas fa-trash" id="i_baja_sucursal" runat="server"></i>
															</asp:LinkButton>
														</div>
														<div class="col-md-offset-3 col-md-6">
															<div class="form-group">
																<div class="input-group">
																	<asp:TextBox CssClass="form-control" ID="txt_buscar_sucursal" runat="server" placeholder="Buscar" Visible="false"></asp:TextBox>
																	<span class="input-group-btn">
																		<asp:Button CssClass="btn" ID="btn_buscar_sucursal" runat="server" Text="Ir" Visible="false" OnClick="btn_buscar_sucursal_Click" />
																	</span>
																</div>
															</div>
														</div>
														<br />
														<div class="col-md-12">
															<asp:GridView CssClass="table" ID="gv_sucursal" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gv_sucursal_PageIndexChanging">
																<Columns>
																	<asp:TemplateField>
																		<ItemTemplate>
																			<asp:CheckBox ID="chk_sucursal" runat="server" onclick="CheckOne(this)" OnCheckedChanged="chk_sucursal_CheckedChanged" AutoPostBack="true" />
																		</ItemTemplate>
																	</asp:TemplateField>
																	<asp:BoundField DataField="id_codigo_centro" HeaderText="Código Sucursal" SortExpression="id_codigo_centro" />
																	<asp:BoundField DataField="desc_licencia" HeaderText="Licencia" SortExpression="desc_licencia" Visible="true" />
																	<asp:BoundField DataField="nombre" HeaderText="Sucursal" SortExpression="nombre" />
																	<asp:BoundField DataField="codigo_usuario" HeaderText="Usuario" SortExpression="codigo_usuario" />
																	<asp:BoundField DataField="admin" HeaderText="Administrador" SortExpression="nombre" />
																	<asp:BoundField DataField="fecha_registro" HeaderText="Fecha de Registro" SortExpression="fecha_registro" DataFormatString="{0:dd/MM/yyyy}" />
																</Columns>
															</asp:GridView>

															<br />
														</div>
														<div class="col-md-2 text-center">
															<i class="fas fa-5x fa-sitemap"></i>

														</div>
														<br />
														<div class="col-md-4">

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
														<div class="col-md-4">
															<asp:TextBox CssClass="form-control" ID="txt_callenum_sucursal" runat="server" placeholder="*Calle y número"></asp:TextBox>
															<br />
															<div class="input-group">
																<asp:TextBox CssClass="form-control" ID="txt_cp_sucursal" runat="server" placeholder="*Código Postal" MaxLength="5"></asp:TextBox>
																<ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_cp_sucursal" Mask="99999" />
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
													</div>
													<hr />
													<div class="row">
														<h3 class="text-center">Anexo de Administradores</h3>
														<div class="col-md-12">
															<asp:GridView CssClass="table" ID="gv_administrador" runat="server" AutoGenerateColumns="False" AllowPaging="true">
																<Columns>
																	<asp:TemplateField>
																		<ItemTemplate>
																			<asp:CheckBox ID="chk_administrador" runat="server" onclick="CheckOne(this)" AutoPostBack="true" OnCheckedChanged="chk_administrador_CheckedChanged" />
																		</ItemTemplate>
																	</asp:TemplateField>
																	<asp:BoundField DataField="codigo_usuario" HeaderText="ID de Usuario" SortExpression="codigo_usuario" Visible="true" />
																	<asp:BoundField DataField="desc_estatus" HeaderText="Estatus" SortExpression="desc_estatus" />
																	<asp:BoundField DataField="nombres" HeaderText="Nombre de Usuario" SortExpression="nombres" />
																	<asp:BoundField DataField="a_paterno" HeaderText="Apellido Paterno" SortExpression="a_paterno" />
																	<asp:BoundField DataField="a_materno" HeaderText="Apellido Materno" SortExpression="a_materno" />
																	<asp:BoundField DataField="fecha_registro" HeaderText="Fecha de Registro" SortExpression="fecha_registro" DataFormatString="{0:dd/MM/yyyy}" />
																</Columns>
															</asp:GridView>
															<br />
														</div>
														<div class="col-md-12 text-right">
															<asp:Button CssClass="btn" ID="btn_guardar_sucursal" runat="server" Text="Guardar" OnClick="btn_guardar_sucursal_Click" />
														</div>
													</div>
												</div>
												<div class="panel-footer"></div>
											</div>
										</ContentTemplate>
									</asp:UpdatePanel>
									<asp:UpdatePanel ID="up_inventarios" runat="server">
										<ContentTemplate>
											<div class="panel panel-default" id="pnl_inventarios" runat="server" visible="false">
												<div class="panel-heading">
													<h3>Control de Inventario</h3>
												</div>
												<div class="panel-body">
													<div class="row" id="div1" runat="server">
														<div class="col-md-10">
														</div>
														<div class="col-md-2">
															<asp:LinkButton CssClass="buttonClass" ID="lkbtn_nuevo_inventario" runat="server" OnClick="lkbtn_nuevo_inventario_Click">
																<i class="fas fa-plus-square" id="i_agrega_inventario" runat="server"></i>
															</asp:LinkButton>
															&nbsp;
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkbtn_edita_inventario" runat="server" OnClick="lkbtn_edita_inventario_Click">
																<i class="fas fa-edit" id="i_edita_inventario" runat="server"></i>
															</asp:LinkButton>
															&nbsp;
                                                            <asp:LinkButton CssClass="buttonClass" ID="lkbtn_baja_inventario" runat="server" OnClick="lkbtn_baja_inventario_Click">
																<i class="fas fa-trash" id="i_baja_inventario" runat="server"></i>
															</asp:LinkButton>
														</div>
														<div class="col-md-offset-3 col-md-6">
															<div class="form-group">
																<div class="input-group">
																	<asp:TextBox CssClass="form-control" ID="txt_buscar_inventario" runat="server" placeholder="Buscar" Visible="false"></asp:TextBox>
																	<span class="input-group-btn">
																		<asp:Button CssClass="btn" ID="btn_buscar_inventario" runat="server" Text="Ir" Visible="false" OnClick="btn_buscar_inventario_Click" />
																	</span>
																</div>
															</div>
														</div>
														<br />
														<div class="col-md-12">
															<asp:GridView CssClass="table" ID="gv_inventario" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="gv_inventario_PageIndexChanging" PageSize="5">
																<Columns>
																	<asp:TemplateField>
																		<ItemTemplate>
																			<asp:CheckBox ID="chk_inventario" runat="server" onclick="CheckOne(this)" OnCheckedChanged="chk_inventario_CheckedChanged" AutoPostBack="true" />
																		</ItemTemplate>
																	</asp:TemplateField>
																	<asp:BoundField DataField="id_codigo_inventario" HeaderText="ID Producto" SortExpression="id_codigo_inventario" Visible="true" />
																	<asp:BoundField DataField="categoria" HeaderText="Categoria" SortExpression="categoria" />
																	<asp:BoundField DataField="desc_inventario" HeaderText="Descripción" SortExpression="desc_inventario" />
																	<asp:BoundField DataField="cantidad" HeaderText="Cantidad" SortExpression="cantidad" />
																	<asp:BoundField DataField="costo" HeaderText="Costo" SortExpression="costo" DataFormatString="{0:C}" />
																	<asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" DataFormatString="{0:C}" />
																	<asp:BoundField DataField="fecha_registro" HeaderText="Fecha de Registro" SortExpression="fecha_registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
																</Columns>
															</asp:GridView>
															<br />
														</div>
														<div class="col-md-2 text-center">
															<i class="fas fa-5x fa-dolly"></i>

														</div>
														<br />
														<div class="col-md-5">
															<div class="input-group">
																<asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server"></asp:DropDownList>
																<span class="input-group-btn">
																	<asp:Button CssClass="btn" ID="Button1" runat="server" Text="calcular"  Enabled="false" />
																</span>
															</div>
															<br />
															<div class="input-group">
																<asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server"></asp:DropDownList>
																<span class="input-group-btn">
																	<asp:Button CssClass="btn" ID="Button2" runat="server" Text="calcular"  Enabled="false" />
																</span>
															</div>
															<br />
															<div class="input-group">
																<asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server"></asp:DropDownList>
																<span class="input-group-btn">
																	<asp:Button CssClass="btn" ID="Button3" runat="server" Text="calcular"  Enabled="false" />
																</span>
															</div>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_categoria_inventario" runat="server" placeholder="*Descripción" TextMode="MultiLine"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_desc_inventario" runat="server" placeholder="*Descripción" TextMode="MultiLine"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_caracteristica_inventario" runat="server" placeholder="*Caracteristica"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_cantidad_inventario" runat="server" placeholder="*Cantidad"></asp:TextBox>
															<br />
														</div>
														<div class="col-md-5">
															<asp:TextBox CssClass="form-control" ID="txt_mcantidad_inventario" runat="server" placeholder="*Cantidad Minima" Enabled="false" Text="*Cantidad Minima"></asp:TextBox>
															<br />
															<asp:TextBox CssClass="form-control" ID="txt_costo_inventario" runat="server" placeholder="*Costo($)"></asp:TextBox>
															<br />
															<ajaxToolkit:MaskedEditExtender
																ID="mee_costo_inventario"
																runat="server"
																TargetControlID="txt_costo_inventario"
																Mask="999,999.99"
																MessageValidatorTip="true"
																OnFocusCssClass="MaskedEditFocus"
																OnInvalidCssClass="MaskedEditError"
																MaskType="Number"
																InputDirection="RightToLeft"
																AcceptNegative="Left"
																DisplayMoney="Left"
																ErrorTooltipEnabled="True" />
															<div class="form-group">
																<div class="input-group">
																	<asp:TextBox CssClass="form-control" ID="txt_margen_inventario" runat="server" placeholder="*Margen (%)" Enabled="false" Text="*Margen (%)"></asp:TextBox>
																	<span class="input-group-btn">
																		<asp:Button CssClass="btn" ID="btn_margen_inventario" runat="server" Text="calcular" OnClick="btn_margen_inventario_Click" Enabled="false" />
																	</span>
																</div>
															</div>
															<asp:TextBox CssClass="form-control" ID="txt_precio_inventario" runat="server" placeholder="Precio" Enabled="false"></asp:TextBox>
															<br />
														</div>
														<div class="col-md-12 text-right">
															<asp:Button CssClass="btn" ID="btn_guardar_inventario" runat="server" Text="Guardar" OnClick="btn_guardar_inventario_Click" />
														</div>
													</div>
												</div>
												<div class="panel-footer"></div>
											</div>
										</ContentTemplate>
									</asp:UpdatePanel>
									<asp:UpdatePanel ID="UpdatePanel6" runat="server">
										<ContentTemplate>
										</ContentTemplate>
									</asp:UpdatePanel>
									<asp:UpdatePanel ID="UpdatePanel7" runat="server">
										<ContentTemplate>
										</ContentTemplate>
									</asp:UpdatePanel>
									<asp:UpdatePanel ID="UpdatePanel8" runat="server">
										<ContentTemplate>
										</ContentTemplate>
									</asp:UpdatePanel>
								</div>
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
