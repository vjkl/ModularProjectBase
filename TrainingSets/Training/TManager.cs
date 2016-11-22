using System;
using System.Collections.ObjectModel;
using System.IO;
using BioContracts.Castle;
using System.Linq;
using Caliburn.Micro;

namespace TrainingSets.Training
{
  public class TManager : PropertyChangedBase, ITraining
  {
    public bool CanApplyTAdd  => TConteiner.SelectedTItem.Sets.All(set => set.NoErrors);
    public bool CanApplyTSave => TConteiner.isChange;

    public TManager()
    {
      OnActivate();
    }

    protected void OnActivate()
    {
      TConteiner.DataChanged += RefreshUi;
    }

    protected void OnDeactivate(bool close)
    {
      TConteiner.DataChanged -= RefreshUi;
    }

    public void RefreshUi()
    {
      NotifyOfPropertyChange(() => CanApplyTAdd);
      NotifyOfPropertyChange(() => CanApplyTSave);
      NotifyOfPropertyChange(() => TConteiner.TrainingSets);
    }

    private TConteiner tConteiner = new TConteiner();
    public TConteiner TConteiner
    {
      get { return tConteiner; }
      set
      {
        if (tConteiner == value) return;
        tConteiner = value;
        NotifyOfPropertyChange(() => TConteiner);
      }
    }

    private TLoader tLoader = new TLoader();

    public static string _NameFileWithListTrainings = "ListTrainings.txt";
    public string _pathToListTrainings = Directory.GetCurrentDirectory() + "\\" + _NameFileWithListTrainings;

    public void Create()
    {
      if (tLoader.Create(_pathToListTrainings))
        tConteiner.AddRange(new ObservableCollection<TItem>());
      else Load(_pathToListTrainings);
    }

    public void Load(string path)
    {
      tConteiner.AddRange(tLoader.Load(path));
      SetNewPathToListTrainings(path);
    }

    public void Save()
    {
      tLoader.Save(tConteiner.TrainingSets, _pathToListTrainings);
      tConteiner.isChange = false;
      RefreshUi();
    }

    private void SetNewPathToListTrainings(string newPathToListTrainings)
    {
      if (!string.IsNullOrEmpty(newPathToListTrainings))
        _pathToListTrainings = newPathToListTrainings;
    }
  }
}
