using Caliburn.Micro;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TrainingSets.Training;
using Xunit;

namespace ModuleTest.Training
{
  public class TrainingConteinerTest
  {
    private TrainingConteiner _tConteiner  = new TrainingConteiner();
    private List<TrainingItem> _listTItems = new List<TrainingItem>();

    [Fact]
    public void AddTest()
    {
      _tConteiner.Clear();
      _tConteiner.Add();
      Assert.Equal(1, _tConteiner.CountTrainingSets);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    public void RemoveTest(int count)
    {
      _listTItems.Clear();
      _tConteiner.Clear();
      FillingListTrainingItem(_listTItems, count);
      _tConteiner.AddRange(_listTItems);
      foreach (TrainingItem item in _listTItems)
        _tConteiner.Remove(item);

      Assert.Equal(default(int), _tConteiner.CountTrainingSets);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    public void AddRangeTest(int count)
    {
      _tConteiner.Clear();
      _listTItems.Clear();
      FillingListTrainingItem(_listTItems, count);
      _tConteiner.AddRange(_listTItems);

      Assert.Equal(count, _tConteiner.CountTrainingSets);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(3, false)]
    [InlineData(5, false)]
    public void ChangeTest(int count, bool isSave)
    {
      _tConteiner.Clear();
      FillingListTrainingItem(_tConteiner.TrainingSets, count);
      _tConteiner.TrainingSets.Apply(set => set.IsNew = isSave);
      _tConteiner.isChange = isSave;

      _tConteiner.Change(isSave);

      _tConteiner.TrainingSets.Apply(x => Assert.Equal(false, x.IsNew));
      Assert.Equal(false, _tConteiner.isChange);
    }

    public void FillingListTrainingItem(IList<TrainingItem> trainingSets, int count)
    {
      for (int i = 0; count > i; i++)
        trainingSets.Add(new TrainingItem());
    }
  }
}