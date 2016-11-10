using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Module.ViewModels;
using BioContracts.Castle;

namespace Module
{
    public class ModuleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<TabViewModel>())
                //.Register(Component.For<SecondViewModel>())
                .Register(Component.For<IModule>().ImplementedBy<ModuleImpl>());
        }
    }
}