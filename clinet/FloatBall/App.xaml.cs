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
            try
            {
                _taskbar = (TaskbarIcon)FindResource("Taskbar");
            }
            catch (Exception ex)
            {
                // 处理资源查找失败的情况
                MessageBox.Show($"托盘图标加载失败: {ex.Message}");
            }
            base.OnStartup(e);
        }

        private TaskbarIcon _taskbar;
    }
}