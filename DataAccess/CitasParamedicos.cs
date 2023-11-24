using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Common.Cache;
using System.Data;
using System.Windows.Media;

namespace DataAccess
{
    public class CitasParamedicos : ConnectionToSql
    {

        //Metodo con parametros para consultar 
        public bool ListarCitasOdon(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "Select " +
                    "CASE " +
                    "WHEN SER.nombre like '%ODONTOLO%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'ODONTOLOGIA (CONTROL) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%ODONTOLO%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'ODONTOLOGIA (P. VEZ) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%ODONTOLO%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESEN%' THEN 'ODONTOLOGIA (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%ODONTOLO%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESEN%' THEN 'ODONTOLOGIA (P. VEZ) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%ODONTOLO%' AND SER.nombre like '%CONTROL%' THEN 'ODONTOLOGIA (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%ODONTOLO%' AND SER.nombre like '%PRIMERA%' THEN 'ODONTOLOGIA (P. VEZ) (PRESENCIAL)' " +
                    "ELSE SER.nombre " +
                    "END as 'ODONTOLOGIA', " +
                                        "CASE " +
                    "WHEN MIN(cita.estado) = 'AT' THEN convert(date, max(cita.fechaconfirmacion)) " +
                    "END as 'Última', " +
                    "convert(date,max(dateadd(day, tope.cantidad,cita.fechaconfirmacion))) as 'Proxima', " +
                    /*"CASE " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) < GETDATE() THEN 'Reserva Vencida' " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) > max(cita.fechaconfirmacion) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) = max(cita.fechainicio) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) <> 'RS' THEN 'Sin Reserva' " +
                    "END as 'Cita Reserva', " +*/
                    "CASE " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) <= GETDATE() THEN 'VENCIDO' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechainicio)) >= GETDATE()+1 and max(dateadd(day, tope.cantidad, cita.fechainicio)) < GETDATE()+15  THEN 'POR VENCER' " +
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
                    "AND ES.id in (219,260,280,284) " +
                    "AND CLA.id in(1) " +
                    "AND cita.estado in ('AT', 'RS') " +
                    "AND SER.nombre like ('%' + @service + '%') " +
                    "and FCCONT.contrato like('%' + @programa + '%') " +
                    "AND cita.fechainicio >= @Fechaini " +
                    "AND cita.fechainicio <= @Fechafin " +
                    "GROUP BY " +
                    "ser.nombre " +
                    "order by 'Última' DESC";
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
                        CitasCache.TablaCparamedicos = dtC;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

        //Metodo con parametros para consultar 
        public bool ListarCitasPsico(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "Select " +
                    "CASE " +
                    "WHEN SER.nombre like '%PSICOLOGIA%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'PSICOLOGIA (CONTROL) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%PSICOLOGIA%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'PSICOLOGIA (P. VEZ) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%PSICOLOGIA%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESEN%' THEN 'PSICOLOGIA (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%PSICOLOGIA%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESEN%' THEN 'PSICOLOGIA (P. VEZ) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%PSICOLOGIA%' AND SER.nombre like '%CONTROL%' THEN 'PSICOLOGIA (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%PSICOLOGIA%' AND SER.nombre like '%PRIMERA%' THEN 'PSICOLOGIA (P. VEZ) (PRESENCIAL)' " +
                    "ELSE SER.nombre " +
                    "END as 'PSICOLOGIA', " +
                                        "CASE " +
                    "WHEN MIN(cita.estado) = 'AT' THEN convert(date, max(cita.fechaconfirmacion)) " +
                    "END as 'Última', " +
                    "convert(date,max(dateadd(day, tope.cantidad,cita.fechaconfirmacion))) as 'Proxima', " +
                    /*"CASE " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) < GETDATE() THEN 'Reserva Vencida' " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) > max(cita.fechaconfirmacion) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) = max(cita.fechainicio) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) <> 'RS' THEN 'Sin Reserva' " +
                    "END as 'Cita Reserva', " +*/
                    "CASE " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) <= GETDATE() THEN 'VENCIDO' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechainicio)) >= GETDATE()+1 and max(dateadd(day, tope.cantidad, cita.fechainicio)) < GETDATE()+15  THEN 'POR VENCER' " +
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
                    "AND ES.id in (275) " +
                    "AND CLA.id in(1) " +
                    "AND cita.estado in ('AT', 'RS') " +
                    "AND SER.nombre like ('%' + @service + '%') " +
                    "and FCCONT.contrato like('%' + @programa + '%') " +
                    "AND cita.fechainicio >= @Fechaini " +
                    "AND cita.fechainicio <= @Fechafin " +
                    "GROUP BY " +
                    "ser.nombre " +
                    "order by 'Última' DESC";
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
                        CitasCache.TablaCpsico = dtC;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

        //Metodo con parametros para consultar 
        public bool ListarCitasEnfermeria(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "Select " +
                    "CASE " +
                    "WHEN SER.nombre like '%ENFERMER%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'ENFERMERIA (CONTROL) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%ENFERMER%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'ENFERMERIA (P. VEZ) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%ENFERMER%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESEN%' THEN 'ENFERMERIA (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%ENFERMER%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESEN%' THEN 'ENFERMERIA (P. VEZ) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%ENFERMER%' AND SER.nombre like '%CONTROL%' THEN 'ENFERMERIA (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%ENFERMER%' AND SER.nombre like '%PRIMERA%' THEN 'ENFERMERIA (P. VEZ) (PRESENCIAL)' " +
                    "ELSE SER.nombre " +
                    "END as 'ENFERMERIA', " +
                                        "CASE " +
                    "WHEN MIN(cita.estado) = 'AT' THEN convert(date, max(cita.fechaconfirmacion)) " +
                    "END as 'Última', " +
                    "convert(date,max(dateadd(day, tope.cantidad,cita.fechaconfirmacion))) as 'Proxima', " +
                    /*"CASE " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) < GETDATE() THEN 'Reserva Vencida' " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) > max(cita.fechaconfirmacion) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) = max(cita.fechainicio) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) <> 'RS' THEN 'Sin Reserva' " +
                    "END as 'Cita Reserva', " +*/
                    "CASE " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) <= GETDATE() THEN 'VENCIDO' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechainicio)) >= GETDATE()+1 and max(dateadd(day, tope.cantidad, cita.fechainicio)) < GETDATE()+15  THEN 'POR VENCER' " +
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
                    "AND ES.id in (504,513,523) " +
                    "AND CLA.id in(1) " +
                    "AND cita.estado in ('AT', 'RS') " +
                    "AND SER.nombre like ('%' + @service + '%') " +
                    "and FCCONT.contrato like('%' + @programa + '%') " +
                    "AND cita.fechainicio >= @Fechaini " +
                    "AND cita.fechainicio <= @Fechafin " +
                    "GROUP BY " +
                    "ser.nombre " +
                    "order by 'Última' DESC";
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
                        CitasCache.TablaCEnfer = dtC;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

        //Metodo con parametros para consultar 
        public bool ListarCitasQuimico(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "Select " +
                    "SER.nombre as 'QUIMICO', " +
                    "CASE " +
                    "WHEN MIN(cita.estado) = 'AT' THEN convert(date, max(cita.fechaconfirmacion)) " +
                    "END as 'Última', " +
                    "convert(date,max(dateadd(day, tope.cantidad,cita.fechaconfirmacion))) as 'Proxima', " +
                    /*"CASE " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) < GETDATE() THEN 'Reserva Vencida' " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) > max(cita.fechaconfirmacion) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) = max(cita.fechainicio) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) <> 'RS' THEN 'Sin Reserva' " +
                    "END as 'Cita Reserva', " +*/
                    "CASE " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) <= GETDATE() THEN 'VENCIDO' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechainicio)) >= GETDATE()+1 and max(dateadd(day, tope.cantidad, cita.fechainicio)) < GETDATE()+15  THEN 'POR VENCER' " +
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
                    "AND ES.id in (514) " +
                    "AND CLA.id in(1) " +
                    "AND cita.estado in ('AT', 'RS') " +
                    "AND SER.nombre like ('%' + @service + '%') " +
                    "and FCCONT.contrato like('%' + @programa + '%') " +
                    "AND cita.fechainicio >= @Fechaini " +
                    "AND cita.fechainicio <= @Fechafin " +
                    "GROUP BY " +
                    "ser.nombre " +
                    "order by 'Última' DESC";
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
                        CitasCache.TablaCQuimi = dtC;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }


        //Metodo con parametros para consultar 
        public bool ListarCitasNutricion(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "Select " +
                    "CASE " +
                    "WHEN SER.nombre like '%NUTRICION%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'NUTRICION (CONTROL) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%NUTRICION%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'NUTRICION (P. VEZ) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%NUTRICION%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESEN%' THEN 'NUTRICION (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%NUTRICION%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESEN%' THEN 'NUTRICION (P. VEZ) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%NUTRICION%' AND SER.nombre like '%CONTROL%' THEN 'NUTRICION (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%NUTRICION%' AND SER.nombre like '%PRIMERA%' THEN 'NUTRICION (P. VEZ) (PRESENCIAL)' " +
                    "ELSE SER.nombre " +
                    "END as 'NUTRICION', " +
                                        "CASE " +
                    "WHEN MIN(cita.estado) = 'AT' THEN convert(date, max(cita.fechaconfirmacion)) " +
                    "END as 'Última', " +
                    "convert(date,max(dateadd(day, tope.cantidad,cita.fechaconfirmacion))) as 'Proxima', " +
                    /*"CASE " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) < GETDATE() THEN 'Reserva Vencida' " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) > max(cita.fechaconfirmacion) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) = max(cita.fechainicio) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) <> 'RS' THEN 'Sin Reserva' " +
                    "END as 'Cita Reserva', " +*/
                    "CASE " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) <= GETDATE() THEN 'VENCIDO' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechainicio)) >= GETDATE()+1 and max(dateadd(day, tope.cantidad, cita.fechainicio)) < GETDATE()+15  THEN 'POR VENCER' " +
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
                    "AND ES.id in (258) " +
                    "AND CLA.id in(1) " +
                    "AND cita.estado in ('AT', 'RS') " +
                    "AND SER.nombre like ('%' + @service + '%') " +
                    "and FCCONT.contrato like('%' + @programa + '%') " +
                    "AND cita.fechainicio >= @Fechaini " +
                    "AND cita.fechainicio <= @Fechafin " +
                    "GROUP BY " +
                    "ser.nombre " +
                    "order by 'Última' DESC";
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
                        CitasCache.TablaCNurti = dtC;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

        //Metodo con parametros para consultar 
        public bool ListarCitasTsocial(String Id, DateTime Fechaini, DateTime Fechafin, String Service, String Programa)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "Select " +
                    "CASE " +
                    "WHEN SER.nombre like '%TRABAJO SOCIAL%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%VIRTUAL%' THEN 'TRABAJO SOCIAL (CONTROL) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%TRABAJO SOCIAL%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%VIRTUAL%' THEN 'TRABAJO SOCIAL (P. VEZ) (VIRTUAL)' " +
                    "WHEN SER.nombre like '%TRABAJO SOCIAL%' AND SER.nombre like '%CONTROL%' AND SER.nombre like '%PRESEN%' THEN 'TRABAJO SOCIAL (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%TRABAJO SOCIAL%' AND SER.nombre like '%PRIMERA%' AND SER.nombre like '%PRESEN%' THEN 'TRABAJO SOCIAL (P. VEZ) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%TRABAJO SOCIAL%' AND SER.nombre like '%CONTROL%' THEN 'TRABAJO SOCIAL (CONTROL) (PRESENCIAL)' " +
                    "WHEN SER.nombre like '%TRABAJO SOCIAL%' AND SER.nombre like '%PRIMERA%' THEN 'TRABAJO SOCIAL (P. VEZ) (PRESENCIAL)' " +
                    "ELSE SER.nombre " +
                    "END as 'T.SOCIAL', " +
                                        "CASE " +
                    "WHEN MIN(cita.estado) = 'AT' THEN convert(date, max(cita.fechaconfirmacion)) " +
                    "END as 'Última', " +
                    "convert(date,max(dateadd(day, tope.cantidad,cita.fechaconfirmacion))) as 'Proxima', " +
                    /*"CASE " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) < GETDATE() THEN 'Reserva Vencida' " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) > max(cita.fechaconfirmacion) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) = 'RS' and convert(date,max(cita.fechainicio)) = max(cita.fechainicio) THEN CONVERT(varchar, convert(date,max(cita.fechainicio)), (20)) " +
                        "WHEN max(cita.estado) <> 'RS' THEN 'Sin Reserva' " +
                    "END as 'Cita Reserva', " +*/
                    "CASE " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechaconfirmacion)) <= GETDATE() THEN 'VENCIDO' " +
                        "WHEN max(dateadd(day, tope.cantidad, cita.fechainicio)) >= GETDATE()+1 and max(dateadd(day, tope.cantidad, cita.fechainicio)) < GETDATE()+15  THEN 'POR VENCER' " +
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
                    "AND ES.id in (290) " +
                    "AND CLA.id in(1) " +
                    "AND cita.estado in ('AT', 'RS') " +
                    "AND SER.nombre like ('%' + @service + '%') " +
                    "and FCCONT.contrato like('%' + @programa + '%') " +
                    "AND cita.fechainicio >= @Fechaini " +
                    "AND cita.fechainicio <= @Fechafin " +
                    "GROUP BY " +
                    "ser.nombre " +
                    "order by 'Última' DESC";
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
                        CitasCache.TablaCTs = dtC;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }


        //Metodo con parametros para consultar 
        public bool ListarInasistentes(String Id, String Nombre, String Service, String Programa, String Especialidad)
        {
            using (var Connection = GetConnection())
            {
                Connection.Open();
                using (var Command = new SqlCommand())
                {
                    Command.Connection = Connection;
                    Command.CommandText = "Select " +
                    "P.tipoidentificacion AS TIPO, " +
                    "P.identificacion AS NUM, " +
                    "P.nombrecompleto as 'NOMBRES', " +
                    "P.TELEFONO, " +
                    "P.CELULAR, " +
                    "CASE " +
                    "WHEN max(cita.fechainicio) <= EOMONTH(GETDATE(), -1) THEN 'NO PROGRAMADO' " +
                    "WHEN MAX(cita.estado) = 'CO' THEN 'CONFIRMADO' " +
                    "WHEN MAX(cita.estado) = 'EA' THEN 'EN ATENCION' " +
                    "WHEN max(cita.fechaconfirmacion) < GETDATE() AND max(cita.fechaconfirmacion) > EOMONTH(GETDATE(), -1) AND max(cita.fechainicio) > dateadd(day, +1, GETDATE())  THEN 'ATENDIDO - AGENDADO' " +
                    "WHEN max(cita.fechaconfirmacion) < GETDATE() AND max(cita.fechaconfirmacion) > EOMONTH(GETDATE(), -1)  THEN 'ATENDIDO - NO PROGRAMADO' " +
                    "WHEN max(cita.fechainicio) < GETDATE()  THEN 'INASISTENTE' " +
                    "WHEN max(cita.fechaconfirmacion) <= DATEADD(month, DATEDIFF(month, -1, getdate()) - 2, 0) THEN 'INASISTENTE - PERSISTENTE' " +
                    "WHEN max(cita.fechainicio) >= GETDATE() AND max(cita.fechaconfirmacion) < EOMONTH(GETDATE()) THEN 'AGENDADO' " +
                    "ELSE 'INASISTENTE' "+
                    "END as 'ESTADO DE CITA', " +
                    "CASE " +
                    "WHEN max(cita.fechaconfirmacion) <= GETDATE() THEN convert(date, MAX(cita.fechaconfirmacion)) " +
                    "END as 'ULTIMA ATENCION', " +
                    "CASE " +
                    "WHEN max(cita.fechainicio) > GETDATE()  THEN CONVERT(DATE, max(cita.fechainicio)) " +
                    "ELSE CONVERT(DATE, max(cita.fechainicio)) " +
                    "END AS 'FECHA DE RESERVA' " +
                    "FROM dbo.PACIENTE PAC " +
                    "INNER JOIN dbo.PACIENTEASEGURADO CONT on PAC.id = CONT.idpaciente " +
                    "INNER JOIN PACIENTE P ON CONT.idpaciente = P.id " +
                    "INNER JOIN dbo.FC_CONTRATO FCCONT on CONT.idcontrato = FCCONT.id " +
                    "INNER JOIN dbo.HC_CITA Cita on CONT.id = Cita.idpacienteasegurado " +
                    "RIGHT JOIN dbo.FC_SERVICIO SER on Cita.idservicio = SER.id " +
                    "INNER JOIN FC_CLASESERVICIO CLA ON SER.idclaseservicio = CLA.id " +
                    "INNER JOIN FC_ESPECIALIDAD ES ON SER.idespecialidad = ES.id " +
                    "WHERE pac.identificacion like('%' + @identy + '%') AND pac.nombrecompleto like('%' + @nombre + '%') " +
                    "AND ES.descripcion like('%' + @especialidad + '%') " +
                    "and CLA.descripcion like '%CONSULTA%' " +
                    "and cita.estado in ('RS', 'AT', 'EA','CO') " +
                    "and SER.nombre like('%' + @service + '%') " +
                    "and FCCONT.contrato like('%' + @programa + '%') " +
                    //"AND CONVERT(DATE, cita.fechainicio) >= CONVERT(DATE, @Fechaini) " +
                    //"AND CONVERT(DATE, cita.fechainicio) <= CONVERT(DATE, @Fechafin) " +
                    "AND CONVERT(DATE, cita.fechainicio) >= DATEADD(dd, -(DAY(DATEADD(mm, -12, GETDATE())) - 1), DATEADD(mm, -12, GETDATE())) " +
                    "AND CONVERT(DATE, cita.fechainicio) <= DATEADD(MONTH,+2,GETDATE()) " +
                    "GROUP BY " +
                    "P.nombrecompleto, P.tipoidentificacion, P.identificacion, P.TELEFONO, P.CELULAR " +
                    "order by P.nombrecompleto DESC";
                    Command.Parameters.AddWithValue("@identy", Id);
                    Command.Parameters.AddWithValue("@nombre", Nombre);
                    //Command.Parameters.AddWithValue("@fechaini", Fechaini);
                    //Command.Parameters.AddWithValue("@fechafin", Fechafin);
                    Command.Parameters.AddWithValue("@service", Service);
                    Command.Parameters.AddWithValue("@programa", Programa);
                    Command.Parameters.AddWithValue("@especialidad", Especialidad);

                    Command.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = Command;
                    DataTable dtIna = new DataTable();
                    adapter.Fill(dtIna);

                    if (dtIna.Rows.Count > 0)
                    {
                        CitasCache.TablaInasistentes = dtIna;
                        return true;
                    }
                    else
                        return false;
                }
            }

        }

    }
}
