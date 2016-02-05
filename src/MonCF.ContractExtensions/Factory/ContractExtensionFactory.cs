﻿using MonCF.ContractExtensions.Extension;
using MonCF.ContractExtensions.Metadata;
using MonCF.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.ServiceModel.Description;

namespace MonCF.ContractExtensions.Factory
{
    public class ContractExtensionFactory : IContractExtensionFactory
    {
        [ImportMany]
        private IEnumerable<Lazy<ContractExtension, IContractExtensionMetadata>> _extensions;
        private IEnumerable<Lazy<ContractExtension, IContractExtensionMetadata>> Extensions
        {
            get
            {
                if (_extensions == null)
                {
                    ComposeContainers();
                }
                return _extensions;
            }
        }

        private CompositionContainer _container;
        private CompositionContainer Container
        {
            get
            {
                return _container;
            }
            set
            {
                _container = value;
            }
        }

        private ILog Logger
        {
            get;
            set;                
        }

        public ContractExtensionFactory(ILog log)
        {
            this.Logger = log;
            ComposeContainers();
        }

        public void ApplyContractExtensions(ServiceEndpoint endpoint)
        {
            var contract = endpoint.Contract;
            foreach (var extension in Extensions)
            {
                var operationDescriptions = contract.Operations.Find(extension.Metadata.FunctionName);

                if (operationDescriptions != null)
                {
                    var serializerBehavior = operationDescriptions.Behaviors.Find<DataContractSerializerOperationBehavior>();
                    if (serializerBehavior == null)
                    {
                        serializerBehavior = new DataContractSerializerOperationBehavior(operationDescriptions);
                        operationDescriptions.Behaviors.Add(serializerBehavior);
                    }
                    serializerBehavior.DataContractResolver = extension.Value.GetResolver();
                }
                else
                {
                    Logger.Log(string.Format("No operation descriptions found for function name: {0}", extension.Metadata.FunctionName);
                }

            }

        }

        #region Private Functions
        private void ComposeContainers()
        {
            var catalog = new AggregateCatalog();

            LoadAssemblyExtensions(ref catalog);
            LoadDynamicExtensions(ref catalog);

            Container = new CompositionContainer(catalog);
            Container.ComposeParts(this);
        }

        private void LoadAssemblyExtensions(ref AggregateCatalog catalog)
        {
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ContractExtensionFactory).Assembly));
        }

        private void LoadDynamicExtensions(ref AggregateCatalog catalog)
        {
            DirectoryInfo newDin = new DirectoryInfo(Environment.CurrentDirectory);
            DirectoryCatalog dcat = new DirectoryCatalog(newDin.FullName);
            catalog.Catalogs.Add(dcat);
        }

        #endregion
    }
}
