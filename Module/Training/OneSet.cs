using Caliburn.Micro;
using Module.Validator;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Module.Training
{
  [JsonObject(MemberSerialization.OptIn)]
  public class OneSet : PropertyChangedBase, IDataErrorInfo
  {
    private readonly IValidator _validator = new PropertyValidator();
    public bool NoErrors => string.IsNullOrEmpty(Error);

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
    [Required(ErrorMessage = "RequiredField")]
    [RegularExpression(RegularExpressions.OnlyNumbers
                  , ErrorMessage = "OnlyNumbers")]
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

    public string this[string columnName]
    {
      get
      {
        var temp = _validator.GetSinglePropertyError(this, columnName);
        Error = string.IsNullOrEmpty(temp) ? _validator.GetAnyPropertyError(this)
                                           : temp;
        return temp;
      }
    }

    private string _error;
    public string Error
    {
      get { return _error; }
      set
      {
        if (_error == value) return;
        _error = value;
        OnCountChange();
      }
    }

    public OneSet Clone()
    {
      return new OneSet(Count);
    }
  }
}
