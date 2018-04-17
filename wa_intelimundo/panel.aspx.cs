using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wa_intelimundo
{
    public partial class panel : System.Web.UI.Page
    {
        static Guid guid_centro, guid_fuser, guid_idalumno, guid_idproveedor, guid_idadmin, guid_idcentro;
        static int int_idtipousuario, int_accion_usuario, int_tipousuario, int_accion_alumno, int_accion_proveedor, int_accion_sucursal, int_accion_inventario;
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
                Response.Redirect("ctrl_acceso.aspx");
            }
        }
        private void inf_user()
        {

            guid_fuser = (Guid)(Session["ss_id_user"]);
            guid_centro = (Guid)(Session["ss_id_center"]);


            using (db_imEntities m_usuario = new db_imEntities())
            {
                var i_usuario = (from i_u in m_usuario.inf_usuarios
                                 join i_tu in m_usuario.fact_tipo_usuario on i_u.id_tipo_usuario equals i_tu.id_tipo_usuario
                                 join i_cd in m_usuario.inf_centro_dep on i_u.id_usuario equals i_cd.id_usuario
                                 join i_c in m_usuario.inf_centro on i_cd.id_centro equals i_c.id_centro
                                 where i_c.id_centro == guid_centro
                                 where i_u.id_usuario == guid_fuser
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

        #region panel
        protected void lkb_edita_usuario_Click(object sender, EventArgs e)
        {
            pnl_fusuario.Visible = true;
            pnl_centro.Visible = false;
			pnl_inventarios.Visible = false;
			pnl_sucursales.Visible = false;
            pnl_proveedores.Visible = false;
            pnl_alumnos.Visible = false;
            pnl_usuarios.Visible = false;
            pnl_empresa.Visible = false;

            i_editausuario.Attributes["style"] = "color:orangered";
            i_editacentro.Attributes["style"] = "color:dimgray";
            i_editausuariof.Attributes["style"] = "color:dimgray";
			i_inventarios.Attributes["style"] = "color:dimgray";
			i_sucursales.Attributes["style"] = "color:dimgray";
            i_proveedores.Attributes["style"] = "color:dimgray";
            i_alumnos.Attributes["style"] = "color:dimgray";
            i_usuarios.Attributes["style"] = "color:dimgray";
            i_empresa.Attributes["style"] = "color:dimgray";
            i_salir.Attributes["style"] = "color:dimgray";

            limpiar_textbox_fusuario();
        }
        protected void lkb_edita_centro_Click(object sender, EventArgs e)
        {
            pnl_fusuario.Visible = false;
            pnl_centro.Visible = true;
			pnl_inventarios.Visible = false;
			pnl_sucursales.Visible = false;
            pnl_proveedores.Visible = false;
            pnl_alumnos.Visible = false;
            pnl_usuarios.Visible = false;
            pnl_empresa.Visible = false;

            i_editausuario.Attributes["style"] = "color:dimgray";
            i_editacentro.Attributes["style"] = "color:orangered";
            i_editacentrof.Attributes["style"] = "color:dimgray";
			i_inventarios.Attributes["style"] = "color:dimgray";
			i_sucursales.Attributes["style"] = "color:dimgray";
            i_proveedores.Attributes["style"] = "color:dimgray";
            i_alumnos.Attributes["style"] = "color:dimgray";
            i_usuarios.Attributes["style"] = "color:dimgray";
            i_empresa.Attributes["style"] = "color:dimgray";
            i_salir.Attributes["style"] = "color:dimgray";

            limpia_txt_centro();

            i_editacentrof.Attributes["style"] = "color:dimgray";
        }
		protected void lkb_inventario_Click(object sender, EventArgs e)
		{
			int_accion_inventario = 0;

			pnl_fusuario.Visible = false;
			pnl_centro.Visible = false;
			pnl_inventarios.Visible = false;
			pnl_sucursales.Visible = false;
			pnl_proveedores.Visible = false;
			pnl_inventarios.Visible = true;
			pnl_alumnos.Visible = false;
			pnl_usuarios.Visible = false;
			pnl_empresa.Visible = false;

			i_editausuario.Attributes["style"] = "color:dimgray";
			i_editacentro.Attributes["style"] = "color:dimgray";
			i_editacentrof.Attributes["style"] = "color:dimgray";
			i_inventarios.Attributes["style"] = "color:dimgray";
			i_sucursales.Attributes["style"] = "color:dimgray";
			i_inventarios.Attributes["style"] = "color:orangered";
			i_alumnos.Attributes["style"] = "color:dimgray";
			i_usuarios.Attributes["style"] = "color:dimgray";
			i_empresa.Attributes["style"] = "color:dimgray";
			i_salir.Attributes["style"] = "color:dimgray";

			limpiart_txt_inventario();

			i_agrega_inventario.Attributes["style"] = "color:dimgray";
			i_edita_inventario.Attributes["style"] = "color:dimgray";
			i_baja_inventario.Attributes["style"] = "color:dimgray";
		}
		protected void lkb_sucursales_Click(object sender, EventArgs e)
        {
            int_accion_proveedor = 0;

            pnl_fusuario.Visible = false;
            pnl_centro.Visible = false;
			pnl_inventarios.Visible = false;
			pnl_sucursales.Visible = true;
            pnl_proveedores.Visible = false;
            pnl_alumnos.Visible = false;
            pnl_usuarios.Visible = false;
            pnl_empresa.Visible = false;

            i_editausuario.Attributes["style"] = "color:dimgray";
            i_editacentro.Attributes["style"] = "color:dimgray";
            i_editacentrof.Attributes["style"] = "color:dimgray";
			i_inventarios.Attributes["style"] = "color:dimgray";
			i_sucursales.Attributes["style"] = "color:orangered";
            i_proveedores.Attributes["style"] = "color:dimgray";
            i_alumnos.Attributes["style"] = "color:dimgray";
            i_usuarios.Attributes["style"] = "color:dimgray";
            i_empresa.Attributes["style"] = "color:dimgray";
            i_salir.Attributes["style"] = "color:dimgray";

            limpia_txt_sucursal();

			txt_buscar_sucursal.Text = "";
			txt_buscar_sucursal.Visible = false;
			btn_buscar_sucursal.Visible = false;
			gv_sucursal.Visible = false;
			gv_administrador.Visible = false;

			i_agrega_sucursal.Attributes["style"] = "color:dimgray";
            i_edita_sucursal.Attributes["style"] = "color:dimgray";
            i_baja_sucursal.Attributes["style"] = "color:dimgray";
        }
        protected void lkb_proveedores_Click(object sender, EventArgs e)
        {
            int_accion_proveedor = 0;

            pnl_fusuario.Visible = false;
            pnl_centro.Visible = false;
			pnl_inventarios.Visible = false;
			pnl_sucursales.Visible = false;
            pnl_proveedores.Visible = true;
            pnl_alumnos.Visible = false;
            pnl_usuarios.Visible = false;
            pnl_empresa.Visible = false;

            i_editausuario.Attributes["style"] = "color:dimgray";
            i_editacentro.Attributes["style"] = "color:dimgray";
            i_editacentrof.Attributes["style"] = "color:dimgray";
			i_inventarios.Attributes["style"] = "color:dimgray";
			i_sucursales.Attributes["style"] = "color:dimgray";
            i_proveedores.Attributes["style"] = "color:orangered";
            i_alumnos.Attributes["style"] = "color:dimgray";
            i_usuarios.Attributes["style"] = "color:dimgray";
            i_empresa.Attributes["style"] = "color:dimgray";
            i_salir.Attributes["style"] = "color:dimgray";

            limpia_txt_proveedor();

            i_agrega_proveedor.Attributes["style"] = "color:dimgray";
            i_edita_proveedor.Attributes["style"] = "color:dimgray";
            i_baja_proveedor.Attributes["style"] = "color:dimgray";
        }
        protected void lkb_alumnos_Click(object sender, EventArgs e)
        {
            pnl_fusuario.Visible = false;
            pnl_centro.Visible = false;
			pnl_inventarios.Visible = false;
			pnl_sucursales.Visible = false;
            pnl_proveedores.Visible = false;
            pnl_alumnos.Visible = true;
            pnl_usuarios.Visible = false;
            pnl_empresa.Visible = false;

            i_editausuario.Attributes["style"] = "color:dimgray";
            i_editacentro.Attributes["style"] = "color:dimgray";
            i_editacentrof.Attributes["style"] = "color:dimgray";
			i_inventarios.Attributes["style"] = "color:dimgray";
			i_sucursales.Attributes["style"] = "color:dimgray";
            i_proveedores.Attributes["style"] = "color:dimgray";
            i_alumnos.Attributes["style"] = "color:orangered";
            i_usuarios.Attributes["style"] = "color:dimgray";
            i_empresa.Attributes["style"] = "color:dimgray";
            i_salir.Attributes["style"] = "color:dimgray";

            limpia_txt_alumno();

            i_agrega_alumno.Attributes["style"] = "color:dimgray";
            i_edita_alumno.Attributes["style"] = "color:dimgray";
            i_baja_alumno.Attributes["style"] = "color:dimgray";
        }
        protected void lkb_usuarios_Click(object sender, EventArgs e)
        {
            pnl_fusuario.Visible = false;
            pnl_centro.Visible = false;
			pnl_inventarios.Visible = false;
			pnl_sucursales.Visible = false;
            pnl_proveedores.Visible = false;
            pnl_alumnos.Visible = false;
            pnl_usuarios.Visible = true;
            pnl_empresa.Visible = false;

            i_editausuario.Attributes["style"] = "color:dimgray";
            i_editacentro.Attributes["style"] = "color:dimgray";
            i_editacentrof.Attributes["style"] = "color:dimgray";
			i_inventarios.Attributes["style"] = "color:dimgray";
			i_sucursales.Attributes["style"] = "color:dimgray";
            i_proveedores.Attributes["style"] = "color:dimgray";
            i_alumnos.Attributes["style"] = "color:dimgray";
            i_usuarios.Attributes["style"] = "color:orangered";
            i_empresa.Attributes["style"] = "color:dimgray";
            i_salir.Attributes["style"] = "color:dimgray";

            limpia_txt_usuarios();

            i_agrega_usuario.Attributes["style"] = "color:dimgray";
            i_edita_usuario.Attributes["style"] = "color:dimgray";
            i_baja_usuario.Attributes["style"] = "color:dimgray";

            chkb_administrador.Checked = false;
            chkb_gerente.Checked = false;
            chkb_facilitador.Checked = false;
            chkb_ejecutivo.Checked = false;
            chkb_contador.Checked = false;
            chkb_vendedor.Checked = false;

        }
        protected void lkb_empresa_Click(object sender, EventArgs e)
        {
            pnl_fusuario.Visible = false;
            pnl_centro.Visible = false;
			pnl_inventarios.Visible = false;
			pnl_sucursales.Visible = false;
            pnl_proveedores.Visible = false;
            pnl_alumnos.Visible = false;
            pnl_usuarios.Visible = false;
            pnl_empresa.Visible = true;

            i_editausuario.Attributes["style"] = "color:dimgray";
            i_editacentro.Attributes["style"] = "color:dimgray";
			i_inventarios.Attributes["style"] = "color:dimgray";
			i_sucursales.Attributes["style"] = "color:dimgray";
            i_proveedores.Attributes["style"] = "color:dimgray";
            i_alumnos.Attributes["style"] = "color:dimgray";
            i_usuarios.Attributes["style"] = "color:dimgray";
            i_empresa.Attributes["style"] = "color:orangered";

            lkb_editar_empresa.Attributes["style"] = "color:dimgray";
            i_salir.Attributes["style"] = "color:dimgray";

            limpiar_textbox_empresa();

            i_editaempresa.Attributes["style"] = "color:dimgray";
        }
        protected void lkb_salir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("acceso.aspx");
        }


        #endregion

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

                                        Guid guid_idusuariof;
                                        int int_genero = int.Parse(ddl_genero_fusuario.SelectedValue);
                                        string str_nombres = txt_nombres_fusuario.Text.ToUpper();
                                        string str_apaterno = txt_apaterno_fusuario.Text.ToUpper();
                                        string str_amaterno = txt_amaterno_fusuario.Text.ToUpper();
                                        DateTime date_cumple = DateTime.Parse(txt_cumple_fusuario.Text);
                                        string str_codigousuario = txt_usuario_fusuario.Text;
                                        string str_password = mdl_encrypta.Encrypt(txt_clave_fusuario.Text);

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
                                                                                where c.id_usuario == guid_fuser
                                                                                select c).FirstOrDefault();

                                                            i_fusuarioff.id_genero = int_genero;
                                                            i_fusuarioff.nombres = str_nombres;
                                                            i_fusuarioff.a_paterno = str_apaterno;
                                                            i_fusuarioff.a_materno = str_amaterno;
                                                            i_fusuarioff.fecha_nacimiento = date_cumple;
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
                                                i_fusuario[0].id_genero = int_genero;
                                                i_fusuario[0].nombres = str_nombres;
                                                i_fusuario[0].a_paterno = str_apaterno;
                                                i_fusuario[0].a_materno = str_amaterno;
                                                i_fusuario[0].fecha_nacimiento = date_cumple;
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
            using (db_imEntities m_genero = new db_imEntities())
            {
                var i_genero = (from f_tr in m_genero.fact_genero
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

            ddl_genero_fusuario.BackColor = Color.White;
            txt_nombres_fusuario.BackColor = Color.White;
            txt_apaterno_fusuario.BackColor = Color.White;
            txt_amaterno_fusuario.BackColor = Color.White;
            txt_cumple_fusuario.BackColor = Color.White;
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
                                      where i_c.id_usuario == guid_fuser
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
                    DateTime str_birthday = new DateTime();
                    str_birthday = Convert.ToDateTime(i_fusuario.fecha_nacimiento);
                    txt_cumple_fusuario.Text = str_birthday.ToShortDateString();
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
                                    i_u.calle,
                                    i_u.cp,
                                    i_u.id_asenta_cpcons,


                                }).FirstOrDefault();

                ddl_licencias_centro.SelectedValue = inf_user.id_licencia.ToString();
                txt_nombre_centro.Text = inf_user.nombre;
                txt_telefono_centro.Text = inf_user.telefono;
                txt_email_centro.Text = inf_user.email;
                txt_callenum_centro.Text = inf_user.calle;

                int int_fcolonia = int.Parse(inf_user.id_asenta_cpcons.ToString());
                string str_fcp = txt_cp_centro.Text = inf_user.cp;

                using (db_imEntities db_sepomex = new db_imEntities())
                {
                    var tbl_sepomex = (from c in db_sepomex.inf_sepomex
                                       where c.id_asenta_cpcons == int_fcolonia
                                       where c.d_codigo == str_fcp
                                       select c).ToList();

                    ddl_colonia_centro.DataSource = tbl_sepomex;
                    ddl_colonia_centro.DataTextField = "d_asenta";
                    ddl_colonia_centro.DataValueField = "id_asenta_cpcons";
                    ddl_colonia_centro.DataBind();

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


            using (var m_fempresa = new db_imEntities())
            {
                var i_fempresa = (from c in m_fempresa.inf_centro
                                  where c.id_centro == guid_centro
                                  select c).FirstOrDefault();

                i_fempresa.id_licencia = 4;
                i_fempresa.nombre = str_corporativo;
                i_fempresa.telefono = str_telefono;
                i_fempresa.email = str_email;
                i_fempresa.calle = str_callenum;
                i_fempresa.cp = str_cp;
                i_fempresa.id_asenta_cpcons = int_colony;

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


		#region inventario

		protected void lkbtn_nuevo_inventario_Click(object sender, EventArgs e)
		{
			int_accion_inventario = 1;
			i_agrega_inventario.Attributes["style"] = "color:orangered";
			i_edita_inventario.Attributes["style"] = "color:dimgray";
			i_baja_inventario.Attributes["style"] = "color:dimgray";
			limpiart_txt_inventario();

			txt_buscar_inventario.Visible = false;
			btn_buscar_inventario.Visible = false;
			gv_inventario.Visible = false;
		}
		protected void lkbtn_edita_inventario_Click(object sender, EventArgs e)
		{
			int_accion_inventario = 2;
			i_agrega_inventario.Attributes["style"] = "color:dimgray";
			i_edita_inventario.Attributes["style"] = "color:orangered";
			i_baja_inventario.Attributes["style"] = "color:dimgray";
			limpiart_txt_inventario();

			txt_buscar_inventario.Visible = true;
			btn_buscar_inventario.Visible = true;

			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from u in data_user.inf_inventario
								where u.id_centro == guid_centro
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
		}
		protected void lkbtn_baja_inventario_Click(object sender, EventArgs e)

		{
			int_accion_inventario = 3;
			i_agrega_inventario.Attributes["style"] = "color:dimgray";
			i_edita_inventario.Attributes["style"] = "color:dimgray";
			i_baja_inventario.Attributes["style"] = "color:orangered";
			limpiart_txt_inventario();

			txt_buscar_inventario.Visible = true;
			btn_buscar_inventario.Visible = true;

			using (db_imEntities data_user = new db_imEntities())
			{
				var inf_user = (from u in data_user.inf_inventario
								where u.id_centro == guid_centro
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
		}
		protected void btn_margen_inventario_Click(object sender, EventArgs e)
		{

		}
		protected void btn_buscar_inventario_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_buscar_inventario.Text))
			{

				txt_buscar_inventario.BackColor = Color.IndianRed;
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

						using (db_imEntities data_user = new db_imEntities())
						{
							var inf_user = (from u in data_user.inf_inventario
											where u.id_centro == guid_centro
											where u.id_codigo_inventario == str_code
											select new
											{
												u.categoria,
												u.desc_inventario,
												u.caracteristica,
												u.cantidad,
												u.costo

											}).FirstOrDefault();

							txt_categoria_inventario.Text = inf_user.categoria;
							txt_desc_inventario.Text = inf_user.desc_inventario;
							txt_caracteristica_inventario.Text = inf_user.caracteristica;
							txt_cantidad_inventario.Text = inf_user.cantidad.ToString();
							txt_costo_inventario.Text = string.Format("{0:n2}", (Math.Truncate(Convert.ToDouble(inf_user.costo) * 100) / 100));
						}
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
				if (string.IsNullOrEmpty(txt_categoria_inventario.Text))
				{
					txt_categoria_inventario.BackColor = Color.IndianRed;
				}
				else
				{
					txt_categoria_inventario.BackColor = Color.Transparent;
					if (string.IsNullOrEmpty(txt_desc_inventario.Text))
					{
						txt_desc_inventario.BackColor = Color.IndianRed;
					}
					else
					{
						txt_desc_inventario.BackColor = Color.Transparent;
						if (string.IsNullOrEmpty(txt_caracteristica_inventario.Text))
						{
							txt_caracteristica_inventario.BackColor = Color.IndianRed;
						}
						else
						{
							txt_caracteristica_inventario.BackColor = Color.Transparent;
							if (string.IsNullOrEmpty(txt_cantidad_inventario.Text))
							{
								txt_cantidad_inventario.BackColor = Color.IndianRed;
							}
							else
							{
								txt_cantidad_inventario.BackColor = Color.Transparent;
								if (string.IsNullOrEmpty(txt_costo_inventario.Text))
								{
									txt_costo_inventario.BackColor = Color.IndianRed;
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

		private void guardar_inventario()
		{
			Guid guid_ngasto = Guid.NewGuid();
			string str_codigogasto = DateTime.Now.Ticks.ToString();
			string str_categoriagasto = txt_categoria_inventario.Text;
			string str_descgasto = txt_desc_inventario.Text;
			string str_caracteristicagasto = txt_caracteristica_inventario.Text;
			int int_cantidadgasto = int.Parse(txt_cantidad_inventario.Text);
			decimal dml_costogasto = decimal.Parse(txt_costo_inventario.Text);

			if (int_accion_inventario == 1)
			{
				using (var insert_address = new db_imEntities())
				{
					var items_address = new inf_inventario
					{
						id_inventario = guid_ngasto,
						id_codigo_inventario = str_codigogasto,
						categoria = str_categoriagasto,
						desc_inventario = str_descgasto,
						caracteristica = str_caracteristicagasto,
						cantidad = int_cantidadgasto,
						costo = dml_costogasto,
						fecha_registro = DateTime.Now,
						id_centro = guid_idcentro

					};

					insert_address.inf_inventario.Add(items_address);
					insert_address.SaveChanges();
				}

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

		private void limpiart_txt_inventario()
		{

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
            i_agrega_sucursal.Attributes["style"] = "color:orangered";
            i_edita_sucursal.Attributes["style"] = "color:dimgray";
            i_baja_sucursal.Attributes["style"] = "color:dimgray";
            limpia_txt_sucursal();
            txt_buscar_sucursal.Visible = false;
            btn_buscar_sucursal.Visible = false;
            gv_sucursal.Visible = false;

            using (db_imEntities data_user = new db_imEntities())
            {
                var inf_user = (from i_u in data_user.inf_usuarios
                                join i_e in data_user.fact_estatus on i_u.id_estatus equals i_e.id_estatus
                                where i_u.id_tipo_usuario == 3
                                where i_u.id_usuario != guid_fuser
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
            i_edita_sucursal.Attributes["style"] = "color:orangered";
            i_agrega_sucursal.Attributes["style"] = "color:dimgray";
     
            i_baja_sucursal.Attributes["style"] = "color:dimgray";
            limpia_txt_sucursal();

            txt_buscar_sucursal.Visible = true;
            btn_buscar_sucursal.Visible = true;



            using (db_imEntities data_user = new db_imEntities())
            {
                var inf_user = (from i_s in data_user.inf_centro
                                join i_l in data_user.fact_licencias on i_s.id_licencia equals i_l.id_licencia
                                join i_sd in data_user.inf_centro_dep on i_s.id_centro equals i_sd.id_centro
                                join i_u in data_user.inf_usuarios on i_sd.id_usuario equals i_u.id_usuario
                                where i_s.id_centro != guid_centro
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
                                where i_u.id_usuario != guid_fuser
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
            i_baja_sucursal.Attributes["style"] = "color:orangered";
            i_agrega_sucursal.Attributes["style"] = "color:dimgray";
            i_edita_sucursal.Attributes["style"] = "color:dimgray";

            limpia_txt_sucursal();

            txt_buscar_sucursal.Visible = true;
            btn_buscar_sucursal.Visible = true;


            using (db_imEntities data_user = new db_imEntities())
            {
                var inf_user = (from i_s in data_user.inf_centro
                                join i_l in data_user.fact_licencias on i_s.id_licencia equals i_l.id_licencia
                                join i_sd in data_user.inf_centro_dep on i_s.id_centro equals i_sd.id_centro
                                join i_u in data_user.inf_usuarios on i_sd.id_usuario equals i_u.id_usuario
                                where i_s.id_centro != guid_centro
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
                                where i_u.id_usuario != guid_fuser
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

                txt_buscar_sucursal.BackColor = Color.IndianRed;
            }
            else
            {
                txt_buscar_sucursal.BackColor = Color.Transparent;

                string str_userb = txt_buscar_usuario.Text;


                using (db_imEntities data_user = new db_imEntities())
                {
                    var inf_user = (from i_u in data_user.inf_fiscal
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
                        row.BackColor = Color.YellowGreen;
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
                                                i_u.calle,
                                                i_u.cp,
                                                i_u.id_asenta_cpcons,
                                            }).FirstOrDefault();

                            ddl_licencias.SelectedValue = inf_user.id_licencia.ToString();
                            txt_nombre_sucursal.Text = inf_user.nombre;
                            txt_telefono_sucursal.Text = inf_user.telefono;
                            txt_email_sucursal.Text = inf_user.email;
                            txt_callenum_sucursal.Text = inf_user.calle;

                            int int_fcolonia = int.Parse(inf_user.id_asenta_cpcons.ToString());
                            string str_fcp = txt_cp_sucursal.Text = inf_user.cp;

                            using (db_imEntities db_sepomex = new db_imEntities())
                            {
                                var tbl_sepomex = (from c in db_sepomex.inf_sepomex
                                                   where c.id_asenta_cpcons == int_fcolonia
                                                   where c.d_codigo == str_fcp
                                                   select c).ToList();

                                ddl_colonia_sucursal.DataSource = tbl_sepomex;
                                ddl_colonia_sucursal.DataTextField = "d_asenta";
                                ddl_colonia_sucursal.DataValueField = "id_asenta_cpcons";
                                ddl_colonia_sucursal.DataBind();

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
                        row.BackColor = Color.YellowGreen;

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

                txt_cp_sucursal.BackColor = Color.IndianRed;
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
                    ddl_licencias.BackColor = Color.IndianRed;
                }
                else
                {
                    ddl_licencias.BackColor = Color.White;
                    if (string.IsNullOrEmpty(txt_nombre_sucursal.Text))
                    {

                        txt_nombre_sucursal.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        txt_nombre_sucursal.BackColor = Color.Transparent;
                        if (string.IsNullOrEmpty(txt_telefono_sucursal.Text))
                        {

                            txt_telefono_sucursal.BackColor = Color.IndianRed;
                        }
                        else
                        {
                            txt_telefono_sucursal.BackColor = Color.Transparent;
                            if (string.IsNullOrEmpty(txt_email_sucursal.Text))
                            {

                                txt_email_sucursal.BackColor = Color.IndianRed;
                            }
                            else
                            {
                                txt_email_sucursal.BackColor = Color.Transparent;
                                if (string.IsNullOrEmpty(txt_callenum_sucursal.Text))
                                {

                                    txt_callenum_sucursal.BackColor = Color.IndianRed;
                                }
                                else
                                {
                                    txt_callenum_sucursal.BackColor = Color.Transparent;
                                    if (string.IsNullOrEmpty(txt_cp_sucursal.Text))
                                    {

                                        txt_cp_sucursal.BackColor = Color.IndianRed;
                                    }
                                    else
                                    {
                                        txt_cp_sucursal.BackColor = Color.Transparent;
                                        if (ddl_colonia_sucursal.SelectedValue == "0")
                                        {
                                            ddl_colonia_sucursal.BackColor = Color.IndianRed;
                                        }
                                        else
                                        {
                                            ddl_colonia_sucursal.BackColor = Color.White;

                                            foreach (GridViewRow row in gv_administrador.Rows)
                                            {
                                                if (row.RowType == DataControlRowType.DataRow)
                                                {
                                                    CheckBox chkRow = (row.Cells[1].FindControl("chk_administrador") as CheckBox);
                                                    if (chkRow.Checked)
                                                    {
                                                        guardar_sucursal();
                                                    }
                                                    else
                                                    {
                                                        lblModalTitle.Text = "Intelimundo";
                                                        lblModalBody.Text = "Favor de seleccionar un Administrador";
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
        }
        private void guardar_sucursal()
        {
            Guid guid_nns = Guid.NewGuid();
            int int_licencia = int.Parse(ddl_licencias.SelectedValue);
            string str_nsucursal = txt_nombre_sucursal.Text.ToUpper();
            string str_telefono = txt_telefono_sucursal.Text;
            string str_email = txt_email_sucursal.Text;
            string str_callenum = txt_callenum_sucursal.Text.ToUpper();
            string str_cp = txt_cp_sucursal.Text;
            int int_idcolonia = int.Parse(ddl_colonia_sucursal.SelectedValue);

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
                                            calle = str_callenum,
                                            cp = str_cp,
                                            id_asenta_cpcons = int_idcolonia,
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
                                            calle = str_callenum,
                                            cp = str_cp,
                                            id_asenta_cpcons = int_idcolonia,
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
                                items_user.calle = str_callenum;
                                items_user.cp = str_cp;
                                items_user.id_asenta_cpcons = int_idcolonia;

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
            txt_nombre_sucursal.Text = "";
            txt_telefono_sucursal.Text = "";
            txt_email_sucursal.Text = "";
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
                var inf_user = (from i_u in data_user.inf_fiscal
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
                var inf_user = (from i_u in data_user.inf_fiscal
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
                    var inf_user = (from i_u in data_user.inf_fiscal
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
                            var items_user = (from c in data_user.inf_fiscal
                                              where c.rfc == codeuser
                                              select c).FirstOrDefault();

                            guid_idproveedor = items_user.id_fiscal;
                        }

                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var inf_user = (from i_u in data_user.inf_fiscal
                                            where i_u.id_fiscal == guid_idproveedor
                                            select new
                                            {
                                                i_u.id_tipo_rfc,
                                                i_u.rfc,
                                                i_u.razon_social,
                                                i_u.telefono,
                                                i_u.email,
                                                i_u.calle,
                                                i_u.cp,
                                                i_u.id_asenta_cpcons,


                                            }).FirstOrDefault();



                            ddl_tipo_rfc_proveedor.Text = inf_user.id_tipo_rfc.ToString();
                            txt_rfc_proveedor.Text = inf_user.rfc;
                            txt_empresa_proveedor.Text = inf_user.razon_social;
                            txt_telefono_proveedor.Text = inf_user.telefono;
                            txt_email_proveedor.Text = inf_user.email;
                            txt_callenum_proveedor.Text = inf_user.calle;

                            int int_fcolonia = int.Parse(inf_user.id_asenta_cpcons.ToString());
                            string str_fcp = txt_cp_proveedor.Text = inf_user.cp;

                            using (db_imEntities db_sepomex = new db_imEntities())
                            {
                                var tbl_sepomex = (from c in db_sepomex.inf_sepomex
                                                   where c.id_asenta_cpcons == int_fcolonia
                                                   where c.d_codigo == str_fcp
                                                   select c).ToList();

                                ddl_colonia_proveedor.DataSource = tbl_sepomex;
                                ddl_colonia_proveedor.DataTextField = "d_asenta";
                                ddl_colonia_proveedor.DataValueField = "id_asenta_cpcons";
                                ddl_colonia_proveedor.DataBind();

                                txt_municipio_proveedor.Text = tbl_sepomex[0].D_mnpio;
                                txt_estado_proveedor.Text = tbl_sepomex[0].d_estado;
                            }

                        }

                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var inf_user = (from i_u in data_user.inf_contacto_fiscal
                                            where i_u.id_fiscal == guid_idproveedor
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

            Guid guid_ncproveedor = Guid.NewGuid();
            string str_nombres = txt_nombres_cproveedor.Text.ToUpper();
            string str_apaterno = txt_apaterno_cproveedor.Text.ToUpper();
            string str_amaterno = txt_amaterno_cproveedor.Text.ToUpper();
            string str_telefonoc = txt_telefono_cproveedor.Text;
            string str_emailc = txt_email_cproveedor.Text;

            if (int_accion_proveedor == 1)
            {
                using (var m_usuario = new db_imEntities())
                {
                    var i_usuario = new inf_fiscal
                    {
                        id_fiscal = guid_nrs,
                        id_estatus = 1,
                        id_tipo_rfc = int_tiporfc,
                        rfc = str_rfc,
                        razon_social = str_rs,
                        telefono = str_telefono,
                        email = str_email,
                        calle = str_callenum,
                        cp = str_cp,
                        id_asenta_cpcons = int_idcolonia,
                        fecha_registro = DateTime.Now,

                    };
                    m_usuario.inf_fiscal.Add(i_usuario);
                    m_usuario.SaveChanges();
                }

                using (var m_usuario = new db_imEntities())
                {
                    var i_usuario = new inf_contacto_fiscal
                    {
                        id_contacto_fiscal = guid_ncproveedor,
                        nombres = str_nombres,
                        a_paterno = str_apaterno,
                        a_materno = str_amaterno,
                        telefono = str_telefonoc,
                        email = str_emailc,
                        id_estatus = 1,

                        fecha_registro = DateTime.Now,
                        id_fiscal = guid_nrs,

                    };
                    m_usuario.inf_contacto_fiscal.Add(i_usuario);
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
                                var items_user = (from c in data_user.inf_fiscal
                                                  where c.rfc == codeuser
                                                  select c).FirstOrDefault();

                                guid_idproveedor = items_user.id_fiscal;
                            }

                            using (var data_user = new db_imEntities())
                            {
                                var items_user = (from c in data_user.inf_fiscal
                                                  where c.id_fiscal == guid_idproveedor
                                                  select c).FirstOrDefault();


                                items_user.id_tipo_rfc = int_tiporfc;
                                items_user.rfc = str_rfc;
                                items_user.razon_social = str_rs;
                                items_user.telefono = str_telefono;
                                items_user.email = str_email;
                                items_user.calle = str_callenum;
                                items_user.cp = str_cp;
                                items_user.id_asenta_cpcons = int_idcolonia;

                                data_user.SaveChanges();
                            }

                            using (var data_user = new db_imEntities())
                            {
                                var items_user = (from c in data_user.inf_contacto_fiscal
                                                  where c.id_fiscal == guid_idproveedor
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
                                var items_user = (from c in data_user.inf_fiscal
                                                  where c.rfc == codeuser
                                                  select c).FirstOrDefault();

                                guid_idproveedor = items_user.id_fiscal;
                            }

                            using (var data_user = new db_imEntities())
                            {
                                var items_user = (from c in data_user.inf_fiscal
                                                  where c.id_fiscal == guid_idproveedor
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
            i_agrega_alumno.Attributes["style"] = "color:orangered";
            i_edita_alumno.Attributes["style"] = "color:dimgray";
            i_baja_alumno.Attributes["style"] = "color:dimgray";
            limpia_txt_alumno();

            gv_alumnos.Visible = false;
            txt_buscar_alumno.Visible = false;
            btn_buscar_alumno.Visible = false;
        }
        protected void lkbtn_edita_alumno_Click(object sender, EventArgs e)
        {
            int_accion_alumno = 2;
            i_agrega_alumno.Attributes["style"] = "color:dimgray";
            i_edita_alumno.Attributes["style"] = "color:orangered";
            i_baja_alumno.Attributes["style"] = "color:dimgray";
            limpia_txt_alumno();

            txt_buscar_alumno.Visible = true;
            btn_buscar_alumno.Visible = true;

            using (db_imEntities m_user = new db_imEntities())
            {
                var i_user = (from i_u in m_user.inf_alumnos
                              join i_e in m_user.fact_estatus on i_u.id_estatus equals i_e.id_estatus
                              where i_u.id_alumno != guid_fuser
                              where i_u.id_estatus == 1

                              select new
                              {
                                  i_u.codigo_alumno,
                                  i_e.desc_estatus,
                                  i_u.nombres,
                                  i_u.a_paterno,
                                  i_u.a_materno,
                                  i_u.fecha_registro

                              }).ToList();

                gv_alumnos.DataSource = i_user;
                gv_alumnos.DataBind();
                gv_alumnos.Visible = true;
            }
        }
        protected void lkbtn_baja_alumno_Click(object sender, EventArgs e)
        {
            int_accion_alumno = 3;
            i_agrega_alumno.Attributes["style"] = "color:dimgray";
            i_edita_alumno.Attributes["style"] = "color:dimgray";
            i_baja_alumno.Attributes["style"] = "color:orangered";
            limpia_txt_alumno();

            txt_buscar_alumno.Visible = true;
            btn_buscar_alumno.Visible = true;

            using (db_imEntities m_user = new db_imEntities())
            {
                var i_user = (from i_u in m_user.inf_alumnos
                              join i_e in m_user.fact_estatus on i_u.id_estatus equals i_e.id_estatus
                              where i_u.id_alumno != guid_fuser
                              where i_u.id_estatus == 1

                              select new
                              {
                                  i_u.codigo_alumno,
                                  i_e.desc_estatus,
                                  i_u.nombres,
                                  i_u.a_paterno,
                                  i_u.a_materno,
                                  i_u.fecha_registro

                              }).ToList();

                gv_alumnos.DataSource = i_user;
                gv_alumnos.DataBind();
                gv_alumnos.Visible = true;
            }
        }

        private void limpia_txt_alumno()
        {
            using (db_imEntities m_tiporfc = new db_imEntities())
            {
                var i_tiporfc = (from f_tr in m_tiporfc.fact_genero
                                 select f_tr).ToList();

                ddl_genero_alumno.DataSource = i_tiporfc;
                ddl_genero_alumno.DataTextField = "desc_genero";
                ddl_genero_alumno.DataValueField = "id_genero";
                ddl_genero_alumno.DataBind();
            }
            ddl_genero_alumno.Items.Insert(0, new ListItem("*Género", "0"));

            txt_nombres_alumno.Text = "";
            txt_apaterno_alumno.Text = "";
            txt_amaterno_alumno.Text = "";
            txt_cumple_alumno.Text = "";
            txt_email_alumno.Text = "";
            txt_usuario_alumno.Text = "";
            txt_clave_alumno.Text = "";

            ddl_genero_alumno.BackColor = Color.White;
            txt_nombres_alumno.BackColor = Color.White;
            txt_apaterno_alumno.BackColor = Color.White;
            txt_amaterno_alumno.BackColor = Color.White;
            txt_cumple_alumno.BackColor = Color.White;
            txt_email_alumno.BackColor = Color.White;
            txt_usuario_alumno.BackColor = Color.White;
            txt_clave_alumno.BackColor = Color.White;
        }

        protected void btn_buscar_alumno_Click(object sender, EventArgs e)
        {

        }
        protected void gv_alumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void chk_alumno_CheckedChanged(object sender, EventArgs e)
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

                            guid_idalumno = items_user.id_alumno;
                        }

                        using (db_imEntities data_user = new db_imEntities())
                        {
                            var inf_user = (from i_u in data_user.inf_alumnos
                                            where i_u.id_alumno == guid_idalumno
                                            select new
                                            {
                                                i_u.id_genero,
                                                i_u.fecha_nacimiento,
                                                i_u.nombres,
                                                i_u.a_paterno,
                                                i_u.a_materno,
                                                i_u.email,
                                                i_u.codigo_alumno,
                                                i_u.clave

                                            }).FirstOrDefault();

                            ddl_genero_alumno.SelectedValue = inf_user.id_genero.ToString();
                            txt_nombres_alumno.Text = inf_user.nombres;
                            txt_apaterno_alumno.Text = inf_user.a_paterno;
                            txt_amaterno_alumno.Text = inf_user.a_materno;
                            DateTime str_birthday = new DateTime();
                            str_birthday = Convert.ToDateTime(inf_user.fecha_nacimiento);
                            txt_cumple_alumno.Text = str_birthday.ToShortDateString();
                            txt_email_alumno.Text = inf_user.email;
                            txt_usuario_alumno.Text = inf_user.codigo_alumno;
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

        protected void btn_usuario_alumno_Click(object sender, EventArgs e)
        {
            if (ddl_genero_alumno.SelectedValue == "0")
            {

                ddl_genero_alumno.BackColor = Color.IndianRed;
            }
            else
            {
                ddl_genero_alumno.BackColor = Color.Transparent;
                if (string.IsNullOrEmpty(txt_cumple_alumno.Text))
                {

                    txt_cumple_alumno.BackColor = Color.IndianRed;
                }
                else
                {
                    txt_cumple_alumno.BackColor = Color.Transparent;
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
        }

        private void genera_alumno()
        {
            try
            {
                int nombres_count = txt_nombres_usuario.Text.Split(' ').Count();
                string str_nombres = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_nombres_alumno.Text.ToLower()));
                string[] separados;

                separados = str_nombres.Split(" ".ToArray());
                int count = separados.Count();

                string str_apaterno = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_apaterno_alumno.Text.ToLower()));
                string str_amaterno = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_amaterno_alumno.Text.ToLower()));

                string codigo_usuario = str_nombres + "_" + left_right_mid.left(str_apaterno, 2) + left_right_mid.left(str_amaterno, 2);
                txt_usuario_alumno.Text = codigo_usuario;
            }
            catch
            {
                lblModalTitle.Text = "Intelimundo";
                lblModalBody.Text = "Se requiere minimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el usuario";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
        }

        protected void btn_guardar_alumno_Click(object sender, EventArgs e)
        {

            if (ddl_genero_alumno.SelectedValue == "0")
            {

                ddl_genero_alumno.BackColor = Color.IndianRed;
            }
            else
            {
                ddl_genero_alumno.BackColor = Color.Transparent;
                if (string.IsNullOrEmpty(txt_cumple_alumno.Text))
                {

                    txt_cumple_alumno.BackColor = Color.IndianRed;
                }
                else
                {
                    txt_cumple_alumno.BackColor = Color.Transparent;
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
                                if (string.IsNullOrEmpty(txt_usuario_alumno.Text))
                                {

                                    txt_usuario_alumno.BackColor = Color.IndianRed;
                                }
                                else
                                {
                                    txt_usuario_alumno.BackColor = Color.Transparent;

                                    if (string.IsNullOrEmpty(txt_clave_alumno.Text))
                                    {

                                        txt_clave_alumno.BackColor = Color.IndianRed;
                                    }
                                    else
                                    {
                                        txt_clave_alumno.BackColor = Color.Transparent;

                                        guardar_alumno();


                                    }

                                }
                            }
                        }
                    }
                }
            }

        }
        private void guardar_alumno()
        {
            Guid guid_nusuario = Guid.NewGuid();
            int int_genero = int.Parse(ddl_genero_alumno.SelectedValue);
            string str_nombres = txt_nombres_alumno.Text.ToUpper();
            string str_apaterno = txt_apaterno_alumno.Text.ToUpper();
            string str_amaterno = txt_amaterno_alumno.Text.ToUpper();
            DateTime date_cumple = DateTime.Parse(txt_cumple_alumno.Text);
            string str_email = txt_email_alumno.Text;
            string str_usuario = txt_usuario_alumno.Text;
            string str_password = mdl_encrypta.Encrypt(txt_clave_alumno.Text);

            if (int_accion_alumno == 1)
            {
                using (db_imEntities data_user = new db_imEntities())
                {
                    var items_user = (from c in data_user.inf_alumnos
                                      where c.codigo_alumno == str_usuario
                                      select c).ToList();

                    if (items_user.Count == 0)
                    {

                        using (var m_usuario = new db_imEntities())
                        {
                            var i_usuario = new inf_alumnos
                            {
                                id_alumno = guid_nusuario,
                                id_estatus = 1,
                                id_genero = int_genero,
                                id_tipo_usuario = 9,
                                nombres = str_nombres,
                                a_paterno = str_apaterno,
                                a_materno = str_amaterno,
                                fecha_nacimiento = date_cumple,
                                email = str_email,
                                codigo_alumno = str_usuario,
                                clave = str_password,
                                fecha_registro = DateTime.Now,
                                id_centro = guid_centro
                            };
                            m_usuario.inf_alumnos.Add(i_usuario);
                            m_usuario.SaveChanges();
                        }

                        using (var m_usuario = new db_imEntities())
                        {
                            var i_usuario = new inf_centro_dep
                            {
                                id_usuario = guid_nusuario,
                                id_centro = guid_centro
                            };
                            m_usuario.inf_centro_dep.Add(i_usuario);
                            m_usuario.SaveChanges();
                        }

                        limpia_txt_alumno();

                        lblModalTitle.Text = "Intelimundo";
                        lblModalBody.Text = "Datos de Alumno agregados con éxito";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                        upModal.Update();
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
                if (string.IsNullOrEmpty(txt_usuario_alumno.Text))
                {

                    txt_usuario_alumno.BackColor = Color.IndianRed;
                }
                else
                {
                    txt_usuario_alumno.BackColor = Color.Transparent;
                    if (string.IsNullOrEmpty(txt_clave_alumno.Text))
                    {

                        txt_clave_alumno.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        txt_clave_alumno.BackColor = Color.Transparent;
                        foreach (GridViewRow row in gv_alumnos.Rows)
                        {
                            if (row.RowType == DataControlRowType.DataRow)
                            {
                                CheckBox chkRow = (row.Cells[1].FindControl("chk_alumno") as CheckBox);
                                if (chkRow.Checked)
                                {
                                    string codeuser = row.Cells[1].Text;

                                    using (db_imEntities data_user = new db_imEntities())
                                    {
                                        var items_user = (from c in data_user.inf_alumnos
                                                          where c.codigo_alumno == codeuser
                                                          select c).FirstOrDefault();

                                        guid_idalumno = items_user.id_alumno;
                                    }

                                    using (var data_user = new db_imEntities())
                                    {
                                        var items_user = (from c in data_user.inf_alumnos
                                                          where c.id_alumno == guid_idalumno
                                                          select c).FirstOrDefault();


                                        items_user.id_genero = int_genero;
                                        items_user.id_tipo_usuario = 8;
                                        items_user.nombres = str_nombres;
                                        items_user.a_paterno = str_apaterno;
                                        items_user.a_materno = str_amaterno;
                                        items_user.fecha_nacimiento = date_cumple;
                                        items_user.email = str_email;
                                        items_user.id_codigo_alumno = str_usuario;
                                        items_user.clave = str_password;

                                        data_user.SaveChanges();
                                    }

                                    limpia_txt_alumno();

                                    gv_alumnos.Visible = false;
                                    txt_buscar_alumno.Visible = false;
                                    btn_buscar_alumno.Visible = false;

                                    lblModalTitle.Text = "Intelimundo";
                                    lblModalBody.Text = "Datos de alumno dados de baja con éxito";
                                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                                    upModal.Update();
                                }
                            }
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
                        CheckBox chkRow = (row.Cells[1].FindControl("chk_alumno") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string codeuser = row.Cells[1].Text;

                            using (db_imEntities data_user = new db_imEntities())
                            {
                                var items_user = (from c in data_user.inf_alumnos
                                                  where c.codigo_alumno == codeuser
                                                  select c).FirstOrDefault();

                                guid_idalumno = items_user.id_alumno;
                            }

                            using (var data_user = new db_imEntities())
                            {
                                var items_user = (from c in data_user.inf_alumnos
                                                  where c.id_alumno == guid_idalumno
                                                  select c).FirstOrDefault();


                                items_user.id_estatus = 3;

                                data_user.SaveChanges();
                            }

                            limpia_txt_alumno();

                            gv_alumnos.Visible = false;
                            txt_buscar_alumno.Visible = false;
                            btn_buscar_alumno.Visible = false;

                            lblModalTitle.Text = "Intelimundo";
                            lblModalBody.Text = "Datos de alumno actualizados con éxito";
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                            upModal.Update();
                        }
                    }
                }
            }
        }
        #endregion

        #region usuarios

        public int id_flist_user()

        {
            if (chkb_administrador.Checked)
            {
                return 3;
            }
            else if (chkb_gerente.Checked)
            {
                return 4;
            }
            else if (chkb_facilitador.Checked)
            {
                return 5;
            }
            else if (chkb_ejecutivo.Checked)
            {
                return 6;
            }
            else if (chkb_vendedor.Checked)
            {
                return 7;
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
            ddl_genero_usuario.Items.Insert(0, new ListItem("*Género", "0"));

            txt_nombres_usuario.Text = "";
            txt_apaterno_usuario.Text = "";
            txt_amaterno_usuario.Text = "";
            txt_cumple_usuario.Text = "";
            txt_usuario_usuario.Text = "";
            txt_clave_usuario.Text = "";

            ddl_genero_usuario.BackColor = Color.Transparent;
            txt_nombres_usuario.BackColor = Color.Transparent;
            txt_apaterno_usuario.BackColor = Color.Transparent;
            txt_apaterno_usuario.BackColor = Color.Transparent;
            txt_cumple_usuario.BackColor = Color.Transparent;
            txt_usuario_usuario.BackColor = Color.Transparent;
            txt_clave_usuario.BackColor = Color.Transparent;
        }


        protected void gv_usuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void chkb_administrador_CheckedChanged(object sender, EventArgs e)
        {
            if (chkb_administrador.Checked == true)
            {

                int_tipousuario = 3;

                chkb_gerente.Checked = false;
                chkb_facilitador.Checked = false;
                chkb_ejecutivo.Checked = false;
                chkb_contador.Checked = false;
                chkb_vendedor.Checked = false;
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

                int_tipousuario = 4;

                chkb_administrador.Checked = false;
                chkb_facilitador.Checked = false;
                chkb_ejecutivo.Checked = false;
                chkb_contador.Checked = false;
                chkb_vendedor.Checked = false;
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

                int_tipousuario = 5;

                chkb_gerente.Checked = false;
                chkb_administrador.Checked = false;
                chkb_ejecutivo.Checked = false;
                chkb_contador.Checked = false;
                chkb_vendedor.Checked = false;
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

                int_tipousuario = 6;

                chkb_gerente.Checked = false;
                chkb_facilitador.Checked = false;
                chkb_administrador.Checked = false;
                chkb_contador.Checked = false;
                chkb_vendedor.Checked = false;
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

                int_tipousuario = 8;

                chkb_gerente.Checked = false;
                chkb_facilitador.Checked = false;
                chkb_ejecutivo.Checked = false;
                chkb_administrador.Checked = false;
                chkb_vendedor.Checked = false;
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

                int_tipousuario = 7;

                chkb_gerente.Checked = false;
                chkb_facilitador.Checked = false;
                chkb_ejecutivo.Checked = false;
                chkb_contador.Checked = false;
                chkb_administrador.Checked = false;
            }
            else
            {
                limpia_txt_usuarios();
            }

        }
        protected void btn_guardar_usuario_Click(object sender, EventArgs e)
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
                                if (string.IsNullOrEmpty(txt_cumple_usuario.Text))
                                {

                                    txt_cumple_usuario.BackColor = Color.IndianRed;
                                }
                                else
                                {
                                    txt_cumple_usuario.BackColor = Color.Transparent;
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
                                        u.fecha_nacimiento,
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
        private void guarda_registro_usuario()
        {
            Guid guid_fusuario;
            Guid guid_nusuario = Guid.NewGuid();
            int int_genero = int.Parse(ddl_genero_usuario.SelectedValue);
            string str_nombres = txt_nombres_usuario.Text.ToUpper();
            string str_apaterno = txt_apaterno_usuario.Text.ToUpper();
            string str_amaterno = txt_amaterno_usuario.Text.ToUpper();
            DateTime date_cumple = DateTime.Parse(txt_cumple_usuario.Text);
            string str_usuario = txt_usuario_usuario.Text;
            string str_password = mdl_encrypta.Encrypt(txt_clave_usuario.Text);

            if (int_accion_usuario == 1)
            {
                using (db_imEntities data_user = new db_imEntities())
                {
                    var items_user = (from c in data_user.inf_usuarios
                                      where c.codigo_usuario == str_usuario
                                      where c.id_tipo_usuario == int_tipousuario
                                      select c).ToList();

                    if (items_user.Count == 0)
                    {

                        using (var m_usuario = new db_imEntities())
                        {
                            var i_usuario = new inf_usuarios
                            {
                                id_usuario = guid_nusuario,
                                id_codigo_usuario = str_idcodigousuario + string.Format("{0:000}", items_user.Count + 1),
                                id_estatus = 1,
                                id_genero = int_genero,
                                id_tipo_usuario = int_tipousuario,
                                nombres = str_nombres,
                                a_paterno = str_apaterno,
                                a_materno = str_amaterno,
                                codigo_usuario = str_usuario,
                                clave = str_password,
                                fecha_nacimiento = date_cumple,
                                fecha_registro = DateTime.Now,
                                id_centro = guid_centro
                            };
                            m_usuario.inf_usuarios.Add(i_usuario);
                            m_usuario.SaveChanges();
                        }

                        using (var m_usuario = new db_imEntities())
                        {
                            var i_usuario = new inf_centro_dep
                            {
                                id_usuario = guid_nusuario,
                                id_centro = guid_centro
                            };
                            m_usuario.inf_centro_dep.Add(i_usuario);
                            m_usuario.SaveChanges();
                        }

                        limpia_txt_usuarios();

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
                                items_user.id_genero = int_genero;
                                items_user.nombres = str_nombres;
                                items_user.a_paterno = str_apaterno;
                                items_user.a_materno = str_amaterno;
                                items_user.codigo_usuario = str_usuario;
                                items_user.clave = str_password;
                                items_user.fecha_nacimiento = date_cumple;
                                data_user.SaveChanges();
                            }

                            limpia_txt_usuarios();

                            grid_usuarios(int_tipousuario);

                            txt_buscar_usuario.Text = "";
                            btn_busca_usuario.Text = "";

                            lblModalTitle.Text = "Intelimundo";
                            lblModalBody.Text = "Datos de usuario actualizados con éxito";
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

                            limpia_txt_usuarios();

                            grid_usuarios(int_tipousuario);

                            txt_buscar_usuario.Text = "";
                            btn_busca_usuario.Text = "";

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
                                if (string.IsNullOrEmpty(txt_cumple_usuario.Text))
                                {

                                    txt_cumple_usuario.BackColor = Color.IndianRed;
                                }
                                else
                                {
                                    txt_cumple_usuario.BackColor = Color.Transparent;
                                    genera_usuario();
                                }
                            }
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
                                                u.id_genero,
                                                u.nombres,
                                                u.a_paterno,
                                                u.a_materno,
                                                u.fecha_nacimiento,
                                                u.codigo_usuario,
                                                u.clave

                                            }).FirstOrDefault();


                            ddl_genero_usuario.SelectedValue = inf_user.id_genero.ToString();
                            txt_nombres_usuario.Text = inf_user.nombres;
                            txt_apaterno_usuario.Text = inf_user.a_paterno;
                            txt_amaterno_usuario.Text = inf_user.a_materno;
                            DateTime str_birthday = new DateTime();
                            str_birthday = Convert.ToDateTime(inf_user.fecha_nacimiento);
                            txt_cumple_usuario.Text = str_birthday.ToShortDateString();
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

       

        protected void lkbtn_nuevo_usuario_Click(object sender, EventArgs e)
        {
            int_accion_usuario = 1;
            i_agrega_usuario.Attributes["style"] = "color:orangered";
            i_edita_usuario.Attributes["style"] = "color:dimgray";
            i_baja_usuario.Attributes["style"] = "color:dimgray";
            limpia_txt_usuarios();

            gv_usuarios.Visible = false;
            txt_buscar_usuario.Visible = false;
            btn_busca_usuario.Visible = false;
        }



        protected void lkbtn_edita_usuario_Click(object sender, EventArgs e)
        {
            int_accion_usuario = 2;
            i_agrega_usuario.Attributes["style"] = "color:dimgray";
            i_edita_usuario.Attributes["style"] = "color:orangered";
            i_baja_usuario.Attributes["style"] = "color:dimgray";
            limpia_txt_usuarios();

            txt_buscar_usuario.Visible = true;
            btn_busca_usuario.Visible = true;

            if (id_flist_user() == 0)
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



        protected void lkbtn_baja_usuario_Click(object sender, EventArgs e)
        {
            int_accion_usuario = 3;
            i_agrega_usuario.Attributes["style"] = "color:dimgray";
            i_edita_usuario.Attributes["style"] = "color:dimgray";
            i_baja_usuario.Attributes["style"] = "color:orangered";
            limpia_txt_usuarios();

            txt_buscar_usuario.Visible = true;
            btn_busca_usuario.Visible = true;

            if (id_flist_user() == 0)
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


        private void grid_usuarios(int idtipousuario)
        {
            using (db_imEntities data_user = new db_imEntities())
            {
                var inf_user = (from i_u in data_user.inf_usuarios
                                join i_e in data_user.fact_estatus on i_u.id_estatus equals i_e.id_estatus
                                where i_u.id_tipo_usuario == idtipousuario
                                where i_u.id_usuario != guid_fuser
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

                gv_usuarios.DataSource = inf_user;
                gv_usuarios.DataBind();
                gv_usuarios.Visible = true;
            }
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
                                              i_c.calle,
                                              i_c.cp,
                                              i_c.id_asenta_cpcons,
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
                        txt_callenum_empresa.Text = i_empresaf.calle;
                        txt_cp_empresa.Text = i_empresaf.cp.ToString();

                        int_fcolonia = int.Parse(i_empresaf.id_asenta_cpcons.ToString());
                        str_fcp = i_empresaf.cp.ToString();
                    }
                    using (db_imEntities db_sepomex = new db_imEntities())
                    {
                        var tbl_sepomex = (from c in db_sepomex.inf_sepomex
                                           where c.id_asenta_cpcons == int_fcolonia
                                           where c.d_codigo == str_fcp
                                           select c).ToList();

                        ddl_colonia_empresa.DataSource = tbl_sepomex;
                        ddl_colonia_empresa.DataTextField = "d_asenta";
                        ddl_colonia_empresa.DataValueField = "id_asenta_cpcons";
                        ddl_colonia_empresa.DataBind();

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
                                                            calle = str_callenum,
                                                            cp = str_cp,
                                                            id_asenta_cpcons = int_colonia,
                                                            fecha_registro = DateTime.Now
                                                        };
                                                        m_usuario.inf_empresa.Add(i_usuario);
                                                        m_usuario.SaveChanges();
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
                                                        i_fempresa.calle = str_callenum;
                                                        i_fempresa.cp = str_cp;
                                                        i_fempresa.id_asenta_cpcons = int_colonia;

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