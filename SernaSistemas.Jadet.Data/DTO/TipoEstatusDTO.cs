using SernaSistemas.Jadet.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data.DTO
{
    public class TipoEstatusDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public static TipoEstatusDTO ToDTO(dynamic tipoEstatus)
        {
            return new TipoEstatusDTO
            {
                Id = tipoEstatus.Id,
                Nombre = tipoEstatus.Nombre
            };
        }
    }

    public class TiposEstatusDTO : List<TipoEstatusDTO>
    {
        public static List<TipoEstatusDTO> ToDTO(List<TipoEstatus> tipos) =>
            tipos.Select(t => TipoEstatusDTO.ToDTO(t)).ToList();
    }
}
