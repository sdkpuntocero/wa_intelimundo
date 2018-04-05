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
    public partial class registro_inicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                    load_ddl();

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

        private void load_ddl()
        {

            using (db_imEntities edm_licencia = new db_imEntities())
            {
                var i_licencia = (from f_tr in edm_licencia.fact_licencias
                                  select f_tr).ToList();

                ddl_licencias.DataSource = i_licencia;
                ddl_licencias.DataTextField = "desc_licencia";
                ddl_licencias.DataValueField = "id_licencia";
                ddl_licencias.DataBind();
            }

            using (db_imEntities edm_genero = new db_imEntities())
            {
                var i_genero = (from f_tr in edm_genero.fact_genero
                                select f_tr).ToList();

                ddl_genero.DataSource = i_genero;
                ddl_genero.DataTextField = "desc_genero";
                ddl_genero.DataValueField = "id_genero";
                ddl_genero.DataBind();
            }

            ddl_licencias.Items.Insert(0, new ListItem("*Licencia", "0"));
            ddl_colonia_sucursal.Items.Insert(0, new ListItem("*Colonia", "0"));
            ddl_genero.Items.Insert(0, new ListItem("*Género", "0"));
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {

            if (ddl_licencias.SelectedValue == "0")
            {

                ddl_licencias.BackColor = Color.IndianRed;
            }
            else
            {
                ddl_licencias.BackColor = Color.Transparent;
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
                                        ddl_colonia_sucursal.BackColor = Color.Transparent;
                                        if (ddl_genero.SelectedValue == "0")
                                        {

                                            ddl_genero.BackColor = Color.IndianRed;
                                        }
                                        else
                                        {
                                            ddl_genero.BackColor = Color.Transparent;
                                            if (string.IsNullOrEmpty(txt_nombres.Text))
                                            {

                                                txt_nombres.BackColor = Color.IndianRed;
                                            }
                                            else
                                            {
                                                txt_nombres.BackColor = Color.Transparent;
                                                if (string.IsNullOrEmpty(txt_apaterno.Text))
                                                {

                                                    txt_apaterno.BackColor = Color.IndianRed;
                                                }
                                                else
                                                {
                                                    txt_apaterno.BackColor = Color.Transparent;
                                                    if (string.IsNullOrEmpty(txt_amaterno.Text))
                                                    {

                                                        txt_amaterno.BackColor = Color.IndianRed;
                                                    }
                                                    else
                                                    {
                                                        txt_amaterno.BackColor = Color.Transparent;
                                                        if (string.IsNullOrEmpty(txt_cumple.Text))
                                                        {

                                                            txt_cumple.BackColor = Color.IndianRed;
                                                        }
                                                        else
                                                        {
                                                            txt_cumple.BackColor = Color.Transparent;
                                                            if (string.IsNullOrEmpty(txt_usuario_usuario.Text))
                                                            {

                                                                txt_usuario_usuario.BackColor = Color.IndianRed;
                                                            }
                                                            else
                                                            {
                                                                txt_usuario_usuario.BackColor = Color.Transparent;
                                                                if (string.IsNullOrEmpty(txt_clave.Text))
                                                                {

                                                                    txt_clave.BackColor = Color.IndianRed;
                                                                }
                                                                else
                                                                {
                                                                    txt_clave.BackColor = Color.Transparent;

                                                                    guarda_registro();
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

        private void guarda_registro()
        {

            Guid guid_ncentro = Guid.NewGuid();
            string str_corporativo = txt_nombre_sucursal.Text.ToUpper();

            string str_telefono = txt_telefono_sucursal.Text;
            string str_email = txt_email_sucursal.Text;
            string str_callenum = txt_callenum_sucursal.Text.ToUpper();
            string str_cp = txt_cp_sucursal.Text;
            int int_colony = Convert.ToInt32(ddl_colonia_sucursal.SelectedValue);

            Guid guid_nusuario = Guid.NewGuid();
            int int_genero = int.Parse(ddl_genero.SelectedValue);
            string str_nombres = txt_nombres.Text.ToUpper();
            string str_apaterno = txt_apaterno.Text.ToUpper();
            string str_amaterno = txt_amaterno.Text.ToUpper();
            DateTime date_cumple = DateTime.Parse(txt_cumple.Text);
            string str_usuairo = txt_usuario_usuario.Text;
            string str_password = mdl_encrypta.Encrypt(txt_clave.Text);

            using (var m_empresa = new db_imEntities())
            {
                var i_empresa = new inf_centro

                {
                    id_centro = guid_ncentro,
                    id_licencia = 4,
                    id_tipo_centro = 1,
                    id_codigo_centro = "intm_corp",
                    id_estatus = 1,
                    nombre = str_corporativo,
                    telefono = str_telefono,
                    email = str_email,
                    calle = str_callenum,
                    cp = str_cp,
                    id_asenta_cpcons = int_colony,
                    fecha_registro = DateTime.Now,
                    dia_corte = 0,
                };

                m_empresa.inf_centro.Add(i_empresa);
                m_empresa.SaveChanges();
            }

            using (var m_usuario = new db_imEntities())
            {
                var i_usuario = new inf_usuarios
                {
                    id_usuario = guid_nusuario,
                    id_codigo_usuario = "intm_dir" + string.Format("{0:000}", 1),
                    id_estatus = 1,
                    id_genero = int_genero,
                    id_tipo_usuario = 2,
                    nombres = str_nombres,
                    a_paterno = str_apaterno,
                    a_materno = str_amaterno,
                    codigo_usuario = str_usuairo,
                    clave = str_password,
                    fecha_nacimiento = date_cumple,
                    fecha_registro = DateTime.Now,
                    id_centro = guid_ncentro
                };
                m_usuario.inf_usuarios.Add(i_usuario);
                m_usuario.SaveChanges();
            }

            using (var m_usuario = new db_imEntities())
            {
                var i_usuario = new inf_centro_dep
                {
                    id_usuario = guid_nusuario,
                    id_centro = guid_ncentro,
                };
                m_usuario.inf_centro_dep.Add(i_usuario);
                m_usuario.SaveChanges();
            }

            limpiar_textbox();

            lblModalTitle.Text = "Intelimundo";
            lblModalBody.Text = "Datos de Corporativo y Director agregados con éxito";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
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

                datos_sepomex(str_codigo);
            }
        }
        private void datos_sepomex(string str_codigo)
        {
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

                    txt_cp_sucursal.BackColor = Color.Transparent;
                    txt_municipio_sucursal.Text = tbl_sepomex[0].D_mnpio;
                    txt_estado_sucursal.Text = tbl_sepomex[0].d_estado;
                }
                if (tbl_sepomex.Count > 1)
                {
                    txt_cp_sucursal.BackColor = Color.Transparent;
                    ddl_colonia_sucursal.Items.Insert(0, new ListItem("*Colonia", "0"));

                    txt_municipio_sucursal.Text = tbl_sepomex[0].D_mnpio;
                    txt_estado_sucursal.Text = tbl_sepomex[0].d_estado;
                }
                else if (tbl_sepomex.Count == 0)
                {
                    txt_cp_sucursal.BackColor = Color.IndianRed;
                    ddl_colonia_sucursal.Items.Clear();
                    ddl_colonia_sucursal.Items.Insert(0, new ListItem("*Colonia", "0"));
                    txt_municipio_sucursal.Text = "";
                    txt_estado_sucursal.Text = "";

                }
            }
        }

        private void limpiar_textbox()
        {
            using (db_imEntities edm_licencia = new db_imEntities())
            {
                var i_licencia = (from f_tr in edm_licencia.fact_licencias
                                  select f_tr).ToList();

                ddl_licencias.DataSource = i_licencia;
                ddl_licencias.DataTextField = "desc_licencia";
                ddl_licencias.DataValueField = "id_licencia";
                ddl_licencias.DataBind();
            }

            using (db_imEntities edm_genero = new db_imEntities())
            {
                var i_genero = (from f_tr in edm_genero.fact_genero
                                select f_tr).ToList();

                ddl_genero.DataSource = i_genero;
                ddl_genero.DataTextField = "desc_genero";
                ddl_genero.DataValueField = "id_genero";
                ddl_genero.DataBind();
            }

            ddl_licencias.Items.Insert(0, new ListItem("*Licencia", "0"));
            ddl_colonia_sucursal.Items.Insert(0, new ListItem("*Colonia", "0"));
            ddl_genero.Items.Insert(0, new ListItem("*Género", "0"));
            txt_nombre_sucursal.Text = "";
            txt_telefono_sucursal.Text = "";
            txt_email_sucursal.Text = "";
            txt_callenum_sucursal.Text = "";
            txt_cp_sucursal.Text = "";

            txt_municipio_sucursal.Text = "";
            txt_estado_sucursal.Text = "";


            txt_nombres.Text = "";
            txt_apaterno.Text = "";
            txt_apaterno.Text = "";
            txt_cumple.Text = "";
            txt_usuario_usuario.Text = "";
            txt_clave.Text = "";
        }

        protected void btn_salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("ctrl_acceso.aspx");
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

        protected void btn_genera_usuario_Click(object sender, EventArgs e)
        {
            if (ddl_genero.SelectedValue == "0")
            {

                ddl_genero.BackColor = Color.IndianRed;
            }
            else
            {
                ddl_genero.BackColor = Color.Transparent;
                if (string.IsNullOrEmpty(txt_nombres.Text))
                {

                    txt_nombres.BackColor = Color.IndianRed;
                }
                else
                {
                    txt_nombres.BackColor = Color.Transparent;
                    if (string.IsNullOrEmpty(txt_apaterno.Text))
                    {

                        txt_apaterno.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        txt_apaterno.BackColor = Color.Transparent;
                        if (string.IsNullOrEmpty(txt_amaterno.Text))
                        {

                            txt_amaterno.BackColor = Color.IndianRed;
                        }
                        else
                        {
                            txt_amaterno.BackColor = Color.Transparent;
                            if (string.IsNullOrEmpty(txt_cumple.Text))
                            {

                                txt_cumple.BackColor = Color.IndianRed;
                            }
                            else
                            {
                                txt_cumple.BackColor = Color.Transparent;
                                genera_usuario();
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
                string str_nombres = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_nombres.Text.ToLower()));
                string[] separados;

                separados = str_nombres.Split(" ".ToCharArray());


                string str_apaterno = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_apaterno.Text.ToLower()));
                string str_amaterno = RemoveSpecialCharacters(RemoveAccentsWithRegEx(txt_amaterno.Text.ToLower()));

                string codigo_usuario = str_nombres + "_" + LeftRightMid.Left(str_apaterno, 2) + LeftRightMid.Left(str_amaterno, 2);
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
    }
}