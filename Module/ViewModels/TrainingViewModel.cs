using Caliburn.Micro;
using Module.Utils;
using Castle.Windsor;
using BioContracts.Castle;
using System.Windows;

namespace Module.ViewModels
{
  public class TrainingViewModel : Screen
  {
    private readonly IWindsorContainer _container;
    public DialogUtil dialogUtil { get; } = new DialogUtil();

    public TrainingViewModel(IWindsorContainer container)
    {
      DisplayName = "Training";
      _container = container;
      _training = container.Resolve<ITraining>();
    }

    private ITraining _training;
    public ITraining Training
    {
      get { return _training; }
    }

    public void Load()
    {
      Training.Load(dialogUtil.GetPathToFileFromDialog());
    }

    public void Save()
    {
      bool isSave = Training.Save();
      if (isSave)
        MessageBox.Show("Successful save trainings!");
      else
        MessageBox.Show("Unsuccessful save trainings!");
    }
  }
}
