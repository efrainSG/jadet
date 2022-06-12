using SernaSistemas.Jadet.Data.DTO;
using SernaSistemas.Jadet.Data.Models;

namespace SernaSistemas.Jadet.Data.Repository
{
    public interface IDbSeguridadContext
    {
        #region TipoEstatus
        /// <summary>
        /// Para obtener uno o más tipos de estatus.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        TiposEstatusDto ObtenerTiposEstatus(TipoEstatusDto tipo);
        #endregion

        #region Estatus
        /// <summary>
        /// Para obtener uno o más estatuses.
        /// </summary>
        /// <param name="estatus"></param>
        /// <returns></returns>
        EstatusesDto ObtenerEstatuses(EstatusDto estatus);
        #endregion

        #region Rol
        /// <summary>
        /// Para Borrar un rol.
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        bool BorrarRol(ref RolDto rol);
        /// <summary>
        /// Para guardar un nuevo rol o su actualización.
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        bool GuardarRol(ref RolDto rol);
        /// <summary>
        /// Para obtener uno o más roles.
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        RolesDto ObtenerRoles(RolDto rol);
        #endregion

        #region Usuario
        /// <summary>
        /// Para Borrar un usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        bool BorrarUsuario(ref UsuarioDto usuario);
        /// <summary>
        /// Para guardar un nuevo usuario o su actualización.
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        bool GuardarUsuario(ref UsuarioDto usuario);
        /// <summary>
        /// Para obtener uno o más usuarios.
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        UsuariosDto ObtenerUsuarios(UsuarioDto usuario);
        #endregion
    }
}
