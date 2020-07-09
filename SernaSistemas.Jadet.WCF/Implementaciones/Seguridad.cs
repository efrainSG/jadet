using SernaSistemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.WCF.Modelos;
using System;

namespace SernaSistemas.Jadet.WCF.Implementaciones
{
    public class Seguridad : ISeguridad
    {
        public LoginResponse CerrarSesion(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public LoginResponse IniciarSesion(LoginRequest request)
        {
            bool resultado = (request.Usuario.Equals("admin") && request.password.Equals("123")) ||
                (request.Usuario.Equals("user") && request.password.Equals("456"));
            LoginResponse response = new LoginResponse
            {
                ErrorNumero = Convert.ToInt32(!resultado),
                ErrorMensaje = resultado ? "" : "Usuario o contraseña incorrectos.",
                IdUsuario = resultado ? Guid.NewGuid() : new Guid(),
                NombreUsuario = new Nombre
                {
                    Nombres = resultado && request.Usuario.Equals("admin") ? "Administrador" :
                    (resultado && request.Usuario.Equals("user") ? "Cliente" : string.Empty),
                },
                RolUsuario = new Rol
                {
                    NombreRol = resultado && request.Usuario.Equals("admin") ? "Administrador" :
                    (resultado && request.Usuario.Equals("user") ? "Cliente" : string.Empty)
                },
                UltimoInicio = DateTime.Today,
                Usuario = request.Usuario
            };

            response.RolUsuario.IdRol = response.RolUsuario.NombreRol.Equals("Administrador") ? 1 :
                (response.RolUsuario.NombreRol.Equals("Cliente") ? 2 : 0);
            response.NombreUsuario.ApellidoMaterno = response.NombreUsuario.Nombres;
            response.NombreUsuario.ApellidoPaterno = response.NombreUsuario.Nombres;

            return response;
        }
    }
}
