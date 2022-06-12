using SernaSistemas.Jadet.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data.DTO
{
    public class TipoCatalogoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public static TipoCatalogoDto ToDTO(dynamic tipoEstatus)
        {
            return new TipoCatalogoDto
            {
                Id = tipoEstatus.Id,
                Nombre = tipoEstatus.Nombre
            };
        }
    }

    public class TiposCatalogosDto: List<TipoCatalogoDto>
    {
        public static List<TipoCatalogoDto> ToDTO (List<TipoCatalogo> tiposCatalogo) =>
            tiposCatalogo.Select(t => TipoCatalogoDto.ToDTO(t)).ToList();
    }
}
