using Microsoft.AspNetCore.Mvc;

namespace Servicio_De_Facturacion
{

    //Creamos el array de Clientes
    public class ClienteController : ControllerBase{

     public Cliente[] DatosCliente = new Cliente[]{

        new Cliente{
            NombreCliente="Esteban", ApellidoCliente="Torres", EdadCliente=20, RutCliente="21.485.967-5"
        },
        new Cliente{
            NombreCliente="Maria", ApellidoCliente="Toro", EdadCliente=25, RutCliente="19.854.627-K"
        },
        new Cliente{
            NombreCliente="Benjamin", ApellidoCliente="Contreras", EdadCliente=21, RutCliente="20.497.243-9"
        }

     };

    }

}