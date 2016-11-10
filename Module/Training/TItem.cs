using System;
using System.Collections.Generic;

namespace Module.Training
{
  public class TItem
  {
    private DateTime  _trainingDate { get; set; }
    private List<int> _sets         { get; set; }
    private int       _totalCount   { get; set; }

    public TItem() { }
    public TItem(List<int> sets)
    {
      TrainingData = DateTime.Now;
      Sets = sets;
      TotalCount = GetSumPullUps(sets);
    }

    public DateTime TrainingData
    {
      get { return _trainingDate; }
      set
      {
        if (_trainingDate == value) return;
        _trainingDate = value;
      }
    }

    public List<int> Sets
    {
      get { return _sets; }
      set
      {
        if (_sets == value) return;
        _sets = value;
      }
    }

    public int TotalCount
    {
      get { return _totalCount; }
      set
      {
        if (_totalCount == value) return;
        _totalCount = value;
      }
    }

    private int GetSumPullUps(List<int> sets)
    {
      int sum = 0;
      foreach(int set in sets)
      {
        sum += set;
      }
      return sum;
    }
  }
}
