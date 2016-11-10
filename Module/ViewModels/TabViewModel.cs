using Caliburn.Micro;
using System.Linq;
using Module.Training;

namespace Module.ViewModels
{
  public class TabViewModel : Screen
  {
    public TConteiner tConteiner { get; } =  new TConteiner();

    public bool CanApplyTPluss => tConteiner.GenerateCountTrainingSets.All(set => set.NoErrors);
    public bool CanApplyTSave  => tConteiner.isChange                                          ;

    public TabViewModel()
    {
      OnActivate();
      tConteiner.InitTrainingSets();
      RefreshUi();
    }

    protected override void OnActivate()
    {
      tConteiner.DataChanged += RefreshUi;
      base.OnActivate();
    }

    protected override void OnDeactivate(bool close)
    {
      tConteiner.DataChanged -= RefreshUi;
      base.OnDeactivate(close);
    }

    public void RefreshUi()
    {
      NotifyOfPropertyChange(() => CanApplyTPluss);
      NotifyOfPropertyChange(() => CanApplyTSave) ;
    }
  }
}
