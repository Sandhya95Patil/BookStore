//-----------------------------------------------------------------------
// <copyright file="StoredProcedureParameterData.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Sandhya Patil</author>
//---------------------------------------------------------------------
namespace RepositoryLayer
{
    /// <summary>
    /// stored procedure parameters data class
    /// </summary>
    public class StoredProcedureParameterData
    {
        /// <summary>
        /// method for taking name of parameters of stored procedure dynamically
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public StoredProcedureParameterData(string name, dynamic value)
        {
            this.name = name;
            this.value = value;
        }

        public string name { get; set; }
        public dynamic value { get; set; }
    }
}
