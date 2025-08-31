using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml.Linq;

namespace FloatBall
{
    public partial class Fball : Window
    {
        #nullable enable
        private DispatcherTimer? menuOpenTimer;
        private DateTime menuTimerStart;
        bool drap = false;
        bool enter = false;
        public Fball()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            drap = true;
            this.DragMove();
        }

        private void Ball_m_right_down(object sender, MouseButtonEventArgs e)
        {
            ballContextMenu.IsOpen = true;
            e.Handled = true;

        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                MessageBox.Show($"您选择了: {menuItem.Header}");
            }
        }

        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            msgbox.Visibility = Visibility.Visible;
            ball_grid.UpdateLayout();
            // 延申大小
            double extensionWidth = msgbox.ActualWidth;
            //  记录当前窗口右侧位置
            double currentRight = this.Left + this.Width;
            // 扩展窗口宽度
            this.Width += extensionWidth+1;
            // 4. 向左移动窗口位置（保持右侧不变）
            this.Left = currentRight - this.Width;
            this.UpdateLayout();
        }

        private void MenuItem3_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                MessageBox.Show($"您选择了: {menuItem.Header}");
            }
        }
        // 退出菜单项
        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void ball_MouseEnter(object sender, MouseEventArgs e)
        {
            enter= true;
            await Task.Delay(600);
            if (!drap)
                ShowMenuAtBottom();
        }

        private void ShowMenuAtBottom()
        {
            if (ballContextMenu.IsOpen)
            {
                return;
            }

            // 获取当前鼠标相对于悬浮球的位置
            Point mousePos = Mouse.GetPosition(ball);

            // 检查鼠标是否在悬浮球范围内
            if (mousePos.X < 0 || mousePos.X > ball.ActualWidth ||
                mousePos.Y < 0 || mousePos.Y > ball.ActualHeight)
            {
                return;
            }

            ballContextMenu.Placement = PlacementMode.Bottom;
            ballContextMenu.PlacementTarget = ball_grid;
            ballContextMenu.IsOpen = true;

        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            drap = false;
        }

    }
}