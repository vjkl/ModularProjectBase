using Caliburn.Micro;
using Newtonsoft.Json;

namespace TrainingSets.Training
{
  [JsonObject(MemberSerialization.OptIn)]
  public class OneSet : PropertyChangedBase
  {
    public bool NoErrors = true;

    public OneSet() { }
    public OneSet(int count)
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

    public OneSet Clone()
    {
      return new OneSet(Count);
    }
  }
}
