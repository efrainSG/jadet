using SernaSistemas.Jadet.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data.DTO
{
    public class TipoEstatusDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public static TipoEstatusDto ToDTO(dynamic tipoEstatus)
        {
            return new TipoEstatusDto
            {
                Id = tipoEstatus.Id,
                Nombre = tipoEstatus.Nombre
            };
        }
    }

    public class TiposEstatusDto : List<TipoEstatusDto>
    {
        public static List<TipoEstatusDto> ToDTO(List<TipoEstatus> tipos) =>
            tipos.Select(t => TipoEstatusDto.ToDTO(t)).ToList();
    }
}
