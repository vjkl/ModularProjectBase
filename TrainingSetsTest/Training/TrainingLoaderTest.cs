using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using TrainingSets.Training;
using TrainingSets.Utils;
using Xunit;

namespace ModuleTest.Training
{
  public class TrainingLoaderTest
  {
    private TrainingLoader _tLoader                         = new TrainingLoader();
    private ObservableCollection<TrainingItem> _trainingSet = new ObservableCollection<TrainingItem>();
    private TrainingItem _iItem                             = new TrainingItem();
    private List<int> _sets                                 = new List<int>();
    private JsonIO _jsonIO                                  = new JsonIO();
    private static string _nameFileTest                     = "ListTrainingsTest.txt";
    private static string _path                             = Directory.GetCurrentDirectory() + "\\" + _nameFileTest;

    public TrainingLoaderTest()
    {
      _sets.Add(1);
      _trainingSet.Add(_iItem);
    }

    public static IEnumerable<object> EnumerablePath => new[]
    {
      new object[] { _path, 1 },
      new object[] { string.Empty, 0 }
    };

    [Theory, MemberData("EnumerablePath")]
    public void LoadTest(string path, int count)
    {
      ObservableCollection<TrainingItem> objectActual = _tLoader.Load(path);
      Assert.Equal(count, objectActual.Count);
    }
  }
}