using SernaSistemas.Jadet.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data.DTO
{
    public class CatalogoDto
    {
        public int Id { get; set; }
        public int IdTipoCatalogo { get; set; }
        public string Nombre { get; set; }

        public static CatalogoDto ToDTO(dynamic catalogo)
        {
            return new CatalogoDto
            {
                Id = catalogo.Id,
                IdTipoCatalogo = catalogo.IdTipoCatalogo,
                Nombre = catalogo.Nombre
            };
        }
    }

    public class CatalogosDto : List<CatalogoDto>
    {
        public static List<CatalogoDto> ToDTO(List<Catalogo> catalogos) =>
            catalogos.Select(c => CatalogoDto.ToDTO(c)).ToList();
    }
}
