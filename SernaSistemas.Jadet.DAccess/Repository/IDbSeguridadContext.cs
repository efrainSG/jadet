using SernaSistemas.Jadet.DAccess.DTO;

namespace SernaSistemas.Jadet.DAccess.Repository
{
    public interface IDbSeguridadContext
    {
        #region TipoEstatus
        /// <summary>
        /// Para obtener uno o más tipos de estatus.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        TiposEstatusDTO ObtenerTiposEstatus(TipoEstatusDTO tipo);
        #endregion

        #region Estatus
        /// <summary>
        /// Para obtener uno o más estatuses.
        /// </summary>
        /// <param name="estatus"></param>
        /// <returns></returns>
        EstatusDTO ObtenerEstatuses(EstatusDTO estatus);
        #endregion

        #region Rol
        /// <summary>
        /// Para Borrar un rol.
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        bool BorrarRol(ref RolDTO rol);
        /// <summary>
        /// Para guardar un nuevo rol o su actualización.
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        bool GuardarRol(ref RolDTO rol);
        /// <summary>
        /// Para obtener uno o más roles.
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        RolesDTO ObtenerRoles(RolDTO rol);
        #endregion

        #region Usuario
        /// <summary>
        /// Para Borrar un usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        bool BorrarUsuario(ref UsuarioDTO usuario);
        /// <summary>
        /// Para guardar un nuevo usuario o su actualización.
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        bool GuardarUsuario(ref UsuarioDTO usuario);
        /// <summary>
        /// Para obtener uno o más usuarios.
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        RolesDTO ObtenerUsuarios(UsuarioDTO usuario);
        #endregion
    }
}
