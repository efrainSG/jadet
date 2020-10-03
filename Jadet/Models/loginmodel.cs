using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jadet.Models {
    public class loginmodel {
        public string usuario { get; set; }
        public Guid usrguid { get; set; }
        public string password { get; set; }
        public int ErrorNumero { get; set; }
        public string ErrorMensaje { get; set; }
    }
}