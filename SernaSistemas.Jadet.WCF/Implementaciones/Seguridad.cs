using SernaSistemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Configuration;
using System.Text;

namespace SernaSistemas.Jadet.WCF.Implementaciones
{
    public class Seguridad : ISeguridad
    {
        public UsuarioResponse cambiarPerfil(UsuarioRequest request)
        {
            DataAccess.DataAccess da = new DataAccess.DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.guardarUsuario(new DataAccess.Usuario
            {
                Direccion = request.Direccion,
                Foto = request.Foto,
                Id = request.Id,
                IdEstatus = request.IdEstatus,
                IdRol = request.IdRol,
                Nombre = request.Nombre,
                Telefono = request.Telefono,
                UserName = request.Usuario,
                Password = request.Password,
                ZonaPaqueteria = request.ZonaPaqueteria
            });

            UsuarioResponse response = new UsuarioResponse
            {
                Usuario = resultado.UserName,
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero,
                Id = resultado.Id,
                Nombre = resultado.Nombre,
                Direccion = resultado.Direccion,
                Password = resultado.Password,
                Foto = resultado.Foto,
                IdEstatus = resultado.IdEstatus,
                IdRol = resultado.IdRol,
                Telefono = resultado.Telefono,
                ZonaPaqueteria = resultado.ZonaPaqueteria
            };
            return response;
        }

        public LoginResponse CerrarSesion(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public LoginResponse IniciarSesion(LoginRequest request)
        {
            DataAccess.DataAccess da = new DataAccess.DataAccess
            {
                CadenaConexion = ConfigurationManager.ConnectionStrings["jadetBD"].ConnectionString
            };
            var resultado = da.iniciarSesion(new DataAccess.Usuario
            {
                UserName = request.Usuario,
                Password = Encoding.UTF8.GetBytes(request.password)
            });

            LoginResponse response = new LoginResponse
            {
                Usuario = resultado.UserName,
                ErrorMensaje = resultado.ErrorMensaje,
                ErrorNumero = resultado.ErrorNumero,
                IdUsuario = resultado.Id,
                NombreUsuario = resultado.Nombre,
                RolUsuario = new Rol
                {
                    IdRol = resultado.IdRol,
                    Nombre = string.Empty
                },
                UltimoInicio = DateTime.Today
            };
            return response;
        }
    }
}
