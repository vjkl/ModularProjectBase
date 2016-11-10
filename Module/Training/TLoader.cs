using Module.Utils;
using System.Collections.ObjectModel;

namespace Module.Training
{
  public class TLoader
  {
    private FileIO fileIO = new FileIO();
    private JsonIO jsonIO = new JsonIO();

    public static ObservableCollection<TItem> Empty => new ObservableCollection<TItem>();

    public ObservableCollection<TItem> InitTrainingSets()
    {
      string listTrainingSets = fileIO.InitFile();
      if (!string.IsNullOrEmpty(listTrainingSets))
      {
        var trainingSets = jsonIO.DeserializeObject<ObservableCollection<TItem>>(listTrainingSets);
        if (trainingSets != null)
          return trainingSets;
      }
      return Empty;
    }

    public ObservableCollection<TItem> Load(string path)
    {
      string dataTrainingFromFile = fileIO.Load(path);
      ObservableCollection<TItem> trainingSets = jsonIO.DeserializeObject<ObservableCollection<TItem>>(dataTrainingFromFile);
      if (trainingSets != null)
        return trainingSets;
      else
        return Empty;
    }

    public void Save(ObservableCollection<TItem> trainingSet)
    {
      fileIO.Save(jsonIO.SerializeObject(trainingSet));
    }
  }
}