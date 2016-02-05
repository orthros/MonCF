using System.Runtime.Serialization;

namespace MonCF.ContractExtensions.Extension
{
    public abstract class ContractExtension
    {
        public abstract DataContractResolver GetResolver();
    }
}
