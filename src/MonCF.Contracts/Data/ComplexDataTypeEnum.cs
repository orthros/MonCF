using System;
using System.Runtime.Serialization;

namespace MonCF.Contracts.Data
{
    /// <summary>
    /// Enumeration to represent the Type the Complex Data Is
    /// </summary>
    [Flags]
    [DataContract(Name = "DataType")]
    public enum ComplexDataTypeEnum
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        Created =    1 << 0,
        [EnumMember]
        Evolved =    1 << 1,
        [EnumMember]
        Maintained = 1 << 2,
        [EnumMember]
        Uncertain =  1 << 3,
        [EnumMember]
        Complex =    Created | Evolved | Maintained
    }
}
