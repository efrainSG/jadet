using SernaSistemas.Jadet.Data.Models;
using SernaSistemas.Jadet.Data.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SernaSistemas.Jadet.Data.Repository
{
    public class DbConfiguracionContext : IDbConfiguracionContext
    {
        private readonly BDJadetContext contexto;

        public DbConfiguracionContext(BDJadetContext entities)
        {
            contexto = entities;
        }
        public DbConfiguracionContext(DbContext dbContext)
        {
            contexto = dbContext as BDJadetContext;
        }

        public bool BorrarCatalogo(ref CatalogoDto catalogo)
        {
            int id = catalogo.Id;
            Catalogo _catalogo = contexto.Catalogos.FirstOrDefault(c => c.Id == id);
            if (_catalogo != null)
            {
                TipoCatalogo tipo = _catalogo.IdTipoCatalogoNavigation;

                tipo.Catalogos.Remove(_catalogo);
                contexto.Catalogos.Remove(_catalogo);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarEstatus(ref EstatusDto estatus)
        {
            int id = estatus.Id;
            Estatus _estatus = contexto.Estatuses.FirstOrDefault(e => e.Id == id);
            if (_estatus != null)
            {
                TipoEstatus tipo = _estatus.IdTipoEstatusNavigation;

                tipo.Estatuses.Remove(_estatus);
                contexto.Estatuses.Remove(_estatus);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarProducto(ref ProductoDto producto)
        {
            int id = producto.Id;
            Producto _producto = contexto.Productos.FirstOrDefault(p => p.Id == id);
            if (_producto != null)
            {
                Catalogo catalogo = _producto.IdCatalogoNavigation;
                Estatus estatus = _producto.IdEstatusNavigation;
                Catalogo tipoNota = _producto.IdTipoNotaNavigation;

                catalogo.ProductoIdCatalogoNavigations.Remove(_producto);
                estatus.Productos.Remove(_producto);
                tipoNota.ProductoIdCatalogoNavigations.Remove(_producto);
                contexto.Productos.Remove(_producto);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarTipoCatalogo(ref TipoCatalogoDto tipoCatalogo)
        {
            int id = tipoCatalogo.Id;
            TipoCatalogo _tipoCatalogo = contexto.TipoCatalogos.FirstOrDefault(t => t.Id == id);
            if (_tipoCatalogo != null)
            {
                contexto.TipoCatalogos.Remove(_tipoCatalogo);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarTipoEstatus(ref TipoEstatusDto tipo)
        {
            int id = tipo.Id;
            TipoEstatus _tipo = contexto.TipoEstatuses.FirstOrDefault(t => t.Id == id);
            if (_tipo != null)
            {
                contexto.TipoEstatuses.Remove(_tipo);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool GuardarCatalogo(ref CatalogoDto catalogo)
        {
            int id = catalogo.Id;
            int idTipo = catalogo.IdTipoCatalogo;
            Catalogo _catalogo = contexto.Catalogos.FirstOrDefault(c => c.Id == id);
            TipoCatalogo _tipo = contexto.TipoCatalogos.FirstOrDefault(t => t.Id == idTipo);
            if (_catalogo == null)
            {
                _catalogo = new Catalogo();
                contexto.Catalogos.Add(_catalogo);
            }
            _tipo.Catalogos.Add(_catalogo);

            _catalogo.Nombre = catalogo.Nombre;

            int resultado = contexto.SaveChanges();

            catalogo = CatalogoDto.ToDTO(_catalogo);

            return resultado != 0;
        }

        public bool GuardarEstatus(ref EstatusDto estatus)
        {
            int id = estatus.Id;
            int idTipo = estatus.IdTipoEstatus;
            Estatus _estatus = contexto.Estatuses.FirstOrDefault(e => e.Id == id);
            TipoEstatus _tipo = contexto.TipoEstatuses.FirstOrDefault(t => t.Id == idTipo);
            if (_estatus == null)
            {
                _estatus = new Estatus();
                contexto.Estatuses.Add(_estatus);
            }

            _tipo.Estatuses.Add(_estatus);
            _estatus.Nombre = estatus.Nombre;

            int resultado = contexto.SaveChanges();

            estatus = EstatusDto.ToDTO(_estatus);

            return resultado != 0;
        }

        public bool GuardarProducto(ref ProductoDto producto)
        {
            int id = producto.Id;
            int idCatalogo = producto.IdCatalogo;
            int idEstatus = producto.IdEstatus;
            int idTipoNota = producto.IdTipoNota;
            Producto _producto = contexto.Productos.FirstOrDefault(p => p.Id == id);
            if (_producto == null)
            {
                _producto = new Producto();
                contexto.Productos.Add(_producto);
            }

            Catalogo _catalogo = contexto.Catalogos.FirstOrDefault(c => c.Id == idCatalogo);
            Estatus _estatus = contexto.Estatuses.FirstOrDefault(e => e.Id == idEstatus);
            Catalogo _tipoNota = contexto.Catalogos.FirstOrDefault(t => t.Id == idTipoNota);

            _catalogo.ProductoIdCatalogoNavigations.Add(_producto);
            _estatus.Productos.Add(_producto);
            _tipoNota.ProductoIdTipoNotaNavigations.Add(_producto);

            int resultado = contexto.SaveChanges();

            producto = ProductoDto.ToDTO(_producto);
            return resultado != 0;
        }

        public bool GuardarTipoCatalogo(ref TipoCatalogoDto tipoCatalogo)
        {
            int id = tipoCatalogo.Id;
            TipoCatalogo _estatus = contexto.TipoCatalogos.FirstOrDefault(e => e.Id == id);
            if (_estatus == null)
            {
                _estatus = new TipoCatalogo();
                contexto.TipoCatalogos.Add(_estatus);
            }

            _estatus.Nombre = tipoCatalogo.Nombre;

            int resultado = contexto.SaveChanges();
            tipoCatalogo = TipoCatalogoDto.ToDTO(_estatus);
            return resultado != 0;
        }

        public bool GuardarTipoEstatus(ref TipoEstatusDto tipo)
        {
            int id = tipo.Id;

            TipoEstatus _tipo = contexto.TipoEstatuses.FirstOrDefault(t => t.Id == id);
            if (_tipo == null)
            {
                _tipo = new TipoEstatus();
                contexto.TipoEstatuses.Add(_tipo);
            }
            _tipo.Nombre = tipo.Nombre;
            int resultado = contexto.SaveChanges();
            tipo = TipoEstatusDto.ToDTO(_tipo);
            return resultado != 0;
        }

        public CatalogosDto ObtenerCatalogos(CatalogoDto catalogo)
        {
            CatalogosDto resultado = new CatalogosDto();
            if (catalogo.Id != 0)
            {
                resultado.AddRange(CatalogosDto.ToDTO(contexto.Catalogos.Where(c => c.Id == catalogo.Id).ToList()));
            }
            else if (catalogo.IdTipoCatalogo != 0)
            {
                resultado.AddRange(CatalogosDto.ToDTO(
                    contexto.Catalogos.Where(c => c.IdTipoCatalogo == catalogo.IdTipoCatalogo).ToList()
                    ));
            }
            else if (!string.IsNullOrEmpty(catalogo.Nombre))
            {
                resultado.AddRange(CatalogosDto.ToDTO(
                    contexto.Catalogos.Where(c => c.Nombre.ToUpper().Contains(catalogo.Nombre.ToUpper())).ToList()
                    ));
            }
            else
            {
                resultado.AddRange(CatalogosDto.ToDTO(contexto.Catalogos.ToList()));
            }
            return resultado;
        }

        public EstatusesDto ObtenerEstatuses(EstatusDto estatus)
        {
            EstatusesDto resultado = new EstatusesDto();
            if (estatus.Id != 0)
            {
                resultado.AddRange(EstatusesDto.ToDTO(contexto.Estatuses.Where(e => e.Id == estatus.Id).ToList()));
            }
            else if (estatus.IdTipoEstatus != 0)
            {
                resultado.AddRange(EstatusesDto.ToDTO(contexto.Estatuses.Where(e => e.IdTipoEstatus == estatus.IdTipoEstatus).ToList()));
            }
            else if (!string.IsNullOrEmpty(estatus.Nombre))
            {
                resultado.AddRange(EstatusesDto.ToDTO(
                    contexto.Estatuses.Where(e => e.Nombre.ToUpper().Contains(estatus.Nombre.ToUpper())).ToList()));
            }
            return resultado;
        }

        public ProductosDto ObtenerProductos(ProductoDto producto)
        {
            ProductosDto resultado = new ProductosDto();
            if (producto.Id != 0)
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.Where(p => p.Id == producto.Id).ToList()));
            }
            else if (producto.IdCatalogo != 0)
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.Where(p => p.IdCatalogo == producto.IdCatalogo).ToList()));
            }
            else if (producto.IdEstatus != 0)
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.Where(p => p.IdEstatus == producto.IdEstatus).ToList()));
            }
            else if (producto.IdTipoNota != 0)
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.Where(p => p.IdTipoNota == producto.IdTipoNota).ToList()));
            }
            else if (!string.IsNullOrEmpty(producto.Sku))
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.Where(p => p.Sku.ToUpper().Contains(producto.Sku.ToUpper())).ToList()));
            }
            else if (!string.IsNullOrEmpty(producto.Nombre))
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.Where(p => p.Nombre.ToUpper().Contains(producto.Nombre.ToUpper())).ToList()));
            }
            else
            {
                resultado.AddRange(ProductosDto.ToDTO(contexto.Productos.ToList()));
            }
            return resultado;
        }

        public TiposCatalogosDto ObtenerTiposCatalogos(TipoCatalogoDto tipoCatalogo)
        {
            TiposCatalogosDto resultado = new TiposCatalogosDto();
            if (tipoCatalogo.Id != 0)
            {
                resultado.AddRange(TiposCatalogosDto.ToDTO(contexto.TipoCatalogos.Where(t => t.Id == tipoCatalogo.Id).ToList()));
            }
            else if (!string.IsNullOrEmpty(tipoCatalogo.Nombre))
            {
                resultado.AddRange(TiposCatalogosDto.ToDTO(contexto.TipoCatalogos.Where(t => t.Nombre.ToUpper().Contains(tipoCatalogo.Nombre.ToUpper())).ToList()));
            }
            else
            {
                resultado.AddRange(TiposCatalogosDto.ToDTO(contexto.TipoCatalogos.ToList()));
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
                resultado.AddRange(TiposEstatusDto.ToDTO(contexto.TipoEstatuses.Where(t => t.Id == tipo.Id).ToList()));
            }
            else
            {
                resultado.AddRange(TiposEstatusDto.ToDTO(contexto.TipoEstatuses.ToList()));
            }
            return resultado;
        }
    }
}
