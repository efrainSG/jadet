using SernaSistemas.Jadet.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data.DTO
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public int IdRol { get; set; }
        public int IdEstatus { get; set; }
        public int ZonaPaqueteria { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NomUsuario { get; set; }
        public byte[] Foto { get; set; }
        public byte[] Passwd { get; set; }

        public static UsuarioDto ToDTO(dynamic usuario)
        {
            return new UsuarioDto
            {
                Id = usuario.Id,
                IdRol = usuario.IdRol,
                IdEstatus = usuario.IdEstatus,
                ZonaPaqueteria = usuario.ZonaPaqueteria,
                Nombre = usuario.Nombre,
                Direccion = usuario.Direccion,
                Telefono = usuario.Telefono,
                NomUsuario = usuario.NomUsuario,
                Foto = usuario.Foto,
                Passwd = usuario.Passwd
            };
        }
    }

    public class UsuariosDto : List<UsuarioDto>
    {
        public static List<UsuarioDto> ToDTO(List<Usuario> usuarios) =>
            usuarios.Select(u => UsuarioDto.ToDTO(u)).ToList();
    }
}
