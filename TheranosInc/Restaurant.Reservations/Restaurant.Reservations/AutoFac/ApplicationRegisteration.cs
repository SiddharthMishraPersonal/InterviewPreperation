﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Restaurant.Reservations.View;
using Restaurant.Reservations.ViewModel;

namespace Restaurant.Reservations.AutoFac
{
  internal class ApplicationRegisteration : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      builder.RegisterType<SettingsView>().AsSelf().InstancePerDependency();
      builder.RegisterType<SettingsViewModel>().As<ViewModelBase>().AsSelf().SingleInstance();

      builder.RegisterType<TableViewModel>().As<ViewModelBase>().AsSelf().InstancePerDependency();

      builder.RegisterType<NewReservation>().AsSelf().InstancePerDependency();
      builder.RegisterType<ReservationViewModel>().As<ViewModelBase>().AsSelf().InstancePerDependency();

      builder.RegisterType<MainWindow>().AsSelf().SingleInstance();
      builder.RegisterType<ApplicationViewModel>().As<ViewModelBase>().AsSelf().SingleInstance();
    }
  }
}