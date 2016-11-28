using System.Collections.Generic;
using System.Collections.ObjectModel;
using TrainingSets.Training;
using Xunit;
using Caliburn.Micro;

namespace ModuleTest.Training
{
  public class TItemTest
  {
    private int _oneSet = 1;
    private int _twoSet = 2;
    private int _threeSet = 3;

    [Fact]
    public void TItem()
    {
      ObservableCollection<OneSet> sets = new ObservableCollection<OneSet>();
      sets.Add(new OneSet(_oneSet));
      sets.Add(new OneSet(_twoSet));
      sets.Add(new OneSet(_threeSet));

      int sum = _oneSet + _twoSet + _threeSet;
      TItem iItem = new TItem(sets);

      Assert.Equal(sum, iItem.TotalCount);
      OneSet oneSet = new OneSet(0);
      iItem.Add(oneSet);
      Assert.Equal(4, iItem.Sets.Count);

      iItem.Remove(oneSet);
      Assert.Equal(3, iItem.Sets.Count);
    }
  }
}