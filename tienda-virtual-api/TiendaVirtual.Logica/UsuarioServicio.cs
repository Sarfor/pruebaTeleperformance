using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaVirtual.Datos;
using TiendaVirtual.Modelos;

namespace TiendaVirtual.Logica
{
     public class UsuarioServicio
    {
        public List<Usuario> ObtenerUsuarios()
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            List<Usuario> listaUsuarios = repositorio.ObtenerUsuarios();
            return listaUsuarios;
        }

        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            Usuario usuario = repositorio.ObtenerUsuarioPorId(idUsuario);
            return usuario;
        }

        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            nuevoUsuario.IdRol = 2; //Siempre se agrega el usuario con rol Cliente
            repositorio.AgregarUsuario(nuevoUsuario);
        }

        public Usuario ObtenerUsuarioPorCredenciales(LoginCredenciales credenciales)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            Usuario usuario = repositorio.ObtenerUsuarioPorCredenciales(credenciales);
            return usuario;
        }
    }
}
