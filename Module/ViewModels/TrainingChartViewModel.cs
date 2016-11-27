using BioContracts.Castle;
using Caliburn.Micro;
using Castle.Windsor;

namespace Module.ViewModels
{
  public class TrainingChartViewModel : Screen
  {
    private readonly IWindsorContainer _container;
    public ITraining Training { get; }

    public TrainingChartViewModel(IWindsorContainer container)
    {
      DisplayName = "Chart";
      _container = container;
      Training = container.Resolve<ITraining>();
    }
  }
}