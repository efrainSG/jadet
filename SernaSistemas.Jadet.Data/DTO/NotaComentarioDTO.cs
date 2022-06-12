using SernaSistemas.Jadet.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data.DTO
{
    public class NotaComentarioDto
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public int IdComentarioAnterior { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }

        public static NotaComentarioDto ToDTO(dynamic notaComentario)
        {
            return new NotaComentarioDto
            {
                Id = notaComentario.Id,
                IdNota = notaComentario.IdNota,
                Comentario = notaComentario.Comentario,
                Fecha = notaComentario.Fecha,
                IdComentarioAnterior = notaComentario.IdComentarioAnterior
            };
        }
    }

    public class NotasComentariosDto: List<NotaComentarioDto>
    {
        public static List<NotaComentarioDto> ToDTO(List<NotasComentario> comentarios) =>
            comentarios.Select(c => NotaComentarioDto.ToDTO(c)).ToList();
    }
}
