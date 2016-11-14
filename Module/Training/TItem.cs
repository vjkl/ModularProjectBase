using Caliburn.Micro;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Module.Training
{
  [JsonObject(MemberSerialization.OptIn)]
  public class TItem : PropertyChangedBase
  {

    public TItem() { }
    public TItem(ObservableCollection<OneSet> sets)
    {
      TrainingData = DateTime.Now;
      sets.Apply(set => Add(set));
      TotalCount = GetSumPullUps();
    }

    public void RefreshSets()
    {
      NotifyOfPropertyChange(() => Sets);
      TotalCount = GetSumPullUps();
      NotifyOfPropertyChange(() => TotalCount);
    }

    public void Add(OneSet item)
    {
      if (item == null) return;
      Sets.Add(item);
      item.CountChanged += RefreshSets;
      RefreshSets();
    }

    public void Remove(OneSet item)
    {
      if (item == null) return;
      item.CountChanged -= RefreshSets;
      Sets.Remove(item);
      RefreshSets();
    }

    private DateTime _trainingDate;
    [JsonProperty]
    public DateTime TrainingData
    {
      get { return _trainingDate; }
      set
      {
        if (_trainingDate == value) return;
        _trainingDate = value;
      }
    }

    private ObservableCollection<OneSet> _sets;
    [JsonProperty]
    public ObservableCollection<OneSet> Sets
    {
      get { return _sets ?? (Sets = new ObservableCollection<OneSet>()); }
      set
      {
        if (_sets == value) return;
        _sets = value;
        RefreshSets();
      }
    }

    private int _totalCount;
    [JsonProperty]
    public int TotalCount
    {
      get { return _totalCount; }
      set
      {
        if (_totalCount == value) return;
        _totalCount = value;
        NotifyOfPropertyChange(() => TotalCount);
      }
    }

    public int GetSumPullUps()
    {
      int sum = 0;
      foreach (OneSet set in Sets)
        sum += set.Count;
      return sum;
    }
  }
}
