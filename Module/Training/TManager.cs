using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Training
{
  public class TManager
  {
    public TConteiner tConteiner = new TConteiner();
    private TLoader tLoader = new TLoader();

    public static string _NameFileWithListTrainings = "ListTrainings.txt";
    public string _pathToListTrainings = Directory.GetCurrentDirectory() + "\\" + _NameFileWithListTrainings;

    public void Create()
    {
      if (tLoader.Create(_pathToListTrainings))
        tConteiner.AddRange(new ObservableCollection<TItem>());
      else Load(_pathToListTrainings);
    }

    public void Add()
    {
      tConteiner.Add();
    }

    public void Remove(TItem trainingItem)
    {
      tConteiner.Remove(trainingItem);
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
    }

    private void SetNewPathToListTrainings(string newPathToListTrainings)
    {
      if (!string.IsNullOrEmpty(newPathToListTrainings))
        _pathToListTrainings = newPathToListTrainings;
    }
  }
}
