using SernaSistemas.Jadet.WCF.Contratos;
using SernaSistemas.Jadet.WCF.Modelos;
using System;

namespace SernaSistemas.Jadet.WCF.Implementaciones
{
    public class Seguridad : ISeguridad
    {
        public UsuarioResponse cambiarPerfil(UsuarioRequest request)
        {
            throw new NotImplementedException();
        }

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
                NombreUsuario = resultado && request.Usuario.Equals("admin") ? "Administrador" :
                    (resultado && request.Usuario.Equals("user") ? "Cliente" : string.Empty),
                RolUsuario = new Rol
                {
                    Nombre = resultado && request.Usuario.Equals("admin") ? "Administrador" :
                    (resultado && request.Usuario.Equals("user") ? "Cliente" : string.Empty)
                },
                UltimoInicio = DateTime.Today,
                Usuario = request.Usuario
            };

            response.RolUsuario.IdRol = response.RolUsuario.Nombre.Equals("Administrador") ? 1 :
                (response.RolUsuario.Nombre.Equals("Cliente") ? 2 : 0);

            return response;
        }
    }
}
