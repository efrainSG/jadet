using System;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.DAccess.DTO
{
    public class EstatusDTO
    {
        public int Id { get; set; }
        public int IdTipoEstatus { get; set; }
        public string Nombre { get; set; }

        public static EstatusDTO ToDTO(dynamic estatus)
        {
            return new EstatusDTO
            {
                Id = estatus.Id,
                IdTipoEstatus = estatus.IdTipoEstatus,
                Nombre = estatus.Nombre
            };
        }
    }

    public class EstatusesDTO: List<EstatusDTO>
    {
        internal static IEnumerable<EstatusDTO> ToDTO(List<Estatus> estatuses) =>
            (List<EstatusDTO>)estatuses.Select(e => EstatusDTO.ToDTO(e));
    }
}
