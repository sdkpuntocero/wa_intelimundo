using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
	public partial class acceso : System.Web.UI.Page
	{
		static Guid guid_fuser, guid_centro;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				inf_user();
			}
			else
			{

			}
		}

		private void inf_user()
		{

			try
			{
				using (db_imEntities edm_fusuario = new db_imEntities())
				{
					var i_fusuario = (from u in edm_fusuario.inf_usuarios
									  where u.id_tipo_usuario == 2
									  select u).ToList();

					if (i_fusuario.Count == 0)
					{
						lkb_registro.Visible = true;
						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "No existe Corporativo ni Director en la aplicación, favor de registrarlos";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();
					}
					else
					{
						lkb_registro.Visible = false;

					}
				}
			}
			catch
			{
				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Sin conexión a base de datos, contactar al administrador";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();
			}

		}

		protected void cmd_acceso_Click(object sender, EventArgs e)
		{
			if (ddl_centro.Visible == true)
			{
				if (ddl_centro.SelectedValue == "0")
				{

					ddl_centro.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					ddl_centro.BackColor = Color.White;
					if (string.IsNullOrEmpty(txt_usuario.Text))
					{

						txt_usuario.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						txt_usuario.BackColor = Color.White;
						if (string.IsNullOrEmpty(txt_clave.Text))
						{

							txt_clave.BackColor = Color.FromArgb(185, 0, 92);
						}
						else
						{
							txt_clave.BackColor = Color.White;


							string str_codigousuario, str_clave, str_valida_clave;
							int int_idtypeuser, int_iduserstatus;

							str_codigousuario = txt_usuario.Text;
							str_clave = encriptacion.Encrypt(txt_clave.Text);

							using (db_imEntities edm_usuarios = new db_imEntities())
							{
								var i_usuarios = (from c in edm_usuarios.inf_usuarios
												  where c.codigo_usuario == str_codigousuario
												  select c).ToList();
								if (i_usuarios.Count == 0)
								{
									lblModalTitle.Text = "Intelimundo";
									lblModalBody.Text = "Usuario incorrecto, favor de contactar al Administrador.";
									ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
									upModal.Update();
								}
								else
								{
									try
									{
										using (db_imEntities m_usuariof = new db_imEntities())
										{
											var i_usuariof = (from c in m_usuariof.inf_usuarios
															  where c.codigo_usuario == str_codigousuario
															  select c).FirstOrDefault();

											guid_fuser = i_usuariof.id_usuario;
											str_valida_clave = i_usuariof.clave;
											int_idtypeuser = int.Parse(i_usuariof.id_tipo_usuario.ToString());
											int_iduserstatus = int.Parse(i_usuariof.id_estatus.ToString());

											guid_centro = Guid.Parse(ddl_centro.SelectedValue);

											if (str_valida_clave == str_clave && int_iduserstatus == 1)
											{
												Session["ss_id_user"] = guid_usuario.code_user(str_codigousuario);
												Session["ss_id_center"] = guid_centro;
												Response.Redirect("panel_director.aspx");
											}
											else
											{
												lblModalTitle.Text = "Intelimundo";
												lblModalBody.Text = "Contraseña incorrecta, favor de contactar al Administrador.";
												ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
												upModal.Update();
											}
										}
									}
									catch
									{
										lblModalTitle.Text = "Intelimundo";
										lblModalBody.Text = "Usuario incorrecto, favor de contactar al Administrador.";
										ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
										upModal.Update();
									}
								}



							}


						}
					}
				}
			}
			else
			{
				if (string.IsNullOrEmpty(txt_usuario.Text))
				{

					txt_usuario.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					txt_usuario.BackColor = Color.White;
					if (string.IsNullOrEmpty(txt_clave.Text))
					{

						txt_clave.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						txt_clave.BackColor = Color.White;

						string str_codigousuario, str_clave, str_valida_clave;
						int int_idtypeuser, int_iduserstatus;

						str_codigousuario = txt_usuario.Text;
						str_clave = encriptacion.Encrypt(txt_clave.Text);

						using (db_imEntities edm_usuarios = new db_imEntities())
						{
							var i_usuarios = (from c in edm_usuarios.inf_usuarios
											  where c.codigo_usuario == str_codigousuario
											  select c).ToList();
							if (i_usuarios.Count == 0)
							{
								lblModalTitle.Text = "Intelimundo";
								lblModalBody.Text = "Usuario incorrecto, favor de contactar al Administrador.";
								ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
								upModal.Update();
							}
							else
							{
								Guid guid_fidusuario;
								guid_fidusuario = i_usuarios[0].id_usuario;

								using (db_imEntities edm_fcentrodep = new db_imEntities())
								{
									var i_fcentrodep = (from i_u in edm_fcentrodep.inf_centro_dep
														where i_u.id_usuario == guid_fidusuario
														select i_u).ToList();

									if (i_fcentrodep.Count == 1)
									{
										try
										{
											using (db_imEntities m_usuariof = new db_imEntities())
											{
												var i_usuariof = (from c in m_usuariof.inf_usuarios
																  where c.codigo_usuario == str_codigousuario
																  select c).FirstOrDefault();

												guid_fuser = i_usuariof.id_usuario;
												str_valida_clave = i_usuariof.clave;
												int_idtypeuser = int.Parse(i_usuariof.id_tipo_usuario.ToString());
												int_iduserstatus = int.Parse(i_usuariof.id_estatus.ToString());

												using (db_imEntities edm_centrof = new db_imEntities())
												{
													var i_centrof = (from a in edm_centrof.inf_centro
																	 join c in edm_centrof.inf_centro_dep on a.id_centro equals c.id_centro
																	 where c.id_usuario == guid_fuser
																	 select a).FirstOrDefault();

													guid_centro = i_centrof.id_centro;
												}

												if (str_valida_clave == str_clave && int_iduserstatus == 1)
												{
													Session["ss_id_user"] = guid_usuario.code_user(str_codigousuario);
													Session["ss_id_center"] = guid_centro;
													Response.Redirect("panel_director.aspx");
												}
												else
												{
													lblModalTitle.Text = "Intelimundo";
													lblModalBody.Text = "Contraseña incorrecta, favor de contactar al Administrador.";
													ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
													upModal.Update();
												}
											}
										}
										catch
										{
											lblModalTitle.Text = "Intelimundo";
											lblModalBody.Text = "Usuario incorrecto, favor de contactar al Administrador.";
											ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
											upModal.Update();
										}
									}
									else
									{
										using (db_imEntities edm_centrodep = new db_imEntities())
										{
											var i_centrodep = (from i_c in edm_centrodep.inf_centro
															   join i_l in edm_centrodep.inf_centro_dep on i_c.id_centro equals i_l.id_centro
															   where i_l.id_usuario == guid_fidusuario
															   where i_c.id_tipo_centro == 2
															   select i_c).ToList();

											ddl_centro.DataSource = i_centrodep;
											ddl_centro.DataTextField = "nombre";
											ddl_centro.DataValueField = "id_centro";
											ddl_centro.DataBind();
										}

										ddl_centro.Items.Insert(0, new ListItem("*Centro", "0"));
										ddl_centro.Visible = true;
									}
								}
							}



						}


					}
				}
			}
		}

		protected void lkb_registro_Click(object sender, EventArgs e)
		{
			Response.Redirect("registro_inicial.aspx");
		}
	}
}