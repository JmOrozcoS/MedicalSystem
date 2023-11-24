using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class CitasCache
    {

        private static string? tipoId;
        private static string? identificacion;
        private static string? nombreC;
        private static string? sexo;
        private static object? tabla;
        private static object? tablaCparamedicos;
        private static object? tablaCpsico;
        private static object? tablaCQuimi;
        private static object? tablaCEnfer;
        private static object? tablaCNurti;
        private static object? tablaCTs;
        private static object? tablaCMgeneral;
        private static object? tablaCMinterna;
        private static object? tablaCinfecto;
        private static object? tablaInasistentes;

        public static string? TipoId { get => tipoId; set => tipoId = value; }
        public static string? Identificacion { get => identificacion; set => identificacion = value; }
        public static string? NombreC { get => nombreC; set => nombreC = value; }
        public static string? Sexo { get => sexo; set => sexo = value; }
        public static object? Tabla { get => tabla; set => tabla = value; }
        public static object? TablaCparamedicos { get => tablaCparamedicos; set => tablaCparamedicos = value; }
        public static object? TablaCpsico { get => tablaCpsico; set => tablaCpsico = value; }
        public static object? TablaCQuimi { get => tablaCQuimi; set => tablaCQuimi = value; }
        public static object? TablaCEnfer { get => tablaCEnfer; set => tablaCEnfer = value; }
        public static object? TablaCNurti { get => tablaCNurti; set => tablaCNurti = value; }
        public static object? TablaCTs { get => tablaCTs; set => tablaCTs = value; }
        public static object? TablaCMgeneral { get => tablaCMgeneral; set => tablaCMgeneral = value; }
        public static object? TablaCMinterna { get => tablaCMinterna; set => tablaCMinterna = value; }
        public static object? TablaCinfecto { get => tablaCinfecto; set => tablaCinfecto = value; }
        public static object? TablaInasistentes { get => tablaInasistentes; set => tablaInasistentes = value; }

    }
}
