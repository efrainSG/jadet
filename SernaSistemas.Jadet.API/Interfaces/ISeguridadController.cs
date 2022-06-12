using Microsoft.AspNetCore.Mvc;
using SernaSistemas.Jadet.Comun.Modelos;
using System;
using System.Collections.Generic;

namespace SernaSistemas.Jadet.API.Interfaces
{
    public interface ISeguridadController
    {
        [HttpGet("estatus")]
        public IEnumerable<Estatus> GetEstatus();
        [HttpGet("estatusPorId/{esId}/{id}")]
        public IEnumerable<Estatus> GetEstatus(bool esId, int id);
        [HttpGet("estatusPorNombre/{nombre}")]
        public IEnumerable<Estatus> GetEstatus(string nombre);

        [HttpGet("tiposEstatus")]
        public IEnumerable<TipoEstatus> GetTiposEstatus();
        [HttpGet("tiposEstatusPorId/{id}")]
        public IEnumerable<TipoEstatus> GetTiposEstatus(int id);
        [HttpGet("tiposEstatusPorNombre/{nombre}")]
        public IEnumerable<TipoEstatus> GetTiposEstatus(string nombre);

        [HttpGet("roles")]
        public IEnumerable<Rol> GetRoles();
        [HttpGet("rolesPorId/{id}")]
        public IEnumerable<Rol> GetRoles(int id);
        [HttpGet("rolesPorNombre/{nombre}")]
        public IEnumerable<Rol> GetRoles(string nombre);
        [HttpDelete("roles/{id}")]
        public IActionResult DelRoles(int id);
        [HttpPost("roles")]
        public ActionResult<Rol> PostRoles(Rol rol);
        [HttpPut("roles/{id}")]
        public ActionResult<Rol> PutRoles(int id, Rol rol);

        [HttpGet("usuarios")]
        public IEnumerable<Usuario> GetUsuarios();
        [HttpGet("usuariosPorId/{id}")]
        public IEnumerable<Usuario> GetUsuarios(int id);
        [HttpGet("usuariosPorNombre/{nombre}")]
        public IEnumerable<Usuario> GetUsuarios(string nombre);
        [HttpDelete("usuarios/{id}")]
        public IActionResult DelUsuarios(Guid id);
        [HttpPost("usuarios")]
        public ActionResult<Usuario> PostUsuarios(Usuario usuario);
        [HttpPut("usuarios/{id}")]
        public ActionResult<Usuario> PutUsuarios(int id, Usuario usuario);

        [HttpPost("inicioSesion")]
        public ActionResult<Comun.Modelos.Usuario> PostSesion(Comun.Modelos.Usuario usuario);
        [HttpPut("inicioSesion")]
        public ActionResult<bool> DelSesion(Comun.Modelos.Usuario usuario);
    }
}
