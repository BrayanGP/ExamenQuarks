using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_Examen
{
    public class Helper
    {
        protected examenEntities miContexto;
        public Helper()
        {
            miContexto = new examenEntities();
        }
        public List<Entidades> consultarUnCP(int DCP)
        {
            List<Entidades> _list = new List<Entidades>();

            foreach(var dom in miContexto.DomicilioConsulta.Where(x => x.codigoPostal == DCP).ToList())
            {
                Entidades datos = new Entidades()
                {
                    id=dom.id,                   
                    codigoPostal = dom.codigoPostal,
                    colonia = dom.colonia,
                    municipio = dom.municipio,
                    ciudad = dom.ciudad,
                    estado = dom.estado

                };
                _list.Add(datos);
            }
            return _list;
        }
    }
}