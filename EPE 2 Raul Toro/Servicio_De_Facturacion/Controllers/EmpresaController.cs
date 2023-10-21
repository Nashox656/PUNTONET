using Microsoft.AspNetCore.Mvc;

namespace Servicio_De_Facturacion
{
    [ApiController]
    //Creamos el array de Empresa

    public class Empresas : ControllerBase{
        public Empresa[] DatosEmpresa = new Empresa[]{

            new Empresa{
                ID=1,NombreEmpresa="Sodexo", RutEmpresa=96556930, GiroEmpresa="Empresa de Comida", TotalDeVentas=300, MontoDinero=3000000, MontoIVA=0.19f, MontoDeUtilidades=0.2f
            },
            new Empresa{
                ID=2,NombreEmpresa="McDonalds", RutEmpresa=96620260, GiroEmpresa="Comida Rapida", TotalDeVentas=300, MontoDinero=3000000, MontoIVA=0.19f, MontoDeUtilidades=0.2f
            },
            new Empresa{
                ID=3,NombreEmpresa="Lider", RutEmpresa=76134946, GiroEmpresa="Supermercado", TotalDeVentas=300, MontoDinero=3000000, MontoIVA=0.19f, MontoDeUtilidades=0.2f
            },
            new Empresa{
                ID=4,NombreEmpresa="Hyundai", RutEmpresa=76758790, GiroEmpresa="Vehiculos", TotalDeVentas=300, MontoDinero=3000000, MontoIVA=0.19f, MontoDeUtilidades=0.2f
            },
            new Empresa{
                ID=5,NombreEmpresa="Cinemark", RutEmpresa=96659800, GiroEmpresa="Cine", TotalDeVentas=300, MontoDinero=3000000, MontoIVA=0.19f, MontoDeUtilidades=0.2f
            }

        };

        //Creamos el metodo GET

        [HttpGet]
        [Route("Listar")]

        public IActionResult ConsultarEmpresa(){
        
            if(DatosEmpresa != null){

                for(int i = 0; i < DatosEmpresa.Length; i++){
                    Console.WriteLine(DatosEmpresa[i]);

           }
           return StatusCode(200,DatosEmpresa);
            }else{

                return StatusCode(400,"No se encontraron datos.");

            };
     }

     //Creamos el metodo GET para busquedas particulares

     [HttpGet]
     [Route("Listar/{ID}")]

     public IActionResult ConsultarPorGiro(int ID){

        try{
            
            if (ID != DatosEmpresa.Length){
                return StatusCode(200,DatosEmpresa[ID-1]);
            }else{
                return StatusCode(400, "No se ha encontrado.");
            }
        }catch(Exception ){

        }

        return StatusCode(200);



     }

     //Creamos el metodo POST para cambiar datos

     [HttpPost]
     [Route("Cambiar")]

     public IActionResult Guardar([FromBody]Empresa empresa){

        try{
       new Empresa{
                ID=4,NombreEmpresa="Hyundai", RutEmpresa=76758790, GiroEmpresa="Vehiculos", TotalDeVentas=300, MontoDinero=3000000, MontoIVA=0, MontoDeUtilidades=0
            };
       return StatusCode(200);
    }catch(Exception ){
      return StatusCode(400, "No se pudo crear la Empresa");
    }

     }

     //Creamos el metodo PUT para editar datos

     [HttpPut]
     [Route("Editar")]

     public IActionResult Editar(int ID, [FromBody] Empresa empresa){

        if (ID > 0 && ID <= DatosEmpresa.Length){

            DatosEmpresa[ID-1].NombreEmpresa = empresa.NombreEmpresa;
            DatosEmpresa[ID-1].RutEmpresa = empresa.RutEmpresa;
            DatosEmpresa[ID-1].GiroEmpresa = empresa.GiroEmpresa;
            DatosEmpresa[ID-1].TotalDeVentas = empresa.TotalDeVentas;
            DatosEmpresa[ID-1].MontoDinero = empresa.MontoDinero;
            DatosEmpresa[ID-1].MontoIVA = empresa.MontoIVA;
            DatosEmpresa[ID-1].MontoDeUtilidades = empresa.MontoDeUtilidades;

            return StatusCode(200,DatosEmpresa[ID-1]);
        }else if(ID == 0){
            Console.WriteLine("Empresa no encontrada. ");
            return StatusCode(404);

        }else{
            Console.WriteLine("No se pudo editar la empresa. ");
            return StatusCode(400);

        }

     }

     //Creamos el metodo DELETE para eliminar datos

     [HttpDelete]
     [Route("Eliminar")]

     public IActionResult ELiminar(int GiroEmpresa){

        if (GiroEmpresa > 0 && GiroEmpresa <= DatosEmpresa.Length){
            DatosEmpresa[GiroEmpresa-1] = null;

            return StatusCode(200,DatosEmpresa);
        }else{
            Console.WriteLine("Empresa no encontrada. ");
            return StatusCode(404);
        }

     }


    }


}