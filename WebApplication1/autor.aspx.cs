using System;
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
    public partial class autor : System.Web.UI.Page
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
                // string cadenaConexion = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                string SQL = "SELECT * FROM autor WHERE borrado = 0";
                SqlConnection conn = new SqlConnection(cadenaConexion);
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter dAdapter = new SqlDataAdapter(SQL, conn);
                dAdapter.Fill(ds);
                dt = ds.Tables[0];

                grdv_Autor.DataSource = dt;
                grdv_Autor.DataBind();
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.Error.Write(ex.Message);
            }
        }

        protected void grdv_Autor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string comand = e.CommandName;
            int index = Convert.ToInt32(e.CommandArgument);
            string codigo = grdv_Autor.DataKeys[index].Value.ToString();

            switch (comand)
            {
                case "editAutor":
                    {
                        lblIdAutor.Text = codigo;
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script>");
                        sb.Append("$('#editModal').modal('show')");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarCreate", sb.ToString(), false);

                    }
                    break;

                case "deleteAutor":
                    {
                        txtIdAutor.Text = codigo;
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(@"<script>");
                        sb.Append("$('#deleteConfirm').modal('show')");
                        sb.Append(@"</script>");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ConfirmarBorrado", sb.ToString(), false);
                    }
                    break;

            }
        }

        protected void btnGuardarAutor_Click(object sender, EventArgs e)
        {
            string codigo = lblIdAutor.Text;
            string nombre = txtNombreAutor.Text;


            string cadenaConexion = ConfigurationManager.ConnectionStrings["GESTLIBRERIAConnectionString"].ConnectionString;
            // string cadenaConexion = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            int cod;
            string SQL;

            if (Int32.TryParse(codigo, out cod) && cod > 0)
            {

                SQL = "UPDATE autor SET nombre = '" + nombre + "' WHERE codAutor ='" + codigo + "'";
            }
            else
            {

                SQL = "INSERT INTO autor (nombre) VALUES('" + nombre + "')";
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

            string codigo = txtIdAutor.Text;
            //string SQL = "DELETE FROM autor WHERE codAutor=" + codigo;
            string SQL = "UPDATE autor SET borrado = '1' WHERE codAutor =" + codigo;

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

        protected void btncrearAutor_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            lblIdAutor.Text = "-1";
            txtIdAutor.Text = "";
            sb.Append(@"<script>");
            sb.Append("$('#editModal').modal('show')");
            sb.Append(@"</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MostrarCreate", sb.ToString(), false);
        }
    }
}