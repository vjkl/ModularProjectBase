using BioContracts.Castle;
using BioContracts.Logging;
using Caliburn.Micro;
using System;
using System.Linq;
using System.Windows.Threading;

namespace Module.ViewModels
{
  public class TabViewModel : Conductor<IScreen>.Collection.OneActive
  {
    private readonly IContainer _container;
    private Dispatcher _dispatcher;
    private ILogger _logger;

    public IScreen DefaultPage { get; set; }

    public TabViewModel(IContainer container)
    {
      _container = container;
      TryResolveDependencies();

      PropertyChanged += PageChanged;
      Items.CollectionChanged += ItemsChanged;
    }

    public void Show<T>()
    {
      try
      {
        var screen = _container.Resolve<T>() as IScreen;
        ActivatePage(screen);
      }
      catch (Exception exception)
      {
        _logger?.Error(exception);
      }
    }

    private void ActivatePage(IScreen screen)
    {
      if (screen == null)
        return;

      var existing = Items.FirstOrDefault(x => x.Equals(screen));
      if (existing == null)
        Items.Add(screen);
      ActivateCurrentItem(screen);
    }

    private void PageChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (ActiveItem == null || ActiveItem.IsActive) return;
      ActivateCurrentItem(ActiveItem);
    }

    private void ActivateCurrentItem(IScreen screen)
    {
      ActivateItem(screen);
      ActiveItem.Activate();
    }

    private void ItemsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
      if (Items.Count == 0)
        _dispatcher?.InvokeAsync(() => { ActivatePage(DefaultPage); });
    }
    private void TryResolveDependencies()
    {
      try
      {
        _logger = _container.Resolve<ILogger>();
        _dispatcher = _container.Resolve<Dispatcher>();
      }
      catch (Exception exception)
      {
        _logger?.Error(exception);
      }
    }
  }
}
