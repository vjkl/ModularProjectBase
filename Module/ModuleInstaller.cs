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
          .Register(Component.For<IModule>().ImplementedBy<ModuleImpl>());
    }
  }
}