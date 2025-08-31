using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FloatBall.Core;
namespace FloatBall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object? sender, CancelEventArgs e)
        {
            bool isSystemClose = (Keyboard.Modifiers == ModifierKeys.Alt &&Keyboard.IsKeyDown(Key.F4));
            if (!isSystemClose)
            {
                e.Cancel = true; // 阻止默认关闭
                ExitDalog window = new();
                window.Owner = this; // 设置父窗口
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner; // 相对于父窗口居中
                window.ShowDialog();
            }
        }

    }
}