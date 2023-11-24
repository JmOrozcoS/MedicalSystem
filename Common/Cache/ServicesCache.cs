using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public class ServicesCache
    {
        private static object? tablaServices;
        private static object? tablaTopes;
        public static object? TablaServices { get => tablaServices; set => tablaServices = value; }
        public static object? TablaTopes { get => tablaTopes; set => tablaTopes = value; }
    }
}
