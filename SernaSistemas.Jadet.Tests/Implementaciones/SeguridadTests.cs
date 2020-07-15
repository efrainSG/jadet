using Microsoft.VisualStudio.TestTools.UnitTesting;
using SernaSistemas.Jadet.WCF.Implementaciones;
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
            var resultado = seguridad.IniciarSesion(new Modelos.LoginRequest
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

            resultado = seguridad.IniciarSesion(new Modelos.LoginRequest
            {
                Usuario = "user",
                password = "456"
            });
            Console.WriteLine("----------------------------\nNúmero de error: {0}\nMensaje: {1}\nId de usuario: {2}\nNombre de usuario: {3}\nRol: {4}\nÚltimo inicio de sesión: {5}\nUsuario: {6}\n----------------------------\n",
                resultado.ErrorNumero,
                resultado.ErrorMensaje,
                resultado.IdUsuario,
                resultado.NombreUsuario.ToString(),
                resultado.RolUsuario.Nombre,
                resultado.UltimoInicio,
                resultado.Usuario);

            resultado = seguridad.IniciarSesion(new Modelos.LoginRequest
            {
                Usuario = "admin",
                password = "456"
            });
            Console.WriteLine("----------------------------\nNúmero de error: {0}\nMensaje: {1}\nId de usuario: {2}\nNombre de usuario: {3}\nRol: {4}\nÚltimo inicio de sesión: {5}\nUsuario: {6}\n----------------------------\n",
                resultado.ErrorNumero,
                resultado.ErrorMensaje,
                resultado.IdUsuario,
                resultado.NombreUsuario.ToString(),
                resultado.RolUsuario.Nombre,
                resultado.UltimoInicio,
                resultado.Usuario);

            resultado = seguridad.IniciarSesion(new Modelos.LoginRequest
            {
                Usuario = "user",
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
        }
    }
}