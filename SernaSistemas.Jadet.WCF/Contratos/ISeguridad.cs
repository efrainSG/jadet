using SernaSistemas.Jadet.WCF.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SernaSistemas.Jadet.WCF.Contratos {
    [ServiceContract]
    public interface ISeguridad {
        [OperationContract]
        LoginResponse IniciarSesion(LoginRequest request);
        [OperationContract]
        LoginResponse CerrarSesion(LoginRequest request);
        [OperationContract]
        UsuarioResponse cambiarPerfil(UsuarioRequest request);
    }
}
