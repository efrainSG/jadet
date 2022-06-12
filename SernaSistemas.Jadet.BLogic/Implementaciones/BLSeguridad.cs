using SernaSistemas.Jadet.Comun.Modelos;
using SernaSistemas.Jadet.Data.DTO;
using SernaSistemas.Jadet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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
            RolDto rolDTO = RolDto.ToDTO(rol);
            return dbSeguridadContext.BorrarRol(ref rolDTO);
        }

        public bool BorrarUsuario(Usuario usuario)
        {
            UsuarioDto usuarioDTO = UsuarioDto.ToDTO(usuario);
            return dbSeguridadContext.BorrarUsuario(ref usuarioDTO);
        }

        public Sesion CerrarSesion(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool GuardarRol(ref Rol rol)
        {
            RolDto rolDTO = RolDto.ToDTO(rol);
            var resultado = dbSeguridadContext.GuardarRol(ref rolDTO);
            rol = Rol.ToModel(rolDTO);
            return resultado;
        }

        public bool GuardarUsuario(ref Usuario usuario)
        {
            UsuarioDto usuarioDTO = UsuarioDto.ToDTO(usuario);
            var resultado = dbSeguridadContext.GuardarUsuario(ref usuarioDTO);
            usuario = Usuario.ToModel(usuarioDTO);
            return resultado;
        }

        public Sesion IniciarSesion(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Estatus> ObtenerEstatuses(bool esId, Estatus estatus)
        {
            return dbSeguridadContext.ObtenerEstatuses(EstatusDto.ToDTO(estatus))
                .Select(e => Estatus.ToModel(e));
        }

        public IEnumerable<Rol> ObtenerRoles(Rol rol)
        {
            return dbSeguridadContext.ObtenerRoles(RolDto.ToDTO(rol))
                .Select(r => Rol.ToModel(r));
        }

        public IEnumerable<TipoEstatus> ObtenerTiposEstatus(TipoEstatus tipoEstatus)
        {
            return dbSeguridadContext.ObtenerTiposEstatus(TipoEstatusDto.ToDTO(tipoEstatus))
                .Select(t=> TipoEstatus.ToModel(t));
        }

        public IEnumerable<Usuario> ObtenerUsuarios(Usuario usuario)
        {
            return dbSeguridadContext.ObtenerUsuarios(UsuarioDto.ToDTO(usuario))
                .Select(u => Usuario.ToModel(u));
        }
    }
}
