using System;
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

      builder.RegisterType<MainWindow>().AsSelf().SingleInstance();
      builder.RegisterType<ApplicationViewModel>().AsSelf().SingleInstance();
    }
  }
}