using Module.Training;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace ModuleTest.Training
{
  public class TConteinerTest
  {
    private int amountSets         = 1               ;
    private TConteiner _tConteiner = new TConteiner();
    private TItem _tItem           = new TItem()     ;
    private List<int> _listInt     = new List<int>() ;
    private ObservableCollection<TItem> _trainingSets;
    private ObservableCollection<OneSet> _generateCountTrainingSets;

    public TConteinerTest()
    {
      _listInt.Add(33);
      _listInt.Add(20);
      _tItem = new TItem(_listInt);
      _trainingSets = _tConteiner.TrainingSets;

      _generateCountTrainingSets = _tConteiner.GenerateCountTrainingSets;
    }

    [Fact]
    public void Remove()
    {
      _trainingSets.Add(_tItem);
      _tConteiner.Remove(_tItem);
      Assert.Empty(_trainingSets);
    }

    [Fact]
    public void Pluss()
    {
      _generateCountTrainingSets.Add(new OneSet(_tConteiner));
      _generateCountTrainingSets[0].Count = "21";
      _tConteiner.Pluss();

      Assert.True(_generateCountTrainingSets.All(x => string.IsNullOrEmpty(x.Count)));
      Assert.Equal(1, _trainingSets.Count);
    }

    [Fact]
    public void AddSet()
    {
      _tConteiner.AddSet(amountSets);
      Assert.Equal(amountSets, _generateCountTrainingSets.Count);
    }

    [Fact]
    public void TraningChangeSetsЕуіе()
    {
      _tConteiner.TraningChangeSets(amountSets);
      Assert.Equal(amountSets, _generateCountTrainingSets.Count);
      Assert.True(_generateCountTrainingSets.All(x => string.IsNullOrEmpty(x.Count)));
    }
  }
}