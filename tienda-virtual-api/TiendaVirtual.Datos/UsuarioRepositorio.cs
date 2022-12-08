using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Modelos;

namespace TiendaVirtual.Datos
{
    public class UsuarioRepositorio
    {
        public List<Usuario> ObtenerUsuarios()
        {
            string query = @"SELECT IdUsuario, Documento, Nombre, Apellido, Email, Clave, IdRol";

            List<Usuario> listaUsuarios = new List<Usuario>();

            using (SqlConnection conexion = TiendaVirtualBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection = conexion;
                    conexion.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        usuario.Documento = Convert.ToString(reader["Documento"]);
                        usuario.Nombre = Convert.ToString(reader["Nombre"]);
                        usuario.Apellido = Convert.ToString(reader["Apellido"]);
                        usuario.Email = Convert.ToString(reader["Email"]);
                        usuario.Clave = Convert.ToString(reader["Clave"]);
                        usuario.IdRol = Convert.ToInt32(reader["IdRol"]);
                        listaUsuarios.Add(usuario);
                    }

                    conexion.Close();
                }
            }

            return listaUsuarios;
        }

        public Usuario ObtenerUsuarioPorId(int IdUsuario)
        {
            string query = @"SELECT IdUsuario, Documento, Nombre, Apellido, Email, Clave, IdRol
                             FROM Usuarios
                             WHERE IdUsuario = @IdUsuario";

            Usuario usuario = null;

            using (SqlConnection conexion = TiendaVirtualBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.Connection = conexion;
                    conexion.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        usuario = new Usuario();
                        usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        usuario.Documento = Convert.ToString(reader["Documento"]);
                        usuario.Nombre = Convert.ToString(reader["Nombre"]);
                        usuario.Apellido = Convert.ToString(reader["Apellido"]);
                        usuario.Email = Convert.ToString(reader["Email"]);
                        usuario.Clave = Convert.ToString(reader["Clave"]);
                        usuario.IdRol = Convert.ToInt32(reader["IdRol"]);
                    }

                    conexion.Close();
                }
            }

            return usuario;
        }

        public Usuario ObtenerUsuarioPorCredenciales(LoginCredenciales credenciales)
        {
            string query = @"SELECT IdUsuario, Documento, Nombre, Apellido, Email, IdRol
                             FROM Usuarios
                             WHERE Email = @Email AND Clave = @Clave";

            Usuario usuario = null;

            using (SqlConnection conexion = TiendaVirtualBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Email", credenciales.Email);
                    cmd.Parameters.AddWithValue("@Clave", credenciales.Clave);
                    cmd.Connection = conexion;
                    conexion.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        usuario = new Usuario();
                        usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        usuario.Documento = Convert.ToString(reader["Documento"]);
                        usuario.Nombre = Convert.ToString(reader["Nombre"]);
                        usuario.Apellido = Convert.ToString(reader["Apellido"]);
                        usuario.Email = Convert.ToString(reader["Email"]);
                        usuario.IdRol = Convert.ToInt32(reader["IdRol"]);
                    }

                    conexion.Close();
                }
            }

            return usuario;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            string query = @"INSERT INTO Usuarios ( Documento, Nombre, Apellido, Email, Clave, IdRol)
                             VALUES  (@Documento, @Nombre, @Apellido, @Email, @Clave, @IdRol)";


            using (SqlConnection conexion = TiendaVirtualBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Documento", usuario.Documento);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                    cmd.Connection = conexion;
                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    conexion.Close();
                }
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            string query = @"UPDATE Usuarios SET
                            Documento = @Documento,
                            Nombre = @Nombre, 
                            Apellido = @Apellido, 
                            WHERE IdUsuario = @IdUsuario";


            using (SqlConnection conexion = TiendaVirtualBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@Documento", usuario.Documento);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    cmd.Connection = conexion;
                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    conexion.Close();
                }
            }
        }

    }
}
