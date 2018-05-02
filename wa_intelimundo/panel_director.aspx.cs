using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
	public partial class panel_director : System.Web.UI.Page
	{

		static Guid guid_iduser, guid_centro, guid_idproveedor, guid_idcentro, guid_idadmin, guid_idventa, guid_idventaf, guid_idinventario;
		static int int_idtipousuario, int_tipousuario, int_accion_usuario, int_accion_alumno, int_accion_proveedor, int_accion_sucursal, int_accion_inventario, int_accion_gasto, int_accion_venta;
		static string str_idcodigousuario;
		static decimal dml_ventas, dml_gastos;
		static string cventa;
		static int int_cventa;
		static Guid guidalumno;


		[WebMethod]
		public static List<string> GetEmployeeName(string empName)
		{
			List<string> empResult = new List<string>();
			using (SqlConnection con = new SqlConnection(cn.CadenaConexion))
			{
				using (SqlCommand cmd = new SqlCommand())
				{
					cmd.CommandText = "SELECT DISTINCT caracteristica WHERE caracteristica LIKE ''+@SearchEmpName+'%'";
					cmd.Connection = con;
					con.Open();
					cmd.Parameters.AddWithValue("@SearchEmpName", empName);
					SqlDataReader dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						empResult.Add(dr["caracteristica"].ToString());
					}
					con.Close();
					return empResult;
				}
			}
		}


		#region panel
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
			guid_centro = (Guid)(Session["ss_id_center"]);

			using (db_imEntities m_usuario = new db_imEntities())
			{
				var i_usuario = (from i_cd in m_usuario.inf_centro_dep
								 join i_u in m_usuario.inf_usuarios on i_cd.id_usuario equals i_u.id_usuario
								 join i_tu in m_usuario.fact_tipo_usuario on i_u.id_tipo_usuario equals i_tu.id_tipo_usuario
								 join i_c in m_usuario.inf_centro on i_cd.id_centro equals i_c.id_centro
								 where i_cd.id_centro == guid_centro
								 where i_cd.id_usuario == guid_iduser
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
			switch (int_idtipousuario)
			{
				case 1:

					break;
				case 2:
					div_ordencompra.Visible = false;
					div_recepcion.Visible = false;
					div_proveedores.Visible = false;
					break;
				case 3:
					div_recepcion.Visible = false;
					div_ordencompra.Visible = false;
					div_inventario.Visible = false;
					
					div_proveedores.Visible = false;
					div_empresa.Visible = false;
					chkb_administrador.Visible = false;
					break;
				case 4:
					div_recepcion.Visible = false;
					div_ordencompra.Visible = false;
					div_inventario.Visible = false;
					
					div_proveedores.Visible = false;
					div_empresa.Visible = false;
					
					break;
				case 5:
					div_recepcion.Visible = false;
					div_ordencompra.Visible = false;
					div_inventario.Visible = false;
					div_sucursales.Visible = false;
					div_proveedores.Visible = false;
					div_empresa.Visible = false;
					chkb_administrador.Visible = false;
					break;
				case 6:
					div_recepcion.Visible = false;
					div_ordencompra.Visible = false;
					div_inventario.Visible = false;
					div_sucursales.Visible = false;
					div_proveedores.Visible = false;
					div_empresa.Visible = false;
					break;
				case 7:

					break;
				case 8:

					break;
				case 9:

					break;
				case 10:

					break;
				case 11:

					break;
				case 12:

					break;
				case 13:

					break;
				case 14:

					break;
				default:

					break;
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
		protected void lkb_resumen_Click(object sender, EventArgs e)
		{
			filtra_panel(3);
		}
		protected void lkb_ventas_Click(object sender, EventArgs e)
		{
			filtra_panel(4);
		}
		protected void lkb_gastos_Click(object sender, EventArgs e)
		{
			filtra_panel(5);
		}
		protected void lkb_inventario_Click(object sender, EventArgs e)
		{
			filtra_panel(8);
		}
		protected void lkb_sucursales_Click(object sender, EventArgs e)
		{
			filtra_panel(9);
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
					pnl_resumen.Visible = false;
					pnl_ventas.Visible = false;
					pnl_alumnosV.Visible = false;
					pnl_inventariosV.Visible = false;
					pnl_rptcotizacion.Visible = false;
					pnl_gastos.Visible = false;
					pnl_inventarios.Visible = false;
					pnl_sucursales.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = false;

					i_editausuario.Attributes["style"] = "color:#B9005C";
					i_editacentro.Attributes["style"] = "color:#079DBC";
					i_editacentrof.Attributes["style"] = "color:#079DBC";
					i_resumen.Attributes["style"] = "color:#079DBC";
					i_ventas.Attributes["style"] = "color:#079DBC";
					i_gastos.Attributes["style"] = "color:#079DBC";
					i_inventarios.Attributes["style"] = "color:#079DBC";
					i_sucursales.Attributes["style"] = "color:#079DBC";
					i_proveedores.Attributes["style"] = "color:#079DBC";
					i_alumnos.Attributes["style"] = "color:#079DBC";
					i_usuarios.Attributes["style"] = "color:#079DBC";
					i_empresa.Attributes["style"] = "color:#079DBC";
					i_salir.Attributes["style"] = "color:#079DBC";

					limpiar_textbox_fusuario();

					break;
				case 2:

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = true;
					pnl_resumen.Visible = false;
					pnl_ventas.Visible = false;
					pnl_alumnosV.Visible = false;
					pnl_inventariosV.Visible = false;
					pnl_rptcotizacion.Visible = false;
					pnl_gastos.Visible = false;
					pnl_inventarios.Visible = false;
					pnl_sucursales.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = false;

					i_editausuario.Attributes["style"] = "color:#079DBC";
					i_editacentro.Attributes["style"] = "color:#B9005C";
					i_editacentrof.Attributes["style"] = "color:#079DBC";
					i_resumen.Attributes["style"] = "color:#079DBC";
					i_ventas.Attributes["style"] = "color:#079DBC";
					i_gastos.Attributes["style"] = "color:#079DBC";
					i_inventarios.Attributes["style"] = "color:#079DBC";
					i_sucursales.Attributes["style"] = "color:#079DBC";
					i_proveedores.Attributes["style"] = "color:#079DBC";
					i_alumnos.Attributes["style"] = "color:#079DBC";
					i_usuarios.Attributes["style"] = "color:#079DBC";
					i_empresa.Attributes["style"] = "color:#079DBC";
					i_salir.Attributes["style"] = "color:#079DBC";
					limpia_txt_centro();
					break;
				case 3:

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					pnl_resumen.Visible = true;
					pnl_ventas.Visible = false;
					pnl_alumnosV.Visible = false;
					pnl_inventariosV.Visible = false;
					pnl_rptcotizacion.Visible = false;
					pnl_gastos.Visible = false;
					pnl_inventarios.Visible = false;
					pnl_sucursales.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = false;

					i_editausuario.Attributes["style"] = "color:#079DBC";
					i_editacentro.Attributes["style"] = "color:#079DBC";
					i_editacentrof.Attributes["style"] = "color:#079DBC";
					i_resumen.Attributes["style"] = "color:#B9005C";
					i_ventas.Attributes["style"] = "color:#079DBC";
					i_gastos.Attributes["style"] = "color:#079DBC";
					i_inventarios.Attributes["style"] = "color:#079DBC";
					i_sucursales.Attributes["style"] = "color:#079DBC";
					i_proveedores.Attributes["style"] = "color:#079DBC";
					i_alumnos.Attributes["style"] = "color:#079DBC";
					i_usuarios.Attributes["style"] = "color:#079DBC";
					i_empresa.Attributes["style"] = "color:#079DBC";
					i_salir.Attributes["style"] = "color:#079DBC";

					limpiar_txt_resumen();

					break;
				case 4:

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					pnl_resumen.Visible = false;
					pnl_ventas.Visible = true;
					pnl_alumnosV.Visible = false;
					pnl_inventariosV.Visible = false;
					pnl_rptcotizacion.Visible = false;
					pnl_gastos.Visible = false;
					pnl_inventarios.Visible = false;
					pnl_sucursales.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = false;

					i_editausuario.Attributes["style"] = "color:#079DBC";
					i_editacentro.Attributes["style"] = "color:#079DBC";
					i_editacentrof.Attributes["style"] = "color:#079DBC";
					i_resumen.Attributes["style"] = "color:#079DBC";
					i_ventas.Attributes["style"] = "color:#B9005C";
					i_gastos.Attributes["style"] = "color:#079DBC";
					i_inventarios.Attributes["style"] = "color:#079DBC";
					i_sucursales.Attributes["style"] = "color:#079DBC";
					i_proveedores.Attributes["style"] = "color:#079DBC";
					i_alumnos.Attributes["style"] = "color:#079DBC";
					i_usuarios.Attributes["style"] = "color:#079DBC";
					i_empresa.Attributes["style"] = "color:#079DBC";
					i_salir.Attributes["style"] = "color:#079DBC";

					int_accion_venta = 0;

					limpiar_txt_ventas();

					i_nueva_venta.Attributes["style"] = "color:#079DBC";
					i_edita_venta.Attributes["style"] = "color:#079DBC";
					i_baja_venta.Attributes["style"] = "color:#079DBC";

					break;
				case 5:

					int_accion_gasto = 0;

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					pnl_resumen.Visible = false;
					pnl_ventas.Visible = false;
					pnl_alumnosV.Visible = false;
					pnl_inventariosV.Visible = false;
					pnl_rptcotizacion.Visible = false;
					pnl_gastos.Visible = true;
					pnl_inventarios.Visible = false;
					pnl_sucursales.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = false;

					i_editausuario.Attributes["style"] = "color:#079DBC";
					i_editacentro.Attributes["style"] = "color:#079DBC";
					i_editacentrof.Attributes["style"] = "color:#079DBC";
					i_resumen.Attributes["style"] = "color:#079DBC";
					i_ventas.Attributes["style"] = "color:#079DBC";
					i_gastos.Attributes["style"] = "color:#B9005C";
					i_inventarios.Attributes["style"] = "color:#079DBC";
					i_sucursales.Attributes["style"] = "color:#079DBC";
					i_proveedores.Attributes["style"] = "color:#079DBC";
					i_alumnos.Attributes["style"] = "color:#079DBC";
					i_usuarios.Attributes["style"] = "color:#079DBC";
					i_empresa.Attributes["style"] = "color:#079DBC";
					i_salir.Attributes["style"] = "color:#079DBC";

					limpiar_txt_gastos();

					txt_buscar_gasto.Text = null;
					txt_buscar_gasto.Visible = false;
					btn_buscar_gasto.Visible = false;
					gv_gasto.Visible = false;

					i_agrega_gasto.Attributes["style"] = "color:#079DBC";
					i_edita_gasto.Attributes["style"] = "color:#079DBC";
					i_baja_gasto.Attributes["style"] = "color:#079DBC";

					break;
				case 6:

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					pnl_resumen.Visible = false;
					pnl_ventas.Visible = false;
					pnl_alumnosV.Visible = false;
					pnl_inventariosV.Visible = false;
					pnl_rptcotizacion.Visible = false;
					pnl_gastos.Visible = false;
					pnl_inventarios.Visible = false;
					pnl_sucursales.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = false;

					i_editausuario.Attributes["style"] = "color:#079DBC";
					i_editacentro.Attributes["style"] = "color:#079DBC";
					i_editacentrof.Attributes["style"] = "color:#079DBC";
					i_resumen.Attributes["style"] = "color:#079DBC";
					i_ventas.Attributes["style"] = "color:#079DBC";
					i_gastos.Attributes["style"] = "color:#079DBC";
					i_inventarios.Attributes["style"] = "color:#079DBC";
					i_sucursales.Attributes["style"] = "color:#079DBC";
					i_proveedores.Attributes["style"] = "color:#079DBC";
					i_alumnos.Attributes["style"] = "color:#079DBC";
					i_usuarios.Attributes["style"] = "color:#079DBC";
					i_empresa.Attributes["style"] = "color:#079DBC";
					i_salir.Attributes["style"] = "color:#079DBC";

					break;
				case 7:

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					pnl_resumen.Visible = false;
					pnl_ventas.Visible = false;
					pnl_alumnosV.Visible = false;
					pnl_inventariosV.Visible = false;
					pnl_rptcotizacion.Visible = false;
					pnl_gastos.Visible = false;
					pnl_inventarios.Visible = false;
					pnl_sucursales.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = false;

					i_editausuario.Attributes["style"] = "color:#079DBC";
					i_editacentro.Attributes["style"] = "color:#079DBC";
					i_editacentrof.Attributes["style"] = "color:#079DBC";
					i_resumen.Attributes["style"] = "color:#079DBC";
					i_ventas.Attributes["style"] = "color:#079DBC";
					i_gastos.Attributes["style"] = "color:#079DBC";
					i_inventarios.Attributes["style"] = "color:#079DBC";
					i_sucursales.Attributes["style"] = "color:#079DBC";
					i_proveedores.Attributes["style"] = "color:#079DBC";
					i_alumnos.Attributes["style"] = "color:#079DBC";
					i_usuarios.Attributes["style"] = "color:#079DBC";
					i_empresa.Attributes["style"] = "color:#079DBC";
					i_salir.Attributes["style"] = "color:#079DBC";

					break;
				case 8:
					int_accion_inventario = 0;

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					pnl_resumen.Visible = false;
					pnl_ventas.Visible = false;
					pnl_alumnosV.Visible = false;
					pnl_inventariosV.Visible = false;
					pnl_rptcotizacion.Visible = false;
					pnl_gastos.Visible = false;
					pnl_inventarios.Visible = false;
					pnl_sucursales.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_inventarios.Visible = true;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = false;

					i_editausuario.Attributes["style"] = "color:#079DBC";
					i_editacentro.Attributes["style"] = "color:#079DBC";
					i_editacentrof.Attributes["style"] = "color:#079DBC";
					i_resumen.Attributes["style"] = "color:#079DBC";
					i_ventas.Attributes["style"] = "color:#079DBC";
					i_gastos.Attributes["style"] = "color:#079DBC";
					i_inventarios.Attributes["style"] = "color:#B9005C";
					i_sucursales.Attributes["style"] = "color:#079DBC";
					i_alumnos.Attributes["style"] = "color:#079DBC";
					i_usuarios.Attributes["style"] = "color:#079DBC";
					i_empresa.Attributes["style"] = "color:#079DBC";
					i_salir.Attributes["style"] = "color:#079DBC";

					limpiart_txt_inventario();

					i_agrega_inventario.Attributes["style"] = "color:#079DBC";
					i_edita_inventario.Attributes["style"] = "color:#079DBC";
					i_baja_inventario.Attributes["style"] = "color:#079DBC";

					break;
				case 9:

					int_accion_sucursal = 0;

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					pnl_resumen.Visible = false;
					pnl_ventas.Visible = false;
					pnl_alumnosV.Visible = false;
					pnl_inventariosV.Visible = false;
					pnl_rptcotizacion.Visible = false;
					pnl_gastos.Visible = false;
					pnl_inventarios.Visible = false;
					pnl_sucursales.Visible = true;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = false;

					i_editausuario.Attributes["style"] = "color:#079DBC";
					i_editacentro.Attributes["style"] = "color:#079DBC";
					i_editacentrof.Attributes["style"] = "color:#079DBC";
					i_resumen.Attributes["style"] = "color:#079DBC";
					i_ventas.Attributes["style"] = "color:#079DBC";
					i_gastos.Attributes["style"] = "color:#079DBC";
					i_inventarios.Attributes["style"] = "color:#079DBC";
					i_sucursales.Attributes["style"] = "color:#B9005C";
					i_proveedores.Attributes["style"] = "color:#079DBC";
					i_alumnos.Attributes["style"] = "color:#079DBC";
					i_usuarios.Attributes["style"] = "color:#079DBC";
					i_empresa.Attributes["style"] = "color:#079DBC";
					i_salir.Attributes["style"] = "color:#079DBC";

					limpia_txt_sucursal();

					txt_buscar_sucursal.Text = "";
					txt_buscar_sucursal.Visible = false;
					btn_buscar_sucursal.Visible = false;
					gv_sucursal.Visible = false;
					gv_administrador.Visible = false;

					i_agrega_sucursal.Attributes["style"] = "color:#079DBC";
					i_edita_sucursal.Attributes["style"] = "color:#079DBC";
					i_baja_sucursal.Attributes["style"] = "color:#079DBC";

					break;
				case 10:

					int_accion_proveedor = 0;

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					pnl_resumen.Visible = false;
					pnl_ventas.Visible = false;
					pnl_alumnosV.Visible = false;
					pnl_inventariosV.Visible = false;
					pnl_rptcotizacion.Visible = false;
					pnl_gastos.Visible = false;
					pnl_inventarios.Visible = false;
					pnl_sucursales.Visible = false;
					pnl_proveedores.Visible = true;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;

					i_editausuario.Attributes["style"] = "color:#079DBC";
					i_editacentro.Attributes["style"] = "color:#079DBC";
					i_editacentrof.Attributes["style"] = "color:#079DBC";
					i_resumen.Attributes["style"] = "color:#079DBC";
					i_ventas.Attributes["style"] = "color:#079DBC";
					i_gastos.Attributes["style"] = "color:#079DBC";
					i_inventarios.Attributes["style"] = "color:#079DBC";
					i_sucursales.Attributes["style"] = "color:#079DBC";
					i_proveedores.Attributes["style"] = "color:#B9005C";
					i_alumnos.Attributes["style"] = "color:#079DBC";
					i_usuarios.Attributes["style"] = "color:#079DBC";
					i_empresa.Attributes["style"] = "color:#079DBC";
					i_salir.Attributes["style"] = "color:#079DBC";

					limpia_txt_proveedor();

					i_agrega_proveedor.Attributes["style"] = "color:#079DBC";
					i_edita_proveedor.Attributes["style"] = "color:#079DBC";
					i_baja_proveedor.Attributes["style"] = "color:#079DBC";

					txt_buscar_proveedor.Visible = false;
					btn_buscar_proveedor.Visible = false;
					gv_proveedor.Visible = false;

					break;
				case 11:

					int_accion_alumno = 0;

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					pnl_resumen.Visible = false;
					pnl_ventas.Visible = false;
					pnl_alumnosV.Visible = false;
					pnl_inventariosV.Visible = false;
					pnl_rptcotizacion.Visible = false;
					pnl_gastos.Visible = false;
					pnl_inventarios.Visible = false;
					pnl_sucursales.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = true;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = false;

					i_editausuario.Attributes["style"] = "color:#079DBC";
					i_editacentro.Attributes["style"] = "color:#079DBC";
					i_editacentrof.Attributes["style"] = "color:#079DBC";
					i_resumen.Attributes["style"] = "color:#079DBC";
					i_ventas.Attributes["style"] = "color:#079DBC";
					i_gastos.Attributes["style"] = "color:#079DBC";
					i_inventarios.Attributes["style"] = "color:#079DBC";
					i_sucursales.Attributes["style"] = "color:#079DBC";
					i_proveedores.Attributes["style"] = "color:#079DBC";
					i_alumnos.Attributes["style"] = "color:#B9005C";
					i_usuarios.Attributes["style"] = "color:#079DBC";
					i_empresa.Attributes["style"] = "color:#079DBC";
					i_salir.Attributes["style"] = "color:#079DBC";


					limpia_txt_alumnos();

					i_agrega_alumno.Attributes["style"] = "color:#079DBC";
					i_edita_alumno.Attributes["style"] = "color:#079DBC";

					break;
				case 12:

					int_accion_usuario = 0;

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					pnl_resumen.Visible = false;
					pnl_ventas.Visible = false;
					pnl_alumnosV.Visible = false;
					pnl_inventariosV.Visible = false;
					pnl_rptcotizacion.Visible = false;
					pnl_gastos.Visible = false;
					pnl_inventarios.Visible = false;
					pnl_sucursales.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = true;
					pnl_empresa.Visible = false;

					i_editausuario.Attributes["style"] = "color:#079DBC";
					i_editacentro.Attributes["style"] = "color:#079DBC";
					i_editacentrof.Attributes["style"] = "color:#079DBC";
					i_resumen.Attributes["style"] = "color:#079DBC";
					i_ventas.Attributes["style"] = "color:#079DBC";
					i_gastos.Attributes["style"] = "color:#079DBC";
					i_inventarios.Attributes["style"] = "color:#079DBC";
					i_sucursales.Attributes["style"] = "color:#079DBC";
					i_proveedores.Attributes["style"] = "color:#079DBC";
					i_alumnos.Attributes["style"] = "color:#079DBC";
					i_usuarios.Attributes["style"] = "color:#B9005C";
					i_empresa.Attributes["style"] = "color:#079DBC";
					i_salir.Attributes["style"] = "color:#079DBC";

					limpia_txt_usuarios();

					i_agrega_usuario.Attributes["style"] = "color:#079DBC";
					i_edita_usuario.Attributes["style"] = "color:#079DBC";

					break;
				case 13:

					pnl_fusuario.Visible = false;
					pnl_centro.Visible = false;
					pnl_resumen.Visible = false;
					pnl_ventas.Visible = false;
					pnl_alumnosV.Visible = false;
					pnl_inventariosV.Visible = false;
					pnl_rptcotizacion.Visible = false;
					pnl_gastos.Visible = false;
					pnl_inventarios.Visible = false;
					pnl_sucursales.Visible = false;
					pnl_proveedores.Visible = false;
					pnl_alumnos.Visible = false;
					pnl_usuarios.Visible = false;
					pnl_empresa.Visible = true;

					i_editausuario.Attributes["style"] = "color:#079DBC";
					i_editacentro.Attributes["style"] = "color:#079DBC";
					i_editacentrof.Attributes["style"] = "color:#079DBC";
					i_resumen.Attributes["style"] = "color:#079DBC";
					i_ventas.Attributes["style"] = "color:#079DBC";
					i_gastos.Attributes["style"] = "color:#079DBC";
					i_inventarios.Attributes["style"] = "color:#079DBC";
					i_sucursales.Attributes["style"] = "color:#079DBC";
					i_proveedores.Attributes["style"] = "color:#079DBC";
					i_alumnos.Attributes["style"] = "color:#079DBC";
					i_usuarios.Attributes["style"] = "color:#079DBC";
					i_empresa.Attributes["style"] = "color:#B9005C";
					i_editaempresa.Attributes["style"] = "color:#079DBC";
					i_salir.Attributes["style"] = "color:#079DBC";

					limpiar_textbox_empresa();


					break;
				case 14:

					Session.Abandon();
					Response.Redirect("acceso.aspx");

					break;
				default:

					break;
			}
		}

		private void limpiar_txt_resumen()
		{
			txt_fecini.Text = null;
			txt_fecfin.Text = null;
			lbl_fventas.Text = null;
			lbl_fgastos.Text = null;
			lbl_fbalance.Text = null;
			lbl_fclientes.Text = null;
		}

		#endregion

		#region usuario

		protected void btn_guarda_fusuario_Click(object sender, EventArgs e)
		{
			if (ddl_genero_fusuario.SelectedValue == "0")
			{

				ddl_genero_fusuario.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				ddl_genero_fusuario.BackColor = Color.Transparent;
				if (string.IsNullOrEmpty(txt_nombres_fusuario.Text))
				{

					txt_nombres_fusuario.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					txt_nombres_fusuario.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_apaterno_fusuario.Text))
					{

						txt_apaterno_fusuario.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						txt_apaterno_fusuario.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_amaterno_fusuario.Text))
						{

							txt_amaterno_fusuario.BackColor = Color.FromArgb(185, 0, 92);
						}
						else
						{
							txt_amaterno_fusuario.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_cumple_fusuario.Text))
							{

								txt_cumple_fusuario.BackColor = Color.FromArgb(185, 0, 92);
							}
							else
							{
								txt_cumple_fusuario.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_usuario_fusuario.Text))
								{

									txt_usuario_fusuario.BackColor = Color.FromArgb(185, 0, 92);
								}
								else
								{
									txt_usuario_fusuario.BackColor = Color.Transparent;
									if (string.IsNullOrEmpty(txt_clave_fusuario.Text))
									{

										txt_clave_fusuario.BackColor = Color.FromArgb(185, 0, 92);
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
			i_editausuariof.Attributes["style"] = "color:#B9005C";

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
			i_editacentrof.Attributes["style"] = "color:#B9005C";

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

				ddl_licencias_centro.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				ddl_licencias_centro.BackColor = Color.Transparent;
				if (string.IsNullOrEmpty(txt_nombre_centro.Text))
				{

					txt_nombre_centro.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					txt_nombre_centro.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_telefono_centro.Text))
					{

						txt_telefono_centro.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						txt_telefono_centro.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_email_centro.Text))
						{

							txt_email_centro.BackColor = Color.FromArgb(185, 0, 92);
						}
						else
						{
							txt_email_centro.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_callenum_centro.Text))
							{

								txt_callenum_centro.BackColor = Color.FromArgb(185, 0, 92);
							}
							else
							{
								txt_callenum_centro.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_cp_centro.Text))
								{

									txt_cp_centro.BackColor = Color.FromArgb(185, 0, 92);
								}
								else
								{
									txt_cp_centro.BackColor = Color.Transparent;
									if (ddl_colonia_centro.SelectedValue == "0")
									{

										ddl_colonia_centro.BackColor = Color.FromArgb(185, 0, 92);
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

				txt_cp_centro.BackColor = Color.FromArgb(185, 0, 92);
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

		#region resumen

		protected void btn_consultar_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_fecini.Text))
			{

				txt_fecini.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				txt_fecini.BackColor = Color.White;
				if (string.IsNullOrEmpty(txt_fecfin.Text))
				{

					txt_fecfin.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					txt_fecfin.BackColor = Color.White;

					DateTime dt_fecini = DateTime.Parse(txt_fecini.Text);
					DateTime dt_fecfin = DateTime.Parse(txt_fecfin.Text);


					using (db_imEntities edm_centro = new db_imEntities())
					{
						var i_centro = (from u in edm_centro.inf_centro
										 where u.id_centro == guid_centro
										 select u).FirstOrDefault();

						if (i_centro.id_tipo_centro == 1)
						{
							using (db_imEntities edm_alumnos = new db_imEntities())
							{
								var i_alumnos = (from u in edm_alumnos.inf_alumnos
												 where u.fecha_registro >= dt_fecini && u.fecha_registro <= dt_fecfin
												 select u).ToList();

								if (i_alumnos.Count == 0)
								{
									lbl_fclientes.Text = string.Format("{0:N0}", i_alumnos.Count);
								}
								else
								{
									lbl_fclientes.Text = string.Format("{0:N0}", i_alumnos.Count);
								}

							}

							using (db_imEntities edm_ventas = new db_imEntities())
							{
								var i_ventas = (from i_v in edm_ventas.inf_ventas
												join i_vd in edm_ventas.inf_ventas_dep on i_v.id_ventas equals i_vd.id_ventas
												where i_v.fecha_registro >= dt_fecini && i_v.fecha_registro <= dt_fecfin
												select new
												{
													i_v.id_ventas,
													i_v.inf_centro,
													i_vd.cantidad,
													i_vd.costo,
													tventa = i_vd.cantidad * i_vd.costo

												}).ToList();

								if (i_ventas.Count == 0)
								{
									lbl_fventas.Text = string.Format("{0:N0}", i_ventas.Count);
								}
								else
								{
									dml_ventas = decimal.Parse(i_ventas.Sum(x => x.tventa).ToString());

									//foreach (var ii_ventas in i_ventas)
									//{
									//	int int_cantidad = int.Parse(ii_ventas.su);
									//}


									lbl_fventas.Text = string.Format("{0:C}", (object)(Math.Truncate(Convert.ToDouble(dml_ventas) * 100.0) / 100.0));
								}

							}

							using (db_imEntities edm_gastos = new db_imEntities())
							{
								var i_gastos = (from i_g in edm_gastos.inf_gastos
												where i_g.fecha_registro >= dt_fecini && i_g.fecha_registro <= dt_fecfin
												select new
												{
													i_g.id_centro,
													i_g.cantidad,
													i_g.costo,
													tgasto = i_g.cantidad * i_g.costo

												}).ToList();

								if (i_gastos.Count == 0)
								{
									dml_gastos = i_gastos.Count;
									lbl_fgastos.Text = string.Format("{0:C}", i_gastos.Count);
								}
								else
								{
									dml_gastos = decimal.Parse(i_gastos.Sum(x => x.tgasto).ToString());
									lbl_fgastos.Text = string.Format("{0:C}", (object)(Math.Truncate(Convert.ToDouble(dml_gastos) * 100.0) / 100.0));
								}

							}

							lbl_fbalance.Text = string.Format("{0:C}", (object)(Math.Truncate(Convert.ToDouble(dml_ventas - dml_gastos) * 100.0) / 100.0));
						}
						else
						{
							using (db_imEntities edm_alumnos = new db_imEntities())
							{
								var i_alumnos = (from u in edm_alumnos.inf_alumnos
												 where u.fecha_registro >= dt_fecini && u.fecha_registro <= dt_fecfin
												 where u.id_centro == guid_centro
												 select u).ToList();

								if (i_alumnos.Count == 0)
								{
									lbl_fclientes.Text = string.Format("{0:N0}", i_alumnos.Count);
								}
								else
								{
									lbl_fclientes.Text = string.Format("{0:N0}", i_alumnos.Count);
								}

							}

							using (db_imEntities edm_ventas = new db_imEntities())
							{
								var i_ventas = (from i_v in edm_ventas.inf_ventas
												join i_vd in edm_ventas.inf_ventas_dep on i_v.id_ventas equals i_vd.id_ventas
												where i_v.fecha_registro >= dt_fecini && i_v.fecha_registro <= dt_fecfin
												where i_v.id_centro == guid_centro
												select new
												{
													i_v.id_ventas,
													i_v.inf_centro,
													i_vd.cantidad,
													i_vd.costo,
													tventa = i_vd.cantidad * i_vd.costo

												}).ToList();

								if (i_ventas.Count == 0)
								{
									lbl_fventas.Text = string.Format("{0:N0}", i_ventas.Count);
								}
								else
								{
									dml_ventas = decimal.Parse(i_ventas.Sum(x => x.tventa).ToString());

									//foreach (var ii_ventas in i_ventas)
									//{
									//	int int_cantidad = int.Parse(ii_ventas.su);
									//}


									lbl_fventas.Text = string.Format("{0:C}", (object)(Math.Truncate(Convert.ToDouble(dml_ventas) * 100.0) / 100.0));
								}

							}

							using (db_imEntities edm_gastos = new db_imEntities())
							{
								var i_gastos = (from i_g in edm_gastos.inf_gastos
												where i_g.fecha_registro >= dt_fecini && i_g.fecha_registro <= dt_fecfin
												where i_g.id_centro == guid_centro
												select new
												{
													i_g.id_centro,
													i_g.cantidad,
													i_g.costo,
													tgasto = i_g.cantidad * i_g.costo

												}).ToList();

								if (i_gastos.Count == 0)
								{
									dml_gastos = i_gastos.Count;
									lbl_fgastos.Text = string.Format("{0:C}", i_gastos.Count);
								}
								else
								{
									dml_gastos = decimal.Parse(i_gastos.Sum(x => x.tgasto).ToString());
									lbl_fgastos.Text = string.Format("{0:C}", (object)(Math.Truncate(Convert.ToDouble(dml_gastos) * 100.0) / 100.0));
								}

							}

							lbl_fbalance.Text = string.Format("{0:C}", (object)(Math.Truncate(Convert.ToDouble(dml_ventas - dml_gastos) * 100.0) / 100.0));
						}

					}


				}
			}



		}
		protected void lkb_fventas_Click(object sender, EventArgs e)
		{




		}




		#endregion

		#region ventas

		protected void lkbtn_nueva_venta_Click(object sender, EventArgs e)
		{
			int_accion_venta = 1;
			txt_idventa.Visible = true;
			ddl_tipoventa.Visible = true;
			btn_anexacliente_venta.Visible = true;
			i_nueva_venta.Attributes["style"] = "color:#B9005C";
			i_edita_venta.Attributes["style"] = "color:#B9005C";
			i_baja_venta.Attributes["style"] = "color:#079DBC";
			limpiar_txt_ventas();

			div_fecini_vta.Visible = false;
			div_fecfin_vta.Visible = false;
			btn_consultar_vta.Visible = false;

			DateTime now = DateTime.Now;
			string str1 = string.Format("{0:00}", (object)now.Year);
			string str2 = string.Format("{0:00}", (object)now.Month);
			string str3 = string.Format("{0:00}", (object)now.Day);
			string str;
			guid_idventa = Guid.NewGuid();
			string str_idventa;

			using (db_imEntities edm_ventas = new db_imEntities())
			{
				var i_ventas = (from c in edm_ventas.inf_ventas
								where c.id_centro == guid_centro
								select c).ToList();

				if (i_ventas.Count == 0)
				{
					str = string.Format("{0:000}", (object)(i_ventas.Count + 1));
					str_idventa = "intm_vta" + str1 + str2 + str3 + str;

					using (var edm_venta = new db_imEntities())
					{
						var i_venta = new inf_ventas
						{
							id_ventas = guid_idventa,
							id_estatus = 1,
							codigo_venta = str_idventa,
							tipo_venta = 1,
							id_usuario = guid_iduser,
							id_centro = guid_centro,
							fecha_registro = DateTime.Now
						};
						edm_venta.inf_ventas.Add(i_venta);
						edm_venta.SaveChanges();
					}
				}
				else
				{
					str = string.Format("{0:000}", (object)(i_ventas.Count + 1));

					str_idventa = "intm_vta" + str1 + str2 + str3 + str;

					using (var edm_venta = new db_imEntities())
					{
						var i_venta = new inf_ventas
						{
							id_ventas = guid_idventa,
							id_estatus = 1,
							codigo_venta = str_idventa,
							tipo_venta = 1,
							id_usuario = guid_iduser,
							id_centro = guid_centro,
							fecha_registro = DateTime.Now
						};
						edm_venta.inf_ventas.Add(i_venta);
						edm_venta.SaveChanges();
					}
				}
			}

			txt_idventa.Text = str_idventa;

			lblModalTitle.Text = "Intelimundo";
			lblModalBody.Text = "ID de venta (" + str_idventa + ") creado con éxito";
			ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
			upModal.Update();
		}

		protected void lkbtn_edita_venta_Click(object sender, EventArgs e)
		{

		}

		protected void lkbtn_baja_venta_Click(object sender, EventArgs e)
		{
			int_accion_venta = 2;
			i_nueva_venta.Attributes["style"] = "color:#079DBC";
			i_edita_venta.Attributes["style"] = "color:#079DBC";
			i_baja_venta.Attributes["style"] = "color:#B9005C";
			limpiar_txt_ventas();

			txt_idventa.Visible = false;
			ddl_tipoventa.Visible = false;
			btn_anexacliente_venta.Visible = false;
			div_fecini_vta.Visible = true;
			div_fecfin_vta.Visible = true;
			btn_consultar_vta.Visible = true;

			
		}

		protected void btn_buscar_inventarioV_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_buscar_inventarioV.Text))
			{
				txt_buscar_inventarioV.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				txt_buscar_inventarioV.BackColor = Color.Transparent;
				string str_userb = txt_buscar_inventarioV.Text;

				using (db_imEntities edm_servicios = new db_imEntities())
				{
					var i_servicios = (from i_u in edm_servicios.inf_inventario
									   join i_g in edm_servicios.fact_grado_escolar on i_u.id_grado_escolar equals i_g.id_grado_escolar
									   join i_n in edm_servicios.fact_nivel_escolar on i_g.id_nivel_escolar equals i_n.id_nivel_escolar
									   where i_u.caracteristica.Contains(str_userb)

									   select new
									   {
										   i_u.id_codigo_inventario,
										   i_n.desc_nivel_escolar,
										   i_g.desc_grado_escolar,
										   i_u.categoria,
										   i_u.caracteristica,
										   i_u.costo

									   }).ToList();

					if (i_servicios.Count == 0)
					{
						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Servicio no encontrado, favor de reintentar";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();
					}
					else
					{
						gv_inventarioV.DataSource = i_servicios;
						gv_inventarioV.DataBind();
						gv_inventarioV.Visible = true;
					}
				}
			}
		}

		protected void gv_inventarioV_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
		}

		protected void chk_inventarioV_CheckedChanged(object sender, EventArgs e)
		{
			foreach (GridViewRow row in gv_inventarioV.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					if ((row.Cells[0].FindControl("chk_inventarioV") as CheckBox).Checked)
					{
						row.BackColor = Color.FromArgb(185, 0, 92);
						string str_code = row.Cells[1].Text;
						using (db_imEntities edm_inventario = new db_imEntities())
						{
							var i_inventario = (from u in edm_inventario.inf_inventario
												where u.id_codigo_inventario == str_code

												select new
												{
													u.id_inventario,
													u.costo,

												}).FirstOrDefault();


							txt_costo_inventarioV.Text = string.Format("{0:n2}", (object)(Math.Truncate(Convert.ToDouble((object)i_inventario.costo) * 100.0) / 100.0));
						}
					}
					else
						row.BackColor = Color.White;
				}
			}
		}

		protected void btn_guardar_inventarioV_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_idventa.Text))
			{
				txt_idventa.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				txt_idventa.BackColor = Color.Transparent;
				if (string.IsNullOrEmpty(txt_cantidad_inventarioV.Text))
				{
					txt_cantidad_inventarioV.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					txt_cantidad_inventarioV.BackColor = Color.Transparent;
					guardar_ventas();
				}
			}
		}

		protected void btn_anexa_inventarioV_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_idventa.Text))
			{
				txt_idventa.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				txt_idventa.BackColor = Color.Transparent;
				if (string.IsNullOrEmpty(txt_cantidad_inventarioV.Text))
				{
					txt_cantidad_inventarioV.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					txt_cantidad_inventarioV.BackColor = Color.Transparent;
					anexa_ventas();
				}
			}
		}

		private void anexa_ventas()
		{
			Decimal dml_costoinv;

			if (chkb_descuentoV.Checked)
			{
				if (string.IsNullOrEmpty(txt_descuentoV.Text))
				{
					txt_descuentoV.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					txt_descuentoV.BackColor = Color.Transparent;

					dml_costoinv = Decimal.Parse(txt_descuentoV.Text);

					foreach (GridViewRow row in gv_inventarioV.Rows)
					{
						if (row.RowType == DataControlRowType.DataRow)
						{
							if ((row.Cells[0].FindControl("chk_inventarioV") as CheckBox).Checked)
							{
								row.BackColor = Color.FromArgb(185, 0, 92);
								string str_code = row.Cells[1].Text;
								using (db_imEntities edm_inventario = new db_imEntities())
								{
									var i_inventario = (from u in edm_inventario.inf_inventario
														where u.id_codigo_inventario == str_code
														select new
														{
															u.id_inventario,
														}).FirstOrDefault();

									guid_idinventario = i_inventario.id_inventario;

								}
							}
							else
								row.BackColor = Color.White;
						}
					}

					int int_cantidadinv = int.Parse(txt_cantidad_inventarioV.Text);

					using (db_imEntities edm_inventario = new db_imEntities())
					{
						var i_inventario = (from u in edm_inventario.inf_ventas
											where u.id_ventas == guid_idventa
											select new
											{
												u.id_ventas,
											}).FirstOrDefault();

						guid_idventa = i_inventario.id_ventas;

					}

					using (db_imEntities edm_inventario = new db_imEntities())
					{
						var i_inventario = (from u in edm_inventario.inf_ventas_dep
											where u.id_ventas == guid_idventa
											where u.id_inventario == guid_idinventario
											select new
											{
												u.id_inventario,
												u.cantidad

											}).ToList();

						if (i_inventario.Count == 0)
						{

							using (db_imEntities dbImEntities = new db_imEntities())
							{
								inf_ventas_dep infVentasDep = new inf_ventas_dep()
								{
									id_inventario = guid_idinventario,
									cantidad = int_cantidadinv,
									costo = dml_costoinv,
									id_ventas = guid_idventa
								};
								dbImEntities.inf_ventas_dep.Add(infVentasDep);
								dbImEntities.SaveChanges();
							}
						}
						else
						{

							using (var m_fempresa = new db_imEntities())
							{
								var i_fempresa = (from c in m_fempresa.inf_ventas_dep
												  where c.id_ventas == guid_idventa
												  select c).FirstOrDefault();

								i_fempresa.cantidad = int_cantidadinv;
								i_fempresa.costo = dml_costoinv;
								m_fempresa.SaveChanges();
							}
						}
					}

					using (db_imEntities edm_servicios = new db_imEntities())
					{
						var i_servicios = (from i_v in edm_servicios.inf_ventas_dep
										   join i_i in edm_servicios.inf_inventario on i_v.id_inventario equals i_i.id_inventario
										   join i_g in edm_servicios.fact_grado_escolar on i_i.id_grado_escolar equals i_g.id_grado_escolar
										   join i_n in edm_servicios.fact_nivel_escolar on i_g.id_nivel_escolar equals i_n.id_nivel_escolar
										   where i_v.id_ventas == guid_idventa
										   select new
										   {
											   i_i.id_codigo_inventario,
											   i_n.desc_nivel_escolar,
											   i_g.desc_grado_escolar,
											   i_i.categoria,
											   i_i.caracteristica,
											   i_v.costo

										   }).ToList();

						gv_inventarioF.DataSource = i_servicios;
						gv_inventarioF.DataBind();
						gv_inventarioF.Visible = true;
					}


					gv_alumnosF.Visible = true;
					pnl_inventariosV.Visible = false;

					btn_anexa_servicios.Visible = true;
					btn_ver_rpt.Visible = true;


					lblModalTitle.Text = "Intelimundo";
					lblModalBody.Text = "Servicio agregada con exito";
					ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
					upModal.Update();
				}

			}
			else
			{
				dml_costoinv = decimal.Parse(txt_costo_inventarioV.Text);

				foreach (GridViewRow row in gv_inventarioV.Rows)
				{
					if (row.RowType == DataControlRowType.DataRow)
					{
						if ((row.Cells[0].FindControl("chk_inventarioV") as CheckBox).Checked)
						{
							row.BackColor = Color.FromArgb(185, 0, 92);
							string str_code = row.Cells[1].Text;
							using (db_imEntities edm_inventario = new db_imEntities())
							{
								var i_inventario = (from u in edm_inventario.inf_inventario
													where u.id_codigo_inventario == str_code
													select new
													{
														u.id_inventario,
													}).FirstOrDefault();

								guid_idinventario = i_inventario.id_inventario;

							}
						}
						else
							row.BackColor = Color.White;
					}
				}

				int int_cantidadinv = int.Parse(txt_cantidad_inventarioV.Text);

				using (db_imEntities edm_inventario = new db_imEntities())
				{
					var i_inventario = (from u in edm_inventario.inf_ventas
										where u.id_ventas == guid_idventa
										select new
										{
											u.id_ventas,
										}).FirstOrDefault();

					guid_idventa = i_inventario.id_ventas;

				}

				using (db_imEntities edm_inventario = new db_imEntities())
				{
					var i_inventario = (from u in edm_inventario.inf_ventas_dep
										where u.id_ventas == guid_idventa
										where u.id_inventario == guid_idinventario
										select new
										{
											u.id_inventario,
											u.cantidad

										}).ToList();

					if (i_inventario.Count == 0)
					{

						using (db_imEntities dbImEntities = new db_imEntities())
						{
							inf_ventas_dep infVentasDep = new inf_ventas_dep()
							{
								id_inventario = guid_idinventario,
								cantidad = int_cantidadinv,
								costo = dml_costoinv,
								id_ventas = guid_idventa
							};
							dbImEntities.inf_ventas_dep.Add(infVentasDep);
							dbImEntities.SaveChanges();
						}
					}
					else
					{

						using (var m_fempresa = new db_imEntities())
						{
							var i_fempresa = (from c in m_fempresa.inf_ventas_dep
											  where c.id_inventario == guid_idinventario
											  where c.id_ventas == guid_idventa
											  select c).FirstOrDefault();

							i_fempresa.cantidad = int_cantidadinv;
							i_fempresa.costo = dml_costoinv;
							m_fempresa.SaveChanges();
						}
					}
				}

				using (db_imEntities edm_servicios = new db_imEntities())
				{
					var i_servicios = (from i_v in edm_servicios.inf_ventas_dep
									   join i_i in edm_servicios.inf_inventario on i_v.id_inventario equals i_i.id_inventario
									   join i_g in edm_servicios.fact_grado_escolar on i_i.id_grado_escolar equals i_g.id_grado_escolar
									   join i_n in edm_servicios.fact_nivel_escolar on i_g.id_nivel_escolar equals i_n.id_nivel_escolar
									   where i_v.id_ventas == guid_idventa
									   select new
									   {
										   i_i.id_codigo_inventario,
										   i_n.desc_nivel_escolar,
										   i_g.desc_grado_escolar,
										   i_i.categoria,
										   i_i.caracteristica,
										   i_v.costo

									   }).ToList();

					gv_inventarioF.DataSource = i_servicios;
					gv_inventarioF.DataBind();
					gv_inventarioF.Visible = true;
				}


				gv_alumnosF.Visible = true;
				pnl_inventariosV.Visible = false;

				btn_anexa_servicios.Visible = true;
				btn_ver_rpt.Visible = true;


				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Servicio agregada con exito";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();


			}
		}

		private void guardar_ventas()
		{
			Decimal num1;
			if (chkb_descuentoV.Checked)
			{
				num1 = Decimal.Parse(txt_descuentoV.Text);
			}
			else
			{
			}
			Guid guid_nventa;


			gv_alumnosF.Visible = true;
			pnl_inventariosV.Visible = false;
			((Control)ReportViewer1).Visible = true;
			btn_ver_rpt.Visible = true;
			lblModalTitle.Text = "Intelimundo";
			lblModalBody.Text = "Venta agregada con exito";
			ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
			upModal.Update();
		}

		private void limpiar_txt_ventas()
		{
			txt_idventa.Text = null;

			btn_anexa_servicios.Visible = false;
			btn_ver_rpt.Visible = false;
			gv_alumnosV.DataSource = (object)"";
			pnl_alumnosV.Visible = false;
			pnl_inventariosV.Visible = false;
			chkb_descuentoV.Checked = false;
			txt_cantidad_inventarioV.Text = "";
			gv_alumnosF.Visible = false;
			gv_alumnosF.DataSource = (object)"";
			gv_inventarioF.Visible = false;
			gv_inventarioF.DataSource = (object)"";
			gv_inventarioV.Visible = false;
			gv_inventarioV.DataSource = (object)"";
			pnl_rptcotizacion.Visible = false;
			btn_anexa_servicios.Visible = false;
			ddl_tipoventa.SelectedValue = "SELECCIONAR";
			ddl_tipoventa.Enabled = true;

		}

		protected void chkb_descuentoV_CheckedChanged(object sender, EventArgs e)
		{
			if (chkb_descuentoV.Checked)
				txt_descuentoV.Enabled = true;
			else
				txt_descuentoV.Enabled = false;
		}

		protected void btn_ver_rpt_Click(object sender, EventArgs e)
		{

			default_rpt();
		}
		protected void btn_anexacliente_venta_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_idventa.Text))
			{
				txt_idventa.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				txt_idventa.BackColor = Color.Transparent;
				int num = !(ddl_tipoventa.SelectedValue == "REMISIÓN") ? 2 : 1;
				if (ddl_tipoventa.SelectedValue == "SELECCIONAR")
				{
					ddl_tipoventa.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					ddl_tipoventa.BackColor = Color.Transparent;

					txt_buscar_alumnoV.Text = "";
					ddl_tipoventa.Enabled = false;
					btn_anexacliente_venta.Visible = false;
					gv_alumnosV.DataSource = (object)"";
					gv_alumnosV.Visible = false;
					pnl_alumnosV.Visible = true;
					txt_buscar_alumnoV.Visible = true;
					btn_buscar_alumnoV.Visible = true;
				}
			}

		}

		protected void chk_alumnoV_CheckedChanged(object sender, EventArgs e)
		{
			foreach (GridViewRow row in gv_alumnosV.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					if ((row.Cells[0].FindControl("chk_alumnoV") as CheckBox).Checked)
					{
						row.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						row.BackColor = Color.White;
					}
				}
			}
		}

		protected void btn_buscar_alumnoV_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_buscar_alumnoV.Text))
			{
				txt_buscar_alumnoV.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				txt_buscar_alumnoV.BackColor = Color.Transparent;
				string str_userb = txt_buscar_alumnoV.Text;

				using (db_imEntities edm_alumnof = new db_imEntities())
				{
					var i_alumnof = (from u in edm_alumnof.inf_alumnos
									 where u.nombres.Contains(str_userb)
									 where u.id_centro == guid_centro
									 select new
									 {
										 u.id_codigo_alumno,
										 u.nombres,
										 u.a_paterno,
										 u.a_materno,
										 u.fecha_registro

									 }).ToList();

					if (i_alumnof.Count == 0)
					{
						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Alumno no encontrado, favor de reintentar";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();
					}
					else
					{
						gv_alumnosV.DataSource = i_alumnof;
						gv_alumnosV.DataBind();
						gv_alumnosV.Visible = true;
					}
				}
			}
		}

		protected void btn_avexa_alumno_Click(object sender, EventArgs e)
		{
			foreach (GridViewRow row in gv_alumnosV.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkRow = (row.Cells[0].FindControl("chk_alumnoV") as CheckBox);
					if (chkRow.Checked)
					{
						row.BackColor = Color.FromArgb(185, 0, 92);
						cventa = row.Cells[1].Text;
						int_cventa = 1;
						int_cventa = int_cventa + 1;
					}
					else
					{
						row.BackColor = Color.White;
					}
				}
			}

			if (int_cventa == 0)
			{
				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Favor de seleccionar Alumno";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();
			}
			else
			{
				using (db_imEntities edm_alumnof = new db_imEntities())
				{
					var i_alumnof = (from u in edm_alumnof.inf_alumnos
									 where u.id_codigo_alumno == cventa

									 select u).FirstOrDefault();

					guidalumno = i_alumnof.id_alumno;
				}

				using (db_imEntities edm_alumnof = new db_imEntities())
				{
					var i_alumnof = (from u in edm_alumnof.inf_alumnos
									 where u.id_alumno == guidalumno

									 select new
									 {
										 u.id_codigo_alumno,
										 u.nombres,
										 u.a_paterno,
										 u.a_materno,
										 u.fecha_registro

									 }).ToList();

					if (i_alumnof.Count == 0)
					{
						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Alumno no encontrado, favor de reintentar";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();
					}
					else
					{

						using (var m_fempresa = new db_imEntities())
						{
							var i_fempresa = (from c in m_fempresa.inf_ventas
											  where c.id_ventas == guid_idventa

											  select c).FirstOrDefault();
							i_fempresa.id_alumno = guidalumno;
							m_fempresa.SaveChanges();
						}

						gv_alumnosF.DataSource = i_alumnof;
						gv_alumnosF.DataBind();
						gv_alumnosF.Visible = true;

						txt_cantidad_inventarioV.Text = "";
						pnl_alumnosV.Visible = false;
						chkb_descuentoV.Checked = false;
						txt_costo_inventarioV.Text = "";
						txt_buscar_inventarioV.Visible = true;
						btn_buscar_inventarioV.Visible = true;
						pnl_inventariosV.Visible = true;
						txt_buscar_inventarioV.Text = "";
						gv_inventarioV.Visible = false;
						gv_inventarioV.DataSource = (object)"";
						txt_descuentoV.Text = "";

						int_cventa = 0;
					}
				}
			}
		}

		protected void btn_anexa_servicios_Click(object sender, EventArgs e)
		{
			txt_cantidad_inventarioV.Text = "";
			pnl_alumnosV.Visible = false;
			chkb_descuentoV.Checked = false;
			txt_costo_inventarioV.Text = "";
			txt_buscar_inventarioV.Visible = true;
			btn_buscar_inventarioV.Visible = true;
			pnl_inventariosV.Visible = true;
			txt_buscar_inventarioV.Text = "";
			gv_inventarioV.Visible = false;
			gv_inventarioV.DataSource = (object)"";
			txt_descuentoV.Text = "";
			pnl_rptcotizacion.Visible = false;
		}

		private void default_rpt()
		{

			string str_idventa = txt_idventa.Text;
			pnl_rptcotizacion.Visible = true;
			DateTime.Now.ToShortDateString().Replace("/", "");

			//using (db_imEntities data_user = new db_imEntities())
			//{
			//	var inf_user = (from a in data_user.rpt_cotizacion("636529437629048583")
			//					select a).ToList();
			//}


			string str_date = DateTime.Now.ToShortDateString().Replace("/", "");
			ReportViewer1.ProcessingMode = ProcessingMode.Local;
			ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/remision.rdl");
			System.Data.DataSet ds = new System.Data.DataSet();
			SqlDataAdapter da = new SqlDataAdapter();
			SqlCommand cmd = new SqlCommand(@"SELECT  [id_ventas]
      ,[codigo_venta]
      ,[tipo_venta]
      ,[fecha_registro]
      ,[desc_tipo_usuario]
      ,[nombres]
      ,[a_paterno]
      ,[a_materno]
      ,[nombres_alumno]
      ,[apaterno_alumno]
      ,[amaterno_alumno]
      ,[id_codigo_centro]
      ,[nombre]
      ,[telefono]
      ,[email]
      ,[callenum]
      ,[d_codigo]
      ,[d_asenta]
      ,[D_mnpio]
      ,[d_estado]
      ,[d_ciudad]
      ,[id_codigo_inventario]
      ,[desc_nivel_escolar]
      ,[desc_grado_escolar]
      ,[categoria]
      ,[desc_inventario]
      ,[caracteristica]
      ,[cantidad]
      ,[costo_ini]
      ,[costo]
  FROM [db_im].[u_im].[v_rptremision]
WHERE [id_ventas] in ('" + guid_idventa + "')");
			cmd.CommandType = CommandType.Text;
			cmd.Connection = new SqlConnection(cn.CadenaConexion);
			da.SelectCommand = cmd;

			da.Fill(ds, "DataSet1");
			ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
			ReportViewer1.LocalReport.DataSources.Clear();
			ReportViewer1.LocalReport.DataSources.Add(datasource);
			ReportViewer1.LocalReport.DisplayName = "vta_" + str_date + "";
			ReportViewer1.LocalReport.Refresh();


		}

		protected void btn_cancela_ventas_Click(object sender, EventArgs e)
		{
			txt_idventa.Enabled = true;
			ddl_tipoventa.Visible = false;
			btn_anexacliente_venta.Visible = false;

			btn_ver_rpt.Visible = false;
		}


		protected void btn_consultar_vta_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_fecini_vta.Text))
			{

				txt_fecini_vta.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				txt_fecini_vta.BackColor = Color.White;
				if (string.IsNullOrEmpty(txt_fecfin_vta.Text))
				{

					txt_fecfin_vta.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					txt_fecfin_vta.BackColor = Color.White;

					DateTime dt_fecini = DateTime.Parse(txt_fecini_vta.Text);
					DateTime dt_fecfin = DateTime.Parse(txt_fecfin_vta.Text);

					using (db_imEntities edm_ventas = new db_imEntities())
					{
						var i_ventas = (from i_v in edm_ventas.inf_ventas
										join i_e in edm_ventas.fact_estatus on i_v.id_estatus equals i_e.id_estatus
										where i_v.fecha_registro >= dt_fecini && i_v.fecha_registro <= dt_fecfin
										where i_v.id_centro == guid_centro
										select new
										{
											i_v.codigo_venta,
											i_e.desc_estatus,
											i_v.fecha_registro

										}).ToList();

						gv_fventas.DataSource = i_ventas;
						gv_fventas.DataBind();
						gv_fventas.Visible = true;
					}
				}
			}
		}

		protected void chk_fventas_CheckedChanged(object sender, EventArgs e)
		{
			foreach (GridViewRow row in gv_fventas.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkRow = (row.Cells[0].FindControl("chk_fventas") as CheckBox);
					if (chkRow.Checked)
					{
						row.BackColor = Color.FromArgb(185, 0, 92);
						string str_code = row.Cells[1].Text;

						using (db_imEntities data_user = new db_imEntities())
						{
							var items_user = (from c in data_user.inf_ventas
											  where c.codigo_venta == str_code
											  where c.id_centro == guid_centro
											  select c).FirstOrDefault();

							guid_idventaf = items_user.id_alumno;
						}

					}
					else
					{
						row.BackColor = Color.White;
					}
				}
			}
		}
		protected void gv_fventas_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			foreach (GridViewRow row in gv_fventas.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkRow = (row.Cells[3].FindControl("chk_fventas") as CheckBox);
					if (chkRow.Checked)
					{
						if (row.RowType == DataControlRowType.DataRow)
						{
							Button btnButton = (Button)row.FindControl("btn_baja_vta");
							if (btnButton.Text == "Baja")
							{
								string str_code = row.Cells[1].Text;
								using (db_imEntities data_user = new db_imEntities())
								{
									var items_user = (from c in data_user.inf_ventas
													  where c.codigo_venta == str_code
													  where c.id_centro == guid_centro
													  select c).FirstOrDefault();

									guid_idventaf = items_user.id_ventas;
								}

								using (var edm_material = new db_imEntities())
								{
									var i_material = (from c in edm_material.inf_ventas
													  where c.id_ventas == guid_idventaf
													  select c).FirstOrDefault();

									i_material.id_estatus = 2;
									edm_material.SaveChanges();
								}
								DateTime dt_fecini = DateTime.Parse(txt_fecini_vta.Text);
								DateTime dt_fecfin = DateTime.Parse(txt_fecfin_vta.Text);

								using (db_imEntities edm_ventas = new db_imEntities())
								{
									var i_ventas = (from i_v in edm_ventas.inf_ventas
													join i_e in edm_ventas.fact_estatus on i_v.id_estatus equals i_e.id_estatus
													where i_v.fecha_registro >= dt_fecini && i_v.fecha_registro <= dt_fecfin
													where i_v.id_centro == guid_centro
													select new
													{
														i_v.codigo_venta,
														i_e.desc_estatus,
														i_v.fecha_registro

													}).ToList();

									gv_fventas.DataSource = i_ventas;
									gv_fventas.DataBind();
									gv_fventas.Visible = true;
								}

								lblModalTitle.Text = "Intelimundo";
								lblModalBody.Text = "Venta dada de baja con éxito";
								ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
								upModal.Update();
								lblModalTitle.Text = "transcript";
								lblModalBody.Text = "Venta dada de baja con éxito.";
								ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
								upModal.Update();

							}

						}
					}
				}
			}
		}
		#endregion

		#region gastos
		protected void lkbtn_nuevo_gasto_Click(object sender, EventArgs e)
		{
			int_accion_gasto = 1;
			i_agrega_gasto.Attributes["style"] = "color:#B9005C";
			i_edita_gasto.Attributes["style"] = "color:#079DBC";
			i_baja_gasto.Attributes["style"] = "color:#079DBC";
			limpiar_txt_gastos();

			txt_buscar_gasto.Visible = false;
			btn_buscar_gasto.Visible = false;
			gv_gasto.Visible = false;
		}
		protected void lkbtn_edita_gasto_Click(object sender, EventArgs e)
		{
			int_accion_gasto = 2;
			i_agrega_gasto.Attributes["style"] = "color:#079DBC";
			i_edita_gasto.Attributes["style"] = "color:#B9005C";
			i_baja_gasto.Attributes["style"] = "color:#079DBC";
			limpiar_txt_gastos();

			txt_buscar_gasto.Visible = true;
			btn_buscar_gasto.Visible = true;

			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from u in data_user.inf_gastos
								where u.id_centro == guid_centro
								select new
								{

									u.id_codigo_gasto,
									u.categoria,
									u.desc_gasto,
									u.fecha_registro,
									u.cantidad,
									u.costo,
									total = u.cantidad * u.costo

								}).ToList();

				gv_gasto.DataSource = inf_user;
				gv_gasto.DataBind();
				gv_gasto.Visible = true;
			}
		}
		protected void lkbtn_baja_gasto_Click(object sender, EventArgs e)

		{
			int_accion_gasto = 3;
			i_agrega_gasto.Attributes["style"] = "color:#079DBC";
			i_edita_gasto.Attributes["style"] = "color:#079DBC";
			i_baja_gasto.Attributes["style"] = "color:#B9005C";
			limpiar_txt_gastos();

			txt_buscar_gasto.Visible = true;
			btn_buscar_gasto.Visible = true;

			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from u in data_user.inf_gastos
								where u.id_centro == guid_centro
								select new
								{

									u.id_codigo_gasto,
									u.categoria,
									u.desc_gasto,
									u.fecha_registro,
									u.cantidad,
									u.costo,
									total = u.cantidad * u.costo

								}).ToList();

				gv_gasto.DataSource = inf_user;
				gv_gasto.DataBind();
				gv_gasto.Visible = true;
			}
		}
		protected void btn_buscar_gasto_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_buscar_gasto.Text))
			{
				txt_buscar_gasto.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				txt_buscar_gasto.BackColor = Color.Transparent;
				string str_userb = txt_buscar_gasto.Text;
				using (db_imEntities data_user = new db_imEntities())
				{
					var inf_user = (from u in data_user.inf_gastos
									where u.id_centro == guid_centro
									select new
									{

										u.id_codigo_gasto,
										u.categoria,
										u.desc_gasto,
										u.fecha_registro,
										u.cantidad,
										u.costo,
										total = u.cantidad * u.costo

									}).ToList();

					gv_gasto.DataSource = inf_user;
					gv_gasto.DataBind();
					gv_gasto.Visible = true;
				}
			}
		}

		protected void gv_gasto_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
		}

		protected void chk_gasto_CheckedChanged(object sender, EventArgs e)
		{
			foreach (GridViewRow row in gv_gasto.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkRow = (row.Cells[0].FindControl("chk_gasto") as CheckBox);
					if (chkRow.Checked)
					{
						row.BackColor = Color.FromArgb(185, 0, 92);
						string str_code = row.Cells[1].Text;

						using (db_imEntities edm_gasto = new db_imEntities())
						{
							var i_gasto = (from u in edm_gasto.inf_gastos
										   where u.id_codigo_gasto == str_code
										   where u.id_centro == guid_centro
										   select new
										   {
											   u.categoria,
											   u.desc_gasto,
											   u.fecha_registro,
											   u.cantidad,
											   u.costo,
											   total = u.cantidad * u.costo

										   }).FirstOrDefault();

							txt_categoria_gasto.Text = i_gasto.categoria;
							txt_desc_gasto.Text = i_gasto.desc_gasto;
							txt_cantidad_gasto.Text = i_gasto.cantidad.ToString();
							txt_costo_gasto.Text = string.Format("{0:n2}", (object)(Math.Truncate(Convert.ToDouble((object)i_gasto.costo) * 100.0) / 100.0));
						}
					}
					else
					{
						row.BackColor = Color.White;
					}
				}
			}
		}

		protected void btn_guardar_gasto_Click(object sender, EventArgs e)
		{
			if (int_accion_gasto == 0)
			{
				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Favor de seleccionar una acción";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();
			}
			else if (string.IsNullOrEmpty(txt_categoria_gasto.Text))
			{
				txt_categoria_gasto.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				txt_categoria_gasto.BackColor = Color.Transparent;
				if (string.IsNullOrEmpty(txt_desc_gasto.Text))
				{
					txt_desc_gasto.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					txt_desc_gasto.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_cantidad_gasto.Text))
					{
						txt_cantidad_gasto.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						txt_cantidad_gasto.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_costo_gasto.Text))
						{
							txt_costo_gasto.BackColor = Color.FromArgb(185, 0, 92);
						}
						else
						{
							txt_costo_gasto.BackColor = Color.Transparent;
							guardar_gasto();
						}
					}
				}
			}
		}

		private void guardar_gasto()
		{
			Guid guid = Guid.NewGuid();
			string text1 = txt_categoria_gasto.Text;
			string text2 = txt_desc_gasto.Text;
			int num1 = int.Parse(txt_cantidad_gasto.Text);
			Decimal num2 = Decimal.Parse(txt_costo_gasto.Text);
			if (int_accion_gasto == 1)
			{


				using (db_imEntities edm_gastos = new db_imEntities())
				{
					var i_gastos = (from c in edm_gastos.inf_gastos
									where c.id_centro == guid_centro
									select c).ToList();

					if (i_gastos.Count == 0)
					{
						string str = "intm_gtos" + string.Format("{0:000}", (object)(i_gastos.Count + 1));
						using (db_imEntities dbImEntities2 = new db_imEntities())
						{
							inf_gastos infGastos = new inf_gastos()
							{
								id_gasto = guid,
								id_estatus = 1,
								id_codigo_gasto = str,
								categoria = text1,
								desc_gasto = text2,
								cantidad = new int?(num1),
								costo = new Decimal?(num2),
								fecha_registro = new DateTime?(DateTime.Now),
								id_centro = guid_centro
							};
							dbImEntities2.inf_gastos.Add(infGastos);
							dbImEntities2.SaveChanges();
						}
						limpiar_txt_gastos();
						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Gasto agregado con exito";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();
					}
					else
					{
						string str = "intm_gtos" + string.Format("{0:000}", (object)(i_gastos.Count + 1));
						using (db_imEntities dbImEntities2 = new db_imEntities())
						{
							inf_gastos infGastos = new inf_gastos()
							{
								id_gasto = guid,
								id_codigo_gasto = str,
								categoria = text1,
								desc_gasto = text2,
								cantidad = new int?(num1),
								costo = new Decimal?(num2),
								fecha_registro = new DateTime?(DateTime.Now),
								id_centro = guid_centro
							};
							dbImEntities2.inf_gastos.Add(infGastos);
							dbImEntities2.SaveChanges();
						}
						limpiar_txt_gastos();
						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Gasto agregado con exito";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();
					}
				}
			}
			else if (int_accion_gasto == 2)
			{
				foreach (GridViewRow row in gv_gasto.Rows)
				{
					if (row.RowType == DataControlRowType.DataRow && (row.Cells[0].FindControl("chk_gasto") as CheckBox).Checked)
					{
						string str_code = row.Cells[1].Text;

						using (var edm_gasto = new db_imEntities())
						{
							var i_gasto = (from c in edm_gasto.inf_gastos
										   where c.id_codigo_gasto == str_code
										   select c).FirstOrDefault();

							i_gasto.categoria = text1;
							i_gasto.desc_gasto = text2;
							i_gasto.cantidad = new int?(num1);
							i_gasto.costo = new Decimal?(num2);

							edm_gasto.SaveChanges();
						}
						using (db_imEntities data_user = new db_imEntities())
						{
							var inf_user = (from u in data_user.inf_gastos
											where u.id_centro == guid_centro
											select new
											{

												u.id_codigo_gasto,
												u.categoria,
												u.desc_gasto,
												u.fecha_registro,
												u.cantidad,
												u.costo,
												total = u.cantidad * u.costo

											}).ToList();

							gv_gasto.DataSource = inf_user;
							gv_gasto.DataBind();
							gv_gasto.Visible = true;
						}
						limpiar_txt_gastos();
						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Gasto actualizado con exito";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();
					}
				}
			}
			else
			{
				if (int_accion_gasto == 3)
					return;
				foreach (GridViewRow row in gv_gasto.Rows)
				{
					if (row.RowType == DataControlRowType.DataRow && (row.Cells[0].FindControl("chk_gasto") as CheckBox).Checked)
					{
						string codeuser = row.Cells[1].Text;

						using (var edm_gasto = new db_imEntities())
						{
							var i_gasto = (from c in edm_gasto.inf_gastos
										   where c.id_codigo_gasto == codeuser
										   select c).FirstOrDefault();

							i_gasto.id_estatus = 3;
							edm_gasto.SaveChanges();
						}

						limpiar_txt_gastos();

						gv_usuarios.Visible = false;
						txt_buscar_usuario.Visible = false;
						btn_busca_usuario.Visible = false;
						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Datos de gasto eliminados con éxito";
						ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
						upModal.Update();
					}
				}
			}
		}

		private void limpiar_txt_gastos()
		{

			txt_categoria_gasto.Text = "";
			txt_desc_gasto.Text = "";
			txt_cantidad_gasto.Text = "";
			txt_costo_gasto.Text = "";
		}

		#endregion

		#region inventario

		protected void lkbtn_nuevo_inventario_Click(object sender, EventArgs e)
		{
			int_accion_inventario = 1;
			i_agrega_inventario.Attributes["style"] = "color:#B9005C";
			i_edita_inventario.Attributes["style"] = "color:#079DBC";
			i_baja_inventario.Attributes["style"] = "color:#079DBC";
			limpiart_txt_inventario();

			txt_buscar_inventario.Visible = false;
			btn_buscar_inventario.Visible = false;
			gv_inventario.Visible = false;
		}
		protected void lkbtn_edita_inventario_Click(object sender, EventArgs e)
		{
			int_accion_inventario = 2;
			i_agrega_inventario.Attributes["style"] = "color:#079DBC";
			i_edita_inventario.Attributes["style"] = "color:#B9005C";
			i_baja_inventario.Attributes["style"] = "color:#079DBC";
			limpiart_txt_inventario();

			txt_buscar_inventario.Visible = true;
			btn_buscar_inventario.Visible = true;

			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from u in data_user.inf_inventario
								join i_e in data_user.fact_grado_escolar on u.id_grado_escolar equals i_e.id_grado_escolar
								join i_n in data_user.fact_nivel_escolar on i_e.id_nivel_escolar equals i_n.id_nivel_escolar
								where u.id_centro == guid_centro
								select new
								{
									i_n.desc_nivel_escolar,
									i_e.desc_grado_escolar,
									u.id_codigo_inventario,
									u.categoria,
									u.desc_inventario,
									u.caracteristica,
									u.fecha_registro

								}).ToList();

				gv_inventario.DataSource = inf_user;
				gv_inventario.DataBind();
				gv_inventario.Visible = true;
			}
		}
		protected void lkbtn_baja_inventario_Click(object sender, EventArgs e)

		{
			int_accion_inventario = 3;
			i_agrega_inventario.Attributes["style"] = "color:#079DBC";
			i_edita_inventario.Attributes["style"] = "color:#079DBC";
			i_baja_inventario.Attributes["style"] = "color:#B9005C";
			limpiart_txt_inventario();

			txt_buscar_inventario.Visible = true;
			btn_buscar_inventario.Visible = true;

			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from u in data_user.inf_inventario
								join i_e in data_user.fact_grado_escolar on u.id_grado_escolar equals i_e.id_grado_escolar
								join i_n in data_user.fact_nivel_escolar on i_e.id_nivel_escolar equals i_n.id_nivel_escolar
								where u.id_centro == guid_centro
								select new
								{

									u.id_codigo_inventario,
									i_n.desc_nivel_escolar,
									i_e.desc_grado_escolar,
									u.categoria,
									u.desc_inventario,
									u.caracteristica,
									u.fecha_registro

								}).ToList();

				gv_inventario.DataSource = inf_user;
				gv_inventario.DataBind();
				gv_inventario.Visible = true;
			}
		}
		protected void btn_margen_inventario_Click(object sender, EventArgs e)
		{

		}
		protected void btn_buscar_inventario_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_buscar_inventario.Text))
			{

				txt_buscar_inventario.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				txt_buscar_inventario.BackColor = Color.Transparent;

				string str_userb = txt_buscar_inventario.Text;

				using (db_imEntities data_user = new db_imEntities())
				{
					var inf_user = (from i_u in data_user.inf_inventario
									where i_u.desc_inventario.Contains(str_userb)
									where i_u.id_centro == guid_idcentro
									select new
									{
										i_u.id_codigo_inventario,
										i_u.categoria,
										i_u.desc_inventario,
										i_u.cantidad,
										i_u.costo,
										total = i_u.cantidad * i_u.costo,
										i_u.fecha_registro

									}).ToList();

					gv_inventario.DataSource = inf_user;
					gv_inventario.DataBind();
					gv_inventario.Visible = true;
				}
			}
		}

		protected void gv_inventario_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{

		}

		protected void chk_inventario_CheckedChanged(object sender, EventArgs e)
		{
			foreach (GridViewRow row in gv_inventario.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkRow = (row.Cells[0].FindControl("chk_inventario") as CheckBox);
					if (chkRow.Checked)
					{
						string str_code = row.Cells[1].Text;
						row.BackColor = Color.FromArgb(185, 0, 92);

						using (db_imEntities edm_inv = new db_imEntities())
						{
							var i_inv = (from u in edm_inv.inf_inventario
										 join i_ge in edm_inv.fact_grado_escolar on u.id_grado_escolar equals i_ge.id_grado_escolar
										 join i_ne in edm_inv.fact_nivel_escolar on i_ge.id_nivel_escolar equals i_ne.id_nivel_escolar
										 where u.id_centro == guid_centro
										 where u.id_codigo_inventario == str_code
										 select new
										 {
											 i_ge.id_nivel_escolar,
											 u.id_grado_escolar,
											 u.categoria,
											 u.desc_inventario,
											 u.caracteristica,
											 u.cantidad,
											 u.costo

										 }).FirstOrDefault();

							ddl_nivel_inventario.SelectedValue = i_inv.id_nivel_escolar.ToString();

							int int_idnivelescolar = int.Parse(i_inv.id_nivel_escolar.ToString());

							using (db_imEntities m_tiporfc = new db_imEntities())
							{
								var i_tiporfc = (from f_tr in m_tiporfc.fact_grado_escolar
												 where f_tr.id_nivel_escolar == int_idnivelescolar
												 select f_tr).ToList();

								ddl_grado_inventario.DataSource = i_tiporfc;
								ddl_grado_inventario.DataTextField = "desc_grado_escolar";
								ddl_grado_inventario.DataValueField = "id_grado_escolar";
								ddl_grado_inventario.DataBind();
							}

							ddl_grado_inventario.SelectedValue = i_inv.id_grado_escolar.ToString();
							txt_categoria_inventario.Text = i_inv.categoria;
							txt_desc_inventario.Text = i_inv.desc_inventario;
							txt_caracteristica_inventario.Text = i_inv.caracteristica;
							txt_cantidad_inventario.Text = i_inv.cantidad.ToString();
							txt_costo_inventario.Text = string.Format("{0:n2}", (Math.Truncate(Convert.ToDouble(i_inv.costo) * 100) / 100));
						}
					}
					else
					{
						row.BackColor = Color.Transparent;
					}
				}
			}
		}

		protected void btn_guardar_inventario_Click(object sender, EventArgs e)
		{
			if (int_accion_inventario == 0)
			{
				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Favor de seleccionar una acción";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();
			}
			else
			{
				if (ddl_nivel_inventario.SelectedValue == "0")
				{
					ddl_nivel_inventario.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					ddl_nivel_inventario.BackColor = Color.Transparent;
					if (ddl_grado_inventario.SelectedValue == "0")
					{
						ddl_grado_inventario.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						ddl_grado_inventario.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_categoria_inventario.Text))
						{
							txt_categoria_inventario.BackColor = Color.FromArgb(185, 0, 92);
						}
						else
						{
							txt_categoria_inventario.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_desc_inventario.Text))
							{
								txt_desc_inventario.BackColor = Color.FromArgb(185, 0, 92);
							}
							else
							{
								txt_desc_inventario.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_caracteristica_inventario.Text))
								{
									txt_caracteristica_inventario.BackColor = Color.FromArgb(185, 0, 92);
								}
								else
								{
									txt_caracteristica_inventario.BackColor = Color.Transparent;
									if (string.IsNullOrEmpty(txt_cantidad_inventario.Text))
									{
										txt_cantidad_inventario.BackColor = Color.FromArgb(185, 0, 92);
									}
									else
									{
										txt_cantidad_inventario.BackColor = Color.Transparent;
										if (string.IsNullOrEmpty(txt_costo_inventario.Text))
										{
											txt_costo_inventario.BackColor = Color.FromArgb(185, 0, 92);
										}
										else
										{
											txt_costo_inventario.BackColor = Color.Transparent;
											guardar_inventario();

										}
									}
								}
							}
						}
					}
				}

			}

		}

		private void guardar_inventario()
		{
			Guid guid_ngasto = Guid.NewGuid();
			string str_codigogasto;
			int int_nivel = int.Parse(ddl_nivel_inventario.SelectedValue);
			int int_grado = int.Parse(ddl_grado_inventario.SelectedValue);
			string str_categoriagasto = txt_categoria_inventario.Text.ToUpper();
			string str_descgasto = txt_desc_inventario.Text.ToUpper();
			string str_caracteristicagasto = txt_caracteristica_inventario.Text.ToUpper();
			int int_cantidadgasto = int.Parse(txt_cantidad_inventario.Text);
			decimal dml_costogasto = decimal.Parse(txt_costo_inventario.Text);

			if (int_accion_inventario == 1)
			{
				using (var edm_inv = new db_imEntities())
				{
					var i_inv = (from c in edm_inv.inf_inventario
								 select c).ToList();

					if (i_inv.Count == 0)
					{
						str_codigogasto = "intm_inv" + string.Format("{0:000}", 1);
					}
					else
					{
						str_codigogasto = "intm_inv" + string.Format("{0:000}", i_inv.Count + 1);
					}
				}

				using (var insert_address = new db_imEntities())
				{
					var items_address = new inf_inventario
					{
						id_inventario = guid_ngasto,
						id_estatus = 1,
						id_codigo_inventario = str_codigogasto,
						id_grado_escolar = int_grado,
						categoria = str_categoriagasto,
						desc_inventario = str_descgasto,
						caracteristica = str_caracteristicagasto,
						cantidad = int_cantidadgasto,
						costo = dml_costogasto,
						fecha_registro = DateTime.Now,
						id_centro = guid_centro

					};

					insert_address.inf_inventario.Add(items_address);
					insert_address.SaveChanges();
				}
				int_accion_inventario = 0;
				i_agrega_inventario.Attributes["style"] = "color:#079DBC";
				limpiart_txt_inventario();

				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Producto agregado con exito";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();


			}
			else if (int_accion_inventario == 2)
			{
				foreach (GridViewRow row in gv_inventario.Rows)
				{
					if (row.RowType == DataControlRowType.DataRow)
					{
						CheckBox chkRow = (row.Cells[0].FindControl("chk_inventario") as CheckBox);
						if (chkRow.Checked)
						{
							string str_code = row.Cells[1].Text;

							using (var data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_inventario
												  where c.id_codigo_inventario == str_code
												  select c).FirstOrDefault();

								items_user.id_grado_escolar = int_grado;
								items_user.categoria = str_categoriagasto;
								items_user.desc_inventario = str_descgasto;
								items_user.caracteristica = str_caracteristicagasto;
								items_user.cantidad = int_cantidadgasto;
								items_user.costo = dml_costogasto;
								data_user.SaveChanges();
							}

							using (db_imEntities data_user = new db_imEntities())
							{
								var inf_user = (from u in data_user.inf_inventario
												where u.id_centro == guid_idcentro
												select new
												{
													u.id_codigo_inventario,
													u.categoria,
													u.desc_inventario,
													u.cantidad,
													u.costo,
													total = u.cantidad * u.costo,
													u.fecha_registro

												}).ToList();

								gv_inventario.DataSource = inf_user;
								gv_inventario.DataBind();
								gv_inventario.Visible = true;
							}
							int_accion_inventario = 0;

							i_edita_inventario.Attributes["style"] = "color:#079DBC";
							limpiart_txt_inventario();

							lblModalTitle.Text = "Intelimundo";
							lblModalBody.Text = "Gasto actualizado con exito";
							ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
							upModal.Update();
						}
					}
				}

			}
		}
		protected void ddl_nivel_inventario_SelectedIndexChanged(object sender, EventArgs e)
		{
			int int_nivel = int.Parse(ddl_nivel_inventario.SelectedValue);

			using (db_imEntities m_tiporfc = new db_imEntities())
			{
				var i_tiporfc = (from f_tr in m_tiporfc.fact_grado_escolar
								 where f_tr.id_nivel_escolar == int_nivel
								 select f_tr).ToList();

				ddl_grado_inventario.DataSource = i_tiporfc;
				ddl_grado_inventario.DataTextField = "desc_grado_escolar";
				ddl_grado_inventario.DataValueField = "id_grado_escolar";
				ddl_grado_inventario.DataBind();
			}

			ddl_grado_inventario.Items.Insert(0, new ListItem("*GRADO", "0"));
		}

		private void limpiart_txt_inventario()
		{
			ddl_nivel_inventario.Items.Clear();
			ddl_grado_inventario.Items.Clear();
			using (db_imEntities m_tiporfc = new db_imEntities())
			{
				var i_tiporfc = (from f_tr in m_tiporfc.fact_nivel_escolar
								 select f_tr).ToList();

				ddl_nivel_inventario.DataSource = i_tiporfc;
				ddl_nivel_inventario.DataTextField = "desc_nivel_escolar";
				ddl_nivel_inventario.DataValueField = "id_nivel_escolar";
				ddl_nivel_inventario.DataBind();
			}

			ddl_nivel_inventario.Items.Insert(0, new ListItem("*NIVEL", "0"));

			ddl_grado_inventario.Items.Insert(0, new ListItem("*GRADO", "0"));

			txt_categoria_inventario.Text = "";
			txt_caracteristica_inventario.Text = "";
			txt_mcantidad_inventario.Text = "";
			txt_desc_inventario.Text = "";
			txt_cantidad_inventario.Text = "";
			txt_margen_inventario.Text = "";
			txt_costo_inventario.Text = "";
		}

		#endregion

		#region sucursal

		protected void lkbtn_nuevo_sucursal_Click(object sender, EventArgs e)
		{
			int_accion_sucursal = 1;
			i_agrega_sucursal.Attributes["style"] = "color:#B9005C";
			i_edita_sucursal.Attributes["style"] = "color:#079DBC";
			i_baja_sucursal.Attributes["style"] = "color:#079DBC";
			limpia_txt_sucursal();
			txt_buscar_sucursal.Visible = false;
			btn_buscar_sucursal.Visible = false;
			gv_sucursal.Visible = false;

			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from i_u in data_user.inf_usuarios
								join i_e in data_user.fact_estatus on i_u.id_estatus equals i_e.id_estatus
								where i_u.id_tipo_usuario == 3
								where i_u.id_usuario != guid_iduser
								where i_u.id_estatus == 1

								select new
								{
									i_u.codigo_usuario,
									i_e.desc_estatus,
									i_u.fecha_nacimiento,
									i_u.nombres,
									i_u.a_paterno,
									i_u.a_materno,
									i_u.fecha_registro

								}).ToList();

				if (inf_user.Count == 0)
				{

					txt_buscar_sucursal.Visible = false;
					btn_buscar_sucursal.Visible = false;
					gv_sucursal.Visible = false;

					limpia_txt_sucursal();

					lblModalTitle.Text = "Intelimundo";
					lblModalBody.Text = "Sin datos de administradores, favor de agregarlos";
					ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
					upModal.Update();
				}
				else
				{
					gv_administrador.DataSource = inf_user;
					gv_administrador.DataBind();
					gv_administrador.Visible = true;
				}
			}

		}

		protected void lkbtn_edita_sucursal_Click(object sender, EventArgs e)
		{
			int_accion_sucursal = 2;
			i_edita_sucursal.Attributes["style"] = "color:#B9005C";
			i_agrega_sucursal.Attributes["style"] = "color:#079DBC";

			i_baja_sucursal.Attributes["style"] = "color:#079DBC";
			limpia_txt_sucursal();

			txt_buscar_sucursal.Visible = true;
			btn_buscar_sucursal.Visible = true;



			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from i_s in data_user.inf_centro
								join i_l in data_user.fact_licencias on i_s.id_licencia equals i_l.id_licencia
								join i_sd in data_user.inf_centro_dep on i_s.id_centro equals i_sd.id_centro
								join i_u in data_user.inf_usuarios on i_sd.id_usuario equals i_u.id_usuario
								where i_s.id_tipo_centro == 2
								where i_s.id_estatus == 1
								select new
								{
									i_s.id_codigo_centro,
									i_l.desc_licencia,
									i_s.nombre,
									i_u.codigo_usuario,
									admin = i_u.nombres + " " + i_u.a_paterno + " " + i_u.a_materno,
									i_s.fecha_registro

								}).ToList();



				gv_sucursal.DataSource = inf_user;
				gv_sucursal.DataBind();
				gv_sucursal.Visible = true;
			}

			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from i_u in data_user.inf_usuarios
								join i_e in data_user.fact_estatus on i_u.id_estatus equals i_e.id_estatus
								where i_u.id_tipo_usuario == 3
								where i_u.id_usuario != guid_iduser
								where i_u.id_estatus == 1

								select new
								{
									i_u.codigo_usuario,
									i_e.desc_estatus,
									i_u.fecha_nacimiento,
									i_u.nombres,
									i_u.a_paterno,
									i_u.a_materno,
									i_u.fecha_registro

								}).ToList();

				gv_administrador.DataSource = inf_user;
				gv_administrador.DataBind();
				gv_administrador.Visible = true;
			}
		}

		protected void lkbtn_baja_sucursal_Click(object sender, EventArgs e)
		{
			int_accion_sucursal = 3;
			i_baja_sucursal.Attributes["style"] = "color:#B9005C";
			i_agrega_sucursal.Attributes["style"] = "color:#079DBC";
			i_edita_sucursal.Attributes["style"] = "color:#079DBC";

			limpia_txt_sucursal();

			txt_buscar_sucursal.Visible = true;
			btn_buscar_sucursal.Visible = true;


			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from i_s in data_user.inf_centro
								join i_l in data_user.fact_licencias on i_s.id_licencia equals i_l.id_licencia
								join i_sd in data_user.inf_centro_dep on i_s.id_centro equals i_sd.id_centro
								join i_u in data_user.inf_usuarios on i_sd.id_usuario equals i_u.id_usuario
								where i_s.id_tipo_centro == 2
								where i_s.id_estatus == 1
								select new
								{
									i_s.id_codigo_centro,
									i_l.desc_licencia,
									i_s.nombre,
									i_u.codigo_usuario,
									admin = i_u.nombres + " " + i_u.a_paterno + " " + i_u.a_materno,
									i_s.fecha_registro

								}).ToList();



				gv_sucursal.DataSource = inf_user;
				gv_sucursal.DataBind();
				gv_sucursal.Visible = true;
			}

			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from i_u in data_user.inf_usuarios
								join i_e in data_user.fact_estatus on i_u.id_estatus equals i_e.id_estatus
								where i_u.id_tipo_usuario == 3
								where i_u.id_usuario != guid_iduser
								where i_u.id_estatus == 1

								select new
								{
									i_u.codigo_usuario,
									i_e.desc_estatus,
									i_u.fecha_nacimiento,
									i_u.nombres,
									i_u.a_paterno,
									i_u.a_materno,
									i_u.fecha_registro

								}).ToList();

				gv_administrador.DataSource = inf_user;
				gv_administrador.DataBind();
				gv_administrador.Visible = true;
			}
		}


		protected void btn_buscar_sucursal_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_buscar_sucursal.Text))
			{

				txt_buscar_sucursal.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				txt_buscar_sucursal.BackColor = Color.Transparent;

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

					gv_sucursal.DataSource = inf_user;
					gv_sucursal.DataBind();
					gv_sucursal.Visible = true;
				}

			}

		}
		protected void gv_sucursal_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{

		}
		protected void chk_sucursal_CheckedChanged(object sender, EventArgs e)
		{
			foreach (GridViewRow row in gv_sucursal.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkRow = (row.Cells[0].FindControl("chk_sucursal") as CheckBox);
					if (chkRow.Checked)
					{
						row.BackColor = Color.FromArgb(185, 0, 92);
						string codeuser = row.Cells[1].Text;

						using (db_imEntities data_user = new db_imEntities())
						{
							var items_user = (from c in data_user.inf_centro
											  where c.id_codigo_centro == codeuser
											  select c).FirstOrDefault();

							guid_idcentro = items_user.id_centro;
						}

						using (db_imEntities data_user = new db_imEntities())
						{
							var inf_user = (from i_u in data_user.inf_centro
											where i_u.id_centro == guid_idcentro
											select new
											{
												i_u.id_licencia,
												i_u.nombre,
												i_u.telefono,
												i_u.email,
												i_u.callenum,
												i_u.id_codigo,
												i_u.dia_corte,

											}).FirstOrDefault();

							ddl_licencias.SelectedValue = inf_user.id_licencia.ToString();
							txt_nombre_sucursal.Text = inf_user.nombre;
							txt_telefono_sucursal.Text = inf_user.telefono;
							txt_email_sucursal.Text = inf_user.email;
							txt_callenum_sucursal.Text = inf_user.callenum;
							txt_dcorte_sucursal.Text = inf_user.dia_corte.ToString();

							using (db_imEntities db_sepomex = new db_imEntities())
							{
								var tbl_sepomex = (from c in db_sepomex.inf_sepomex
												   where c.id_codigo == inf_user.id_codigo
												   select c).ToList();

								ddl_colonia_sucursal.DataSource = tbl_sepomex;
								ddl_colonia_sucursal.DataTextField = "d_asenta";
								ddl_colonia_sucursal.DataValueField = "id_asenta_cpcons";
								ddl_colonia_sucursal.DataBind();

								txt_cp_sucursal.Text = tbl_sepomex[0].d_codigo;
								txt_municipio_sucursal.Text = tbl_sepomex[0].D_mnpio;
								txt_estado_sucursal.Text = tbl_sepomex[0].d_estado;
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
		protected void chk_administrador_CheckedChanged(object sender, EventArgs e)
		{
			foreach (GridViewRow row in gv_administrador.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox chkRow = (row.Cells[0].FindControl("chk_administrador") as CheckBox);
					if (chkRow.Checked)
					{
						row.BackColor = Color.FromArgb(185, 0, 92);

					}
					else
					{
						row.BackColor = Color.White;

					}
				}
			}
		}
		protected void btn_cp_sucursal_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_cp_sucursal.Text))
			{

				txt_cp_sucursal.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				txt_cp_sucursal.BackColor = Color.Transparent;

				string str_codigo = txt_cp_sucursal.Text;

				using (db_imEntities db_sepomex = new db_imEntities())
				{
					var tbl_sepomex = (from c in db_sepomex.inf_sepomex
									   where c.d_codigo == str_codigo
									   select c).ToList();

					ddl_colonia_sucursal.DataSource = tbl_sepomex;
					ddl_colonia_sucursal.DataTextField = "d_asenta";
					ddl_colonia_sucursal.DataValueField = "id_asenta_cpcons";
					ddl_colonia_sucursal.DataBind();

					if (tbl_sepomex.Count == 1)
					{


						txt_municipio_sucursal.Text = tbl_sepomex[0].D_mnpio;
						txt_estado_sucursal.Text = tbl_sepomex[0].d_estado;
					}
					if (tbl_sepomex.Count > 1)
					{

						ddl_colonia_sucursal.Items.Insert(0, new ListItem("*Colonia", "0"));

						txt_municipio_sucursal.Text = tbl_sepomex[0].D_mnpio;
						txt_estado_sucursal.Text = tbl_sepomex[0].d_estado;
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
		protected void btn_guardar_sucursal_Click(object sender, EventArgs e)
		{
			if (int_accion_sucursal == 0)
			{
				lblModalTitle.Text = "Intelimundo";
				lblModalBody.Text = "Favor de seleccionar una acción";
				ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
				upModal.Update();
			}
			else
			{
				if (ddl_licencias.SelectedValue == "0")
				{
					ddl_licencias.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					ddl_licencias.BackColor = Color.White;
					if (string.IsNullOrEmpty(txt_nombre_sucursal.Text))
					{

						txt_nombre_sucursal.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						txt_nombre_sucursal.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_telefono_sucursal.Text))
						{

							txt_telefono_sucursal.BackColor = Color.FromArgb(185, 0, 92);
						}
						else
						{
							txt_telefono_sucursal.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_email_sucursal.Text))
							{

								txt_email_sucursal.BackColor = Color.FromArgb(185, 0, 92);
							}
							else
							{
								txt_email_sucursal.BackColor = Color.Transparent;

								if (string.IsNullOrEmpty(txt_dcorte_sucursal.Text))
								{

									txt_dcorte_sucursal.BackColor = Color.FromArgb(185, 0, 92);
								}
								else
								{
									txt_dcorte_sucursal.BackColor = Color.Transparent;
									if (string.IsNullOrEmpty(txt_callenum_sucursal.Text))
									{

										txt_callenum_sucursal.BackColor = Color.FromArgb(185, 0, 92);
									}
									else
									{
										txt_callenum_sucursal.BackColor = Color.Transparent;
										if (string.IsNullOrEmpty(txt_cp_sucursal.Text))
										{

											txt_cp_sucursal.BackColor = Color.FromArgb(185, 0, 92);
										}
										else
										{
											txt_cp_sucursal.BackColor = Color.Transparent;
											if (ddl_colonia_sucursal.SelectedValue == "0")
											{
												ddl_colonia_sucursal.BackColor = Color.FromArgb(185, 0, 92);
											}
											else
											{
												ddl_colonia_sucursal.BackColor = Color.White;
												int vgvadmin = 0; 
												foreach (GridViewRow row in gv_administrador.Rows)
												{
													if (row.RowType == DataControlRowType.DataRow)
													{
														CheckBox chkRow = (row.Cells[1].FindControl("chk_administrador") as CheckBox);
														if (chkRow.Checked)
														{
															
															vgvadmin = vgvadmin + 1;
														}
													}
												}

												if (vgvadmin == 0)
												{
													lblModalTitle.Text = "Intelimundo";
													lblModalBody.Text = "Favor de seleccionar un Administrador";
													ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
													upModal.Update();
												}
												else
												{
													guardar_sucursal();
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
		private void guardar_sucursal()
		{
			Guid guid_nns = Guid.NewGuid();
			int int_licencia = int.Parse(ddl_licencias.SelectedValue);
			string str_nsucursal = txt_nombre_sucursal.Text.ToUpper();
			string str_telefono = txt_telefono_sucursal.Text;
			string str_email = txt_email_sucursal.Text;
			int int_dcorte = int.Parse(txt_dcorte_sucursal.Text);
			string str_callenum = txt_callenum_sucursal.Text.ToUpper();
			string str_cp = txt_cp_sucursal.Text;
			int int_idcolonia = int.Parse(ddl_colonia_sucursal.SelectedValue);
			int int_idcodigocp;

			using (db_imEntities db_sepomex = new db_imEntities())
			{
				var tbl_sepomex = (from c in db_sepomex.inf_sepomex
								   where c.d_codigo == str_cp
								   where c.id_asenta_cpcons == int_idcolonia
								   select c).ToList();

				int_idcodigocp = tbl_sepomex[0].id_codigo;
			}

			if (int_accion_sucursal == 1)
			{
				foreach (GridViewRow row in gv_administrador.Rows)
				{
					if (row.RowType == DataControlRowType.DataRow)
					{
						CheckBox chkRow = (row.Cells[1].FindControl("chk_administrador") as CheckBox);
						if (chkRow.Checked)
						{
							string codeuser = row.Cells[1].Text;

							using (db_imEntities data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_usuarios
												  where c.codigo_usuario == codeuser
												  select c).FirstOrDefault();

								guid_idadmin = items_user.id_usuario;
							}

							using (db_imEntities edm_centro = new db_imEntities())
							{
								var i_centro = (from c in edm_centro.inf_centro
												where c.id_tipo_centro == 2
												select c).ToList();

								if (i_centro.Count == 0)
								{

									using (var m_usuario = new db_imEntities())
									{
										var i_usuario = new inf_centro
										{
											id_tipo_centro = 2,
											id_centro = guid_nns,
											id_estatus = 1,
											id_licencia = int_licencia,
											id_codigo_centro = "intm_suc" + string.Format("{0:000}", 1),
											nombre = str_nsucursal,
											telefono = str_telefono,
											email = str_email,
											callenum = str_callenum,
											id_codigo = int_idcodigocp,
											dia_corte = int_dcorte,
											fecha_registro = DateTime.Now,

										};
										m_usuario.inf_centro.Add(i_usuario);
										m_usuario.SaveChanges();
									}

									using (var m_usuario = new db_imEntities())
									{
										var i_usuario = new inf_centro_dep
										{
											id_usuario = guid_idadmin,
											id_centro = guid_nns,
										};
										m_usuario.inf_centro_dep.Add(i_usuario);
										m_usuario.SaveChanges();
									}
								}
								else
								{
									using (var m_usuario = new db_imEntities())
									{
										var i_usuario = new inf_centro
										{
											id_tipo_centro = 2,
											id_centro = guid_nns,
											id_estatus = 1,
											id_licencia = int_licencia,
											id_codigo_centro = "intm_suc" + string.Format("{0:000}", i_centro.Count + 1),
											nombre = str_nsucursal,
											telefono = str_telefono,
											email = str_email,
											callenum = str_callenum,
											id_codigo = int_idcodigocp,
											dia_corte = int_dcorte,
											fecha_registro = DateTime.Now,

										};
										m_usuario.inf_centro.Add(i_usuario);
										m_usuario.SaveChanges();
									}

									using (var m_usuario = new db_imEntities())
									{
										var i_usuario = new inf_centro_dep
										{
											id_usuario = guid_idadmin,
											id_centro = guid_nns,
										};
										m_usuario.inf_centro_dep.Add(i_usuario);
										m_usuario.SaveChanges();
									}
								}
							}


							limpia_txt_sucursal();

							lblModalTitle.Text = "Intelimundo";
							lblModalBody.Text = "Datos de sucursal agregados con éxito";
							ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
							upModal.Update();
						}
					}
				}
			}
			else if (int_accion_sucursal == 2)
			{
				foreach (GridViewRow row in gv_sucursal.Rows)
				{
					if (row.RowType == DataControlRowType.DataRow)
					{
						CheckBox chkRow = (row.Cells[1].FindControl("chk_sucursal") as CheckBox);
						if (chkRow.Checked)
						{
							string codeuser = row.Cells[1].Text;

							using (db_imEntities data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_centro
												  where c.id_codigo_centro == codeuser
												  select c).FirstOrDefault();

								guid_idcentro = items_user.id_centro;
							}

							using (var data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_centro
												  where c.id_centro == guid_idcentro
												  select c).FirstOrDefault();


								items_user.id_licencia = int_licencia;
								items_user.nombre = str_nsucursal;
								items_user.telefono = str_telefono;
								items_user.email = str_email;
								items_user.callenum = str_callenum;
								items_user.id_codigo = int_idcodigocp;
								items_user.dia_corte = int_dcorte;
								data_user.SaveChanges();
							}

							foreach (GridViewRow rowf in gv_administrador.Rows)
							{
								if (rowf.RowType == DataControlRowType.DataRow)
								{
									CheckBox chkRowf = (rowf.Cells[1].FindControl("chk_administrador") as CheckBox);
									if (chkRowf.Checked)
									{
										string codeuserf = rowf.Cells[1].Text;
										Guid guid_fadmin;
										using (var data_user = new db_imEntities())
										{
											var items_user = (from c in data_user.inf_usuarios
															  where c.codigo_usuario == codeuserf
															  select c).FirstOrDefault();
											guid_fadmin = items_user.id_usuario;

										}

										using (var data_user = new db_imEntities())
										{
											var items_user = (from c in data_user.inf_centro_dep
															  where c.id_centro == guid_idcentro
															  where c.id_usuario == guid_fadmin
															  select c).FirstOrDefault();


											items_user.id_usuario = guid_fadmin;


											data_user.SaveChanges();
										}

										limpia_txt_sucursal();



										gv_sucursal.Visible = false;
										txt_buscar_sucursal.Visible = false;
										btn_buscar_sucursal.Visible = false;

										lblModalTitle.Text = "Intelimundo";
										lblModalBody.Text = "Datos de sucursal actualizados con éxito";
										ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
										upModal.Update();
									}
								}
							}

						}
					}
				}
			}
			else if (int_accion_sucursal == 3)
			{
				foreach (GridViewRow row in gv_sucursal.Rows)
				{
					if (row.RowType == DataControlRowType.DataRow)
					{
						CheckBox chkRow = (row.Cells[1].FindControl("chk_sucursal") as CheckBox);
						if (chkRow.Checked)
						{
							string codeuser = row.Cells[1].Text;

							using (db_imEntities data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_centro
												  where c.id_codigo_centro == codeuser
												  select c).FirstOrDefault();

								guid_idcentro = items_user.id_centro;
							}

							using (var data_user = new db_imEntities())
							{
								var items_user = (from c in data_user.inf_centro
												  where c.id_centro == guid_idcentro
												  select c).FirstOrDefault();


								items_user.id_estatus = 3;


								data_user.SaveChanges();
							}


							limpia_txt_sucursal();



							gv_sucursal.Visible = false;
							txt_buscar_sucursal.Visible = false;
							btn_buscar_sucursal.Visible = false;

							lblModalTitle.Text = "Intelimundo";
							lblModalBody.Text = "Datos de sucursal dados de baja con éxito";
							ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
							upModal.Update();
							//foreach (GridViewRow rowf in gv_administrador.Rows)
							//{
							//    if (rowf.RowType == DataControlRowType.DataRow)
							//    {
							//        CheckBox chkRowf = (rowf.Cells[1].FindControl("chk_administrador") as CheckBox);
							//        if (chkRowf.Checked)
							//        {
							//            string codeuserf = rowf.Cells[1].Text;
							//            Guid guid_fadmin;
							//            using (var data_user = new db_imEntities())
							//            {
							//                var items_user = (from c in data_user.inf_usuarios
							//                                  where c.codigo_usuario == codeuserf
							//                                  select c).FirstOrDefault();
							//                guid_fadmin = items_user.id_usuario;

							//            }

							//            using (var data_user = new db_imEntities())
							//            {
							//                var items_user = (from c in data_user.inf_centro_dep
							//                                  where c.id_centro == guid_idcentro
							//                                  where c.id_usuario == guid_fadmin
							//                                  select c).FirstOrDefault();


							//                items_user.id_usuario = guid_fadmin;


							//                data_user.SaveChanges();
							//            }

							//        }
							//    }
							//}

						}
					}
				}
			}
		}
		private void limpia_txt_sucursal()
		{
			if (ddl_licencias.Items.Count == 0)
			{
				ddl_licencias.Items.Clear();
				using (db_imEntities m_tiporfc = new db_imEntities())
				{
					var i_tiporfc = (from f_tr in m_tiporfc.fact_licencias
									 select f_tr).ToList();

					ddl_licencias.DataSource = i_tiporfc;
					ddl_licencias.DataTextField = "desc_licencia";
					ddl_licencias.DataValueField = "id_licencia";
					ddl_licencias.DataBind();
				}

				ddl_licencias.Items.Insert(0, new ListItem("*Licencia", "0"));
				ddl_licencias.SelectedValue = "0";
			}
			else
			{
				ddl_licencias.SelectedValue = "0";
			}

			txt_nombre_sucursal.Text = "";
			txt_telefono_sucursal.Text = "";
			txt_email_sucursal.Text = "";
			txt_dcorte_sucursal.Text = "";

			txt_callenum_sucursal.Text = "";
			txt_cp_sucursal.Text = "";

			ddl_colonia_sucursal.Items.Clear();
			ddl_colonia_sucursal.Items.Insert(0, new ListItem("*Colonia", "0"));
			ddl_colonia_sucursal.SelectedValue = "0";
			txt_municipio_sucursal.Text = "";
			txt_estado_sucursal.Text = "";

		}
		#endregion

		#region proveedor
		protected void lkbtn_nuevo_proveedor_Click(object sender, EventArgs e)
		{
			int_accion_proveedor = 1;
			i_agrega_proveedor.Attributes["style"] = "color:#B9005C";
			i_edita_proveedor.Attributes["style"] = "color:#079DBC";
			i_baja_proveedor.Attributes["style"] = "color:#079DBC";
			limpia_txt_proveedor();

			txt_buscar_proveedor.Visible = false;
			btn_buscar_proveedor.Visible = false;
			gv_proveedor.Visible = false;
		}
		protected void lkbtn_edita_proveedor_Click(object sender, EventArgs e)
		{
			int_accion_proveedor = 2;
			i_agrega_proveedor.Attributes["style"] = "color:#079DBC";
			i_edita_proveedor.Attributes["style"] = "color:#B9005C";
			i_baja_proveedor.Attributes["style"] = "color:#079DBC";
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
			i_agrega_proveedor.Attributes["style"] = "color:#079DBC";
			i_edita_proveedor.Attributes["style"] = "color:#079DBC";
			i_baja_proveedor.Attributes["style"] = "color:#B9005C";
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

				txt_buscar_proveedor.BackColor = Color.FromArgb(185, 0, 92);
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
						row.BackColor = Color.FromArgb(185, 0, 92);
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

				txt_cp_proveedor.BackColor = Color.FromArgb(185, 0, 92);
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
					ddl_tipo_rfc_proveedor.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					ddl_tipo_rfc_proveedor.BackColor = Color.White;
					if (string.IsNullOrEmpty(txt_rfc_proveedor.Text))
					{

						txt_rfc_proveedor.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						txt_rfc_proveedor.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_empresa_proveedor.Text))
						{

							txt_empresa_proveedor.BackColor = Color.FromArgb(185, 0, 92);
						}
						else
						{
							txt_empresa_proveedor.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_telefono_proveedor.Text))
							{

								txt_telefono_proveedor.BackColor = Color.FromArgb(185, 0, 92);
							}
							else
							{
								txt_telefono_proveedor.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_email_proveedor.Text))
								{

									txt_email_proveedor.BackColor = Color.FromArgb(185, 0, 92);
								}
								else
								{
									txt_email_proveedor.BackColor = Color.Transparent;
									if (string.IsNullOrEmpty(txt_callenum_proveedor.Text))
									{

										txt_callenum_proveedor.BackColor = Color.FromArgb(185, 0, 92);
									}
									else
									{
										txt_callenum_proveedor.BackColor = Color.Transparent;
										if (string.IsNullOrEmpty(txt_cp_proveedor.Text))
										{

											txt_cp_proveedor.BackColor = Color.FromArgb(185, 0, 92);
										}
										else
										{
											txt_cp_proveedor.BackColor = Color.Transparent;
											if (ddl_colonia_proveedor.SelectedValue == "0")
											{
												ddl_colonia_proveedor.BackColor = Color.FromArgb(185, 0, 92);
											}
											else
											{
												ddl_colonia_proveedor.BackColor = Color.White;
												if (string.IsNullOrEmpty(txt_nombres_cproveedor.Text))
												{

													txt_nombres_cproveedor.BackColor = Color.FromArgb(185, 0, 92);
												}
												else
												{
													txt_nombres_cproveedor.BackColor = Color.Transparent;
													if (string.IsNullOrEmpty(txt_apaterno_cproveedor.Text))
													{

														txt_apaterno_cproveedor.BackColor = Color.FromArgb(185, 0, 92);
													}
													else
													{
														txt_apaterno_cproveedor.BackColor = Color.Transparent;
														if (string.IsNullOrEmpty(txt_amaterno_cproveedor.Text))
														{

															txt_amaterno_cproveedor.BackColor = Color.FromArgb(185, 0, 92);
														}
														else
														{
															txt_amaterno_cproveedor.BackColor = Color.Transparent;
															if (string.IsNullOrEmpty(txt_telefono_cproveedor.Text))
															{

																txt_telefono_cproveedor.BackColor = Color.FromArgb(185, 0, 92);
															}
															else
															{
																txt_telefono_cproveedor.BackColor = Color.Transparent;
																if (string.IsNullOrEmpty(txt_email_cproveedor.Text))
																{

																	txt_email_cproveedor.BackColor = Color.FromArgb(185, 0, 92);
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
						id_centro = guid_centro
					};
					m_usuario.inf_proveedor.Add(i_usuario);
					m_usuario.SaveChanges();
				}

				//using (var m_usuario = new db_imEntities())
				//{
				//	var i_usuario = new inf_contacto_proveedor
				//	{
				//		id_contacto_proveedor = guid_ncproveedor,
				//		nombres = str_nombres,
				//		a_paterno = str_apaterno,
				//		a_materno = str_amaterno,
				//		telefono = str_telefonoc,
				//		email = str_emailc,
				//		id_estatus = 1,

				//		fecha_registro = DateTime.Now,
				//		id_proveedor = guid_nrs,

				//	};
				//	m_usuario.inf_contacto_proveedor.Add(i_usuario);
				//	m_usuario.SaveChanges();
				//}

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

		#region alumnos

		protected void lkbtn_nuevo_alumno_Click(object sender, EventArgs e)
		{
			int_accion_alumno = 1;
			i_agrega_alumno.Attributes["style"] = "color:#B9005C";
			i_edita_alumno.Attributes["style"] = "color:#079DBC";

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
			i_agrega_alumno.Attributes["style"] = "color:#079DBC";
			i_edita_alumno.Attributes["style"] = "color:#B9005C";

			limpia_txt_alumnos();
			grid_alumnos(8);
			txt_buscar_alumno.Visible = true;
			btn_busca_alumno.Visible = true;


			chkb_activar_alumno.Visible = true;

		}
		protected void lkbtn_baja_alumno_Click(object sender, EventArgs e)
		{
			int_accion_alumno = 3;
			i_agrega_alumno.Attributes["style"] = "color:#079DBC";
			i_edita_alumno.Attributes["style"] = "color:#079DBC";

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

				txt_buscar_alumno.BackColor = Color.FromArgb(185, 0, 92);
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

					ddl_genero_alumno.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					ddl_genero_alumno.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_nombres_alumno.Text))
					{

						txt_nombres_alumno.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						txt_nombres_alumno.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_apaterno_alumno.Text))
						{

							txt_apaterno_alumno.BackColor = Color.FromArgb(185, 0, 92);
						}
						else
						{
							txt_apaterno_alumno.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_amaterno_alumno.Text))
							{

								txt_amaterno_alumno.BackColor = Color.FromArgb(185, 0, 92);
							}
							else
							{
								txt_amaterno_alumno.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_fecna_alumno.Text))
								{

									txt_fecna_alumno.BackColor = Color.FromArgb(185, 0, 92);
								}
								else
								{
									txt_fecna_alumno.BackColor = Color.Transparent;
									if (string.IsNullOrEmpty(txt_alumno_alumno.Text))
									{

										txt_alumno_alumno.BackColor = Color.FromArgb(185, 0, 92);
									}
									else
									{
										txt_alumno_alumno.BackColor = Color.Transparent;
										if (string.IsNullOrEmpty(txt_clave_alumno.Text))
										{

											txt_clave_alumno.BackColor = Color.FromArgb(185, 0, 92);
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
						row.BackColor = Color.FromArgb(185, 0, 92);
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

				ddl_genero_alumno.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				ddl_genero_alumno.BackColor = Color.Transparent;
				if (string.IsNullOrEmpty(txt_nombres_alumno.Text))
				{

					txt_nombres_alumno.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					txt_nombres_alumno.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_apaterno_alumno.Text))
					{

						txt_apaterno_alumno.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						txt_apaterno_alumno.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_amaterno_alumno.Text))
						{

							txt_amaterno_alumno.BackColor = Color.FromArgb(185, 0, 92);
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
				using (db_imEntities edm_alumnof = new db_imEntities())
				{
					var i_alumnof = (from c in edm_alumnof.inf_alumnos
									 where c.codigo_alumno == str_alumno
									 where c.id_centro == guid_centro
									 select c).ToList();

					if (i_alumnof.Count == 0)
					{
						using (db_imEntities edm_alumno = new db_imEntities())
						{
							var i_alumno = (from c in edm_alumno.inf_alumnos
											where c.id_centro == guid_centro
											select c).ToList();

							if (i_alumno.Count == 0)
							{
								string str_codigoalumno = "intm_alum" + string.Format("{0:000}", (object)(i_alumno.Count + 1));
								using (var m_alumno = new db_imEntities())
								{
									var i_alumnoff = new inf_alumnos
									{
										id_alumno = guid_nalumno,
										id_codigo_alumno = str_codigoalumno,
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
									m_alumno.inf_alumnos.Add(i_alumnoff);
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
								i_agrega_alumno.Attributes["style"] = "color:#079DBC";
								i_edita_alumno.Attributes["style"] = "color:#079DBC";

								lblModalTitle.Text = "Intelimundo";
								lblModalBody.Text = "Datos de alumno agregados con éxito";
								ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
								upModal.Update();
							}
							else
							{
								string str_codigoalumno = "intm_alum" + string.Format("{0:000}", (object)(i_alumno.Count + 1));
								using (var m_alumno = new db_imEntities())
								{
									var i_alumnoff = new inf_alumnos
									{
										id_alumno = guid_nalumno,
										id_codigo_alumno = str_codigoalumno,
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
									m_alumno.inf_alumnos.Add(i_alumnoff);
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
								i_agrega_alumno.Attributes["style"] = "color:#079DBC";
								i_edita_alumno.Attributes["style"] = "color:#079DBC";

								lblModalTitle.Text = "Intelimundo";
								lblModalBody.Text = "Datos de alumno agregados con éxito";
								ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
								upModal.Update();
							}
						}

					}
					else
					{
						lblModalTitle.Text = "Intelimundo";
						lblModalBody.Text = "Alumno ya existe en la base de datos, favor de reintentar";
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
							row.BackColor = Color.FromArgb(185, 0, 92);
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
							row.BackColor = Color.FromArgb(185, 0, 92);
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

		#region usuarios

		protected void lkbtn_nuevo_usuario_Click(object sender, EventArgs e)
		{
			int_accion_usuario = 1;
			i_agrega_usuario.Attributes["style"] = "color:#B9005C";
			i_edita_usuario.Attributes["style"] = "color:#079DBC";

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
			i_agrega_usuario.Attributes["style"] = "color:#079DBC";
			i_edita_usuario.Attributes["style"] = "color:#B9005C";

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
			i_agrega_usuario.Attributes["style"] = "color:#079DBC";
			i_edita_usuario.Attributes["style"] = "color:#079DBC";

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

				txt_buscar_usuario.BackColor = Color.FromArgb(185, 0, 92);
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
					if (int_accion_usuario == 2)
					{
						grid_usuarios(int_tipousuario);
					}
		
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
					if (int_accion_usuario == 2)
					{
						grid_usuarios(int_tipousuario);
					}
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

					if (int_accion_usuario == 2)
					{
						grid_usuarios(int_tipousuario);
					}
				}
			}
			else
			{
				limpia_txt_usuarios();
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

					if (int_accion_usuario == 2)
					{
						grid_usuarios(int_tipousuario);
					}
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

					if (int_accion_usuario == 2)
					{
						grid_usuarios(int_tipousuario);
					}
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

					if (int_accion_usuario == 2)
					{
						grid_usuarios(int_tipousuario);
					}
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

						ddl_genero_usuario.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						ddl_genero_usuario.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_nombres_usuario.Text))
						{

							txt_nombres_usuario.BackColor = Color.FromArgb(185, 0, 92);
						}
						else
						{
							txt_nombres_usuario.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_apaterno_usuario.Text))
							{

								txt_apaterno_usuario.BackColor = Color.FromArgb(185, 0, 92);
							}
							else
							{
								txt_apaterno_usuario.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_amaterno_usuario.Text))
								{

									txt_amaterno_usuario.BackColor = Color.FromArgb(185, 0, 92);
								}
								else
								{
									txt_amaterno_usuario.BackColor = Color.Transparent;
									if (string.IsNullOrEmpty(txt_fecnac_usuario.Text))
									{

										txt_fecnac_usuario.BackColor = Color.FromArgb(185, 0, 92);
									}
									else
									{
										txt_fecnac_usuario.BackColor = Color.Transparent;
										if (string.IsNullOrEmpty(txt_usuario_usuario.Text))
										{

											txt_usuario_usuario.BackColor = Color.FromArgb(185, 0, 92);
										}
										else
										{
											txt_usuario_usuario.BackColor = Color.Transparent;
											if (string.IsNullOrEmpty(txt_clave_usuario.Text))
											{

												txt_clave_usuario.BackColor = Color.FromArgb(185, 0, 92);
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
						row.BackColor = Color.FromArgb(185, 0, 92);
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

					ddl_genero_usuario.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					ddl_genero_usuario.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_nombres_usuario.Text))
					{

						txt_nombres_usuario.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						txt_nombres_usuario.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_apaterno_usuario.Text))
						{

							txt_apaterno_usuario.BackColor = Color.FromArgb(185, 0, 92);
						}
						else
						{
							txt_apaterno_usuario.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_amaterno_usuario.Text))
							{

								txt_amaterno_usuario.BackColor = Color.FromArgb(185, 0, 92);
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
						i_agrega_usuario.Attributes["style"] = "color:#079DBC";
						i_edita_usuario.Attributes["style"] = "color:#079DBC";


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
							row.BackColor = Color.FromArgb(185, 0, 92);
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
							row.BackColor = Color.FromArgb(185, 0, 92);
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
				int_tipousuario = 6;
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
			i_editaempresa.Attributes["style"] = "color:#B9005C";

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

				txt_cp_empresa.BackColor = Color.FromArgb(185, 0, 92);
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

				ddl_tipo_rfc_empresa.BackColor = Color.FromArgb(185, 0, 92);
			}
			else
			{
				ddl_tipo_rfc_empresa.BackColor = Color.Transparent;
				if (string.IsNullOrEmpty(txt_rfc_empresa.Text))
				{

					txt_rfc_empresa.BackColor = Color.FromArgb(185, 0, 92);
				}
				else
				{
					txt_rfc_empresa.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_rs_empresa.Text))
					{

						txt_rs_empresa.BackColor = Color.FromArgb(185, 0, 92);
					}
					else
					{
						txt_rs_empresa.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_telefono_empresa.Text))
						{

							txt_telefono_empresa.BackColor = Color.FromArgb(185, 0, 92);
						}
						else
						{
							txt_telefono_empresa.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_email_empresa.Text))
							{

								txt_email_empresa.BackColor = Color.FromArgb(185, 0, 92);
							}
							else
							{
								txt_email_empresa.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_callenum_empresa.Text))
								{

									txt_callenum_empresa.BackColor = Color.FromArgb(185, 0, 92);
								}
								else
								{
									txt_callenum_empresa.BackColor = Color.Transparent;
									if (string.IsNullOrEmpty(txt_cp_empresa.Text))
									{

										txt_cp_empresa.BackColor = Color.FromArgb(185, 0, 92);
									}
									else
									{
										txt_cp_empresa.BackColor = Color.Transparent;
										if (ddl_colonia_empresa.SelectedValue == "0")
										{

											ddl_colonia_empresa.BackColor = Color.FromArgb(185, 0, 92);
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