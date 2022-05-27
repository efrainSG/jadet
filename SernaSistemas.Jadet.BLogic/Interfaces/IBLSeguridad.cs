using SernaSistemas.Jadet.Comun.Modelos;
using System.Collections.Generic;

namespace SernaSistemas.Jadet.BLogic
{
    public interface IBLSeguridad
    {
        Sesion IniciarSesion(Usuario usuario);
        Sesion CerrarSesion(Usuario usuario);

        IEnumerable<TipoEstatus> ObtenerTiposEstatus(TipoEstatus tipoEstatus);
        IEnumerable<Estatus> ObtenerEstatuses(Estatus estatus);
        IEnumerable<Rol> ObtenerRoles(Rol rol);
        IEnumerable<Usuario> ObtenerUsuarios(Usuario usuario);

        bool GuardarRol(ref Rol rol);
        bool GuardarUsuario(ref Usuario usuario);

        bool BorrarRol(Rol rol);
        bool BorrarUsuario(Usuario usuario);
    }
}
