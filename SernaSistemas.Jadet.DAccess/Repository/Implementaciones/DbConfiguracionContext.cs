using SernaSistemas.Jadet.DAccess.DTO;
using System.Linq;

namespace SernaSistemas.Jadet.DAccess.Repository
{
    public class DbConfiguracionContext : IDbConfiguracionContext
    {
        private readonly BDJadetEntities contexto;

        public DbConfiguracionContext(BDJadetEntities entities)
        {
            contexto = entities;
        }
        public DbConfiguracionContext(System.Data.Entity.DbContext dbContext)
        {
            contexto = dbContext as BDJadetEntities;
        }

        public bool BorrarCatalogo(ref CatalogoDTO catalogo)
        {
            int id = catalogo.Id;
            Catalogo _catalogo = contexto.Catalogoes.FirstOrDefault(c => c.Id == id);
            if (_catalogo != null)
            {
                TipoCatalogo tipo = _catalogo.TipoCatalogo;

                tipo.Catalogos.Remove(_catalogo);
                contexto.Catalogoes.Remove(_catalogo);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarEstatus(ref EstatusDTO estatus)
        {
            int id = estatus.Id;
            Estatus _estatus = contexto.Estatus1.FirstOrDefault(e => e.Id == id);
            if (_estatus != null)
            {
                TipoEstatus tipo = _estatus.TipoEstatus;

                tipo.Estatuses.Remove(_estatus);
                contexto.Estatus1.Remove(_estatus);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarProducto(ref ProductoDTO producto)
        {
            int id = producto.Id;
            Producto _producto = contexto.Productoes.FirstOrDefault(p => p.Id == id);
            if (_producto != null)
            {
                Catalogo catalogo = _producto.CatProducto;
                Catalogo estatus = _producto.CatEstatus;
                Catalogo tipoNota = _producto.CatTipoNota;

                catalogo.CatProductos.Remove(_producto);
                estatus.CatProductos.Remove(_producto);
                tipoNota.CatProductos.Remove(_producto);
                contexto.Productoes.Remove(_producto);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarTipoCatalogo(ref TipoCatalogoDTO tipoCatalogo)
        {
            int id = tipoCatalogo.Id;
            TipoCatalogo _tipoCatalogo = contexto.TipoCatalogoes.FirstOrDefault(t => t.Id == id);
            if (_tipoCatalogo != null)
            {
                contexto.TipoCatalogoes.Remove(_tipoCatalogo);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool BorrarTipoEstatus(ref TipoEstatusDTO tipo)
        {
            int id = tipo.Id;
            TipoEstatus _tipo = contexto.TipoEstatus1.FirstOrDefault(t => t.Id == id);
            if (_tipo != null)
            {
                contexto.TipoEstatus1.Remove(_tipo);

                return contexto.SaveChanges() != 0;
            }
            return false;
        }

        public bool GuardarCatalogo(ref CatalogoDTO catalogo)
        {
            int id = catalogo.Id;
            int idTipo = catalogo.IdTipoCatalogo;
            Catalogo _catalogo = contexto.Catalogoes.FirstOrDefault(c => c.Id == id);
            TipoCatalogo _tipo = contexto.TipoCatalogoes.FirstOrDefault(t => t.Id == idTipo);
            if (_catalogo == null)
            {
                _catalogo = new Catalogo();
                contexto.Catalogoes.Add(_catalogo);
            }
            _tipo.Catalogos.Add(_catalogo);

            _catalogo.Nombre = catalogo.Nombre;

            int resultado = contexto.SaveChanges();

            catalogo = CatalogoDTO.ToDTO(_catalogo);

            return resultado != 0;
        }

        public bool GuardarEstatus(ref EstatusDTO estatus)
        {
            int id = estatus.Id;
            int idTipo = estatus.IdTipoEstatus;
            Estatus _estatus = contexto.Estatus1.FirstOrDefault(e => e.Id == id);
            TipoEstatus _tipo = contexto.TipoEstatus1.FirstOrDefault(t => t.Id == idTipo);
            if (_estatus == null)
            {
                _estatus = new Estatus();
                contexto.Estatus1.Add(_estatus);
            }

            _tipo.Estatuses.Add(_estatus);
            _estatus.Nombre = estatus.Nombre;

            int resultado = contexto.SaveChanges();

            estatus = EstatusDTO.ToDTO(_estatus);

            return resultado != 0;
        }

        public bool GuardarProducto(ref ProductoDTO producto)
        {
            int id = producto.Id;
            int idCatalogo = producto.IdCatalogo;
            int idEstatus = producto.IdEstatus;
            int idTipoNota = producto.IdTipoNota;
            Producto _producto = contexto.Productoes.FirstOrDefault(p => p.Id == id);
            if (_producto == null)
            {
                _producto = new Producto();
                contexto.Productoes.Add(_producto);
            }

            Catalogo _catalogo = contexto.Catalogoes.FirstOrDefault(c => c.Id == idCatalogo);
            Catalogo _estatus = contexto.Catalogoes.FirstOrDefault(e => e.Id == idEstatus);
            Catalogo _tipoNota = contexto.Catalogoes.FirstOrDefault(t => t.Id == idTipoNota);

            _catalogo.CatProductos.Add(_producto);
            _estatus.EstProductos.Add(_producto);
            _tipoNota.CatProductos2.Add(_producto);

            int resultado = contexto.SaveChanges();

            producto = ProductoDTO.ToDTO(_producto);
            return resultado != 0;
        }

        public bool GuardarTipoCatalogo(ref TipoCatalogoDTO tipoCatalogo)
        {
            int id = tipoCatalogo.Id;
            TipoCatalogo _estatus = contexto.TipoCatalogoes.FirstOrDefault(e => e.Id == id);
            if (_estatus == null)
            {
                _estatus = new TipoCatalogo();
                contexto.TipoCatalogoes.Add(_estatus);
            }

            _estatus.Nombre = tipoCatalogo.Nombre;

            int resultado = contexto.SaveChanges();
            tipoCatalogo = TipoCatalogoDTO.ToDTO(_estatus);
            return resultado != 0;
        }

        public bool GuardarTipoEstatus(ref TipoEstatusDTO tipo)
        {
            int id = tipo.Id;

            TipoEstatus _tipo = contexto.TipoEstatus1.FirstOrDefault(t => t.Id == id);
            if (_tipo == null)
            {
                _tipo = new TipoEstatus();
                contexto.TipoEstatus1.Add(_tipo);
            }
            _tipo.Nombre = tipo.Nombre;
            int resultado = contexto.SaveChanges();
            tipo = TipoEstatusDTO.ToDTO(_tipo);
            return resultado != 0;
        }

        public CatalogosDTO ObtenerCatalogos(CatalogoDTO catalogo)
        {
            CatalogosDTO resultado = new CatalogosDTO();
            if (catalogo.Id != 0)
            {
                resultado.AddRange(CatalogosDTO.ToDTO(contexto.Catalogoes.Where(c => c.Id == catalogo.Id).ToList()));
            }
            else if (catalogo.IdTipoCatalogo != 0)
            {
                resultado.AddRange(CatalogosDTO.ToDTO(
                    contexto.Catalogoes.Where(c => c.IdTipoCatalogo == catalogo.IdTipoCatalogo).ToList()
                    ));
            }
            else if (!string.IsNullOrEmpty(catalogo.Nombre))
            {
                resultado.AddRange(CatalogosDTO.ToDTO(
                    contexto.Catalogoes.Where(c => c.Nombre.ToUpper().Contains(catalogo.Nombre.ToUpper())).ToList()
                    ));
            }
            else
            {
                resultado.AddRange(CatalogosDTO.ToDTO(contexto.Catalogoes.ToList()));
            }
            return resultado;
        }

        public EstatusesDTO ObtenerEstatuses(EstatusDTO estatus)
        {
            EstatusesDTO resultado = new EstatusesDTO();
            if (estatus.Id != 0)
            {
                resultado.AddRange(EstatusesDTO.ToDTO(contexto.Estatus1.Where(e => e.Id == estatus.Id).ToList()));
            }
            else if (estatus.IdTipoEstatus != 0)
            {
                resultado.AddRange(EstatusesDTO.ToDTO(contexto.Estatus1.Where(e => e.IdTipoEstatus == estatus.IdTipoEstatus).ToList()));
            }
            else if (!string.IsNullOrEmpty(estatus.Nombre))
            {
                resultado.AddRange(EstatusesDTO.ToDTO(
                    contexto.Estatus1.Where(e => e.Nombre.ToUpper().Contains(estatus.Nombre.ToUpper())).ToList()));
            }
            return resultado;
        }

        public ProductosDTO ObtenerProductos(ProductoDTO producto)
        {
            ProductosDTO resultado = new ProductosDTO();
            if (producto.Id != 0)
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.Where(p => p.Id == producto.Id).ToList()));
            }
            else if (producto.IdCatalogo != 0)
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.Where(p => p.IdCatalogo == producto.IdCatalogo).ToList()));
            }
            else if (producto.IdEstatus != 0)
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.Where(p => p.IdEstatus == producto.IdEstatus).ToList()));
            }
            else if (producto.IdTipoNota != 0)
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.Where(p => p.IdTipoNota == producto.IdTipoNota).ToList()));
            }
            else if (!string.IsNullOrEmpty(producto.Sku))
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.Where(p => p.sku.ToUpper().Contains(producto.Sku.ToUpper())).ToList()));
            }
            else if (!string.IsNullOrEmpty(producto.Nombre))
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.Where(p => p.Nombre.ToUpper().Contains(producto.Nombre.ToUpper())).ToList()));
            }
            else
            {
                resultado.AddRange(ProductosDTO.ToDTO(contexto.Productoes.ToList()));
            }
            return resultado;
        }

        public TiposCatalogosDTO ObtenerTiposCatalogos(TipoCatalogoDTO tipoCatalogo)
        {
            TiposCatalogosDTO resultado = new TiposCatalogosDTO();
            if (tipoCatalogo.Id != 0)
            {
                resultado.AddRange(TiposCatalogosDTO.ToDTO(contexto.TipoCatalogoes.Where(t => t.Id == tipoCatalogo.Id).ToList()));
            }
            else if (!string.IsNullOrEmpty(tipoCatalogo.Nombre))
            {
                resultado.AddRange(TiposCatalogosDTO.ToDTO(contexto.TipoCatalogoes.Where(t => t.Nombre.ToUpper().Contains(tipoCatalogo.Nombre.ToUpper())).ToList()));
            }
            else
            {
                resultado.AddRange(TiposCatalogosDTO.ToDTO(contexto.TipoCatalogoes.ToList()));
            }
            return resultado;
        }

        public TiposEstatusDTO ObtenerTiposEstatus(TipoEstatusDTO tipo)
        {
            TiposEstatusDTO resultado = new TiposEstatusDTO();
            if (tipo.Id != 0)
            {
                resultado.AddRange(TiposEstatusDTO.ToDTO(contexto.TipoEstatus1.Where(t => t.Id == tipo.Id).ToList()));
            }
            else if (!string.IsNullOrEmpty(tipo.Nombre))
            {
                resultado.AddRange(TiposEstatusDTO.ToDTO(contexto.TipoEstatus1.Where(t => t.Id == tipo.Id).ToList()));
            }
            else
            {
                resultado.AddRange(TiposEstatusDTO.ToDTO(contexto.TipoEstatus1.ToList()));
            }
            return resultado;
        }
    }
}
