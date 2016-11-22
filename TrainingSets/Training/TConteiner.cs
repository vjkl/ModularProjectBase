using Caliburn.Micro;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TrainingSets.Training
{
  public class TConteiner : PropertyChangedBase
  {
    private int _minCountPullUps = 1;
    private int _maxCountPullUps = 20;
    private int _averageCountPullUps = 4;
    public bool isChange = false;

    public TConteiner()
    {
      OnActivate();
    }

    protected void OnActivate()
    {
      TrainingSets.CollectionChanged += OnCollectionChanged;
      OnDataChange();
    }

    protected void OnDeactivate()
    {
      TrainingSets.CollectionChanged -= OnCollectionChanged;
      OnDataChange();
    }

    public delegate void DataChangesEventHandler();
    public event DataChangesEventHandler DataChanged;
    public virtual void OnDataChange()
    {
      DataChanged?.Invoke();
    }

    public void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
      System.Collections.Specialized.NotifyCollectionChangedAction action = e.Action;
      isChange = true;
    }

    private ObservableCollection<TItem> _trainingSet;
    public ObservableCollection<TItem> TrainingSets
    {
      get { return _trainingSet ?? (_trainingSet = new ObservableCollection<TItem>()); }
      set
      {
        if (_trainingSet == value) return;
        _trainingSet = value;
        NotifyOfPropertyChange(() => TrainingSets);
        OnDataChange();
      }
    }

    private TItem _selectedTItem;
    public TItem SelectedTItem
    {
      get { return _selectedTItem ?? (_selectedTItem = new TItem()); }
      set
      {
        if (_selectedTItem == value) return;
        _selectedTItem = value;
        if (SelectedTItem != null)
          CountPullUps = SelectedTItem.Sets.Count;
        NotifyOfPropertyChange(() => SelectedTItem);
        NotifyOfPropertyChange(() => CountPullUps);
        OnDataChange();
      }
    }

    private int _countPullUps;
    public int CountPullUps
    {
      get { return _countPullUps != default(int) ? _countPullUps : (_countPullUps = _averageCountPullUps); }
      set
      {
        if (_countPullUps == value) return;
        {
          if (value > default(int))
          {
            _countPullUps = GetCountPullUps(value);
            ChangeCountSets(SelectedTItem);
            NotifyOfPropertyChange(() => CountPullUps);
            NotifyOfPropertyChange(() => SelectedTItem);
            OnDataChange();
          }
        }
      }
    }

    private int GetCountPullUps(int countPullUps)
    {
      if (countPullUps > _maxCountPullUps)
        return _maxCountPullUps;
      else if (countPullUps < _minCountPullUps)
        return _minCountPullUps;
      else return countPullUps;
    }

    public void Remove(TItem trainingItem)
    {
      TrainingSets.Remove(trainingItem);
      NotifyOfPropertyChange(() => SelectedTItem);
      OnDataChange();
    }

    public void Add()
    {
      if (SelectedTItem.Sets.Count != 0)
        TrainingSets.Add(ChangeCountSets(new TItem()));
      else
        TrainingSets.Add(ChangeCountSets(new TItem()));
      OnDataChange();
    }

    public void Clear()
    {
      TrainingSets.Clear();
      OnDataChange();
    }

    public void AddRange(IList<TItem> items)
    {
      SelectedTItem.Sets.Apply(x => x = new OneSet());
      if (items.Count != default(int))
        Clear();
      foreach (var item in items)
        TrainingSets.Add(new TItem(item.Sets));
      isChange = false;
      OnDataChange();
    }

    public TItem ChangeCountSets(TItem tItem)
    {
      int amountSets = GetAmountSets(tItem);
      ChangeCountSets(tItem, amountSets);
      NotifyOfPropertyChange(() => TrainingSets);
      foreach (var item in TrainingSets)
        NotifyOfPropertyChange(() => item);
      return tItem;
    }

    private int GetAmountSets(TItem tItem)
    {
      if (tItem == null && tItem.Sets.Count == default(int))
        return default(int);
      return tItem.Sets.Count;
    }

    private void ChangeCountSets(TItem tItem, int amountSets)
    {
      for (int i = amountSets; i < _countPullUps; i++)
        tItem.Add(new OneSet());
      for (int i = amountSets; i > _countPullUps; i--)
        tItem.Remove(tItem.Sets[tItem.Sets.Count - 1]);
    }
  }
}