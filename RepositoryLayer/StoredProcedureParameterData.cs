using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
    public class StoredProcedureParameterData
    {
        public StoredProcedureParameterData(string name, dynamic value)
        {
            this.name = name;
            this.value = value;
        }

        public string name { get; set; }
        public dynamic value { get; set; }
    }
}
