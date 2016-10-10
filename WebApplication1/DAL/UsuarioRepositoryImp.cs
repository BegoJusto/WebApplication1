using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using WebApplication1.DAL;

namespace EjemploWebForm.DAL
{
    public class UsuarioRepositoryImp : UsuarioRepository
    {
        private string conexionString = ConfigurationManager.ConnectionStrings["GESTLIBRERIAConnectionString"].ConnectionString;
        public Guid create(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void delete(Guid codigo)
        {
            throw new NotImplementedException();
        }

        public IList<Usuario> getAll()
        {
            IList<Usuario> usuarios = null;
            const string SQL = "obtenerUsuarios";

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
            }

            return usuarios;
        }

        public Usuario getById(Guid codigo)
        {
            Usuario usuario = null;
            const string SQL = "getUsuarioById";
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {

                SqlCommand command = new SqlCommand(SQL, conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@pUsuarioId", codigo); //pUsuarioId se llama así en su procedimiento almacenado
                command.Connection = conexion;
                conexion.Open();
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usuario = parseUsuario(reader);
                        }
                    }
                }
            }
            return usuario;
        }

        private Usuario parseUsuario(SqlDataReader reader)
        {
            Usuario usuario = new Usuario();
            usuario.CodigoUsuario = new Guid(reader["codigoUsuario"].ToString());
            usuario.Nombre = reader["nombreUsuario"].ToString();
            usuario.Apellidos = reader["apellidos"].ToString();
            usuario.Mail = reader["mail"].ToString();
            usuario.Userid = reader["userid"].ToString();
            usuario.Password = reader["password"].ToString();
            usuario.FNacimiento = Convert.ToDateTime(reader["fNacimiento"].ToString());

            return usuario;
        }

        public Usuario update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}