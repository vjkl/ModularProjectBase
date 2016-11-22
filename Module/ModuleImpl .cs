﻿using BioContracts.Castle;
using Module.ViewModels;
using System;

namespace Module
{
  class ModuleImpl : IModule
  {
    private readonly IShell _shell;
    private readonly TabViewModel _tabViewModel;

    public ModuleImpl(IShell shell, TabViewModel tabViewModel)
    {
      _shell = shell;
      _tabViewModel = tabViewModel;
    }

    public void DeInit()
    {
      throw new NotImplementedException();
    }

    public void Init()
    {
      _shell.TabControl = _tabViewModel;
    }
  }
}
