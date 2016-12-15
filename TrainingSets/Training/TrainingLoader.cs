using TrainingSets.Utils;
using System.Collections.ObjectModel;

namespace TrainingSets.Training
{
  public class TrainingLoader
  {
    private FileIO fileIO = new FileIO();
    private JsonIO jsonIO = new JsonIO();

    public static ObservableCollection<TrainingItem> Empty => new ObservableCollection<TrainingItem>();

    public bool Create(string path)
    {
      return fileIO.Create(path);
    }

    public ObservableCollection<TrainingItem> Load(string path)
    {
      string dataTrainingFromFile = fileIO.Load(path);
      ObservableCollection<TrainingItem> trainingSets = jsonIO.DeserializeObject<ObservableCollection<TrainingItem>>(dataTrainingFromFile);
      if (trainingSets != null)
        return trainingSets;
      else
        return Empty;
    }

    public bool Save(ObservableCollection<TrainingItem> trainingSet, string pathToListTrainings)
    {
      return fileIO.Save(jsonIO.SerializeObject(trainingSet), pathToListTrainings);
    }
  }
}