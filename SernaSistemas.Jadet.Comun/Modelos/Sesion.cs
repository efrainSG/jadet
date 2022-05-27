using System;

namespace SernaSistemas.Jadet.Comun.Modelos
{
    public class Sesion
    {
        public Guid Id { get; set; }
        public int IdRol { get; set; }
        public int IdEstatus { get; set; }
        public string NomUsuario { get; set; }
        public DateTime FechaLogin { get; set; }
        public byte[] Token{ get; set; }

    }
}
