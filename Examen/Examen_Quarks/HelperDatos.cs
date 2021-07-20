
using Examen_Quarks.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Quarks
{
    public class HelperDatos
    {
        public ModeloData miContexto;
        
        public HelperDatos()
        {
            miContexto=new ModeloData();
        }
        public List<cliente> consultarCliente()
        {
            miContexto.Configuration.LazyLoadingEnabled = true;
            miContexto.Configuration.ProxyCreationEnabled = true;
            return miContexto.cliente.ToList();
        }
        public List<contacto> consultarContacto()
        {
            miContexto.Configuration.LazyLoadingEnabled = true;
            miContexto.Configuration.ProxyCreationEnabled = true;
            return miContexto.contacto.ToList();
        }
        public cliente consultarUnCliente(int id)
        {
            miContexto.Configuration.LazyLoadingEnabled = true;
            miContexto.Configuration.ProxyCreationEnabled = true;
            return miContexto.cliente.Where(x => x.id == id).FirstOrDefault();
        }
        public List<cliente> consultarClientes(string nombre,string aP, string aM,string fN)
        {
            miContexto.Configuration.LazyLoadingEnabled = true;
            miContexto.Configuration.ProxyCreationEnabled = true;
            //return miContexto.cliente.Where(x => x.nombre.Contains(nombre)).ToList();


            return miContexto.cliente.Where(x => x.nombre.Contains(nombre) && x.apellidoPaterno.Contains(aP) && x.apellidoMaterno.Contains(aM) && x.fechaNacimiento.Contains(fN) ).ToList();
        }
        public contacto consultarUnContacto(int id)
        {
            miContexto.Configuration.LazyLoadingEnabled = true;
            miContexto.Configuration.ProxyCreationEnabled = true;
            return miContexto.contacto.Where(x => x.id == id).FirstOrDefault();
        }
        public void eliminarCliente(int id)
        {
            miContexto.cliente.Remove(consultarUnCliente(id));
            miContexto.SaveChanges();
        }
        public void eliminarDomicilio(int id)
        {
            miContexto.domicilio.Remove(miContexto.domicilio.Where(x => x.id == id).FirstOrDefault());
            miContexto.SaveChanges();
        }
        public void eliminarContacto(int id)
        {
            miContexto.contacto.Remove(miContexto.contacto.Where(x => x.id == id).FirstOrDefault());
            miContexto.SaveChanges();
        }
        public void crearCliente(cliente client)
        {
            miContexto.cliente.Add(client);
            miContexto.SaveChanges();
        }
        public void crearDomicilio(domicilio domicilio)
        {
            miContexto.domicilio.Add(domicilio);
            miContexto.SaveChanges();
        }
        public void crearContacto(contacto contacto)
        {
            miContexto.contacto.Add(contacto);
            miContexto.SaveChanges();
        }
        public void actualizarCliente(cliente client)
        {
            miContexto.Entry<cliente>(client).State = System.Data.Entity.EntityState.Modified;
            miContexto.SaveChanges();
        }
        public void actualizarDomicilio(domicilio domi)
        {
            miContexto.Entry<domicilio>(domi).State = System.Data.Entity.EntityState.Modified;
            miContexto.SaveChanges();
        }
        public void actualizarContacto(contacto contac)
        {
            miContexto.Entry<contacto>(contac).State = System.Data.Entity.EntityState.Modified;
            miContexto.SaveChanges();
        }

        public List<DomicilioConsulta> consultarUnCP(int DCP)
        {

            Service2Client con = new Service2Client();
            List<DomicilioConsulta> _lisDom = new List<DomicilioConsulta>();
            con.Open();
            foreach (var li in con.consultarUnCP(DCP))
            {
                DomicilioConsulta Dom = new DomicilioConsulta()
                {
                    id = li.id,
                    codigoPostal = li.codigoPostal,
                    colonia = li.colonia,
                    municipio = li.municipio,
                    ciudad = li.ciudad,
                    estado = li.estado
                };
                _lisDom.Add(Dom);
            }
            con.Close();
            return _lisDom.ToList();
            //List<DomicilioConsulta> n = new List<DomicilioConsulta>();
            //return n;

        }
        public void insertarCP(List<DomicilioConsulta> DCP)
        {
            if (miContexto.DomicilioConsulta.Count()==0) {
                miContexto.DomicilioConsulta.AddRange(DCP);
                miContexto.SaveChanges();

            }

        }

    }
}
