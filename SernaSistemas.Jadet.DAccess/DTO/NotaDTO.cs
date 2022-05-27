﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SernaSistemas.Jadet.DAccess.DTO
{
    public class NotaDTO
    {
        public int Folio { get; set; }
        public int IdTipo { get; set; }
        public int IdEstatus { get; set; }
        public int IdPaqueteria { get; set; }
        public Guid IdCliente { get; set; }
        public string Guia { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaEnvio { get; set; }
        public decimal MontoMXN { get; set; }
        public decimal MontoUSD { get; set; }
        public decimal SaldoMXN { get; set; }
        public decimal SaldoUSD { get; set; }

        public static NotaDTO ToDTO(dynamic nota)
        {
            return new NotaDTO
            {
                Fecha = nota.Fecha,
                FechaEnvio = nota.FechaEnvio,
                Folio = nota.Folio,
                IdTipo = nota.IdTipo,
                IdEstatus = nota.IdEstatus,
                IdPaqueteria = nota.IdPaqueteria,
                IdCliente = nota.IdCliente,
                Guia = nota.Guia,
                MontoMXN = nota.MontoMXN,
                MontoUSD = nota.MontoUSD,
                SaldoMXN = nota.SaldoMXN,
                SaldoUSD = nota.SaldoUSD
            };
        }
    }

    public class NotasDTO: List<NotaDTO>
    {
        public static List<NotaDTO> ToDTO(List<Nota> notas)
        {
            var _notas = new List<NotaDTO>();
            _notas.AddRange((List<NotaDTO>)notas.Select(n => NotaDTO.ToDTO(n)));
            return _notas;
        }
    }
}
