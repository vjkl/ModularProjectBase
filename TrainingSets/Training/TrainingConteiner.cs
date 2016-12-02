using Caliburn.Micro;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace TrainingSets.Training
{
  public class TrainingConteiner : PropertyChangedBase
  {
    public bool isChange = false;

    public TrainingConteiner()
    {
      SortByDateTrainingSets = CollectionViewSource.GetDefaultView(TrainingSets);
      SortByDateTrainingSets.SortDescriptions.Add(new SortDescription("TrainingData", ListSortDirection.Descending));
      TrainingSets.CollectionChanged += OnCollectionChanged;
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

    private ObservableCollection<TrainingItem> _trainingSet;
    public ObservableCollection<TrainingItem> TrainingSets
    {
      get { return _trainingSet ?? (_trainingSet = new ObservableCollection<TrainingItem>()); }
      set
      {
        if (_trainingSet == value) return;
        _trainingSet = value;
        NotifyOfPropertyChange(() => TrainingSets);
        OnDataChange();
      }
    }

    private ICollectionView _sortByDateTrainingSets;
    public ICollectionView SortByDateTrainingSets
    {
      get { return _sortByDateTrainingSets; }
      set
      {
        if (_sortByDateTrainingSets == value) return;
        _sortByDateTrainingSets = value;
        NotifyOfPropertyChange(() => SortByDateTrainingSets);
      }
    }

    private TrainingItem _selectedTItem;
    public TrainingItem SelectedTItem
    {
      get { return _selectedTItem ?? (_selectedTItem = new TrainingItem(true)); }
      set
      {
        if (_selectedTItem == value) return;
        _selectedTItem = value;
        NotifyOfPropertyChange(() => SelectedTItem);
        OnDataChange();
      }
    }

    public void Remove(TrainingItem trainingItem)
    {
      bool isSelected = SelectedTItem == trainingItem;
      TrainingSets.Remove(trainingItem);
      if (isSelected) SelectedTItem = TrainingSets.LastOrDefault();

      OnDataChange();
    }

    public void Add()
    {
      TrainingSets.Add(new TrainingItem(true));
      SelectedTItem = TrainingSets.LastOrDefault();
      foreach (var item in TrainingSets)
        NotifyOfPropertyChange(() => item);
      OnDataChange();
    }

    public void Clear()
    {
      TrainingSets.Clear();
      OnDataChange();
    }

    public void AddRange(IList<TrainingItem> items)
    {
      Clear();
      foreach (var item in items)
      {
        TrainingSets.Add(item.SubcribeTrainingSet());
      }

      SelectedTItem = TrainingSets.LastOrDefault();
      isChange = false;
      OnDataChange();
    }

    public void Change(bool isSave)
    {
      if (isSave)
      {
        TrainingSets.Apply(x => x.IsNew = false);
        isChange = false;
      }
    }

    public int CountTrainingSets
    {
      get { return TrainingSets.Count; }
    }
  }
}