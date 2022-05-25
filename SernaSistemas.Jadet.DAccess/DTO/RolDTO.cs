using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.DAccess.DTO
{
    public class RolDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static RolDTO ToDTO(dynamic rol)
        {
            return new RolDTO
            {
                Id = rol.Id,
                Nombre = rol.Nombre
            };
        }
    }

    public class RolesDTO:List<RolDTO>
    {
        public static List<RolDTO> ToDTO(List<Rol> roles) =>
            (List<RolDTO>)roles.Select(r => RolDTO.ToDTO(r));
    }
}
