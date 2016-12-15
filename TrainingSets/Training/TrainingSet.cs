using Caliburn.Micro;
using Newtonsoft.Json;

namespace TrainingSets.Training
{
  [JsonObject(MemberSerialization.OptIn)]
  public class TrainingSet : PropertyChangedBase
  {
    public TrainingSet() { }
    public TrainingSet(int count)
    {
      Count = count;
    }

    public delegate void CountChangesEventHandler();
    public event CountChangesEventHandler CountChanged;
    public virtual void OnCountChange()
    {
      CountChanged?.Invoke();
    }

    private int _count = default(int);
    [JsonProperty]
    public int Count
    {
      get { return _count; }
      set
      {
        if (_count == value && value < default(int)) return;
        _count = value;
        NotifyOfPropertyChange(() => Count);
        OnCountChange();
      }
    }

    public TrainingSet Clone()
    {
      return new TrainingSet(Count);
    }
  }
}
