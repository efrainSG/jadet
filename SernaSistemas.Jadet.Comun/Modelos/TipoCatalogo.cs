using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Comun.Modelos
{
    public class TipoCatalogo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public static TipoCatalogo ToModel(dynamic tipoEstatusDto)
        {
            return new TipoCatalogo
            {
                Id = tipoEstatusDto.Id,
                Nombre = tipoEstatusDto.Nombre
            };
        }
    }
}
