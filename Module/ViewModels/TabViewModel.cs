using Caliburn.Micro;
using System.Linq;
using Module.Training;
using Module.Utils;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Module.ViewModels
{
  public class TabViewModel : Screen
  {
    public DialogUtil dialogUtil { get; } = new DialogUtil();
    public TManager tManager     { get; } = new TManager()  ;
    public TConteiner tConteiner => tManager.tConteiner                                   ;
    public bool CanApplyTAdd     => tConteiner.SelectedTItem.Sets.All(set => set.NoErrors);
    public bool CanApplyTSave    => tConteiner.isChange                                   ;

    public TabViewModel()
    {
      OnActivate();
      tManager.Create();
      RefreshUi();
    }

    protected override void OnActivate()
    {
      tConteiner.TrainingSets.CollectionChanged += tConteiner.OnCollectionChanged;
      tConteiner.DataChanged += RefreshUi;
      base.OnActivate();
    }

    protected override void OnDeactivate(bool close)
    {
      tConteiner.TrainingSets.CollectionChanged -= tConteiner.OnCollectionChanged;
      tConteiner.DataChanged -= RefreshUi;
      base.OnDeactivate(close);
    }

    public void RefreshUi()
    {
      NotifyOfPropertyChange(() => CanApplyTAdd);
      NotifyOfPropertyChange(() => CanApplyTSave);
      NotifyOfPropertyChange(() => tConteiner.TrainingSets);
    }

    public void Load()
    {
      tManager.Load(dialogUtil.GetPathToFileFromDialog());
      RefreshUi();
    }

    public void Save()
    {
      tManager.Save();
      RefreshUi();
    }
  }
}
