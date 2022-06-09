using System;
using System.Collections.Generic;

#nullable disable

namespace SernaSistemas.Jadet.Data.Models
{
    public partial class NotasComentario
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public int? IdComentarioAnterior { get; set; }
        public string Comentario { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Nota IdNotaNavigation { get; set; }
    }
}
