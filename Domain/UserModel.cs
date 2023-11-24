using DataAccess;

namespace Domain
{
    public class UserModel
    {
        /* //Metodo funcional
        //metodo para editar perfil
        UserDao userProfile = new UserDao();
        public void EditUser(int id, String user, String pname, String sname, String papellido, String sapellido, String email, String posicion, String pass)
        {
            userProfile.EditProfile(id, user, pname, sname, papellido, sapellido, email, posicion, pass);
        }*/


        //Nuevo bloque
        private int id;
        private string user;
        private string pname;
        private string sname;
        private string papellido;
        private string sapellido;
        private string email;
        private string pass;
        //private string posicion;

        public UserModel(int id, string user, string pname, string sname, string papellido, string sapellido, string email, string pass)
        {
            this.id = id;
            this.user = user;
            this.pname = pname;
            this.sname = sname;
            this.papellido = papellido;
            this.sapellido = sapellido;
            this.email = email;
            this.pass = pass;
            //this.posicion = posicion;
        }

        public UserModel() { 
        
        }

        public string EditUserProfile() {
            userDao.EditProfile(id, user, pname, sname, papellido, sapellido, email, pass);
            LoginUser(user,pass);
            return "Tu perfil se ha actualizado correctamente";
        }
        //Fin nuevo Bloque

        //
        //
        //

        //metodo para validar login
        UserDao userDao = new UserDao();
        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }

        //Metodo para consultar paciente
        PatientsDao Patient = new PatientsDao();
        public bool ConsultarPaciente(string Id, string Nombre)
        {
            return Patient.ConsulPaciente(Id, Nombre);
        }

        //Metodo para consultar paciente
        PatientsDao labs = new PatientsDao();
        public bool ListarLaboratorios(string Id, string Exam, String Programa)
        {
            return labs.ListarLabs(Id, Exam, Programa);
        }


        //Metodo para llenar datagrid
        CitasDao Tabla = new CitasDao();
        public bool Llenartabla(String sede, String MEDT, String programa, DateTime Fechaini, DateTime Fechafin)
        {
            return Tabla.LlenarT(sede, MEDT, programa, Fechaini, Fechafin);
        }



        //Metodo para consultar procedimientos
        PatientsDao Proced = new PatientsDao();
        public bool ListarProcedimientos(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            return Proced.ListProcedures(Id, Fechaini, Fechafin, Service, Programa);
        }

        //Metodo para consultar CITAS
        PatientsDao Citas = new PatientsDao();
        public bool ListarCitas(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            return Citas.ListCitas(Id, Fechaini, Fechafin, Service, Programa);
        }


        //Metodo para consultar RIESGO
        PatientsDao Riesgo = new PatientsDao();
        public bool ConsultarRiesgo(String Id, String Exa)
        {
            return Riesgo.ConsulRiesgo(Id, Exa);
        }

    }
}