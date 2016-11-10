using Module.Training;
using Module.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ModuleTest.Training
{
  public class TLoaderTest
  {
    private TLoader _tLoader;
    private ObservableCollection<TItem> _trainingSet;
    private TItem _iItem;
    private List<int> _sets;

    JsonIO jsonIO = new JsonIO();

    private static string _nameFileTest = "ListTrainingsTest.txt";
    private string _path = Directory.GetCurrentDirectory() + "\\" + _nameFileTest;

    public TLoaderTest()
    {
      _tLoader = new TLoader();
      _trainingSet = new ObservableCollection<TItem>();
      _iItem = new TItem();
      _sets = new List<int>();
      _sets.Add(1);
      _trainingSet.Add(_iItem);
    }

    [Fact]
    public void LoadTest()
    {
      ObservableCollection<TItem> objectActualEmpty = _tLoader.Load(string.Empty);
      Assert.Equal(TLoader.Empty, objectActualEmpty);

      ObservableCollection<TItem> objectActual = _tLoader.Load(_path);
      Assert.Equal(1, objectActual.Count);
    }
  }
}