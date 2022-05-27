using System;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Comun.Modelos
{
    public class NotaComentario
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public int IdComentarioAnterior { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }

        public static NotaComentario ToModel(dynamic notaComentarioDto)
        {
            return new NotaComentario
            {
                Id = notaComentarioDto.Id,
                IdNota = notaComentarioDto.IdNota,
                Comentario = notaComentarioDto.Comentario,
                Fecha = notaComentarioDto.Fecha,
                IdComentarioAnterior = notaComentarioDto.IdComentarioAnterior
            };
        }
    }
}
