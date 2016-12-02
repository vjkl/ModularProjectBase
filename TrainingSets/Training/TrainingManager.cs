using BioContracts.Castle;
using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.IO;

namespace TrainingSets.Training
{
  public class TrainingManager : PropertyChangedBase, ITraining
  {
    public bool CanSave                             => TConteiner.isChange;
    private TrainingLoader tLoader                  = new TrainingLoader();
    public static string _NameFileWithListTrainings = "ListTrainings.txt";
    public string _pathToListTrainings              = Directory.GetCurrentDirectory() + "\\" + _NameFileWithListTrainings;

    public TrainingManager()
    {
      TConteiner.DataChanged += RefreshUi;

      if (tLoader.Create(_pathToListTrainings))
        tConteiner.AddRange(new ObservableCollection<TrainingItem>());
      else Load(_pathToListTrainings);
    }

    public void RefreshUi()
    {
      NotifyOfPropertyChange(() => CanSave);
      NotifyOfPropertyChange(() => TConteiner.TrainingSets);
    }

    private TrainingConteiner tConteiner = new TrainingConteiner();
    public TrainingConteiner TConteiner
    {
      get { return tConteiner; }
    }

    public void Load(string path)
    {
      tConteiner.AddRange(tLoader.Load(path));
      SetNewPathToListTrainings(path);
    }

    public bool Save()
    {
      bool isSave = tLoader.Save(tConteiner.TrainingSets, _pathToListTrainings);
      tConteiner.Change(isSave);
      RefreshUi();
      return isSave;
    }

    private void SetNewPathToListTrainings(string newPathToListTrainings)
    {
      if (!string.IsNullOrEmpty(newPathToListTrainings))
        _pathToListTrainings = newPathToListTrainings;
    }
  }
}
