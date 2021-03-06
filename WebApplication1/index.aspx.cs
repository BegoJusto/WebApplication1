﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EjemploWebForm
{
    public partial class index : System.Web.UI.Page
    {
        DataTable dt;
        // string cadenaConexion = ConfigurationManager.ConnectionStrings["GESTLIBRERIAConnectionString"].ConnectionString;
        //string cadenaConexion = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargaDatos();
        }

        private void cargaDatos()
        {
            try
            {
                string cadenaConexion = ConfigurationManager.ConnectionStrings["GESTLIBRERIAConnectionString"].ConnectionString;
                //string cadenaConexion = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                string SQL = "SELECT * FROM usuario WHERE borrado = 0";
                SqlConnection conn = new SqlConnection(cadenaConexion);
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter dAdapter = new SqlDataAdapter(SQL, conn);
                dAdapter.Fill(ds);
                dt = ds.Tables[0];

                grdv_Usuarios.DataSource = dt;
                grdv_Usuarios.DataBind();
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.Error.Write(ex.Message);
            }
        }

        protected void grdv_Usuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string comand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            string codigo = grdv_Usuarios.DataKeys[index].Value.ToString();

            switch (comand)
            {
                case "editUsuario":
                    {
                        lblIdUsuario.Text = codigo;
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script>");
                        sb.Append("$('#editModal').modal('show')");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarCreate", sb.ToString(), false);

                    }
                    break;

                case "deleteUsuario":
                    {
                        txtIdUsuario.Text = codigo;
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script>");
                        sb.Append("$('#deleteConfirm').modal('show')");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ConfirmarBorrado", sb.ToString(), false);
                    }
                    break;

            }
        }

        protected void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            string codigo = lblIdUsuario.Text;
            string nombre = txtNombreUsuario.Text;
            string apellidos = txtApellidos.Text;
            string mail = txtMail.Text;
            string fNacimiento = txtFNacimiento.Text;
            DateTime fNac;
            DateTime.TryParse(fNacimiento, out fNac);
            string password = txtpassword.Text;
            string userid = txtuserid.Text;


            string cadenaConexion = ConfigurationManager.ConnectionStrings["GESTLIBRERIAConnectionString"].ConnectionString;
            // string cadenaConexion = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            int cod;
            string SQL;
          
            if (Int32.TryParse(codigo, out cod) && cod > 0)
            {
               
                SQL = "UPDATE usuario SET nombre = '" + nombre + "', apellidos = '" + apellidos + "', mail = '" + mail + "', fNacimiento = '" + fNac + "', password = '" + password + "', userid = '" + userid + "' WHERE codUsuario ='" + codigo + "'";
            }
            else
            {
                
                SQL = "INSERT INTO usuario(nombre,apellidos, mail, fNacimiento, password, userid) VALUES('" + nombre + "','" + apellidos + "','" + mail + "','" + fNac + "','" + password + "','" + userid + "')";
            }

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();
                SqlCommand sqlcmm = new SqlCommand();
                sqlcmm.Connection = conn;
                sqlcmm.CommandText = SQL;
                sqlcmm.CommandType = CommandType.Text;
                // sqlcmm.CommandType = CommandType.StoredProcedure;
                sqlcmm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            cargaDatos();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script>");
            sb.Append("$('#editModal').modal('hide')");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OcultarCreate", sb.ToString(), false);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            string cadenaConexion = ConfigurationManager.ConnectionStrings["GESTLIBRERIAConnectionString"].ConnectionString;
            // string cadenaConexion = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            string codigo = txtIdUsuario.Text;
            //string SQL = "DELETE FROM usuario WHERE codUsuario=" + codigo;
            string SQL = "UPDATE usuario SET borrado = '1' WHERE codUsuario =" + codigo;

            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();
                SqlCommand sqlcmm = new SqlCommand();
                sqlcmm.Connection = conn;
                sqlcmm.CommandText = SQL;
                sqlcmm.CommandType = CommandType.Text;
                // sqlcmm.CommandType = CommandType.StoredProcedure;
                sqlcmm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            cargaDatos();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script>");
            sb.Append("$('#deleteConfirm').modal('hide')");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OcultarCreate", sb.ToString(), false);
        }

        protected void btncrearUsuario_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            lblIdUsuario.Text = "-1";
            txtNombreUsuario.Text = "";
            txtApellidos.Text = "";
            txtFNacimiento.Text = "";
            txtMail.Text = "";
            txtpassword.Text = "";
            txtuserid.Text = "";            
            sb.Append(@"<script>");
            sb.Append("$('#editModal').modal('show')");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarCreate", sb.ToString(), false);
        }
    }
}