using BioContracts.Castle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using TrainingSets.Training;

namespace TrainingSets
{
  class TrainingSetsImpl : IModule
  {
    private readonly IWindsorContainer _container;

    public TrainingSetsImpl (IWindsorContainer container)
    {
      _container = container;
    }

    public void DeInit()
    {
      throw new NotImplementedException();
    }

    public void Init()
    {
      _container.Register(Component.For<ITraining>().ImplementedBy<TrainingManager>());
    }
  }
}