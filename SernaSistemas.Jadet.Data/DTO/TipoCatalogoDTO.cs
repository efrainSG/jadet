using SernaSistemas.Jadet.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data.DTO
{
    public class TipoCatalogoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public static TipoCatalogoDTO ToDTO(dynamic tipoEstatus)
        {
            return new TipoCatalogoDTO
            {
                Id = tipoEstatus.Id,
                Nombre = tipoEstatus.Nombre
            };
        }
    }

    public class TiposCatalogosDTO: List<TipoCatalogoDTO>
    {
        public static List<TipoCatalogoDTO> ToDTO (List<TipoCatalogo> tiposCatalogo) =>
            tiposCatalogo.Select(t => TipoCatalogoDTO.ToDTO(t)).ToList();
    }
}
