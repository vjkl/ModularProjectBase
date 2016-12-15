using Caliburn.Micro;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace TrainingSets.Training
{
  [JsonObject(MemberSerialization.OptIn)]
  public class TrainingItem : PropertyChangedBase
  {
    public static int MinCountPullUps = 1;
    public static int MaxCountPullUps = 20;
    public static int AverageCountPullUps = 4;

    public TrainingItem() { }
    public TrainingItem(bool isChangeCountSets)
    {
      TrainingData = DateTime.Now;
      IsNew = true;
      if (isChangeCountSets)
        ChangeCountSets();
    }

    public TrainingItem SubcribeTrainingSet()
    {
      foreach (TrainingSet set in Sets)
        set.CountChanged += RefreshSets;
      return this;
    }

    public void RefreshSets()
    {
      NotifyOfPropertyChange(() => Sets);
      TotalCount = GetSumPullUps();
      NotifyOfPropertyChange(() => TotalCount);
      NotifyOfPropertyChange(() => CountPullUps);
    }

    public void Add(TrainingSet item)
    {
      if (item == null) return;
      Sets.Add(item);
      item.CountChanged += RefreshSets;
      RefreshSets();
    }

    public void Remove(TrainingSet item)
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

    private ObservableCollection<TrainingSet> _sets;
    [JsonProperty]
    public ObservableCollection<TrainingSet> Sets
    {
      get { return _sets ?? (Sets = new ObservableCollection<TrainingSet>()); }
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

    private int _countPullUps;
    [JsonProperty]
    public int CountPullUps
    {
      get { return _countPullUps != default(int) ? _countPullUps : (_countPullUps = GetCountPullUps(default(int))); }
      set
      {
        if (_countPullUps == value) return;
        _countPullUps = GetCountPullUps(value);
        ChangeCountSets();
        RefreshSets();
      }
    }

    public int GetCountPullUps(int countPullUps)
    {
      if (countPullUps == 0) return AverageCountPullUps;
      if (countPullUps > MaxCountPullUps)
        return MaxCountPullUps;
      else if (countPullUps < MinCountPullUps)
        return MinCountPullUps;
      else return countPullUps;
    }

    public void ChangeCountSets()
    {
      if (Sets.Count < CountPullUps)
      {
        for (int i = Sets.Count; i < CountPullUps; i++)
          Add(new TrainingSet());
      }
      else if (Sets.Count > CountPullUps)
      {
        for (int i = Sets.Count; i > CountPullUps; i--)
          Remove(this.Sets[this.Sets.Count - 1]);
      }
    }

    public int GetSumPullUps()
    {
      int sum = 0;
      foreach (TrainingSet set in Sets)
        sum += set.Count;
      return sum;
    }

    private bool _isItem = false;
    public bool IsNew
    {
      get { return _isItem; }
      set
      {
        if (_isItem == value) return;
        _isItem = value;
        NotifyOfPropertyChange(() => IsNew);
      }
    }
  }
}
