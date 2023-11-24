using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class PatientsCache
    {
        private static int idPaciente;
        private static string tipoID;
        private static string? identificacion;
        private static string? firstName;
        private static string? secondName;
        private static string? lastName;
        private static string? lastName2;
        private static string sexo;
        private static string? medicoT;
        private static DateTime fechaN;
        private static string? religion;
        private static string contrato;
        private static object? tabla;
        private static object? tablalab;
        private static object? tablaProced;
        private static object? tablaCitas;
        private static string? nombreLab;
        private static string? riesgo;
        private static DateTime? fechaUltimoLab;
        private static object? tablaContratos;
        private static object? tablaContratosInd;
        private static object? tablaAllContratos;
        private static DataTable? tablaEspecialidades;
        private static string? nombreC;
        private static string? observacion;







        public static int IdPaciente { get => idPaciente; set => idPaciente = value; }
        public static string? Identificacion { get => identificacion; set => identificacion = value; }
        public static string? FirstName { get => firstName; set => firstName = value; }
        public static string? LastName { get => lastName; set => lastName = value; }
        public static string Sexo { get => sexo; set => sexo = value; }
        public static string? MedicoT { get => medicoT; set => medicoT = value; }
        public static DateTime FechaN { get => fechaN; set => fechaN = value; }
        public static string? Religion { get => religion; set => religion = value; }
        public static string TipoID { get => tipoID; set => tipoID = value; }
        public static string? SecondName { get => secondName; set => secondName = value; }
        public static string? LastName2 { get => lastName2; set => lastName2 = value; }
        public static string Contrato { get => contrato; set => contrato = value; }
        public static object? Tabla { get => tabla; set => tabla = value; }
        public static object? Tablalab { get => tablalab; set => tablalab = value; }
        public static object? TablaProced { get => tablaProced; set => tablaProced = value; }
        public static object? TablaCitas { get => tablaCitas; set => tablaCitas = value; }
        public static string? Riesgo { get => riesgo; set => riesgo = value; }
        public static DateTime? FechaUltimoLab { get => fechaUltimoLab; set => fechaUltimoLab = value; }
        public static string? NombreLab { get => nombreLab; set => nombreLab = value; }
        public static object? TablaContratos { get => tablaContratos; set => tablaContratos = value; }
        public static object? TablaAllContratos { get => tablaAllContratos; set => tablaAllContratos = value; }
        public static DataTable? TablaEspecialidades { get => tablaEspecialidades; set => tablaEspecialidades = value; }
        public static string? NombreC { get => nombreC; set => nombreC = value; }
        public static string? Observacion { get => observacion; set => observacion = value; }
        public static object? TablaContratosInd { get => tablaContratosInd; set => tablaContratosInd = value; }
    }
}
