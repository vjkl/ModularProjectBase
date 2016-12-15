using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using BioContracts.Castle;

namespace TrainingSets
{
  public class TrainingSetsInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container
        .Register(Component.For<IModule>().ImplementedBy<TrainingSetsImpl>());
    }
  }
}
