using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common.Cache;
using System.Data;


namespace DataAccess
{
    public class PatientsDao : ConnectionToSql
    {

        //Metodo con parametros para consultar paciente
        public bool ConsulPaciente(String Id, String Nombre)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "select top 10 pa.tipoidentificacion as TipoID,  pa.identificacion as Identificacion, pa.nombrecompleto as Nombres from paciente pa INNER JOIN PACIENTEASEGURADO PAS ON pa.id = PAS.idpaciente INNER JOIN FC_CONTRATO CONT ON PAS.idcontrato = CONT.id LEFT JOIN MEDICO MED ON pa.idmedicotratante = MED.id where pa.identificacion like ('%' + @id + '%') and pa.nombrecompleto like ('%' + @nombre + '%') and pas.estado = 'A' group by pa.tipoidentificacion,  pa.identificacion, pa.nombrecompleto";
                    Command.Parameters.AddWithValue("@id", Id);
                    Command.Parameters.AddWithValue("@nombre", Nombre);
                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        PatientsCache.Tabla = dt;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }


        //Metodo con parametros para consultar laboratorios
        public bool ListarLabs(String Id, String Exam, String Programa)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "select CASE "+

"WHEN EXA.nombre like '%TRANSAMINASA%' AND EXA.nombre LIKE '%TGO-AST%' THEN 'TRANSAMINASA (TGO)' "+
"WHEN EXA.nombre like '%TRANSAMINASA GLUTAMICO PIRUVICA O ALANINO AMINO TRANSFERASA (TGP-ALT)%' THEN 'TRANSAMINASA (TGP)' " +

"WHEN EXA.nombre like '%PROTEINA C REACTIVA%' and EXA.nombre LIKE '%ALTA PRECISI%' THEN 'PROTEINA C REACTIVA CUANTITATIVA' " +
"WHEN EXA.nombre like '%PROTEINA C REACTIVA%' and EXA.nombre LIKE '%SEMICUANTITATIVA%' THEN 'PROTEINA C REACTIVA SEMICUANTITATIVA' " +

"WHEN EXA.nombre like '%FACTOR REMATOIDEO%' THEN 'FACTOR REMATOIDEO' " +

"WHEN EXA.nombre like '%HEPATITIS B%' and EXA.nombre LIKE '%ANTI-CORE%' THEN 'HEPATITIS B ANTI-CORE' " +
"ELSE EXA.nombre " +

"END as 'Nombre del Examen', " +
                        "convert(date,max(RES.fechainicio)) as 'Último realizado', convert(date,max(dateadd(day, tope.cantidad,RES.fechainicio))) as 'Fecha Proyección', " +
                    "CASE " +
                        "WHEN max(dateadd(day, tope.cantidad, RES.fechainicio)) <= GETDATE() THEN 'VENCIDO' " +
                        "WHEN max(dateadd(day, tope.cantidad, RES.fechainicio)) >= GETDATE()+1 and max(dateadd(day, tope.cantidad, RES.fechainicio)) < GETDATE()+15  THEN 'POR VENCER' "+
                        "WHEN max(dateadd(day, tope.cantidad, RES.fechainicio)) > GETDATE() THEN 'OK' " +
                    "END as Estado " +
                    "FROM FC_FACTURA FAC " +
                    "INNER JOIN dbo.PACIENTEASEGURADO PAS ON FAC.idpacienteasegurado = PAS.id " +
                    "INNER JOIN PACIENTE PAC ON PAS.idpaciente = PAC.id " +
                    "INNER JOIN FC_CONTRATO CON ON PAS.idcontrato = CON.id " +
                    "INNER JOIN FC_SERVICIOPRESTADO SEP ON FAC.id = SEP.idfactura " +
                    "INNER JOIN FC_SERVICIO SER ON SEP.idservicio = SER.id " +
                    "INNER JOIN LB_RESULTADO RES ON SEP.id = RES.idservicioprestado " +
                    "INNER JOIN LB_RESULTADODETALLE RED ON RES.id = RED.idresultado " +
                    "INNER JOIN LB_EXAMENITEM EXI ON RED.idexamenitem = EXI.id " +
                    "INNER JOIN LB_AREAPROCESO ARP ON EXI.idareaproceso = ARP.id " +
                    "INNER JOIN LB_EXAMEN EXA ON RES.idexamen = EXA.id " +
                    //"LEFT JOIN FC_TOPESERVICIO tope ON concat(SEP.idservicio, CON.id) = concat(tope.idservicio, tope.idcontrato) " +
                    "LEFT JOIN vitalapps.dbo.FC_VTOPES tope ON concat(SER.id, CON.id) = concat(tope.idservicio, tope.idcontrato)" +
                    "WHERE (pac.tipoidentificacion+pac.identificacion) = @identy and SER.nombre like('%' + @Examen + '%') and RES.estado in('R','A') " +
                    "and CON.contrato like('%' + @programa + '%') " +
                    "GROUP BY EXA.nombre order by ESTADO DESC";
                    Command.Parameters.AddWithValue("@identy", Id);
                    Command.Parameters.AddWithValue("@Examen", Exam);
                    Command.Parameters.AddWithValue("@programa", Programa);
                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        PatientsCache.Tablalab = dt;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

        //Metodo con parametros para consultar procedures
        public bool ListProcedures(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "Select " +
                    "CASE " +

"WHEN SER.nombre like '%TUBERCULINA%' and SER.nombre like '%LECTURA%'  THEN 'TUBERCULINA - PPD (LECTURA)' "+
"WHEN SER.nombre like '%TUBERCULINA%' THEN 'TUBERCULINA - PPD' " +

"WHEN SER.nombre like '%VAGINAL%' and SER.nombre like '%LECTURA%'  THEN 'CITOLOGIA VAGINAL (LECTURA)' " +
"WHEN SER.nombre like '%VAGINAL%' THEN 'CITOLOGIA VAGINAL' " +

"WHEN SER.nombre like '%CITOLO%' AND SER.nombre like '% ANAL%' and SER.nombre like '%LECTURA%'  THEN 'CITOLOGIA ANAL (LECTURA)' " +
"WHEN SER.nombre like '%CITOLO%' AND SER.nombre like '%ANAL%' THEN 'CITOLOGIA ANAL' " +
"ELSE SER.nombre " +

"END as 'Nombre del Procedimiento', " +
                    "convert(date,max(cita.fechaconfirmacion)) as 'Último realizado', " +
                    "convert(date,max(dateadd(day, tope.cantidad,cita.fechaconfirmacion))) as 'Fecha Proyección', " +
                    "CASE " +
                        "WHEN max(cita.estado) = 'RS' and max(cita.fechainicio) < GETDATE() THEN 'Reserva Vencida' " +
                        "WHEN max(cita.estado) = 'RS' and max(cita.fechainicio) > max(cita.fechaconfirmacion) THEN CONVERT(varchar,convert(date,max(cita.fechainicio)),(20)) " +
                        "WHEN max(cita.estado) = 'RS' and max(cita.fechainicio) = max(cita.fechainicio) THEN CONVERT(varchar,convert(date,max(cita.fechainicio)),(20)) " +
                        "WHEN max(cita.estado) <> 'RS' THEN 'Sin Reserva' " +
                    "END as 'Cita Reserva', " +
                    "CASE " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) <= GETDATE() THEN 'VENCIDO' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechainicio)) >= GETDATE()+1 and max(dateadd(day, tope.cantidad, cita.fechainicio)) < GETDATE()+15  THEN 'POR VENCER' "+
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) > GETDATE() THEN 'OK' " +
                    "END as Estado " +
                    "from dbo.PACIENTE PAC " +
                    "INNER JOIN dbo.PACIENTEASEGURADO CONT on PAC.id = CONT.idpaciente " +
                    "INNER JOIN dbo.FC_CONTRATO FCCONT on CONT.idcontrato = FCCONT.id " +
                    "INNER JOIN dbo.HC_CITA Cita on CONT.id = Cita.idpacienteasegurado " +
                    "RIGHT JOIN dbo.FC_SERVICIO SER on Cita.idservicio = SER.id " +
                    //"LEFT JOIN FC_TOPESERVICIO tope ON concat(SER.id, FCCONT.id) = concat(tope.idservicio, tope.idcontrato) " +
                    "LEFT JOIN vitalapps.dbo.FC_VTOPES tope ON concat(SER.id, FCCONT.id) = concat(tope.idservicio, tope.idcontrato)" +
                    "INNER JOIN FC_CLASESERVICIO CLA ON SER.idclaseservicio = CLA.id " +
                    "INNER JOIN FC_ESPECIALIDAD ES ON SER.idespecialidad = ES.id " +
                    "WHERE(pac.tipoidentificacion + pac.identificacion) = @identy " +
                    "and CLA.descripcion like '%PROCEDIMIENTO%' " +
                    "and cita.estado in ('AT', 'RS') " +
                    "and SER.nombre like('%' + @service + '%') " +
                    "and FCCONT.contrato like('%' + @programa + '%') " +
                    "AND cita.fechainicio >= @Fechaini " +
                    "AND cita.fechainicio <= @Fechafin " +
                    "GROUP BY " +
                    "ser.nombre " +
                    "order by ESTADO DESC";
                    Command.Parameters.AddWithValue("@identy", Id);
                    Command.Parameters.AddWithValue("@fechaini", Fechaini);
                    Command.Parameters.AddWithValue("@fechafin", Fechafin);
                    Command.Parameters.AddWithValue("@service", Service);
                    Command.Parameters.AddWithValue("@programa", Programa);

                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        PatientsCache.TablaProced = dt;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

        //Metodo con parametros para consultar procedures
        public bool ListCitas(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "Select " +
                    "CASE "+
"WHEN SER.nombre like '%SALUD FAMILIAR%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'SALUD FAMILIAR (CONTROL) (VIRTUAL)' " +
"WHEN SER.nombre like '%SALUD FAMILIAR%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'SALUD FAMILIAR (P. VEZ) (VIRTUAL)' " +
"WHEN SER.nombre like '%SALUD FAMILIAR%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESENCIAL%' THEN 'SALUD FAMILIAR (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%SALUD FAMILIAR%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESENCIAL%' THEN 'SALUD FAMILIAR (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%SALUD FAMILIAR%' AND SER.nombre like '%CONTROL%' THEN 'SALUD FAMILIAR (CONTROL)' " +
"WHEN SER.nombre like '%SALUD FAMILIAR%' AND SER.nombre like '%PRIMERA%' THEN 'SALUD FAMILIAR (P. VEZ)' " +
"WHEN SER.nombre like '%INFECTO%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'INFECTOLOGÍA (CONTROL) (VIRTUAL)' " +
"WHEN SER.nombre like '%INFECTO%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'INFECTOLOGÍA (P. VEZ) (VIRTUAL)' " +
"WHEN SER.nombre like '%INFECTO%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESENCIAL%' THEN 'INFECTOLOGÍA (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%INFECTO%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESENCIAL%' THEN 'INFECTOLOGÍA (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%INFECTO%' AND SER.nombre like '%CONTROL%' THEN 'INFECTOLOGÍA (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%INFECTO%' AND SER.nombre like '%PRIMERA%' THEN 'INFECTOLOGÍA (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%MEDICINA INTERNA%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'MEDICINA INTERNA (CONTROL) (VIRTUAL)' " +
"WHEN SER.nombre like '%MEDICINA INTERNA%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'MEDICINA INTERNA (P. VEZ) (VIRTUAL)' " +
"WHEN SER.nombre like '%MEDICINA INTERNA%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESENCIAL%' THEN 'MEDICINA INTERNA (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%MEDICINA INTERNA%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESENCIAL%' THEN 'MEDICINA INTERNA (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%MEDICINA INTERNA%' AND SER.nombre like '%CONTROL%' THEN 'MEDICINA INTERNA (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%MEDICINA INTERNA%' AND SER.nombre like '%PRIMERA%' THEN 'MEDICINA INTERNA (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%MEDICINA GENERAL%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'MEDICINA GENERAL (CONTROL) (VIRTUAL)' " +
"WHEN SER.nombre like '%MEDICINA GENERAL%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'MEDICINA GENERAL (P. VEZ) (VIRTUAL)' " +
"WHEN SER.nombre like '%MEDICINA GENERAL%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESEN%' THEN 'MEDICINA GENERAL (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%MEDICINA GENERAL%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESEN%' THEN 'MEDICINA GENERAL (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%MEDICINA GENERAL%' AND SER.nombre like '%CONTROL%' THEN 'MEDICINA GENERAL (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%MEDICINA GENERAL%' AND SER.nombre like '%PRIMERA%' THEN 'MEDICINA GENERAL (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%NUTRICION%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'NUTRICION (CONTROL) (VIRTUAL)' " +
"WHEN SER.nombre like '%NUTRICION%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'NUTRICION (P. VEZ) (VIRTUAL)' " +
"WHEN SER.nombre like '%NUTRICION%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESEN%' THEN 'NUTRICION (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%NUTRICION%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESEN%' THEN 'NUTRICION (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%NUTRICION%' AND SER.nombre like '%CONTROL%' THEN 'NUTRICION (CONTROL) (PRESENCIAL)'" +
"WHEN SER.nombre like '%NUTRICION%' AND SER.nombre like '%PRIMERA%' THEN 'NUTRICION (P. VEZ) (PRESENCIAL)' "+
"WHEN SER.nombre like '%PSICOLOGIA%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'PSICOLOGIA (CONTROL) (VIRTUAL)' "+
"WHEN SER.nombre like '%PSICOLOGIA%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'PSICOLOGIA (P. VEZ) (VIRTUAL)' " +
"WHEN SER.nombre like '%PSICOLOGIA%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESEN%' THEN 'PSICOLOGIA (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%PSICOLOGIA%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESEN%' THEN 'PSICOLOGIA (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%PSICOLOGIA%' AND SER.nombre like '%CONTROL%' THEN 'PSICOLOGIA (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%PSICOLOGIA%' AND SER.nombre like '%PRIMERA%' THEN 'PSICOLOGIA (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%ENFERMER%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'ENFERMERIA (CONTROL) (VIRTUAL)' " +
"WHEN SER.nombre like '%ENFERMER%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'ENFERMERIA (P. VEZ) (VIRTUAL)' " +
"WHEN SER.nombre like '%ENFERMER%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESEN%' THEN 'ENFERMERIA (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%ENFERMER%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESEN%' THEN 'ENFERMERIA (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%ENFERMER%' AND SER.nombre like '%CONTROL%' THEN 'ENFERMERIA (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%ENFERMER%' AND SER.nombre like '%PRIMERA%' THEN 'ENFERMERIA (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%FISIOTERAPIA%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'FISIOTERAPIA (CONTROL) (VIRTUAL)' " +
"WHEN SER.nombre like '%FISIOTERAPIA%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'FISIOTERAPIA (P. VEZ) (VIRTUAL)' " +
"WHEN SER.nombre like '%FISIOTERAPIA%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESEN%' THEN 'FISIOTERAPIA (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%FISIOTERAPIA%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESEN%' THEN 'FISIOTERAPIA (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%FISIOTERAPIA%' AND SER.nombre like '%CONTROL%' THEN 'FISIOTERAPIA (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%FISIOTERAPIA%' AND SER.nombre like '%PRIMERA%' THEN 'FISIOTERAPIA (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%TRABAJO SOCIAL%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'TRABAJO SOCIAL (CONTROL) (VIRTUAL)' " +
"WHEN SER.nombre like '%TRABAJO SOCIAL%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'TRABAJO SOCIAL (P. VEZ) (VIRTUAL)' " +
"WHEN SER.nombre like '%TRABAJO SOCIAL%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESEN%' THEN 'TRABAJO SOCIAL (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%TRABAJO SOCIAL%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESEN%' THEN 'TRABAJO SOCIAL (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%TRABAJO SOCIAL%' AND SER.nombre like '%CONTROL%' THEN 'TRABAJO SOCIAL (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%TRABAJO SOCIAL%' AND SER.nombre like '%PRIMERA%' THEN 'TRABAJO SOCIAL (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%ODONTOLO%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'ODONTOLOGIA (CONTROL) (VIRTUAL)' " +
"WHEN SER.nombre like '%ODONTOLO%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'ODONTOLOGIA (P. VEZ) (VIRTUAL)' " +
"WHEN SER.nombre like '%ODONTOLO%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESEN%' THEN 'ODONTOLOGIA (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%ODONTOLO%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESEN%' THEN 'ODONTOLOGIA (P. VEZ) (PRESENCIAL)' " +
"WHEN SER.nombre like '%ODONTOLO%' AND SER.nombre like '%CONTROL%' THEN 'ODONTOLOGIA (CONTROL) (PRESENCIAL)' " +
"WHEN SER.nombre like '%ODONTOLO%' AND SER.nombre like '%PRIMERA%' THEN 'ODONTOLOGIA (P. VEZ) (PRESENCIAL)' " +

"ELSE SER.nombre " +
"END as 'Nombre del Servicio', " +
                    "CASE " +
"WHEN MIN(cita.estado) = 'AT' THEN convert(date, max(cita.fechaconfirmacion)) " +
"END as 'Última Atencion'," +
                    "convert(date,max(dateadd(day, tope.cantidad,cita.fechaconfirmacion))) as 'Cita Proyectada', " +
                    "CASE " +
                        "WHEN max(cita.estado) = 'RS' and max(cita.fechainicio) < GETDATE() THEN 'Reserva Vencida' " +
                        "WHEN max(cita.estado) = 'RS' and max(cita.fechainicio) > max(cita.fechaconfirmacion) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) = 'RS' and max(cita.fechainicio) = max(cita.fechainicio) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) <> 'RS' THEN 'Sin Reserva' " +
                    "END as 'Cita Reserva', " +
                    "CASE " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) <= GETDATE() THEN 'VENCIDO' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechainicio)) >= GETDATE()+1 and max(dateadd(day, tope.cantidad, cita.fechainicio)) < GETDATE()+15  THEN 'POR VENCER' "+
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) > GETDATE() THEN 'OK' " +
                    "END as Estado " +
                    "from dbo.PACIENTE PAC " +
                    "INNER JOIN dbo.PACIENTEASEGURADO CONT on PAC.id = CONT.idpaciente " +
                    "INNER JOIN dbo.FC_CONTRATO FCCONT on CONT.idcontrato = FCCONT.id " +
                    "INNER JOIN dbo.HC_CITA Cita on CONT.id = Cita.idpacienteasegurado " +
                    "RIGHT JOIN dbo.FC_SERVICIO SER on Cita.idservicio = SER.id " +
                    //"LEFT JOIN FC_TOPESERVICIO tope ON concat(SER.id, FCCONT.id) = concat(tope.idservicio, tope.idcontrato) " +
                    "LEFT JOIN vitalapps.dbo.FC_VTOPES tope ON concat(SER.id, FCCONT.id) = concat(tope.idservicio, tope.idcontrato)" +
                    "INNER JOIN FC_CLASESERVICIO CLA ON SER.idclaseservicio = CLA.id " +
                    "INNER JOIN FC_ESPECIALIDAD ES ON SER.idespecialidad = ES.id " +
                    "WHERE(pac.tipoidentificacion + pac.identificacion) = @identy " +
                    "AND CLA.id in(1) " +
                    "and cita.estado in ('AT', 'RS') " +
                    "and SER.nombre like ('%' + @service + '%') " +
                    "and FCCONT.contrato like('%' + @programa + '%') "+
                    "AND cita.fechainicio >= @Fechaini " +
                    "AND cita.fechainicio <= @Fechafin " +
                    "GROUP BY " +
                    "ser.nombre " +
                    "order by ESTADO DESC";
                    Command.Parameters.AddWithValue("@identy", Id);
                    Command.Parameters.AddWithValue("@fechaini", Fechaini);
                    Command.Parameters.AddWithValue("@fechafin", Fechafin);
                    Command.Parameters.AddWithValue("@service", Service);
                    Command.Parameters.AddWithValue("@programa", Programa);

                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dtC = new DataTable();
                    adapter.Fill(dtC);

                    if (dtC.Rows.Count > 0)
                    {
                        PatientsCache.TablaCitas = dtC;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

        //Metodo con parametros para consultar de riesgo
        public bool ConsulRiesgo(String Id, String Exa)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "select top 1 EXA.nombre, MEDT.nombrecompleto as 'MEDICO T', " +
                    "max(RES.fechainicio) as Fecha_ultimo, "+
                    "CASE " +
                        "WHEN max(EXA.nombre) LIKE '%CARGA VIRAL%' and min(RED.valor) like '%MENOR%' or min(RED.valor) like '%<%' or max(RED.valor) like '%MENOR%' or max(RED.valor) like '%<%'THEN concat('Riesgo: ','INDETECTABLE') " +
                        "WHEN max(EXA.nombre) LIKE '%CARGA VIRAL%' and RES.estado = 'A' then 'NO REPORTADO' " +
                        "else concat('Riesgo: ', 'DETECTABLE: ', max(RED.valor), ' Copias/mL') " +
                        
                    "END as Resultado " +
                    "FROM FC_FACTURA FAC " +
                    "INNER JOIN dbo.PACIENTEASEGURADO PAS ON FAC.idpacienteasegurado = PAS.id " +
                    "INNER JOIN PACIENTE PAC ON PAS.idpaciente = PAC.id " +
                    "LEFT JOIN MEDICO MEDT ON PAC.idmedicotratante = MEDT.id "+
                    "INNER JOIN FC_CONTRATO CON ON PAS.idcontrato = CON.id " +
                    "INNER JOIN FC_SERVICIOPRESTADO SEP ON FAC.id = SEP.idfactura " +
                    "INNER JOIN FC_SERVICIO SER ON SEP.idservicio = SER.id " +
                    "INNER JOIN LB_RESULTADO RES ON SEP.id = RES.idservicioprestado " +
                    "INNER JOIN LB_RESULTADODETALLE RED ON RES.id = RED.idresultado " +
                    "INNER JOIN LB_EXAMENITEM EXI ON RED.idexamenitem = EXI.id " +
                    "INNER JOIN LB_EXAMEN EXA ON RES.idexamen = EXA.id " +
                    //"LEFT JOIN FC_TOPESERVICIO tope ON concat(SEP.idservicio, CON.id) = concat(tope.idservicio, tope.idcontrato) " +
                    "LEFT JOIN vitalapps.dbo.FC_VTOPES tope ON concat(SER.id, CON.id) = concat(tope.idservicio, tope.idcontrato)" +
                    "WHERE(pac.tipoidentificacion + pac.identificacion) = @identy and EXI.nombre like('%' + @Examen + '%') and RES.estado in('R','A') " +
                    "GROUP BY EXA.nombre, red.valor, RES.fechainicio, MEDT.nombrecompleto, RES.estado order by Fecha_ultimo DESC";
                    Command.Parameters.AddWithValue("@identy", Id);
                    Command.Parameters.AddWithValue("@Examen", Exa);
                    Command.CommandType = CommandType.Text;
                    SqlDataReader reader2 = Command.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            PatientsCache.NombreLab = reader2.Get<String>(0);
                            PatientsCache.FechaUltimoLab = reader2.Get<DateTime>(2);
                            PatientsCache.Riesgo = reader2.Get<String>(3);
                            PatientsCache.MedicoT =reader2.Get<String>(1);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

        //Metodo con parametros para consultar procedures
        public bool ListContratos(String Id)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "SELECT DISTINCT " +
                    "CASE " +
                    "WHEN CONT.id IN(677,684,698,708,710,714,715,716,717) THEN 'SERVIHDA' " +
                    "WHEN CONT.id IN(705,706,709,711)THEN 'SER RESILIENTE' " +
                    "WHEN CONT.id IN(679,681,685,691,693,697,712,713) THEN 'AMARTE' " +
                    "WHEN CONT.id IN(682,683) THEN 'RESPIRA' " +
                    "WHEN CONT.id IN(678,686,694,695,696) THEN 'EVENTO' " +
                    "WHEN CONT.id IN(701,702) THEN 'CAPITA RUTA DE PYM' " +
                    "WHEN CONT.id IN(703,704) THEN 'RECUPERACION DE LA SALUD' " +
                    "ELSE cont.contrato " +
                    "END AS contrato " +
                    "FROM PACIENTEASEGURADO PAS " +
                    "INNER JOIN FC_CONTRATO CONT ON PAS.idcontrato = CONT.id " +
                    "INNER JOIN PACIENTE PAC ON PAS.idpaciente = PAC.id " +
                    "WHERE PAS.estado = 'A' and(pac.tipoidentificacion + pac.identificacion) = @identy";
                    Command.Parameters.AddWithValue("@identy", Id);
                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dtC = new DataTable();
                    adapter.Fill(dtC);

                    if (dtC.Rows.Count > 0)
                    {
                        PatientsCache.TablaContratos = dtC;
                        //Prueba
                        DataRow fila2 = dtC.NewRow();
                        fila2["contrato"] = "Todos los contratos";
                        dtC.Rows.InsertAt(fila2, 0);
                        //Prueba
                        return true;
                    }
                    else
                        return false;
                }
            }

        }


        //Metodo con parametros para consultar contratos Individuales
        public bool ListAllContratosInd()
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "SELECT DISTINCT cont.id, cont.contrato as contrato FROM FC_CONTRATO CONT WHERE CONT.idestado = 'A' order by cont.contrato";
                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dtCInd = new DataTable();
                    adapter.Fill(dtCInd);

                    if (dtCInd.Rows.Count > 0)
                    {
                        PatientsCache.TablaContratosInd = dtCInd;
                        //Prueba
                        DataRow fila2 = dtCInd.NewRow();
                        fila2["contrato"] = "Todos los contratos";
                        dtCInd.Rows.InsertAt(fila2, 0);
                        //Prueba
                        return true;
                    }
                    else
                        return false;
                }
            }

        }



        //Metodo con parametros para consultar procedures
        public bool ListAllContratos()
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "SELECT DISTINCT "+
                    "CASE " +
                    "WHEN CONT.id IN(677,684,698,708,710,714,715,716,717) THEN 'SERVIHDA' " +
                    "WHEN CONT.id IN(705,706,709,711)THEN 'SER RESILIENTE' " +
                    "WHEN CONT.id IN(679,681,685,691,693,697,712,713) THEN 'AMARTE' " +
                    "WHEN CONT.id IN(682,683) THEN 'RESPIRA' " +
                    "WHEN CONT.id IN(678,686,694,695,696) THEN 'EVENTO' " +
                    "WHEN CONT.id IN(701,702) THEN 'CAPITA RUTA DE PYM' " +
                    "WHEN CONT.id IN(703,704) THEN 'RECUPERACION DE LA SALUD' " +
                    "ELSE cont.contrato " +
                    "END AS contrato " +
                    "FROM FC_CONTRATO CONT " +
                    "WHERE CONT.idestado = 'A'";
                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dtCAll = new DataTable();
                    adapter.Fill(dtCAll);

                    if (dtCAll.Rows.Count > 0)
                    {
                        PatientsCache.TablaAllContratos = dtCAll;
                        //Prueba
                        DataRow fila2 = dtCAll.NewRow();
                        fila2["contrato"] = "Todos los contratos";
                        dtCAll.Rows.InsertAt(fila2, 0);
                        //Prueba
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

        //Metodo con parametros para consultar Especialidades
        public bool ListEspecialidades()
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "SELECT DISTINCT ES.id, ES.descripcion FROM FC_ESPECIALIDAD ES "+
                    "INNER JOIN MEDICO MED ON ES.id = MED.idespecialidad " +
                    "GROUP BY ES.descripcion, ES.ID ORDER BY ES.descripcion ASC";
                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dtE = new DataTable();
                    adapter.Fill(dtE);

                    if (dtE.Rows.Count > 0)
                    {
                        PatientsCache.TablaEspecialidades = dtE;
                        //Insert Row All Especial
                        DataRow fila1 = dtE.NewRow();
                        fila1["descripcion"] = "GRUPO - MEDICINA GENERAL";
                        dtE.Rows.InsertAt(fila1, 0);
                        //Insert Row All Especial
                        DataRow fila2 = dtE.NewRow();
                        fila2["descripcion"] = "TODAS LAS ESPECIALIDADES";
                        dtE.Rows.InsertAt(fila2, 0);
                        //Prueba
                        return true;
                    }
                    else
                        return false;
                }
            }

        }


        //Metodo con parametros para consultar de riesgo
        public bool ConsulCriterios(String Id)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "use emedico "+
                    "declare " +
                    "@idc INT, " +
                    "@idp INT, " +
                    "@ids INT, " +
                    "@ide INT, " +
                    "@jsonInfo nvarchar(max); " +
                    "set @idp = 5592 " +
                    "set @jsonInfo = (SELECT H.datos FROM dbo.HC_HISTORIA H where H.id = (SELECT max(H.id) " +
                    "FROM dbo.HC_FORMATO F " +
                    "INNER JOIN dbo.HC_HISTORIA H ON F.id = H.idformato " +
                    "INNER JOIN dbo.HC_EVENTOATENCION EA ON EA.id = H.idevento " +
                    "INNER JOIN dbo.PACIENTEASEGURADO PAS ON PAS.id = EA.idpacienteasegurado " +
                    "INNER JOIN dbo.FC_CONTRATO CO ON CO.id = PAS.idcontrato " +
                    "INNER JOIN dbo.PACIENTE P ON P.id = PAS.idpaciente " +
                    "WHERE EA.idempresa like '%%' " +
                    "AND F.id = @idp " +
                    "AND H.idestado <> 'X' " +
                    "AND P.identificacion = @identy " +
                    "AND(@ids = 0 OR EA.idsede like '%%') " +
                    "AND(@idc = 0 OR PAS.idcontrato like '%%'))) " +
                    "SELECT top 1 " +
                    "max(H.fechacrea) as fecha, " +
                    "F.descripcion AS plantilla, " +
                    "CO.contrato, " +
                    "CONCAT(P.tipoidentificacion, ' ', " +
                    "P.identificacion) AS identificacion, " +
                    "P.nombrecompleto, " +
                    "P.fechanacimiento, " +
                    "JSON_VALUE(@jsonInfo, '$.HCSEGTEL_A03_P05') as Observacion, " +
                    "P.direccion, " +
                    "P.telefono, " +
                    "P.celular, " +
                    "CI.nombre AS ciudadnombre, " +
                    "DE.nombre AS departamento " +
                    "FROM dbo.HC_FORMATO F " +
                    "INNER JOIN dbo.HC_HISTORIA H ON F.id = H.idformato " +
                    "INNER JOIN dbo.HC_EVENTOATENCION EA ON EA.id = H.idevento " +
                    "INNER JOIN dbo.PACIENTEASEGURADO PAS ON PAS.id = EA.idpacienteasegurado " +
                    "INNER JOIN dbo.FC_CONTRATO CO ON CO.id = PAS.idcontrato " +
                    "INNER JOIN dbo.PACIENTE P ON P.id = PAS.idpaciente " +
                    "INNER JOIN dbo.MEDICO M ON H.idmedico = M.id " +
                    "INNER JOIN dbo.CIUDAD CI ON P.idciudad = CI.id " +
                    "INNER JOIN dbo.ESTADO DE ON DE.id = CI.idestado " +
                    "LEFT JOIN dbo.HC_HISTORIAFORMATO HF ON H.idhistoriaformato = HF.id " +
                    "WHERE EA.idempresa like '%%' " +
                    "AND F.id = @idp " +
                    "AND H.idestado <> 'X' " +
                    "AND P.identificacion = @identy " +
                    "AND(@ids = 0 OR EA.idsede like '%%') " +
                    "AND(@idc = 0 OR PAS.idcontrato like '%%') " +
                    "AND ISJSON(@jsonInfo) > 0 " +
                    "GROUP by " +
                    "P.tipoidentificacion, " +
                    "P.identificacion, " +
                    "P.nombrecompleto, " +
                    "P.direccion, " +
                    "P.telefono, " +
                    "P.celular, " +
                    "CI.nombre, " +
                    "DE.nombre, " +
                    "F.descripcion, " +
                    "CO.contrato, " +
                    "P.fechanacimiento";
                    Command.Parameters.AddWithValue("@identy", Id);
                    Command.CommandType = CommandType.Text;
                    SqlDataReader reader2 = Command.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            PatientsCache.NombreC = reader2.Get<String>(4);
                            PatientsCache.Observacion = reader2.Get<String>(6);
                        }
                        return true;
                    }
                    else
                    {
                        PatientsCache.NombreC = "";
                        PatientsCache.Observacion = "";
                    }
                    return false;
                }
            }

        }



    }

}
