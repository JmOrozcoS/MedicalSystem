using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Domain
{
    public class ServicesModel
    {

        //Metodo funcional
        ServicesDao servicesDao = new ServicesDao();
        public void EditTope(int id, string cantidad)
        {
            servicesDao.EditTope(id, cantidad);
        }
        
        //
        public void InsertTopes(int idServicio, int idContrato, string cantidadI)
        {
            servicesDao.InsertTope(idServicio, idContrato, cantidadI);
        }
        //

        private int id;
        private string cantidad;

        //
        private int idServicio;
        private int idContrato;
        private string cantidadI;


        public ServicesModel(int id, string cantidad)
        {
            this.id = id;
            this.cantidad = cantidad;
        }


        public ServicesModel(int idServicio, int idContrato, string cantidadI)
        {
            this.idServicio = idServicio;
            this.idContrato = idContrato;
            this.cantidadI = cantidadI;
        }


        public string InsertTopeI(){
            servicesDao.InsertTope(idServicio, idContrato, cantidadI);
            return "Se ha ingresado correctamente";
        }
        //

        public ServicesModel()
        {

        }

        public string EditCTope() {
            servicesDao.EditTope(id, cantidad);
            return "Se ha actualizado correctamente";
        }



        //Metodo para consultar topes
        ServicesDao Topes = new ServicesDao();
        public bool ConsultarTopes(string topes)
        {
            return Topes.ListTopes(topes);
        }



        //Metodo para consultar  
        ServicesDao Services = new ServicesDao();
        public bool ConsultarServicios(string Service)
        {
            return Services.ListServices(Service);
        }

    }
}
