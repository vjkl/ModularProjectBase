using BioContracts.Castle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Module.ViewModels;
using Module.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Base
{
  public class ViewModelsContainer : IContainer
  {
    private readonly IWindsorContainer _container;

    public ViewModelsContainer(IWindsorContainer subContainer)
    {
      _container = subContainer;

      _container
        .Register(Component.For<TabViewModel>())
        .Register(Component.For<TrainingViewModel>())
        .Register(Component.For<TrainingChartViewModel>());
    }

    public T Resolve<T>()
    {
      return _container.Resolve<T>();
    }
  }
}
