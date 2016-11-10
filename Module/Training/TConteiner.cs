using Caliburn.Micro;
using Module.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Module.Training
{
  public interface ISetsHolder
  {
    void OnChanges();
  }

  public class TConteiner : PropertyChangedBase, ISetsHolder
  {
    public bool isChange = false;
    private FileIO fileIO = new FileIO();
    private JsonIO jsonIO = new JsonIO();
    private TLoader tLoader = new TLoader();

    public delegate void DataChangesEventHandler();
    public event DataChangesEventHandler DataChanged;
    protected virtual void OnDataChange()
    {
      DataChanged?.Invoke();
    }

    public void OnChanges()
    {
      OnDataChange();
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

    private ObservableCollection<OneSet> _generateCountTrainingSets;
    public ObservableCollection<OneSet> GenerateCountTrainingSets
    {
      get { return _generateCountTrainingSets ?? (_generateCountTrainingSets = new ObservableCollection<OneSet>()); }

      set
      {
        if (_generateCountTrainingSets == value) return;
        _generateCountTrainingSets = value;
        NotifyOfPropertyChange(() => GenerateCountTrainingSets);
        OnDataChange();
      }
    }

    private string _countPullUps = "4";
    public string CountPullUps
    {
      get { return _countPullUps; }
      set
      {
        if (_countPullUps == value) return;
        {
          string countPullUps = StringUtils.GetAllNumberFromString(value);
          if (!string.IsNullOrEmpty(countPullUps))
          {
            _countPullUps = countPullUps;
            int intCountSets = Convert.ToInt32(countPullUps);
            TraningChangeSets(intCountSets);
            NotifyOfPropertyChange(() => CountPullUps);
            OnDataChange();
          }
        }
      }
    }

    public void InitTrainingSets()
    {
      GenerateCountTrainingSets = new ObservableCollection<OneSet>();
      AddSet(Convert.ToInt32(CountPullUps));
      TrainingSets = tLoader.InitTrainingSets();
    }

    public void Remove(TItem trainingItem)
    {
      TrainingSets.Remove(trainingItem);
      isChange = true;
      OnDataChange();
    }

    public void Pluss()
    {
      if (GenerateCountTrainingSets.Count > 0)
      {
        TrainingSets.Add(GetSets(GenerateCountTrainingSets));
      }
      GenerateCountTrainingSets.Apply(x => x.Clear());
      isChange = true;
      OnDataChange();
    }

    public void AddSet(int amountSets)
    {
      while (amountSets > 0)
      {
        GenerateCountTrainingSets.Add(new OneSet(this));
        amountSets--;
      }
    }

    public void TraningChangeSets(int countSets)
    {
      GenerateCountTrainingSets.Clear();
      AddSet(countSets);
    }

    public void LoadFromFile()
    {
      Pluss();
      TrainingSets = tLoader.Load(GetPathToFileFromDialog());
      isChange = false;
      OnDataChange();
    }

    public void SaveToFile()
    {
      tLoader.Save(TrainingSets);
      isChange = false;
      OnDataChange();
    }

    private TItem GetSets(ObservableCollection<OneSet> generateCountTrainingSets)
    {
      List<int> listPullUps = new List<int>();
      for (int i = 0; generateCountTrainingSets.Count > i; ++i)
        listPullUps.Add(GetSet(generateCountTrainingSets[i].Count));
      return new TItem(listPullUps);
    }

    private int GetSet(string set)
    {
      if (!string.IsNullOrEmpty(set) && StringUtils.CheckStringISNumber(set))
        return Convert.ToInt32(set);
      else
        return 0;
    }

    private string GetPathToFileFromDialog()
    {
      System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

      openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
      openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
      openFileDialog.FilterIndex = 2;
      openFileDialog.RestoreDirectory = true;

      if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        return openFileDialog.FileName;
      }
      return string.Empty;
    }
  }
}