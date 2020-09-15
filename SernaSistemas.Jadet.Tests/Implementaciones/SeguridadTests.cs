using Microsoft.VisualStudio.TestTools.UnitTesting;
using SernaSistemas.Jadet.WCF.Implementaciones;
using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.WCF.Implementaciones.Tests
{
    [TestClass()]
    public class SeguridadTests
    {
        [TestMethod()]
        public void IniciarSesionTest()
        {
            Seguridad seguridad = new Seguridad();
            var resultado = seguridad.IniciarSesion(new LoginRequest
            {
                Usuario = "admin",
                password = "123"
            });
            Console.WriteLine("----------------------------\nNúmero de error: {0}\nMensaje: {1}\nId de usuario: {2}\nNombre de usuario: {3}\nRol: {4}\nÚltimo inicio de sesión: {5}\nUsuario: {6}\n----------------------------\n",
                resultado.ErrorNumero,
                resultado.ErrorMensaje,
                resultado.IdUsuario,
                resultado.NombreUsuario.ToString(),
                resultado.RolUsuario.Nombre,
                resultado.UltimoInicio,
                resultado.Usuario);

            resultado = seguridad.IniciarSesion(new LoginRequest
            {
                Usuario = "may",
                password = "may"
            });
            Console.WriteLine("----------------------------\nNúmero de error: {0}\nMensaje: {1}\nId de usuario: {2}\nNombre de usuario: {3}\nRol: {4}\nÚltimo inicio de sesión: {5}\nUsuario: {6}\n----------------------------\n",
                resultado.ErrorNumero,
                resultado.ErrorMensaje,
                resultado.IdUsuario,
                resultado.NombreUsuario.ToString(),
                resultado.RolUsuario.Nombre,
                resultado.UltimoInicio,
                resultado.Usuario);
        }

        [TestMethod()]
        public void cambiarPerfilTest()
        {
            Seguridad seguridad = new Seguridad();
            var resultado = seguridad.cambiarPerfil(new UsuarioRequest
            {
                Id = new Guid("0a305737-6ab2-4ebc-b7ba-4185ee448a9a"),
                Nombre = "USUARIO ADMINISTRADOR",
                Direccion = "CONOCIDA 1",
                IdEstatus = 1,
                Foto = Encoding.UTF8.GetBytes("0"),
                IdRol = 1,
                Password = Encoding.UTF8.GetBytes("Pa$$w0rd"),
                Telefono = "12345367890",
                Usuario = "admin",// + DateTime.Now.Ticks.ToString(),
                ZonaPaqueteria = 6
            });
            Console.WriteLine("----------------------------\nNúmero de error: {0}\nMensaje: {1}\nId de usuario: {2}\nNombre de usuario: {3}\nRol: {4}\nÚltimo inicio de sesión: {5}\nUsuario: {6}\n----------------------------\n",
                resultado.ErrorNumero,
                resultado.ErrorMensaje,
                resultado.Id,
                resultado.Nombre,
                resultado.IdRol,
                Encoding.UTF8.GetString(resultado.Password),
                resultado.Usuario);

        }

        [TestMethod()]
        public void CerrarSesionTest()
        {
            throw new NotImplementedException();
        }
    }
}