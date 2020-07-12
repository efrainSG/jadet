using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.DataAccess
{
    public class ResultadoBorrado
    {
        public int ErrorNumero { get; set; }
        public string ErrorMensaje { get; set; }
    }

    public class Catalogo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipoCatalogo { get; set; }
    }
    public class Estatus
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipoEstatus { get; set; }
    }
}
