using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.PeerResolvers;
using System.Web;

namespace Jadet.Models
{
    public class clientemodel
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public string Nombre { get; set; }
        public int ErrorNumero { get; set; }
        public string ErrorMensaje { get; set; }
    }
    public class listaclientesmodel
    {
        public List<clientemodel> Items { get; set; }
        public listaclientesmodel()
        {
            Items = new List<clientemodel>();
        }
    }
}