using SernaSistemas.Jadet.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data.DTO
{
    public class EstatusDto
    {
        public int Id { get; set; }
        public int IdTipoEstatus { get; set; }
        public string Nombre { get; set; }

        public static EstatusDto ToDTO(dynamic estatus)
        {
            return new EstatusDto
            {
                Id = estatus.Id,
                IdTipoEstatus = estatus.IdTipoEstatus,
                Nombre = estatus.Nombre
            };
        }
    }

    public class EstatusesDto: List<EstatusDto>
    {
        internal static IEnumerable<EstatusDto> ToDTO(List<Estatus> estatuses) =>
            estatuses.Select(e => EstatusDto.ToDTO(e)).ToList();
    }
}
