using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TrainingSets.Training;
using Xunit;

namespace ModuleTest.Training
{
  public class TConteinerTest
  {
    private TConteiner _tConteiner = new TConteiner();
    private TItem _tItem = new TItem();
    private List<int> _listInt = new List<int>();
    List<TItem> tItems = new List<TItem>();
    private ObservableCollection<TItem> _trainingSets;

    public TConteinerTest()
    {
      ObservableCollection<OneSet> listOneSets = new ObservableCollection<OneSet>();
      listOneSets.Add(new OneSet(33));
      listOneSets.Add(new OneSet(20));
      _tItem = new TItem(listOneSets);
      _trainingSets = _tConteiner.TrainingSets;
    }

    [Fact]
    public void AddAndRemove()
    {
      _trainingSets.Add(_tItem);
      Assert.Equal(1, _trainingSets.Count);
      _tConteiner.Remove(_tItem);
      Assert.Empty(_trainingSets);
    }

    [Fact]
    public void ClearAndAddRange()
    {
      _trainingSets.Add(new TItem());
      _trainingSets.Clear();
      Assert.Empty(_trainingSets);

      tItems.Add(_tItem);
      _tConteiner.AddRange(tItems);
      Assert.Equal(1, _tConteiner.TrainingSets.Count);
    }

    [Fact]
    public void ChangeCountSetsTest()
    {
      _trainingSets.Clear();
      Assert.Equal(4, _tConteiner.ChangeCountSets(new TItem()).Sets.Count);
    }
  }
}