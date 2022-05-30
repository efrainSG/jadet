using SernaSistemas.Jadet.Comun.Modelos;
using SernaSistemas.Jadet.DAccess.DTO;
using SernaSistemas.Jadet.DAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.BLogic
{
    public class BLSeguridad : IBLSeguridad
    {
        private readonly IDbSeguridadContext dbSeguridadContext;

        public BLSeguridad(IDbSeguridadContext dbSeguridadContext)
        {
            this.dbSeguridadContext = dbSeguridadContext;
        }
        public bool BorrarRol(Rol rol)
        {
            RolDTO rolDTO = RolDTO.ToDTO(rol);
            return dbSeguridadContext.BorrarRol(ref rolDTO);
        }

        public bool BorrarUsuario(Usuario usuario)
        {
            UsuarioDTO usuarioDTO = UsuarioDTO.ToDTO(usuario);
            return dbSeguridadContext.BorrarUsuario(ref usuarioDTO);
        }

        public Sesion CerrarSesion(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool GuardarRol(ref Rol rol)
        {
            RolDTO rolDTO = RolDTO.ToDTO(rol);
            var resultado = dbSeguridadContext.GuardarRol(ref rolDTO);
            rol = Rol.ToModel(rolDTO);
            return resultado;
        }

        public bool GuardarUsuario(ref Usuario usuario)
        {
            UsuarioDTO usuarioDTO = UsuarioDTO.ToDTO(usuario);
            var resultado = dbSeguridadContext.GuardarUsuario(ref usuarioDTO);
            usuario = Usuario.ToModel(usuarioDTO);
            return resultado;
        }

        public Sesion IniciarSesion(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estatus> ObtenerEstatuses(Estatus estatus)
        {
            return dbSeguridadContext.ObtenerEstatuses(EstatusDTO.ToDTO(estatus))
                .Select(e => Estatus.ToModel(e));
        }

        public IEnumerable<Rol> ObtenerRoles(Rol rol)
        {
            return dbSeguridadContext.ObtenerRoles(RolDTO.ToDTO(rol))
                .Select(r => Rol.ToModel(r));
        }

        public IEnumerable<TipoEstatus> ObtenerTiposEstatus(TipoEstatus tipoEstatus)
        {
            return dbSeguridadContext.ObtenerTiposEstatus(TipoEstatusDTO.ToDTO(tipoEstatus))
                .Select(t=> TipoEstatus.ToModel(t));
        }

        public IEnumerable<Usuario> ObtenerUsuarios(Usuario usuario)
        {
            return dbSeguridadContext.ObtenerUsuarios(UsuarioDTO.ToDTO(usuario))
                .Select(u => Usuario.ToModel(u));
        }
    }
}
