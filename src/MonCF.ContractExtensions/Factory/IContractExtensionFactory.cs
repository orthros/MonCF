using System.ServiceModel.Description;

namespace MonCF.ContractExtensions.Factory
{
    public interface IContractExtensionFactory
    {
        void ApplyContractExtensions(ServiceEndpoint endpoint);
    }
}
