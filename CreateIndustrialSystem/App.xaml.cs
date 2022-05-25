using CreateIndustrialSystem.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CreateIndustrialSystem
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            GlobalMonitorModel.Start(
                () =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        new MainWindow().Show();
                    });
                },
                (msg) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show(msg, "系统启动失败");
                        Application.Current.Shutdown();
                    });
                });
        }

        protected override void OnExit(ExitEventArgs e)
        {
            GlobalMonitorModel.Dispose();

            base.OnExit(e);
        }
    }
}
