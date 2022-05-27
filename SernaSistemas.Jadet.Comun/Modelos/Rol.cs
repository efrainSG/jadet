using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Comun.Modelos
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static Rol ToModel(dynamic rolDto)
        {
            return new Rol
            {
                Id = rolDto.Id,
                Nombre = rolDto.Nombre
            };
        }
    }
}
