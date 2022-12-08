using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Datos;
using TiendaVirtual.Modelos;

namespace TiendaVirtual.Logica
{
    public class ProductoServicio
    {
        public List<Producto> ObtenerProductosActivos()
        {
            ProductoRepositorio repositorio = new ProductoRepositorio();
            List<Producto> listaProductos =  repositorio.ObtenerProductosActivos();
            return listaProductos;
        }

        public Producto ObtenerProductoPorId(int idProducto)
        {
            ProductoRepositorio repositorio = new ProductoRepositorio();
            Producto producto = repositorio.ObtenerProductoPorId(idProducto);
            return producto;
        }

        public void AgregarProducto(Producto nuevoProducto)
        {
            ProductoRepositorio repositorio = new ProductoRepositorio();
            repositorio.AgregarProducto(nuevoProducto);
        }
    }
}
