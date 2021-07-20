using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen_Quarks;

namespace AplicaccionWeb.Controllers
{
    public class PadreController : Controller
    {
        // GET: Padre
        protected HelperDatos datos = new HelperDatos();
        public ActionResult Index()
        {
            return View(datos.consultarCliente());
        }
        [HttpPost]
        public ActionResult Index(string nombre = "",string primerApellido = "",string segundoApellido = "",string fechaNacimiento = "")
        {
            if (nombre!="" || primerApellido != ""|| segundoApellido != ""|| fechaNacimiento != "")
            {
                return View(datos.consultarClientes(nombre, primerApellido, segundoApellido, fechaNacimiento));
            }
               
            return View(datos.consultarCliente());
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(FormCollection cliente)
        {
            var nombre = this.Request.Form["nombre"];
            var primerApellido = this.Request.Form["apellidoPaterno"];
            var apellidoMaterno = this.Request.Form["apellidoMaterno"];
            var fechaNacimiento = this.Request.Form["fechaNacimiento"];
            var calle = this.Request.Form["calle"];
            var numeroExterior = this.Request.Form["numeroExterior"];
            var numeroInterior = this.Request.Form["numeroInterior"];
            var codigoPostal = this.Request.Form["codigoPostal"];
            var colonia = this.Request.Form["colonia"];
            var municipio = this.Request.Form["municipio"];
            var ciudad = this.Request.Form["ciudad"];
            var estado = this.Request.Form["estado"];
            var NumTelefono = this.Request.Form["NumTelefono"];
            var numeroCelular = this.Request.Form["numeroCelular"];
            var correoElectronico = this.Request.Form["correoElectronico"];

          
            contacto contacto = new contacto()
            {
                NumTeleDomicilio = NumTelefono,
                celular = numeroCelular,
                correoElectronico = correoElectronico
            };
            domicilio domicilio = new domicilio()
            {
                calle = calle,
                numeroExterior=numeroExterior,
                numeroInterior = numeroInterior,
                codigoPostal =codigoPostal,
                colonia = colonia,
                municipio = municipio,
                ciudad = ciudad,
                estado =estado              
            };
            cliente client = new cliente()
            {
                nombre = nombre,
                apellidoPaterno = primerApellido,
                apellidoMaterno = apellidoMaterno,
                fechaNacimiento = fechaNacimiento,    

            };
            datos.crearDomicilio(domicilio);
            client.idDomicilio = domicilio.id;
            datos.crearCliente(client);
            contacto.idCliente = client.id;
            datos.crearContacto(contacto);

            return RedirectToAction("Index");
        }
        
        public JsonResult buscarRFC(string CP)
        {
            return Json(datos.consultarUnCP(Convert.ToInt32( CP)), JsonRequestBehavior.AllowGet);

        }
        public ActionResult cargarXML()
        {
            List<DomicilioConsulta> _lstDomicilio = new List<DomicilioConsulta>();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(Server.MapPath("~/Hidalgo.xml"), XmlReadMode.ReadSchema);
            var myTable = dataSet.Tables[0];
            foreach (DataRow item in myTable.Rows)
            {
                _lstDomicilio.Add(new DomicilioConsulta() {
                    codigoPostal =Convert.ToInt32( item["d_codigo"].ToString()),
                    municipio = item["D_mnpio"].ToString(),
                    colonia = item["d_asenta"].ToString(),
                    estado = item["d_estado"].ToString(),
                    ciudad = item["d_ciudad"].ToString()
                });

                
            }
            datos.insertarCP(_lstDomicilio);
            return RedirectToAction("create");
        }

        public ActionResult editar(int id)
        {
            var variable = datos.consultarUnContacto(id);
            ViewBag.colonias = datos.consultarUnCP(Convert.ToInt32(variable.cliente.domicilio.codigoPostal)) ?? new List<DomicilioConsulta>();
            return View(variable);

        }
        [HttpPost]
        public ActionResult editar(contacto contac)
        {
            //var variable = datos.consultarUnContacto(id);
            //ViewBag.colonias = datos.consultarUnCP(Convert.ToInt32(variable.cliente.domicilio.codigoPostal)) ?? new List<DomicilioConsulta>();
            datos.actualizarDomicilio(contac.cliente.domicilio);
            var upde = new cliente()
            {
                id = contac.cliente.id,
                nombre = contac.cliente.nombre,
                apellidoPaterno = contac.cliente.apellidoPaterno,
                apellidoMaterno = contac.cliente.apellidoMaterno,
                fechaNacimiento = contac.cliente.fechaNacimiento,
                idDomicilio = contac.cliente.idDomicilio
            };

            datos.actualizarCliente(upde);
            var updeC = new contacto()
            {
                id = contac.id,
                NumTeleDomicilio = contac.NumTeleDomicilio,
                celular = contac.celular,
                correoElectronico = contac.correoElectronico,
                idCliente = contac.idCliente
            };
            datos.actualizarContacto(updeC);
            


            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
           var resultados= datos.consultarUnContacto(id);
            var idcliente = resultados.idCliente;
            var idDomicilio = resultados.cliente.domicilio.id;
                datos.eliminarContacto(resultados.id);
            
            datos.eliminarCliente((int)idcliente);
            datos.eliminarDomicilio(idDomicilio);


            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var variable = datos.consultarUnContacto(id);
            ViewBag.colonias = datos.consultarUnCP(Convert.ToInt32(variable.cliente.domicilio.codigoPostal)) ?? new List<DomicilioConsulta>();
            return View(variable);

        }
     
    }
}