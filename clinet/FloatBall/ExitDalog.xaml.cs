using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FloatBall.Core;
namespace FloatBall
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class ExitDalog : Window
    {
        public ExitDalog()
        {
            InitializeComponent();
        }
        private void ClCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ClExit(object sender, RoutedEventArgs e)
        {
            this.Close();
            Core.MouseHook mouseHook = new MouseHook();
            
            // 检查用户选择的选项
            if (MinimizeToTray.IsChecked == true)
            {
                // 最小化到系统托盘的逻辑
                var mainWindow = Application.Current.MainWindow as MainWindow;
                if (mainWindow != null)
                {
                    // 隐藏主窗口
                    mainWindow.Hide();

                    
                }

            }
            else if (CloseApplication.IsChecked == true)
            {
                // 关闭整个应用程序
                App.Current.Shutdown();
            }
        }
    }
}
