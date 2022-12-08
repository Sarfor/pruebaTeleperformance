using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Modelos;

namespace TiendaVirtual.Datos
{
    public class ProductoRepositorio
    {
        public List<Producto> ObtenerProductosActivos()
        {
            string query = @"SELECT IdProducto, Nombre, Stock, Precio, Descripcion, EsActivo, ImagenUrl
                             FROM Productos";

            List<Producto> listaProductos = new List<Producto>();

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
                        Producto producto = new Producto();
                        producto.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                        producto.Nombre = Convert.ToString(reader["Nombre"]);
                        producto.Stock = Convert.ToInt32(reader["Stock"]);
                        producto.Precio = Convert.ToDecimal(reader["Precio"]);
                        producto.Descripcion = Convert.ToString(reader["Descripcion"]);
                        producto.EsActivo = Convert.ToBoolean(reader["EsActivo"]);
                        producto.ImagenUrl = Convert.ToString(reader["ImagenUrl"]);
                        listaProductos.Add(producto);
                    }

                    conexion.Close();
                }
            }

            return listaProductos;
        }

        public Producto ObtenerProductoPorId(int idProducto)
        {
            string query = @"SELECT IdProducto, Nombre, Stock, Precio, Descripcion, EsActivo, ImagenUrl
                             FROM Productos
                             WHERE IdProducto = @IdProducto";

            Producto producto = null; 

            using (SqlConnection conexion = TiendaVirtualBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                    cmd.Connection = conexion;
                    conexion.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        producto = new Producto();
                        producto.IdProducto = Convert.ToInt32(reader["IdProducto"]);
                        producto.Nombre = Convert.ToString(reader["Nombre"]);
                        producto.Stock = Convert.ToInt32(reader["Stock"]);
                        producto.Precio = Convert.ToDecimal(reader["Precio"]);
                        producto.Descripcion = Convert.ToString(reader["Descripcion"]);
                        producto.EsActivo = Convert.ToBoolean(reader["EsActivo"]);
                        producto.ImagenUrl = Convert.ToString(reader["ImagenUrl"]);
                    }

                    conexion.Close();
                }
            }

            return producto;
        }

        public void AgregarProducto(Producto producto)
        {
            string query = @"INSERT INTO Productos (Nombre, Stock, Precio, Descripcion, EsActivo, ImagenUrl)
                             VALUES  (@Nombre, @Stock, @Precio, @Descripcion, @EsActivo, @ImagenUrl)";


            using (SqlConnection conexion = TiendaVirtualBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@EsActivo", producto.EsActivo);
                    cmd.Parameters.AddWithValue("@ImagenUrl", producto.ImagenUrl);
                    cmd.Connection = conexion;
                    conexion.Open();

                    cmd.ExecuteNonQuery();
                    
                    conexion.Close();
                }
            }
        }

        public void ModificarProducto(Producto producto)
        {
            string query = @"UPDATE Productos SET
                            Nombre = @Nombre,
                            Stock = @Stock, 
                            Precio = @Precio, 
                            Descripcion = @Descripcion, 
                            EsActivo = @EsActivo, 
                            ImagenUrl = @ImagenUrl
                            WHERE IdProducto = @IdProducto";


            using (SqlConnection conexion = TiendaVirtualBD.CrearConexion())
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@EsActivo", producto.EsActivo);
                    cmd.Parameters.AddWithValue("@ImagenUrl", producto.ImagenUrl);
                    cmd.Connection = conexion;
                    conexion.Open();

                    cmd.ExecuteNonQuery();

                    conexion.Close();
                }
            }
        }

    }
}
