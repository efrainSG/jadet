using SernaSistemas.Jadet.WCF.Modelos;
using System.ServiceModel;

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
