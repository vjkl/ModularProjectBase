﻿using Caliburn.Micro;
using Module.Utils;
using Castle.Windsor;
using BioContracts.Castle;

namespace Module.ViewModels
{
  public class TabViewModel : Screen
  {
    private readonly IWindsorContainer _container;
    public DialogUtil dialogUtil { get; } = new DialogUtil();

    public TabViewModel(IWindsorContainer container)
    {
      _container = container;
      _training = container.Resolve<ITraining>();
      OnActivate();
      Training.Create();
    }

    public void Load()
    {
      Training.Load(dialogUtil.GetPathToFileFromDialog());
    }

    private ITraining _training;
    public ITraining Training
    {
      get { return _training; }
      set
      {
        if (_training == value) return;
        {
          _training = value;
          NotifyOfPropertyChange(() => _training);
        }
      }
    }
  }
}
