using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.DAccess.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdEstatus { get; set; }
        public int ZonaPaqueteria { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NomUsuario { get; set; }
        public byte[] Foto { get; set; }
        public byte[] Passwd { get; set; }

        public static UsuarioDTO ToDTO(dynamic usuario)
        {
            return new UsuarioDTO
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

    public class UsuariosDTO : List<UsuarioDTO>
    {
        public static List<UsuarioDTO> ToDTO(List<dynamic> usuarios) =>
            (List<UsuarioDTO>)usuarios.Select(u => UsuarioDTO.ToDTO(u));
    }
}
