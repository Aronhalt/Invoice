using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace invoice
{
    class Globals
    {
        public enum storageType
        {
            local,
            server
        };
        
        public static storageType Database { get;set;}
        
    

    }

}