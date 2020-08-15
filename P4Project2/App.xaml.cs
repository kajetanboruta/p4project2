using Autofac;
using P4Project2.DBContext;
using P4Project2.Models;
using P4Project2.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace P4Project2
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Logger>().AsSelf();
            builder.RegisterType<ClientView>().AsSelf();
            builder.RegisterType<Context>().AsSelf();
            builder.RegisterType<Menu>().AsSelf();
            builder.RegisterType<FightModel>().AsSelf();

            var container = builder.Build();

            using(var scope = container.BeginLifetimeScope()){
                var window = scope.Resolve<ClientView>();
                window.Show();
            };
        }
    }
}
