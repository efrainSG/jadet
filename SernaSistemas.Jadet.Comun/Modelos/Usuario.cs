using System;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Comun.Modelos
{
    public class Usuario
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

        public static Usuario ToModel(dynamic usuarioDto)
        {
            return new Usuario
            {
                Id = usuarioDto.Id,
                IdRol = usuarioDto.IdRol,
                IdEstatus = usuarioDto.IdEstatus,
                ZonaPaqueteria = usuarioDto.ZonaPaqueteria,
                Nombre = usuarioDto.Nombre,
                Direccion = usuarioDto.Direccion,
                Telefono = usuarioDto.Telefono,
                NomUsuario = usuarioDto.NomUsuario,
                Foto = usuarioDto.Foto,
                Passwd = usuarioDto.Passwd
            };
        }
    }
}
