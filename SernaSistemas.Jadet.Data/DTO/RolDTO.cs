using SernaSistemas.Jadet.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data.DTO
{
    public class RolDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static RolDto ToDTO(dynamic rol)
        {
            return new RolDto
            {
                Id = rol.Id,
                Nombre = rol.Nombre
            };
        }
    }

    public class RolesDto:List<RolDto>
    {
        public static List<RolDto> ToDTO(List<Rol> roles) =>
            roles.Select(r => RolDto.ToDTO(r)).ToList();
    }
}
