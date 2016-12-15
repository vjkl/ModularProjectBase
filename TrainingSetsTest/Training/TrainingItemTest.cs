using System.Linq;
using TrainingSets.Training;
using Xunit;

namespace ModuleTest.Training
{
  public class TrainingItemTest
  {
    private TrainingItem _trainingItem = new TrainingItem();

    [Theory]
    [InlineData(0)]
    [InlineData(4)]
    [InlineData(-5)]
    [InlineData(25)]
    public void GetCountPullUpsText(int countPullUps)
    {
      int count = _trainingItem.GetCountPullUps(countPullUps);
      Assert.True(count >= TrainingItem.MinCountPullUps && count <= TrainingItem.MaxCountPullUps);
    }

    [Fact]
    public void ChangeCountSetsTest()
    {
      _trainingItem.Sets.Clear();
      _trainingItem.ChangeCountSets();
      Assert.Equal(_trainingItem.CountPullUps, _trainingItem.Sets.Count);
    }

    [Theory]
    [InlineData(new[] { 1, 2 })]
    [InlineData(new[] { 1, 2, 3 })]
    [InlineData(new[] { 1, 2, 3, 4, 5 })]
    public void GetSumPullUpsTest(int[] sets)
    {
      _trainingItem.Sets.Clear();
      int sum = 0;
      for (int i = 0; sets.Length > i; i++)
      {
        sum += sets[i];
        _trainingItem.Sets.Add(new TrainingSet(sets[i]));
      }
      Assert.Equal(sum, _trainingItem.GetSumPullUps());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    public void AddTest(int count)
    {
      _trainingItem.Sets.Clear();
      while (count != _trainingItem.Sets.Count)
      {
        _trainingItem.Add(new TrainingSet());
      }
      Assert.Equal(count, _trainingItem.Sets.Count);
    }

    [Fact]
    public void RemoveTest()
    {
      TrainingSet item = new TrainingSet();
      _trainingItem.Sets.Clear();
      _trainingItem.Sets.Add(item);
      _trainingItem.Remove(_trainingItem.Sets.FirstOrDefault());

      Assert.Empty(_trainingItem.Sets);
    }
  }
}