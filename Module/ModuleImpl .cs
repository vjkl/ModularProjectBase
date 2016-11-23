using BioContracts.Castle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Module.Base;
using Module.ViewModels;
using System;

namespace Module
{
  class ModuleImpl : IModule
  {
    private readonly IShell _shell;
    private readonly TabViewModel _tabViewModel;
    private readonly ViewModelsContainer _viewModelsContainer;
    private readonly IWindsorContainer _container;

    public ModuleImpl(IWindsorContainer container, IShell shell)
    {
      _shell = shell;
      _container = container;
      
      _viewModelsContainer = CreateViewModelsContainer();
      _tabViewModel = _viewModelsContainer.Resolve<TabViewModel>();
      _shell.TabControl = _tabViewModel;
      _tabViewModel.Show<TrainingViewModel>();
      _tabViewModel.Show<TrainingChartViewModel>();
    }

    public void DeInit()
    {
      throw new NotImplementedException();
    }

    public void Init()
    {
      _shell.TabControl = _tabViewModel;
    }

    private ViewModelsContainer CreateViewModelsContainer()
    {
      var vmContainer = new WindsorContainer();
      _container.AddChildContainer(vmContainer);

      var instance = new ViewModelsContainer(vmContainer);
      vmContainer.Register(Component.For<IContainer>().Instance(instance));
      return instance;
    }
  }
}
