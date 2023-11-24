using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Domain
{
    public class PatientModel
    {
        //Metodo para consultar contratos de paciente selecionado
        PatientsDao Contrato = new PatientsDao();
        public bool ConsultarContrato(String Id)
        {
            return Contrato.ListContratos(Id);
        }


        //Metodo para consultar contratos
        PatientsDao ContratoAll = new PatientsDao();
        public bool ConsultarContratoAll()
        {
            return ContratoAll.ListAllContratos();
        }

        //Metodo para consultar contratos individuales
        PatientsDao ContratoAllInd = new PatientsDao();
        public bool ConsultarContratoAllInd()
        {
            return ContratoAllInd.ListAllContratosInd();
        }


        //Metodo para consultar 
        CitasParamedicos citasO = new CitasParamedicos();
        public bool ConsultarCitasOdon(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            return citasO.ListarCitasOdon(Id,  Fechaini,  Fechafin,  Service, Programa);
        }

        //Metodo para consultar 
        CitasParamedicos citasPs = new CitasParamedicos();
        public bool ConsultarCitasPsico(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            return citasPs.ListarCitasPsico(Id, Fechaini, Fechafin, Service, Programa);
        }

        //Metodo para consultar Eenfermeria
        CitasParamedicos citasEn = new CitasParamedicos();
        public bool ConsultarCitasEnfer(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            return citasEn.ListarCitasEnfermeria(Id, Fechaini, Fechafin, Service, Programa);
        }

        //Metodo para consultar 
        CitasParamedicos citasQ = new CitasParamedicos();
        public bool ConsultarCitasQuimi(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            return citasQ.ListarCitasQuimico(Id, Fechaini, Fechafin, Service, Programa);
        }

        //Metodo para consultar 
        CitasParamedicos citasN = new CitasParamedicos();
        public bool ConsultarCitasNurti(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            return citasN.ListarCitasNutricion(Id, Fechaini, Fechafin, Service, Programa);
        }

        //Metodo para consultar  CitasTsocial
        CitasParamedicos citasTs = new CitasParamedicos();
        public bool ConsultarCitasTs(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            return citasTs.ListarCitasTsocial(Id, Fechaini, Fechafin, Service, Programa);
        }


        //
        //
        //

        //Metodo para consultar  Citas Medicia General
        CitasMedicos citasG = new CitasMedicos();
        public bool ConsultarCitasG(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            return citasG.ListarCitasGeneral(Id, Fechaini, Fechafin, Service, Programa);
        }

        //Metodo para consultar  Citas Medicia Interna
        CitasMedicos citasI = new CitasMedicos();
        public bool ConsultarCitasI(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            return citasI.ListarCitasInterna(Id, Fechaini, Fechafin, Service, Programa);
        }

        //Metodo para consultar  Citas Infectologia
        CitasMedicos citasInf = new CitasMedicos();
        public bool ConsultarCitasInfecto(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            return citasInf.ListarCitasInfecto(Id, Fechaini, Fechafin, Service, Programa);
        }

        //Metodo para consultar  Citas Infectologia
        CitasParamedicos citasInas = new CitasParamedicos();
        public bool ConsultarInasistentes(String Id, String Nombre, String Service, String Programa, String Especialidad)
        {
            return citasInas.ListarInasistentes(Id, Nombre, Service, Programa, Especialidad);
        }

        //Metodo para consultar Especialidades
        PatientsDao Especialidad = new PatientsDao();
        public bool ConsultarEspecialidad()
        {
            return Especialidad.ListEspecialidades();
        }

        PatientsDao Criterios= new PatientsDao();
        public bool ConsultarC(String Identy)
        {
            return Criterios.ConsulCriterios(Identy);
        }


    }
}
