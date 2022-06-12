using SernaSistemas.Jadet.Data.Models;
using SernaSistemas.Jadet.Data.DTO;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SernaSistemas.Jadet.Data.Repository
{
    public class DbSeguridadContext : IDbSeguridadContext
    {
        private readonly BDJadetContext contexto;

        public DbSeguridadContext(BDJadetContext entities)
        {
            contexto = entities;
        }
        public DbSeguridadContext(DbContext dbContext)
        {
            contexto = dbContext as BDJadetContext;
        }

        public bool BorrarRol(ref RolDto rol)
        {
            int id = rol.Id;
            Rol _rol = contexto.Rols.FirstOrDefault(r => r.Id == id);
            if (_rol != null)
            {
                contexto.Rols.Remove(_rol);
                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarUsuario(ref UsuarioDto usuario)
        {
            Guid id = usuario.Id;
            int idRol = usuario.IdRol;
            Usuario _usuario = contexto.Usuarios.FirstOrDefault(u => u.Id == id);
            if (_usuario != null)
            {
                Rol _usuarioRol = contexto.Rols.FirstOrDefault(r => r.Id == idRol);
                _usuarioRol.Usuarios.Remove(_usuario);
                contexto.Usuarios.Remove(_usuario);
                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool GuardarRol(ref RolDto rol)
        {
            int id = rol.Id;
            Rol _rol = contexto.Rols.FirstOrDefault(r => r.Id == id);
            if (_rol == null)
            {
                _rol = new Rol();
                contexto.Rols.Add(_rol);
            }
            _rol.Nombre = rol.Nombre;
            int resultado = contexto.SaveChanges();
            rol.Id = _rol.Id;
            return resultado != 0;
        }

        public bool GuardarUsuario(ref UsuarioDto usuario)
        {
            Guid id = usuario.Id;
            int idRol = usuario.IdRol;
            int idEstatus = usuario.IdEstatus;
            Rol _rol = contexto.Rols.FirstOrDefault(r => r.Id == idRol);
            if (_rol != null)
            {
                Estatus _estatus = contexto.Estatuses.FirstOrDefault(e => e.Id == idEstatus);
                Usuario _usuario = contexto.Usuarios.FirstOrDefault(u => u.Id == id);
                if (_usuario == null)
                {
                    _usuario = new Usuario { Id = Guid.NewGuid() };
                    contexto.Usuarios.Add(_usuario);
                }
                _usuario.Direccion = usuario.Direccion;
                _usuario.ZonaPaqueteria = usuario.ZonaPaqueteria;
                _usuario.Usuario1 = usuario.NomUsuario;
                _usuario.Nombre = usuario.Nombre;
                _usuario.Telefono = usuario.Telefono;
                _usuario.Foto = usuario.Foto;
                _usuario.Passwd = usuario.Passwd;
                _estatus.Usuarios.Add(_usuario);
                _rol.Usuarios.Add(_usuario);
                int resultado = contexto.SaveChanges();
                usuario.Id = _usuario.Id;
                return resultado != 0;
            }
            return false;
        }

        public EstatusesDto ObtenerEstatuses(EstatusDto estatus)
        {
            EstatusesDto resultado = new EstatusesDto();
            if (estatus.Id != 0)
            {
                resultado.AddRange(EstatusesDto.ToDTO(contexto.Estatuses.Where(e => e.Id == estatus.Id).ToList()));
            }
            else if (!string.IsNullOrEmpty(estatus.Nombre))
            {
                resultado.AddRange(EstatusesDto.ToDTO(
                    contexto.Estatuses.Where(e => e.Nombre.ToUpper().Contains(estatus.Nombre.ToUpper())).ToList())
                    );
            }
            else
            {
                resultado.AddRange(EstatusesDto.ToDTO(contexto.Estatuses.ToList()));
            }
            return resultado;
        }

        public RolesDto ObtenerRoles(RolDto rol)
        {
            RolesDto resultado = new RolesDto();
            if (rol.Id != 0)
            {
                resultado.AddRange(RolesDto.ToDTO(contexto.Rols.Where(r => r.Id == rol.Id).ToList()));
            }
            else if (!string.IsNullOrEmpty(rol.Nombre))
            {
                resultado.AddRange(RolesDto.ToDTO(
                    contexto.Rols.Where(r => r.Nombre.ToUpper().Contains(rol.Nombre.ToUpper())).ToList())
                    );
            }
            else
            {
                resultado.AddRange(RolesDto.ToDTO(contexto.Rols.ToList()));
            }
            return resultado;
        }

        public TiposEstatusDto ObtenerTiposEstatus(TipoEstatusDto tipo)
        {
            TiposEstatusDto resultado = new TiposEstatusDto();
            if (tipo.Id != 0)
            {
                resultado.AddRange(TiposEstatusDto.ToDTO(contexto.TipoEstatuses.Where(t => t.Id == tipo.Id).ToList()));
            }
            else if (!string.IsNullOrEmpty(tipo.Nombre))
            {
                resultado.AddRange(TiposEstatusDto.ToDTO(
                    contexto.TipoEstatuses.Where(t => t.Nombre.ToUpper().Contains(tipo.Nombre.ToUpper())).ToList())
                    );
            }
            else
            {
                resultado.AddRange(TiposEstatusDto.ToDTO(contexto.TipoEstatuses.ToList()));
            }
            return resultado;
        }

        public UsuariosDto ObtenerUsuarios(UsuarioDto usuario)
        {
            UsuariosDto resultado = new UsuariosDto();
            if (usuario.Id != Guid.Empty)
            {
                resultado.AddRange(UsuariosDto.ToDTO(contexto.Usuarios.Where(u => u.Id == usuario.Id).ToList()));
            }
            else if (usuario.IdEstatus != 0)
            {
                resultado.AddRange(UsuariosDto.ToDTO(contexto.Usuarios.Where(u => u.IdEstatus == usuario.IdEstatus).ToList()));
            }
            else if (usuario.IdRol != 0)
            {
                resultado.AddRange(UsuariosDto.ToDTO(contexto.Usuarios.Where(u => u.IdRol == usuario.IdRol).ToList()));
            }
            else if (!string.IsNullOrEmpty(usuario.NomUsuario))
            {
                resultado.AddRange(UsuariosDto.ToDTO(
                    contexto.Usuarios.Where(u => u.Usuario1.ToUpper().Contains(usuario.NomUsuario.ToUpper())).ToList())
                    );
            }
            else if (!string.IsNullOrEmpty(usuario.Nombre))
            {
                resultado.AddRange(UsuariosDto.ToDTO(
                    contexto.Usuarios.Where(u => u.Nombre.ToUpper().Contains(usuario.Nombre.ToUpper())).ToList())
                    );
            }
            return resultado;
        }
    }
}
