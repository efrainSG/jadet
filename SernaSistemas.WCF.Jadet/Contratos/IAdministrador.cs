using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace SernaSisitemas.Jadet.WCF.Contratos
{
    [ServiceContract]
    public interface IAdministrador
    {
        [OperationContract]
        object guardarCliente(object request);
        [OperationContract]
        object bajaCliente(object request);
        [OperationContract]
        object cargarCliente(object request);

        [OperationContract]
        object subirFotos(object request);
        [OperationContract]
        object cargarHistorialCliente(object request);

        [OperationContract]
        object guardarProducto(object request);
        [OperationContract]
        object bajaProducto(object request);
        [OperationContract]
        object cargarProducto(object request);
        [OperationContract]
        object listarProductos(object request);

        [OperationContract]
        object listarNotas(object request);
        [OperationContract]
        object verNota(object request);
        [OperationContract]
        object borrarNota(object request);


        [OperationContract]
        object generarGuias(object request);
        [OperationContract]
        object enviarRecordatorios(object request);
        [OperationContract]
        object altaCliente(object request);

        [OperationContract]
        object cambiarEstatusPagina(object request);
    }
}
