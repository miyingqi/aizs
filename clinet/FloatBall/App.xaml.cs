using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace FloatBall
{
    
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            
            _taskbar = (TaskbarIcon)FindResource("Taskbar");
            base.OnStartup(e);

        }

        private TaskbarIcon _taskbar;
    }
}