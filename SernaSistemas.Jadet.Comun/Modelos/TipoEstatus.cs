using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Comun.Modelos
{
    public class TipoEstatus
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public static TipoEstatus ToModel(dynamic tipoEstatusDto)
        {
            return new TipoEstatus
            {
                Id = tipoEstatusDto.Id,
                Nombre = tipoEstatusDto.Nombre
            };
        }
    }
}
