using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace invoice
{
    class Globals
    {
        public enum DataType
        {
            Local,
            Server
        };
        public static DataType dataType { get; set; }
        public static String author { get; set; }
         

    }
}
