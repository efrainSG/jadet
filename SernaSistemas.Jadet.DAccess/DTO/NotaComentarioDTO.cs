﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.DAccess.DTO
{
    public class NotaComentarioDTO
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public int IdComentarioAnterior { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }

        public static NotaComentarioDTO ToDTO(dynamic notaComentario)
        {
            return new NotaComentarioDTO
            {
                Id = notaComentario.Id,
                IdNota = notaComentario.IdNota,
                Comentario = notaComentario.Comentario,
                Fecha = notaComentario.Fecha,
                IdComentarioAnterior = notaComentario.IdComentarioAnterior
            };
        }
    }

    public class NotasComentariosDTO: List<NotaComentarioDTO>
    {
        public static List<NotaComentarioDTO> ToDTO(List<dynamic> comentarios) =>
            (List<NotaComentarioDTO>)comentarios.Select(c => NotaComentarioDTO.ToDTO(c));
    }
}
