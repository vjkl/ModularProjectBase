using Module.Training;
using System.Collections.Generic;
using Xunit;

namespace ModuleTest.Training
{
  public class TItemTest
  {
    private int _oneSet   = 1;
    private int _twoSet   = 2;
    private int _threeSet = 3;

    [Fact]
    public void ConstructorTItem()
    {
      List<int> sets = new List<int>();
      sets.Add(_oneSet);
      sets.Add(_twoSet);
      sets.Add(_threeSet);

      int sum = _oneSet + _twoSet + _threeSet;
      TItem iItem = new TItem(sets);

      Assert.Equal(sum, iItem.TotalCount);
    }
  }
}
