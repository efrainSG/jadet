using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Comun.Modelos
{
    public class Catalogo
    {
        public int Id { get; set; }
        public int IdTipoCatalogo { get; set; }
        public string Nombre { get; set; }

        public static Catalogo ToModel(dynamic catalogoDto)
        {
            return new Catalogo
            {
                Id = catalogoDto.Id,
                IdTipoCatalogo = catalogoDto.IdTipoCatalogo,
                Nombre = catalogoDto.Nombre
            };
        }
    }
}
