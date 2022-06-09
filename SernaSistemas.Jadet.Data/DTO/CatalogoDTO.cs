﻿using SernaSistemas.Jadet.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.Data.DTO
{
    public class CatalogoDTO
    {
        public int Id { get; set; }
        public int IdTipoCatalogo { get; set; }
        public string Nombre { get; set; }

        public static CatalogoDTO ToDTO(dynamic catalogo)
        {
            return new CatalogoDTO
            {
                Id = catalogo.Id,
                IdTipoCatalogo = catalogo.IdTipoCatalogo,
                Nombre = catalogo.Nombre
            };
        }
    }

    public class CatalogosDTO : List<CatalogoDTO>
    {
        public static List<CatalogoDTO> ToDTO(List<Catalogo> catalogos) =>
            catalogos.Select(c => CatalogoDTO.ToDTO(c)).ToList();
    }
}