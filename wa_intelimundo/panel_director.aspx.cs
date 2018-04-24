﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
	public partial class panel_director : System.Web.UI.Page
	{

		static Guid guid_fuser, guid_iduser, guid_centro, guid_idproveedor;
		static int int_idtipousuario, int_tipousuario, int_accion_usuario, int_accion_alumno, int_accion_proveedor;
		static string str_idcodigousuario;

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{

				if (!IsPostBack)
				{
					inf_user();
				}
				else
				{

				}
			}
			catch
			{
				Response.Redirect("acceso.aspx");
			}
		}
		private void inf_user()
		{

			guid_iduser = (Guid)(Session["ss_id_user"]);


			using (db_imEntities m_usuario = new db_imEntities())
			{
				var i_usuario = (from i_u in m_usuario.inf_usuarios
								 join i_tu in m_usuario.fact_tipo_usuario on i_u.id_tipo_usuario equals i_tu.id_tipo_usuario

								 join i_c in m_usuario.inf_centro on i_u.id_centro equals i_c.id_centro

								 where i_u.id_usuario == guid_iduser
								 select new
								 {
									 i_u.nombres,
									 i_u.a_paterno,
									 i_u.a_materno,
									 i_tu.desc_tipo_usuario,
									 i_tu.id_tipo_usuario,
									 i_c.nombre,
									 i_c.id_centro

								 }).FirstOrDefault();

				lbl_fuser.Text = i_usuario.nombres + " " + i_usuario.a_paterno + " " + i_usuario.a_materno;
				lbl_ftipousuario.Text = i_usuario.desc_tipo_usuario;
				int_idtipousuario = i_usuario.id_tipo_usuario;
				lbl_fcentro.Text = i_usuario.nombre;
				guid_centro = i_usuario.id_centro;
			}


		}

		protected void lkb_edita_usuario_Click(object sender, EventArgs e)
		{
			filtra_panel(1);

		}
		protected void lkb_edita_centro_Click(object sender, EventArgs e)
		{
			filtra_panel(2);
		}
		protected void lkb_proveedores_Click(object sender, EventArgs e)
		{
			filtra_panel(10);
		}
		protected void lkb_alumnos_Click(object sender, EventArgs e)
		{
			filtra_panel(11);
		}
		protected void lkb_usuarios_Click(object sender, EventArgs e)
		{

			filtra_panel(12);
		}
		protected void lkb_empresa_Click(object sender, EventArgs e)
		{
			filtra_panel(13);
		}
		protected void lkb_salir_Click(object sender, EventArgs e)
		{
			filtra_panel(14);
		}
		private void filtra_panel(int int_idpanel)
		{

			switch (int_idpanel)
			{
				case 1:
					pnl_fusuario.Visible = true;
					pnl_centro.Visible = false;
					//pnl_inventarios.Visible = false;
					//pnl_categoria.Visible = false;
					//pnl_marca.Visible = false;
					//pnl_linea.Visible = false;
					//pnl_cliente.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = false;

					lbl_fuser.Attributes["style"] = "color:orangered";
					lbl_fcentro.Attributes["style"] = "color:dimgray";
					i_editausuariof.Attributes["style"] = "color:dimgray";
					i_editacentrof.Attributes["style"] = "color:dimgray";
					lbl_inventario.Attributes["style"] = "color:dimgray";
					//lbl_clientes.Attributes["style"] = "color:dimgray";
					lbl_proveedores.Attributes["style"] = "color:dimgray";
					lbl_alumnos.Attributes["style"] = "color:dimgray";
					lbl_usuarios.Attributes["style"] = "color:dimgray";
					lbl_empresa.Attributes["style"] = "color:dimgray";
					limpiar_textbox_fusuario();

					lbl_usuarios.Attributes["style"] = "color:dimgray";
					break;
				case 2:

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = true;
					//pnl_inventarios.Visible = false;
					//pnl_categoria.Visible = false;
					//pnl_marca.Visible = false;
					//pnl_linea.Visible = false;
					//pnl_cliente.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = false;

					lbl_fuser.Attributes["style"] = "color:dimgray";
					lbl_fcentro.Attributes["style"] = "color:orangered";
					i_editacentrof.Attributes["style"] = "color:dimgray";
					lbl_inventario.Attributes["style"] = "color:dimgray";
					//lbl_clientes.Attributes["style"] = "color:dimgray";
					lbl_proveedores.Attributes["style"] = "color:dimgray";
					lbl_alumnos.Attributes["style"] = "color:dimgray";
					lbl_usuarios.Attributes["style"] = "color:dimgray";
					lbl_empresa.Attributes["style"] = "color:dimgray";
					limpia_txt_centro();
					break;
				case 3:

					break;
				case 4:

					break;
				case 5:

					break;
				case 6:
					//int_accion_contribuyente = 0;

					pnl_fusuario.Visible = false;
					//pnl_centro.Visible = false;
					//pnl_inventarios.Visible = true;
					//pnl_categoria.Visible = false;
					//pnl_marca.Visible = false;
					//pnl_linea.Visible = false;
					//pnl_cliente.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					//pnl_usuarios.Visible = false;

					lbl_fuser.Attributes["style"] = "color:dimgray";
					lbl_fcentro.Attributes["style"] = "color:dimgray";
					//i_editacentrof.Attributes["style"] = "color:dimgray";
					lbl_inventario.Attributes["style"] = "color:orangered";
					//lbl_clientes.Attributes["style"] = "color:dimgray";
					lbl_proveedores.Attributes["style"] = "color:dimgray";
					lbl_alumnos.Attributes["style"] = "color:dimgray";
					lbl_usuarios.Attributes["style"] = "color:dimgray";
					lbl_empresa.Attributes["style"] = "color:dimgray";
					//limpia_txt_inventario();

					//i_agrega_inventario.Attributes["style"] = "color:dimgray";
					//i_edita_inventario.Attributes["style"] = "color:dimgray";
					//i_baja_inventario.Attributes["style"] = "color:dimgray";
					break;
				case 7:

					//int_accion_contribuyente = 0;

					pnl_fusuario.Visible = false;
					//pnl_centro.Visible = false;
					//pnl_inventarios.Visible = false;
					//pnl_categoria.Visible = false;
					//pnl_marca.Visible = false;
					//pnl_linea.Visible = false;
					//pnl_cliente.Visible = true;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					//pnl_usuarios.Visible = false;

					lbl_fuser.Attributes["style"] = "color:dimgray";
					lbl_fcentro.Attributes["style"] = "color:dimgray";
					//i_editacentrof.Attributes["style"] = "color:dimgray";
					lbl_inventario.Attributes["style"] = "color:dimgray";
					//lbl_clientes.Attributes["style"] = "color:orangered";
					lbl_proveedores.Attributes["style"] = "color:dimgray";
					lbl_alumnos.Attributes["style"] = "color:dimgray";
					lbl_usuarios.Attributes["style"] = "color:dimgray";
					lbl_empresa.Attributes["style"] = "color:dimgray";
					//limpia_txt_cliente();

					//i_agrega_cliente.Attributes["style"] = "color:dimgray";
					//i_edita_cliente.Attributes["style"] = "color:dimgray";
					//i_baja_cliente.Attributes["style"] = "color:dimgray";

					break;
				case 8:
					

					break;
				case 9:

					//int_accion_contribuyente = 0;

					pnl_fusuario.Visible = false;
					//pnl_centro.Visible = false;
					//pnl_inventarios.Visible = false;
					//pnl_categoria.Visible = false;
					//pnl_marca.Visible = false;
					//pnl_linea.Visible = false;
					//pnl_cliente.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = true;
					//pnl_usuarios.Visible = false;

					lbl_fuser.Attributes["style"] = "color:dimgray";
					lbl_fcentro.Attributes["style"] = "color:dimgray";
					//i_editacentrof.Attributes["style"] = "color:dimgray";
					lbl_inventario.Attributes["style"] = "color:dimgray";
					//lbl_clientes.Attributes["style"] = "color:dimgray";
					lbl_proveedores.Attributes["style"] = "color:dimgray";
					lbl_alumnos.Attributes["style"] = "color:orangered";
					lbl_usuarios.Attributes["style"] = "color:dimgray";
					lbl_empresa.Attributes["style"] = "color:dimgray";
					//limpia_txt_contribuyente();

					//i_agrega_contribuyente.Attributes["style"] = "color:dimgray";
					//i_edita_contribuyente.Attributes["style"] = "color:dimgray";
					//i_baja_contribuyente.Attributes["style"] = "color:dimgray";

					break;
				case 10:

					int_accion_proveedor = 0;

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					//pnl_inventarios.Visible = false;
					//pnl_categoria.Visible = false;
					//pnl_marca.Visible = false;
					//pnl_linea.Visible = false;
					//pnl_cliente.Visible = false;
					pnl_proveedores.Visible = true;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;

					lbl_fuser.Attributes["style"] = "color:dimgray";
					lbl_fcentro.Attributes["style"] = "color:dimgray";
					//i_editacentrof.Attributes["style"] = "color:dimgray";
					lbl_inventario.Attributes["style"] = "color:dimgray";
					//lbl_clientes.Attributes["style"] = "color:dimgray";
					lbl_proveedores.Attributes["style"] = "color:orangered";
					lbl_alumnos.Attributes["style"] = "color:dimgray";
					lbl_usuarios.Attributes["style"] = "color:dimgray";
					lbl_empresa.Attributes["style"] = "color:dimgray";

					limpia_txt_proveedor();

					i_agrega_proveedor.Attributes["style"] = "color:dimgray";
					i_edita_proveedor.Attributes["style"] = "color:dimgray";
			

					break;
				case 11:

					int_accion_alumno = 0;

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					//pnl_inventarios.Visible = false;
					//pnl_categoria.Visible = false;
					//pnl_marca.Visible = false;
					//pnl_linea.Visible = false;
					//pnl_cliente.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = true;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = false;

					lbl_fuser.Attributes["style"] = "color:dimgray";
					lbl_fcentro.Attributes["style"] = "color:dimgray";
					//i_editacentrof.Attributes["style"] = "color:dimgray";
					lbl_inventario.Attributes["style"] = "color:dimgray";
		
					lbl_proveedores.Attributes["style"] = "color:dimgray";
					lbl_alumnos.Attributes["style"] = "color:orangered";
					lbl_usuarios.Attributes["style"] = "color:dimgray";
					lbl_empresa.Attributes["style"] = "color:dimgray";
					limpia_txt_alumnos();

					i_agrega_alumno.Attributes["style"] = "color:dimgray";
					i_edita_alumno.Attributes["style"] = "color:dimgray";

					break;
				case 12:

					int_accion_usuario = 0;

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					//pnl_inventarios.Visible = false;
					//pnl_categoria.Visible = false;
					//pnl_marca.Visible = false;
					//pnl_linea.Visible = false;
					//pnl_cliente.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = true;
					pnl_empresa.Visible = false;

					lbl_fuser.Attributes["style"] = "color:dimgray";
					lbl_fcentro.Attributes["style"] = "color:dimgray";
					//i_editacentrof.Attributes["style"] = "color:dimgray";
					lbl_inventario.Attributes["style"] = "color:dimgray";
			
					lbl_proveedores.Attributes["style"] = "color:dimgray";
					lbl_alumnos.Attributes["style"] = "color:dimgray";
					lbl_usuarios.Attributes["style"] = "color:orangered";
					lbl_empresa.Attributes["style"] = "color:dimgray";
					limpia_txt_usuarios();

					i_agrega_usuario.Attributes["style"] = "color:dimgray";
					i_edita_usuario.Attributes["style"] = "color:dimgray";

					break;
				case 13:

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					//pnl_inventarios.Visible = false;
					//pnl_categoria.Visible = false;
					//pnl_marca.Visible = false;
					//pnl_linea.Visible = false;
					//pnl_cliente.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = true;

					lbl_fuser.Attributes["style"] = "color:dimgray";
					lbl_fcentro.Attributes["style"] = "color:dimgray";
					//i_editacentrof.Attributes["style"] = "color:dimgray";
					lbl_inventario.Attributes["style"] = "color:dimgray";
		
					lbl_proveedores.Attributes["style"] = "color:dimgray";
					lbl_alumnos.Attributes["style"] = "color:dimgray";
					lbl_usuarios.Attributes["style"] = "color:dimgray";

					limpiar_textbox_empresa();

					i_editaempresa.Attributes["style"] = "color:dimgray";
					lbl_empresa.Attributes["style"] = "color:orangered";
					break;
				case 14:

					Session.Abandon();
					Response.Redirect("acceso.aspx");

					break;
				default:

					break;
			}
		}

		#region usuario

		protected void btn_guarda_fusuario_Click(object sender, EventArgs e)
		{
			if (ddl_genero_fusuario.SelectedValue == "0")
			{

				ddl_genero_fusuario.BackColor = Color.IndianRed;
			}
			else
			{
				ddl_genero_fusuario.BackColor = Color.Transparent;
				if (string.IsNullOrEmpty(txt_nombres_fusuario.Text))
				{

					txt_nombres_fusuario.BackColor = Color.IndianRed;
				}
				else
				{
					txt_nombres_fusuario.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_apaterno_fusuario.Text))
					{

						txt_apaterno_fusuario.BackColor = Color.IndianRed;
					}
					else
					{
						txt_apaterno_fusuario.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_amaterno_fusuario.Text))
						{

							txt_amaterno_fusuario.BackColor = Color.IndianRed;
						}
						else
						{
							txt_amaterno_fusuario.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_cumple_fusuario.Text))
							{

								txt_cumple_fusuario.BackColor = Color.IndianRed;
							}
							else
							{
								txt_cumple_fusuario.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_usuario_fusuario.Text))
								{

									txt_usuario_fusuario.BackColor = Color.IndianRed;
								}
								else
								{
									txt_usuario_fusuario.BackColor = Color.Transparent;
									if (string.IsNullOrEmpty(txt_clave_fusuario.Text))
									{

										txt_clave_fusuario.BackColor = Color.IndianRed;
									}
									else
									{
										txt_clave_fusuario.BackColor = Color.Transparent;

										string str_nombres = txt_nombres_fusuario.Text.ToUpper();
										string str_apaterno = txt_apaterno_fusuario.Text.ToUpper();
										string str_amaterno = txt_amaterno_fusuario.Text.ToUpper();

										string str_codigousuario = txt_usuario_fusuario.Text;
										string str_password = encriptacion.Encrypt(txt_clave_fusuario.Text);

										using (var m_fusuario = new db_imEntities())
										{
											var i_fusuario = (from c in m_fusuario.inf_usuarios
															  where c.codigo_usuario == str_codigousuario
															  select c).ToList();

											if (i_fusuario.Count == 0)
											{
												using (var m_fusuariof = new db_imEntities())
												{
													var i_fusuariof = (from c in m_fusuariof.inf_usuarios
																	   where c.codigo_usuario == str_codigousuario
																	   select c).ToList();

													if (i_fusuariof.Count == 0)
													{
														using (var m_fusuarioff = new db_imEntities())
														{
															var i_fusuarioff = (from c in m_fusuarioff.inf_usuarios
																				where c.id_usuario == guid_iduser
																				select c).FirstOrDefault();


															i_fusuarioff.nombres = str_nombres;
															i_fusuarioff.a_paterno = str_apaterno;
															i_fusuarioff.a_materno = str_amaterno;

															i_fusuarioff.codigo_usuario = str_codigousuario;
															i_fusuarioff.clave = str_password;

															m_fusuarioff.SaveChanges();

															limpiar_textbox_fusuario();

															lblModalTitle.Text = "Intelimundo";
															lblModalBody.Text = "Datos de Usuario actualizados con éxito";
															ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
															upModal.Update();
														}
													}
													else
													{
														txt_usuario_fusuario.Text = "";

														lblModalTitle.Text = "Intelimundo";
														lblModalBody.Text = "Código de usuario ya existe en la base de datos, favor de reintentar";
														ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
														upModal.Update();
													}
												}
											}
											else
											{

												i_fusuario[0].nombres = str_nombres;
												i_fusuario[0].a_paterno = str_apaterno;
												i_fusuario[0].a_materno = str_amaterno;

												i_fusuario[0].codigo_usuario = str_codigousuario;
												i_fusuario[0].clave = str_password;

												m_fusuario.SaveChanges();

												limpiar_textbox_fusuario();

												lblModalTitle.Text = "Intelimundo";
												lblModalBody.Text = "Datos de Usuario actualizados con éxito";
												ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
												upModal.Update();
											}
										}
									}
								}

							}

						}
					}
				}
			}


		}

		private void limpiar_textbox_fusuario()
		{

			ddl_genero_fusuario.Items.Clear();

			using (db_imEntities edm_genero = new db_imEntities())
			{
				var i_genero = (from f_tr in edm_genero.fact_genero
								select f_tr).ToList();

				ddl_genero_fusuario.DataSource = i_genero;
				ddl_genero_fusuario.DataTextField = "desc_genero";
				ddl_genero_fusuario.DataValueField = "id_genero";
				ddl_genero_fusuario.DataBind();
			}

			ddl_genero_fusuario.Items.Insert(0, new ListItem("*Género", "0"));

			txt_nombres_fusuario.Text = "";
			txt_apaterno_fusuario.Text = "";
			txt_amaterno_fusuario.Text = "";
			txt_cumple_fusuario.Text = "";
			txt_usuario_fusuario.Text = "";
			txt_clave_fusuario.Text = "";


			txt_nombres_fusuario.BackColor = Color.White;
			txt_apaterno_fusuario.BackColor = Color.White;
			txt_amaterno_fusuario.BackColor = Color.White;
			//txt_cumple_fusuario.BackColor = Color.White;
			txt_usuario_fusuario.BackColor = Color.White;
			txt_clave_fusuario.BackColor = Color.White;
		}

		protected void lkb_editar_fusuario_Click(object sender, EventArgs e)
		{
			i_editausuariof.Attributes["style"] = "color:orangered";

			try
			{

				using (db_imEntities m_fusuario = new db_imEntities())
				{
					var i_fusuario = (from i_c in m_fusuario.inf_usuarios
									  where i_c.id_usuario == guid_iduser
									  select new
									  {
										  i_c.id_genero,
										  i_c.nombres,
										  i_c.a_paterno,
										  i_c.a_materno,
										  i_c.fecha_nacimiento,
										  i_c.codigo_usuario,
										  i_c.clave,

									  }).FirstOrDefault();

					ddl_genero_fusuario.SelectedValue = i_fusuario.id_genero.ToString();
					txt_nombres_fusuario.Text = i_fusuario.nombres;
					txt_apaterno_fusuario.Text = i_fusuario.a_paterno;
					txt_amaterno_fusuario.Text = i_fusuario.a_materno;
					txt_cumple_fusuario.Text = DateTime.Parse(i_fusuario.fecha_nacimiento.ToString()).ToShortDateString();
					txt_usuario_fusuario.Text = i_fusuario.codigo_usuario;
					txt_clave_fusuario.Text = i_fusuario.clave;

				}
			}
			catch
			{

			}
		}

		#endregion

		#region centro
		protected void lkb_editar_centro_Click(object sender, EventArgs e)
		{
			i_editacentrof.Attributes["style"] = "color:orangered";

			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from i_u in data_user.inf_centro
								where i_u.id_centro == guid_centro
								select new
								{
									i_u.id_licencia,
									i_u.nombre,
									i_u.telefono,
									i_u.email,
									i_u.callenum,
									i_u.id_codigo,


								}).FirstOrDefault();

				ddl_licencias_centro.SelectedValue = inf_user.id_licencia.ToString();
				txt_nombre_centro.Text = inf_user.nombre;
				txt_telefono_centro.Text = inf_user.telefono;
				txt_email_centro.Text = inf_user.email;
				txt_callenum_centro.Text = inf_user.callenum;



				using (db_imEntities db_sepomex = new db_imEntities())
				{
					var tbl_sepomex = (from c in db_sepomex.inf_sepomex
									   where c.id_codigo == inf_user.id_codigo
									   select c).ToList();

					ddl_colonia_centro.DataSource = tbl_sepomex;
					ddl_colonia_centro.DataTextField = "d_asenta";
					ddl_colonia_centro.DataValueField = "id_asenta_cpcons";
					ddl_colonia_centro.DataBind();

					txt_cp_centro.Text = tbl_sepomex[0].d_codigo;
					txt_municipio_centro.Text = tbl_sepomex[0].D_mnpio;
					txt_estado_centro.Text = tbl_sepomex[0].d_estado;
				}

			}
		}
		protected void btn_guarda_centro_Click(object sender, EventArgs e)
		{
			if (ddl_licencias_centro.SelectedValue == "0")
			{

				ddl_licencias_centro.BackColor = Color.IndianRed;
			}
			else
			{
				ddl_licencias_centro.BackColor = Color.Transparent;
				if (string.IsNullOrEmpty(txt_nombre_centro.Text))
				{

					txt_nombre_centro.BackColor = Color.IndianRed;
				}
				else
				{
					txt_nombre_centro.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_telefono_centro.Text))
					{

						txt_telefono_centro.BackColor = Color.IndianRed;
					}
					else
					{
						txt_telefono_centro.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_email_centro.Text))
						{

							txt_email_centro.BackColor = Color.IndianRed;
						}
						else
						{
							txt_email_centro.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_callenum_centro.Text))
							{

								txt_callenum_centro.BackColor = Color.IndianRed;
							}
							else
							{
								txt_callenum_centro.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_cp_centro.Text))
								{

									txt_cp_centro.BackColor = Color.IndianRed;
								}
								else
								{
									txt_cp_centro.BackColor = Color.Transparent;
									if (ddl_colonia_centro.SelectedValue == "0")
									{

										ddl_colonia_centro.BackColor = Color.IndianRed;
									}
									else
									{
										ddl_colonia_centro.BackColor = Color.Transparent;
										guarda_centro();
									}
								}
							}
						}
					}
				}
			}
		}

		private void guarda_centro()
		{

			Guid guid_ncentro = Guid.NewGuid();
			string str_corporativo = txt_nombre_centro.Text.ToUpper();

			string str_telefono = txt_telefono_centro.Text;
			string str_email = txt_email_centro.Text;
			string str_callenum = txt_callenum_centro.Text.ToUpper();
			string str_cp = txt_cp_centro.Text;
			int int_colony = Convert.ToInt32(ddl_colonia_centro.SelectedValue);
			int int_idcodigocp;

			using (db_imEntities db_sepomex = new db_imEntities())
			{
				var tbl_sepomex = (from c in db_sepomex.inf_sepomex
								   where c.d_codigo == str_cp
								   where c.id_asenta_cpcons == int_colony
								   select c).ToList();

				int_idcodigocp = tbl_sepomex[0].id_codigo;
			}

			using (var m_fempresa = new db_imEntities())
			{
				var i_fempresa = (from c in m_fempresa.inf_centro
								  where c.id_centro == guid_centro
								  select c).FirstOrDefault();

				i_fempresa.id_licencia = 4;
				i_fempresa.nombre = str_corporativo;
				i_fempresa.telefono = str_telefono;
				i_fempresa.email = str_email;
				i_fempresa.callenum = str_callenum;
				i_fempresa.id_codigo = int_idcodigocp;

				m_fempresa.SaveChanges();
			}

			limpia_txt_centro();

			lblModalTitle.Text = "Intelimundo";
			lblModalBody.Text = "Datos de Centro actualizados con éxito";
			ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
			upModal.Update();
		}


		protected void btn_cp_centro_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_cp_centro.Text))
			{

				txt_cp_centro.BackColor = Color.IndianRed;
			}
			else
			{
				txt_cp_centro.BackColor = Color.Transparent;

				string str_codigo = txt_cp_centro.Text;

				using (db_imEntities db_sepomex = new db_imEntities())
				{
					var tbl_sepomex = (from c in db_sepomex.inf_sepomex
									   where c.d_codigo == str_codigo
									   select c).ToList();

					ddl_colonia_centro.DataSource = tbl_sepomex;
					ddl_colonia_centro.DataTextField = "d_asenta";
					ddl_colonia_centro.DataValueField = "id_asenta_cpcons";
					ddl_colonia_centro.DataBind();

					if (tbl_sepomex.Count == 1)
					{


						txt_municipio_centro.Text = tbl_sepomex[0].D_mnpio;
						txt_estado_centro.Text = tbl_sepomex[0].d_estado;
					}
					if (tbl_sepomex.Count > 1)
					{

						ddl_colonia_centro.Items.Insert(0, new ListItem("*Colonia", "0"));

						txt_municipio_centro.Text = tbl_sepomex[0].D_mnpio;
						txt_estado_centro.Text = tbl_sepomex[0].d_estado;
					}
					else if (tbl_sepomex.Count == 0)
					{

						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Error de Código Postal, favor de reintentar";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();

					}
				}
			}

		}
		private void limpia_txt_centro()
		{
			using (db_imEntities m_tiporfc = new db_imEntities())
			{
				var i_tiporfc = (from f_tr in m_tiporfc.fact_licencias
								 select f_tr).ToList();

				ddl_licencias_centro.DataSource = i_tiporfc;
				ddl_licencias_centro.DataTextField = "desc_licencia";
				ddl_licencias_centro.DataValueField = "id_licencia";
				ddl_licencias_centro.DataBind();
			}

			ddl_licencias_centro.Items.Insert(0, new ListItem("*Licencia", "0"));
			ddl_licencias_centro.SelectedValue = "0";

			ddl_colonia_centro.Items.Clear();
			ddl_colonia_centro.Items.Insert(0, new ListItem("*Colonia", "0"));
			ddl_colonia_centro.SelectedValue = "0";

			txt_nombre_centro.Text = "";
			txt_telefono_centro.Text = "";
			txt_email_centro.Text = "";
			txt_callenum_centro.Text = "";
			txt_cp_centro.Text = "";
			txt_municipio_centro.Text = "";
			txt_estado_centro.Text = "";

			ddl_licencias_centro.BackColor = Color.White;
			txt_nombre_centro.BackColor = Color.White;
			txt_telefono_centro.BackColor = Color.White;
			txt_email_centro.BackColor = Color.White;
			txt_callenum_centro.BackColor = Color.White;
			txt_cp_centro.BackColor = Color.White;
			ddl_colonia_centro.BackColor = Color.White;
			txt_municipio_centro.BackColor = Color.White;
			txt_estado_centro.BackColor = Color.White;

		}
		#endregion

		#region alumnos

		protected void lkbtn_nuevo_alumno_Click(object sender, EventArgs e)
		{
			int_accion_alumno = 1;
			i_agrega_alumno.Attributes["style"] = "color:orangered";
			i_edita_alumno.Attributes["style"] = "color:dimgray";

			limpia_txt_alumnos();

			gv_alumnos.Visible = false;
			txt_buscar_alumno.Visible = false;
			btn_busca_alumno.Visible = false;
			ddl_perfil.Visible = false;
			chkb_activar_alumno.Visible = false;
		}
		protected void lkbtn_edita_alumno_Click(object sender, EventArgs e)
		{
			int_accion_alumno = 2;
			i_agrega_alumno.Attributes["style"] = "color:dimgray";
			i_edita_alumno.Attributes["style"] = "color:orangered";

			limpia_txt_alumnos();
			grid_alumnos(8);
			txt_buscar_alumno.Visible = true;
			btn_busca_alumno.Visible = true;


			chkb_activar_alumno.Visible = true;

		}
		protected void lkbtn_baja_alumno_Click(object sender, EventArgs e)
		{
			int_accion_alumno = 3;
			i_agrega_alumno.Attributes["style"] = "color:dimgray";
			i_edita_alumno.Attributes["style"] = "color:dimgray";

			limpia_txt_alumnos();

			txt_buscar_alumno.Visible = true;
			btn_busca_alumno.Visible = true;
			gv_alumnos.Visible = false;
			ddl_perfil.Visible = true;
			chkb_activar_alumno.Visible = true;


		}
		protected void btn_busca_alumno_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_buscar_alumno.Text))
			{

				txt_buscar_alumno.BackColor = Color.IndianRed;
			}
			else
			{
				txt_buscar_alumno.BackColor = Color.Transparent;

				string str_userb = txt_buscar_alumno.Text;



				using (db_imEntities data_user = new db_imEntities())
				{
					var inf_user = (from u in data_user.inf_alumnos
									join est in data_user.fact_estatus on u.id_estatus equals est.id_estatus
									where u.nombres.Contains(str_userb)
									where u.id_estatus == 1

									select new
									{
										u.codigo_alumno,
										est.desc_estatus,

										u.nombres,
										u.a_paterno,
										u.a_materno,
										u.fecha_registro

									}).ToList();

					if (inf_user.Count == 0)
					{
						gv_alumnos.DataSource = inf_user;
						gv_alumnos.DataBind();
						gv_alumnos.Visible = true;

						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "alumno no exite o tiene un perfil diferente";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();


					}
					else
					{
						gv_alumnos.DataSource = inf_user;
						gv_alumnos.DataBind();
						gv_alumnos.Visible = true;
					}
				}
			}
		}

		protected void btn_guardar_alumno_Click(object sender, EventArgs e)
		{
			if (int_accion_alumno == 0)
			{
				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Favor de seleccionar una acción";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();
			}
			else
			{

				if (ddl_genero_alumno.SelectedValue == "0")
				{

					ddl_genero_alumno.BackColor = Color.IndianRed;
				}
				else
				{
					ddl_genero_alumno.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_nombres_alumno.Text))
					{

						txt_nombres_alumno.BackColor = Color.IndianRed;
					}
					else
					{
						txt_nombres_alumno.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_apaterno_alumno.Text))
						{

							txt_apaterno_alumno.BackColor = Color.IndianRed;
						}
						else
						{
							txt_apaterno_alumno.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_amaterno_alumno.Text))
							{

								txt_amaterno_alumno.BackColor = Color.IndianRed;
							}
							else
							{
								txt_amaterno_alumno.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_fecna_alumno.Text))
								{

									txt_fecna_alumno.BackColor = Color.IndianRed;
								}
								else
								{
									txt_fecna_alumno.BackColor = Color.Transparent;
									if (string.IsNullOrEmpty(txt_alumno_alumno.Text))
									{

										txt_alumno_alumno.BackColor = Color.IndianRed;
									}
									else
									{
										txt_alumno_alumno.BackColor = Color.Transparent;
										if (string.IsNullOrEmpty(txt_clave_alumno.Text))
										{

											txt_clave_alumno.BackColor = Color.IndianRed;
										}
										else
										{
											txt_clave_alumno.BackColor = Color.Transparent;

											guarda_registro_alumno();

										}
									}
								}


							}
						}
					}
				}



			}





		}
		protected void gv_alumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{

		}
		protected void chk_alumno_CheckedChanged(object sender, EventArgs e)
		{
			Guid id_fuser;
			foreach (GridViewRow row in gv_alumnos.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkRow = (row.Cells[0].FindControl("chk_alumno") as CheckBox);
					if (chkRow.Checked)
					{
						row.BackColor = Color.YellowGreen;
						string codeuser = row.Cells[1].Text;

						using (db_imEntities data_user = new db_imEntities())
						{
							var items_user = (from c in data_user.inf_alumnos
											  where c.codigo_alumno == codeuser
											  select c).FirstOrDefault();

							id_fuser = items_user.id_alumno;
						}

						using (db_imEntities data_user = new db_imEntities())
						{
							var inf_user = (from u in data_user.inf_alumnos
											where u.id_alumno == id_fuser
											select new
											{

												u.nombres,
												u.a_paterno,
												u.a_materno,
												u.id_genero,
												u.fecha_nacimiento,
												u.codigo_alumno,
												u.clave

											}).FirstOrDefault();

							DateTime dt_fecnac = DateTime.Parse(inf_user.fecha_nacimiento.ToString());

							txt_nombres_alumno.Text = inf_user.nombres;
							txt_apaterno_alumno.Text = inf_user.a_paterno;
							txt_amaterno_alumno.Text = inf_user.a_materno;
							ddl_genero_alumno.SelectedValue = inf_user.id_genero.ToString();
							txt_fecna_alumno.Text = dt_fecnac.ToShortDateString();
							txt_alumno_alumno.Text = inf_user.codigo_alumno;
							txt_clave_alumno.Text = inf_user.clave;
						}

					}
					else
					{
						row.BackColor = Color.White;
					}
				}
			}
		}
		private void grid_alumnos(int idtipoalumno)
		{
			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from i_u in data_user.inf_alumnos
								join i_e in data_user.fact_estatus on i_u.id_estatus equals i_e.id_estatus
								where i_u.id_centro == guid_centro
								select new
								{
									i_u.codigo_alumno,
									i_e.desc_estatus,

									i_u.nombres,
									i_u.a_paterno,
									i_u.a_materno,
									i_u.fecha_registro

								}).ToList();

				gv_alumnos.DataSource = inf_user;
				gv_alumnos.DataBind();
				gv_alumnos.Visible = true;
			}
		}
		protected void btn_genera_alumno_Click(object sender, EventArgs e)
		{

			if (ddl_genero_alumno.SelectedValue == "0")
			{

				ddl_genero_alumno.BackColor = Color.IndianRed;
			}
			else
			{
				ddl_genero_alumno.BackColor = Color.Transparent;
				if (string.IsNullOrEmpty(txt_nombres_alumno.Text))
				{

					txt_nombres_alumno.BackColor = Color.IndianRed;
				}
				else
				{
					txt_nombres_alumno.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_apaterno_alumno.Text))
					{

						txt_apaterno_alumno.BackColor = Color.IndianRed;
					}
					else
					{
						txt_apaterno_alumno.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_amaterno_alumno.Text))
						{

							txt_amaterno_alumno.BackColor = Color.IndianRed;
						}
						else
						{
							txt_amaterno_alumno.BackColor = Color.Transparent;
							genera_alumno();
						}
					}
				}
			}

		}
		private void guarda_registro_alumno()
		{
			Guid guid_falumno;
			Guid guid_nalumno = Guid.NewGuid();
			int int_genero = int.Parse(ddl_genero_alumno.SelectedValue);
			string str_nombres = txt_nombres_alumno.Text.ToUpper();
			string str_apaterno = txt_apaterno_alumno.Text.ToUpper();
			string str_amaterno = txt_amaterno_alumno.Text.ToUpper();
			DateTime dt_fecna = DateTime.Parse(txt_fecna_alumno.Text);
			string str_alumno = txt_alumno_alumno.Text;
			string str_password = encriptacion.Encrypt(txt_clave_alumno.Text);




			if (int_accion_alumno == 1)
			{
				using (db_imEntities data_user = new db_imEntities())
				{
					var items_user = (from c in data_user.inf_alumnos
									  where c.codigo_alumno == str_alumno
									  select c).ToList();

					if (items_user.Count == 0)
					{

						using (var m_alumno = new db_imEntities())
						{
							var i_alumno = new inf_alumnos
							{
								id_alumno = guid_nalumno,
								id_genero = int_genero,
								id_estatus = 1,
								fecha_nacimiento = dt_fecna,
								id_tipo_usuario = 8,
								nombres = str_nombres,
								a_paterno = str_apaterno,
								a_materno = str_amaterno,
								codigo_alumno = str_alumno,
								clave = str_password,
								fecha_registro = DateTime.Now,
								id_centro = guid_centro
							};
							m_alumno.inf_alumnos.Add(i_alumno);
							m_alumno.SaveChanges();
						}

						using (var m_centro = new db_imEntities())
						{
							var i_centro = new inf_centro_dep

							{
								id_centro = guid_centro,
								id_usuario = guid_nalumno
							};

							m_centro.inf_centro_dep.Add(i_centro);
							m_centro.SaveChanges();
						}
						int_accion_alumno = 0;
						limpia_txt_alumnos();
						i_agrega_alumno.Attributes["style"] = "color:dimgray";
						i_edita_alumno.Attributes["style"] = "color:dimgray";


						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Datos de alumno agregados con éxito";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();
					}
					else
					{
						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "alumno ya existe en la base de datos, favor de reintentar";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();
					}
				}

			}
			else if (int_accion_alumno == 2)
			{

				int int_activar;

				if (chkb_activar_alumno.Checked == true)
				{
					int_activar = 3;
				}
				else
				{
					int_activar = 1;
				}
				foreach (GridViewRow row in gv_alumnos.Rows)
				{
					if (row.RowType == DataControlRowType.DataRow)
					{
						CheckBox chkRow = (row.Cells[0].FindControl("chk_alumno") as CheckBox);
						if (chkRow.Checked)
						{
							row.BackColor = Color.YellowGreen;
							string codeuser = row.Cells[1].Text;

							if (codeuser == str_alumno)
							{
								using (db_imEntities data_user = new db_imEntities())
								{
									var items_user = (from c in data_user.inf_alumnos
													  where c.codigo_alumno == codeuser
													  select c).FirstOrDefault();

									guid_falumno = items_user.id_alumno;
								}
								using (var data_user = new db_imEntities())
								{
									var items_user = (from c in data_user.inf_alumnos
													  where c.id_alumno == guid_falumno
													  select c).FirstOrDefault();

									items_user.id_estatus = int_activar;
									items_user.id_genero = int_genero;
									items_user.nombres = str_nombres;
									items_user.a_paterno = str_apaterno;
									items_user.a_materno = str_amaterno;
									items_user.fecha_nacimiento = dt_fecna;
									items_user.codigo_alumno = str_alumno;
									items_user.clave = str_password;

									data_user.SaveChanges();
								}
								int_accion_alumno = 0;
								limpia_txt_alumnos();

								grid_alumnos(8);

								txt_buscar_alumno.Text = "";


								lblModalTitle.Text = "Intelimundo";
								lblModalBody.Text = "Datos de alumno actualizados con éxito";
								ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
								upModal.Update();
							}
							else
							{
								using (db_imEntities data_user = new db_imEntities())
								{
									var items_user = (from c in data_user.inf_alumnos
													  where c.codigo_alumno == str_alumno
													  select c).ToList();

									if (items_user.Count == 0)
									{
										using (db_imEntities data_userf = new db_imEntities())
										{
											var items_userf = (from c in data_userf.inf_alumnos
															   where c.codigo_alumno == codeuser
															   select c).FirstOrDefault();

											guid_falumno = items_userf.id_alumno;
										}
										using (var data_userff = new db_imEntities())
										{
											var items_userff = (from c in data_userff.inf_alumnos
																where c.id_alumno == guid_falumno
																select c).FirstOrDefault();

											items_userff.nombres = str_nombres;
											items_userff.a_paterno = str_apaterno;
											items_userff.a_materno = str_amaterno;
											items_userff.codigo_alumno = str_alumno;
											items_userff.clave = str_password;
											data_userff.SaveChanges();
										}

										limpia_txt_alumnos();

										grid_alumnos(8);

										txt_buscar_alumno.Text = "";


										lblModalTitle.Text = "Intelimundo";
										lblModalBody.Text = "Datos de alumno actualizados con éxito";
										ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
										upModal.Update();

									}
									else
									{
										lblModalTitle.Text = "Intelimundo";
										lblModalBody.Text = "alumno ya existe en la base de datos, favor de reintentar";
										ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
										upModal.Update();
									}
								}
							}


						}
						else
						{
							row.BackColor = Color.White;
						}
					}
				}
			}
			else if (int_accion_alumno == 3)
			{
				foreach (GridViewRow row in gv_alumnos.Rows)
				{
					if (row.RowType == DataControlRowType.DataRow)
					{
						CheckBox chkRow = (row.Cells[0].FindControl("chk_alumno") as CheckBox);
						if (chkRow.Checked)
						{
							row.BackColor = Color.YellowGreen;
							string codeuser = row.Cells[1].Text;

							using (db_imEntities data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_alumnos
												  where c.codigo_alumno == codeuser
												  select c).FirstOrDefault();

								guid_falumno = items_user.id_alumno;
							}
							using (var data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_alumnos
												  where c.id_alumno == guid_falumno
												  select c).FirstOrDefault();

								items_user.id_estatus = 3;

								data_user.SaveChanges();
							}
							int_accion_alumno = 0;
							limpia_txt_alumnos();

							grid_alumnos(8);

							txt_buscar_alumno.Text = "";


							lblModalTitle.Text = "Intelimundo";
							lblModalBody.Text = "alumno dado de baja con éxito";
							ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
							upModal.Update();
						}
						else
						{
							row.BackColor = Color.White;
						}
					}
				}
			}
		}
		private void genera_alumno()
		{
			try
			{
				int nombres_count = txt_nombres_alumno.Text.Split(' ').Count();
				string str_nombres = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_nombres_alumno.Text.ToLower()));
				string[] separados;

				separados = str_nombres.Split(" ".ToArray());
				int count = separados.Count();

				string str_apaterno = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_apaterno_alumno.Text.ToLower()));
				string str_amaterno = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_amaterno_alumno.Text.ToLower()));

				string codigo_alumno = str_nombres + "_" + left_right_mid.left(str_apaterno, 2) + left_right_mid.left(str_amaterno, 2);
				txt_alumno_alumno.Text = codigo_alumno;
			}
			catch
			{
				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Se requiere minimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el alumno";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();
			}
		}

		private void limpia_txt_alumnos()
		{
			ddl_genero_alumno.Items.Clear();
			using (db_imEntities m_genero = new db_imEntities())
			{
				var i_genero = (from f_tr in m_genero.fact_genero
								select f_tr).ToList();

				ddl_genero_alumno.DataSource = i_genero;
				ddl_genero_alumno.DataTextField = "desc_genero";
				ddl_genero_alumno.DataValueField = "id_genero";
				ddl_genero_alumno.DataBind();
			}
			ddl_genero_alumno.Items.Insert(0, new ListItem("*GÉNERO", "0"));


			txt_nombres_alumno.Text = "";
			txt_apaterno_alumno.Text = "";
			txt_amaterno_alumno.Text = "";
			txt_alumno_alumno.Text = "";
			txt_clave_alumno.Text = "";
			txt_fecna_alumno.Text = "";
			txt_buscar_alumno.Text = "";
			gv_alumnos.Visible = false;

			ddl_genero_alumno.BackColor = Color.Transparent;
			txt_nombres_alumno.BackColor = Color.Transparent;
			txt_apaterno_alumno.BackColor = Color.Transparent;
			txt_apaterno_alumno.BackColor = Color.Transparent;
			txt_fecna_alumno.BackColor = Color.Transparent;
			txt_alumno_alumno.BackColor = Color.Transparent;
			txt_clave_alumno.BackColor = Color.Transparent;



		}

		#endregion

		#region proveedor
		protected void lkbtn_nuevo_proveedor_Click(object sender, EventArgs e)
		{
			int_accion_proveedor = 1;
			i_agrega_proveedor.Attributes["style"] = "color:orangered";
			i_edita_proveedor.Attributes["style"] = "color:dimgray";
			i_baja_proveedor.Attributes["style"] = "color:dimgray";
			limpia_txt_proveedor();

			txt_buscar_proveedor.Visible = false;
			btn_buscar_proveedor.Visible = false;
			gv_proveedor.Visible = false;
		}
		protected void lkbtn_edita_proveedor_Click(object sender, EventArgs e)
		{
			int_accion_proveedor = 2;
			i_agrega_proveedor.Attributes["style"] = "color:dimgray";
			i_edita_proveedor.Attributes["style"] = "color:orangered";
			i_baja_proveedor.Attributes["style"] = "color:dimgray";
			limpia_txt_proveedor();

			txt_buscar_proveedor.Visible = true;
			btn_buscar_proveedor.Visible = true;

			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from i_u in data_user.inf_proveedor
								join i_e in data_user.fact_tipo_rfc on i_u.id_tipo_rfc equals i_e.id_tipo_rfc
								where i_u.id_estatus == 1

								select new
								{
									i_u.rfc,
									i_e.desc_tipo_rfc,
									i_u.razon_social,
									i_u.fecha_registro

								}).ToList();

				gv_proveedor.DataSource = inf_user;
				gv_proveedor.DataBind();
				gv_proveedor.Visible = true;
			}
		}
		protected void lkbtn_baja_proveedor_Click(object sender, EventArgs e)

		{
			int_accion_proveedor = 3;
			i_agrega_proveedor.Attributes["style"] = "color:dimgray";
			i_edita_proveedor.Attributes["style"] = "color:dimgray";
			i_baja_proveedor.Attributes["style"] = "color:orangered";
			limpia_txt_proveedor();

			txt_buscar_proveedor.Visible = true;
			btn_buscar_proveedor.Visible = true;

			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from i_u in data_user.inf_proveedor
								join i_e in data_user.fact_tipo_rfc on i_u.id_tipo_rfc equals i_e.id_tipo_rfc
								where i_u.id_estatus == 1

								select new
								{
									i_u.rfc,
									i_e.desc_tipo_rfc,
									i_u.razon_social,
									i_u.fecha_registro

								}).ToList();

				gv_proveedor.DataSource = inf_user;
				gv_proveedor.DataBind();
				gv_proveedor.Visible = true;
			}
		}

		protected void btn_buscar_proveedor_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_buscar_proveedor.Text))
			{

				txt_buscar_proveedor.BackColor = Color.IndianRed;
			}
			else
			{
				txt_buscar_proveedor.BackColor = Color.Transparent;

				string str_userb = txt_buscar_usuario.Text;


				using (db_imEntities data_user = new db_imEntities())
				{
					var inf_user = (from i_u in data_user.inf_proveedor
									join i_e in data_user.fact_tipo_rfc on i_u.id_tipo_rfc equals i_e.id_tipo_rfc
									where i_u.razon_social.Contains(str_userb)
									where i_u.id_estatus == 1

									select new
									{
										i_u.rfc,
										i_e.desc_tipo_rfc,
										i_u.razon_social,
										i_u.fecha_registro

									}).ToList();

					gv_proveedor.DataSource = inf_user;
					gv_proveedor.DataBind();
					gv_proveedor.Visible = true;
				}

			}

		}
		protected void gv_proveedor_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{

		}
		protected void chk_proveedor_CheckedChanged(object sender, EventArgs e)
		{
			foreach (GridViewRow row in gv_proveedor.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkRow = (row.Cells[0].FindControl("chk_proveedor") as CheckBox);
					if (chkRow.Checked)
					{
						row.BackColor = Color.YellowGreen;
						string codeuser = row.Cells[1].Text;

						using (db_imEntities data_user = new db_imEntities())
						{
							var items_user = (from c in data_user.inf_proveedor
											  where c.rfc == codeuser
											  select c).FirstOrDefault();

							guid_idproveedor = items_user.id_proveedor;
						}

						using (db_imEntities data_user = new db_imEntities())
						{
							var inf_user = (from i_u in data_user.inf_proveedor
											where i_u.id_proveedor == guid_idproveedor
											select new
											{
												i_u.id_tipo_rfc,
												i_u.rfc,
												i_u.razon_social,
												i_u.telefono,
												i_u.email,
												i_u.callenum,
												i_u.id_codigo,


											}).FirstOrDefault();



							ddl_tipo_rfc_proveedor.Text = inf_user.id_tipo_rfc.ToString();
							txt_rfc_proveedor.Text = inf_user.rfc;
							txt_empresa_proveedor.Text = inf_user.razon_social;
							txt_telefono_proveedor.Text = inf_user.telefono;
							txt_email_proveedor.Text = inf_user.email;
							txt_callenum_proveedor.Text = inf_user.callenum;



							using (db_imEntities db_sepomex = new db_imEntities())
							{
								var tbl_sepomex = (from c in db_sepomex.inf_sepomex
												   where c.id_codigo == inf_user.id_codigo
												   select c).ToList();

								ddl_colonia_proveedor.DataSource = tbl_sepomex;
								ddl_colonia_proveedor.DataTextField = "d_asenta";
								ddl_colonia_proveedor.DataValueField = "id_asenta_cpcons";
								ddl_colonia_proveedor.DataBind();

								txt_cp_proveedor.Text = tbl_sepomex[0].d_codigo;
								txt_municipio_proveedor.Text = tbl_sepomex[0].D_mnpio;
								txt_estado_proveedor.Text = tbl_sepomex[0].d_estado;
							}

						}

						using (db_imEntities data_user = new db_imEntities())
						{
							var inf_user = (from i_u in data_user.inf_contacto_proveedor
											where i_u.id_proveedor == guid_idproveedor
											select new
											{
												i_u.nombres,
												i_u.a_paterno,
												i_u.a_materno,
												i_u.telefono,
												i_u.email,

											}).FirstOrDefault();

							txt_nombres_cproveedor.Text = inf_user.nombres;
							txt_apaterno_cproveedor.Text = inf_user.a_paterno;
							txt_amaterno_cproveedor.Text = inf_user.a_materno;
							txt_telefono_cproveedor.Text = inf_user.telefono;
							txt_email_cproveedor.Text = inf_user.email;

						}

					}
					else
					{
						row.BackColor = Color.White;

					}
				}
			}
		}
		protected void btn_cp_proveedor_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_cp_proveedor.Text))
			{

				txt_cp_proveedor.BackColor = Color.IndianRed;
			}
			else
			{
				txt_cp_proveedor.BackColor = Color.Transparent;

				string str_codigo = txt_cp_proveedor.Text;

				using (db_imEntities db_sepomex = new db_imEntities())
				{
					var tbl_sepomex = (from c in db_sepomex.inf_sepomex
									   where c.d_codigo == str_codigo
									   select c).ToList();

					ddl_colonia_proveedor.DataSource = tbl_sepomex;
					ddl_colonia_proveedor.DataTextField = "d_asenta";
					ddl_colonia_proveedor.DataValueField = "id_asenta_cpcons";
					ddl_colonia_proveedor.DataBind();

					if (tbl_sepomex.Count == 1)
					{


						txt_municipio_proveedor.Text = tbl_sepomex[0].D_mnpio;
						txt_estado_proveedor.Text = tbl_sepomex[0].d_estado;
					}
					if (tbl_sepomex.Count > 1)
					{

						ddl_colonia_proveedor.Items.Insert(0, new ListItem("*Colonia", "0"));

						txt_municipio_proveedor.Text = tbl_sepomex[0].D_mnpio;
						txt_estado_proveedor.Text = tbl_sepomex[0].d_estado;
					}
					else if (tbl_sepomex.Count == 0)
					{

						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Error de Código Postal, favor de reintentar";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();

					}
				}
			}
		}
		protected void btn_guardar_proveedor_Click(object sender, EventArgs e)
		{
			if (int_accion_proveedor == 0)
			{

				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Favor de seleccionar una acción";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();
			}
			else
			{

				if (ddl_tipo_rfc_proveedor.SelectedValue == "0")
				{
					ddl_tipo_rfc_proveedor.BackColor = Color.IndianRed;
				}
				else
				{
					ddl_tipo_rfc_proveedor.BackColor = Color.White;
					if (string.IsNullOrEmpty(txt_rfc_proveedor.Text))
					{

						txt_rfc_proveedor.BackColor = Color.IndianRed;
					}
					else
					{
						txt_rfc_proveedor.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_empresa_proveedor.Text))
						{

							txt_empresa_proveedor.BackColor = Color.IndianRed;
						}
						else
						{
							txt_empresa_proveedor.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_telefono_proveedor.Text))
							{

								txt_telefono_proveedor.BackColor = Color.IndianRed;
							}
							else
							{
								txt_telefono_proveedor.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_email_proveedor.Text))
								{

									txt_email_proveedor.BackColor = Color.IndianRed;
								}
								else
								{
									txt_email_proveedor.BackColor = Color.Transparent;
									if (string.IsNullOrEmpty(txt_callenum_proveedor.Text))
									{

										txt_callenum_proveedor.BackColor = Color.IndianRed;
									}
									else
									{
										txt_callenum_proveedor.BackColor = Color.Transparent;
										if (string.IsNullOrEmpty(txt_cp_proveedor.Text))
										{

											txt_cp_proveedor.BackColor = Color.IndianRed;
										}
										else
										{
											txt_cp_proveedor.BackColor = Color.Transparent;
											if (ddl_colonia_proveedor.SelectedValue == "0")
											{
												ddl_colonia_proveedor.BackColor = Color.IndianRed;
											}
											else
											{
												ddl_colonia_proveedor.BackColor = Color.White;
												if (string.IsNullOrEmpty(txt_nombres_cproveedor.Text))
												{

													txt_nombres_cproveedor.BackColor = Color.IndianRed;
												}
												else
												{
													txt_nombres_cproveedor.BackColor = Color.Transparent;
													if (string.IsNullOrEmpty(txt_apaterno_cproveedor.Text))
													{

														txt_apaterno_cproveedor.BackColor = Color.IndianRed;
													}
													else
													{
														txt_apaterno_cproveedor.BackColor = Color.Transparent;
														if (string.IsNullOrEmpty(txt_amaterno_cproveedor.Text))
														{

															txt_amaterno_cproveedor.BackColor = Color.IndianRed;
														}
														else
														{
															txt_amaterno_cproveedor.BackColor = Color.Transparent;
															if (string.IsNullOrEmpty(txt_telefono_cproveedor.Text))
															{

																txt_telefono_cproveedor.BackColor = Color.IndianRed;
															}
															else
															{
																txt_telefono_cproveedor.BackColor = Color.Transparent;
																if (string.IsNullOrEmpty(txt_email_cproveedor.Text))
																{

																	txt_email_cproveedor.BackColor = Color.IndianRed;
																}
																else
																{
																	txt_email_cproveedor.BackColor = Color.Transparent;

																	guardar_proveedor();

																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		private void guardar_proveedor()
		{
			Guid guid_nrs = Guid.NewGuid();
			int int_tiporfc = int.Parse(ddl_tipo_rfc_proveedor.SelectedValue);
			string str_rfc = txt_rfc_proveedor.Text.ToUpper();
			string str_rs = txt_empresa_proveedor.Text.ToUpper();
			string str_telefono = txt_telefono_proveedor.Text;
			string str_email = txt_email_proveedor.Text;
			string str_callenum = txt_callenum_proveedor.Text.ToUpper();
			string str_cp = txt_cp_proveedor.Text;
			int int_idcolonia = int.Parse(ddl_colonia_proveedor.SelectedValue);
			int int_idcodigocp;
			Guid guid_ncproveedor = Guid.NewGuid();
			string str_nombres = txt_nombres_cproveedor.Text.ToUpper();
			string str_apaterno = txt_apaterno_cproveedor.Text.ToUpper();
			string str_amaterno = txt_amaterno_cproveedor.Text.ToUpper();
			string str_telefonoc = txt_telefono_cproveedor.Text;
			string str_emailc = txt_email_cproveedor.Text;
						using (db_imEntities db_sepomex = new db_imEntities())
				{
					var tbl_sepomex = (from c in db_sepomex.inf_sepomex
									   where c.d_codigo == str_cp
									   where c.id_asenta_cpcons == int_idcolonia
									   select c).ToList();

					int_idcodigocp = tbl_sepomex[0].id_codigo;
				}


			if (int_accion_proveedor == 1)
			{



				using (var m_usuario = new db_imEntities())
				{
					var i_usuario = new inf_proveedor
					{
						id_proveedor = guid_nrs,
						id_estatus = 1,
						id_tipo_rfc = int_tiporfc,
						rfc = str_rfc,
						razon_social = str_rs,
						telefono = str_telefono,
						email = str_email,
						callenum = str_callenum,
						id_codigo = int_idcodigocp,
						fecha_registro = DateTime.Now,

					};
					m_usuario.inf_proveedor.Add(i_usuario);
					m_usuario.SaveChanges();
				}

				using (var m_usuario = new db_imEntities())
				{
					var i_usuario = new inf_contacto_proveedor
					{
						id_contacto_proveedor = guid_ncproveedor,
						nombres = str_nombres,
						a_paterno = str_apaterno,
						a_materno = str_amaterno,
						telefono = str_telefonoc,
						email = str_emailc,
						id_estatus = 1,

						fecha_registro = DateTime.Now,
						id_proveedor = guid_nrs,

					};
					m_usuario.inf_contacto_proveedor.Add(i_usuario);
					m_usuario.SaveChanges();
				}

				limpia_txt_proveedor();

				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Datos de proveedor agregados con éxito";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();
			}
			else if (int_accion_proveedor == 2)
			{
				foreach (GridViewRow row in gv_proveedor.Rows)
				{
					if (row.RowType == DataControlRowType.DataRow)
					{
						CheckBox chkRow = (row.Cells[1].FindControl("chk_proveedor") as CheckBox);
						if (chkRow.Checked)
						{
							string codeuser = row.Cells[1].Text;

							using (db_imEntities data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_proveedor
												  where c.rfc == codeuser
												  select c).FirstOrDefault();

								guid_idproveedor = items_user.id_proveedor;
							}

							using (var data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_proveedor
												  where c.id_proveedor == guid_idproveedor
												  select c).FirstOrDefault();


								items_user.id_tipo_rfc = int_tiporfc;
								items_user.rfc = str_rfc;
								items_user.razon_social = str_rs;
								items_user.telefono = str_telefono;
								items_user.email = str_email;
								items_user.callenum = str_callenum;
								items_user.id_codigo = int_idcodigocp;
								data_user.SaveChanges();
							}

							using (var data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_contacto_proveedor
												  where c.id_proveedor == guid_idproveedor
												  select c).FirstOrDefault();


								items_user.nombres = str_nombres;
								items_user.a_paterno = str_apaterno;
								items_user.a_materno = str_amaterno;
								items_user.telefono = str_telefonoc;
								items_user.email = str_emailc;

								data_user.SaveChanges();
							}

							limpia_txt_proveedor();

							gv_proveedor.Visible = false;
							txt_buscar_proveedor.Visible = false;
							btn_buscar_proveedor.Visible = false;

							lblModalTitle.Text = "Intelimundo";
							lblModalBody.Text = "Datos de proveedor actualizados con éxito";
							ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
							upModal.Update();
						}
					}
				}
			}
			else if (int_accion_proveedor == 3)
			{
				foreach (GridViewRow row in gv_proveedor.Rows)
				{
					if (row.RowType == DataControlRowType.DataRow)
					{
						CheckBox chkRow = (row.Cells[1].FindControl("chk_proveedor") as CheckBox);
						if (chkRow.Checked)
						{
							string codeuser = row.Cells[1].Text;

							using (db_imEntities data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_proveedor
												  where c.rfc == codeuser
												  select c).FirstOrDefault();

								guid_idproveedor = items_user.id_proveedor;
							}

							using (var data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_proveedor
												  where c.id_proveedor == guid_idproveedor
												  select c).FirstOrDefault();


								items_user.id_estatus = 3;

								data_user.SaveChanges();
							}

							limpia_txt_proveedor();

							gv_proveedor.Visible = false;
							txt_buscar_proveedor.Visible = false;
							btn_buscar_proveedor.Visible = false;

							lblModalTitle.Text = "Intelimundo";
							lblModalBody.Text = "Datos de proveedor dados de baja con éxito";
							ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
							upModal.Update();
						}
					}
				}
			}
		}
		private void limpia_txt_proveedor()
		{
			using (db_imEntities m_tiporfc = new db_imEntities())
			{
				var i_tiporfc = (from f_tr in m_tiporfc.fact_tipo_rfc
								 select f_tr).ToList();

				ddl_tipo_rfc_proveedor.DataSource = i_tiporfc;
				ddl_tipo_rfc_proveedor.DataTextField = "desc_tipo_rfc";
				ddl_tipo_rfc_proveedor.DataValueField = "id_tipo_rfc";
				ddl_tipo_rfc_proveedor.DataBind();
			}

			ddl_tipo_rfc_proveedor.Items.Insert(0, new ListItem("*Tipo RFC", "0"));
			ddl_tipo_rfc_proveedor.SelectedValue = "0";
			txt_rfc_proveedor.Text = "";
			txt_empresa_proveedor.Text = "";
			txt_telefono_proveedor.Text = "";
			txt_email_proveedor.Text = "";
			txt_callenum_proveedor.Text = "";
			txt_cp_proveedor.Text = "";
			ddl_colonia_proveedor.Items.Clear();
			ddl_colonia_proveedor.Items.Insert(0, new ListItem("*Colonia", "0"));
			ddl_colonia_proveedor.SelectedValue = "0";
			txt_municipio_proveedor.Text = "";
			txt_estado_proveedor.Text = "";

			txt_nombres_cproveedor.Text = "";
			txt_apaterno_cproveedor.Text = "";
			txt_amaterno_cproveedor.Text = "";
			txt_telefono_cproveedor.Text = "";
			txt_email_cproveedor.Text = "";
		}
		#endregion


		#region usuarios

		protected void lkbtn_nuevo_usuario_Click(object sender, EventArgs e)
		{
			int_accion_usuario = 1;
			i_agrega_usuario.Attributes["style"] = "color:orangered";
			i_edita_usuario.Attributes["style"] = "color:dimgray";

			limpia_txt_usuarios();

			gv_usuarios.Visible = false;
			txt_buscar_usuario.Visible = false;
			btn_busca_usuario.Visible = false;
			ddl_perfil.Visible = false;
			chkb_activar_usuario.Visible = false;
		}
		protected void lkbtn_edita_usuario_Click(object sender, EventArgs e)
		{
			int_accion_usuario = 2;
			i_agrega_usuario.Attributes["style"] = "color:dimgray";
			i_edita_usuario.Attributes["style"] = "color:orangered";

			limpia_txt_usuarios();

			txt_buscar_usuario.Visible = true;
			btn_busca_usuario.Visible = true;
			gv_usuarios.Visible = false;
			ddl_perfil.Visible = true;
			chkb_activar_usuario.Visible = true;

		}
		protected void lkbtn_baja_usuario_Click(object sender, EventArgs e)
		{
			int_accion_usuario = 3;
			i_agrega_usuario.Attributes["style"] = "color:dimgray";
			i_edita_usuario.Attributes["style"] = "color:dimgray";

			limpia_txt_usuarios();

			txt_buscar_usuario.Visible = true;
			btn_busca_usuario.Visible = true;
			gv_usuarios.Visible = false;
			ddl_perfil.Visible = true;
			chkb_activar_usuario.Visible = true;


		}
		protected void btn_busca_usuario_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_buscar_usuario.Text))
			{

				txt_buscar_usuario.BackColor = Color.IndianRed;
			}
			else
			{
				txt_buscar_usuario.BackColor = Color.Transparent;

				string str_userb = txt_buscar_usuario.Text;



				using (db_imEntities data_user = new db_imEntities())
				{
					var inf_user = (from u in data_user.inf_usuarios
									join est in data_user.fact_estatus on u.id_estatus equals est.id_estatus
									where u.nombres.Contains(str_userb)
									where u.id_estatus == 1

									select new
									{
										u.codigo_usuario,
										est.desc_estatus,

										u.nombres,
										u.a_paterno,
										u.a_materno,
										u.fecha_registro

									}).ToList();

					if (inf_user.Count == 0)
					{
						gv_usuarios.DataSource = inf_user;
						gv_usuarios.DataBind();
						gv_usuarios.Visible = true;

						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Usuario no exite o tiene un perfil diferente";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();


					}
					else
					{
						gv_usuarios.DataSource = inf_user;
						gv_usuarios.DataBind();
						gv_usuarios.Visible = true;
					}
				}
			}
		}
		protected void chkb_facilitador_CheckedChanged(object sender, EventArgs e)
		{
			if (chkb_facilitador.Checked == true)
			{
				chkb_gerente.Checked = false;
				chkb_administrador.Checked = false;
				chkb_ejecutivo.Checked = false;
				chkb_vendedor.Checked = false;
				chkb_contador.Checked = false;


				if (filtro_usuario() == 0)
				{
					lblModalTitle.Text = "Intelimundo";
					lblModalBody.Text = "Favor de seleccionar una perfil";
					ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
					upModal.Update();
				}
				else
				{
					grid_usuarios(int_tipousuario);
				}

			}
			else
			{
				limpia_txt_usuarios();
			}
		}
		protected void chkb_gerente_CheckedChanged(object sender, EventArgs e)
		{
			if (chkb_gerente.Checked == true)
			{

				chkb_facilitador.Checked = false;
				chkb_administrador.Checked = false;
				chkb_ejecutivo.Checked = false;
				chkb_vendedor.Checked = false;
				chkb_contador.Checked = false;

				if (filtro_usuario() == 0)
				{
					lblModalTitle.Text = "Intelimundo";
					lblModalBody.Text = "Favor de seleccionar una perfil";
					ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
					upModal.Update();
				}
				else
				{
					grid_usuarios(int_tipousuario);
				}
			}
			else
			{
				limpia_txt_usuarios();
			}
		}
		protected void chkb_administrador_CheckedChanged(object sender, EventArgs e)
		{
			if (chkb_administrador.Checked == true)
			{

				chkb_gerente.Checked = false;
				chkb_facilitador.Checked = false;
				chkb_ejecutivo.Checked = false;
				chkb_vendedor.Checked = false;
				chkb_contador.Checked = false;

				if (filtro_usuario() == 0)
				{
					lblModalTitle.Text = "Intelimundo";
					lblModalBody.Text = "Favor de seleccionar una perfil";
					ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
					upModal.Update();
				}
				else
				{
					grid_usuarios(int_tipousuario);
				}
			}
			else
			{
				limpia_txt_usuarios();
			}

		}



		protected void chkb_ejecutivo_CheckedChanged(object sender, EventArgs e)
		{
			if (chkb_ejecutivo.Checked == true)
			{
				chkb_gerente.Checked = false;
				chkb_administrador.Checked = false;
				chkb_facilitador.Checked = false;
				chkb_vendedor.Checked = false;
				chkb_contador.Checked = false;

				if (filtro_usuario() == 0)
				{
					lblModalTitle.Text = "Intelimundo";
					lblModalBody.Text = "Favor de seleccionar una perfil";
					ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
					upModal.Update();
				}
				else
				{
					grid_usuarios(int_tipousuario);
				}
			}
			else
			{
				limpia_txt_usuarios();
			}

		}
		protected void chkb_vendedor_CheckedChanged(object sender, EventArgs e)
		{
			if (chkb_vendedor.Checked == true)
			{
				chkb_gerente.Checked = false;
				chkb_administrador.Checked = false;
				chkb_ejecutivo.Checked = false;
				chkb_facilitador.Checked = false;
				chkb_contador.Checked = false;

				if (filtro_usuario() == 0)
				{
					lblModalTitle.Text = "Intelimundo";
					lblModalBody.Text = "Favor de seleccionar una perfil";
					ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
					upModal.Update();
				}
				else
				{
					grid_usuarios(int_tipousuario);
				}
			}
			else
			{
				limpia_txt_usuarios();
			}

		}
		protected void chkb_contador_CheckedChanged(object sender, EventArgs e)
		{
			if (chkb_contador.Checked == true)
			{
				chkb_gerente.Checked = false;
				chkb_administrador.Checked = false;
				chkb_ejecutivo.Checked = false;
				chkb_vendedor.Checked = false;
				chkb_facilitador.Checked = false;

				if (filtro_usuario() == 0)
				{
					lblModalTitle.Text = "Intelimundo";
					lblModalBody.Text = "Favor de seleccionar una perfil";
					ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
					upModal.Update();
				}
				else
				{
					grid_usuarios(int_tipousuario);
				}
			}
			else
			{
				limpia_txt_usuarios();
			}
		}
		protected void btn_guardar_usuario_Click(object sender, EventArgs e)
		{
			if (int_accion_usuario == 0)
			{
				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Favor de seleccionar una acción";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();
			}
			else
			{
				if (filtro_usuario() == 0)
				{
					lblModalTitle.Text = "Intelimundo";
					lblModalBody.Text = "Favor de seleccionar una perfil";
					ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
					upModal.Update();
				}
				else
				{
					if (ddl_genero_usuario.SelectedValue == "0")
					{

						ddl_genero_usuario.BackColor = Color.IndianRed;
					}
					else
					{
						ddl_genero_usuario.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_nombres_usuario.Text))
						{

							txt_nombres_usuario.BackColor = Color.IndianRed;
						}
						else
						{
							txt_nombres_usuario.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_apaterno_usuario.Text))
							{

								txt_apaterno_usuario.BackColor = Color.IndianRed;
							}
							else
							{
								txt_apaterno_usuario.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_amaterno_usuario.Text))
								{

									txt_amaterno_usuario.BackColor = Color.IndianRed;
								}
								else
								{
									txt_amaterno_usuario.BackColor = Color.Transparent;
									if (string.IsNullOrEmpty(txt_fecnac_usuario.Text))
									{

										txt_fecnac_usuario.BackColor = Color.IndianRed;
									}
									else
									{
										txt_fecnac_usuario.BackColor = Color.Transparent;
										if (string.IsNullOrEmpty(txt_usuario_usuario.Text))
										{

											txt_usuario_usuario.BackColor = Color.IndianRed;
										}
										else
										{
											txt_usuario_usuario.BackColor = Color.Transparent;
											if (string.IsNullOrEmpty(txt_clave_usuario.Text))
											{

												txt_clave_usuario.BackColor = Color.IndianRed;
											}
											else
											{
												txt_clave_usuario.BackColor = Color.Transparent;

												guarda_registro_usuario();

											}
										}
									}


								}
							}
						}
					}
				}


			}





		}
		protected void gv_usuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{

		}
		protected void chk_usuario_CheckedChanged(object sender, EventArgs e)
		{
			Guid id_fuser;
			foreach (GridViewRow row in gv_usuarios.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkRow = (row.Cells[0].FindControl("chk_usuario") as CheckBox);
					if (chkRow.Checked)
					{
						row.BackColor = Color.YellowGreen;
						string codeuser = row.Cells[1].Text;

						using (db_imEntities data_user = new db_imEntities())
						{
							var items_user = (from c in data_user.inf_usuarios
											  where c.codigo_usuario == codeuser
											  select c).FirstOrDefault();

							id_fuser = items_user.id_usuario;
						}

						using (db_imEntities data_user = new db_imEntities())
						{
							var inf_user = (from u in data_user.inf_usuarios
											where u.id_usuario == id_fuser
											select new
											{

												u.nombres,
												u.a_paterno,
												u.a_materno,
												u.id_genero,
												u.fecha_nacimiento,
												u.codigo_usuario,
												u.clave

											}).FirstOrDefault();

							DateTime dt_fecnac = DateTime.Parse(inf_user.fecha_nacimiento.ToString());

							txt_nombres_usuario.Text = inf_user.nombres;
							txt_apaterno_usuario.Text = inf_user.a_paterno;
							txt_amaterno_usuario.Text = inf_user.a_materno;
							ddl_genero_usuario.SelectedValue = inf_user.id_genero.ToString();
							txt_fecnac_usuario.Text = dt_fecnac.ToShortDateString();
							txt_usuario_usuario.Text = inf_user.codigo_usuario;
							txt_clave_usuario.Text = inf_user.clave;
						}

					}
					else
					{
						row.BackColor = Color.White;
					}
				}
			}
		}
		private void grid_usuarios(int idtipousuario)
		{
			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from i_u in data_user.inf_usuarios
								join i_e in data_user.fact_estatus on i_u.id_estatus equals i_e.id_estatus
								where i_u.id_tipo_usuario == idtipousuario
								where i_u.id_usuario != guid_iduser


								select new
								{
									i_u.codigo_usuario,
									i_e.desc_estatus,

									i_u.nombres,
									i_u.a_paterno,
									i_u.a_materno,
									i_u.fecha_registro

								}).ToList();

				gv_usuarios.DataSource = inf_user;
				gv_usuarios.DataBind();
				gv_usuarios.Visible = true;
			}
		}
		protected void btn_genera_usuario_Click(object sender, EventArgs e)
		{
			if (int_tipousuario == 0)
			{
				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Favor de seleccionar una perfil";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();
			}
			else
			{
				if (ddl_genero_usuario.SelectedValue == "0")
				{

					ddl_genero_usuario.BackColor = Color.IndianRed;
				}
				else
				{
					ddl_genero_usuario.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_nombres_usuario.Text))
					{

						txt_nombres_usuario.BackColor = Color.IndianRed;
					}
					else
					{
						txt_nombres_usuario.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_apaterno_usuario.Text))
						{

							txt_apaterno_usuario.BackColor = Color.IndianRed;
						}
						else
						{
							txt_apaterno_usuario.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_amaterno_usuario.Text))
							{

								txt_amaterno_usuario.BackColor = Color.IndianRed;
							}
							else
							{
								txt_amaterno_usuario.BackColor = Color.Transparent;
								genera_usuario();
							}
						}
					}
				}
			}


		}
		private void guarda_registro_usuario()
		{
			Guid guid_fusuario;
			Guid guid_nusuario = Guid.NewGuid();
			int int_genero = int.Parse(ddl_genero_usuario.SelectedValue);
			string str_nombres = txt_nombres_usuario.Text.ToUpper();
			string str_apaterno = txt_apaterno_usuario.Text.ToUpper();
			string str_amaterno = txt_amaterno_usuario.Text.ToUpper();
			DateTime dt_fecna = DateTime.Parse(txt_fecnac_usuario.Text);
			string str_usuario = txt_usuario_usuario.Text;
			string str_password = encriptacion.Encrypt(txt_clave_usuario.Text);




			if (int_accion_usuario == 1)
			{
				using (db_imEntities data_user = new db_imEntities())
				{
					var items_user = (from c in data_user.inf_usuarios
									  where c.codigo_usuario == str_usuario
									  select c).ToList();

					if (items_user.Count == 0)
					{

						using (var m_usuario = new db_imEntities())
						{
							var i_usuario = new inf_usuarios
							{
								id_usuario = guid_nusuario,
								id_genero = int_genero,
								id_estatus = 1,
								fecha_nacimiento = dt_fecna,
								id_tipo_usuario = int_tipousuario,
								nombres = str_nombres,
								a_paterno = str_apaterno,
								a_materno = str_amaterno,
								codigo_usuario = str_usuario,
								clave = str_password,
								fecha_registro = DateTime.Now,
								id_centro = guid_centro
							};
							m_usuario.inf_usuarios.Add(i_usuario);
							m_usuario.SaveChanges();
						}

						using (var m_centro = new db_imEntities())
						{
							var i_centro = new inf_centro_dep

							{
								id_centro = guid_centro,
								id_usuario = guid_nusuario
							};

							m_centro.inf_centro_dep.Add(i_centro);
							m_centro.SaveChanges();
						}
						int_accion_usuario = 0;
						limpia_txt_usuarios();
						i_agrega_usuario.Attributes["style"] = "color:dimgray";
						i_edita_usuario.Attributes["style"] = "color:dimgray";


						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Datos de usuario agregados con éxito";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();
					}
					else
					{
						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Usuario ya existe en la base de datos, favor de reintentar";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();
					}
				}

			}
			else if (int_accion_usuario == 2)
			{
				int int_perfil;
				if (ddl_perfil.SelectedValue == "0")
				{
					using (db_imEntities data_user = new db_imEntities())
					{
						var items_user = (from c in data_user.inf_usuarios
										  where c.codigo_usuario == str_usuario
										  select c).ToList();

						int_perfil = int.Parse(items_user[0].id_tipo_usuario.ToString());
					}
				}
				else
				{
					int_perfil = int.Parse(ddl_perfil.SelectedValue);
				}

				int int_activar;

				if (chkb_activar_usuario.Checked == true)
				{
					int_activar = 3;
				}
				else
				{
					int_activar = 1;
				}
				foreach (GridViewRow row in gv_usuarios.Rows)
				{
					if (row.RowType == DataControlRowType.DataRow)
					{
						CheckBox chkRow = (row.Cells[0].FindControl("chk_usuario") as CheckBox);
						if (chkRow.Checked)
						{
							row.BackColor = Color.YellowGreen;
							string codeuser = row.Cells[1].Text;

							if (codeuser == str_usuario)
							{
								using (db_imEntities data_user = new db_imEntities())
								{
									var items_user = (from c in data_user.inf_usuarios
													  where c.codigo_usuario == codeuser
													  select c).FirstOrDefault();

									guid_fusuario = items_user.id_usuario;
								}
								using (var data_user = new db_imEntities())
								{
									var items_user = (from c in data_user.inf_usuarios
													  where c.id_usuario == guid_fusuario
													  select c).FirstOrDefault();

									items_user.id_estatus = int_activar;
									items_user.id_genero = int_genero;
									items_user.nombres = str_nombres;
									items_user.a_paterno = str_apaterno;
									items_user.a_materno = str_amaterno;
									items_user.fecha_nacimiento = dt_fecna;
									items_user.id_tipo_usuario = int_perfil;
									items_user.codigo_usuario = str_usuario;
									items_user.clave = str_password;

									data_user.SaveChanges();
								}
								int_accion_usuario = 0;
								limpia_txt_usuarios();

								grid_usuarios(int_tipousuario);

								txt_buscar_usuario.Text = "";


								lblModalTitle.Text = "Intelimundo";
								lblModalBody.Text = "Datos de usuario actualizados con éxito";
								ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
								upModal.Update();
							}
							else
							{
								using (db_imEntities data_user = new db_imEntities())
								{
									var items_user = (from c in data_user.inf_usuarios
													  where c.codigo_usuario == str_usuario
													  select c).ToList();

									if (items_user.Count == 0)
									{
										using (db_imEntities data_userf = new db_imEntities())
										{
											var items_userf = (from c in data_userf.inf_usuarios
															   where c.codigo_usuario == codeuser
															   select c).FirstOrDefault();

											guid_fusuario = items_userf.id_usuario;
										}
										using (var data_userff = new db_imEntities())
										{
											var items_userff = (from c in data_userff.inf_usuarios
																where c.id_usuario == guid_fusuario
																select c).FirstOrDefault();

											items_userff.nombres = str_nombres;
											items_userff.a_paterno = str_apaterno;
											items_userff.a_materno = str_amaterno;
											items_userff.id_tipo_usuario = int_tipousuario;
											items_userff.codigo_usuario = str_usuario;
											items_userff.clave = str_password;
											data_userff.SaveChanges();
										}

										limpia_txt_usuarios();

										grid_usuarios(int_tipousuario);

										txt_buscar_usuario.Text = "";


										lblModalTitle.Text = "Intelimundo";
										lblModalBody.Text = "Datos de usuario actualizados con éxito";
										ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
										upModal.Update();

									}
									else
									{
										lblModalTitle.Text = "Intelimundo";
										lblModalBody.Text = "Usuario ya existe en la base de datos, favor de reintentar";
										ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
										upModal.Update();
									}
								}
							}


						}
						else
						{
							row.BackColor = Color.White;
						}
					}
				}
			}
			else if (int_accion_usuario == 3)
			{
				foreach (GridViewRow row in gv_usuarios.Rows)
				{
					if (row.RowType == DataControlRowType.DataRow)
					{
						CheckBox chkRow = (row.Cells[0].FindControl("chk_usuario") as CheckBox);
						if (chkRow.Checked)
						{
							row.BackColor = Color.YellowGreen;
							string codeuser = row.Cells[1].Text;

							using (db_imEntities data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_usuarios
												  where c.codigo_usuario == codeuser
												  select c).FirstOrDefault();

								guid_fusuario = items_user.id_usuario;
							}
							using (var data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_usuarios
												  where c.id_usuario == guid_fusuario
												  select c).FirstOrDefault();

								items_user.id_estatus = 3;

								data_user.SaveChanges();
							}
							int_accion_usuario = 0;
							limpia_txt_usuarios();

							grid_usuarios(int_tipousuario);

							txt_buscar_usuario.Text = "";


							lblModalTitle.Text = "Intelimundo";
							lblModalBody.Text = "Usuario dado de baja con éxito";
							ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
							upModal.Update();
						}
						else
						{
							row.BackColor = Color.White;
						}
					}
				}
			}
		}
		private void genera_usuario()
		{
			try
			{
				int nombres_count = txt_nombres_usuario.Text.Split(' ').Count();
				string str_nombres = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_nombres_usuario.Text.ToLower()));
				string[] separados;

				separados = str_nombres.Split(" ".ToArray());
				int count = separados.Count();

				string str_apaterno = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_apaterno_usuario.Text.ToLower()));
				string str_amaterno = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_amaterno_usuario.Text.ToLower()));

				string codigo_usuario = str_nombres + "_" + left_right_mid.left(str_apaterno, 2) + left_right_mid.left(str_amaterno, 2);
				txt_usuario_usuario.Text = codigo_usuario;
			}
			catch
			{
				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Se requiere minimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el usuario";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();
			}
		}
		public int filtro_usuario()

		{
			if (chkb_administrador.Checked)
			{
				int_tipousuario = 3;
				return 3;
			}
			else if (chkb_gerente.Checked)
			{
				int_tipousuario = 4;
				return 4;
			}
			else if (chkb_facilitador.Checked)
			{
				int_tipousuario = 5;
				return 5;
			}
			else if (chkb_ejecutivo.Checked)
			{
				int_tipousuario = 7;
				return 6;
			}
			else if (chkb_vendedor.Checked)
			{
				int_tipousuario = 7;
				return 7;
			}
			else if (chkb_contador.Checked)
			{
				int_tipousuario = 8;
				return 8;
			}
			else
			{
				return 0;
			}


		}

	

		private void limpia_txt_usuarios()
		{
			ddl_genero_usuario.Items.Clear();
			using (db_imEntities m_genero = new db_imEntities())
			{
				var i_genero = (from f_tr in m_genero.fact_genero
								select f_tr).ToList();

				ddl_genero_usuario.DataSource = i_genero;
				ddl_genero_usuario.DataTextField = "desc_genero";
				ddl_genero_usuario.DataValueField = "id_genero";
				ddl_genero_usuario.DataBind();
			}
			ddl_genero_usuario.Items.Insert(0, new ListItem("*GÉNERO", "0"));

			ddl_perfil.Items.Clear();
			using (db_imEntities m_genero = new db_imEntities())
			{
				var i_genero = (from f_tr in m_genero.fact_tipo_usuario
								where f_tr.id_tipo_usuario != 1
								where f_tr.id_tipo_usuario != 2
								select f_tr).ToList();

				ddl_perfil.DataSource = i_genero;
				ddl_perfil.DataTextField = "desc_tipo_usuario";
				ddl_perfil.DataValueField = "id_tipo_usuario";
				ddl_perfil.DataBind();
			}
			ddl_perfil.Items.Insert(0, new ListItem("*PERFIL", "0"));

			txt_nombres_usuario.Text = "";
			txt_apaterno_usuario.Text = "";
			txt_amaterno_usuario.Text = "";
			txt_usuario_usuario.Text = "";
			txt_clave_usuario.Text = "";
			txt_fecnac_usuario.Text = "";
			txt_buscar_usuario.Text = "";
			gv_usuarios.Visible = false;

			ddl_genero_usuario.BackColor = Color.Transparent;
			txt_nombres_usuario.BackColor = Color.Transparent;
			txt_apaterno_usuario.BackColor = Color.Transparent;
			txt_apaterno_usuario.BackColor = Color.Transparent;
			txt_fecnac_usuario.BackColor = Color.Transparent;
			txt_usuario_usuario.BackColor = Color.Transparent;
			txt_clave_usuario.BackColor = Color.Transparent;
			ddl_perfil.BackColor = Color.Transparent;

			chkb_administrador.Checked = false;
			chkb_gerente.Checked = false;
			chkb_facilitador.Checked = false;
			chkb_ejecutivo.Checked = false;
			chkb_vendedor.Checked = false;
			chkb_contador.Checked = false;
			chkb_activar_usuario.Checked = false;


		}
		private string RemoveSpecialCharacters(string str)
		{
			return Regex.Replace(str, @"[^0-9A-Za-z]", "", RegexOptions.None);
		}



		public static string RemoveAccentsWithRegEx(string inputString)
		{
			Regex replace_a_Accents = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
			Regex replace_e_Accents = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
			Regex replace_i_Accents = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
			Regex replace_o_Accents = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
			Regex replace_u_Accents = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);
			inputString = replace_a_Accents.Replace(inputString, "a");
			inputString = replace_e_Accents.Replace(inputString, "e");
			inputString = replace_i_Accents.Replace(inputString, "i");
			inputString = replace_o_Accents.Replace(inputString, "o");
			inputString = replace_u_Accents.Replace(inputString, "u");
			return inputString;
		}
		#endregion

		#region empresa
		protected void lkb_editar_empresa_Click(object sender, EventArgs e)
		{
			i_editaempresa.Attributes["style"] = "color:orangered";

			Guid id_fempresa = guid_centro;
			int int_fcolonia;
			string str_fcp;

			using (db_imEntities edm_empresa = new db_imEntities())
			{
				var i_empresa = (from c in edm_empresa.inf_empresa
								 select c).ToList();

				if (i_empresa.Count == 0)
				{

					lblModalTitle.Text = "Intelimundo";
					lblModalBody.Text = "Sin datos de Empresa, favor de agregar";
					ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
					upModal.Update();
				}
				else
				{
					using (db_imEntities m_empresaf = new db_imEntities())
					{
						var i_empresaf = (from i_c in m_empresaf.inf_empresa
										  where i_c.id_empresa == id_fempresa
										  select new
										  {
											  i_c.id_tipo_rfc,
											  i_c.rfc,
											  i_c.razon_social,
											  i_c.callenum,
											  i_c.id_codigo,
											  i_c.telefono,
											  i_c.email

										  }).FirstOrDefault();

						using (db_imEntities m_tiporfc = new db_imEntities())
						{
							var i_tiporfc = (from f_tr in m_tiporfc.fact_tipo_rfc
											 select f_tr).ToList();

							ddl_tipo_rfc_empresa.DataSource = i_tiporfc;
							ddl_tipo_rfc_empresa.DataTextField = "desc_tipo_rfc";
							ddl_tipo_rfc_empresa.DataValueField = "id_tipo_rfc";
							ddl_tipo_rfc_empresa.DataBind();
						}

						ddl_tipo_rfc_empresa.Items.Insert(0, new ListItem("*Tipo RFC", "0"));
						ddl_tipo_rfc_empresa.SelectedValue = i_empresaf.id_tipo_rfc.ToString();
						txt_rfc_empresa.Text = i_empresaf.rfc;
						txt_rs_empresa.Text = i_empresaf.razon_social;
						txt_telefono_empresa.Text = i_empresaf.telefono;
						txt_email_empresa.Text = i_empresaf.email;
						txt_callenum_empresa.Text = i_empresaf.callenum;

						int_fcolonia = int.Parse(i_empresaf.id_codigo.ToString());

					}
					using (db_imEntities db_sepomex = new db_imEntities())
					{
						var tbl_sepomex = (from c in db_sepomex.inf_sepomex
										   where c.id_codigo == int_fcolonia
										   select c).ToList();

						ddl_colonia_empresa.DataSource = tbl_sepomex;
						ddl_colonia_empresa.DataTextField = "d_asenta";
						ddl_colonia_empresa.DataValueField = "id_asenta_cpcons";
						ddl_colonia_empresa.DataBind();

						txt_cp_empresa.Text = tbl_sepomex[0].d_codigo;
						txt_municipio_empresa.Text = tbl_sepomex[0].D_mnpio;
						txt_estado_empresa.Text = tbl_sepomex[0].d_estado;
					}
				}
			}
		}



		protected void btn_cp_empresa_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_cp_empresa.Text))
			{

				txt_cp_empresa.BackColor = Color.IndianRed;
			}
			else
			{
				txt_cp_empresa.BackColor = Color.Transparent;

				string str_codigo = txt_cp_empresa.Text;

				using (db_imEntities db_sepomex = new db_imEntities())
				{
					var tbl_sepomex = (from c in db_sepomex.inf_sepomex
									   where c.d_codigo == str_codigo
									   select c).ToList();

					ddl_colonia_empresa.DataSource = tbl_sepomex;
					ddl_colonia_empresa.DataTextField = "d_asenta";
					ddl_colonia_empresa.DataValueField = "id_asenta_cpcons";
					ddl_colonia_empresa.DataBind();

					if (tbl_sepomex.Count == 1)
					{


						txt_municipio_empresa.Text = tbl_sepomex[0].D_mnpio;
						txt_estado_empresa.Text = tbl_sepomex[0].d_estado;
					}
					if (tbl_sepomex.Count > 1)
					{

						ddl_colonia_empresa.Items.Insert(0, new ListItem("*Colonia", "0"));

						txt_municipio_empresa.Text = tbl_sepomex[0].D_mnpio;
						txt_estado_empresa.Text = tbl_sepomex[0].d_estado;
					}
					else if (tbl_sepomex.Count == 0)
					{

						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Error de Código Postal, favor de reintentar";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();

					}
				}
			}


		}



		private void limpiar_textbox_empresa()
		{
			using (db_imEntities m_tiporfc = new db_imEntities())
			{
				var i_tiporfc = (from f_tr in m_tiporfc.fact_tipo_rfc
								 select f_tr).ToList();

				ddl_tipo_rfc_empresa.DataSource = i_tiporfc;
				ddl_tipo_rfc_empresa.DataTextField = "desc_tipo_rfc";
				ddl_tipo_rfc_empresa.DataValueField = "id_tipo_rfc";
				ddl_tipo_rfc_empresa.DataBind();
			}

			ddl_tipo_rfc_empresa.Items.Insert(0, new ListItem("*Tipo RFC", "0"));
			ddl_colonia_empresa.Items.Clear();
			ddl_colonia_empresa.Items.Insert(0, new ListItem("*Colonia", "0"));
			ddl_colonia_empresa.SelectedValue = "0";

			txt_rfc_empresa.Text = "";
			txt_rs_empresa.Text = "";
			txt_telefono_empresa.Text = "";
			txt_email_empresa.Text = "";
			txt_callenum_empresa.Text = "";
			txt_cp_empresa.Text = "";

			txt_municipio_empresa.Text = "";
			txt_estado_empresa.Text = "";

			ddl_tipo_rfc_empresa.BackColor = Color.White;
			txt_rfc_empresa.BackColor = Color.White;
			txt_rs_empresa.BackColor = Color.White;
			txt_telefono_empresa.BackColor = Color.White;
			txt_email_empresa.BackColor = Color.White;
			txt_callenum_empresa.BackColor = Color.White;
			txt_cp_empresa.BackColor = Color.White;
			ddl_colonia_empresa.BackColor = Color.White;
			txt_municipio_empresa.BackColor = Color.White;
			txt_estado_empresa.BackColor = Color.White;


		}



		protected void btn_guarda_empresa_Click(object sender, EventArgs e)
		{
			if (ddl_tipo_rfc_empresa.SelectedValue == "0")
			{

				ddl_tipo_rfc_empresa.BackColor = Color.IndianRed;
			}
			else
			{
				ddl_tipo_rfc_empresa.BackColor = Color.Transparent;
				if (string.IsNullOrEmpty(txt_rfc_empresa.Text))
				{

					txt_rfc_empresa.BackColor = Color.IndianRed;
				}
				else
				{
					txt_rfc_empresa.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_rs_empresa.Text))
					{

						txt_rs_empresa.BackColor = Color.IndianRed;
					}
					else
					{
						txt_rs_empresa.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_telefono_empresa.Text))
						{

							txt_telefono_empresa.BackColor = Color.IndianRed;
						}
						else
						{
							txt_telefono_empresa.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_email_empresa.Text))
							{

								txt_email_empresa.BackColor = Color.IndianRed;
							}
							else
							{
								txt_email_empresa.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_callenum_empresa.Text))
								{

									txt_callenum_empresa.BackColor = Color.IndianRed;
								}
								else
								{
									txt_callenum_empresa.BackColor = Color.Transparent;
									if (string.IsNullOrEmpty(txt_cp_empresa.Text))
									{

										txt_cp_empresa.BackColor = Color.IndianRed;
									}
									else
									{
										txt_cp_empresa.BackColor = Color.Transparent;
										if (ddl_colonia_empresa.SelectedValue == "0")
										{

											ddl_colonia_empresa.BackColor = Color.IndianRed;
										}
										else
										{
											ddl_colonia_empresa.BackColor = Color.Transparent;

											Guid guid_fempresa = guid_centro;
											int int_tiporfc = int.Parse(ddl_tipo_rfc_empresa.SelectedValue);
											string str_rfc = txt_rfc_empresa.Text.ToUpper();
											string str_empresa = txt_rs_empresa.Text.ToUpper();
											string str_telefono = txt_telefono_empresa.Text;
											string str_email = txt_email_empresa.Text;
											string str_callenum = txt_callenum_empresa.Text.ToUpper();
											string str_cp = txt_cp_empresa.Text;
											int int_colonia = Convert.ToInt32(ddl_colonia_empresa.SelectedValue);
											int int_idcodigocp;

											using (db_imEntities db_sepomex = new db_imEntities())
											{
												var tbl_sepomex = (from c in db_sepomex.inf_sepomex
																   where c.d_codigo == str_cp
																   where c.id_asenta_cpcons == int_colonia
																   select c).ToList();

												int_idcodigocp = tbl_sepomex[0].id_codigo;
											}

											using (db_imEntities edm_empresa = new db_imEntities())
											{
												var i_empresa = (from c in edm_empresa.inf_empresa
																 select c).ToList();

												if (i_empresa.Count == 0)
												{
													using (var m_usuario = new db_imEntities())
													{
														var i_usuario = new inf_empresa
														{
															id_empresa = guid_fempresa,
															id_estatus = 1,
															id_tipo_rfc = int_tiporfc,
															rfc = str_rfc,
															razon_social = str_empresa,
															telefono = str_telefono,
															email = str_email,
															callenum = str_callenum,
															id_codigo = int_idcodigocp,
															fecha_registro = DateTime.Now
														};
														m_usuario.inf_empresa.Add(i_usuario);
														m_usuario.SaveChanges();
													}

													using (var m_fempresa = new db_imEntities())
													{
														var i_fempresa = (from c in m_fempresa.inf_centro
																		  where c.id_centro == guid_centro
																		  select c).FirstOrDefault();

														i_fempresa.id_empresa = guid_fempresa;
														m_fempresa.SaveChanges();
													}

													limpiar_textbox_empresa();
													lblModalTitle.Text = "Intelimundo";
													lblModalBody.Text = "Datos de Empresa agregados con éxito";
													ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
													upModal.Update();
												}
												else
												{
													Guid f_empresa = i_empresa[0].id_empresa;
													using (var m_fempresa = new db_imEntities())
													{
														var i_fempresa = (from c in m_fempresa.inf_empresa
																		  where c.id_empresa == f_empresa
																		  select c).FirstOrDefault();

														i_fempresa.id_tipo_rfc = int_tiporfc;
														i_fempresa.rfc = str_rfc;
														i_fempresa.razon_social = str_empresa;
														i_fempresa.telefono = str_telefono;
														i_fempresa.email = str_email;
														i_fempresa.callenum = str_callenum;
														i_fempresa.id_codigo = int_idcodigocp;

														m_fempresa.SaveChanges();
													}

													limpiar_textbox_empresa();

													lblModalTitle.Text = "Intelimundo";
													lblModalBody.Text = "Datos de Empresa actualizados con éxito";
													ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
													upModal.Update();

												}
											}

										}
									}
								}
							}
						}
					}
				}
			}

		}
		#endregion
	}
}