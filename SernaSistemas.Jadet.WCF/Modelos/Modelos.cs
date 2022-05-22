using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SernaSistemas.Jadet.WCF.Modelos
{
    [DataContract]
    public class BaseRequest
    {

    }

    [DataContract]
    public class BaseResponse
    {
        [DataMember]
        public int ErrorNumero { get; set; }
        [DataMember]
        public string ErrorMensaje { get; set; }
        public BaseResponse()
        {
            ErrorNumero = 0;
            ErrorMensaje = string.Empty;
        }
    }

    [DataContract]
    public class ArchivoRequest : BaseRequest
    {
        [DataMember]
        public string Ruta { get; set; }
        [DataMember]
        public string TipoArchivo { get; set; }
        [DataMember]
        public int Longitud { get; set; }
        [DataMember]
        public DateTime FechaCarga { get; set; }
        [DataMember]
        public DateTime UltimaModificacion { get; set; }

        public static ArchivoRequest ToRequest(dynamic archivo)
        {
            if (archivo != null)
            {
                return new ArchivoRequest
                {
                    FechaCarga = archivo.FechaCarga,
                    Longitud = archivo.Longitud,
                    Ruta = archivo.Ruta,
                    TipoArchivo = archivo.TipoArchivo,
                    UltimaModificacion = archivo.UltimaModificacion
                };
            }
            else
                return new ArchivoRequest();
        }
    }

    [DataContract]
    public class ArchivoResponse : BaseResponse
    {

    }

    [DataContract]
    public class CatalogoRequest : BaseRequest
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int IdTipoCatalogo { get; set; }

        public static CatalogoRequest ToRequest(dynamic catalogo)
        {
            if (catalogo != null)
            {
                return new CatalogoRequest
                {
                    Id = catalogo.Id,
                    Nombre = catalogo.Nombre,
                    IdTipoCatalogo = catalogo.IdTipoCatalogo
                };
            }
            else
            {
                return new CatalogoRequest();
            }
        }
    }

    [DataContract]
    public class CatalogoResponse : BaseResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int IdTipoCatalogo { get; set; }

        public static CatalogoResponse ToResponse(dynamic catalogo)
        {
            if (catalogo != null)
            {
                return new CatalogoResponse
                {
                    IdTipoCatalogo = catalogo.IdTipoCatalogo,
                    Nombre = catalogo.Nombre,
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    Id = catalogo.Id
                };
            }
            else
            {
                return new CatalogoResponse();
            }
        }
    }

    [DataContract]
    public class ColeccionCatalogoResponse : BaseResponse
    {
        [DataMember]
        public List<CatalogoResponse> Items { get; set; }
        public ColeccionCatalogoResponse()
        {
            Items = new List<CatalogoResponse>();
        }
    }

    [DataContract]
    public class TipoCatalogoResponse : BaseResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }

        public static TipoCatalogoResponse ToResponse(dynamic catalogo)
        {
            if (catalogo != null)
            {
                return new TipoCatalogoResponse
                {
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    Id = catalogo.Id,
                    Nombre = catalogo.Nombre
                };
            }
            else
            {
                return new TipoCatalogoResponse();
            }
        }
    }

    [DataContract]
    public class TipoCatalogoRequest : BaseRequest
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }

        public static TipoEstatusRequest ToRequest(dynamic tipoEstatus)
        {
            if (tipoEstatus != null)
            {
                return new TipoEstatusRequest
                {
                    Nombre = tipoEstatus.Nombre,
                    Id = tipoEstatus.Id
                };
            }
            else
            {
                return new TipoEstatusRequest();
            }
        }
    }

    [DataContract]
    public class ColeccionTipoCatalogoResponse : BaseResponse
    {
        [DataMember]
        public List<TipoCatalogoResponse> Items { get; set; }
        public ColeccionTipoCatalogoResponse()
        {
            Items = new List<TipoCatalogoResponse>();
        }
    }

    [DataContract]
    public class EstatusRequest : BaseRequest
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int IdTipoEstatus { get; set; }

        public static EstatusRequest ToRequest(dynamic estatus)
        {
            if (estatus != null)
            {
                return new EstatusRequest
                {
                    Id = estatus.Id,
                    IdTipoEstatus = estatus.IdTipoEstatus,
                    Nombre = estatus.Nombre
                };
            }
            else
            {
                return new EstatusRequest();
            }
        }
    }

    [DataContract]
    public class EstatusResponse : BaseResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int IdTipoEstatus { get; set; }

        public static EstatusResponse ToResponse(dynamic estatus)
        {
            if (estatus != null)
            {
                return new EstatusResponse
                {
                    ErrorMensaje = string.Empty,
                    ErrorNumero = 0,
                    IdTipoEstatus = estatus.IdTipoEstatus,
                    Id = estatus.Id,
                    Nombre = estatus.Nombre
                };
            }
            else
            {
                return new EstatusResponse();
            }
        }
    }

    [DataContract]
    public class ColeccionEstatusResponse : BaseResponse
    {
        [DataMember]
        public List<EstatusResponse> Items { get; set; }
        public ColeccionEstatusResponse()
        {
            Items = new List<EstatusResponse>();
        }
    }

    [DataContract]
    public class TipoEstatusRequest : BaseRequest
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }

        public static TipoCatalogoRequest ToRequest(dynamic tipoCatalogo)
        {
            if (tipoCatalogo != null)
            {
                return new TipoCatalogoRequest
                {
                    Nombre = tipoCatalogo.Nombre,
                    Id = tipoCatalogo.Id
                };
            }
            else
            {
                return new TipoCatalogoRequest();
            }
        }
    }

    [DataContract]
    public class TipoEstatusResponse : BaseResponse
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }

        public static TipoEstatusResponse ToRequest(dynamic tipoEstatus)
        {
            if (tipoEstatus != null)
            {
                return new TipoEstatusResponse
                {
                    Nombre = tipoEstatus.Nombre,
                    Id = tipoEstatus.Id
                };
            }
            else
            {
                return new TipoEstatusResponse();
            }
        }
    }

    [DataContract]
    public class ColeccionTipoEstatusResponse : BaseResponse
    {
        [DataMember]
        public List<TipoEstatusResponse> Items { get; set; }
        public ColeccionTipoEstatusResponse()
        {
            Items = new List<TipoEstatusResponse>();
        }
    }
}
