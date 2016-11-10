using Caliburn.Micro;
using Module.Validator;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Module.Training
{
  public class OneSet : PropertyChangedBase, IDataErrorInfo
  {
    private ISetsHolder _holder                                          ;
    private readonly IValidator _validator =  new PropertyValidator()    ;
    public bool NoErrors                   => string.IsNullOrEmpty(Error);

    public OneSet(ISetsHolder holder)
    {
      _holder = holder;
    }

    private string _count = string.Empty;

    [Required(ErrorMessage = "RequiredField")]
    [RegularExpression(RegularExpressions.OnlyNumbers
                  , ErrorMessage = "OnlyNumbers")]
    public string Count
    {
      get { return _count; }
      set
      {
        if (_count == value) return;
        _count = value;
        NotifyOfPropertyChange(() => Count);
        _holder.OnChanges();
      }
    }

    public void Clear()
    {
      Count = "";
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
        _holder.OnChanges();
      }
    }
  }
}
