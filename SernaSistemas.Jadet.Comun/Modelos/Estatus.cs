using System;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Comun.Modelos
{
    public class Estatus
    {
        public int Id { get; set; }
        public int IdTipoEstatus { get; set; }
        public string Nombre { get; set; }

        public static Estatus ToModel(dynamic estatusDto)
        {
            return new Estatus
            {
                Id = estatusDto.Id,
                IdTipoEstatus = estatusDto.IdTipoEstatus,
                Nombre = estatusDto.Nombre
            };
        }
    }
}
