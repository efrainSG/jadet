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

        public bool BorrarRol(ref RolDTO rol)
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

        public bool BorrarUsuario(ref UsuarioDTO usuario)
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

        public bool GuardarRol(ref RolDTO rol)
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

        public bool GuardarUsuario(ref UsuarioDTO usuario)
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
                    _usuario = new Usuario();
                    _usuario.Id = Guid.NewGuid();
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

        public EstatusesDTO ObtenerEstatuses(EstatusDTO estatus)
        {
            EstatusesDTO resultado = new EstatusesDTO();
            if (estatus.Id != 0)
            {
                resultado.AddRange(EstatusesDTO.ToDTO(contexto.Estatuses.Where(e => e.Id == estatus.Id).ToList()));
            }
            else if (!string.IsNullOrEmpty(estatus.Nombre))
            {
                resultado.AddRange(EstatusesDTO.ToDTO(
                    contexto.Estatuses.Where(e => e.Nombre.ToUpper().Contains(estatus.Nombre.ToUpper())).ToList())
                    );
            }
            else
            {
                resultado.AddRange(EstatusesDTO.ToDTO(contexto.Estatuses.ToList()));
            }
            return resultado;
        }

        public RolesDTO ObtenerRoles(RolDTO rol)
        {
            RolesDTO resultado = new RolesDTO();
            if (rol.Id != 0)
            {
                resultado.AddRange(RolesDTO.ToDTO(contexto.Rols.Where(r => r.Id == rol.Id).ToList()));
            }
            else if (!string.IsNullOrEmpty(rol.Nombre))
            {
                resultado.AddRange(RolesDTO.ToDTO(
                    contexto.Rols.Where(r => r.Nombre.ToUpper().Contains(rol.Nombre.ToUpper())).ToList())
                    );
            }
            else
            {
                resultado.AddRange(RolesDTO.ToDTO(contexto.Rols.ToList()));
            }
            return resultado;
        }

        public TiposEstatusDTO ObtenerTiposEstatus(TipoEstatusDTO tipo)
        {
            TiposEstatusDTO resultado = new TiposEstatusDTO();
            if (tipo.Id != 0)
            {
                resultado.AddRange(TiposEstatusDTO.ToDTO(contexto.TipoEstatuses.Where(t => t.Id == tipo.Id).ToList()));
            }
            else if (!string.IsNullOrEmpty(tipo.Nombre))
            {
                resultado.AddRange(TiposEstatusDTO.ToDTO(
                    contexto.TipoEstatuses.Where(t => t.Nombre.ToUpper().Contains(tipo.Nombre.ToUpper())).ToList())
                    );
            }
            else
            {
                resultado.AddRange(TiposEstatusDTO.ToDTO(contexto.TipoEstatuses.ToList()));
            }
            return resultado;
        }

        public UsuariosDTO ObtenerUsuarios(UsuarioDTO usuario)
        {
            UsuariosDTO resultado = new UsuariosDTO();
            if (usuario.Id != Guid.Empty)
            {
                resultado.AddRange(UsuariosDTO.ToDTO(contexto.Usuarios.Where(u => u.Id == usuario.Id).ToList()));
            }
            else if (usuario.IdEstatus != 0)
            {
                resultado.AddRange(UsuariosDTO.ToDTO(contexto.Usuarios.Where(u => u.IdEstatus == usuario.IdEstatus).ToList()));
            }
            else if (usuario.IdRol != 0)
            {
                resultado.AddRange(UsuariosDTO.ToDTO(contexto.Usuarios.Where(u => u.IdRol == usuario.IdRol).ToList()));
            }
            else if (!string.IsNullOrEmpty(usuario.NomUsuario))
            {
                resultado.AddRange(UsuariosDTO.ToDTO(
                    contexto.Usuarios.Where(u => u.Usuario1.ToUpper().Contains(usuario.NomUsuario.ToUpper())).ToList())
                    );
            }
            else if (!string.IsNullOrEmpty(usuario.Nombre))
            {
                resultado.AddRange(UsuariosDTO.ToDTO(
                    contexto.Usuarios.Where(u => u.Nombre.ToUpper().Contains(usuario.Nombre.ToUpper())).ToList())
                    );
            }
            return resultado;
        }
    }
}
